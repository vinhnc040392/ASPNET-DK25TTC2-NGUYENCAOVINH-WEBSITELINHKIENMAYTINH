using Model.Dao;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, EncryptorMaHoaMD5.MD5Hash(model.Password),true);
                if (result == 1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new OnlineShop.Common.UserLogin();
                    userSession.UserName = user.Username;
                    userSession.UserID = user.idUser;
                    userSession.Name = user.Name;
                    userSession.idUserGroup = user.idUserGroup;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "HomeAdmin");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài không tồn tại");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài không đang bị khóa \nVui lòng liên hệ với quản trị viên");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else if (result == -3)
                {
                    ModelState.AddModelError("", "Tài khoản của bạn không có quyền đăng nhập \nVui lòng liên hệ với quản trị viên");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập thất bại");
                }
            }
            return View("Index");
        }

        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return RedirectToAction("Index","Login");
        }
    }
}