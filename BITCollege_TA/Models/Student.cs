
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BITCollege_TA.Models;
using BITCollege_TA.Data;
using System.Data.Entity;

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

        protected BITCollege_TAContext db;

        public static void ChangeState()
        {
            // create private instance of data context class
            // untested code, gate kept at GetInstance();
            using (var dbContext = new BITCollege_TAContext())
            {
                bool stateChanged = true;

                while (stateChanged)
                {
                    stateChanged = false; // reset the flag

                    //ref Student type to student var, and set it to the collection of Students
                    //or a default value if source empty
                    Student student = dbContext.Students.FirstOrDefault();

                    //so if student does not equal null
                    //
                    if (student != null)
                    {
                        //ref GradePointState type to currentState var
                        //assign it to student var get GradePointState property
                        GradePointState currentState = student.GradePointState;

                        //call StateChangeCheck on the existing object
                        //recall that we initially ref Student type to student
                        //so, in other words currentState is storing the Student type, collections,
                        //and the decision of First or Default.
                        currentState.StateChangeCheck(student);

                        //track the state change via public boolean in GradePointState.cs (only way i could figure this out)
                        //it does make sense to set a flag, since both methods are static, no return.
                        stateChanged = currentState.stateChanged;
                    }

                    //commit the changes to the collections
                    dbContext.SaveChanges();
                }
            }
        }


    [Required(ErrorMessage = "StudentNumber is required.")]
    [Display(Name = "Student Number")]
    [DisplayFormat(DataFormatString = "{0:Student Number\n}", ApplyFormatInEditMode = true)]
    [Range(10000000, 99999999, ErrorMessage = "StudentNumber must be within the range of 10000000 and 99999999.")]
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
