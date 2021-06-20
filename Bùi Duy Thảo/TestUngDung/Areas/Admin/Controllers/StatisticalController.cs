using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class StatisticalController : Controller
    {
        // GET: Admin/Statistical
        public ActionResult Index()
        {
            var sta = new StatisticalDao();
            var model = sta.ListAll();
            var authors = new AuthorDao();
            var aut = authors.ListAll();
            var categorys = new CategoryDao();
            var cat = categorys.ListAll();
            ViewBag.Category = cat;
            ViewBag.Author = aut;
            return View(model);
        }


        [HttpPost]
        public JsonResult LoadData(int idCat, int idAut)
        {
            var sta = new StatisticalDao();
            var model = sta.ListAllDK(idCat, idAut);
            return Json(model);
        }
    }
}