CREATE DATABASE QuanLyThongTinKhachHangSacomBank
GO
USE QuanLyThongTinKhachHangSacomBank
GO

USE master;
GO
ALTER DATABASE QuanLyThongTinKhachHangSacomBank
SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO
DROP DATABASE QuanLyThongTinKhachHangSacomBank;
GO

-- BẢNG LOẠI KHÁCH HÀNG
CREATE TABLE CUSTOMER_TYPE (
  CustomerTypeID INT IDENTITY(1,1) PRIMARY KEY,
  CustomerTypeCode AS ('LKH' + CAST(CustomerTypeID AS NVARCHAR(10))) PERSISTED,
  CustomerTypeName NVARCHAR(100) NOT NULL,
  CustomerTypeDescription NVARCHAR(255) NOT NULL
);

-- BẢNG KHÁCH HÀNG
CREATE TABLE CUSTOMER (
  CustomerID INT IDENTITY(1,1) PRIMARY KEY,
  CustomerCode AS ('KH' + CAST(CustomerID AS NVARCHAR(10))) PERSISTED,
  FullName NVARCHAR(255) NOT NULL,
  Gender NVARCHAR(10) NOT NULL CHECK (Gender IN (N'Nam', N'Nữ')),
  DateOfBirth DATE NOT NULL,
  Nationality NVARCHAR(100) NOT NULL,
  CitizenID VARCHAR(20) NOT NULL UNIQUE,
  CustomerAddress NVARCHAR(255) NOT NULL,
  Phone VARCHAR(15) NOT NULL UNIQUE,
  Email VARCHAR(100) NOT NULL UNIQUE CHECK (Email LIKE '%_@__%.__%'),
  RegistrationDate DATETIME NOT NULL,
  CustomerTypeID INT NOT NULL,
  FOREIGN KEY (CustomerTypeID) REFERENCES CUSTOMER_TYPE(CustomerTypeID)
);

-- BẢNG LOẠI TÀI KHOẢN
CREATE TABLE ACCOUNT_TYPE (
  AccountTypeID INT IDENTITY(1,1) PRIMARY KEY,
  AccountTypeCode AS ('LTK' + CAST(AccountTypeID AS NVARCHAR(10))) PERSISTED,
  AccountTypeName NVARCHAR(50) NOT NULL,
  AccountTypeDescription NVARCHAR(255) NOT NULL
);

-- BẢNG TÀI KHOẢN
CREATE TABLE ACCOUNT (
  AccountID INT IDENTITY(1,1) PRIMARY KEY,
  AccountCode AS ('TK' + CAST(AccountID AS NVARCHAR(10))) PERSISTED,
  AccountName NVARCHAR(50) NOT NULL, 
  Balance DECIMAL(18,0) NOT NULL,          
  AccountOpenDate DATETIME NOT NULL,           
  Username NVARCHAR(50) NOT NULL UNIQUE,          
  UserPassword NVARCHAR(256) NOT NULL,         
  PINCode NVARCHAR(6) NOT NULL CHECK (PINCode LIKE '[0-9][0-9][0-9][0-9][0-9][0-9]'),           
  AccountStatus NVARCHAR(20) NOT NULL CHECK (AccountStatus IN (N'Hoạt động', N'Khóa', N'Đóng')),            
  CustomerID INT NOT NULL,               
  AccountTypeID INT NOT NULL,            
  FOREIGN KEY (CustomerID) REFERENCES CUSTOMER(CustomerID),
  FOREIGN KEY (AccountTypeID) REFERENCES ACCOUNT_TYPE(AccountTypeID)
);

-- BẢNG LOẠI GIAO DỊCH
CREATE TABLE TRANSACTION_TYPE (
  TransactionTypeID INT IDENTITY(1,1) PRIMARY KEY,
  TransactionTypeCode AS ('LGD' + CAST(TransactionTypeID AS NVARCHAR(10))) PERSISTED,
  TransactionTypeName NVARCHAR(100) NOT NULL,
  TransactionTypeDescription NVARCHAR(255) NOT NULL
);

-- BẢNG GIAO DỊCH
CREATE TABLE [TRANSACTION] (
  TransactionID INT IDENTITY(1,1) PRIMARY KEY,
  TransactionCode AS ('GD' + CAST(TransactionID AS NVARCHAR(10))) PERSISTED,
  Amount DECIMAL(18,0) NOT NULL CHECK (Amount >= 0),
  TransactionDate DATETIME NOT NULL,
  ReceiverAccountID INT NULL,
  ReceiverAccountName NVARCHAR(50) NULL,
  TransactionStatus NVARCHAR(20) NOT NULL CHECK (TransactionStatus IN (N'Hoàn tất', N'Đang xử lý', N'Thất bại')),
  HandledBy INT NULL, -- Có thể NULL nếu giao dịch tự động
  TransactionDescription NVARCHAR(255) NULL,
  TransactionMethod NVARCHAR(50) NOT NULL CHECK (TransactionMethod IN (N'Trực tuyến', N'Tại quầy')),
  AccountID INT NOT NULL,
  TransactionTypeID INT NOT NULL,
  FOREIGN KEY (AccountID) REFERENCES ACCOUNT(AccountID),
  FOREIGN KEY (ReceiverAccountID) REFERENCES ACCOUNT(AccountID),
  FOREIGN KEY (TransactionTypeID) REFERENCES TRANSACTION_TYPE(TransactionTypeID),
  FOREIGN KEY (HandledBy) REFERENCES EMPLOYEE(EmployeeID)
);

