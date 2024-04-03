using BITCollege_TA.Controllers;
using BITCollege_TA.Data;
using BITCollege_TA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using Utility;

namespace BITCollegeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service2" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service2.svc or Service2.svc.cs at the Solution Explorer and start debugging.
    //return promise, implement interface
    public class CollegeRegistration : ICollegeRegistration
    {
        //instantiate object of db context
        private BITCollege_TAContext db = new BITCollege_TAContext();

        public bool DropCourse(int registrationId)
        {
            throw new NotImplementedException();
        }

        //various return codes indicating reason for failure
        public int RegisterCourse(int studentId, int courseId, string notes)
        {
            try
            {
                //further query: if any registration records in student/course has null grade
                //if null is true -> not permitted to register /ungraded
                //set return code to -100

                //register query
                IQueryable<Registration> registrationList = db.Registrations;
                Registration register = db.Registrations.SingleOrDefault(r => r.StudentId == studentId && r.CourseId == courseId);

                //ungraded query + nullcheck var
                bool ungradedRegistration = db.Registrations.Any(r => r.RegistrationId == courseId && r.Grade == null);
                double? gradeNullCheck = null;

                if (register != null)
                {
                    gradeNullCheck = register.Grade;
                }

                // set the return code value to -100 in the case of an ungraded registration as per course id
                if (ungradedRegistration)
                {
                    return -100;
                }

                //course query
                IQueryable<Course> courseList = db.Courses;
                courseList.Where(c => c.CourseId == courseId).SingleOrDefault();
                MasteryCourse course = db.MasteryCourses.SingleOrDefault(c => c.CourseId == courseId);

                //assign vars
                if (course != null)
                {
                    int getMaxAttempts = course.MaximumAttempts;
                    string getCourseType = course.CourseType;
                }

                //reassign studentList where, return one student
                //student list query
                //replace 74 to 75
                //process the studentList
                IQueryable<Student> studentList = db.Students;
                Student student = studentList.Where(s => s.StudentId == studentId).SingleOrDefault();

                //student vars
                double getOutStandingFees = student.OutstandingFees;
                int getNumRegistrations = db.Registrations.Count(r => r.StudentId == studentId);


                if (gradeNullCheck != null)
                {
                    int checkAttempts = course.MaximumAttempts;

                    //catch -200 error code: exceeded max attempts mastery
                    if (checkAttempts >= getNumRegistrations)
                    {
                        return -200;
                    }
                    try
                    {
                        //catch -300 error code: error updating
                        // update the registration and outstanding fees & commit to db
                        Registration validRegister = new Registration();
                        validRegister.CourseId = courseId;
                        validRegister.StudentId = studentId;
                        validRegister.Notes = "testing";
                        validRegister.RegistrationDate = DateTime.Today;
                        validRegister.SetNextRegistrationNumber();
                        db.Registrations.Add(validRegister);
                        db.SaveChanges();

                        double tuitionTotal = course.TuitionAmount;
                        getOutStandingFees += tuitionTotal;
                        db.SaveChanges();

                    }
                    catch (Exception ex)
                    {
                        // check update failure, concurrency and other
                        if (ex is DbUpdateException || ex is DbUpdateConcurrencyException)
                        {
                            //return -300
                        }
                        return -300;
                    }
                }
            }
            catch (Exception)
            {
                //success
            }
            return 0;
        }




        //lambda linq-sql-server retrieve/validate
        //when student already has an incomplete registration for same course
        //expression: stored registration => return false (-100)
        //student, registering for mastery -> & this registration >= max attempts -> then false (-200)

        public double? UpdateGrade(double grade, int registrationId, string notes)
        {
            try
            {
                // get the registration record
                var registration = db.Registrations.SingleOrDefault(r => r.RegistrationId == registrationId);

                if (registration == null)
                {
                    throw new ArgumentException("Registration not found");
                }

                // set properties of registration record
                registration.Grade = grade;
                registration.Notes = notes;

                // persist db
                db.SaveChanges();

                // call the calc gpa method w/ studentId
                var gpa = CalculateGradePointAverage(registration.StudentId);

                // return gpa
                return gpa;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating grade", ex);
            }

        }

        private double? CalculateGradePointAverage(int studentId)
        {
            try
            {
                double totalCreditHours = 0;
                double totalGradePointValue = 0;


                var registrations = db.Registrations.Where(r => r.StudentId == studentId && r.Grade != null);



                foreach (var registration in registrations.ToList())
                {
                    // get grade/coursetype/Reigstration
                    double grade = registration.Grade.Value;

                    CourseType courseType = CourseType.AUDIT;
                    string courseTypeString = registration.ToString();
                    courseType = BusinessRules.CourseTypeLookup(courseTypeString);


                    // no audit course type
                    if (courseType != CourseType.AUDIT)
                    {
                        // gp value using business utility
                        double gradePointValue = BusinessRules.GradeLookup(grade, courseType);

                        // calc total GP using course navigable for registration/credithours
                        double creditHours = registration.Course.CreditHours;
                        double totalGradePointForCourse = gradePointValue * creditHours;

                        // append calc to zeroed doubles to credithours/total
                        totalCreditHours += creditHours;
                        totalGradePointValue += totalGradePointForCourse;
                    }
                }

                double? calculatedGradePointAverage = null;

                // calc gpa if cred hours not 0
                if (totalCreditHours != 0)
                {
                    calculatedGradePointAverage = totalGradePointValue / totalCreditHours;
                }

                // get student rec
                var student = db.Students.SingleOrDefault(s => s.StudentId == studentId);

                if (student != null)
                {
                    // update gpa for student
                    student.GradePointAverage = calculatedGradePointAverage;

                    // update db
                    db.SaveChanges();

                    // change grade point state for student
                    student.ChangeState();

                    // return final
                    return calculatedGradePointAverage;
                }
                else
                {
                    throw new Exception("Student not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error calculating GPA", ex);
            }
        }
    }

}

