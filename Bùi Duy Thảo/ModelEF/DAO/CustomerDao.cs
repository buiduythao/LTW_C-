using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class CustomerDao
    {

        private BuiDuyThaoContext db;
        public CustomerDao()
        {
            db = new BuiDuyThaoContext();
        }
        public List<Customer> ListAll()
        {
            return db.Customers.ToList();
        }
        public Customer FindId(System.Int32 customer_id)
        {
            return db.Customers.Find(customer_id);
        }
        public string Update(Customer entityCustomer)
        {
            var customer = FindId(entityCustomer.Cus_ID);
            if (customer != null)
            {
                customer.Cus_UserName = entityCustomer.Cus_UserName;
                customer.Cus_Pass = entityCustomer.Cus_Pass;
                customer.Cus_Status = entityCustomer.Cus_Status == "1" ? "Activated" : "Blocked";

            }
            db.SaveChanges();
            return entityCustomer.Cus_UserName;
        }
        public bool Delete(System.Int32 cus_id)
        {
            try
            {
                var customer = db.Customers.Find(cus_id);
                db.Customers.Remove(customer);
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
