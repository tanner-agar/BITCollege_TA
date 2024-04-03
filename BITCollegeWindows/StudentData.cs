using BITCollege_TA.Controllers;
using BITCollege_TA.Data;
using BITCollege_TA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Data.Entity.Infrastructure.Design.Executor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BITCollegeWindows
{
    public partial class StudentData : Form
    {

        BITCollege_TAContext db = new BITCollege_TAContext();
        ///Given: Student and Registration data will be retrieved
        ///in this form and passed throughout application
        ///These variables will be used to store the current
        ///Student and selected Registration
        ConstructorData constructorData = new ConstructorData();

        /// <summary>
        /// This constructor will be used when this form is opened from
        /// the MDI Frame.
        /// </summary>
        public StudentData()
        {
            InitializeComponent();
        }

        /// <summary>
        /// given:  This constructor will be used when returning to StudentData
        /// from another form.  This constructor will pass back
        /// specific information about the student and registration
        /// based on activities taking place in another form.
        /// </summary>
        /// <param name="constructorData">constructorData object containing
        /// specific student and registration data.</param>
        public StudentData (ConstructorData constructor)
        {
            //return to student data form
            InitializeComponent();

            long studentNumberInput;
            // set instance variable to the value of the corresponding argument
            constructor = this.constructorData;

            //  Student Number -> MaskedTextBox value using the Student prop of the constructor argument
            if (long.TryParse(studentNumberTextBox.Text, out studentNumberInput) && constructor != null && constructor.Student != null)
            {
                studentNumberInput = constructor.Student.StudentNumber;
            }

            // reset leave event -> call MaskedTextBox_Leave event passing null for each of the event arguments
            studentNumberMaskedText_Leave(null, null);
        }

        /// <summary>
        /// given: Open grading form passing constructor data.
        /// </summary>
        private void lnkUpdateGrade_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // null check -> populate constructorData current student/registration
            if (constructorData == null)
            {
                ConstructorData constructorData = new ConstructorData();
            }

            constructorData.Student = studentBindingSource.Current as Student;
            constructorData.Registration = registrationBindingSource.Current as Registration;

            // open grade -> pass constructor data
            Grading grading = new Grading(constructorData);
            grading.MdiParent = this.MdiParent;
            grading.Show();
            this.Close();
        }


        /// <summary>
        /// given: Open history form passing constructor data.
        /// </summary>
        /// 
        //For the Update Grade and View Details Link Labels LinkClick events, ensure the
        //constructorData object is populated with the current Student record and current
        //Registration record prior to constructing the Grading and History forms.
        //o Note: Since both events require the same code, this is an excellent opportunity
        //for refactoring to avoid repetitive code

        // update grade && view detail -> constructorData pop. -> current stu rec, curr. regis rec. prior to form construct.
        private void lnkViewDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (constructorData == null)
            {
                constructorData = new ConstructorData();
            }
            // current records populate constructorData
            constructorData.Student = studentBindingSource.Current as Student;
            constructorData.Registration = registrationBindingSource.Current as Registration;

            // open history -> pass constructorData
            History history = new History(constructorData);
            history.MdiParent = this.MdiParent;
            history.Show();
            this.Close();
        }

        private void btnOpenHistory_Click(object sender, EventArgs e)
        {
            History historyForm = new History(constructorData);
            historyForm.ShowDialog();
        }

        private void btnOpenGrading_Click(object sender, EventArgs e)
        { 
            Grading gradingForm = new Grading(constructorData);
            gradingForm.ShowDialog();
        }

        /// <summary>
        /// given:  Opens the form in top right corner of the frame.
        /// </summary>
        private void StudentData_Load(object sender, EventArgs e)
        {
            //keeps location of form static when opened and closed
            this.Location = new Point(0, 0);
            studentNumberTextBox.Focus();
        }

        // Define a LINQ-to-SQL Server query selecting data from the Students table whose
        // StudentNumber matches the value in the MaskedTextBox.
        private void studentNumberMaskedText_Leave(object sender, EventArgs e)
        {
            // debugging
            Console.WriteLine("Leave");

            // assign long for studentid
            long studentNumberInput;

            // parse long to string
            if (long.TryParse(studentNumberTextBox.Text, out studentNumberInput))
            {
                IQueryable<Student> studentQuery = db.Students.Where(student => student.StudentNumber == studentNumberInput);


            if (studentQuery.Any())
                {
                    //select single student
                    Student student = studentQuery.SingleOrDefault();
                    //assign student data
                    studentBindingSource.DataSource = student;

                    IQueryable<Registration> registrations = db.Registrations.Where(registration => registration.StudentId == student.StudentId);
                    lnkUpdateGrade.Enabled = false;
                    lnkViewDetails.Enabled = false;

                    if (registrations.Any())
                    {
                        // reg binding -> retrieved binding
                        registrationBindingSource.DataSource = registrations.ToList();
                        lnkUpdateGrade.Enabled = true;
                        lnkViewDetails.Enabled = true;
                    }
                    else
                    {
                        // no records

                        // disable links
                        lnkUpdateGrade.Enabled = false;
                        lnkViewDetails.Enabled = false;

                        // clear binding
                        studentBindingSource.DataSource = typeof(Student);

                        // clear binding
                        registrationBindingSource.DataSource = typeof(Registration);

                        // message box
                        MessageBox.Show("The student number entered does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // reset focus
                        studentNumberTextBox.Focus();
                    }
                }
            }
        }
    }
}
