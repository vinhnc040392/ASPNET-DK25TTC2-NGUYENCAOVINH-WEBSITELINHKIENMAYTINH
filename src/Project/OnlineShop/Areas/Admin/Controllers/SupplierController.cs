using Model.Dao;
using Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class SupplierController : BaseController
    {
        // GET: Admin/Suppliers
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new SupplierDao();
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
        public ActionResult Create(Supplier sup)
        {
            if (ModelState.IsValid)
            {
                var dao = new SupplierDao();
                string id = dao.Insert(sup);
                if (id != null)
                {
                    SetAlert("Thêm Dữ Liệu Thành Công", "success");
                    return RedirectToAction("Index", "Supplier");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Dữ Liệu Không Thành Công");
                }
            }
            return View(sup);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var sup = new SupplierDao().ViewDetail(id);
            return View(sup);
        }

        [HttpPost]
        public ActionResult Edit(Supplier sup)
        {
            if (ModelState.IsValid)
            {
                var dao = new SupplierDao();
                var result = dao.Update(sup);
                if (result)
                {
                    SetAlert("Cập Nhật Dữ Liệu Thành Công", "success");
                    return RedirectToAction("Index", "Supplier");
                }
                else
                {
                    //return RedirectToAction("Index", "Erro");
                    ModelState.AddModelError("", "Sửa Dữ Liệu Không Thành Công");
                }
            }
            return View(sup);
        }

        //[HttpDelete]
        //public ActionResult Delete(string id)
        //{
        //    new SupplierDao().Delete(id);
        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public JsonResult Delete(string id)
        {
            var dao = new SupplierDao();
            if (dao.CheckInUse(id))
            {
                return Json(new { success = false, message = "Không thể lưu thay đổi do dữ liệu đang tồn tại. Vui lòng kiểm tra lại hoặc liên hệ với quản trị viên, số điện thoại 0949234086 !", id = id }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                new SupplierDao().Delete(id);
                return Json(new { success = true, message = "Xóa dữ liệu thành công !", id = id }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Detail(string id)
        {
            var pro = new SupplierDao().ViewDetail(id);
            return View(pro);
        }
    }
}