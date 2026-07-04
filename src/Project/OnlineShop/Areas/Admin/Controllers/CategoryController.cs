using Model.Dao;
using Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new CategoryDao();
            var model = dao.ListAll(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBagCategory();
            SetViewBagUser();
            ViewBag.listStatus = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Kích Hoạt", Value = "true"},
                    new SelectListItem {Text = "Không Kích Hoạt", Value = "false"},
                };
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category ct)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
                ct.CreateDate = DateTime.Now;
                int id = dao.Insert(ct);
                if (id > 0)
                {
                    SetAlert("Thêm Dữ Liệu Thành Công", "success");
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Dữ Liệu Không Thành Công");
                }
            }
            SetViewBagCategory();
            SetViewBagUser();
            ViewBag.listStatus = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Kích Hoạt", Value = "true"},
                    new SelectListItem {Text = "Không Kích Hoạt", Value = "false"},
                };
            return View(ct);
        }

        //hien thi droplist
        public void SetViewBagCategory(int? selectId = null)
        {
            var daopr = new CategoryDao();
            ViewBag.ParenId = new SelectList(daopr.DropListCategory(), "idCategories", "Name", selectId);
        }

        public void SetViewBagUser(int? selectId = null)
        {
            var daopr = new CategoryDao();
            ViewBag.idUser = new SelectList(daopr.DropListUser(), "idUser", "Name", selectId);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new CategoryDao();
            var ct = dao.ViewDetail(id);
            SetViewBagCategory(ct.ParenId);
            SetViewBagUser(ct.idUser);
            ViewBag.listStatus = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Kích Hoạt", Value = "true"},
                    new SelectListItem {Text = "Không Kích Hoạt", Value = "false"},
                };
            return View(ct);
        }

        [HttpPost]
        public ActionResult Edit(Category ct)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
                var result = dao.Update(ct);
                if (result)
                {
                    SetAlert("Cập Nhật Dữ Liệu Thành Công", "success");
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    //return RedirectToAction("Index", "Erro");
                    ModelState.AddModelError("", "Sửa Dữ Liệu Không Thành Công");
                }
            }
            SetViewBagCategory(ct.ParenId);
            SetViewBagUser(ct.idUser);
            ViewBag.listStatus = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Kích Hoạt", Value = "true"},
                    new SelectListItem {Text = "Không Kích Hoạt", Value = "false"},
                };
            return View(ct);
        }

        //[HttpDelete]
        //public ActionResult Delete(int id)
        //{
        //    new CategoryDao().Delete(id);
        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public JsonResult Delete(int id)
        {
            var dao = new CategoryDao();
            if (dao.CheckInUse(id))
            {
                return Json(new { success = false, message = "Không thể lưu thay đổi do dữ liệu đang tồn tại. Vui lòng kiểm tra lại hoặc liên hệ với quản trị viên, số điện thoại 0949234086 !", id = id }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                new CategoryDao().Delete(id);
                return Json(new { success = true, message = "Xóa dữ liệu thành công !", id = id }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Detail(int id)
        {
            var ct = new CategoryDao().ViewDetail(id);
            return View(ct);
        }
    }
}