-- BẢNG YÊU CẦU (REQUEST)
CREATE TABLE REQUEST (
  RequestID INT IDENTITY(1,1) PRIMARY KEY,
  RequestCode AS ('YC' + CAST(RequestID AS NVARCHAR(10))) PERSISTED,
  Title NVARCHAR(100) NOT NULL,
  RequestMessage NVARCHAR(1000) NOT NULL,
  RequestDate DATETIME NOT NULL,
  HandledBy INT NULL,
  RequestStatus NVARCHAR(20) NOT NULL CHECK (RequestStatus IN (N'Chờ xử lý', N'Đang xử lý', N'Đã xử lý', N'Từ chối xử lý')), 
  CustomerID INT NOT NULL,
  FOREIGN KEY (CustomerID) REFERENCES CUSTOMER(CustomerID),
  FOREIGN KEY (HandledBy) REFERENCES EMPLOYEE(EmployeeID)
);

-- BẢNG LOẠI DỊCH VỤ
CREATE TABLE SERVICE_TYPE (
  ServiceTypeID INT IDENTITY(1,1) PRIMARY KEY,
  ServiceTypeCode AS ('LDV' + CAST(ServiceTypeID AS NVARCHAR(10))) PERSISTED,
  ServiceTypeName NVARCHAR(100) NOT NULL,
  ServiceTypeDescription NVARCHAR(255) NOT NULL
);

-- BẢNG DỊCH VỤ
CREATE TABLE [SERVICE] (
  ServiceID INT IDENTITY(1,1) PRIMARY KEY,
  ServiceCode AS ('DV' + CAST(ServiceID AS NVARCHAR(10))) PERSISTED,

  TotalPrincipalAmount DECIMAL(18,0) NOT NULL CHECK (TotalPrincipalAmount >= 0),
  Duration NVARCHAR(10) NOT NULL,
  InterestRate DECIMAL(5,2) NOT NULL CHECK (InterestRate >= 0),
  TotalInterestAmount DECIMAL(18,0) NULL CHECK (TotalInterestAmount >= 0),
  ServiceDescription NVARCHAR(255) NULL,
  CreatedDate DATETIME NOT NULL,
  ApplicableDate DATETIME NULL,
  EndDate DATETIME NULL,
  ApprovalStatus NVARCHAR(20) NOT NULL CHECK (ApprovalStatus IN (N'Chờ duyệt', N'Đã duyệt', N'Từ chối')),
  ServiceStatus NVARCHAR(20) NOT NULL CHECK (ServiceStatus IN (N'Chờ hoạt động', N'Đang hoạt động', N'Đã tất toán', N'Hủy', N'Trễ hạn thanh toán')),

  HandledBy INT NULL,
  CustomerID INT NOT NULL,
  AccountID INT NOT NULL,
  ServiceTypeID INT NOT NULL,

  FOREIGN KEY (HandledBy) REFERENCES EMPLOYEE(EmployeeID),
  FOREIGN KEY (CustomerID) REFERENCES CUSTOMER(CustomerID),
  FOREIGN KEY (AccountID) REFERENCES ACCOUNT(AccountID),
  FOREIGN KEY (ServiceTypeID) REFERENCES SERVICE_TYPE(ServiceTypeID)
);

-- BẢNG THAHH TOÁN KHOẢN VAY
CREATE TABLE LOAN_PAYMENT (
    PayLoanID INT IDENTITY(1,1) PRIMARY KEY,
    PayLoanCode AS ('TTV' + CAST(PayLoanID AS NVARCHAR(10))) PERSISTED, -- Mã tự động phát sinh
    PrincipalDue DECIMAL(18,0) NOT NULL CHECK (PrincipalDue >= 0), -- Số tiền gốc phải trả
    InterestDue DECIMAL(18,0) NOT NULL CHECK (InterestDue >= 0), -- Số tiền lãi phải trả
	LateFee DECIMAL(18,0) NOT NULL DEFAULT 0 CHECK (LateFee >= 0), -- Phí trễ hạn
    TotalDue DECIMAL(18,0) NOT NULL CHECK (TotalDue >= 0), -- Tổng số tiền phải trả (gốc + lãi + phí trễ hạn nếu có)
    RemainingDebt DECIMAL(18,0) NOT NULL CHECK (RemainingDebt >= 0), -- Số nợ còn lại
    PayNotification NVARCHAR(100) NOT NULL, -- Thông báo thanh toán
	DueDate DATETIME NOT NULL, -- Ngày đến hạn thanh toán
	PaymentStatus NVARCHAR(20) NOT NULL CHECK (PaymentStatus IN (N'Chưa thanh toán', N'Đã thanh toán', N'Trễ hạn')), -- Trạng thái thanh toán
    ServiceID INT NOT NULL,
    FOREIGN KEY (ServiceID) REFERENCES SERVICE(ServiceID)
);

