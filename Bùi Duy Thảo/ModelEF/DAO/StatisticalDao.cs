using ModelEF.Model;
using ModelEF.ViewModelClone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class StatisticalDao
    {
        private BuiDuyThaoContext db;
        public StatisticalDao()
        {
            db = new BuiDuyThaoContext();
        }
        public List<StatisticalModel> ListAll()
        {
            var list_orderdetail = from s in db.Order_Detail
                                   join p in db.Products
                                   on s.Pro_ID equals p.Pro_ID
                                   join c in db.Categories
                                   on p.Cat_ID equals c.Cat_ID
                                   join a in db.Authors
                                   on p.Aut_ID equals a.Aut_ID
                                   select new StatisticalModel
                                   {
                                       ProID = s.Pro_ID,
                                       ProName = p.Pro_Name,
                                       CatName = c.Cat_Name,
                                       AutName = a.Aut_Name,
                                       ProImg = p.Pro_Img,
                                       ProPrice = p.Pro_Price,
                                       ProQuatity = s.OrDet_Quantity

                                   };
            var result = from s in list_orderdetail
                         group s by s.ProID into r
                         select new StatisticalModel
                         {
                             ProID = r.FirstOrDefault().ProID,
                             ProName = r.FirstOrDefault().ProName,
                             CatName = r.FirstOrDefault().CatName,
                             AutName = r.FirstOrDefault().AutName,
                             ProImg = r.FirstOrDefault().ProImg,
                             ProPrice = r.FirstOrDefault().ProPrice,
                             ProQuatity = r.Sum(x => x.ProQuatity)
                         };
            return result.ToList();
        }
        public List<StatisticalModel> ListAllDK(int idCat, int idAut)
        {
            IEnumerable<StatisticalModel> list_orderdetail;
            if (idCat == 0 && idAut == 0)
            {
                list_orderdetail = from s in db.Order_Detail
                                   join p in db.Products
                                   on s.Pro_ID equals p.Pro_ID
                                   join c in db.Categories
                                   on p.Cat_ID equals c.Cat_ID
                                   join a in db.Authors
                                   on p.Aut_ID equals a.Aut_ID
                                   select new StatisticalModel
                                   {
                                       ProID = s.Pro_ID,
                                       ProName = p.Pro_Name,
                                       CatName = c.Cat_Name,
                                       AutName = a.Aut_Name,
                                       ProImg = p.Pro_Img,
                                       ProPrice = p.Pro_Price,
                                       ProQuatity = s.OrDet_Quantity

                                   };
            }
            else if (idCat == 0 && idAut != 0)
            {
                list_orderdetail = from s in db.Order_Detail
                                   join p in db.Products
                                   on s.Pro_ID equals p.Pro_ID
                                   join c in db.Categories
                                   on p.Cat_ID equals c.Cat_ID
                                   join a in db.Authors
                                   on p.Aut_ID equals a.Aut_ID
                                   where a.Aut_ID == idAut
                                   select new StatisticalModel
                                   {
                                       ProID = s.Pro_ID,
                                       ProName = p.Pro_Name,
                                       CatName = c.Cat_Name,
                                       AutName = a.Aut_Name,
                                       ProImg = p.Pro_Img,
                                       ProPrice = p.Pro_Price,
                                       ProQuatity = s.OrDet_Quantity

                                   };
            }
            else if (idCat != 0 && idAut == 0)
            {
                list_orderdetail = from s in db.Order_Detail
                                   join p in db.Products
                                   on s.Pro_ID equals p.Pro_ID
                                   join c in db.Categories
                                   on p.Cat_ID equals c.Cat_ID
                                   join a in db.Authors
                                   on p.Aut_ID equals a.Aut_ID
                                   where c.Cat_ID == idCat
                                   select new StatisticalModel
                                   {
                                       ProID = s.Pro_ID,
                                       ProName = p.Pro_Name,
                                       CatName = c.Cat_Name,
                                       AutName = a.Aut_Name,
                                       ProImg = p.Pro_Img,
                                       ProPrice = p.Pro_Price,
                                       ProQuatity = s.OrDet_Quantity

                                   };
            }
            else
            {
                list_orderdetail = from s in db.Order_Detail
                                   join p in db.Products
                                   on s.Pro_ID equals p.Pro_ID
                                   join c in db.Categories
                                   on p.Cat_ID equals c.Cat_ID
                                   join a in db.Authors
                                   on p.Aut_ID equals a.Aut_ID
                                   where c.Cat_ID == idCat && a.Aut_ID == idAut
                                   select new StatisticalModel
                                   {
                                       ProID = s.Pro_ID,
                                       ProName = p.Pro_Name,
                                       CatName = c.Cat_Name,
                                       AutName = a.Aut_Name,
                                       ProImg = p.Pro_Img,
                                       ProPrice = p.Pro_Price,
                                       ProQuatity = s.OrDet_Quantity

                                   };
            }
            var result = from s in list_orderdetail
                         group s by s.ProID into r
                         select new StatisticalModel
                         {
                             ProID = r.FirstOrDefault().ProID,
                             ProName = r.FirstOrDefault().ProName,
                             CatName = r.FirstOrDefault().CatName,
                             AutName = r.FirstOrDefault().AutName,
                             ProImg = r.FirstOrDefault().ProImg,
                             ProPrice = r.FirstOrDefault().ProPrice,
                             ProQuatity = r.Sum(x => x.ProQuatity)
                         };
            return result.ToList();
        }
    }
}
