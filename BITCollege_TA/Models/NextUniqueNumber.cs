using BITCollege_TA.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BITCollege_TA.Models
{
    public abstract class NextUniqueNumber
    {
        //
        protected static BITCollege_TAContext db = new BITCollege_TAContext();

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NextUniqueNumberId { get; set; }

        [Required]
        public long NextAvailableNumber { get; set; }



    }
}