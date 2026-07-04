using Model.Dao;
using Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class MenuTypeController : BaseController
    {
        // GET: Admin/MenuType
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new MenuTypeDao();
            var model = dao.ListAll(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MenuType mn)
        {
            if (ModelState.IsValid)
            {
                var dao = new MenuTypeDao();
                int id = dao.Insert(mn);
                if (id > 0)
                {
                    SetAlert("Thêm Dữ Liệu Thành Công", "success");
                    return RedirectToAction("Index", "MenuType");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Dữ Liệu Không Thành Công");
                }
            }
            return View(mn);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var mn = new MenuTypeDao().ViewDetail(id);
            return View(mn);
        }

        [HttpPost]
        public ActionResult Edit(MenuType mn)
        {
            if (ModelState.IsValid)
            {
                var dao = new MenuTypeDao();
                var result = dao.Update(mn);
                if (result)
                {
                    SetAlert("Cập Nhật Dữ Liệu Thành Công", "success");
                    return RedirectToAction("Index", "MenuType");
                }
                else
                {
                    //return RedirectToAction("Index", "Erro");
                    ModelState.AddModelError("", "Sửa Dữ Liệu Không Thành Công");
                }
            }
            return View(mn);
        }

        //[HttpDelete]
        //public ActionResult Delete(int id)
        //{
        //    new MenuTypeDao().Delete(id);
        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public JsonResult Delete(int id)
        {
            var dao = new MenuTypeDao();
            if (dao.CheckInUse(id))
            {
                return Json(new { success = false, message = "Không thể lưu thay đổi do dữ liệu đang tồn tại. Vui lòng kiểm tra lại hoặc liên hệ với quản trị viên, số điện thoại 0949234086 !", id = id }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                new MenuTypeDao().Delete(id);
                return Json(new { success = true, message = "Xóa dữ liệu thành công !", id = id }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Detail(int id)
        {
            var mn = new MenuTypeDao().ViewDetail(id);
            return View(mn);
        }
    }
}