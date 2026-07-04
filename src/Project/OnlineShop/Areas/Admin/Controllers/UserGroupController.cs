using Model.Dao;
using Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class UserGroupController : BaseController
    {
        // GET: Admin/UserGroup        
            public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new UserGroupDao();
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
        public ActionResult Create(UserGroup mn)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserGroupDao();
                string id = dao.Insert(mn);
                if (id !=null)
                {
                    SetAlert("Thêm Dữ Liệu Thành Công", "success");
                    return RedirectToAction("Index", "UserGroup");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Dữ Liệu Không Thành Công");
                }
            }
            return View(mn);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var mn = new UserGroupDao().ViewDetail(id);
            return View(mn);
        }

        [HttpPost]
        public ActionResult Edit(UserGroup mn)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserGroupDao();
                var result = dao.Update(mn);
                if (result)
                {
                    SetAlert("Cập Nhật Dữ Liệu Thành Công", "success");
                    return RedirectToAction("Index", "UserGroup");
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
        //public ActionResult Delete(string id)
        //{
        //    new UserGroupDao().Delete(id);
        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public JsonResult Delete(string id)
        {
            var dao = new UserGroupDao();
            if (dao.CheckInUse(id))
            {
                return Json(new { success = false, message = "Không thể lưu thay đổi do dữ liệu đang tồn tại. Vui lòng kiểm tra lại hoặc liên hệ với quản trị viên, số điện thoại 0949234086 !", id = id }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                new UserGroupDao().Delete(id);
                return Json(new { success = true, message = "Xóa dữ liệu thành công !", id = id }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Detail(string id)
        {
            var mn = new UserGroupDao().ViewDetail(id);
            return View(mn);
        }
    }
}