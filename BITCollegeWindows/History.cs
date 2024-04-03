using BITCollege_TA.Data;
using BITCollege_TA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BITCollegeWindows
{
    public partial class History : Form
    {

        ///given:  student and registration data will passed throughout 
        ///application. This object will be used to store the current
        ///student and selected registration
        ConstructorData constructorData;
        BITCollege_TAContext db = new BITCollege_TAContext();

        /// <summary>
        /// given:  This constructor will be used when called from the
        /// Student form.  This constructor will receive 
        /// specific information about the student and registration
        /// further code required:  
        /// </summary>
        /// <param name="constructorData">constructorData object containing
        /// specific student and registration data.</param>
        public History(ConstructorData constructorData)
        {
            InitializeComponent();

            // populating constructorData with corresponding data
            if (constructorData != null)
            {
                // populate student data
                Student student = constructorData.Student;
                studentBindingSource.DataSource = student;

                // populate academic program data
                academicProgramBindingSource.DataSource = student.AcademicProgram;

                // populate datagrid view
                var registration = constructorData.Registration; 
                registrationDataGridView.DataSource = new List<Registration> { registration };
                registrationDataGridView.DataSource = new List<Course> { registration.Course };

                // Optionally, you can populate other controls with additional data
                // For example, if you have a TextBox for displaying the student's name:
                fullNameLabel1.Text = $"{student.FullName}";
            }
        }

        private void History_FormClosed(object sender, FormClosedEventArgs e)
        {
            // update student data if changes
            studentBindingSource.DataSource = constructorData;
        }

        private void Grading_FormClosed(object sender, FormClosedEventArgs e)
        {
            // update student data if changes
            studentBindingSource.DataSource = constructorData;
        }

        /// <summary>
        /// given: This code will navigate back to the Student form with
        /// the specific student and registration data that launched
        /// this form.
        /// </summary>
        private void lnkReturn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StudentData student = new StudentData(constructorData);
            student.MdiParent = this.MdiParent;
            student.Show();
            this.Close();
        }

        /// <summary>
        /// given:  Open this form in top right corner of the frame.
        /// further code required:
        /// </summary>
        private void History_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);

            try
            {
                // get studentid
                int studentId = constructorData.Student.StudentId;

                // linq query using normal syntax for clarity
                var query = from registration in db.Registrations
                            join course in db.Courses on registration.CourseId equals course.CourseId
                            where registration.StudentId == studentId
                            select new
                            {
                                RegistrationId = registration.RegistrationId,
                                Date = registration.RegistrationDate,
                                CourseCode = course.CourseId,
                                CourseName = course.CourseType,
                                Grade = registration.Grade,
                                Notes = registration.Notes
                            };

                // bind data source to property of dgv registration
                registrationDataGridView.DataSource = query.ToList();
            }
            catch (Exception ex)
            {
                // handle errors
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
