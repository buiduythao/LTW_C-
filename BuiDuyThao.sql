create database BuiDuyThaoCKDB
create table Category(
Cat_ID INT IDENTITY(1,1) PRIMARY KEY,
Cat_Name nvarchar(200) not null,
Cat_Description nvarchar(200))

INSERT INTO Category(Cat_Name,Cat_Description)
VALUES(N'Tự do',''),(N'Ngôn Tình',''),(N'Thơ',''),(N'Chính Trị',''),(N'Giáo Trình','')

create table Author(
Aut_ID INT IDENTITY(1,1) PRIMARY KEY,
Aut_Name nvarchar(200) not null)

INSERT INTO Author(Aut_Name)
VALUES(N'Nguyễn Nhật Ánh'),(N'Hồ Chí Minh'),(N'Tô Hoài')

create table Product(
Pro_ID INT IDENTITY(1,1) PRIMARY KEY,
Cat_ID INT FOREIGN KEY REFERENCES Category(Cat_ID),
Aut_ID INT FOREIGN KEY REFERENCES Author(Aut_ID),
Pro_Name nvarchar(200) not null,
Pro_Quantity int,
Pro_Img varchar(200) null,
Pro_Price decimal,
Pro_Status nvarchar(50),
Pro_Description text null)

INSERT INTO Product(Cat_ID,Aut_ID,Pro_Name,Pro_Quantity,Pro_Img,Pro_Price,Pro_Status,Pro_Description)
VALUES(2,1,N'Tôi thấy hoa vàng trên cỏ xanh',10,'',100000,N'Còn hàng',''),
(2,1,N'ngày xưa có một chuyện tình',10,'',200000,N'Còn hàng',''),
(4,2,N'Ngắm Trăng',10,'',100000,N'Còn hàng','')

create table Customer(
Cus_ID INT IDENTITY(1,1) PRIMARY KEY,
Cus_UserName varchar(50) not null unique,
Cus_Pass varchar(50) not null,
Cus_Name nvarchar(50) not null,
Cus_Status varchar(10) not null,
Cus_Email varchar(50),
Cus_Phone varchar(15),
Cus_Address nvarchar(200))

INSERT INTO Customer(Cus_UserName,Cus_Pass,Cus_Name,Cus_Status,Cus_Email,Cus_Phone,Cus_Address)
VALUES('anhkun','123',N'Duy Thảo','Blocked','bdt2103@gmail.com','0123456789',N'Đà Nẵng'),
('anhkun1','123',N'Duy Thảo 1','Activated','bdt2103@gmail.com','0123456789',N'Đà Nẵng'),
('anhkun2','123',N'Duy Thảo 2','Blocked','bdt2103@gmail.com','0123456789',N'Đà Nẵng'),
('anhkun3','123',N'Duy Thảo 3','Blocked','bdt2103@gmail.com','0123456789',N'Đà Nẵng'),
('anhkun4','123',N'Duy Thảo 4','Blocked','bdt2103@gmail.com','0123456789',N'Đà Nẵng')

create table Orders(
Ord_ID INT IDENTITY(1,1) PRIMARY KEY,
Cus_ID INT FOREIGN KEY REFERENCES Customer(Cus_ID),
Ord_TotalMoney decimal,
Ord_Date date,
Ord_Status nvarchar(50),
Ord_Description nvarchar(200))

create table Order_Detail(
OrDet_ID INT IDENTITY(1,1) PRIMARY KEY,
Ord_ID INT FOREIGN KEY REFERENCES Orders(Ord_ID),
Pro_ID INT FOREIGN KEY REFERENCES Product(Pro_ID),
OrDet_Quantity int default 0)

create table Admin(
Ad_ID INT IDENTITY(1,1) PRIMARY KEY,
Ad_UserName varchar(50) not null unique,
Ad_Pass varchar(50) not null,
Ad_Role int not null)

INSERT INTO Admin(Ad_UserName,Ad_Pass,Ad_Role)
VALUES('admin','21232f297a57a5a743894a0e4a801fc3',1)
