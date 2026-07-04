using Model.Dao;
using Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class MenuController : BaseController
    {
        // GET: Admin/Menu
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new MenuDao();
            var model = dao.ListAll(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBagMenuType();
            ViewBag.listStatus = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Kích Hoạt", Value = "true"},
                    new SelectListItem {Text = "Không Kích Hoạt", Value = "false"},
                };
            return View();
        }

        [HttpPost]
        public ActionResult Create(Menu mn)
        {
            if (ModelState.IsValid)
            {
                var dao = new MenuDao();
                int id = dao.Insert(mn);
                if (id > 0)
                {
                    SetAlert("Thêm Dữ Liệu Thành Công", "success");
                    return RedirectToAction("Index", "Menu");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Dữ Liệu Không Thành Công");
                }
            }
            SetViewBagMenuType();
            ViewBag.listStatus = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Kích Hoạt", Value = "true"},
                    new SelectListItem {Text = "Không Kích Hoạt", Value = "false"},
                };
            return View(mn);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new MenuDao();
            var mn = dao.ViewDetail(id);
            SetViewBagMenuType(mn.idMenuType);
            ViewBag.listStatus = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Kích Hoạt", Value = "true"},
                    new SelectListItem {Text = "Không Kích Hoạt", Value = "false"},
                };
            return View(mn);
        }

        [HttpPost]
        public ActionResult Edit(Menu mn)
        {
            if (ModelState.IsValid)
            {
                var dao = new MenuDao();
                var result = dao.Update(mn);
                if (result)
                {
                    SetAlert("Cập Nhật Dữ Liệu Thành Công", "success");
                    return RedirectToAction("Index", "Menu");
                }
                else
                {
                    //return RedirectToAction("Index", "Erro");
                    ModelState.AddModelError("", "Sửa Dữ Liệu Không Thành Công");
                }
            }
            SetViewBagMenuType(mn.idMenuType);
            ViewBag.listStatus = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Kích Hoạt", Value = "true"},
                    new SelectListItem {Text = "Không Kích Hoạt", Value = "false"},
                };
            return View(mn);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new MenuDao().Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            var mn = new MenuDao().ViewDetail(id);
            return View(mn);
        }

        public void SetViewBagMenuType(int? selectId=null)
        {
            var dao = new MenuDao();
            ViewBag.idMenuType = new SelectList(dao.DropListMenuType(), "idMenuType", "Name", selectId);
        }
    }
}