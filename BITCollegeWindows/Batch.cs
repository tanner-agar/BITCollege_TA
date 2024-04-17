using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.ServiceModel.Channels;
using System.Diagnostics.Eventing.Reader;
using BITCollege_TA.Data;
using BITCollege_TA.Models;
using System.Xml;
using Utility;
using System.Globalization;
using System.ServiceModel.ComIntegration;
using BITCollegeService;
using BITCollegeWindows.CollegeRegistration;
using System.Windows.Forms;

namespace BITCollegeWindows
{
    /// <summary>
    /// Batch:  This class provides functionality that will validate
    /// and process incoming xml files.
    /// </summary>
    public class Batch
    {
        //string prop
        private String inputFileName;
        //string prop, corresponds with file name
        private String logFileName;
        //string prop, represents all data to be written to log file
        //corresponds with data being processed
        private String logData;

        XDocument xDocument;
        BITCollege_TAContext db = new BITCollege_TAContext();

        private void ProcessErrors(IEnumerable<XElement> beforeQuery, IEnumerable<XElement> afterQuery, string message)
        {
            //build the string for 
            StringBuilder logData = new StringBuilder();
            var failedRecords = beforeQuery.Except(afterQuery);

            if (failedRecords.Any())
            {
                logData.AppendLine($"Errors detected in {inputFileName}:");
                logData.AppendLine(message);

                // loop over the elements display N/A if does not exist
                foreach (var record in failedRecords)
                {
                    logData.AppendLine("-----------ERROR-------------");
                    logData.AppendLine($"File: {inputFileName}");

                    XElement programElement = record.Element("program");
                    logData.AppendLine($"Program: {programElement.Value ?? "N/A"}");

                    XElement studentNoElement = record.Element("student_no");
                    logData.AppendLine($"Student Number: {studentNoElement.Value ?? "N/A"}");

                    XElement courseNoElement = record.Element("course_no");
                    logData.AppendLine($"Course Number: {courseNoElement.Value ?? "N/A"}");

                    XElement registrationNoElement = record.Element("registration_no");
                    logData.AppendLine($"Registration Number: {registrationNoElement?.Value ?? "N/A"}");

                    XElement typeElement = record.Element("type");
                    logData.AppendLine($"Type: {typeElement.Value ?? "N/A"}");

                    XElement gradeElement = record.Element("grade");
                    logData.AppendLine($"Grade: {gradeElement.Value ?? "N/A"}");

                    XElement notesElement = record.Element("notes");
                    logData.AppendLine($"Notes: {notesElement.Value ?? "N/A"}");

                    logData.AppendLine($"Number of Nodes: {record.Nodes().Count()}");
                    logData.AppendLine("----------------------------");
                }
            }
            else
            {
                logData.AppendLine($"No errors detected in {inputFileName}.");
            }
            this.logData += logData.ToString();
        }



        private void ProcessHeader()
        {

            var academicProgram = db.AcademicPrograms.FirstOrDefault().ToString();
            xDocument = new XDocument(this, inputFileName);
            XElement root = xDocument.Element("student_update");
            XAttribute xProgramAcronym = root.Attribute(academicProgram);
            DateTime daysStamp = ((DateTime)root.Attribute("days"));
            DateTime yearStamp = ((DateTime)root.Attribute("year"));
            //verify attributes of the xml file's root element

            if (root.Attributes().Count() != 3)
            {
                throw new Exception("Attributes do not equal 3.");

            }
            else if (((DateTime)root.Attribute("year")) != DateTime.Today)
            {
                throw new Exception("Incorrect time.");
            }
            else if (xProgramAcronym == null)
            {
                throw new Exception("Null or empty program acronym.");
            }
            else
            {
                throw new Exception("Processing header failed. Try Again.");
            }

        }

