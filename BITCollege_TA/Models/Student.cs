
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BITCollege_TA.Models;
using BITCollege_TA.Data;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;
using System.Diagnostics;
using BITCollege_TA.Migrations;

namespace BITCollege_TA.Models
{
    public class Student
    {

        [Key] //Optional if -Id suffix real
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        //Navigation - Many Registrations for one Student
        public ICollection<Registration> Registration { get; set; }

        [Required]
        [ForeignKey("GradePointState")]
        public int GradePointStateId { get; set; }
        public virtual GradePointState GradePointState { get; set; }

        [ForeignKey("AcademicProgram")]
        public int? AcademicProgramId { get; set; } //int? - nullable           //Navigation - One Academic program for many Students
        public virtual AcademicProgram AcademicProgram { get; set; }


        /*
         * Student get instance of GPstate
        Student invokes the check on the state for a change
        Student passes itself (`this`) as student parameter
        State performs the change as needed */
        private BITCollege_TAContext db = new BITCollege_TAContext();
        public void ChangeState()
        {
            // Check if GradePointState is null before proceeding
            if (this.GradePointState != null)
            {
                bool stateChanged = true;

                // continue executing the process as long as states keep changing, i.e. while stateChanged true continue execution until satisfied. allows state to move multiple states if requirements are met.
                while (stateChanged)
                {
                    //state right now
                    GradePointState currentState = this.GradePointState;

                    //student invokes the check on the state change, this student param
                    currentState.StateChangeCheck(this);

                    //should it change? compare, is the state different ?
                    //if it is perform
                    if (currentState != this.GradePointState)
                    {
                        this.GradePointStateId = this.GradePointState.GradePointStateId;
                        db.SaveChanges();
                    }
                    //end
                    else
                    {
                        stateChanged = false;
                    }
                }
            }
        }

        public void SetNextStudentNumber()
        {
            long defaultNum = 0;
            long? nextNum = StoredProcedure.NextNumber("S");
         
            if (nextNum != null)
            {
                StudentNumber = defaultNum + nextNum.Value;
            }
        }

        [Display(Name = "Student Number")]
        [DisplayFormat(DataFormatString = "{0:Student Number\n}", ApplyFormatInEditMode = true)]
        //Long (long integer) variables are stored as signed 32-bit (4-byte) numbers ranging in value from -2,147,483,648 to 2,147,483,647. The type-declaration character for Long is the ampersand(&).
        public long StudentNumber { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [DisplayFormat(DataFormatString = "{0:First Name\n}", ApplyFormatInEditMode = true)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [DisplayFormat(DataFormatString = "{0:Last Name\n}", ApplyFormatInEditMode = true)]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [RegularExpression("^(N[BLSTU]|[AMN]B|[BQ]C|ON|PE|SK|YT)", ErrorMessage = "Invalid Canadian province code.")]
        public string Province { get; set; }

        [Required]
        [Display(Name = "Date")]
        //Suppress time stamp instead of 0:d to display appropriate and non-confusing information.
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Grade Point\nAverage")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        //Set Range of data allowed / constrain the end user to adhere to database standard.
        [Range(0, 4.5, ErrorMessage = "Grade Point Average must be between 0 and 4.5.")]
        public double? GradePointAverage { get; set; } //double?
        [Required]
        [Display(Name = "Fees")]
        [DisplayFormat(DataFormatString = "Outstanding Fees: {0:C}")]
        public double OutstandingFees { get; set; }

        public string Notes { get; set; }


        [NotMapped]
        [Display(Name = "Name")]
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        [NotMapped]
        [Display(Name = "Address")]
        public string FullAddress
        {
            get { return $"{Address}, {City}, {Province}"; }
        }
    }
}

