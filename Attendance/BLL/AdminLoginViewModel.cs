using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
   public class AdminLoginViewModel
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Admin Name is Required!")]
        public string AdminName { get; set; }
        [Required(ErrorMessage = "Password is Required!")]
        public string Password { get; set; }
    }
}
