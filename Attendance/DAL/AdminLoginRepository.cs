using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DataModel;

namespace DAL
{
    interface IAdminLoginRepository
    {
        bool Login(AdminLoginViewModel dept);
    }
    public class AdminLoginRepository : IAdminLoginRepository
    {
        AttendanceEntities context = new AttendanceEntities();
        public bool Login(AdminLoginViewModel dept)
        {
            try
            {
                var obj = context.AdminPanals.Where(x => x.AdminName == dept.AdminName && x.Password == dept.Password).FirstOrDefault();
                if (obj is null)
                {
                    return false;
                }
                if (obj.AdminName == dept.AdminName && obj.Password == dept.Password)
                {


                    return true;

                }
                return false;
            }
            catch
            {

                return false;
            }

        }
    }
}
