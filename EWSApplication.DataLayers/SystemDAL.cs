using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWSApplication.Entities;
using EWSApplication.Entities.DBContext;

namespace EWSApplication.DataLayers
{
    public class SystemDAL
    {
        EWSDbContext db = new EWSDbContext();
        public UserAccount Login(string userName, string password)
        {
            UserAccount data = null;
            data = db.UserAccounts.Where(x => (x.username == userName && x.password == password) ).FirstOrDefault<UserAccount>();
            return data;
        }
        public bool CreateNewAccount(UserAccount acc)
        {
            try
            {
                UserAccount newacc = new UserAccount()
                {
                   email = acc.email,
                   password  = acc.password,
                   username = acc.username,
                   roleid = acc.roleid,
                   facultyid = acc.facultyid
                };
                db.UserAccounts.Add(newacc);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeteleNewAccount(int userid)
        {
            try
            {
                UserAccount acc= db.UserAccounts.Where(x => x.userid == userid).SingleOrDefault();
                db.UserAccounts.Remove(acc);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
