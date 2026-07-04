using Model.Dao;
using Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class SlideController : BaseController
    {
        // GET: Admin/Slide
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new SlideDao();
            var model = dao.ListAll(page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.listStatus = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Kích Hoạt", Value = "true"},
                    new SelectListItem {Text = "Không Kích Hoạt", Value = "false"},
                };
            return View();
        }

        [HttpPost]
        public ActionResult Create(Slide sl)
        {
            if (ModelState.IsValid)
            {
                var dao = new SlideDao();
                sl.CreateDate = DateTime.Now;
                int id = dao.Insert(sl);
                if (id > 0)
                {
                    SetAlert("Thêm Dữ Liệu Thành Công", "success");
                    return RedirectToAction("Index", "Slide");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Dữ Liệu Không Thành Công");
                }
            }
            ViewBag.listStatus = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Kích Hoạt", Value = "true"},
                    new SelectListItem {Text = "Không Kích Hoạt", Value = "false"},
                };
            return View(sl);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var sl = new SlideDao().ViewDetail(id);
            ViewBag.listStatus = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Kích Hoạt", Value = "true"},
                    new SelectListItem {Text = "Không Kích Hoạt", Value = "false"},
                };
            return View(sl);
        }

        [HttpPost]
        public ActionResult Edit(Slide sl)
        {
            if (ModelState.IsValid)
            {
                var dao = new SlideDao();
                var result = dao.Update(sl);
                if (result)
                {
                    SetAlert("Cập Nhật Dữ Liệu Thành Công", "success");
                    return RedirectToAction("Index", "Slide");
                }
                else
                {
                    //return RedirectToAction("Index", "Erro");
                    ModelState.AddModelError("", "Sửa Dữ Liệu Không Thành Công");
                }
            }
            ViewBag.listStatus = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Kích Hoạt", Value = "true"},
                    new SelectListItem {Text = "Không Kích Hoạt", Value = "false"},
                };
            return View(sl);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new SlideDao().Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            var sl = new SlideDao().ViewDetail(id);
            return View(sl);
        }
    }
}