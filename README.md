Do An Tot Nghiep - He Thong Ban Linh Kien May Tinh & điện tử
Hoc vien: Tran Van Hanh

MSSV: 170125153

Lop: DK25TTC2

1. Công Nghệ Sử Dụng
Visual Studio 2022 (ASP.NET MVC 5)
Entity Framework 6 (Database First)
SQL Server (SQLEXPRESS01 - port 21136)
Bootstrap 4, Owl Carousel, PagedList
2. Yêu Cầu
Windows 10/11
SQL Server (đã cài SQLEXPRESS01, port 21136)
Visual Studio 2022
3. Cách Cài Đặt
Bước 1: Khởi tạo Database
Mở SQL Server Management Studio (SSMS), kết nối:

Server name: localhost,21136
Authentication: Windows Authentication
Chạy file SQL:

D:\tvu-Project\projectlkdt\StoreComputer\StoreComputer_init.sql
(Nhấn F5 hoặc Execute)

File này tự động:

Xóa và tạo lại database StoreComputer
Tạo 7 bảng: LoaiHang, NhaCungCap, HangHoa, TaiKhoan, KhachHang, DatHang, ChiTietDatHang
Insert dữ liệu mẫu (11 loại hàng, 6 nhà cung cấp, 14 sản phẩm, 1 tài khoản)
Tạo 4 Foreign Key constraints
Bước 2: Mở Project
Mở Visual Studio 2022
File → Open → Project/Solution
Chọn file:
D:\tvu-Project\projectlkdt\StoreComputer\StoreComputer\StoreComputer.sln
Bước 3: Build & Run
Nhấn Ctrl + Shift + B để Build
Nhấn F5 để chạy (IIS Express)
4. Tài Khoản Mặc Định
Tài Khoản Admin
Username	Password
admin	admin
Truy cập: http://localhost:xxxxx/Admin
Hoặc đăng nhập từ menu trên header → Đăng nhập
Tài Khoản Khách Hàng (đã có sẵn)
Username	Password	Mật khẩu lưu trong DB (MD5)
hoang123	xxx	202cb962ac59075b964b07152d234b70
5. Chuỗi Kết Nối (Connection String)
File: StoreComputer\StoreComputer\Web.config

<connectionStrings>
  <add name="StoreComputer"
       connectionString="data source=localhost,21136;
                         initial catalog=StoreComputer;
                         integrated security=True;
                         MultipleActiveResultSets=True;
                         App=EntityFramework"
       providerName="System.Data.SqlClient" />

  <add name="StoreComputerEntities1"
       connectionString="metadata=res://*/Models.Model1.csdl|...
                         provider connection string=&quot;data source=localhost,21136;
                         initial catalog=StoreComputer;
                         integrated security=True;
                         MultipleActiveResultSets=True;&quot;"
       providerName="System.Data.EntityClient" />
</connectionStrings>
Lưu ý: Server localhost,21136 = SQL Server SQLEXPRESS01 đang listen trên port 21136. Nếu port khác, đổi lại cho đúng.

6. Cách Thức Hoạt Động
Luồng Dữ Liệu
User Request
    → Route (RouteConfig.cs)
    → Controller (Action)
    → Model (Entity Framework - StoreComputerEntities1)
    → SQL Server (localhost,21136 / StoreComputer)
    → Trả về View (.cshtml)