-- BẢNG DOANH THU
CREATE TABLE REVENUE (
    RevenueID INT IDENTITY(1,1) PRIMARY KEY,
    RevenueCode AS ('DT' + CAST(RevenueID AS NVARCHAR(10))) PERSISTED, -- Mã tự động phát sinh
    PrincipalAmount DECIMAL(18,0) NOT NULL CHECK (PrincipalAmount >= 0), -- Số tiền gốc thu được
    InterestAmount DECIMAL(18,0) NOT NULL CHECK (InterestAmount >= 0), -- Số tiền lãi thu được
    LateFee DECIMAL(18,0) NOT NULL CHECK (LateFee >= 0), -- Phí trễ hạn thu được
    TotalAmount DECIMAL(18,0) NOT NULL CHECK (TotalAmount >= 0), -- Tổng số tiền thu được
	RevenueDate DATETIME NOT NULL, -- Ngày ghi nhận doanh thu
    PayLoanID INT NULL, -- Liên kết với khoản thanh toán vay
    ProfitID INT NULL, -- Liên kết với bảng PROFIT
    FOREIGN KEY (PayLoanID) REFERENCES LOAN_PAYMENT(PayLoanID),
    FOREIGN KEY (ProfitID) REFERENCES PROFIT(ProfitID)
);

-- BẢNG LỢI NHUẬN
CREATE TABLE PROFIT (
    ProfitID INT IDENTITY(1,1) PRIMARY KEY,
    ProfitCode AS ('LN' + CAST(ProfitID AS NVARCHAR(10))) PERSISTED, -- Mã tự động phát sinh    
    TotalRevenue DECIMAL(18,0) NOT NULL CHECK (TotalRevenue >= 0), -- Tổng doanh thu
    TotalExpense DECIMAL(18,0) NOT NULL CHECK (TotalExpense >= 0), -- Tổng chi phí
	NetProfit DECIMAL(18,0) NOT NULL, -- Lợi nhuận ròng
    ProfitDate DATE NOT NULL -- Ngày ghi nhận lợi nhuận
);

-- BẢNG TRẢ LÃI TIẾT KIỆM
CREATE TABLE SAVINGS_PAYMENT (
    PaySavingsID INT IDENTITY(1,1) PRIMARY KEY,
    PaySavingsCode AS ('TTTK' + CAST(PaySavingsID AS NVARCHAR(10))) PERSISTED, -- Mã tự sinh    
    MonthlyInterestAmount DECIMAL(18,0) NOT NULL CHECK (MonthlyInterestAmount >= 0), -- Lãi hàng tháng
	TotalInterestPaid DECIMAL(18,0) NOT NULL CHECK (TotalInterestPaid >= 0), -- Tổng lãi đã trả
    LastInterestPaidDate DATETIME NOT NULL, -- Ngày trả lãi gần nhất	
    ServiceID INT NOT NULL,
    FOREIGN KEY (ServiceID) REFERENCES SERVICE(ServiceID)
);

-- BẢNG CHI PHÍ
CREATE TABLE EXPENSE (
    ExpenseID INT IDENTITY(1,1) PRIMARY KEY,
    ExpenseCode AS ('CP' + CAST(ExpenseID AS NVARCHAR(10))) PERSISTED, -- Mã tự sinh    
    InterestPaid DECIMAL(18,0) NULL CHECK (InterestPaid >= 0),
    EmployeeSalary DECIMAL(18,0) NULL CHECK (EmployeeSalary >= 0),
    SystemMaintenanceFee DECIMAL(18,0) NULL CHECK (SystemMaintenanceFee >= 0),
	ExpenseDate DATETIME NOT NULL, -- Ngày chi
    PaySavingsID INT NULL, -- Liên kết với bảng trả lãi tiết kiệm
    ProfitID INT NULL, -- Liên kết với bảng PROFIT
    FOREIGN KEY (PaySavingsID) REFERENCES SAVINGS_PAYMENT(PaySavingsID),
    FOREIGN KEY (ProfitID) REFERENCES PROFIT(ProfitID)
);

-- BẢNG LOẠI THÔNG BÁO
CREATE TABLE NOTIFICATION_TYPE (
  NotificationTypeID INT IDENTITY(1,1) PRIMARY KEY,
  NotificationTypeCode AS ('LTB' + CAST(NotificationTypeID AS NVARCHAR(10))) PERSISTED,
  NotificationTypeName NVARCHAR(100) NOT NULL,
  NotificationTypeDescription NVARCHAR(255) NOT NULL
);

-- BẢNG THÔNG BÁO
CREATE TABLE [NOTIFICATION] (
  NotificationID INT IDENTITY(1,1) PRIMARY KEY,
  NotificationCode AS ('TB' + CAST(NotificationID AS NVARCHAR(10))) PERSISTED,
  Title NVARCHAR(100) NOT NULL,
  NotificationMessage NVARCHAR(1000) NOT NULL,
  NotificationDate DATETIME NOT NULL,
  NotificationStatus NVARCHAR(20) NOT NULL CHECK (NotificationStatus IN (N'Chưa xem', N'Đã xem')),
  ReferenceID INT NULL, -- Tham chiếu đến giao dịch, dịch vụ, v.v. (nếu cần)
  CustomerID INT NULL, -- Có thể NULL nếu thông báo dành cho nhân viên
  EmployeeID INT NULL, -- Có thể NULL nếu thông báo dành cho khách hàng
  NotificationTypeID INT NOT NULL,
 
  FOREIGN KEY (CustomerID) REFERENCES CUSTOMER(CustomerID),
  FOREIGN KEY (EmployeeID) REFERENCES EMPLOYEE(EmployeeID),
  FOREIGN KEY (NotificationTypeID) REFERENCES NOTIFICATION_TYPE(NotificationTypeID)
);

