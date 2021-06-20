using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class AdminDao
    {
        private BuiDuyThaoContext db;
        public AdminDao()
        {
            db = new BuiDuyThaoContext();
        }
        public int login(string user, string pass)
        {
            var result = db.Admins.SingleOrDefault(x => x.Ad_UserName.Contains(user) && x.Ad_Pass.Contains(pass));
            return result == null ? 0 : 1;
        }
    }
}
