using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DataModel;

namespace DAL
{
    interface IAttendanceRepoaitory
    {
        IEnumerable<StudentViewModel> GetAll(StudentViewModel student);
        bool Add(AttendanceViewModel dept);
        IEnumerable<LevelViewModel> DropdownlistLevel();
        IEnumerable<ClassViewModel> DropdownlistClass();
        IEnumerable<StudentViewModel> DropdownlistStudent();
        IEnumerable<AttendanceViewModel> LoadData(AttendanceViewModel option);
        IEnumerable<AttendanceViewModel> LoadDataAdvancedReport(AttendanceViewModel option);
    }
    public class AttendanceRepoaitory : IAttendanceRepoaitory
    {
        AttendanceEntities context = new AttendanceEntities();
        //loadData in Student Reports and attentance
        public IEnumerable<StudentViewModel> GetAll(StudentViewModel student)
        {
            List<StudentViewModel> depts = new List<StudentViewModel>();
            foreach (var item in context.Students.Where(x => x.LevelID == student.LevelID && x.ClassID == student.ClassID))
            {
                StudentViewModel obj = new StudentViewModel();
                obj.Photo = item.Photo;
                obj.StudentID = item.StudentID;
                obj.StudentName = item.StudentName;
                obj.StudentMobile = item.StudentMobile;
                obj.StudentEmail = item.StudentEmail;
                obj.StudentDate = item.StudentDate;
                depts.Add(obj);
            }
            return depts;
        }

