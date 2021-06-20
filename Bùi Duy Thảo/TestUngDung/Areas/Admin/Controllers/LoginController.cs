using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.Admin.Models;
using TestUngDung.Common;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel admin)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDao();
                var result = dao.login(admin.UserName, Encryptor.EncryptMD5(admin.PassWord));
                if (result == 1)
                {
                    ModelState.AddModelError("", "Đăng nhập thành công!!");
                    Session.Add(Constants.ADMIN_SESSION, admin);
                    return RedirectToAction("Index", "Dasboard");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập thất bại!!");
                }
            }
            return View("Index");
        }
    }
}