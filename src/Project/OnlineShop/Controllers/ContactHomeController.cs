using Model.Dao;
using Model.Data;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ContactHomeController : Controller
    {
        // GET: ContactHome
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FeedBack(string txtName, string txtMobile, string txtGmail, string txtAddRess, string txtContent)
        {
            var feedback = new FeedBack();
            feedback.Name = txtName;
            feedback.Phone = txtMobile;
            feedback.Email = txtGmail;
            feedback.Address = txtAddRess;
            feedback.Content = txtContent;
            feedback.CreateDate = DateTime.Now;
            feedback.Status = false;
            try
            {
                //tra ve id
                var id = new FeedBackDao().Insert(feedback);
            }
            catch (Exception)
            {
                return Redirect("/loi-hoan-thanh");
            }
            return Redirect("/thanh-cong");

        }

        //su kien hoan thanh don hang
        public ActionResult Success()
        {
            return View();
        }
    }
}