-- BẢNG NHÂN VIÊN
CREATE TABLE EMPLOYEE (
  EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
  EmployeeCode AS ('NV' + CAST(EmployeeID AS NVARCHAR(10))) PERSISTED,
  EmployeeName NVARCHAR(255) NOT NULL,
  EmployeeGender NVARCHAR(10) NOT NULL CHECK (EmployeeGender IN (N'Nam', N'Nữ')),
  EmployeeDateOfBirth DATE NOT NULL,
  EmployeeCitizenID VARCHAR(20) NOT NULL UNIQUE,
  EmployeeAddress NVARCHAR(255) NOT NULL,
  EmployeeRole NVARCHAR(50) NOT NULL,
  EmployeePhone VARCHAR(15) NOT NULL UNIQUE,
  EmployeeEmail VARCHAR(100) NOT NULL UNIQUE CHECK (EmployeeEmail LIKE '%_@__%.__%'),
  HireDate DATE NOT NULL,
  Salary DECIMAL(18,0) NOT NULL CHECK (Salary >= 0),
  EmployeeUsername NVARCHAR(50) NOT NULL UNIQUE,
  EmployeePassword NVARCHAR(256) NOT NULL,
  AccessLevel INT NOT NULL CHECK (AccessLevel BETWEEN 1 AND 2), -- 1: Nhân viên, 2: Quản lý
  ManagerID INT NULL,
  FOREIGN KEY (ManagerID) REFERENCES EMPLOYEE(EmployeeID)
);

--BẢNG LỊCH SỬ TRÒ CHUYỆN CHATBOT
CREATE TABLE CHATMESSAGE (
    MessageID INT PRIMARY KEY IDENTITY(1,1),
    AccountID INT NULL,  -- NULL nếu là khách vãng lai
    MessageContent NVARCHAR(MAX) NOT NULL,
    IsFromBot BIT NOT NULL,  -- 1 nếu là tin nhắn từ bot, 0 nếu từ người dùng
    MessageTime DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (AccountID) REFERENCES ACCOUNT(AccountID)
);


-- XÓA BẢNG
DROP TABLE CUSTOMER_TYPE
DROP TABLE CUSTOMER
DROP TABLE ACCOUNT_TYPE
DROP TABLE ACCOUNT
DROP TABLE EMPLOYEE
DROP TABLE TRANSACTION_TYPE
DROP TABLE [TRANSACTION]
DROP TABLE REQUEST
DROP TABLE SERVICE_TYPE
DROP TABLE [SERVICE]
DROP TABLE LOAN_PAYMENT
DROP TABLE REVENUE
DROP TABLE PROFIT
DROP TABLE EXPENSE
DROP TABLE SAVINGS_PAYMENT
DROP TABLE NOTIFICATION_TYPE
DROP TABLE [NOTIFICATION]
DROP TABLE CHATMESSAGE



-- DỮ LIỆU
INSERT INTO CUSTOMER_TYPE (CustomerTypeName, CustomerTypeDescription)
VALUES
	(N'Cá nhân', N'Khách hàng cá nhân có nhu cầu sử dụng dịch vụ ngân hàng cá nhân.'),
	(N'Doanh nghiệp', N'Khách hàng doanh nghiệp, tổ chức sử dụng các dịch vụ tài chính cho doanh nghiệp.'),
	(N'VIP Cá nhân', N'Khách hàng cá nhân có mức độ sử dụng dịch vụ cao, yêu cầu dịch vụ đặc biệt.'),
	(N'VIP Doanh nghiệp', N'Khách hàng doanh nghiệp, tổ chức lớn với các nhu cầu tài chính phức tạp, yêu cầu dịch vụ ưu tiên.');



