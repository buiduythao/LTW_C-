using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class AuthorController : BaseController
    {
        public ActionResult Index()
        {
            var aut = new AuthorDao();
            var model = aut.ListAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Author model)
        {
            if (ModelState.IsValid)
            {
                var author = new AuthorDao();
                if (author.FindName(model.Aut_Name))
                {
                    SetAlert("Tác Giả Đã Tồn Tại!!!", "warning");
                    return RedirectToAction("Create", "Category");
                }
                //var user = dao.FindId(model.admin_id);
                string result = author.Insert(model);
                if (!string.IsNullOrEmpty(result))
                {
                    SetAlert("Thêm tác giả thành công", "success");
                    return RedirectToAction("Index", "Author");
                }
                else
                {
                    SetAlert("Thêm tác giả thất bại", "error");
                    //return RedirectToAction("Create", "User");
                }
            }
            return View();
        }
        public ActionResult Edit(System.Int32 id)
        {
            var author = new AuthorDao();
            var result = author.FindId(id);
            if (result != null)
                return View(result);
            return View();
        }
        [HttpPost]

        public ActionResult Edit(Author model)
        {
            var author = new AuthorDao();
            string result = author.Update(model);
            if (!string.IsNullOrEmpty(result))
            {
                SetAlert("Cập nhật tác giả thành công", "success");
                return RedirectToAction("Index", "Author");
            }
            else
            {
                SetAlert("Cập nhật tác giả thất bại", "error");
            }
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(System.Int32 id)
        {
            var author = new AuthorDao();
            Boolean result = author.Delete(id);
            if (result)
            {
                SetAlert("Đã xóa thành công", "success");
                return RedirectToAction("Index", "Author");
            }
            else
            {
                SetAlert("Xóa không thành công ", "error");
                return RedirectToAction("Index", "Author");
            }

        }
    }
}