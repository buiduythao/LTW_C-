using ModelEF.Model;
using ModelEF.ViewModelClone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class OrderDetailDao
    {

        private BuiDuyThaoContext db;
        public OrderDetailDao()
        {
            db = new BuiDuyThaoContext();
        }
        public List<OrderDetailModel> ListAll(System.Int32 id)
        {
            var list_orderdetail = from s in db.Order_Detail
                                   join p in db.Products
                                   on s.Pro_ID equals p.Pro_ID
                                   where s.Ord_ID == id
                                   select new OrderDetailModel
                                   {
                                       OrdDetID = s.OrDet_ID,
                                       OrdID = s.Ord_ID,
                                       ProName = p.Pro_Name,
                                       ProPrice = p.Pro_Price,
                                       OrdDetQuantity = s.OrDet_Quantity
                                   };
            return list_orderdetail.ToList();
        }
        public void Delete(System.Int32 orderdet_id)
        {
            try
            {
                var orderdet = db.Order_Detail.Find(orderdet_id);
                db.Order_Detail.Remove(orderdet);
                db.SaveChanges();

            }
            catch (Exception ex)
            {

            }
        }
    }
}
