-- Tạo cơ sở dữ liệu
CREATE DATABASE QLBanHoaBluey;
GO

-- Sử dụng cơ sở dữ liệu
USE QLBanHoaBluey;
GO

create table Category(
ID int primary key identity(1,1),
Title nvarchar(250),
Description nvarchar(500),
Position int,
SeoTitle nvarchar(150),
SeoDescription nvarchar(500),
SeoKeyword nvarchar(50),
CreatedDate datetime,
CreatedBy nvarchar(50),
ModifierDate datetime,
ModifierBy nvarchar(50)
)

create table Adv(
ID int primary key identity(1,1),
Title nvarchar(250),
Description nvarchar(500),
Image nvarchar(500),
Type int,
CreatedDate datetime,
CreatedBy nvarchar(50),
ModifierDate datetime,
ModifierBy nvarchar(50)
)

create table Contact(
Id int primary key identity(1,1),
Name nvarchar(150),
Website nvarchar(150),
Email varchar(150),
Message nvarchar(4000),
IsRead bit,
CreatedDate datetime,
CreatedBy nvarchar(50),
ModifierDate datetime,
ModifierBy nvarchar(50)
)

-- Bang Danh muc sp
create table ProductCategory(
Id int primary key identity(1,1),
Title nvarchar(50),
Description nvarchar(500),
Icon nvarchar(500),
CreatedDate datetime,
CreatedBy nvarchar(50),
ModifierDate datetime,
ModifierBy nvarchar(50)
)

-- Bang sp
create table Product(
Id int primary key identity(1,1),
Title nvarchar(250),
Description nvarchar(4000),
Detail nvarchar(MAX),
ProductCategoryId int,
Image nvarchar(500),
Price decimal(18,2),
Quantity int,
PriceSale decimal(18,2),
SeoTitle nvarchar(150),
SeoDescription nvarchar(500),
SeoKeyword nvarchar(50),
CreatedDate datetime,
CreatedBy nvarchar(50),
ModifierDate datetime,
ModifierBy nvarchar(50)
CONSTRAINT FK_Product_ProductCategory FOREIGN KEY (Id) REFERENCES ProductCategory(Id)
)

create table News(
Id int primary key identity(1,1),
Title nvarchar(250),
Description nvarchar(4000),
Detail nvarchar(MAX),
CategoryId int, -- Lay tu bang menu
Image nvarchar(500),
SeoTitle nvarchar(150),
SeoDescription nvarchar(500),
SeoKeyword nvarchar(50),
CreatedDate datetime,
CreatedBy nvarchar(50),
ModifierDate datetime,
ModifierBy nvarchar(50)
CONSTRAINT FK_News_Category FOREIGN KEY (Id) REFERENCES Category(Id)
)

create table Post(
Id int primary key identity(1,1),
Title nvarchar(250),
Description nvarchar(4000),
Detail nvarchar(MAX),
CategoryId int, -- Lay tu bang menu
Image nvarchar(500),
SeoTitle nvarchar(150),
SeoDescription nvarchar(500),
SeoKeyword nvarchar(50),
CreatedDate datetime,
CreatedBy nvarchar(50),
ModifierDate datetime,
ModifierBy nvarchar(50)
CONSTRAINT FK_News_Category FOREIGN KEY (Id) REFERENCES Category(Id)
)

create table Order(
Id int primary key identity(1,1),
Code varchar(50),
CustomerName nvarchar(150),
Phone varchar(15),
Address nvarchar(500),
TotalAmount decimal(18,0),
Quantity int,
CreatedDate datetime,
CreatedBy nvarchar(50),
ModifierDate datetime,
ModifierBy nvarchar(50)
)

create table DetailOrder(
Id  int primary key identity(1,1),

)

-- Bảng Loại Sản Phẩm
CREATE TABLE LoaiSP (
    MaLSP VARCHAR(10) PRIMARY KEY, 
    TenLSP NVARCHAR(50) NOT NULL
);

-- Bảng Sản Phẩm
CREATE TABLE SanPham (
    MaSP VARCHAR(10) PRIMARY KEY, 
    TenSP NVARCHAR(50) NOT NULL,
    MoTa NVARCHAR(100) NOT NULL, 
    AnhSP NVARCHAR(100), 
	NgayTao DATETIME,
	NguoiTao nvarchar(50),
	SoLuong int,
    DonGia INT NOT NULL, 
	NgaySua datetime,
	NguoiSua nvarchar(50),
    MaLSP VARCHAR(10) NOT NULL,
    CONSTRAINT FK_SanPham_LoaiSP FOREIGN KEY (MaLSP) REFERENCES LoaiSP(MaLSP)
);

-- Bảng Khách Hàng
CREATE TABLE KhachHang (
    MaKH VARCHAR(10) PRIMARY KEY, 
    HoKH NVARCHAR(50) NOT NULL, 
    TenKH NVARCHAR(50) NOT NULL,
    DiaChi NVARCHAR(100), 
    Email NVARCHAR(100), 
    TenDN NVARCHAR(50) NOT NULL, 
    MatKhau NVARCHAR(50) NOT NULL 
);

-- Bảng Giỏ Hàng (Hóa Đơn)
CREATE TABLE GioHang (
    SoHD INT PRIMARY KEY IDENTITY(1,1), 
    NgayDat DATE NOT NULL, 
    NgayGiao DATE, 
    TinhTrang NVARCHAR(50) NOT NULL,
    MaKH VARCHAR(10) NOT NULL, 
    CONSTRAINT FK_GioHang_KhachHang FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
);

-- Bảng Chi Tiết Hóa Đơn
CREATE TABLE CTHD (
	Id INT PRIMARY KEY,
    SoHD INT NOT NULL, 
    MaSP VARCHAR(10) NOT NULL, 
    SoLuong INT NOT NULL, 
    DonGia INT NOT NULL, 
    PRIMARY KEY (SoHD, MaSP),
    CONSTRAINT FK_CTHD_GioHang FOREIGN KEY (SoHD) REFERENCES GioHang(SoHD), -- Khóa ngoại đến GioHang
    CONSTRAINT FK_CTHD_SanPham FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP) -- Khóa ngoại đến SanPham
);

-- Bảng Nhân Viên
CREATE TABLE NhanVien (
    MaNV VARCHAR(10) PRIMARY KEY, 
    HoTen NVARCHAR(50) NOT NULL, 
    TenDN NVARCHAR(50) NOT NULL, 
    MatKhau NVARCHAR(50) NOT NULL, 
    Quyen NVARCHAR(20) NOT NULL
);
GO
