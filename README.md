# Đồ Án Website Bán Linh kiện điện tử - laptop

## 1. Giới thiệu đồ án

**OnlineShopLapTop** là đồ án tốt nghiệp xây dựng website thương mại điện tử chuyên kinh doanh **laptop, máy tính, linh kiện và phụ kiện máy tính**. Website được phát triển bằng **ASP.NET MVC 5** trên nền **.NET Framework 4.8**, sử dụng **Entity Framework 6** để thao tác với cơ sở dữ liệu **SQL Server**, giao diện thiết kế theo hướng responsive với **Bootstrap**.

Hệ thống được chia làm 2 phần rõ rệt:

- **Client (Frontend)** — giao diện khách hàng: xem sản phẩm, danh mục, tin tức, đặt hàng, liên hệ, đăng ký/đăng nhập.
- **Admin (Backend)** — trang quản trị dành cho admin và nhân viên: quản lý sản phẩm, danh mục, đơn hàng, người dùng, nội dung, slider, menu…

### Công nghệ sử dụng

| Thành phần | Công nghệ |
|---|---|
| Ngôn ngữ | C# |
| Framework | ASP.NET MVC 5 (.NET Framework 4.8) |
| ORM | Entity Framework 6 |
| Cơ sở dữ liệu | SQL Server (Express trở lên) |
| Frontend | Bootstrap, jQuery, CKEditor, CKFinder |
| Captcha | BotDetect |
| IDE | Visual Studio |

---

## 2. Các chức năng hiện có

### 2.1. Phía Client (khách hàng)

- **Trang chủ** — hiển thị slide banner, sản phẩm nổi bật, danh mục, video quảng cáo.
- **Danh mục sản phẩm** — phân cấp nhiều cấp (cha/con), lọc theo danh mục.
- **Chi tiết sản phẩm** — mô tả, hình ảnh, giá, khuyến mãi, số lượng tồn, nhà cung cấp.
- **Tìm kiếm sản phẩm** — theo từ khóa.
- **Tin tức** — danh sách + chi tiết bài viết.
- **Giỏ hàng** — thêm/xóa/cập nhật số lượng sản phẩm.
- **Thanh toán** — nhập thông tin giao hàng, đặt đơn.
- **Liên hệ** — gửi phản hồi kèm bản đồ Google Maps.
- **Đăng ký / Đăng nhập / Đăng xuất** — tài khoản khách hàng (nhóm `MEMBER`), có Captcha khi đăng ký.
- **Giới thiệu** — trang thông tin về shop.

### 2.2. Phía Admin (quản trị)

- **Dashboard** — thống kê tổng số sản phẩm, đơn hàng, khách hàng, tin tức, phản hồi, nhà cung cấp.
- **Quản lý sản phẩm** — CRUD, phân trang, tìm kiếm, gán danh mục & nhà cung cấp.
- **Quản lý danh mục** — CRUD, phân cấp nhiều cấp.
- **Quản lý nhà cung cấp** — CRUD.
- **Quản lý đơn hàng** — xem, cập nhật trạng thái, chi tiết đơn.
- **Quản lý người dùng** — CRUD, phân nhóm (ADMIN / MOD / MEMBER), đổi mật khẩu.
- **Quản lý nhóm người dùng** — CRUD.
- **Quản lý tin tức (Content)** — CRUD với trình soạn thảo CKEditor.
- **Quản lý trang giới thiệu (About)** — chỉnh sửa nội dung.
- **Quản lý liên hệ** — xem phản hồi khách hàng.
- **Quản lý Slide/Banner** — CRUD ảnh slide trang chủ.
- **Quản lý Menu / Loại Menu** — cấu hình menu điều hướng.
- **Quản lý Video quảng cáo** — CRUD.
- **Quản lý Footer** — chỉnh sửa footer hiển thị ngoài Client.
- **Phân quyền theo nhóm** — chỉ ADMIN/MOD mới vào được trang admin.

---

## 3. Hướng dẫn cài đặt

### 3.1. Yêu cầu môi trường

| Phần mềm | Yêu cầu |
|---|---|
| Visual Studio | 2022 trở lên (khuyến nghị 2026) |
| .NET Framework | 4.8 |
| SQL Server | 2017 trở lên, hoặc SQL Server Express |
| SQL Server Management Studio (SSMS) | 18.x trở lên |
| IIS Express | đi kèm Visual Studio |

