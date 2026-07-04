using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ContentHomeController : Controller
    {
        // GET: ContentHome
        public ActionResult Index(int page = 1, int pageSize = 12)
        {
            var model = new ContentDao().ListAllHome(page, pageSize);
            int totalRecord = 0;            

            //phan trang
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize)); // lam tron so du len
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.Firts = 1; // tro ve trang dau
            ViewBag.Last = totalPage; //tro ve trang cuoi cung
            ViewBag.Next = page + 1; //tang 1 trang
            ViewBag.Prev = page - 1; //giam 1 trang

            return View(model);
        }


        public ActionResult Detail(int id)
        {
            var model = new ContentDao().ViewDetailHome(id);
            return View(model);
        }
    }
}