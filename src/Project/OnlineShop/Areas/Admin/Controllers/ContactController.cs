using Model.Dao;
using Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ContactController : BaseController
    {
        // GET: Admin/Contact
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ContactDao();
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
        public ActionResult Create(Contact cont)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContactDao();
                int id = dao.Insert(cont);
                if (id > 0)
                {
                    SetAlert("Thêm Dữ Liệu Thành Công", "success");
                    return RedirectToAction("Index", "Contact");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Dữ Liệu Không Thành Công");
                }
            }
            return View(cont);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new ContactDao().ViewDetail(id);
            return View(dao);
        }

        [HttpPost]
        public ActionResult Edit(Contact cont)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContactDao();
                var result = dao.Update(cont);
                if (result)
                {
                    SetAlert("Cập Nhật Dữ Liệu Thành Công", "success");
                    return RedirectToAction("Index", "Contact");
                }
                else
                {
                    //return RedirectToAction("Index", "Erro");
                    ModelState.AddModelError("", "Sửa Dữ Liệu Không Thành Công");
                }
            }
            return View(cont);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ContactDao().Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            var cont = new ContactDao().ViewDetail(id);
            return View(cont);
        }
    }
}