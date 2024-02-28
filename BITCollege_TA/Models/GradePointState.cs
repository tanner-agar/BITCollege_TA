using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BITCollege_TA.Models;
using BITCollege_TA.Data;

namespace BITCollege_TA.Models
{
    public abstract class GradePointState
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int GradePointStateId { get; set; }

        public bool stateChanged;

        public ICollection<Student> Student { get; set; }

        [Required(ErrorMessage = "LowerLimit is required.")]
        [Display(Name = "Lower Limit\n")]
        [DisplayFormat(DataFormatString = "Lower Limit: {0:N2}\n", ApplyFormatInEditMode = true)]
        public double LowerLimit { get; set; }

        [Required]
        [Display(Name = "Upper Limit")]
        [DisplayFormat(DataFormatString = "Upper Limit: {0:N2}\n", ApplyFormatInEditMode = true)]
        public double UpperLimit { get; set; }

        [Required(ErrorMessage = "TuitionRateFactor is required.")]
        [Display(Name = "Tuition Rate Factor")]
        [DisplayFormat(DataFormatString = "Tuition Rate Rate:\n{0:N2}", ApplyFormatInEditMode = true)]
        public double TuitionRateFactor { get; set; }


        [Display(Name = "State")]
        //Return GetType().Name
        [NotMapped]
        public string Description
        {
            //Override default behaivour
            get
            {
                //store current instance or nametype
                string instanceType = GetType().Name;
                int stateIndex = instanceType.LastIndexOf("State");

                if (stateIndex != -1)
                {

                    return instanceType.Substring(0, stateIndex);
                }

                return instanceType;
            }
        }


        protected static BITCollege_TAContext db = new BITCollege_TAContext();


        public abstract void StateChangeCheck(Student student);

        public abstract void TuitionRateAdjustment(Student student);

    }
}