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
    }
}
