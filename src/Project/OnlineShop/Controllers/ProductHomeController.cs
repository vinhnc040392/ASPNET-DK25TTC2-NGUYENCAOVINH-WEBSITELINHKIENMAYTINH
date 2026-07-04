using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ProductHomeController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var model = new CategoryDao().ListAllHome();
            return PartialView(model);
        }

        //tao metatitle cho link category
        public ActionResult Category(int cateId, int page = 1, int pageSize = 12)
        {
            var category = new CategoryDao().ViewDetail(cateId);
            ViewBag.Category = category;
            int totalRecord = 0;
            var model = new ProductDao().ListByCategoryId(cateId, ref totalRecord, page, pageSize);

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
            var product = new ProductDao().ViewDetailHome(id);
            ViewBag.Category = new CategoryDao().ViewDetailHome(product.idCategories);
            ViewBag.RelatedProducts = new ProductDao().ListRelatedProduct(id);
            return View(product);
        }

        //list ra danh sach search
        public JsonResult ListName(string q)
        {
            var data = new ProductDao().ListName(q);
            return Json(new
            {
                data = data,
                Status = true
            },JsonRequestBehavior.AllowGet);
        }

        //tao list search cho product
        public ActionResult Search(string keyword, int page = 1, int pageSize = 12)
        {
            int totalRecord = 0;
            var model = new ProductDao().Search(keyword, ref totalRecord, page, pageSize);

            //phan trang
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            ViewBag.Keyword = keyword;

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
    }
}