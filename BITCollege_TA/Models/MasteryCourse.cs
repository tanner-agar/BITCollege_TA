using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BITCollege_TA.Models
{
    public class MasteryCourse : Course
    {

        public override void SetNextCourseNumber()
        {
            //M= followed by value returned from NextNumber static method
            CourseNumber = "M-";
            long? nextNum = StoredProcedure.NextNumber("M");
            string appendString = CourseNumber + nextNum.ToString();
            if (nextNum != null)
            {
                CourseNumber += nextNum.ToString();
            }
        }

        [Required]
        [Display(Name = "Maximum Attempts\n")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public int MaximumAttempts { get; set; }

    }
}