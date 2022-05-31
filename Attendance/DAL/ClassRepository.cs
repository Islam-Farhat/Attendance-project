using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DataModel;

namespace DAL
{
    interface IClassRepository
    {
        bool Add(ClassViewModel dept);
        bool Update(ClassViewModel dept);
        bool Delete(int id);
        ClassViewModel GetByID(int id);
        IEnumerable<ClassViewModel> GetAll();
        int counter(int i);
        IEnumerable<LevelViewModel> Dropdownlist();

    }
    public class ClassRepository : IClassRepository
    {
        AttendanceEntities context = new AttendanceEntities();

        //ADD data in table using viewmodel
        public bool Add(ClassViewModel dept)
        {
            Class obj = new Class();
            try
            {
                if (dept.ClassName==null || dept.Seat == null)
                {
                    return false;
                }
                else
                {
                    obj.ClassName = dept.ClassName;
                    obj.Seat = dept.Seat;
                    obj.LevelID = dept.LevelID;
                    context.Classes.Add(obj);
                    context.SaveChanges();
                    return true;
                }
                
            }
            catch
            {
                return false;
            }
        }

        //Dropdownlist in table
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
        public bool Update(ClassViewModel dept)
        {
            try
            {
                Class obj = context.Classes.FirstOrDefault(x => x.ClassID == dept.ClassID);
                if (obj != null)
                {
                    obj.ClassName = dept.ClassName;
                    obj.Seat = dept.Seat;
                    obj.LevelID = dept.LevelID;
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
                    Class obj = context.Classes.FirstOrDefault(x => x.ClassID == id);
                    if (obj != null)
                    {
                        context.Classes.Remove(obj);
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

        public IEnumerable<ClassViewModel> GetAll()
        {
            List<ClassViewModel> depts = new List<ClassViewModel>();
            foreach (var item in context.Classes)
            {
                ClassViewModel obj = new ClassViewModel();
                obj.ClassID = item.ClassID;
                obj.ClassName = item.ClassName;
                obj.Seat = item.Seat;
                obj.LevelID = item.LevelID;
                obj.LevelName = item.Level.LevelName;
                obj.counter = counter(item.ClassID);
                depts.Add(obj);
            }
            return depts;
        }

        public ClassViewModel GetByID(int id)
        {
            Class dept = context.Classes.FirstOrDefault(x => x.ClassID == id);
            ClassViewModel obj = new ClassViewModel();           
            obj.ClassID = dept.ClassID;
            obj.ClassName = dept.ClassName;
            obj.Seat = dept.Seat;
            obj.LevelID = dept.LevelID;
            return obj;
        }
        int a = 0;
        public int counter(int id)
        {
            Class deptName = context.Classes.Where(x => x.ClassID == id).FirstOrDefault();
            a++;
            return a;
        }
    }
}
