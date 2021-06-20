using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            var cat = new CategoryDao();
            var model = cat.ListAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                var category = new CategoryDao();
                if (category.FindName(model.Cat_Name))
                {
                    SetAlert("Danh Mục Đã Tồn Tại!!!", "warning");
                    return RedirectToAction("Create", "Category");
                }
                //var user = dao.FindId(model.admin_id);
                string result = category.Insert(model);
                if (!string.IsNullOrEmpty(result))
                {
                    SetAlert("Thêm danh mục thành công", "success");
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    SetAlert("Thêm danh mục thất bại", "error");
                    //return RedirectToAction("Create", "User");
                }
            }
            return View();
        }
        public ActionResult Edit(System.Int32 id)
        {
            var category = new CategoryDao();
            var result = category.FindId(id);
            if (result != null)
                return View(result);
            return View();
        }
        [HttpPost]

        public ActionResult Edit(Category model)
        {
            var category = new CategoryDao();
            string result = category.Update(model);
            if (!string.IsNullOrEmpty(result))
            {
                SetAlert("Cập nhật thể loại thành công", "success");
                return RedirectToAction("Index", "Category");
            }
            else
            {
                SetAlert("Cập nhật thể loại thất bại", "error");
            }
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(System.Int32 id)
        {
            var category = new CategoryDao();
            Boolean result = category.Delete(id);
            if (result)
            {
                SetAlert("Đã xóa thành công", "success");
                return RedirectToAction("Index", "Category");
            }
            else
            {
                SetAlert("Xóa không thành công ", "error");
                return RedirectToAction("Index", "Category");
            }
        }
    }
}