### 3.2. Cài đặt database qua SSMS

**Bước 1**: Mở **SQL Server Management Studio**, kết nối tới SQL Server instance của bạn (ví dụ `localhost\SQLEXPRESS01` hoặc `localhost`).

**Bước 2**: Mở file script `OnlineShopMVC5.sql` ở thư mục gốc dự án bằng SSMS:
> `File` → `Open` → `File...` → chọn `OnlineShopMVC5.sql`

**Bước 3**: Nhấn **F5** (Execute) để chạy toàn bộ script. Script sẽ tự động:
- Tạo database `OnlineShopMVC5`
- Tạo các bảng, indexes, constraints
- Insert dữ liệu mẫu (Categories, Products, Slide…)
- Tạo 2 user đăng nhập (xem mục 4)

**Bước 4**: Kiểm tra database đã tạo:
- Mở rục `Databases` ở Object Explorer, refresh, thấy `OnlineShopMVC5` là OK.

### 3.3. Cấu hình Connection String

Mở file `src/Project/OnlineShop/Web.config`, tìm thẻ `<connectionStrings>`:

```xml
<connectionStrings>
  <add name="OnlineShop"
       connectionString="data source=localhost\SQLEXPRESS01;initial catalog=OnlineShopMVC5;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

Sửa lại phần `data source=` cho khớp với instance SQL Server của bạn:
- SQL Server Express tên `SQLEXPRESS01` → `data source=localhost\SQLEXPRESS01`
- SQL Server Express mặc định → `data source=localhost\SQLEXPRESS`
- SQL Server bản đầy đủ → `data source=localhost` hoặc `data source=.`

### 3.4. Chạy project bằng Visual Studio

**Bước 1**: Mở file `src/Project/Project.sln` bằng Visual Studio.

**Bước 2**: Visual Studio sẽ tự động restore NuGet packages. Nếu lỗi, click chuột phải vào **Solution** → **Restore NuGet Packages**.

**Bước 3**: Chọn project `OnlineShop` làm Startup Project (click chuột phải → `Set as StartUp Project`).

**Bước 4**: Nhấn **F5** (hoặc click nút ▶ Start) để chạy. Trình duyệt sẽ tự mở trang chủ Client tại `http://localhost:xxxx/`.

**Bước 5**: Đăng nhập admin (xem mục 5).

---

## 4. Tài khoản đăng nhập

Sau khi chạy script SQL, hệ thống có sẵn 2 tài khoản:

| Vai trò | Username (tên đăng nhập) | Mật khẩu | Nhóm |
|---|---|---|---|
| **Quản trị viên** | `admin@gmail.com` | `admin123` | `ADMIN` |
| **Nhân viên** | `user1@gmail.com` | `user123` | `MOD` |

> Lưu ý: Tên đăng nhập là cột `Username` trong bảng `User` (không phải cột `Email` mặc dù giá trị giống nhau).

### Cách tạo thêm tài khoản khách hàng (MEMBER)

- Vào trang Client → click **Đăng ký** ở góc phải header.
- Điền form + Captcha → bấm đăng ký → tài khoản nhóm `MEMBER` được tạo.
- Hoặc vào trang admin `/Admin/User/Create` để tạo thủ công.

---

## 5. Link đăng nhập quan trọng

| Chức năng | URL |
|---|---|
| Trang chủ Client | `http://localhost:xxxx/` |
| Đăng nhập Client (khách hàng) | `http://localhost:xxxx/dang-nhap` |
| Đăng ký Client | `http://localhost:xxxx/dang-ky` |
| **Đăng nhập Admin** | **`http://localhost:xxxx/Admin/Login`** |
| Dashboard Admin | `http://localhost:xxxx/Admin/HomeAdmin/Index` |
| Quản lý sản phẩm | `http://localhost:xxxx/Admin/Product/Index` |
| Quản lý danh mục | `http://localhost:xxxx/Admin/Category/Index` |
| Quản lý đơn hàng | `http://localhost:xxxx/Admin/Order/Index` |
| Quản lý người dùng | `http://localhost:xxxx/Admin/User/Index` |
| Quản lý tin tức | `http://localhost:xxxx/Admin/Content/Index` |
| Quản lý slide | `http://localhost:xxxx/Admin/Slide/Index` |
| Quản lý menu | `http://localhost:xxxx/Admin/Menu/Index` |
| Quản lý nhà cung cấp | `http://localhost:xxxx/Admin/Supplier/Index` |
| Quản lý phản hồi | `http://localhost:xxxx/Admin/FeedBack/Index` |
| Quản lý giới thiệu | `http://localhost:xxxx/Admin/About/Index` |
| Quản lý footer | `http://localhost:xxxx/Admin/Contact/Index` |
| Đăng xuất Admin | `http://localhost:xxxx/Admin/Login/Logout` |