INSERT INTO CUSTOMER (FullName, Gender, DateOfBirth, Nationality, CitizenID, CustomerAddress, Phone, Email, RegistrationDate, CustomerTypeID)
VALUES
    (N'Nguyễn Văn An', N'Nam', '1990-03-15', N'Việt Nam', '071234567890', N'12 Đường Láng, Đống Đa, Hà Nội', '0901234567', 'nguyenvanan@email.com', '2020-06-12 14:35:22', 1),
    (N'Trần Thị Bình', N'Nữ', '1992-07-20', N'Việt Nam', '071234567891', N'45 Nguyễn Trãi, Thanh Xuân, Hà Nội', '0912345678', 'tranthibinh@email.com', '2021-03-19 09:15:10', 1),
    (N'Công Ty TNHH Minh Phát', N'Nam', '2000-01-01', N'Việt Nam', '071234567892', N'78 Hai Bà Trưng, Quận 1, TP.HCM', '0933456789', 'minhphat.company@email.com', '2022-11-05 16:20:45', 2),
    (N'Phạm Thị Duyên', N'Nữ', '1995-09-25', N'Việt Nam', '071234567893', N'101 Lê Lợi, Quận 3, TP.HCM', '0944567890', 'phamthiduyen@email.com', '2023-08-14 11:50:33', 1),
    (N'Hoàng Văn Đông', N'Nam', '1988-06-12', N'Việt Nam', '071234567894', N'23 Trần Phú, Nha Trang, Khánh Hòa', '0965678901', 'hoangvandong@email.com', '2024-02-28 08:10:15', 1),
    (N'Ngô Thị Phương', N'Nữ', '1993-08-18', N'Việt Nam', '071234567895', N'56 Hùng Vương, Đà Nẵng', '0976789012', 'ngothiphuong@email.com', '2024-07-10 13:45:59', 1),
    (N'Công Ty Cổ Phần Ánh Sáng', N'Nam', '2000-01-01', N'Việt Nam', '071234567896', N'89 Nguyễn Huệ, Biên Hòa, Đồng Nai', '0987890123', 'anhsang.corp@email.com', '2020-09-22 17:30:12', 2),
    (N'Công Ty TNHH Thương Mại Sài Gòn', N'Nữ', '2000-01-01', N'Việt Nam', '071234567897', N'34 Lý Thường Kiệt, Cần Thơ', '0328901234', 'saigontrade.company@email.com', '2021-12-03 10:25:07', 2),
    (N'Công Ty Cổ Phần Công Nghệ Vina', N'Nam', '2000-01-01', N'Việt Nam', '071234567898', N'67 Pasteur, Quận 1, TP.HCM', '0339012345', 'vina.tech@email.com', '2022-04-18 15:40:28', 2),
    (N'Công Ty TNHH Du Lịch Biển Xanh', N'Nữ', '2000-01-01', N'Việt Nam', '071234567899', N'90 Trần Hưng Đạo, Hải Phòng', '0340123456', 'bienxanh.travel@email.com', '2023-01-30 12:55:44', 2),
    (N'Mai Văn Lực', N'Nam', '1989-03-28', N'Việt Nam', '071234567900', N'112 Nguyễn Văn Cừ, Hà Nội', '0351234567', 'maivanluc@email.com', '2024-05-15 09:20:36', 3),
    (N'Trịnh Thị Mai', N'Nữ', '1996-02-10', N'Việt Nam', '071234567901', N'145 Lê Đại Hành, Đà Nẵng', '0362345678', 'trinhthimai@email.com', '2020-10-07 14:10:19', 3),
    (N'Phan Văn Nam', N'Nam', '1984-09-05', N'Việt Nam', '071234567902', N'178 Hai Bà Trưng, Hà Nội', '0373456789', 'phanvannam@email.com', '2021-06-25 16:45:03', 3),
    (N'Hà Thị Oanh', N'Nữ', '1990-04-22', N'Việt Nam', '071234567903', N'201 Nguyễn Thị Minh Khai, TP.HCM', '0384567890', 'hathioanh@email.com', '2022-03-12 11:30:50', 3),
    (N'Công Ty Cổ Phần Đầu Tư Phát Triển', N'Nam', '2000-01-01', N'Việt Nam', '071234567904', N'234 Trần Quang Khải, Cần Thơ', '0395678901', 'phattrien.invest@email.com', '2023-09-08 13:15:27', 4),
    (N'Công Ty TNHH Sản Xuất Hoàng Gia', N'Nữ', '2000-01-01', N'Việt Nam', '071234567905', N'267 Lê Văn Sỹ, TP.HCM', '0706789012', 'hoanggia.prod@email.com', '2024-01-19 10:40:14', 4),
    (N'Công Ty Cổ Phần Công Nghệ Sáng Tạo', N'Nam', '2000-01-01', N'Việt Nam', '071234567906', N'290 Nguyễn Văn Thoại, Đà Nẵng', '0797890123', 'sangtao.tech@email.com', '2020-11-30 15:25:09', 4),
    (N'Công Ty TNHH Dịch Vụ Toàn Cầu', N'Nữ', '2000-01-01', N'Việt Nam', '071234567907', N'313 Điện Biên Phủ, Hà Nội', '0778901234', 'toancau.service@email.com', '2021-08-14 12:50:31', 4),
    (N'Công Ty Cổ Phần Năng Lượng Xanh', N'Nam', '2000-01-01', N'Việt Nam', '071234567908', N'336 Võ Thị Sáu, TP.HCM', '0769012345', 'nangluongxanh.corp@email.com', '2022-07-06 17:05:46', 4),
    (N'Công Ty TNHH Thương Mại Đại Phát', N'Nữ', '2000-01-01', N'Việt Nam', '071234567909', N'359 Cách Mạng Tháng Tám, Cần Thơ', '0780123456', 'daiphat.trade@email.com', '2023-04-22 09:30:58', 4);


	
INSERT INTO ACCOUNT_TYPE (AccountTypeName, AccountTypeDescription)
VALUES
	(N'Cá nhân', N'Tài khoản dành cho khách hàng cá nhân, sử dụng các dịch vụ ngân hàng cá nhân.'),
	(N'Doanh nghiệp', N'Tài khoản dành cho khách hàng doanh nghiệp, phục vụ các nhu cầu tài chính của tổ chức.');



