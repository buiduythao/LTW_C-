using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.Admin.Models;
using TestUngDung.Common;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class DasboardController : BaseController
    {
        // GET: Admin/Dasboard
        public ActionResult Index()
        {
            var session = (LoginModel)Session[Constants.ADMIN_SESSION];
            if (session == null) return RedirectToAction("Index", "Login");
            return View();
        }
        public ActionResult Logout()
        {
            Session[Constants.ADMIN_SESSION] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}