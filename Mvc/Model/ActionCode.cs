using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MparWinForm07.Mvc.Model
{
    public class ActionCode
    {
        [Key]
        public string Actioncode { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Description is required")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Description text must be 4-20 pos.")]
        //[Column(TypeName = "varchar(20)")]// Exacte aanduiding
        public string Description { get; set; }

        //[Timestamp]
        //public byte[] Timestamp { get; set; }


        public ActionCode() { }
        public ActionCode(string actioncode, string description)
        {
            this.Actioncode = actioncode;
            this.Description = description;
        }
    }
}
