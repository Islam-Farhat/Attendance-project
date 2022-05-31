using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
   public class LevelViewModel
    {
        [Key]
        public int LevelID { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage = "Level Name is Required!")]
        //[Display(Name = "Level Name")]
        public string LevelName { get; set; }
       // public int counter { get; set; }
    }
}
