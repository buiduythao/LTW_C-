using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        // GET: Admin/Order
        public ActionResult Index()
        {
            var order = new OrderDao();
            var model = order.ListAll();
            return View(model);
        }
        public ActionResult Update(System.Int32 id)
        {
            var order = new OrderDao();
            int result = order.Update(id);
            if (result == 1)
            {
                SetAlert("Duyệt đơn hàng thành công", "success");
                return RedirectToAction("Index", "Order");
            }
            else
            {
                SetAlert("Duyệt đơn hàng thất bại", "error");
            }
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(System.Int32 id)
        {
            var order = new OrderDao();
            Boolean result = order.Delete(id);
            if (result)
            {
                SetAlert("Đã xóa thành công", "success");
                return RedirectToAction("Index", "Order");
            }
            else
            {
                SetAlert("Xóa không thành công ", "error");
                return RedirectToAction("Index", "Order");
            }

        }
        public ActionResult Delete_Link(System.Int32 id)
        {
            var order = new OrderDao();
            Boolean result = order.Delete(id);
            if (result)
            {
                SetAlert("Đã xóa thành công", "success");
                return RedirectToAction("Index", "Order");
            }
            else
            {
                SetAlert("Xóa không thành công ", "error");
                return RedirectToAction("Index", "Order");
            }

        }
    }
}