INSERT INTO ACCOUNT (AccountName, Balance, AccountOpenDate, Username, UserPassword, PINCode, AccountStatus, CustomerID, AccountTypeID)
VALUES
    (N'NGUYEN VAN AN', 5000000000, '2020-06-12 14:35:22', '0901234567', 'hashedpass1', '123456', N'Hoạt động', 1, 1),
    (N'TRAN THI BINH', 15000000000, '2021-03-19 09:15:10', '0912345678', 'hashedpass2', '234567', N'Hoạt động', 2, 1),
    (N'CONG TY TNHH MINH PHAT', 8000000000, '2022-11-05 16:20:45', '0933456789', 'hashedpass3', '345678', N'Hoạt động', 3, 2),
    (N'PHAM THI DUYEN', 12000000000, '2023-08-14 11:50:33', '0944567890', 'hashedpass4', '456789', N'Hoạt động', 4, 1),
    (N'HOANG VAN DONG', 20000000000, '2024-02-28 08:10:15', '0965678901', 'hashedpass5', '567890', N'Hoạt động', 5, 1),
    (N'NGO THI PHUONG', 3000000000, '2024-07-10 13:45:59', '0976789012', 'hashedpass6', '678901', N'Hoạt động', 6, 1),
    (N'CONG TY CO PHAN ANH SANG', 9000000000, '2020-09-22 17:30:12', '0987890123', 'hashedpass7', '789012', N'Hoạt động', 7, 2),
    (N'CONG TY TNHH THUONG MAI SAI GON', 11000000000, '2021-12-03 10:25:07', '0328901234', 'hashedpass8', '890123', N'Hoạt động', 8, 2),
    (N'CONG TY CO PHAN CONG NGHE VINA', 7000000000, '2022-04-18 15:40:28', '0339012345', 'hashedpass9', '901234', N'Hoạt động', 9, 2),
    (N'CONG TY TNHH DU LICH BIEN XANH', 13000000000, '2023-01-30 12:55:44', '0340123456', 'hashedpass10', '012345', N'Hoạt động', 10, 2),
    (N'MAI VAN LUC', 6000000000, '2024-05-15 09:20:36', '0351234567', 'hashedpass11', '123456', N'Hoạt động', 11, 1),
    (N'TRINH THI MAI', 14000000000, '2020-10-07 14:10:19', '0362345678', 'hashedpass12', '234567', N'Hoạt động', 12, 1),
    (N'PHAN VAN NAM', 8000000000, '2021-06-25 16:45:03', '0373456789', 'hashedpass13', '345678', N'Hoạt động', 13, 1),
    (N'HA THI OANH', 16000000000, '2022-03-12 11:30:50', '0384567890', 'hashedpass14', '456789', N'Hoạt động', 14, 1),
    (N'CONG TY CO PHAN DAU TU PHAT TRIEN', 35000000000, '2023-09-08 13:15:27', '0395678901', 'hashedpass15', '567890', N'Hoạt động', 15, 2),
    (N'CONG TY TNHH SAN XUAT HOANG GIA', 40000000000, '2024-01-19 10:40:14', '0706789012', 'hashedpass16', '678901', N'Hoạt động', 16, 2),
    (N'CONG TY CO PHAN CONG NGHE SANG TAO', 32000000000, '2020-11-30 15:25:09', '0797890123', 'hashedpass17', '789012', N'Hoạt động', 17, 2),
    (N'CONG TY TNHH DICH VU TOAN CAU', 38000000000, '2021-08-14 12:50:31', '0778901234', 'hashedpass18', '890123', N'Hoạt động', 18, 2),
    (N'CONG TY CO PHAN NANG LUONG XANH', 45000000000, '2022-07-06 17:05:46', '0769012345', 'hashedpass19', '901234', N'Hoạt động', 19, 2),
    (N'CONG TY TNHH THUONG MAI DAI PHAT', 31000000000, '2023-04-22 09:30:58', '0780123456', 'hashedpass20', '012345', N'Hoạt động', 20, 2);



INSERT INTO TRANSACTION_TYPE (TransactionTypeName, TransactionTypeDescription)
VALUES
  (N'Nạp tiền', N'Nạp tiền vào tài khoản từ nguồn như quầy giao dịch, ATM'),
  (N'Rút tiền', N'Rút tiền mặt từ tài khoản qua ATM, quầy giao dịch hoặc các kênh khác'),
  (N'Chuyển tiền', N'Chuyển tiền từ tài khoản này sang tài khoản khác trong nội bộ'),
  (N'Thanh toán khoản vay', N'Thanh toán dịch vụ vay vốn của tài khoản');



  INSERT INTO [TRANSACTION] (Amount, TransactionDate, ReceiverAccountID, ReceiverAccountName, TransactionStatus, HandledBy, TransactionDescription, TransactionMethod, AccountID, TransactionTypeID)
