using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
   public class StudentViewModel
    {
        [Key]
        public int TeacherID { get; set; }
        public int StudentID { get; set; }
        public int LevelID { get; set; }
        public int ClassID { get; set; }
        public string StudentName { get; set; }
        public string StudentMobile { get; set; }
        public string StudentEmail { get; set; }
        public string StudentDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Photo { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string TeacherName { get; set; }
        public string AttendanceDate { get; set; }
        public string Attendance { get; set; }
    }
}
