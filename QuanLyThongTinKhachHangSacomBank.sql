CREATE DATABASE QuanLyThongTinKhachHangSacomBank
GO
USE QuanLyThongTinKhachHangSacomBank
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
  ReceiverAccountID INT NOT NULL,
  ReceiverAccountName NVARCHAR(50) NOT NULL,
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

-- BẢNG NHÂN VIÊN
CREATE TABLE EMPLOYEE (
  EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
  EmployeeCode AS ('NV' + CAST(EmployeeID AS NVARCHAR(10))) PERSISTED,
  EmployeeName NVARCHAR(255) NOT NULL,
  EmployeeGender NVARCHAR(10) NOT NULL CHECK (EmployeeGender IN (N'Nam', N'Nữ')),
  EmployeeDateOfBirth DATE NOT NULL,
  EmployeeCitizenID VARCHAR(20) NOT NULL UNIQUE,
  EmployeeAddress NVARCHAR(255) NOT NULL,
  EmmployeeRole NVARCHAR(50) NOT NULL,
  EmployeePhone VARCHAR(15) NOT NULL UNIQUE,
  EmployeeEmail VARCHAR(100) NOT NULL UNIQUE CHECK (EmployeeEmail LIKE '%_@__%.__%'),
  HireDate DATE NOT NULL,
  Salary DECIMAL(18,2) NOT NULL CHECK (Salary >= 0),
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





-- DỮ LIỆU
INSERT INTO CUSTOMER_TYPE (CustomerTypeName, CustomerTypeDescription)
VALUES
	(N'Cá nhân', N'Khách hàng cá nhân có nhu cầu sử dụng dịch vụ ngân hàng cá nhân.'),
	(N'Doanh nghiệp', N'Khách hàng doanh nghiệp, tổ chức sử dụng các dịch vụ tài chính cho doanh nghiệp.'),
	(N'VIP Cá nhân', N'Khách hàng cá nhân có mức độ sử dụng dịch vụ cao, yêu cầu dịch vụ đặc biệt.'),
	(N'VIP Doanh nghiệp', N'Khách hàng doanh nghiệp, tổ chức lớn với các nhu cầu tài chính phức tạp, yêu cầu dịch vụ ưu tiên.');

INSERT INTO CUSTOMER (FullName, Gender, DateOfBirth, Nationality, CitizenID, CustomerAddress, Phone, Email, RegistrationDate, CustomerTypeID)
VALUES
  (N'Trương Anh Tuấn', N'Nam', '1992-03-10', N'Việt Nam', '123456001', N'Hà Nội', '0912345670', 'tuan.truong@email.com', '2025-01-01', 1),
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
  (N'TRUONG ANH TUAN', 8000000, '2025-01-01', '0912345670', 'pass123', '111111', N'Hoạt động', 1, 1),
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
  (N'Thanh toán', N'Thanh toán dịch vụ vay vốn của tài khoản');





-- Quản lý
INSERT INTO EMPLOYEE (EmployeeName, EmployeeGender, EmployeeDateOfBirth, EmployeeCitizenID, EmployeeAddress,
  EmmployeeRole, EmployeePhone, EmployeeEmail, HireDate, Salary,
  EmployeeUsername, EmployeePassword, AccessLevel, ManagerID)
VALUES
  (N'Đặng Thị Lan', N'Nữ', '1980-01-01', '999000001', N'Quận 1, TP.HCM',
   N'Quản lý', '0900000001', 'lan.dang@sacombank.com', '2010-01-01', 25000000,
   '0900000001', 'adminpass1', 2, NULL);


-- Nhân viên dưới quyền
INSERT INTO EMPLOYEE (EmployeeName, EmployeeGender, EmployeeDateOfBirth, EmployeeCitizenID, EmployeeAddress,
  EmmployeeRole, EmployeePhone, EmployeeEmail, HireDate, Salary,
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


