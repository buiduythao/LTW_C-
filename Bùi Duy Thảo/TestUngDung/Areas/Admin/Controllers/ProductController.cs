using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        BuiDuyThaoContext db = new BuiDuyThaoContext();
        // GET: Admin/Product
        public ActionResult Index(string searchString)
        {
            var product = new ProductDao();
            var model = product.ListAll(searchString);
            ViewBag.searchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            setViewBagCat();
            setViewBagAut();
            return View();
        }
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product sp, HttpPostedFileBase Pro_Img)
        {


            if (Pro_Img != null && Pro_Img.ContentLength > 0)
            {
                int id = int.Parse(db.Products.ToList().Last().Pro_ID.ToString());
                string _FileName = Path.GetFileName(Pro_Img.FileName);
                int index = Path.GetFileName(Pro_Img.FileName).IndexOf('.');
                _FileName = "sp" + id.ToString() + "." + Path.GetFileName(Pro_Img.FileName).Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Upload/Product/" + _FileName));
                Pro_Img.SaveAs(_path);
                sp.Pro_Img = _FileName;
            }

            if (ModelState.IsValid)
            {
                db.Products.Add(sp);
                db.SaveChanges();
                SetAlert("Thêm Sách Thành Công", "success");
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(System.Int32 id)
        {
            var product = new ProductDao();
            var result = product.FindId(id);
            if (result != null)
            {
                setViewBagCat(result.Cat_ID);
                setViewBagAut(result.Aut_ID);
                return View(result);
            }
            return View();
        }

        [HttpPost,ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product sp, HttpPostedFileBase Pro_Img)
        {
            Product pro_up = db.Products.FirstOrDefault(x => x.Pro_ID == sp.Pro_ID);

            if (pro_up != null)
            {
                pro_up.Cat_ID = sp.Cat_ID;
                pro_up.Aut_ID = sp.Aut_ID;
                pro_up.Pro_Name = sp.Pro_Name;
                pro_up.Pro_Price = sp.Pro_Price;
                pro_up.Pro_Quantity = sp.Pro_Quantity;
                pro_up.Pro_Status = sp.Pro_Status;
                pro_up.Pro_Description = sp.Pro_Description;
                if (Pro_Img != null && Pro_Img.ContentLength > 0)
                {
                    int id = sp.Pro_ID;
                    string _FileName = "";
                    int index = Path.GetFileName(Pro_Img.FileName).IndexOf('.');
                    _FileName = "udsp" + id.ToString() + "." + Path.GetFileName(Pro_Img.FileName).Substring(index + 1);
                    string _path = Path.Combine(Server.MapPath("~/Upload/product/" + _FileName));
                    Pro_Img.SaveAs(_path);
                    pro_up.Pro_Img = _FileName;
                }
            }

            if (ModelState.IsValid)
            {
                db.SaveChanges();
                SetAlert("Cập Nhật Sách Thành Công", "success");
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var product = new ProductDao().Delete(id);
            if (product)
            {
                SetAlert("Đã xóa thành công", "success");
                return RedirectToAction("Index", "Product");
            }
            else
            {
                SetAlert("Xóa không thành công ", "error");
                return RedirectToAction("Index", "Product");
            }

        }
        public void setViewBagCat(int? selectedID = null)
        {
            var cat = new CategoryDao();
            ViewBag.Cat_ID = new SelectList(cat.ListAll(), "Cat_ID", "Cat_Name", selectedID);
        }
        public void setViewBagAut(int? selectedID = null)
        {
            var aut = new AuthorDao();
            ViewBag.Aut_ID = new SelectList(aut.ListAll(), "Aut_ID", "Aut_Name", selectedID);
        }
        [HttpPost]
        public JsonResult Detail(int idPro)
        {
            var pro = new ProductDao();
            var model = pro.Detail(idPro);
            return Json(model);
        }
    }
}