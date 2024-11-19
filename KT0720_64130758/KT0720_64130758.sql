create database  KT0720_64130758
go
use KT0720_64130758
go
create table Lop
(
	MaLop varchar(10) primary key,
	TenLop nvarchar(50) not null,
)

create table SinhVien
(
	MaSV varchar(10) primary key,
	HoSV nvarchar (50),
	TenSV nvarchar (50),
	NgaySinh date,
	GioiTinh bit,
	AnhSV varchar(50),
	DiaChi nvarchar(100) not null,
	MaLop varchar(10) not null foreign key references Lop(MaLop)
	/* update primary key theo bang Lop */
	ON UPDATE CASCADE
	ON DELETE CASCADE
)

create table Category
(
	Id varchar(10) primary key,
	Name 
)
go 
insert into Lop values 
('01', N'Công nghệ thông tin'),
('02', N'Hệ thống thông tin quản lý'),
('03', N'Khoa học máy tính')

go
insert into SinhVien(MaSV, HoSV, TenSV, NgaySinh, GioiTinh, AnhSV, DiaChi, MaLop) values
('641',N'Dương',N'Hồng',CONVERT(DATE, '11-10-2004',105),0,'hongduong.jpg',N'Nha Trang, Khánh Hòa','01'),
('642',N'Hoàng',N'An',CONVERT(DATE, '13-10-2004',105),0,'anhoang.jpg',N'Nha Trang, Khánh Hòa','02'),
('643',N'Hà',N'Ngân',CONVERT(DATE, '07-10-2004',105),0,'nganha.jpg',N'Nha Trang, Khánh Hòa','03')

DROP PROCEDURE IF EXISTS SinhVien_TimKiem;

CREATE PROCEDURE SinhVien_TimKiem
    @MaSV varchar(10)=NULL,
	@HoTen nvarchar(50)=NULL,
	@NgaySinh date=NULL,
	@GioiTinh bit= NULL,
	@AnhSV varchar(50)= NULL,
	@DiaChi nvarchar(100)=NULL,
	@MaLop varchar(10)= NULL
AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
SELECT @SqlStr = '
       SELECT * 
       FROM SinhVien
       WHERE  (1=1)
       '
IF @MaSV IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MaSV LIKE ''%'+@MaSV+'%'')
              '
IF @HoTen IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (HoSV+'' ''+TenSV LIKE ''%'+@HoTen+'%'')
              '
IF @NgaySinh IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (NgaySinh = ''' + CONVERT(varchar(10), @NgaySinh, 105) + ''')
              '
IF @GioiTinh IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (GioiTinh = ' + CAST(@GioiTinh AS NVARCHAR) + ')
             '
IF @AnhSV IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (AnhSV LIKE ''%' + @AnhSV + '%'')
             '
IF @DiaChi IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (DiaChi LIKE ''%' + @DiaChi + '%'')              '
IF @MaLop IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MaLop LIKE ''%' + @MaLop + '%'')
              '
	EXEC SP_EXECUTESQL @SqlStr
END
