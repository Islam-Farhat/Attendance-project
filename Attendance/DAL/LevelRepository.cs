using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DataModel;

namespace DAL
{
    interface ILevelRepository
    {
        bool Add(LevelViewModel dept); 
        bool Update(LevelViewModel dept);
        bool Delete(int id);
        LevelViewModel GetByID(int id);
        IEnumerable<LevelViewModel> GetAll();
        //int counter(int i);

    }
    public class LevelRepository : ILevelRepository
    {
        AttendanceEntities context = new AttendanceEntities();
        //ADD data in table using viewmodel
        public bool Add(LevelViewModel dept)
        {
            Level obj = new Level();
            try
            {
                obj.LevelName = dept.LevelName;
                context.Levels.Add(obj);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Update data in table using viewmodel
        public bool Update(LevelViewModel dept)
        {
            try
            {
                Level obj = context.Levels.FirstOrDefault(x => x.LevelID == dept.LevelID);
                if (obj != null)
                {
                    obj.LevelName = dept.LevelName;
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
                    Level obj = context.Levels.FirstOrDefault(x => x.LevelID == id);
                    if (obj != null)
                    {
                        context.Levels.Remove(obj);
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

        public IEnumerable<LevelViewModel> GetAll()
        {

            List<LevelViewModel> depts = new List<LevelViewModel>();
            foreach (var item in context.Levels)
            {
                LevelViewModel obj = new LevelViewModel();
                obj.LevelID = item.LevelID;
                obj.LevelName = item.LevelName;
               // obj.counter = counter(item.LevelID);
                depts.Add(obj);
            }
            return depts;
        }

        public LevelViewModel GetByID(int id)
        {
            Level dept = context.Levels.FirstOrDefault(x => x.LevelID == id);
            LevelViewModel obj = new LevelViewModel();
            obj.LevelID = dept.LevelID;
            obj.LevelName = dept.LevelName;
            return obj;
        }
        //int a = 0;
        //public int counter(int id)
        //{
        //    Level deptName = context.Levels.Where(x => x.LevelID == id).FirstOrDefault();
        //    a++;
        //    return a;
        //}
    }
}
