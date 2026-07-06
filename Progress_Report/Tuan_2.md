# BÁO CÁO TIẾN ĐỘ ĐỒ ÁN - TUẦN 2
**Môn học:** Đồ án Ngành Công nghệ Thông tin  
**Đề tài:** Xây dựng website bán linh kiện điện tử sử dụng ASP.NET MVC 5 và SQL Server  

---

## 1. Thông tin chung
* **Thời gian thực hiện:** 29/06/2026 - 05/07/2026  
* **Trọng tâm giai đoạn:** Phân tích thiết kế hệ thống và Cơ sở dữ liệu  

## 2. Nội dung công việc
* Tiến hành khảo sát thực tế quy trình vận hành, phân loại mã linh kiện và nhu cầu quản lý kinh doanh tại cửa hàng linh kiện điện tử.
* Phân tích và xác định cụ thể các yêu cầu của hệ thống:
    * **Yêu cầu chức năng:** Xác định 14 chức năng chính chia đều cho hai phân hệ chính: Khách hàng (Xem sản phẩm, tìm kiếm theo thông số, giỏ hàng, đặt hàng,...) và Quản trị viên/Admin (Quản lý danh mục linh kiện, tồn kho, đơn hàng, thống kê,...).
    * **Yêu cầu phi chức năng:** Đảm bảo tính bảo mật dữ liệu, hiệu năng phản hồi nhanh khi truy vấn số lượng mã hàng lớn, giao diện tương thích tốt trên di động và máy tính.
* Vẽ sơ đồ Use-case tổng quát mức 0 để định hình các tác nhân và luồng tương tác chính.
* Thiết kế mô hình quan hệ dữ liệu (ERD) trực quan trên hệ quản trị cơ sở dữ liệu SQL Server.

## 3. Tài liệu liên quan
* Tài liệu hướng dẫn phân tích và thiết kế hệ thống phần mềm hướng đối tượng.
* Tài liệu kỹ thuật quản trị và tối ưu hóa SQL Server.
* Đặc tả cấu trúc các bảng xác thực mặc định của ASP.NET Identity (`AspNetUsers`, `AspNetRoles`, `AspNetUserClaims`,...).
* Đặc tả cấu trúc các bảng nghiệp vụ cốt lõi tự định nghĩa: `LinhKien`, `MetaLinhKien`, `Hang`, `TinTuc`, `ChuDe`, `BinhLuan`.

## 4. Khó khăn gặp phải
* Gặp phức tạp khi thiết kế mối quan hệ ràng buộc toàn vẹn khóa chính - khóa ngoại giữa các bảng dữ liệu có liên kết chặt chẽ như `LinhKien`, `MetaLinhKien` (lưu các thuộc tính kỹ thuật chi tiết như điện áp, dòng điện, chân cắm) và `Hang`.
* Nghiên cứu cách kết nối, đồng bộ hóa hệ thống phân quyền có sẵn của thư viện ASP.NET Identity vào mô hình cơ sở dữ liệu nghiệp vụ tự xây dựng sao cho không bị xung đột.

## 5. Kết quả đạt được
* Xây dựng thành công Từ điển dữ liệu chi tiết gồm 14 bảng dữ liệu, định nghĩa đầy đủ kiểu dữ liệu, độ dài và các ràng buộc.
* Thiết kế hoàn chỉnh sơ đồ cơ sở dữ liệu quan hệ (Database Diagram) trên SQL Server sẵn sàng cho giai đoạn code.
