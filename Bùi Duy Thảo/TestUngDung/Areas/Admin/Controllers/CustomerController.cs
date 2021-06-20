using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Common;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class CustomerController : BaseController
    {
        // GET: Admin/Customer
        public ActionResult Index()
        {
            var cus = new CustomerDao();
            var model = cus.ListAll();
            return View(model);
        }



        [HttpDelete]
        public ActionResult Delete(System.Int32 id)
        {
            var customer = new CustomerDao();
            Boolean result = customer.Delete(id);
            if (result)
            {
                SetAlert("Đã xóa thành công", "success");
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                SetAlert("Xóa không thành công ", "error");
                return RedirectToAction("Index", "Customer");
            }

        }
        public ActionResult Edit(System.Int32 id)
        {
            var customer = new CustomerDao();
            var result = customer.FindId(id);
            if (result != null)
                return View(result);
            return View();
        }
        [HttpPost]

        public ActionResult Edit(Customer model)
        {
            var customer = new CustomerDao();
            model.Cus_Pass = Encryptor.EncryptMD5(model.Cus_Pass);
            string result = customer.Update(model);
            if (!string.IsNullOrEmpty(result))
            {
                SetAlert("Cập nhật thể loại thành công", "success");
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                SetAlert("Cập nhật thể loại thất bại", "error");
            }
            return View();
        }

    }
}