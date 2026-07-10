# BÁO CÁO TIẾN ĐỘ ĐỒ ÁN - TUẦN 3
**Môn học:** Đồ án Ngành Công nghệ Thông tin  
**Đề tài:** Xây dựng website bán linh kiện điện tử sử dụng ASP.NET MVC 5 và SQL Server  

---

## 1. Thông tin chung
* **Thời gian thực hiện:** 06/07/2026 - 12/07/2026  
* **Trọng tâm giai đoạn:** Hiện thực hóa code chức năng cốt lõi (Phía Khách hàng)  

## 2. Nội dung công việc
* Cấu hình chuỗi kết nối cơ sở dữ liệu (Connection String) trong tệp tin hệ thống `Web.config` để liên kết ứng dụng với SQL Server.
* Tập trung lập trình xây dựng các chức năng thuộc phân hệ Khách hàng (Client site):
    * Thiết kế màn hình Trang chủ hiển thị danh mục linh kiện (Điện trở, Tụ điện, IC, Vi điều khiển, Cảm biến), sản phẩm mới về.
    * Xây dựng trang Danh sách sản phẩm, tích hợp bộ lọc thông minh theo thương hiệu (Hãng sản xuất) và theo thông số kỹ thuật hoặc loại linh kiện.
    * Xây dựng module Giỏ hàng (Cart module): Thực hiện các logic nghiệp vụ thêm sản phẩm vào giỏ với số lượng lớn, cập nhật số lượng, xóa sản phẩm khỏi giỏ hàng.
    * Xây dựng quy trình Đặt hàng trực tuyến, lưu trữ thông tin giao hàng và chức năng cho phép khách hàng Xem lại lịch sử mua hàng cá nhân.

## 3. Tài liệu liên quan
* Tài liệu kỹ thuật về cơ chế định tuyến dữ liệu ASP.NET Routing.
* Tài liệu hướng dẫn sử dụng các kiểu trả về `ActionResult`, `JsonResult` trong Controller.
* Cơ chế lưu trữ trạng thái phiên làm việc `Session` trong ASP.NET để quản lý thông tin giỏ hàng tạm thời của khách hàng chưa đăng nhập.

## 4. Khó khăn gặp phải
* Gặp khó khăn trong việc xử lý đồng bộ dữ liệu giỏ hàng. Do đặc thù linh kiện thường được mua với số lượng nhiều và nhiều mã hàng cùng lúc, việc trang web phải tải lại (reload) toàn bộ mỗi khi sửa số lượng gây trải nghiệm rất kém.
* Giải pháp khắc phục: Phải tìm hiểu và áp dụng kỹ thuật AJAX kết hợp jQuery để gửi yêu cầu xử lý ngầm, cập nhật lại thành tiền và tổng tiền một cách mượt mà ngay tại giao diện front-end.

## 5. Kết quả đạt được
* Vận hành ổn định luồng mua hàng khép kín (End-to-End): Từ bước tìm kiếm/xem chi tiết linh kiện -> Thêm vào giỏ hàng -> Điền thông tin thanh toán -> Lưu đơn hàng thành công vào cơ sở dữ liệu.
