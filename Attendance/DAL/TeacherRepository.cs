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
    interface ITeacherRepository
    {
        bool Add(TeacherViewModel dept);
        bool Update(TeacherViewModel dept);
        bool UpdatePassword(TeacherViewModel dept);
        bool Delete(int id);
        TeacherViewModel GetByID(int id);
        IEnumerable<TeacherViewModel> GetAll();
        IEnumerable<LevelViewModel> Dropdownlist();
        bool LoginTeacher(TeacherViewModel dept);
    }
   public class TeacherRepository:ITeacherRepository
    {
        AttendanceEntities context = new AttendanceEntities();

        //ADD data in table using viewmodel
        public bool Add(TeacherViewModel dept)
        {
            var check = context.TeacherTables.Select(x => x.Email).Contains(dept.Email);
            if (check)
            {
                return false;
            }
            TeacherTable obj = new TeacherTable();
            try
            {
                obj.TeacherName = dept.TeacherName;
                obj.Email = dept.Email;
                obj.Mobile = dept.Mobile;
                obj.Address = dept.Address;
                obj.City = dept.City;
                obj.Gender = dept.Gender;
                obj.FileName = Path.GetFileName(dept.FileName);
                obj.LevelID = dept.LevelID;
                obj.Username = dept.Username;
                obj.Password = dept.Password;
                context.TeacherTables.Add(obj);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Dropdownlist level in table
        public IEnumerable<LevelViewModel> Dropdownlist()
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

        //Update data in table using viewmodel
        public bool Update(TeacherViewModel dept)
        {
            try
            {
                TeacherTable obj = context.TeacherTables.FirstOrDefault(x => x.Email == dept.Email);
                if (obj != null)
                {
                    //obj.TeacherName = dept.TeacherName;
                    obj.Email = dept.Email;
                    obj.Mobile = dept.Mobile;
                    obj.Address = dept.Address;
                    obj.City = dept.City;
                    // obj.Gender = dept.Gender;
                    obj.FileName = Path.GetFileName(dept.FileName);
                    //obj.FileName = dept.FileName;
                    // obj.LevelID = dept.LevelID;
                    // obj.Username = dept.Username;
                    // obj.Password = dept.Password;
                    //context.TeacherTables.Add(obj);
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Delete data in table using viewmodel
        public bool Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    TeacherTable obj = context.TeacherTables.FirstOrDefault(x => x.TeacherID == id);
                    if (obj != null)
                    {
                        context.TeacherTables.Remove(obj);
                        context.SaveChanges();
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Loaddata in table
        public IEnumerable<TeacherViewModel> GetAll()
        {
            List<TeacherViewModel> depts = new List<TeacherViewModel>();
            foreach (var item in context.TeacherTables)
            {
                TeacherViewModel obj = new TeacherViewModel();
                obj.TeacherID = item.TeacherID;
                obj.TeacherName = item.TeacherName;
                obj.Email = item.Email;
                obj.Mobile = item.Mobile;
                obj.Address = item.Address;
                obj.City = item.City;
                obj.Gender = item.Gender;
                obj.FileName = item.FileName;
                obj.LevelID = item.LevelID;
                obj.LevelName = item.Level.LevelName;
                obj.Username = item.Username;
                obj.Password = item.Password;
                depts.Add(obj);
            }
            return depts;
        }

        //geting id of row
        public TeacherViewModel GetByID(int id)
        {
            //var dept = context.TeacherTables.Where(x => x.TeacherID == id).Select(x=> new TeacherViewModel {
            //TeacherID=x.TeacherID,
            //TeacherName=x.TeacherName,
            //Email=x.Email,
            //Mobile=x.Mobile,
            //Address=x.Address,
            //City=x.City,
            //Gender=x.Gender}).FirstOrDefault();
            TeacherTable dept = context.TeacherTables.FirstOrDefault(x => x.TeacherID == id);
            TeacherViewModel obj = new TeacherViewModel();
            obj.TeacherID = dept.TeacherID;
            obj.TeacherName = dept.TeacherName;
            obj.Email = dept.Email;
            obj.Mobile = dept.Mobile;
            obj.Address = dept.Address;
            obj.City = dept.City;
            obj.FileName = dept.FileName;
            return obj;
        }

        //Login to update teacher in table
        public  bool LoginTeacher(TeacherViewModel dept)
        {
            try
            {
                var obj = context.TeacherTables.Where(x => x.Email == dept.Email).FirstOrDefault();
                if (obj is null)
                {
                    return false;
                }
                if (obj.Password == dept.Password)
                {
                    //GetByID(obj.Teache

                    return true;

                }
                return false;
            }
            catch
            {

                return false;
            }

        }

        //Update data in table using viewmodel
        public bool UpdatePassword(TeacherViewModel dept)
        {
            try
            {
                TeacherTable obj = context.TeacherTables.FirstOrDefault(x => x.TeacherID == dept.TeacherID);
                if (dept.OldPassword==obj.Password)
                {
                    //obj.TeacherName = dept.TeacherName;
                    obj.Password = dept.Password;
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
