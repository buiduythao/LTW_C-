using ModelEF.Model;
using ModelEF.ViewModelClone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class OrderDao
    {
        private BuiDuyThaoContext db;
        public OrderDao()
        {
            db = new BuiDuyThaoContext();
        }
        public List<OrderModel> ListAll()
        {
            var list_order = from s in db.Orders
                             join c in db.Customers
                             on s.Cus_ID equals c.Cus_ID
                             select new OrderModel
                             {
                                 OrdID = s.Ord_ID,
                                 CusName = c.Cus_Name,
                                 CusAddress = c.Cus_Address,
                                 OrdTotal = s.Ord_TotalMoney,
                                 OrdDate = (DateTime)s.Ord_Date,
                                 OrdStatus = s.Ord_Status,
                                 OrdDescription = s.Ord_Description,

                             };
            return list_order.ToList();
        }
        public Order FindId(System.Int32 order_id)
        {
            return db.Orders.Find(order_id);
        }
        public int Update(System.Int32 order_id)
        {
            var order = FindId(order_id);
            if (order != null)
            {
                order.Ord_Status = "1";

            }
            db.SaveChanges();
            return 1;
        }
        public bool Delete(System.Int32 order_id)
        {
            try
            {
                OrderDetailDao det = new OrderDetailDao();
                var list_detorder = from s in db.Order_Detail
                                    where s.Ord_ID == order_id
                                    select s.OrDet_ID;
                foreach (int i in list_detorder)
                {
                    det.Delete(i);
                }
                var order = db.Orders.Find(order_id);
                db.Orders.Remove(order);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
