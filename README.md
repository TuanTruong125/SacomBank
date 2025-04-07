# Hệ Thống Quản Lý Khách Hàng Ngân Hàng SacomBank

## Giới Thiệu
Dự án này là hệ thống quản lý thông tin khách hàng dành cho ngân hàng SacomBank, được phát triển theo mô hình MVC và sử dụng SQL Server làm hệ quản trị cơ sở dữ liệu. Hệ thống hỗ trợ các chức năng chính như quản lý khách hàng, tài khoản, giao dịch, dịch vụ ngân hàng, và hệ thống thông báo.

## Công Nghệ Sử Dụng
- **Ngôn ngữ lập trình**: C# (WinForms)
- **Cơ sở dữ liệu**: SQL Server
- **Mô hình kiến trúc**: MVC
- **Thư viện hỗ trợ**: Entity Framework, ADO.NET

## Chức Năng Chính
### Quản lý
#### 1. Tạo thông báo
- Xem thông báo
- Tạo thông báo hệ thống (Tất cả đều có thể xem).
- Tạo thông báo cho tất cả nhân viên (Nhân viên nội bộ có thể xem).
- Tạo thông báo cho một nhân viên (Nhân viên được chỉ định có thể xem).

#### 2. Quản lý nhân viên
- Thêm, sửa, xóa thông tin nhân viên.
- Tìm kiếm, lọc, xuất dữ liệu nhân viên.

#### 3. Duyệt yêu cầu
- Duyệt hoặc từ chối các yêu cầu về dịch vụ tài chính được tạo bởi nhân viên hoặc khách hàng.
- Tìm kiếm, lọc, xuất dữ liệu dịch vụ yêu cầu.

#### 4. Báo cáo và thống kê
- Xem báo cáo và thống kê về doanh thu, chi trả, lợi nhuận.
- Tìm kiếm, lọc, xuất dữ liệu.

#### 5. Cài đặt
- Xem thông tin tài khoản.
- Thay đổi tên tài khoản và mật khẩu.
- Thay đổi về ngôn ngữ và giao diện.

### Nhân viên
#### 1. Quản lý khách hàng
- Thêm, sửa, xóa thông tin khách hàng.
- Tìm kiếm, lọc, xuất dữ liệu khách hàng.

#### 2. Quản lý tài khoản
- Thêm, sửa, xóa thông tin tài khoản.
- Tìm kiếm, lọc, xuất dữ liệu tài khoản.

#### 3. Quản lý dịch vụ
- Thêm, sửa, xóa thông tin dịch vụ khi chưa duyệt.
- Tìm kiếm, lọc, xuất dữ liệu dịch vụ.
- Tất toán khoản vay, Rút toàn bộ số tiền tiết kiệm khi được yêu cầu.

#### 4. Quản lý giao dịch
- Có thể nạp, rút, chuyển tiền hoặc thanh toán dịch vụ cho khách hàng.
- Tìm kiếm, lọc, xuất dữ liệu giao dịch.

#### 5. Chăm sóc khách hàng
- Có thể chat trực tiếp với khách hàng.
- Khi hoàn thành yêu cầu rồi thì không được chat lại.

#### 6. Cài đặt
- Xem thông tin tài khoản.
- Thay đổi tên tài khoản và mật khẩu.
- Thay đổi về ngôn ngữ và giao diện.

### Khách hàng
#### 1. Trang chủ
- Xem thông tin số tài khoản, số dư.
- Thực hiện chuyển tiền.
- Xem lịch sử giao dịch.
- Thực hiện thanh toán dịch vụ.
- Xem thông tin chi tiết tài khoản thanh toán.
- Quản lý dịch vụ.
- Xem thông báo.
- Chat với nhân viên hỗ trợ hoặc ChatBot.

#### 2. Dịch vụ
- Xem chi tiết dịch vụ.
- Đăng ký dịch vụ.

#### 3. Cá nhân
- Xem thông tin tài khoản.
- Thay đổi tên tài khoản, mật khẩu và mã PIN.
- Thay đổi về ngôn ngữ và giao diện.

## Cài Đặt
### Yêu Cầu Hệ Thống
- **Hệ điều hành**: Windows 10/11
- **Phần mềm cần thiết**:
  - .NET 8 SDK
  - SQL Server
  - SQL Server Management Studio (SSMS)
  - Visual Studio 2022 trở lên

### Hướng Dẫn Cài Đặt
1. **Clone dự án**
   ```sh
   git clone https://github.com/your-repo-url.git
   cd project-folder
   ```
2. **Cấu hình CSDL**
   - Khởi động SQL Server và tạo database theo file `database.sql` trong thư mục `Database`.
   - Kiểm tra chuỗi kết nối trong file `appsettings.json`.

3. **Chạy ứng dụng**
   - Mở dự án bằng Visual Studio
   - Build & Run

## Cấu Trúc Dự Án
```
📁 QuanLyThongTinKhachHangSacomBank
│── 📁 Controllers    # Chứa các controller xử lý logic
│── 📁 Models         # Chứa các model (DTO, Entity)
│── 📁 Views          # Chứa giao diện WinForms
│── 📁 Database       # Chứa script SQL tạo database
│── 📁 Common         # Các hàm tiện ích
│── appsettings.json  # Cấu hình chuỗi kết nối DB
│── Program.cs        # Điểm bắt đầu của ứng dụng
```

## Chức Năng Chính
- **Quản lý khách hàng**: Thêm, sửa, xóa khách hàng, quản lý thông tin cá nhân.
- **Quản lý tài khoản**: Tạo tài khoản, khóa/mở tài khoản, kiểm tra số dư.
- **Giao dịch**: Chuyển tiền, nạp tiền, rút tiền, kiểm tra lịch sử giao dịch.
- **Quản lý dịch vụ**: Tiết kiệm, vay vốn, thanh toán khoản vay.
- **Hệ thống thông báo**: Nhận thông báo giao dịch, thông báo hệ thống.

## Thành Viên Dự Án
- **Project Manager**: [Tên]
- **Business Analyst**: [Tên]
- **Developer**: [Trương Anh Tuấn, Nguyễn Hoàng Nhựt Thiên]
- **UI/UX Designer**: [Trương Anh Tuấn, Nguyễn Hoàng Nhựt Thiên]

## Liên Hệ
Nếu có bất kỳ vấn đề gì, vui lòng liên hệ qua email: [your-email@example.com]
