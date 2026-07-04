using Model.Dao;
using Model.Data;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new UserDao();
            var model = dao.ListAll(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBagUserGroup();
            ViewBag.listStatus = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Kích Hoạt", Value = "true"},
                    new SelectListItem {Text = "Không Kích Hoạt", Value = "false"},
                };
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.CheckUserName(user.Username))
                {
                    ModelState.AddModelError("", "Tên đăng nhập của bạn đã tồn tại");
                }
                else
                {
                    //ma hoa MD5
                    var encryptedMd5Pas = EncryptorMaHoaMD5.MD5Hash(user.Password);
                    user.Password = encryptedMd5Pas;
                    user.CreateDate = DateTime.Now;
                    int id = dao.Insert(user);
                    if (id > 0)
                    {
                        SetAlert("Thêm Dữ Liệu Thành Công", "success");
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm Dữ Liệu Không Thành Công");
                    }
                }
            }
            SetViewBagUserGroup();
            ViewBag.listStatus = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Kích Hoạt", Value = "true"},
                    new SelectListItem {Text = "Không Kích Hoạt", Value = "false"},
                };
            return View(user);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            SetViewBagUserGroup(user.idUserGroup);
            ViewBag.listStatus = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Kích Hoạt", Value = "true"},
                    new SelectListItem {Text = "Không Kích Hoạt", Value = "false"},
                };
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                //kiem tra neu pass rong thi k cho update
                //if (!string.IsNullOrEmpty(user.Password))
                //{
                //    var encryptedMd5Pas = EncryptorMaHoaMD5.MD5Hash(user.Password);
                //    user.Password = encryptedMd5Pas;
                //}
                var result = dao.Update(user);
                if (result)
                {
                    SetAlert("Cập Nhật Dữ Liệu Thành Công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    //return RedirectToAction("Index", "Erro");
                    ModelState.AddModelError("", "Sửa Dữ Liệu Không Thành Công");
                }
            }
            SetViewBagUserGroup(user.idUserGroup);
            ViewBag.listStatus = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Kích Hoạt", Value = "true"},
                    new SelectListItem {Text = "Không Kích Hoạt", Value = "false"},
                };
            return View(user);
        }

        [HttpGet]
        public ActionResult EditPass(int id)
        {
            var user = new UserDao().ViewDetail(id);
            user.Password = "";
            SetViewBagUserGroup(user.idUserGroup);
            ViewBag.listStatus = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Kích Hoạt", Value = "true"},
                    new SelectListItem {Text = "Không Kích Hoạt", Value = "false"},
                };
            return View(user);
        }

        [HttpPost]
        public ActionResult EditPass(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                //kiem tra neu pass rong thi k cho update
                if (!string.IsNullOrEmpty(user.Password))
                {
                    var encryptedMd5Pas = EncryptorMaHoaMD5.MD5Hash(user.Password);
                    user.Password = encryptedMd5Pas;
                }
                var result = dao.UpdatePass(user);
                if (result)
                {
                    SetAlert("Mật Khẩu Đổi Thành Công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    //return RedirectToAction("Index", "Erro");
                    ModelState.AddModelError("", "Sửa Mật Khẩu Không Thành Công");
                }
            }
            SetViewBagUserGroup(user.idUserGroup);
            ViewBag.listStatus = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Kích Hoạt", Value = "true"},
                    new SelectListItem {Text = "Không Kích Hoạt", Value = "false"},
                };
            return View(user);
        }

        //[HttpDelete]
        //public ActionResult Delete(int id)
        //{
        //    new UserDao().Delete(id);
        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public JsonResult Delete(int id)
        {
            var dao = new UserDao();
            if (dao.CheckInUse(id))
            {
                return Json(new { success = false, message = "Không thể lưu thay đổi do dữ liệu đang tồn tại. Vui lòng kiểm tra lại hoặc liên hệ với quản trị viên, số điện thoại 0949234086 !", id = id }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                new UserDao().Delete(id);
                return Json(new { success = true, message = "Xóa dữ liệu thành công !", id = id }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Detail(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }

        public void SetViewBagUserGroup(string selectId = null)
        {
            var dao = new UserDao();
            ViewBag.idUserGroup = new SelectList(dao.DropListUserGroup(), "idUserGroup", "Name", selectId);
        }

        //[HttpPost]
        //public JsonResult ChangeStatus(int id)
        //{
        //    var result = new UserDao().ChangeStatus(id);
        //    return Json(new
        //    {
        //        Status = result
        //    });
        //}
    }
}