        //ADD data in table using viewmodel
        public bool Add(AttendanceViewModel dept)
        {
            AttendanceTable obj = new AttendanceTable();
            try
            {
                obj.TeacherID = dept.TeacherID;
                obj.StudentID = dept.StudentID;
                obj.AttendanceID = dept.AttendanceID;
                obj.Attendance = dept.Attendance;
                obj.AttendanceDate = dept.AttendanceDate;
                context.AttendanceTables.Add(obj);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //DropDownlist Level, Class, Student

        public IEnumerable<LevelViewModel> DropdownlistLevel()
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


        public IEnumerable<ClassViewModel> DropdownlistClass()
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


        public IEnumerable<StudentViewModel> DropdownlistStudent()
        {
            List<StudentViewModel> depts = new List<StudentViewModel>();
            foreach (var item in context.Students)
            {
                StudentViewModel obj = new StudentViewModel();
                obj.StudentID = item.StudentID;
                obj.StudentName = item.StudentName;
                depts.Add(obj);
            }
            return depts;
        }
        /// Fire DropDownlist of Student
        public IEnumerable<StudentViewModel> ReloadDropdownlistStudent(StudentViewModel option)
        {
            List<StudentViewModel> depts = new List<StudentViewModel>();
            if (option.ClassID==-1)
            {
                foreach (var item in context.Students.Where(x => x.LevelID == option.LevelID))
                {
                    StudentViewModel obj = new StudentViewModel();
                    obj.StudentID = item.StudentID;
                    obj.StudentName = item.StudentName;
                    depts.Add(obj);
                }
            }
            if (option.LevelID == -1)
            {
                foreach (var item in context.Students.Where(x => x.ClassID == option.ClassID))
                {
                    StudentViewModel obj = new StudentViewModel();
                    obj.StudentID = item.StudentID;
                    obj.StudentName = item.StudentName;
                    depts.Add(obj);
                }
            }
            if (option.ClassID != -1&&option.LevelID!=-1)
            {
                foreach (var item in context.Students.Where(x => x.LevelID == option.LevelID && x.ClassID == option.ClassID))
                {
                    StudentViewModel obj = new StudentViewModel();
                    obj.StudentID = item.StudentID;
                    obj.StudentName = item.StudentName;
                    depts.Add(obj);
                }
            }
            if (option.ClassID == -1 && option.LevelID == -1)
            {
                foreach (var item in context.Students)
                {
                    StudentViewModel obj = new StudentViewModel();
                    obj.StudentID = item.StudentID;
                    obj.StudentName = item.StudentName;
                    depts.Add(obj);
                }
            }
            return depts;
        }
        //Show Data in Table
        public IEnumerable<AttendanceViewModel> LoadData(AttendanceViewModel option)
        {
            List<AttendanceViewModel> depts = new List<AttendanceViewModel>();
            if (option.LevelID!=-1 && option.ClassID == -1 && option.StudentID == -1)
            {
                depts = context.AttendanceTables.Where(x => x.Student.LevelID == option.LevelID).Select(x => new AttendanceViewModel
                {
                    StudentName = x.Student.StudentName,
                    TeacherName = x.TeacherTable.TeacherName,
                    Attendance= x.Attendance,
                    AttendanceDate= x.AttendanceDate
                }).ToList();
            }
            if (option.LevelID == -1 && option.ClassID != -1 && option.StudentID == -1)
            {
                depts = context.AttendanceTables.Where(x => x.Student.ClassID == option.ClassID).Select(x => new AttendanceViewModel
                {
                    StudentName = x.Student.StudentName,
                    TeacherName = x.TeacherTable.TeacherName,
                    Attendance = x.Attendance,
                    AttendanceDate = x.AttendanceDate
                }).ToList();
            }
            if (option.ClassID != -1 && option.LevelID != -1&&option.StudentID==-1)
            {
                depts = context.AttendanceTables.Where(x => x.Student.LevelID == option.LevelID&& x.Student.ClassID == option.ClassID).Select(x => new AttendanceViewModel
                {
                    StudentName = x.Student.StudentName,
                    TeacherName = x.TeacherTable.TeacherName,
                    Attendance = x.Attendance,
                    AttendanceDate = x.AttendanceDate
                }).ToList();
            }
            //if ((option.ClassID == -1 || option.LevelID == -1) && option.StudentID != -1)
            //{
            //    return null;
            //    //depts = context.AttendanceTables.Where(x => x.Student.LevelID == option.LevelID && x.Student.ClassID == option.ClassID).Select(x => new AttendanceViewModel
            //    //{
            //    //    StudentName = x.Student.StudentName,
            //    //    TeacherName = x.TeacherTable.TeacherName,
            //    //    Attendance = x.Attendance,
            //    //    AttendanceDate = x.AttendanceDate
            //    //}).ToList();
            //}
            if (option.ClassID != -1 && option.LevelID != -1 && option.StudentID != -1)
            {
                depts = context.AttendanceTables.Where(x => x.StudentID==option.StudentID).Select(x => new AttendanceViewModel
                {
                    StudentName = x.Student.StudentName,
                    TeacherName = x.TeacherTable.TeacherName,
                    Attendance = x.Attendance,
                    AttendanceDate = x.AttendanceDate
                }).ToList();
            }
            return depts;
        }


        //LoadData in page Attendance Report
        public IEnumerable<AttendanceViewModel> LoadDataAdvancedReport(AttendanceViewModel option)
        {
            List<AttendanceViewModel> depts = new List<AttendanceViewModel>();
            if (option.LevelID != -1 && option.ClassID == -1 && option.AttendanceDate == null)
            {
                depts = context.AttendanceTables.Where(x => x.Student.LevelID == option.LevelID).Select(x => new AttendanceViewModel
                {
                    StudentName = x.Student.StudentName,
                    TeacherName = x.TeacherTable.TeacherName,
                    Attendance = x.Attendance,
                    AttendanceDate = x.AttendanceDate
                }).ToList();
            }
            if (option.LevelID != -1 && option.ClassID != -1 && option.AttendanceDate == null)
            {
                depts = context.AttendanceTables.Where(x => x.Student.LevelID == option.LevelID && x.Student.ClassID == option.ClassID).Select(x => new AttendanceViewModel
                {
                    StudentName = x.Student.StudentName,
                    TeacherName = x.TeacherTable.TeacherName,
                    Attendance = x.Attendance,
                    AttendanceDate = x.AttendanceDate
                }).ToList();
            }
            if (option.LevelID != -1 && option.ClassID == -1 && option.AttendanceDate != null)
            {
                depts = context.AttendanceTables.Where(x => x.Student.LevelID == option.LevelID&&x.AttendanceDate==option.AttendanceDate).Select(x => new AttendanceViewModel
                {
                    StudentName = x.Student.StudentName,
                    TeacherName = x.TeacherTable.TeacherName,
                    Attendance = x.Attendance,
                    AttendanceDate = x.AttendanceDate
                }).ToList();
            }
            if (option.LevelID == -1 && option.ClassID != -1 && option.AttendanceDate != null)
            {
                depts = context.AttendanceTables.Where(x => x.Student.ClassID == option.ClassID&&x.AttendanceDate==option.AttendanceDate).Select(x => new AttendanceViewModel
                {
                    StudentName = x.Student.StudentName,
                    TeacherName = x.TeacherTable.TeacherName,
                    Attendance = x.Attendance,
                    AttendanceDate = x.AttendanceDate
                }).ToList();
            }
            if (option.LevelID == -1 && option.ClassID != -1 && option.AttendanceDate == null)
            {
                depts = context.AttendanceTables.Where(x => x.Student.ClassID == option.ClassID).Select(x => new AttendanceViewModel
                {
                    StudentName = x.Student.StudentName,
                    TeacherName = x.TeacherTable.TeacherName,
                    Attendance = x.Attendance,
                    AttendanceDate = x.AttendanceDate
                }).ToList();
            }
            if (option.LevelID == -1 && option.ClassID == -1 && option.AttendanceDate != null)
            {
                depts = context.AttendanceTables.Where(x => x.AttendanceDate == option.AttendanceDate).Select(x => new AttendanceViewModel
                {
                    StudentName = x.Student.StudentName,
                    TeacherName = x.TeacherTable.TeacherName,
                    Attendance = x.Attendance,
                    AttendanceDate = x.AttendanceDate
                }).ToList();
            }
            if (option.LevelID != -1 && option.ClassID != -1 && option.AttendanceDate != null)
            {
                depts = context.AttendanceTables.Where(x => x.Student.LevelID == option.LevelID && x.Student.ClassID == option.ClassID && x.AttendanceDate == option.AttendanceDate).Select(x => new AttendanceViewModel
                {
                    StudentName = x.Student.StudentName,
                    TeacherName = x.TeacherTable.TeacherName,
                    Attendance = x.Attendance,
                    AttendanceDate = x.AttendanceDate
                }).ToList();
            }
            return depts;
        }
    }

}