> `xxxx` là số port do Visual Studio tự chọn khi chạy (ví dụ `51234`, `44300`...). Xem port ở URL khi F5, hoặc trong file `OnlineShop.csproj.user`.

---

## 6. Các link quan trọng của đồ án

| Link | Mô tả |
|---|---|
| `/` | Trang chủ Client |
| `/san-pham/{metatitle}-{cateId}` | Danh sách sản phẩm theo danh mục |
| `/chi-tiet/{metatitle}-{id}` | Chi tiết sản phẩm |
| `/tim-kiem` | Tìm kiếm sản phẩm |
| `/gioi-thieu` | Trang giới thiệu |
| `/lien-he` | Trang liên hệ (có bản đồ Google Maps + form phản hồi) |
| `/tin-tuc` | Danh sách tin tức |
| `/tin-tuc/{metatitle}-{id}` | Chi tiết bài viết |
| `/them-gio-hang` | API thêm sản phẩm vào giỏ |
| `/gio-hang` | Trang giỏ hàng |
| `/thanh-toan` | Trang thanh toán |
| `/hoan-thanh` | Trang thanh toán thành công |
| `/loi-hoan-thanh` | Trang thanh toán lỗi |
| `/thanh-cong` | Trang gửi liên hệ thành công |
| `/dang-ky` | Đăng ký tài khoản khách hàng |
| `/dang-nhap` | Đăng nhập khách hàng |
| `/Admin/Login` | **Đăng nhập vào trang quản trị** |

---

## 7. Bảng Route (Route Map)

### 7.1. Client Routes

| URL Pattern | Controller | Action | Ghi chú |
|---|---|---|---|
| `/san-pham/{metatitle}-{cateId}` | `ProductHome` | `Category` | Xem sản phẩm theo danh mục |
| `/chi-tiet/{metatitle}-{id}` | `ProductHome` | `Detail` | Chi tiết sản phẩm |
| `/gioi-thieu` | `AboutHome` | `Index` | Trang giới thiệu |
| `/lien-he` | `ContactHome` | `Index` | Liên hệ |
| `/them-gio-hang` | `CartHome` | `AddItem` | Thêm vào giỏ (POST/GET) |
| `/gio-hang` | `CartHome` | `Index` | Xem giỏ hàng |
| `/thanh-toan` | `CartHome` | `Payment` | Thanh toán |
| `/hoan-thanh` | `CartHome` | `Success` | Thanh toán thành công |
| `/loi-hoan-thanh` | `CartHome` | `Error` | Thanh toán lỗi |
| `/thanh-cong` | `ContactHome` | `Success` | Gửi liên hệ thành công |
| `/dang-ky` | `UserHome` | `Register` | Đăng ký |
| `/dang-nhap` | `UserHome` | `Login` | Đăng nhập client |
| `/tim-kiem` | `ProductHome` | `Search` | Tìm kiếm |
| `/tin-tuc` | `ContentHome` | `Index` | Danh sách tin tức |
| `/tin-tuc/{metatitle}-{id}` | `ContentHome` | `Detail` | Chi tiết tin tức |
| `{controller}/{action}/{id}` (default) | `Home` | `Index` | Route mặc định |

### 7.2. Admin Routes (`/Admin/...`)

