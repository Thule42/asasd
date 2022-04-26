CREATE DATABASE FoodCompany
GO

USE FoodCompany
GO

CREATE TABLE UserLogin(
	UserName nvarchar(20),
	UserPassword nvarchar(20),
	PRIMARY KEY(UserName)
)
GO

CREATE TABLE Employee(
	EmployeeID nvarchar(50),
	EmployeeName nvarchar(50),
	Gender nvarchar(50),
	Birthdate date,
	Phone nvarchar(50),
	Email nvarchar(50),
	EmployeeAdress nvarchar(50),
	CMNN nvarchar(50)
	PRIMARY KEY(EmployeeID)
)
GO

CREATE TABLE Product(
	ProductID nvarchar(50),
	ProductName nvarchar(50),
	Quantity int,
	Price decimal(18,0),
	PRIMARY KEY(ProductID)
)
GO

CREATE TABLE Agent(
	AgentID nvarchar(50),
	AgentName nvarchar(50),
	AgentAdress nvarchar(50),
	Phone nvarchar(50)
	PRIMARY KEY(AgentID)
)

CREATE TABLE Import(
	ImportID nvarchar(50),
	ProductID nvarchar(50) FOREIGN KEY REFERENCES Product(ProductID),
	ProductName nvarchar(50),
	ImportDate date,
	Quantity int,
	Price decimal(18,0),

	PRIMARY KEY(ImportID)
)
GO

CREATE TABLE Export(
	ExportID nvarchar(50),
	ProductID nvarchar(50) FOREIGN KEY REFERENCES Product(ProductID),
	ProductName nvarchar(50),
	AgentID nvarchar(50) FOREIGN KEY REFERENCES Agent(AgentID),
	ExportDate date,
	Quantity int,
	Price decimal(18,0),
	DeliveryStatus nvarchar(50),
	PaymentStatus nvarchar(50),
	PRIMARY KEY(ExportID)
)
GO

CREATE TABLE RevenueMonth(
	RevenueID int identity,
	Months int,
	Revenue decimal(18,0)
	PRIMARY KEY(RevenueID)
)
GO



INSERT INTO UserLogin VALUES('Thu', '123456')
INSERT INTO UserLogin VALUES('Thuan', '123456')
INSERT INTO UserLogin VALUES('Vy','123456')
SELECT * FROM UserLogin

INSERT INTO Employee VALUES(N'001',N'Đoàn Chính Thuần',N'Nam',N'09823144534',CAST(N'2001-1-30' AS Date), N'doanchinhthuan@gmail.com',N'17 Lê Hồng Phong P.02 Q.10 TPHCM',454674289)
INSERT INTO Employee VALUES(N'002',N'Lê Đào Minh Thư', N'Nữ',N'0909870405',CAST(N'1990-4-11' AS Date), N'minhthu@gmail.com',N'75 Hoàng Văn Thái P.Tân Phú Q.07 TPHCM',936710490)
INSERT INTO Employee VALUES(N'003',N'Nguyễn Đặng Ý Vy', N'Nữ',N'0903002953',CAST(N'1998-12-25' AS Date), N'vynguyen@gmail.com',N'20 Lê Thánh Tôn P.Bến Thành Q.01 TPHCM',825242454)
INSERT INTO Employee VALUES(N'004',N'Nguyễn Lê Phong',N'Nam',N'0909767667',CAST(N'1995-9-14' AS Date), N'nguyenlephong96@gmail.com',N'164 Phan Đình Phùng P.02 Q.Phú Nhuận TPHCM',402567191)
INSERT INTO Employee VALUES(N'005',N'Trần Hoàng Anh',N'Nam',N'0706429133',CAST(N'2000-7-18' AS Date), N'hoanganhtran@gmail.com',N'10 Trưng Nữ Vương P.04 Q.Gò Vấp TPHCM',686753666)
SELECT * FROM Employee