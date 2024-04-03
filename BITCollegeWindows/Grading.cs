using BITCollege_TA.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;

namespace BITCollegeWindows
{
    public partial class Grading : Form
    {
        BITCollege_TAContext db = new BITCollege_TAContext();

        ///given:  student and registration data will passed throughout 
        ///application. This object will be used to store the current
        ///student and selected registration
        ConstructorData constructorData;


        /// <summary>
        /// given:  This constructor will be used when called from the
        /// Student form.  This constructor will receive 
        /// specific information about the student and registration
        /// further code required:  
        /// </summary>
        /// <param name="constructorData">constructorData object containing
        /// specific student and registration data.</param>
        public Grading(ConstructorData constructor)
        {
            InitializeComponent();
            if (constructor != null)
            {
                // populate upper controls with student data
                if (constructor.Student != null)
                {
                    fullNameLabel1.Text = $"{constructor.Student.FullName}";
                    studentNumberMaskedLabel.Text = constructor.Student.StudentId.ToString();
                    descriptionLabel1.Text = constructor.Student.AcademicProgram.Description;
                }

                // populate lower controls with registration data
                if (constructor.Registration != null)
                {
                    courseNumberMaskedLabel.Text = constructor.Registration.CourseId.ToString();
                    titleLabel1.Text = constructor.Registration.Course.Title;
                    courseTypeLabel1.Text = constructor.Registration.Course.CourseType;
                }
            }
        }

        /// <summary>
        /// given: This code will navigate back to the Student form with
        /// the specific student and registration data that launched
        /// this form.
        /// </summary>
        private void lnkReturn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //return to student with the data selected for this form
            StudentData student = new StudentData(constructorData);
            student.MdiParent = this.MdiParent;
            student.Show();
            this.Close();
        }

        private void History_FormClosed(object sender, FormClosedEventArgs e)
        {
            studentBindingSource.DataSource = constructorData;
        }

        private void Grading_FormClosed(object sender, FormClosedEventArgs e)
        {
            studentBindingSource.DataSource = constructorData;
        }


        /// <summary>
        /// given:  Always open in this form in the top right corner of the frame.
        /// further code required:
        /// </summary>
        private void Grading_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);

            // course number -> masked label mask using course format method
            if (constructorData != null && constructorData.Registration.Course != null)
            {
                string courseType = constructorData.Registration.Course.CourseType;
                string courseNumberMask = BusinessRules.CourseFormat(courseType);

                courseNumberMaskedLabel.Mask = courseNumberMask;
            }

            // controls are initially enabled and visible based on a grade has been previously entered
            if (constructorData != null && constructorData.Registration != null)
            {
                // previous grade entered
                if (constructorData.Registration.Grade != null)
                {
                    gradeTextBox.Enabled = false;
                    lnkUpdate.Enabled = false;
                    lblExisting.Visible = true;
                }
                else
                {
                    // no grade has been previously entered
                    gradeTextBox.Enabled = true;
                    lnkUpdate.Enabled = true;
                    lblExisting.Visible = false;
                }
            }
        }


        /// <summary>
        /// Handles the logic for updating a student grade
        /// </summary>
        private void lnkUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // get the value from the TextBox -> clear format -> numeric check ->
            string gradeString = constructorData.Registration.Grade.ToString();
            string gradePercent = Numeric.ClearFormatting(gradeString, gradeTextBox.Text);
            NumberStyles styles = NumberStyles.Integer | NumberStyles.AllowDecimalPoint;

            // value = numeric check
            if (!Numeric.IsNumeric(gradePercent, styles))
            {
                //fail?
                MessageBox.Show("Grade must be numeric.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // convert decimal
            decimal grade;
            if (!decimal.TryParse(gradePercent, out grade))
            {
                // fail?
                MessageBox.Show("Invalid grade value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // divide by 100
            grade /= 100;

            // range 0 - 1
            if (grade < 0 || grade > 1)
            {
                // fail?
                MessageBox.Show("Grade must be between 0 and 100.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            gradeTextBox.Enabled = false;
        }

    }
}
