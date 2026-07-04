using Model.Dao;
using Model.Data;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ProductDao();
            var model = dao.ListAll(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {

            SetViewBagCategory();
            SetViewBagUser();
            SetViewBagSupplier();
            ViewBag.listStatus = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Kích Hoạt", Value = "true"},
                    new SelectListItem {Text = "Không Kích Hoạt", Value = "false"},
                };
            ViewBag.listAvailable = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Còn Hàng", Value = "true"},
                    new SelectListItem {Text = "Hết Hàng", Value = "false"},
                };
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product pro)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                pro.CreateDate = DateTime.Now;
                int id = dao.Insert(pro);
                if (id > 0)
                {
                    SetAlert("Thêm Dữ Liệu Thành Công", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Dữ Liệu Không Thành Công");
                }
            }
            SetViewBagCategory();
            SetViewBagUser();
            SetViewBagSupplier();
            ViewBag.listStatus = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Kích Hoạt", Value = "true"},
                    new SelectListItem {Text = "Không Kích Hoạt", Value = "false"},
                };
            ViewBag.listAvailable = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Còn Hàng", Value = "true"},
                    new SelectListItem {Text = "Hết Hàng", Value = "false"},
                };
            return View(pro);
        }

        //hien thi droplist
        public void SetViewBagCategory(int? selectId = null)
        {
            var daopr = new ProductDao();
            ViewBag.idCategories = new SelectList(daopr.DropListCategory(), "idCategories", "Name", selectId);
        }

        public void SetViewBagUser(int? selectId = null)
        {
            var daopr = new ProductDao();
            ViewBag.idUser = new SelectList(daopr.DropListUser(), "idUser", "Name", selectId);
        }

        public void SetViewBagSupplier(string selectId = null)
        {
            var dao = new ProductDao();
            ViewBag.idSupplier = new SelectList(dao.DropListSupplier(), "idSupplier", "Name", selectId);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new ProductDao();
            var pr = dao.ViewDetail(id);
            SetViewBagCategory(pr.idCategories);
            SetViewBagUser(pr.idUser);
            SetViewBagSupplier(pr.idSupplier);
            ViewBag.listStatus = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Kích Hoạt", Value = "true"},
                    new SelectListItem {Text = "Không Kích Hoạt", Value = "false"},
                };
            ViewBag.listAvailable = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Còn Hàng", Value = "true"},
                    new SelectListItem {Text = "Hết Hàng", Value = "false"},
                };
            return View(pr);
        }

        [HttpPost]
        public ActionResult Edit(Product pro)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                var result = dao.Update(pro);
                if (result)
                {
                    SetAlert("Cập Nhật Dữ Liệu Thành Công", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    //return RedirectToAction("Index", "Erro");
                    ModelState.AddModelError("", "Sửa Dữ Liệu Không Thành Công");
                }
            }
            SetViewBagCategory(pro.idCategories);
            SetViewBagUser(pro.idUser);
            SetViewBagSupplier(pro.idSupplier);
            ViewBag.listStatus = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Kích Hoạt", Value = "true"},
                    new SelectListItem {Text = "Không Kích Hoạt", Value = "false"},
                };
            ViewBag.listAvailable = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Còn Hàng", Value = "true"},
                    new SelectListItem {Text = "Hết Hàng", Value = "false"},
                };
            return View(pro);
        }

        //[HttpDelete]
        //public ActionResult Delete(int id)
        //{
        //    new ProductDao().Delete(id);
        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public JsonResult Delete(int id)
        {
            var dao = new ProductDao();
            if (dao.CheckInUse(id))
            {
                return Json(new { success = false, message = "Không thể lưu thay đổi do dữ liệu đang tồn tại. Vui lòng kiểm tra lại hoặc liên hệ với quản trị viên, số điện thoại 0949234086 !", id = id }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                new ProductDao().Delete(id);
                return Json(new { success = true, message = "Xóa dữ liệu thành công !", id = id }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Detail(int id)
        {
            var pro = new ProductDao().ViewDetail(id);
            return View(pro);
        }

        OnlineShopDbContext db = new OnlineShopDbContext();
        public void ExportToExcel()
        {
            List<Product> emplist = db.Products.ToList();

            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

            ws.Cells["A1"].Value = "Công ty";
            ws.Cells["B1"].Value = "TNHH Thương Mại ACS Việt Nam";

            ws.Cells["A2"].Value = "Báo Cáo";
            ws.Cells["B2"].Value = " Sản Phẩm";

            ws.Cells["A3"].Value = "Ngày Tạo";
            ws.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);

            ws.Cells["A6"].Value = "Mã Sản Phẩm";
            ws.Cells["B6"].Value = "Tên Sản Phẩm";
            ws.Cells["C6"].Value = "Đơn Giá";
            ws.Cells["D6"].Value = "Giá Khuyến Mãi";
            ws.Cells["E6"].Value = "Số Lượng";

            ws.Cells["F6"].Value = "Thời Hạn Khuyến Mãi";
            ws.Cells["G6"].Value = "Ngày Tạo";
            ws.Cells["H6"].Value = "Tài Khoản Đăng";
            ws.Cells["I6"].Value = "Danh Mục Sản Phẩm";
            ws.Cells["J6"].Value = "Nhà Cung Cấp";

            ws.Cells["K6"].Value = "Lượt Xem";
            ws.Cells["L6"].Value = "Trạng Thái Hàng";
            ws.Cells["M6"].Value = "Trạng Thái";

            int rowStart = 7;
            foreach (var item in emplist)
            {
                //if (item.idSupplier < 5)
                //{
                ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("pink")));

                //}

                ws.Cells[string.Format("A{0}", rowStart)].Value = item.Code;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.Name;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.Price;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.Discount;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.Quantity;

                ws.Cells[string.Format("F{0}", rowStart)].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", item.Special);
                ws.Cells[string.Format("G{0}", rowStart)].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", item.CreateDate);
                ws.Cells[string.Format("H{0}", rowStart)].Value = item.User.Name;
                ws.Cells[string.Format("I{0}", rowStart)].Value = item.Category.Name;
                ws.Cells[string.Format("J{0}", rowStart)].Value = item.Supplier.Name;

                ws.Cells[string.Format("K{0}", rowStart)].Value = item.Views;
                ws.Cells[string.Format("L{0}", rowStart)].Value = (item.Available.GetValueOrDefault(false) ? "Còn Hàng" : "Hết Hàng");
                ws.Cells[string.Format("M{0}", rowStart)].Value = (item.Status.GetValueOrDefault(false) ? "Kích Hoạt" : "Không Kích Hoạt");
                rowStart++;
            }

            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();

        }

        //List<SelectListItem> list = new List<SelectListItem>

        //    {
        //    new SelectListItem {  Text = "text1", Value = "11"},
        //    new SelectListItem { Text = "text2", Value = "12"}
        //    };



    }
}