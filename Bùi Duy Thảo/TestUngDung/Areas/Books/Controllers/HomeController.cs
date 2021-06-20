using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Books.Controllers
{
    public class HomeController : Controller
    {
        // GET: Books/Home
        public ActionResult Index()
        {
            var authors = new AuthorDao();
            var aut = authors.ListAll();
            var categorys = new CategoryDao();
            var cat = categorys.ListAll();
            ViewBag.Category = cat;
            ViewBag.Author = aut;
            var product = new ProductDao();
            var model = product.ListAllLimit6();
            ViewBag.Pro_casualActi = product.ListCasuaActiLimit3();
            ViewBag.Pro_casualItem = product.ListCasuaItem();
            ViewBag.Pro_Tab = product.ListTabItem();
            return View(model);
        }
    }
}