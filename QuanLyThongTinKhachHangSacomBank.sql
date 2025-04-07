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
  RegistrationDate DATE NOT NULL,
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
  Balance DECIMAL(18,2) NOT NULL,          
  AccountOpenDate DATE NOT NULL,           
  Username NVARCHAR(50) NOT NULL UNIQUE,          
  UserPassword NVARCHAR(256) NOT NULL,         
  PINCode NVARCHAR(6) NOT NULL CHECK (PINCode LIKE '[0-9][0-9][0-9][0-9][0-9][0-9]'),           
  AccountStatus NVARCHAR(20) NOT NULL CHECK (AccountStatus IN (N'Hoạt động', N'Đã khóa', N'Tạm khóa', N'Đóng')),            
  CustomerID INT NOT NULL,               
  AccountTypeID INT NOT NULL,            
  FOREIGN KEY (CustomerID) REFERENCES CUSTOMER(CustomerID),
  FOREIGN KEY (AccountTypeID) REFERENCES ACCOUNT_TYPE(AccountTypeID)
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



-- DỮ LIỆU
INSERT INTO CUSTOMER_TYPE (CustomerTypeName, CustomerTypeDescription)
VALUES
	(N'Cá nhân', N'Khách hàng cá nhân có nhu cầu sử dụng dịch vụ ngân hàng cá nhân.'),
	(N'Doanh nghiệp', N'Khách hàng doanh nghiệp, tổ chức sử dụng các dịch vụ tài chính cho doanh nghiệp.'),
	(N'VIP Cá nhân', N'Khách hàng cá nhân có mức độ sử dụng dịch vụ cao, yêu cầu dịch vụ đặc biệt.'),
	(N'VIP Doanh nghiệp', N'Khách hàng doanh nghiệp, tổ chức lớn với các nhu cầu tài chính phức tạp, yêu cầu dịch vụ ưu tiên.');

INSERT INTO CUSTOMER (FullName, Gender, DateOfBirth, Nationality, CitizenID, CustomerAddress, Phone, Email, RegistrationDate, CustomerTypeID)
VALUES
	(N'Nguyễn Văn A', N'Nam', '1990-01-01', N'Việt Nam', '123456789', N'Hà Nội', '0769727851', 'tat01022005@gmail.com', '2025-01-01', 1),
	(N'Phạm Thị B', N'Nữ', '1985-05-15', N'Việt Nam', '987654321', N'Hồ Chí Minh', '0987654321', 'b.pham@mail.com', '2025-02-01', 2),
	(N'Trần Quang C', N'Nam', '1992-11-22', N'Việt Nam', '123987456', N'Đà Nẵng', '0934123456', 'c.tran@mail.com', '2025-03-01', 3),
	(N'Vũ Minh D', N'Nữ', '1990-07-09', N'Việt Nam', '654321987', N'Bình Dương', '0976123456', 'd.vu@mail.com', '2025-04-01', 4),
	(N'Ngô Hữu E', N'Nam', '1988-12-12', N'Việt Nam', '321654987', N'Cần Thơ', '0901234567', 'e.ngo@mail.com', '2025-05-01', 1);
	
INSERT INTO ACCOUNT_TYPE (AccountTypeName, AccountTypeDescription)
VALUES
	(N'Cá nhân', N'Tài khoản dành cho khách hàng cá nhân, sử dụng các dịch vụ ngân hàng cá nhân.'),
	(N'Doanh nghiệp', N'Tài khoản dành cho khách hàng doanh nghiệp, phục vụ các nhu cầu tài chính của tổ chức.');

INSERT INTO ACCOUNT (AccountName, Balance, AccountOpenDate, Username, UserPassword, PINCode, AccountStatus, CustomerID, AccountTypeID)
VALUES
    (N'Tài khoản cá nhân A', 5000000, '2025-01-01', 'user_a', 'passwordA', '123456', N'Hoạt động', 1, 1),
    (N'Tài khoản cá nhân B', 2000000, '2025-02-01', 'user_b', 'passwordB', '654321', N'Hoạt động', 2, 1),
    (N'Tài khoản doanh nghiệp C', 10000000, '2025-03-01', 'user_c', 'passwordC', '789123', N'Hoạt động', 3, 2),
    (N'Tài khoản doanh nghiệp D', 15000000, '2025-04-01', 'user_d', 'passwordD', '321654', N'Hoạt động', 4, 2),
    (N'Tài khoản cá nhân E', 3000000, '2025-05-01', 'user_e', 'passwordE', '987654', N'Tạm khóa', 5, 1);

-- Trước tiên chèn người quản lý
INSERT INTO EMPLOYEE (
  EmployeeName, EmployeeGender, EmployeeDateOfBirth, EmployeeCitizenID, EmployeeAddress,
  EmmployeeRole, EmployeePhone, EmployeeEmail, HireDate, Salary,
  EmployeeUsername, EmployeePassword, AccessLevel, ManagerID
)
VALUES
  (N'Nguyễn Thị Lan', N'Nữ', '1988-03-22', '9876543210', N'Quận 3, TP.HCM',
   N'Quản lý', '0922333444', 'lan.nguyen@sacombank.com', '2018-05-20', 18000000,
   'lannt', 'passLan456', 2, NULL);

-- Giả sử EmployeeID của chị Lan là 1, ta dùng ManagerID = 1 cho các nhân viên
INSERT INTO EMPLOYEE (
  EmployeeName, EmployeeGender, EmployeeDateOfBirth, EmployeeCitizenID, EmployeeAddress,
  EmmployeeRole, EmployeePhone, EmployeeEmail, HireDate, Salary,
  EmployeeUsername, EmployeePassword, AccessLevel, ManagerID
)
VALUES
  (N'Lê Văn Hùng', N'Nam', '1990-06-15', '0123456789', N'Quận 1, TP.HCM',
   N'Nhân viên', '0911222333', 'hung.le@sacombank.com', '2020-01-10', 12000000,
   'hunglv', 'passHung123', 1, 1),

  (N'Phạm Quang Dũng', N'Nam', '1992-11-10', '4567891230', N'Quận Bình Thạnh, TP.HCM',
   N'Nhân viên', '0933444555', 'dung.pham@sacombank.com', '2021-03-01', 11000000,
   'dungpq', 'passDung789', 1, 1),

  (N'Trần Mai Anh', N'Nữ', '1995-08-05', '7891234560', N'Quận 5, TP.HCM',
   N'Nhân viên', '0944555666', 'anh.tran@sacombank.com', '2022-07-15', 10500000,
   'anhtm', 'passAnh321', 1, 1),

  (N'Vũ Đức Minh', N'Nam', '1985-12-30', '3216549870', N'Quận 10, TP.HCM',
   N'Nhân viên', '0955666777', 'minh.vu@sacombank.com', '2023-01-10', 10200000,
   'minhvd', 'passMinh654', 1, 1);


