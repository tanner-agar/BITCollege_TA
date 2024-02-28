using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BITCollege_TA.Models
{
    public abstract class Course
    {

        public abstract void SetNextCourseNumber();


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }
        // Navigation - One course can have many Registration
        public virtual ICollection<Registration> Registration { get; set; }

        //Entity Framework allows us to easily navigate our system by grouping getters and setters together.
        [ForeignKey("AcademicProgram")]
        public int? AcademicProgramId { get; set; }

        // Navigation - Many side to 0..1 of Academic Program
        public virtual AcademicProgram AcademicProgram { get; set; }

        [Display(Name = "Course Number\n")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public string CourseNumber { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Credit Hours\n")]
        //Two decimals {0:N2}
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public double CreditHours { get; set; }

        [Required]
        [Display(Name = "Tuition")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double TuitionAmount { get; set; }

        //REMINDER TO CREATE STATIC METHOD IN UTILITY TO STREAMLINE WORK FLOW
        //UNTESTED 2024-01-17
        [Display(Name = "Course Type")]
        [DisplayFormat(DataFormatString = "{0:Course Type}", ApplyFormatInEditMode = true)]
        [NotMapped]
        public string CourseType
        {
            get
            {
                //Assign instanceType to the GetType() method, using Name to grab the meta data.
                string instanceType = GetType().Name;
                int courseIndex = instanceType.LastIndexOf("Course"); //looking for -1 because we want the text before the C in course.

                //condition check if Course is not found in Instance Type.  i.e. if true it does not execute the remainder of the logic in the behaviour of the get, or in other words it does not return the instanceType that was operated on by the LastIndexOf method. Returning the original, entire class name without any changes.
                if (courseIndex != -1)
                {
                    //Return unchanged class name using substring method starting from the beginning (0), and the length of the courseIndex.
                    return instanceType.Substring(0, courseIndex);
                }

                return instanceType;
            }
        }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

    }
}