VALUES
    -- Giao dịch Nạp tiền
    (1234567, '2020-07-15 10:25:30', NULL, NULL, N'Hoàn tất', NULL, N'Nạp tiền qua ứng dụng', N'Trực tuyến', 1, 1),
    (987654, '2021-04-20 14:50:45', NULL, NULL, N'Hoàn tất', 2, N'Nạp tiền tại quầy', N'Tại quầy', 2, 1),
    (5432109, '2022-01-10 09:15:20', NULL, NULL, N'Hoàn tất', NULL, N'Nạp tiền qua ATM', N'Trực tuyến', 3, 1),
    (2345678, '2023-05-25 16:30:55', NULL, NULL, N'Hoàn tất', 4, N'Nạp tiền tại quầy', N'Tại quầy', 4, 1),
    (8765432, '2024-03-12 11:45:10', NULL, NULL, N'Hoàn tất', NULL, N'Nạp tiền qua ứng dụng', N'Trực tuyến', 5, 1),

    -- Giao dịch Rút tiền
    (4567891, '2020-08-05 13:20:40', NULL, NULL, N'Hoàn tất', NULL, N'Rút tiền qua ATM', N'Trực tuyến', 6, 2),
    (3210987, '2021-06-18 15:35:25', NULL, NULL, N'Hoàn tất', 3, N'Rút tiền tại quầy', N'Tại quầy', 7, 2),
    (7891234, '2022-03-22 10:10:15', NULL, NULL, N'Hoàn tất', NULL, N'Rút tiền qua ứng dụng', N'Trực tuyến', 8, 2),
    (6543219, '2023-07-30 12:55:30', NULL, NULL, N'Thất bại', 5, N'Rút tiền tại quầy - lỗi hệ thống', N'Tại quầy', 9, 2),
    (1987654, '2024-04-15 14:40:50', NULL, NULL, N'Hoàn tất', NULL, N'Rút tiền qua ATM', N'Trực tuyến', 10, 2),

    -- Giao dịch Chuyển tiền
    (3456789, '2020-09-10 09:30:20', 2, N'TRAN THI BINH', N'Hoàn tất', NULL, N'Chuyển tiền cho bạn', N'Trực tuyến', 1, 3),
    (5678901, '2021-07-25 11:45:35', 3, N'CONG TY TNHH MINH PHAT', N'Hoàn tất', 6, N'Chuyển tiền thanh toán hợp đồng', N'Tại quầy', 2, 3),
    (4321098, '2022-05-15 13:20:40', 4, N'PHAM THI DUYEN', N'Hoàn tất', NULL, N'Chuyển tiền trả nợ', N'Trực tuyến', 3, 3),
    (8765432, '2023-08-20 15:10:55', 5, N'HOANG VAN DONG', N'Đang xử lý', 7, N'Chuyển tiền tại quầy', N'Tại quầy', 4, 3),
    (2345678, '2024-02-28 10:25:30', 6, N'NGO THI PHUONG', N'Hoàn tất', NULL, N'Chuyển tiền qua ứng dụng', N'Trực tuyến', 5, 3),

    -- Thêm một số giao dịch khác
    (9876543, '2021-10-05 12:30:15', NULL, NULL, N'Hoàn tất', NULL, N'Nạp tiền qua ứng dụng', N'Trực tuyến', 11, 1),
    (1234567, '2022-06-18 14:55:20', NULL, NULL, N'Hoàn tất', 8, N'Rút tiền tại quầy', N'Tại quầy', 12, 2),
    (5432109, '2023-03-22 09:40:35', 13, N'PHAN VAN NAM', N'Hoàn tất', NULL, N'Chuyển tiền trả lương', N'Trực tuyến', 7, 3),
    (6789012, '2024-01-15 11:25:50', NULL, NULL, N'Hoàn tất', NULL, N'Nạp tiền qua ATM', N'Trực tuyến', 14, 1),
    (3456789, '2024-05-10 13:50:10', 15, N'CONG TY CO PHAN DAU TU PHAT TRIEN', N'Hoàn tất', 9, N'Chuyển tiền thanh toán dự án', N'Tại quầy', 8, 3);



INSERT INTO SERVICE_TYPE (ServiceTypeName, ServiceTypeDescription)
VALUES 
(N'Vay vốn', N'Dịch vụ cho khách hàng vay tiền với lãi suất nhất định'),
(N'Gửi tiết kiệm', N'Dịch vụ gửi tiền tiết kiệm và nhận lãi theo kỳ hạn');



INSERT INTO NOTIFICATION_TYPE (NotificationTypeName, NotificationTypeDescription)
VALUES
    (N'Hệ thống', N'Thông báo liên quan đến hệ thống và vận hành'),
    (N'Nội bộ', N'Thông báo nội bộ dành cho nhân viên'),
    (N'Giao dịch', N'Thông báo liên quan đến giao dịch tài chính'),
    (N'Dịch vụ', N'Thông báo về các dịch vụ ngân hàng');





-- Quản lý
INSERT INTO EMPLOYEE (EmployeeName, EmployeeGender, EmployeeDateOfBirth, EmployeeCitizenID, EmployeeAddress,
  EmployeeRole, EmployeePhone, EmployeeEmail, HireDate, Salary,
  EmployeeUsername, EmployeePassword, AccessLevel, ManagerID)