| URL Pattern | Controller | Chức năng |
|---|---|---|
| `/Admin/Login` | `Login` | Trang đăng nhập admin |
| `/Admin/HomeAdmin/Index` | `HomeAdmin` | Dashboard + thống kê |
| `/Admin/About` | `About` | Quản lý trang giới thiệu |
| `/Admin/Category` | `Category` | Quản lý danh mục sản phẩm |
| `/Admin/Contact` | `Contact` | Quản lý footer + liên hệ |
| `/Admin/Content` | `Content` | Quản lý tin tức |
| `/Admin/FeedBack` | `FeedBack` | Quản lý phản hồi |
| `/Admin/Menu` | `Menu` | Quản lý menu |
| `/Admin/MenuType` | `MenuType` | Quản lý loại menu |
| `/Admin/Order` | `Order` | Quản lý đơn hàng |
| `/Admin/Product` | `Product` | Quản lý sản phẩm |
| `/Admin/Slide` | `Slide` | Quản lý slide banner |
| `/Admin/Supplier` | `Supplier` | Quản lý nhà cung cấp |
| `/Admin/User` | `User` | Quản lý người dùng |
| `/Admin/UserGroup` | `UserGroup` | Quản lý nhóm người dùng |

---

## 8. Các lỗi thường gặp và cách sửa

### Lỗi 1: Không kết nối được SQL Server

**Triệu chứng:**
```
A network-related or instance-specific error occurred while establishing a connection to SQL Server.
(provider: Named Pipes Provider, error: 40 - Could not open a connection to SQL Server)
```

**Nguyên nhân:** Connection string sai tên instance, hoặc SQL Server chưa bật, hoặc chưa cài SQL Server.

**Cách sửa:**

1. Mở **SQL Server Configuration Manager** → **SQL Server Services** xem có dòng `SQL Server (...)` nào đang chạy không. Tên trong ngoặc chính là instance name.
2. Sửa `Web.config`:
   ```xml
   <!-- ĐÚNG -->
   <add name="OnlineShop" connectionString="data source=localhost\SQLEXPRESS01;initial catalog=OnlineShopMVC5;..." />
   ```
3. **Lỗi phổ biến:** quên `data source=` ở đầu, hoặc thừa dấu `.` sau tên instance.

### Lỗi 2: Keyword not supported khi login

**Triệu chứng:**
```
System.ArgumentException: Keyword not supported: 'localhost\sqlexpress01.;initial catalog'.
```

**Nguyên nhân:** Connection string sai cú pháp.

**Cách sửa:** Luôn bắt đầu bằng `data source=`, theo sau là instance name, rồi dấu `;`. Ví dụ đúng:
```xml
data source=localhost\SQLEXPRESS01;initial catalog=OnlineShopMVC5;integrated security=True;...
```

### Lỗi 3: View không tìm thấy

**Triệu chứng:**
```
The view 'Index' or its master was not found or no view engine supports the searched locations.
~/Views/HomeAdmin/Index.cshtml
```

**Nguyên nhân:** Route mặc định trỏ tới controller `HomeAdmin` (thuộc Admin area), nhưng MVC tìm view ở `~/Views/` thay vì `~/Areas/Admin/Views/`.

**Cách sửa:** Mở `src/Project/OnlineShop/App_Start/RouteConfig.cs`, đổi route mặc định:
```csharp
routes.MapRoute(
    name: "Default",
    url: "{controller}/{action}/{id}",
    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
    namespaces: new[] { "OnlineShop.Controllers" }
);
```
- Đổi `HomeAdmin` → `Home`
- Sửa typo `OnlineShop.controller` → `OnlineShop.Controllers` (chữ C hoa, có s)

### Lỗi 4: Login admin ở Client không vào được trang quản trị

**Triệu chứng:** Sau khi login ở `/dang-nhap` bằng tài khoản admin, vào `/Admin/HomeAdmin/Index` thì bị redirect về trang login hoặc mất quyền.

**Nguyên nhân:** Login Client không lưu `idUserGroup` vào session, nên Admin không nhận diện được role.

**Cách sửa (đã có sẵn trong source):** Mở `src/Project/OnlineShop/Controllers/UserHomeController.cs`, trong hàm `Login`, thêm dòng `userSession.idUserGroup = user.idUserGroup;` trước khi `Session.Add`.

**Cách đơn giản nhất:** Vào thẳng `/Admin/Login` để đăng nhập, không cần qua Client.

### Lỗi 5: Lỗi khi build - Missing references

