using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
   public class ClassViewModel
    {
        [Key]
        public int ClassID { get; set; }
        [Required(ErrorMessage = "Class Name is Required!")]
        public string ClassName { get; set; }
        public string LevelName { get; set; }
        public int counter { get; set; }
        public int Seat { get; set; }
        public Nullable<int> LevelID { get; set; }
    }
}
