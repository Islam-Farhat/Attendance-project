using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL; 
using BLL;
using System.IO;
using DataModel;

namespace UI.Controllers
{
    public class AdminLoginController : Controller
    {
       
        LevelRepository repo = new LevelRepository();
        ClassRepository re = new ClassRepository();
        TeacherRepository teach = new TeacherRepository();
        AdminLoginRepository log = new AdminLoginRepository();
        StudentRepository stud = new StudentRepository();
        AttendanceRepoaitory atend = new AttendanceRepoaitory();
        AttendanceEntities obj = new AttendanceEntities();

        //Home Action
        public ActionResult Home()
        {
            return View();
        }
        //Action of page Classes
        public ActionResult Class()
        {
            return View();
        }
        public ActionResult Dropdownlist()
        {
            IEnumerable<LevelViewModel> dept = re.Dropdownlist();
            return Json(dept, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetClass()
        {
            IEnumerable<ClassViewModel> dept = re.GetAll();
            return Json(dept, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreatClass(ClassViewModel departmentViewModel)
        {
          bool flag= re.Add(departmentViewModel);
            if (flag)
            {
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetByClassID(int id)
        {
            ClassViewModel dept = re.GetByID(id);
            return Json(dept, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditClass(ClassViewModel departmentViewModel)
        {
            re.Update(departmentViewModel);
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteClass(int id)
        {
            re.Delete(id);
            return Json("", JsonRequestBehavior.AllowGet);
        }


        //Action of page Teacher
        public ActionResult TeacherReport()
        {
            return View();
        }
        public ActionResult GetTeacher()
        {
            IEnumerable<TeacherViewModel> dept = teach.GetAll();
            return Json(dept, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteTeacher(int id)
        {
            teach.Delete(id);
            return Json("", JsonRequestBehavior.AllowGet);
        }
        /////////////////////////////////
        public ActionResult Teacher()
        {
            return View();
        } 
        public ActionResult DropdownlistTeacher()
        {
            IEnumerable<LevelViewModel> dept = teach.Dropdownlist();
            return Json(dept, JsonRequestBehavior.AllowGet);
        }      
        public ActionResult CreatTeacher(TeacherViewModel departmentViewModel)
        {
           bool x= teach.Add(departmentViewModel);
            if (x)
            {
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
            
        }
        /////////////////////////////////////
        //Login and go to Teacher profile
        public ActionResult LoginTeacher(TeacherViewModel dept)
        {

            bool flag = teach.LoginTeacher(dept);
            if (flag)
            {
                var id = obj.TeacherTables.Where(x => x.Email == dept.Email && x.Password == dept.Password).Select(x => x.TeacherID).FirstOrDefault();
                return Json(id, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult TeacherProfile(int id)
        {
            ViewBag.id = id;
            return View();
        }
        public ActionResult GetByTeacheeID(int id)
        {
            TeacherViewModel dept = teach.GetByID(id);
            return Json(dept, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditTeacher(TeacherViewModel teacherViewModel)
        {
           bool flag= teach.Update(teacherViewModel);
            if (flag)
            {
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult uploadFile()
        {
            // check if the user selected a file to upload
            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpFileCollectionBase files = Request.Files;

                    HttpPostedFileBase file = files[0];
                    string fileName = file.FileName;

                    // create the uploads folder if it doesn't exist
                    Directory.CreateDirectory(Server.MapPath("~/Files/"));
                    string path = Path.Combine(Server.MapPath("~/Files/"), fileName);
                    //string path = Path.Combine(Server.MapPath("~/Files/"), Path.GetFileName(file.FileName));

                    // save the file
                    file.SaveAs(path);
                    return Json("File uploaded successfully");
                }

                catch (Exception e)
                {
                    return Json("error" + e.Message);
                }
            }

            return Json("no files were selected !");
        }
        public ActionResult Feedback()
        {
            return View();
        }


        //Login Page
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult Login(AdminLoginViewModel dept)
        {
           bool flag= log.Login(dept);
            if (flag)
            {
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
            
        }

        //Action of page Levels
        public ActionResult Level()
        {
            return View();
        }
        public ActionResult GetLevel()
        {
            IEnumerable<LevelViewModel> dept = repo.GetAll();
            return Json(dept, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateLevel(LevelViewModel departmentViewModel)
        {
            repo.Add(departmentViewModel);
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetByLevelID(int id)
        {
            LevelViewModel dept = repo.GetByID(id);
            return Json(dept, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditLevel(LevelViewModel departmentViewModel)
        {
            repo.Update(departmentViewModel);
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteLevel(int id)
        {
            repo.Delete(id);
            return Json("", JsonRequestBehavior.AllowGet);
        }


        //Action of page Students
        public ActionResult Student(int teacherid)
        {
            ViewBag.id = teacherid;
            return View();
        }
        public ActionResult DropdownlistLevelStudent()
        {
            IEnumerable<LevelViewModel> dept = stud.DropdownlistLevelStudent();
            return Json(dept, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DropdownlistClassStudent()
        {
            IEnumerable<ClassViewModel> dept = stud.DropdownlistClassStudent();
            return Json(dept, JsonRequestBehavior.AllowGet);
        }
        //////////////////////////////////////
        ///Count seat in the class was choice
        public ActionResult CountSeat(StudentViewModel student)
        {
            var countseat = obj.Classes.Where(x => x.ClassID == student.ClassID).Select(x=>x.Seat).FirstOrDefault();
            //var countstudent= obj.Students.Where(x => x.LevelID == student.LevelID).Select(x =>x.StudentName).Count();
            return Json(countseat, JsonRequestBehavior.AllowGet);
        }
        ///Count seat in the level was choice
        public ActionResult CountStudent(StudentViewModel student)
        {
            //var countseat = obj.Classes.Where(x => x.ClassID == student.ClassID).Select(x => x.Seat).FirstOrDefault();
            var countstudent = obj.Students.Where(x => x.LevelID == student.LevelID&&x.ClassID==student.ClassID).Select(x => x.StudentName).Count();
            return Json(countstudent, JsonRequestBehavior.AllowGet);
        }
        ///Subtract between seat and number of student
        public ActionResult SubtractSeatandStudent(StudentViewModel student)
        {
            var countseat = obj.Classes.Where(x => x.ClassID == student.ClassID).Select(x => x.Seat).FirstOrDefault();
            var countstudent = obj.Students.Where(x => x.LevelID == student.LevelID && x.ClassID == student.ClassID).Select(x => x.StudentName).Count();
            int subtract = countseat - countstudent;
            if (subtract<0)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            return Json(subtract, JsonRequestBehavior.AllowGet);
        }
        //////////////////////////////////////
        public ActionResult AddStudent(StudentViewModel studentViewModel)
        {
            bool x = stud.Add(studentViewModel);
            if (x)
            {
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }

        //Action Attendance
        public ActionResult Attendance(int teacherid)
        {
            ViewBag.id = teacherid;
            return View();
        }
        public ActionResult GetAllAtendance(StudentViewModel student)
        {
            IEnumerable<StudentViewModel> dept = atend.GetAll(student);
            return Json(dept, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateAttendance(AttendanceViewModel Atendance)
        {
           bool flag= atend.Add(Atendance);
            if (flag)
            {
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
            
        }

        //Student Report actions
        public ActionResult StudentReports(int teacherid)
        {
            ViewBag.id = teacherid;
            return View();
        }

        //AdvancedAttendaceReport actions
        public ActionResult AdvancedAttendaceReport()
        {
            return View();
        }
        public ActionResult DropdownlistLevelAdvancedAttendaceReport()
        {
            IEnumerable<LevelViewModel> dept = atend.DropdownlistLevel();
            return Json(dept, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DropdownlistClassAdvancedAttendaceReport()
        {
            IEnumerable<ClassViewModel> dept = atend.DropdownlistClass();
            return Json(dept, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DropdownlistStudentAdvancedAttendaceReport()
        {
            IEnumerable<StudentViewModel> dept = atend.DropdownlistStudent();
            return Json(dept, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ReloadDropdownlistStudentAdvancedAttendaceReport(StudentViewModel option)
        {
            IEnumerable<StudentViewModel> dept = atend.ReloadDropdownlistStudent(option);
            return Json(dept, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LoadDataAdvancedAttendaceReport(AttendanceViewModel student)
        {
            IEnumerable<AttendanceViewModel> dept = atend.LoadData(student);

            return Json(dept, JsonRequestBehavior.AllowGet);
        }

        //Update password of Teacher  //validation
        public ActionResult UpdataPasswordTeacher(int teacherid)
        {
            ViewBag.id = teacherid;
            return View();
        }
        public ActionResult UpdatePassword(TeacherViewModel option)
        {
            bool flag = teach.UpdatePassword(option);
            if (flag)
            {
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

        }

        //Actions of Attendance Report
        public ActionResult AttendanceReport()
        {
            return View();
        }
        public ActionResult LoadDataAttendanceReport(AttendanceViewModel student)
        {
            IEnumerable<AttendanceViewModel> dept = atend.LoadDataAdvancedReport(student);

            return Json(dept, JsonRequestBehavior.AllowGet);
        }

        ////Actions of Advanced Report
        public ActionResult AdvancedReport()
        {
            return View();
        }
        public ActionResult LoadDataAdvReport(StudentViewModel student)
        {
            StudentViewModel dept = stud.LoadDataAdvancedReport(student);

            return Json(dept, JsonRequestBehavior.AllowGet);
        }

        //Actions of Students
        public ActionResult StudentProfile()
        {
            return View();
        }
    }
}