        private void ProcessDetails()
        {
            //verify contents of detail records in input file
            xDocument = new XDocument(inputFileName);

            //only incl. transaction elements
            IEnumerable<XElement> dataRoot = xDocument.Descendants("transaction");

            ProcessErrors(dataRoot, dataRoot, "First round of validation: ");

            if (dataRoot.All(element => element.Name == "transaction" && dataRoot.Nodes().Count() != 7)) ;



            IEnumerable<XElement> matchTransactions = dataRoot.Where(t => t.Element("program").Value == xDocument.Root.Attribute("program").Value);

            ProcessErrors(dataRoot, matchTransactions, "Second round of validation: ");

            IEnumerable<XElement> matchType = matchTransactions.Where(ty => Numeric.IsNumeric(ty.Element("type").Value, NumberStyles.Any));
            // xDocument.Descendants.Where(t => t.Transaction == "transaction").Nodes().Count();

            IEnumerable<XElement> matchGrade = matchType.Where(g => Numeric.IsNumeric(g.Element("grade").Value, NumberStyles.Any) || g.Element("grade").Value == "*");

            IEnumerable<XElement> matchTypeValue = matchGrade.Where(tv => tv.Element("type").Value == "1" || tv.Element("type").Value == "2");

            ProcessErrors(matchTransactions, matchTypeValue, "Third round of validation");

            IEnumerable<XElement> matchInclusive = matchTypeValue.Where(i =>
            (i.Element("type").Value == "1"
            && i.Element("grade").Value == "*")
            || (i.Element("type").Value == "2")
            && (Numeric.IsNumeric(i.Element("grade").Value, NumberStyles.Any)
            && int.TryParse(i.Element("grade").Value, out int gradeResult)
            && gradeResult >= 0 && gradeResult <= 100));

            ProcessErrors(matchTypeValue, matchInclusive, "Fourth round of validation: ");

            IEnumerable<long> studentNumbers = db.Students.Select(s => s.StudentNumber).ToList();
            IEnumerable<XElement> studentNumList = matchInclusive.Where(sl => studentNumbers.Contains(Convert.ToInt64(sl.Element("student_no").Value)) && sl.Element("course_no").Value == "*");
            IEnumerable<string> courseNumList = db.Courses.Select(c => c.CourseNumber).ToList();
            IEnumerable<XElement> courseTransactions = studentNumList.Where(ct => long.TryParse(ct.Element("course_no").Value, out long courseNum) && courseNumList.Select(long.Parse).Contains(courseNum));

            ProcessErrors(matchInclusive, courseTransactions, "Fifth round of validation: ");

            IEnumerable<long> registrationNumbers = db.Registrations.Select(r => Convert.ToInt64(r.RegistrationNumber)).ToList();
            IEnumerable<XElement> registrationTransactions = courseTransactions.Where(rt =>
            (rt.Element("type").Value == "1"
            && rt.Element("registration_no").Value == "*")
            || (rt.Element("type").Value == "2" && long.TryParse(rt.Element("registration_no").Value, out long registrationNum) && registrationNumbers.Contains(registrationNum)));

            ProcessErrors(courseTransactions, registrationTransactions, "Sixth/Last round of validation: ");

            //registrationNumbers.Contains(rt.Element("registration_no").Value == "*" || rt.Element("registration_no").Value == registrationNumbers;
            /*Severity	Code	Description	Project	File	Line	Suppression State
            Error	CS1929	'IEnumerable<long>' does not contain a definition for 'Contains' and the best extension method overload 'Queryable.Contains<string>(IQueryable<string>, string)' requires a receiver of type 'System.Linq.IQueryable<string>'	BITCollegeWindows	C:\Users\missi\source\repos\BITCollege_TA\BITCollegeWindows\Batch.cs	111	Active
            */
            // call ProcessTransactions
            ProcessTransactions(registrationTransactions);
        }

