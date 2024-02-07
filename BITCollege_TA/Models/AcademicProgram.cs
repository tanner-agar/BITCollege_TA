using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BITCollege_TA.Models
{
    // REMINDER TO FORMAT EVERYTHING AND PUT THINGS IN LOGICAL SEQUENCE. OR AS PER THE ASSIGNMENT IF IT MAKES THE CODE MORE CLEAR.
    //Not sure if I've missed anything that I need to learn for this assignment. Navigability is a bit confusing to me still but this syntax makes more sense at least rather than just looking at UML diagrams and deciding. I can see actually see how syntatically it is written.
    //Navigability 
    public class AcademicProgram //Check
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AcademicProgramId { get; set; }
        //Navigation - There can be 0..* students for one Academic Program
        //Lazy Loading - delay the loading of the object unit the point where we need it. sort of like a level of detail for detail, defer the initalization of loading of an object until need: asynchronous loading.
        public virtual ICollection<Student> Student { get; set; }

        // Navigation - There can be 0..*  side for  1 Academic Program
        public virtual ICollection<Course> Course { get; set; }

        [Required]
        [Display(Name = "Program")]
        public string ProgramAcronym { get; set; }

        //Overload Required with an error message. Not a requirement for assignment at the moment.
        [Required(ErrorMessage = "Description is required.")]
        [Display(Name = "Program Name\n")]
        //ApplyFormateInEditMode to keep DataFormatString consistency, mimicking the back end formatting, for the front end.
        //Line break \n escape sequence is an end of line, hence the escape. Since we are using ApplyFormatInEditMode too, it will show for the view and edit/user.
        [DisplayFormat(DataFormatString = "Program Name: {0}\n", ApplyFormatInEditMode = true)]
        public string Description { get; set; }
    }

}