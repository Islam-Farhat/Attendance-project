using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
   public class AttendanceViewModel
    {
        [Key]
        public int TeacherID { get; set; }
        public int AttendanceID { get; set; }
        public int StudentID { get; set; }
        public int LevelID { get; set; }
        public int ClassID { get; set; }
        public string Attendance { get; set; }
        public string StudentName { get; set; }
        public string TeacherName { get; set; }
        public string AttendanceDate { get; set; }
    }
}
