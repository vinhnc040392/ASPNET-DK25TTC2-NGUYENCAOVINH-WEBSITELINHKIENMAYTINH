using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class AboutHomeController : Controller
    {
        // GET: AboutHome
        public ActionResult Index()
        {
            //khoi tao bien
            var aboutDao = new AboutDao();
            ViewBag.ListAbout = aboutDao.ListAboutHome(1);
            return View();
        }
    }
}