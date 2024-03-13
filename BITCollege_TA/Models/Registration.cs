using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BITCollege_TA.Models
{
    public class Registration
    {
        public void SetNextRegistrationNumber()
        {
            //value of R- followed by value returned from NextNumber static method
            RegistrationNumber = "R-";
            long? nextNum = StoredProcedure.NextNumber("R");
            string appendString = RegistrationNumber + nextNum.ToString();
            if (nextNum != null)
            {
                RegistrationNumber += nextNum.ToString();
            }
        }



        [Key] //Optional if -Id suffix real
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RegistrationId { get; set; }

        [Required]
        [Display(Name = "Student")]
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }


        [Required]
        [Display(Name = "Course")]
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        [Display(Name = "Registration Number\n")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public string RegistrationNumber { get; set; }

        [Required]
        [Display(Name = "Date")]
        //Suppress the time stamp by specifying what the exact format is otherwise you will have a lot of minutes, seconds, possibly milliseconds I'm not sure, but it's plausible. Something that no one cares to see in this context. etc.
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegistrationDate { get; set; }

        //Since our Grade is nullabe with the ? symbol at the end of double we can display text to correspond with the null return, using NullDisplayText
        [DisplayFormat(NullDisplayText = "Ungraded")]
        [Range(0, 1, ErrorMessage = "Grade must be between 0 and 1.")]
        public double? Grade { get; set; }

        public string Notes { get; set; }

    }
}