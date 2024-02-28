using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BITCollege_TA.Models
{
    public class GradedCourse : Course
    {
        public override void SetNextCourseNumber()
        { 
            CourseNumber = "G-";
            long? nextNum = StoredProcedure.NextNumber("G");
            string appendString = CourseNumber + nextNum.ToString();
            if (nextNum != null)
            {
                CourseNumber += nextNum.ToString();
            }
        }

        [Required]
        [Display(Name = "Assignments")]
        //Percent format {0:F2}%
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public double AssignmentWeight { get; set; }

        [Required]
        [Display(Name = "Exams")]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public double ExamWeight { get; set; }


    }

}