VALUES
  (N'Đặng Thị Lan', N'Nữ', '1980-01-01', '071234567890', N'15 Lý Tự Trọng, Quận 1, TP.HCM',
   N'Quản lý', '0901234567', 'lan.dang@sacombank.com', '2010-03-15 09:30:15', 25000000,
   '0901234567', 'adminpass1', 2, NULL);

-- Nhân viên dưới quyền
INSERT INTO EMPLOYEE (EmployeeName, EmployeeGender, EmployeeDateOfBirth, EmployeeCitizenID, EmployeeAddress,
  EmployeeRole, EmployeePhone, EmployeeEmail, HireDate, Salary,
  EmployeeUsername, EmployeePassword, AccessLevel, ManagerID)
VALUES
  (N'Trần Văn Hòa', N'Nam', '1990-02-02', '071234567891', N'25 Nguyễn Hữu Cảnh, Quận 2, TP.HCM',
   N'Nhân viên', '0912345678', 'hoa.tran@sacombank.com', '2020-01-10 14:20:30', 12000000, '0912345678', 'passnv1', 1, 1),
  (N'Lê Thị Hằng', N'Nữ', '1991-03-03', '071234567892', N'38 Lê Văn Sỹ, Quận 3, TP.HCM',
   N'Nhân viên', '0933456789', 'hang.le@sacombank.com', '2020-02-15 10:45:10', 12000000, '0933456789', 'passnv2', 1, 1),
  (N'Phạm Văn Minh', N'Nam', '1992-04-04', '071234567893', N'50 Pasteur, Quận 4, TP.HCM',
   N'Nhân viên', '0944567890', 'minh.pham@sacombank.com', '2020-03-20 15:30:25', 12000000, '0944567890', 'passnv3', 1, 1),
  (N'Nguyễn Thị Lan Anh', N'Nữ', '1993-05-05', '071234567894', N'72 Nguyễn Trãi, Quận 5, TP.HCM',
   N'Nhân viên', '0965678901', 'lananh.nguyen@sacombank.com', '2020-04-25 11:15:40', 12000000, '0965678901', 'passnv4', 1, 1),
  (N'Trịnh Văn Quang', N'Nam', '1994-06-06', '071234567895', N'85 Trần Hưng Đạo, Quận 6, TP.HCM',
   N'Nhân viên', '0976789012', 'quang.trinh@sacombank.com', '2020-05-30 13:50:55', 12000000, '0976789012', 'passnv5', 1, 1),
  (N'Hoàng Kim Ngân', N'Nữ', '1995-07-07', '071234567896', N'98 Hai Bà Trưng, Quận 7, TP.HCM',
   N'Nhân viên', '0987890123', 'ngan.hoang@sacombank.com', '2020-06-10 09:25:20', 12000000, '0987890123', 'passnv6', 1, 1),
  (N'Đỗ Văn Kiệt', N'Nam', '1996-08-08', '071234567897', N'110 Nguyễn Văn Cừ, Quận 8, TP.HCM',
   N'Nhân viên', '0328901234', 'kiet.do@sacombank.com', '2020-07-15 16:40:35', 12000000, '0328901234', 'passnv7', 1, 1),
  (N'Tống Mỹ Duyên', N'Nữ', '1997-09-09', '071234567898', N'125 Điện Biên Phủ, Quận 9, TP.HCM',
   N'Nhân viên', '0339012345', 'duyen.tong@sacombank.com', '2020-08-20 12:10:50', 12000000, '0339012345', 'passnv8', 1, 1),
  (N'Tăng Minh Tuấn', N'Nam', '1998-10-10', '071234567899', N'140 Võ Văn Kiệt, TP. Thủ Đức, TP.HCM',
   N'Nhân viên', '0340123456', 'tuan.tang@sacombank.com', '2020-09-25 14:55:15', 12000000, '0340123456', 'passnv9', 1, 1),
   (N'Ngô Thị Ngọc', N'Nữ', '1999-11-11', '071234567900', N'150 Lê Lợi, Quận 10, TP.HCM',
   N'Nhân viên', '0351234567', 'ngoc.ngo@sacombank.com', '2021-01-05 10:15:20', 12000000, '0351234567', 'passnv10', 1, 1),
  (N'Vũ Thị Hạnh', N'Nữ', '2000-12-12', '071234567901', N'175 Nguyễn Thị Minh Khai, Quận 11, TP.HCM',
   N'Nhân viên', '0362345678', 'hanh.vu@sacombank.com', '2021-03-12 13:40:35', 12000000, '0362345678', 'passnv11', 1, 1),
  (N'Phan Thị Linh', N'Nữ', '2001-01-13', '071234567902', N'200 Trần Phú, Quận 12, TP.HCM',
   N'Nhân viên', '0373456789', 'linh.phan@sacombank.com', '2021-06-20 15:25:50', 12000000, '0373456789', 'passnv12', 1, 1),
  (N'Hoàng Thị Mai', N'Nữ', '2002-02-14', '071234567903', N'225 Cách Mạng Tháng Tám, Quận Bình Thạnh, TP.HCM',
   N'Nhân viên', '0384567890', 'mai.hoang@sacombank.com', '2021-09-10 09:50:10', 12000000, '0384567890', 'passnv13', 1, 1);


