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
CREATE TABLE ACCOUNT_TYPE
(
  AccountTypeID INT IDENTITY(1,1) PRIMARY KEY,
  AccountTypeCode AS ('LTK' + CAST(AccountTypeID AS NVARCHAR(10))) PERSISTED,
  AccountTypeName NVARCHAR(50) NOT NULL,
  AccountTypeDescription NVARCHAR(255) NOT NULL,
);

-- BẢNG TÀI KHOẢN
CREATE TABLE ACCOUNT
(
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
CREATE TABLE TRANSACTION_TYPE
(
  TransactionTypeID INT IDENTITY(1,1) PRIMARY KEY,
  TransactionTypeCode AS ('LGD' + CAST(TransactionTypeID AS NVARCHAR(10))) PERSISTED,
  TransactionTypeName NVARCHAR(100) NOT NULL,
  TransactionTypeDescription NVARCHAR(255) NOT NULL
);

-- BẢNG GIAO DỊCH
CREATE TABLE [TRANSACTION]
(
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
CREATE TABLE REQUEST 
(
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
CREATE TABLE SERVICE_TYPE 
(
  ServiceTypeID INT IDENTITY(1,1) PRIMARY KEY,
  ServiceTypeCode AS ('LDV' + CAST(ServiceTypeID AS NVARCHAR(10))) PERSISTED,
  ServiceTypeName NVARCHAR(100) NOT NULL,
  ServiceTypeDescription NVARCHAR(255) NOT NULL
);

-- BẢNG DỊCH VỤ
CREATE TABLE [SERVICE] 
(
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
CREATE TABLE LOAN_PAYMENT
(
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
CREATE TABLE REVENUE
(
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
CREATE TABLE PROFIT
(
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



-- DỮ LIỆU
INSERT INTO CUSTOMER_TYPE (CustomerTypeName, CustomerTypeDescription)
VALUES
	(N'Cá nhân', N'Khách hàng cá nhân có nhu cầu sử dụng dịch vụ ngân hàng cá nhân.'),
	(N'Doanh nghiệp', N'Khách hàng doanh nghiệp, tổ chức sử dụng các dịch vụ tài chính cho doanh nghiệp.'),
	(N'VIP Cá nhân', N'Khách hàng cá nhân có mức độ sử dụng dịch vụ cao, yêu cầu dịch vụ đặc biệt.'),
	(N'VIP Doanh nghiệp', N'Khách hàng doanh nghiệp, tổ chức lớn với các nhu cầu tài chính phức tạp, yêu cầu dịch vụ ưu tiên.');

INSERT INTO CUSTOMER (FullName, Gender, DateOfBirth, Nationality, CitizenID, CustomerAddress, Phone, Email, RegistrationDate, CustomerTypeID)
VALUES
  (N'Trương Minh Tuấn', N'Nam', '1992-03-10', N'Việt Nam', '123456001', N'Hà Nội', '0912345670', 'tuan.truongminh@email.com', '2025-01-01', 1),
  (N'Nguyễn Thị Mai', N'Nữ', '1989-07-20', N'Việt Nam', '123456002', N'Hải Phòng', '0912345671', 'mai.nguyen@email.com', '2025-01-05', 1),
  (N'Công Ty TNHH ABC', N'Nam', '2000-01-01', N'Việt Nam', '123456003', N'Hồ Chí Minh', '0912345672', 'abc.company@email.com', '2025-01-10', 2),
  (N'Trần Văn Bình', N'Nam', '1990-11-12', N'Việt Nam', '123456004', N'Nghệ An', '0912345673', 'binh.tran@email.com', '2025-01-15', 1),
  (N'Lê Thị Hương', N'Nữ', '1995-06-30', N'Việt Nam', '123456005', N'Đà Nẵng', '0912345674', 'huong.le@email.com', '2025-01-20', 3),
  (N'Nguyễn Văn Khoa', N'Nam', '1988-08-08', N'Việt Nam', '123456006', N'Huế', '0912345675', 'khoa.nguyen@email.com', '2025-01-25', 1),
  (N'Trường Đại Học Tôn Đức Thắng', N'Nữ', '2000-01-01', N'Việt Nam', '123456007', N'Hồ Chí Minh', '0912345676', 'tdt.university@email.com', '2025-02-01', 4),
  (N'Lý Minh Quân', N'Nam', '1993-09-09', N'Việt Nam', '123456008', N'Bình Dương', '0912345677', 'quan.ly@email.com', '2025-02-05', 3),
  (N'Phạm Hoàng Nam', N'Nam', '1991-04-14', N'Việt Nam', '123456009', N'Cần Thơ', '0912345678', 'nam.pham@email.com', '2025-02-10', 1),
  (N'Công Ty Cổ Phần XYZ', N'Nữ', '2000-01-01', N'Việt Nam', '123456010', N'Hà Nội', '0912345679', 'xyz.corp@email.com', '2025-02-15', 2);

	
INSERT INTO ACCOUNT_TYPE (AccountTypeName, AccountTypeDescription)
VALUES
	(N'Cá nhân', N'Tài khoản dành cho khách hàng cá nhân, sử dụng các dịch vụ ngân hàng cá nhân.'),
	(N'Doanh nghiệp', N'Tài khoản dành cho khách hàng doanh nghiệp, phục vụ các nhu cầu tài chính của tổ chức.');

INSERT INTO ACCOUNT (AccountName, Balance, AccountOpenDate, Username, UserPassword, PINCode, AccountStatus, CustomerID, AccountTypeID)
VALUES
  (N'TRUONG MINH TUAN', 8000000, '2025-01-01', '0912345670', 'pass123', '111111', N'Hoạt động', 1, 1),
  (N'NGUYEN THI MAI', 7500000, '2025-01-05', '0912345671', 'pass123', '222222', N'Hoạt động', 2, 1),
  (N'CONG TY TNHH ABC', 15000000, '2025-01-10', '0912345672', 'pass123', '333333', N'Hoạt động', 3, 2),
  (N'TRAN VAN BINH', 4500000, '2025-01-15', '0912345673', 'pass123', '444444', N'Hoạt động', 4, 1),
  (N'LE THI HUONG', 12000000, '2025-01-20', '0912345674', 'pass123', '555555', N'Hoạt động', 5, 1),
  (N'NGUYEN VAN KHOA', 9800000, '2025-01-25', '0912345675', 'pass123', '666666', N'Khóa', 6, 1),
  (N'TRUONG DAI HOC TON DUC THANG', 250000000, '2025-02-01', '0912345676', 'pass123', '777777', N'Hoạt động', 7, 2),
  (N'LY MINH QUAN', 6300000, '2025-02-05', '0912345677', 'pass123', '888888', N'Hoạt động', 8, 1),
  (N'PHAM HOANG NAM', 7000000, '2025-02-10', '0912345678', 'pass123', '999999', N'Đóng', 9, 1),
  (N'CONG TY CO PHAN XYZ', 30000000, '2025-02-15', '0912345679', 'pass123', '000000', N'Hoạt động', 10, 2);


INSERT INTO TRANSACTION_TYPE (TransactionTypeName, TransactionTypeDescription)
VALUES
  (N'Nạp tiền', N'Nạp tiền vào tài khoản từ nguồn như quầy giao dịch, ATM'),
  (N'Rút tiền', N'Rút tiền mặt từ tài khoản qua ATM, quầy giao dịch hoặc các kênh khác'),
  (N'Chuyển tiền', N'Chuyển tiền từ tài khoản này sang tài khoản khác trong nội bộ'),
  (N'Thanh toán khoản vay', N'Thanh toán dịch vụ vay vốn của tài khoản');

INSERT INTO SERVICE_TYPE (ServiceTypeName, ServiceTypeDescription)
VALUES 
(N'Vay vốn', N'Dịch vụ cho khách hàng vay tiền với lãi suất nhất định'),
(N'Gửi tiết kiệm', N'Dịch vụ gửi tiền tiết kiệm và nhận lãi theo kỳ hạn');




-- Quản lý
INSERT INTO EMPLOYEE (EmployeeName, EmployeeGender, EmployeeDateOfBirth, EmployeeCitizenID, EmployeeAddress,
  EmployeeRole, EmployeePhone, EmployeeEmail, HireDate, Salary,
  EmployeeUsername, EmployeePassword, AccessLevel, ManagerID)
VALUES
  (N'Đặng Thị Lan', N'Nữ', '1980-01-01', '999000001', N'Quận 1, TP.HCM',
   N'Quản lý', '0900000001', 'lan.dang@sacombank.com', '2010-01-01', 25000000,
   '0900000001', 'adminpass1', 2, NULL);


-- Nhân viên dưới quyền
INSERT INTO EMPLOYEE (EmployeeName, EmployeeGender, EmployeeDateOfBirth, EmployeeCitizenID, EmployeeAddress,
  EmployeeRole, EmployeePhone, EmployeeEmail, HireDate, Salary,
  EmployeeUsername, EmployeePassword, AccessLevel, ManagerID)
VALUES
  (N'Trần Văn Hòa', N'Nam', '1990-02-02', '999000002', N'Quận 2, TP.HCM',
   N'Nhân viên', '0900000002', 'hoa.tran@sacombank.com', '2020-01-01', 12000000, '0900000002', 'passnv1', 1, 1),
  (N'Lê Thị Hằng', N'Nữ', '1991-03-03', '999000003', N'Quận 3, TP.HCM',
   N'Nhân viên', '0900000003', 'hang.le@sacombank.com', '2020-02-01', 12000000, '0900000003', 'passnv2', 1, 1),
  (N'Phạm Văn Minh', N'Nam', '1992-04-04', '999000004', N'Quận 4, TP.HCM',
   N'Nhân viên', '0900000004', 'minh.pham@sacombank.com', '2020-03-01', 12000000, '0900000004', 'passnv3', 1, 1),
  (N'Nguyễn Thị Lan Anh', N'Nữ', '1993-05-05', '999000005', N'Quận 5, TP.HCM',
   N'Nhân viên', '0900000005', 'lananh.nguyen@sacombank.com', '2020-04-01', 12000000, '0900000005', 'passnv4', 1, 1),
  (N'Trịnh Văn Quang', N'Nam', '1994-06-06', '999000006', N'Quận 6, TP.HCM',
   N'Nhân viên', '0900000006', 'quang.trinh@sacombank.com', '2020-05-01', 12000000, '0900000006', 'passnv5', 1, 1),
  (N'Hoàng Kim Ngân', N'Nữ', '1995-07-07', '999000007', N'Quận 7, TP.HCM',
   N'Nhân viên', '0900000007', 'ngan.hoang@sacombank.com', '2020-06-01', 12000000, '0900000007', 'passnv6', 1, 1),
  (N'Đỗ Văn Kiệt', N'Nam', '1996-08-08', '999000008', N'Quận 8, TP.HCM',
   N'Nhân viên', '0900000008', 'kiet.do@sacombank.com', '2020-07-01', 12000000, '0900000008', 'passnv7', 1, 1),
  (N'Tống Mỹ Duyên', N'Nữ', '1997-09-09', '999000009', N'Quận 9, TP.HCM',
   N'Nhân viên', '0900000009', 'duyen.tong@sacombank.com', '2020-08-01', 12000000, '0900000009', 'passnv8', 1, 1),
  (N'Tăng Minh Tuấn', N'Nam', '1998-10-10', '999000010', N'TP. Thủ Đức',
   N'Nhân viên', '0900000010', 'tuan.tang@sacombank.com', '2020-09-01', 12000000, '0900000010', 'passnv9', 1, 1);