Entity Model (Database First)
Model: StoreComputerEntities1 (tự động sinh từ EDMX)
Các bảng tương ứng: HangHoa, LoaiHang, NhaCungCap, TaiKhoan, KhachHang, DatHang, ChiTietDatHang
FK relationships được Entity Framework quản lý tự động
Session (đăng nhập)
Session["taiKhoan"] — lưu tên đăng nhập
Session["maKH"] — lưu mã khách hàng
Kiểm tra: if (Session["taiKhoan"] != null) → đã đăng nhập
7. Các Trang Chính
Trang Người Dùng
Trang	URL	Controller	Chức năng
Trang chủ	/Home/TrangChu	HomeController	Hiện slider, sản phẩm nổi bật
Laptop	/Laptop/DanhSachLaptop	LaptopController	Danh sách laptop (phân trang)
Linh kiện	/LinhKien/DanhSachLinhKien	LinhKienController	Danh sách linh kiện (phân trang)
Chi tiết Laptop	/Laptop/ChiTietLaptop/{id}	LaptopController	Xem chi tiết + sản phẩm cùng loại
Chi tiết Linh kiện	/LinhKien/ChiTietLinhKien/{id}	LinhKienController	Xem chi tiết + sản phẩm cùng loại
Tìm kiếm	/Laptop/TimKiemLaptop?search=xxx	LaptopController	Tìm sản phẩm
Giỏ hàng	/ShoppingCart/Index	ShoppingCartController	Xem giỏ hàng
Thanh toán	/ShoppingCart/thanhToan	ShoppingCartController	Đặt hàng
Đăng nhập	/NguoiDung/DangNhap	NguoiDungController	Đăng nhập user
Đăng ký	/NguoiDung/dangKy	NguoiDungController	Tạo tài khoản mới
Trang Admin (cần đăng nhập admin)
Trang	URL	Chức năng
Dashboard	/Admin	Quản lý chung
Hàng hóa	/Admin/HangHoa	Thêm/Sửa/Xóa sản phẩm
Loại hàng	/Admin/DanhSachLoaiHang	Thêm/Sửa/Xóa loại hàng
Nhà cung cấp	/Admin/DanhSachNhaCungCap	Thêm/Sửa/Xóa NCC
Khách hàng	/Admin/DanhSachKhachHang	Xem danh sách KH
Đơn hàng	/Admin/DonHang	Xem/Xử lý đơn hàng
8. Cấu Trúc Thư Mục
StoreComputer/
├── StoreComputer/
│   ├── StoreComputer/
│   │   ├── Controllers/        # Logic xử lý
│   │   ├── Models/            # Entity Framework (EDMX)
│   │   ├── Views/             # Giao diện Razor
│   │   │   ├── Home/         # Trang chủ
│   │   │   ├── Laptop/       # Laptop
│   │   │   ├── LinhKien/    # Linh kiện
│   │   │   ├── Admin/        # Trang quản trị
│   │   │   ├── NguoiDung/    # Đăng nhập/đăng ký
│   │   │   ├── ShoppingCart/  # Giỏ hàng
│   │   │   └── Shared/       # Layout, partial views
│   │   ├── Theme/            # CSS, JS, hình ảnh
│   │   ├── Web.config        # Connection string
│   │   └── bin/              # DLL (runtime config)
│   └── StoreComputer.sln     # Solution file
└── StoreComputer_init.sql     # Script khởi tạo database (CHỈ 1 FILE)
9. Xử Lý Lỗi Thường Gặp
Lỗi kết nối SQL
Nguyên nhân: Server name sai hoặc SQL Server chưa chạy
Kiểm tra: Services → SQL Server (SQLEXPRESS01) → Status = Running
Kiểm tra port: SQL Error Log → tìm dòng listening on ... port XXXXX
Lỗi "The underlying provider failed on Open"
Nguyên nhân: Connection string server name không đúng
Sửa: Đổi ENVY trong Web.config thành localhost,21136 (hoặc port đúng)
Lỗi FK khi chạy SQL
Nguyên nhân: Thứ tự insert không đúng (insert vào bảng con trước)
Sửa: Dùng file StoreComputer_init.sql — đã sắp xếp đúng thứ tự
Lỗi "There is already an object named 'ChiTietDatHang' in the database"
Nguyên nhân: Chạy script SQL nhiều lần — bảng đã tồn tại từ lần chạy trước
Sửa 1 (tự động): Script đã được cập nhật tự động DROP bảng trước khi tạo mới, chạy lại bình thường
Sửa 2 (thủ công): Mở SSMS, kết nối localhost,21136, chạy:
USE [StoreComputer];
GO
DROP TABLE IF EXISTS [dbo].[ChiTietDatHang];
DROP TABLE IF EXISTS [dbo].[DatHang];
DROP TABLE IF EXISTS [dbo].[HangHoa];
DROP TABLE IF EXISTS [dbo].[KhachHang];
DROP TABLE IF EXISTS [dbo].[LoaiHang];
DROP TABLE IF EXISTS [dbo].[NhaCungCap];
DROP TABLE IF EXISTS [dbo].[TaiKhoan];
GO
Sau đó chạy lại StoreComputer_init.sql
Lỗi "Invalid object name 'dbo.HangHoa'"
Nguyên nhân: Chưa chạy script SQL tạo bảng, hoặc chạy bị lỗi (dính lỗi "already exists" phía trên)
Sửa: Chạy lại file StoreComputer_init.sql trong SSMS (đã fix tự động DROP bảng cũ)
Kiểm tra: Sau khi chạy xong, chạy câu lệnh sau trong SSMS để xác nhận bảng đã tồn tại:
USE [StoreComputer];
GO
SELECT name FROM sys.tables;
Kết quả phải có: HangHoa, DatHang, KhachHang, LoaiHang, NhaCungCap, TaiKhoan, ChiTietDatHang
Lỗi "ChiTietDatHang, DatHang, HangHoa, KhachHang, LoaiHang, NhaCungCap, TaiKhoan already exist"
Nguyên nhân: Chạy script SQL nhiều lần mà không DROP bảng trước
Sửa: Xem mục "Lỗi 'There is already an object named...'" phía trên
10. Nâng Cấp / Thay Đổi
Đổi port SQL Server: Sửa cả Web.config và bin/StoreComputer.dll.config
Đổi data mẫu: Sửa StoreComputer_init.sql, phần INSERT
Thêm trường sản phẩm: Thêm trong SQL → Update EDMX trong Visual Studio