**Triệu chứng:** Build báo lỗi thiếu DLL như `EntityFramework`, `BotDetect`, `CKFinder`...

**Cách sửa:**
1. Click chuột phải vào Solution → **Restore NuGet Packages**.
2. Nếu vẫn lỗi, mở `Tools` → **NuGet Package Manager** → **Package Manager Console** → chạy:
   ```
   Update-Package -reinstall
   ```
3. Kiểm tra lại file `packages.config` đã có các package cần thiết.

### Lỗi 6: BotDetect Captcha không hiển thị / báo lỗi license

**Triệu chứng:** Trang đăng ký hiển thị captcha lỗi hoặc không render.

**Cách sửa:**
1. BotDetect cần license key trong `Web.config`:
   ```xml
   <botDetect helpLinkEnabled="true" helpLinkMode="image" />
   ```
2. Nếu BotDetect trial đã hết hạn, tải trial mới từ [captcha.com](https://captcha.com/) và thay DLL trong thư mục `packagesdll/`.

### Lỗi 7: Lỗi 404 khi truy cập link thân thiện (Friendly URL)

**Triệu chứng:** Click vào sản phẩm báo 404.

**Cách sửa:** Đảm bảo IIS Express đã bật routing. Trong `Web.config`:
```xml
<system.webServer>
  <modules runAllManagedModulesForAllRequests="true">...</modules>
</system.webServer>
```
Nhấn F5 để chạy lại từ Visual Studio (IIS Express sẽ tự config).

### Lỗi 8: Trang admin không load CSS/JS

**Triệu chứng:** Layout admin hiển thị không có style, hình ảnh broken.

**Cách sửa:** Kiểm tra đường dẫn `/Areas/Admin/images/` và `/Assets/Admin/` còn nguyên vẹn trong project. Nếu build bị exclude, kiểm tra trong file `.csproj` có include các folder đó chưa (right-click folder → `Include in Project`).

### Lỗi 9: Không attach được file upload (CKFinder)

**Triệu chứng:** Upload ảnh trong CKEditor báo lỗi permission.

**Cách sửa:** Cấp quyền write cho IIS_IUSRS trên các folder:
- `/Areas/Admin/images/images/products/`
- `/Assets/Client/images/`

Click chuột phải folder → `Properties` → `Security` → `Edit` → `Add` → gõ `IIS_IUSRS` → OK.

### Lỗi 10: Compile error "Cannot find type or namespace"

**Triệu chứng:** Lỗi biên dịch liên quan đến `Model`, `BotDetect`, `CKEditor`...

**Cách sửa:**
1. Đảm bảo project `Model` đã được build thành công (build project `Model` trước).
2. Right-click project `OnlineShop` → `Add Reference` → đánh dấu project `Model`.
3. Rebuild solution.

---

## 9. Cấu trúc thư mục

```
OnlineShopLapTop/
├── OnlineShopMVC5.sql          ← Script tạo database (chạy trong SSMS)
├── README.md                   ← File này
├── Progress_Report/            ← Báo cáo tiến độ
├── thesis/                     ← Báo cáo đồ án / slide
└── src/
    └── Project/
        ├── OnlineShop.sln      ← Solution Visual Studio
        ├── Model/              ← Entity classes, DbContext, DAO
        │   ├── Data/           ← Entity Framework entities
        │   ├── Dao/            ← Data Access Objects
        │   ├── Common/         ← Hằng số dùng chung
        │   └── ViewModel/      ← ViewModels cho MVC
        ├── OnlineShop/         ← Project MVC chính
        │   ├── Controllers/    ← Client controllers
        │   ├── Views/          ← Client views
        │   ├── Areas/Admin/    ← Admin area (controllers + views)
        │   ├── Models/         ← ViewModels + InputModels
        │   ├── Common/         ← Helper classes (MD5, Constants...)
              ├── Content/        ← CSS, JS, images
        │   └── Web.config      ← Cấu hình chính
        └── packagesdll/        ← DLL bổ sung (BotDetect, CKFinder)
```

---

## 10. Thông tin tác giả

Đồ án được phát triển bởi sinh viên Trường Đại học Trà Vinh (TVU).

---

## 11. License

Đồ án này được phát triển cho mục đích học tập.