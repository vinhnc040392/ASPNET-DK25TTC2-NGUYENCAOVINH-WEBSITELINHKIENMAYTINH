using Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class HomeAdminController : BaseController
    {
        // GET: Admin/HomeAdmin
        private OnlineShopDbContext db = new OnlineShopDbContext();
        public ActionResult Index()
        {
            return View();
        }

        //thống kê tất cả có bn sản phẩm
        public int GetAllQuanlityProduct()
        {
            return db.Products.Count();
        }

        //thống kê tất cả có bn sản phẩm
        public int GetAllQuanlityOrder()
        {
            return db.Orders.Count();
        }

        //thống kê tất cả có bn sản phẩm
        public int GetAllQuanlityUser()
        {
            return db.Users.Count();
        }

        //thống kê tất cả có bn sản phẩm
        public int GetAllQuanlityContent()
        {
            return db.Contents.Count();
        }

        //thống kê tất cả có bn sản phẩm
        public int GetAllQuanlityFeedback()
        {
            return db.FeedBacks.Count();
        }

        //thống kê tất cả có bn sản phẩm
        public int GetAllQuanlitySuppliers()
        {
            return db.Suppliers.Count();
        }

        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            return PartialView();
        }
    }
}