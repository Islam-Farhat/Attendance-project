using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DataModel;

namespace DAL
{
    interface IStudentRepository
    {
        bool Add(StudentViewModel dept);
        IEnumerable<LevelViewModel> DropdownlistLevelStudent();
        IEnumerable<ClassViewModel> DropdownlistClassStudent();
        StudentViewModel LoadDataAdvancedReport(StudentViewModel option);
    }
    public class StudentRepository : IStudentRepository
    {
        AttendanceEntities context = new AttendanceEntities();

        //ADD data in table using viewmodel
        public bool Add(StudentViewModel dept)
        {
            var check = context.Students.Select(x => x.StudentEmail).Contains(dept.StudentEmail);
            if (check)
            {
                return false;
            }
            Student obj = new Student();
            try
            {
                obj.TeacherID = dept.TeacherID;
                obj.StudentName = dept.StudentName;
                obj.StudentEmail = dept.StudentEmail;
                obj.StudentMobile = dept.StudentMobile;
                obj.Address = dept.Address;
                obj.City = dept.City;
                obj.StudentDate = dept.StudentDate;
                obj.Photo = Path.GetFileName(dept.Photo);
                obj.LevelID = dept.LevelID;
                obj.UserName = dept.UserName;
                obj.Password = dept.Password;
                obj.ClassID = dept.ClassID;
                context.Students.Add(obj);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Dropdownlist level in TableStudent
        public IEnumerable<LevelViewModel> DropdownlistLevelStudent()
        {
            List<LevelViewModel> depts = new List<LevelViewModel>();
            foreach (var item in context.Levels)
            {
                LevelViewModel obj = new LevelViewModel();
                obj.LevelID = item.LevelID;
                obj.LevelName = item.LevelName;
                depts.Add(obj);
            }
            return depts;
        }

        //Dropdownlist classes in Tablestudent
        public IEnumerable<ClassViewModel> DropdownlistClassStudent()
        {
            List<ClassViewModel> depts = new List<ClassViewModel>();
            foreach (var item in context.Classes)
            {
                ClassViewModel obj = new ClassViewModel();
                obj.ClassID = item.ClassID;
                obj.ClassName = item.ClassName;
                depts.Add(obj);
            }
            return depts;
        }


        //LoadData in page Advanced Report
        public StudentViewModel LoadDataAdvancedReport(StudentViewModel option)
        {
            Student dept = context.Students.FirstOrDefault(x => x.StudentID == option.StudentID);
            StudentViewModel obj = new StudentViewModel();
            obj.Photo = dept.Photo;
            obj.StudentName = dept.StudentName;
            obj.StudentEmail = dept.StudentEmail;
            obj.StudentMobile = dept.StudentMobile;
            obj.Address = dept.Address;
            obj.StudentDate = dept.StudentDate;
            obj.City = dept.City;
            obj.UserName = dept.UserName;
            obj.Password = dept.Password;
            return obj;
        }
    }
}
