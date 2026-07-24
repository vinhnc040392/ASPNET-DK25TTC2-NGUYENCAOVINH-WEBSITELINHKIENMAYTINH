# BÁO CÁO TIẾN ĐỘ ĐỒ ÁN - TUẦN 4
**Môn học:** Đồ án Ngành Công nghệ Thông tin  
**Đề tài:** Xây dựng website bán linh kiện điện tử sử dụng ASP.NET MVC 5 và SQL Server  

---

## 1. Thông tin chung
* **Thời gian thực hiện:** 13/07/2026 - 19/07/2026  
* **Trọng tâm giai đoạn:** Hiện thực hóa code chức năng quản trị (Phía Admin) và bổ sung tính năng cải tiến  

## 2. Nội dung công việc
* Nhúng và cấu hình đồng bộ mã nguồn giao diện quản trị mẫu Bootstrap SB Admin 2 vào phân hệ Admin của dự án.
* Lập trình chức năng quản lý nghiệp vụ CRUD (Create, Read, Update, Delete) cho các thực thể quan trọng:
    * Quản lý danh mục sản phẩm Linh kiện (gồm việc upload hình ảnh thông số, quản lý số lượng tồn kho theo đơn vị con/chiếc).
    * Quản lý thể loại, hãng sản xuất, nhóm linh kiện.
    * Quản lý đơn hàng (Tiếp nhận đơn, cập nhật trạng thái đơn hàng: Chờ duyệt, Đang đóng gói, Đang giao, Đã giao).
    * Quản lý chuyên mục bài viết hướng dẫn kỹ thuật và tin tức công nghệ.
* Thiết lập phân hệ quản lý tài khoản người dùng, cấu hình giao diện Quản lý vai trò (Roles) và thực hiện phân quyền truy cập.

## 3. Tài liệu liên quan
* Tài liệu Framework bảo mật ASP.NET Identity.
* Cơ chế phân quyền dựa trên vai trò (Role-based Authorization) áp dụng thuộc tính `[Authorize(Roles = "Admin")]` ngăn chặn truy cập trái phép vào các Action.

## 4. Khó khăn khi viết thêm chức năng
* Hệ thống gặp trở ngại lớn khi tiến hành tích hợp một số chức năng nâng cao theo đề xuất cải tiến từ hội đồng:
    * Thiết lập tính năng thông báo nổi (Toast Notification) thời gian thực hiển thị tức thì trên màn hình Admin khi có khách hàng phát sinh đơn hàng linh kiện mới.
    * Gặp khó khăn lớn khi xây dựng logic gợi ý thông minh: Tự động kiểm tra các trường dữ liệu trùng khớp (số điện thoại, email) của khách hàng cũ để hệ thống tự đưa ra gợi ý, hỗ trợ quản trị viên nhanh chóng tạo mới/liên kết profile khách hàng ngay tại trang Admin.
    * Thử nghiệm tích hợp các cấu hình Realtime làm tiêu tốn rất nhiều thời gian nghiên cứu và cấu hình hệ thống.

## 5. Kết quả đạt được
* Hoàn thiện toàn bộ các module màn hình chức năng CRUD của phân hệ Admin, đảm bảo dữ liệu linh kiện cập nhật chính xác xuống SQL Server.
* Tích hợp thành công phần phân quyền cơ bản, chia tách rõ ràng không gian trải nghiệm của Khách hàng và không gian quản lý của Admin.
