using Model.Dao;
using Model.Data;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace OnlineShop.Controllers
{
    public class CartHomeController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: CartHome
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        //tao AddItem gio hang
        public ActionResult AddItem(int productId, int quantity)
        {
            var product = new ProductDao().ViewDetail(productId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.idProduct == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.idProduct == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //tao moi doi tuong cart item
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                //gan vao session
                Session[CartSession] = list;
            }
            else
            {
                //tao moi doi tuong cart item
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //gan vao session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        //tao update quantity gio hang
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.idProduct == item.Product.idProduct);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                Status = true
            });
        }

        //tao delete toan bo gio hang
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                Status = true
            });
        }

        //tao delete tung san pham trong gio hang
        public JsonResult Delete(int id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.idProduct == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                Status = true
            });
        }

        //tao su kien nut thanh toan
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        //tao su kien nut thanh toan
        [HttpPost]
        public ActionResult Payment(string shipname, string shipgmail, string shipmobile, string shipaddress)
        {
            var order = new Order();
            order.CreateDate = DateTime.Now;
            order.ShipName = shipname;
            order.ShipEmai = shipgmail;
            order.ShipMobile = shipmobile;
            order.ShipAdress = shipaddress;
            order.Status = false;

            try
            {
                //tra ve id
                var id = new OrderDao().Insert(order);
                //lay ra thong tin san pham
                var cart = (List<CartItem>)Session[CartSession];
                var detailDao = new OrderDetailDao();
                foreach (var item in cart)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.idProduct = item.Product.idProduct;
                    orderDetail.idOrder = id;
                    orderDetail.Price = item.Product.Price;
                    orderDetail.Quantity = item.Quantity;
                    detailDao.Insert(orderDetail);
                }
            }
            catch (Exception)
            {
                return Redirect("/loi-hoan-thanh");
            }
            return Redirect("/hoan-thanh");
        }

        //su kien hoan thanh don hang
        public ActionResult Success()
        {
            Session[CartSession] = null;
            return View();
        }

        //su kien hoan thanh don hang
        public ActionResult Error()
        {
            return View();
        }
    }
}