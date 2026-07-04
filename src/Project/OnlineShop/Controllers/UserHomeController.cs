using BotDetect.Web.Mvc;
using Model.Dao;
using Model.Data;
using OnlineShop.Common;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class UserHomeController : Controller
    {
        // GET: UserHome
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [CaptchaValidation("CaptchaCode", "registerCapcha", "Mã xác nhận không đúng!")] //tích hợp chứng thực capcha
        public ActionResult Register(RegisterModel model)
        {
            if(ModelState.IsValid)
            {
                var dao = new UserDao();
                if(dao.CheckUserName(model.Username))
                {
                    ModelState.AddModelError("", "Tên đăng nhập của bạn đã tồn tại");
                }
                else if (dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email của bạn đã tồn tại");
                }
                else
                {
                    var user = new User();
                    user.Username = model.Username;
                    user.Password = EncryptorMaHoaMD5.MD5Hash(model.Password);
                    user.Name = model.Name;
                    user.Address = model.Address;
                    user.Email = model.Email;
                    user.Phone = model.Phone;
                    user.CreateDate = DateTime.Now;
                    user.idUserGroup = "MEMBER";
                    user.Status = true;
                    var result = dao.Insert(user);
                    if(result>0)
                    {
                        ViewBag.Success = "Bạn đã đăng ký thành công!";
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công! Vui lòng thử lại !");
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.Username, EncryptorMaHoaMD5.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dao.GetById(model.Username);
                    var userSession = new OnlineShop.Common.UserLogin();
                    userSession.UserName = user.Username;
                    userSession.UserID = user.idUser;
                    userSession.Name = user.Name;
                    userSession.idUserGroup = user.idUserGroup;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return Redirect("/");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài không tồn tại");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài không đang bị khóa \nVui lòng liên hệ với người quản trị");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập thất bại");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }
    }
}