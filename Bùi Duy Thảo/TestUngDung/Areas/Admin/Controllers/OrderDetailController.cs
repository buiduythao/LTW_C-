using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class OrderDetailController : Controller
    {
        // GET: Admin/OrderDetail
        public ActionResult Index(System.Int32 id)
        {
            var orderDet = new OrderDetailDao();
            var model = orderDet.ListAll(id);
            var order = new OrderDao();
            var model_only = order.FindId(id);
            ViewBag.Order = model_only;
            return View(model);
        }
    }
}