        private void ProcessTransactions(IEnumerable<XElement> transactionRecords)
        {

            //4Digit-3DigitDayOfYear-AcademicProgramAcronym.xml
            StringBuilder logData = new StringBuilder();

            foreach (XElement transactionRecord in transactionRecords)
            {
                string registrationNumber = string.Empty;
                int registrationId = 0;
                int studentNumber = 0;
                string type = transactionRecord.Element("type").Value;
                int courseNumber = 0;
                string grade = string.Empty;
                string notes = string.Empty;
                if (type == "1")
                {
                    registrationNumber = transactionRecord.Element("registration_no").Value;
                    studentNumber = int.Parse(transactionRecord.Element("student_no").Value);
                    notes = transactionRecord.Element("notes").Value;
                    courseNumber = int.Parse(transactionRecord.Element("course_no").Value);

                    Registration registration = db.Registrations.SingleOrDefault(reg => reg.RegistrationNumber == registrationNumber);

                    if (registration != null)
                    {
                        var client = new CollegeRegistrationClient();

                        int registerResult = client.RegisterCourse(studentNumber, courseNumber, notes);


                        if (registerResult > 0)
                        {
                            logData.AppendLine($"Student: {studentNumber} has successfully registered: {registrationNumber}");
                        }
                        else
                        {
                            logData.AppendLine($"REGISTER ERROR: {Utility.BusinessRules.RegisterError(-100)}");
                        }
                    } // add exceeded max attempts conditional check for errors might be error 200
                }
                else
                {
                    logData.Append($"Registration with registration number {registrationNumber} not found.");
                }
                if (type == "2")
                {
                    var client = new CollegeRegistrationClient();
                    grade = transactionRecord.Element("grade").Value;
                    notes = transactionRecord.Element("notes").Value;
                    registrationId = int.Parse(transactionRecord.Element("registration_no").Value);

                    double calcGrade = Convert.ToInt64(grade) / 100;

                    double? newGrade = client.UpdateGrade(calcGrade, registrationId, notes);

                    if (newGrade > 0)
                    {
                        logData.AppendLine($"Updated grade was successful at registration number: {registrationNumber}");
                    }
                    else
                    {
                        logData.AppendLine($"Unable to update grade at registration number: {registrationNumber}. {BusinessRules.RegisterError(-300)}");
                    }


                }


            }


        }

        public string WriteLogData()
        {
            using (StreamWriter writer = new StreamWriter(logFileName))
            {
                writer.Write(logData);
            }

            string capturedLogData = logData; // Capture the contents of logData into a local variable
            logData = ""; // Clear logData for subsequent use
            logFileName = ""; // Clear logFileName for the next log file
            return capturedLogData; // Return the captured logging data
        }


        public void ProcessTransmission(String programAcronym)
        {

            string xmlLog = $"{DateTime.Today:yyyy}- {DateTime.Today:ddd}- {programAcronym}.xml";
            string txtLog = $"LOG{DateTime.Today:yyyy}- {DateTime.Today:ddd}- {programAcronym}.txt";

            inputFileName = xmlLog;
            logFileName = txtLog;

            if (!File.Exists(xmlLog))
            {
                logData = "File does not exist @ " + xmlLog;
                //StreamWriter writer = new StreamWriter(logFileName, true);
                //writer.Write(logData);
                //writer.Close();
                //transmissionLog.Write(txtLog);
                //transmissionLog.Close();
                //if (!DateTime.Parse(root.Attribute("date").Value))
                //.Equals(DateTime.Today);
            }
            else
            {
                XDocument xDocument = XDocument.Load(xmlLog);
                XElement xElement = xDocument.Element("student_update");
                if (File.Exists(xmlLog))
                {

                   /* string xProgramAcronym = (string)xElement.Attribute("program");
                    DateTime daysStamp = (DateTime)xElement.Attribute("days");
                    DateTime yearStamp = (DateTime)xElement.Attribute("year");

                    string days = daysStamp.ToString("ddd");
                    string year = yearStamp.ToString("yyyy");
                    string program = programAcronym; */
                    ProcessHeader();
                    ProcessDetails();
                    // call processheader
                    // call processdetails
                    //StreamWriter transmissionLog = new StreamWriter(xmlLog, true);
                    //xDocument = XDocument.Load(xmlLog);
                }
                else
                {
                    throw new Exception(logData + "either the file does not exist, or unable to call processes.");
                    //append relevant message to logData incl. file does not exist
                    //incl. inputFileName
                }
            }
        }
    }

}
