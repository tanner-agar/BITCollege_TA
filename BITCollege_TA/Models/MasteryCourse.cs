using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BITCollege_TA.Models
{
    public class MasteryCourse : Course
    {
        [Required]
        [Display(Name = "Maximum Attempts\n")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public int MaximumAttempts { get; set; }

    }
}