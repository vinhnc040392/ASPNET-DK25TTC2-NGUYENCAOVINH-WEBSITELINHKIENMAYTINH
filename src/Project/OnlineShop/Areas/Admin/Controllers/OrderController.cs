using Model.Dao;
using Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        // GET: Admin/Order
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new OrderDao();
            var model = dao.ListAll(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult DetailOrder(int id)
        {
            var order = new OrderDao().ViewDetailOrder(id);
            return View(order);
        }

        [HttpPost]
        public JsonResult changeStatus(int idOrder, bool status)
        {
            var dao = new OrderDao();
            //bool stt = (status == 1) ? true : false;
            if (dao.UpdateStatus(idOrder, status))
            {
                return Json(new { message = " Thành Công ", idOrder= idOrder }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { message = " Thất Bại !", idOrder = idOrder }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}