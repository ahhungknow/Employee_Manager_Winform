CREATE DATABASE [QlNhanSu]
GO
USE [QlNhanSu]

GO
CREATE TABLE [dbo].[BaoHiem](
	[MaNhanVien] [varchar](5) NOT NULL,
	[LoaiBaoHiem] [nvarchar](50) NULL,
	[SoThe] [varchar](20) NULL,
	[NgayCap] [date] NULL,
	[NgayHetHan] [date] NULL,
	[NoiCap] [nvarchar](100) NULL
) ON [PRIMARY]


GO
CREATE TABLE [dbo].[ChamCong](
	[MaNhanVien] [varchar](5) NOT NULL,
	[Ngay] [date] NOT NULL,
	[TinhTrang] [nvarchar](20) NULL
) ON [PRIMARY]


GO
CREATE TABLE [dbo].[ChucVu](
	[MaCV] [varchar](5) NOT NULL,
	[TenCv] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE TABLE [dbo].[ctChucVu](
	[MaNhanVien] [varchar](5) NULL,
	[MaCV] [varchar](5) NULL,
	[NgayBatDau] [date] NULL,
	[NgayKetThuc] [date] NULL,
	[LyDo] [nvarchar](100) NULL
) ON [PRIMARY]

GO
CREATE TABLE [dbo].[HopDong](
	[MaHD] [varchar](5) NOT NULL,
	[NgayVaoLam] [date] NOT NULL,
	[HeSoLuong] [int] NOT NULL,
	[MaCV] [varchar](5) NOT NULL,
	[MaPB] [varchar](5) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


GO

CREATE TABLE [dbo].[Luong](
	[HeSoLuong] [int] NOT NULL,
	[LuongCB] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[HeSoLuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 29/04/2019 4:02:27 CH ******/

CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [varchar](5) NOT NULL,
	[MaPB] [varchar](5) NOT NULL,
	[MaHD] [varchar](5) NOT NULL,
	[HeSoLuong] [int] NOT NULL,
	[TenNV] [nvarchar](100) NOT NULL,
	[GioiTinh] [nvarchar](5) NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[SoCM] [varchar](20) NOT NULL,
	[DienThoai] [varchar](20) NOT NULL,
	[TrinhDoHV] [nvarchar](30) NOT NULL,
	[DiaChi] [nvarchar](max) NOT NULL,
	[Email] [varchar](20) NULL,
	[Hinh] [nvarchar](100) NOT NULL,
	[TTHonNhan] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK__NhanVien__77B2CA47594A01A3] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[PhongBan](
	[MaPB] [varchar](5) NOT NULL,
	[TenPB] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[PhuCap](
	[MaNhanVien] [varchar](5) NOT NULL,
	[LoaiPC] [nvarchar](50) NULL,
	[Tien] [int] NULL,
	[TuNgay] [date] NULL,
	[DenNgay] [date] NULL
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Taikhoan](
	[MaNhanVien] [varchar](5) NOT NULL,
	[TenDangNhap] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NOT NULL,
	[TenQuyenHan] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[ThuongPhat](
	[MaNhanVien] [varchar](5) NOT NULL,
	[Loai] [nvarchar](50) NULL,
	[Tien] [int] NULL,
	[LyDo] [nvarchar](max) NULL,
	[Ngay] [date] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[BaoHiem]  WITH CHECK ADD  CONSTRAINT [FK__BaoHiem__NoiCap__286302EC] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BaoHiem] CHECK CONSTRAINT [FK__BaoHiem__NoiCap__286302EC]
GO
ALTER TABLE [dbo].[ChamCong]  WITH CHECK ADD  CONSTRAINT [FK__ChamCong__MaNhan__239E4DCF] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChamCong] CHECK CONSTRAINT [FK__ChamCong__MaNhan__239E4DCF]
GO
ALTER TABLE [dbo].[ctChucVu]  WITH CHECK ADD FOREIGN KEY([MaCV])
REFERENCES [dbo].[ChucVu] ([MaCV])
GO
ALTER TABLE [dbo].[ctChucVu]  WITH CHECK ADD  CONSTRAINT [FK__ctChucVu__MaNhan__25869641] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ctChucVu] CHECK CONSTRAINT [FK__ctChucVu__MaNhan__25869641]
GO
ALTER TABLE [dbo].[HopDong]  WITH CHECK ADD  CONSTRAINT [FK__HopDong__HeSoLuong__164452B1] FOREIGN KEY([HeSoLuong])
REFERENCES [dbo].[Luong] ([HeSoLuong])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HopDong] CHECK CONSTRAINT [FK__HopDong__HeSoLuong__164452B1]
GO
ALTER TABLE [dbo].[HopDong]  WITH CHECK ADD  CONSTRAINT [FK__HopDong__MaCV__173876EA] FOREIGN KEY([MaCV])
REFERENCES [dbo].[ChucVu] ([MaCV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HopDong] CHECK CONSTRAINT [FK__HopDong__MaCV__173876EA]
GO
ALTER TABLE [dbo].[HopDong]  WITH CHECK ADD  CONSTRAINT [FK__HopDong__MaPB__182C9B23] FOREIGN KEY([MaPB])
REFERENCES [dbo].[PhongBan] ([MaPB])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HopDong] CHECK CONSTRAINT [FK__HopDong__MaPB__182C9B23]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__HeSoLu__1BFD2C07] FOREIGN KEY([HeSoLuong])
REFERENCES [dbo].[Luong] ([HeSoLuong])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK__NhanVien__HeSoLu__1BFD2C07]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__MaPB__1B0907CE] FOREIGN KEY([MaPB])
REFERENCES [dbo].[PhongBan] ([MaPB])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK__NhanVien__MaPB__1B0907CE]
GO
ALTER TABLE [dbo].[PhuCap]  WITH CHECK ADD  CONSTRAINT [FK__PhuCap__DenNgay__2A4B4B5E] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PhuCap] CHECK CONSTRAINT [FK__PhuCap__DenNgay__2A4B4B5E]
GO
ALTER TABLE [dbo].[Taikhoan]  WITH CHECK ADD  CONSTRAINT [FK__Taikhoan__MaNhan__1FCDBCEB] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Taikhoan] CHECK CONSTRAINT [FK__Taikhoan__MaNhan__1FCDBCEB]
GO
ALTER TABLE [dbo].[ThuongPhat]  WITH CHECK ADD  CONSTRAINT [FK__ThuongPha__MaNha__21B6055D] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ThuongPhat] CHECK CONSTRAINT [FK__ThuongPha__MaNha__21B6055D]
GO


Create proc [dbo].[CapNhatChucVu]
@macv varchar(5),
@tencv nvarchar(50)
as
	if(exists(select MaCV from ChucVu where MaCV = @macv))
	begin
		update ChucVu set MaCV = @macv, TenCV = @tencv where MaCV = @macv
	end

----------------------------------------------------------------------------------------------------------------------

GO


Create proc [dbo].[CapNhatLuong]
@hesoluong int,
@luongcb int
as
	Update Luong set LuongCB = @luongcb where HeSoLuong = @hesoluong

-------------------------------------------------------------------------------------------------

GO


Create Proc [dbo].[CapNhatMaCvTrongHopDong]
@mahd varchar(5),
@macv varchar(5)
as
	update HopDong set MaCV = @macv where MaHD = @mahd
------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------Bảng Chấm Công-----------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------


GO


Create proc [dbo].[CapNhatNgayVaoLam]
@ngay date,
@manv varchar(5)
as
	update HopDong set NgayVaoLam = @ngay from NhanVien inner join HopDong on NhanVien.MaHD = HopDong.MaHD where MaNhanVien = @manv
------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------Bảng Hợp Đồng-----------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------



Create Proc [dbo].[CapNhatPhongBan]
@maphong varchar(5),
@tenphong nvarchar(20)
as
	update PhongBan set MaPB = @maphong, TenPB = @tenphong
	where MaPB = @maphong

-------------------------------------------------------------------------------------------------

GO

Create Proc [dbo].[DangNhap]
@taikhoan nvarchar(50),
@matkhau nvarchar(50)
as
if(exists(select TenDangNhap from TaiKhoan where TenDangNhap = @taikhoan and MatKhau = @matkhau))
begin
	select err = 0
end
else
	select err = 1
-------------------------------------------------------------------------------------------------

GO

Create proc [dbo].[DemSoNgayLam]
@manv varchar(5),
@ngaydau date,
@ngaycuoi date
as
	select MaNhanVien, COUNT(Ngay)as NgayLam from ChamCong 
	where MaNhanVien = @manv and (Ngay >= @ngaydau and Ngay <= @ngaycuoi) and TinhTrang = N'Đi Làm'
	Group By MaNhanVien

-------------------------------------------------------------------------------------------------

GO

Create proc [dbo].[DemSoNgaynghiCoPhep]
@manv varchar(5),
@ngaydau date,
@ngaycuoi date
as
	select MaNhanVien, COUNT(Ngay)as NgayLam from ChamCong 
	where MaNhanVien = @manv and (Ngay >= @ngaydau and Ngay <= @ngaycuoi) and TinhTrang = N'Nghỉ Có Phép'
	Group By MaNhanVien

-------------------------------------------------------------------------------------------------

GO

Create proc [dbo].[DemSoNgayNghiKhongPhep]
@manv varchar(5),
@ngaydau date,
@ngaycuoi date
as
	select MaNhanVien, COUNT(Ngay)as NgayLam from ChamCong 
	where MaNhanVien = @manv and (Ngay >= @ngaydau and Ngay <= @ngaycuoi) and TinhTrang = N'Nghỉ Không Phép'
	Group By MaNhanVien

GO

Create Proc [dbo].[DoiMatKhau]
@manv varchar(5),
@taikhoan nvarchar(50),
@matkhaumoi nvarchar(50)
as
	update TaiKhoan set MaNhanVien = @manv, TenDangNhap = @taikhoan, MatKhau = @matkhaumoi
	where TenDangNhap = @taikhoan

-------------------------------------------------------------------------------------------------

GO

Create Proc [dbo].[HienPhongBan]
@maphong varchar(5)
as
	if(@maphong = '0')
	begin
		select PhongBan.MaPB, TenPB, count(NhanVien.MaPB) as SoNV
		from PhongBan left join NhanVien on PhongBan.MaPB = NhanVien.MaPB
		GROUP BY PhongBan.MaPB, TenPB
	end
	else
	begin
		select PhongBan.MaPB, TenPB, count(NhanVien.MaPB) as SoNV
		from PhongBan left join NhanVien on PhongBan.MaPB = NhanVien.MaPB
		where PhongBan.MaPB = @maphong
		GROUP BY PhongBan.MaPB, TenPB
	end	

-------------------------------------------------------------------------------------------------

GO

Create proc [dbo].[LayBaoHiem]
@ma varchar(5),
@loaibh nvarchar(50)
as
	if(@ma = '0')
	begin
		select NhanVien.MaNhanVien, TenNV, LoaiBaoHiem, NgayHetHan
		from NhanVien left join BaoHiem on NhanVien.MaNhanVien = BaoHiem.MaNhanVien
	end
	else
	begin
		select NhanVien.MaNhanVien, TenNV, LoaiBaoHiem, SoThe, NgayCap, NgayHetHan, NoiCap
		from NhanVien left join BaoHiem on NhanVien.MaNhanVien = BaoHiem.MaNhanVien
		where NhanVien.MaNhanVien = @ma and LoaiBaoHiem = @loaibh
	end
---------------------------------------------------------------------------------------

GO

Create Proc [dbo].[LayChamCong]
@ma varchar(5),
@ngay date
as
if(@ma = '0')
begin
	select ChamCong.MaNhanVien, NhanVien.TenNV, TinhTrang 
	from ChamCong inner join NhanVien on ChamCong.MaNhanVien = NhanVien.MaNhanVien
	where Ngay = @ngay
end
else
begin
	select ngay from ChamCong where Ngay = @ngay
end

-------------------------------------------------------------------------------------------------

GO


Create proc [dbo].[LayChucVu]
@ma varchar(5)
as
	if(@ma = '0')
	begin
		select MaCV, TenCv from ChucVu
	end
	else
	begin
		select MaCV, TenCv from ChucVu where MaCV = @ma
	end

----------------------------------------------------------------------------------------------------------------------

GO


Create proc [dbo].[LayChucVuTuMaNV]
@manv varchar(5)
as
	select TenCV from (NhanVien inner join HopDong on NhanVien.MaHD = HopDong.MaHD) inner join ChucVu on HopDong.MaCV = ChucVu.MaCV
	where MaNhanVien = @manv

----------------------------------------------------------------------------------------------------------------------

GO


Create proc [dbo].[LayctChucVu]
@manv varchar(5)
as
	if(@manv = '0')
	begin
		select MaNhanVien, ' ' as TenNV,  ' ' as TenCv, NgayBatDau, NgayKetThuc, LyDo from ctChucVu
	end
	else
	begin
		select MaNhanVien, ' ' as TenNV,  ' ' as TenCv, NgayBatDau, NgayKetThuc, LyDo from ctChucVu where MaNhanVien = @manv
	end

------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------Bảo Hiểm-----------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------

GO


Create proc [dbo].[LayLuongCB]
@hesoluong int
as
	select LuongCB From Luong where HeSoLuong = @hesoluong


------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------Bảng Chức Vụ-----------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------

GO


Create proc [dbo].[LayLuongCBTuHSL]
@hsl int
as
	select LuongCB from Luong where HeSoLuong = @hsl

-------------------------------------------------------------------------------------------------

GO


----Fixing---
Create Proc [dbo].[layMaCCTuTenNV]
@tennv nvarchar(50)
as
	select MaHD from NhanVien inner join ChamCong on NhanVien.MaNhanVien = ChamCong.MaNhanVien
	where TenNV = @tennv
-------------------------------------------------------------------------------------------------

GO


Create Proc [dbo].[layMaCVTuTenCV]
@tencv nvarchar(100)
as
	if(exists(select TenCV from ChucVu where TenCV = @tencv))
	begin
		select MaCV from ChucVu where TenCV = @tencv
	end
	else
		select err = 1

-------------------------------------------------------------------------------------------------

GO

Create Proc [dbo].[layMaHopDong]
@mahd varchar(5)
as
if(@mahd = '0')
begin
	select MaHD from HopDong
end
else 
begin
	select MaHD from HopDong where MaHD = @mahd
end

------------------------------------------------------------------------------------------------------

GO

Create Proc [dbo].[layMaHopDongTuMaNV]
@manv  varchar(5)
as
	select MaHD from NhanVien where MaNhanVien = @manv
-------------------------------------------------------------------------------------------------

GO

------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------Bảng Nhân Viên-----------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------

Create Proc [dbo].[LayMaNV]
@tendangnhap nvarchar(50)
as
if(@tendangnhap = '0')
begin
	select MaNhanVien from NhanVien
end
else 
begin
	select MaNhanVien from Taikhoan where TenDangNhap = @tendangnhap
end
-------------------------------------------------------------------------------------------------

GO


Create Proc [dbo].[layMaNVTuTenNV]
@tennv nvarchar(50)
as
	select MaNhanVien from NhanVien where TenNV = @tennv
-------------------------------------------------------------------------------------------------

GO


------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------Bảng Phòng Ban-----------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------

Create Proc [dbo].[layMaPBTuTenPB]
@tenpb nvarchar(100)
as
	if(exists(select TenPB from PhongBan where TenPB = @tenpb))
	begin
		select MaPB from PhongBan where TenPB = @tenpb
	end
	else
		select err = 1

-------------------------------------------------------------------------------------------------

GO


Create proc [dbo].[LayNgayVaoLam]
@manv varchar(5)
as
	select NgayVaoLam from NhanVien inner join HopDong on NhanVien.MaHD = HopDong.MaHD where MaNhanVien = @manv

-------------------------------------------------------------------------------------------------

GO


Create proc [dbo].[LayNhanVienTuMaPB]--'0','12-1-2016', '12-30-2016'
@mapb varchar(5),
@ngaydau date,
@ngaycuoi date
as
	if(@mapb = '0')
	begin
		select TenNV, Loai, Tien, LyDo
		from NhanVien left join ThuongPhat on NhanVien.MaNhanVien = ThuongPhat.MaNhanVien
		where (Ngay >= @ngaydau and Ngay <= @ngaycuoi) or Ngay is null
	end
	else
	begin
		select TenNV, Loai, Tien, LyDo
		from NhanVien left join ThuongPhat on NhanVien.MaNhanVien = ThuongPhat.MaNhanVien
		where (@mapb = MaPB and (Ngay >= @ngaydau and Ngay <= @ngaycuoi)) or Ngay is null
	end

------------------------------------------------------------------------------------------------

GO

Create proc [dbo].[LayPhongBan]
as
	begin
		select * from PhongBan
	end
GO


Create proc [dbo].[LayPhuCap]
@ma varchar(5)
as
	if(@ma = '0')
	begin
		select PhuCap.MaNhanVien, TenNV, LoaiPC, Tien, TuNgay, DenNgay from PhuCap left join NhanVien on PhuCap.MaNhanVien = NhanVien.MaNhanVien
		order by TuNgay Desc
	end
	else
	begin
		select PhuCap.MaNhanVien, TenNV, LoaiPC, Tien, TuNgay, DenNgay from PhuCap left join NhanVien on PhuCap.MaNhanVien = NhanVien.MaNhanVien
		where PhuCap.MaNhanVien = @ma
		order by TuNgay Desc
	end

---------------------------------------------------------------------------------------

GO


Create proc [dbo].[LayQuyenHanNV]
@taikhoan nvarchar(50),
@matkhau nvarchar(50)
as
	select TenQuyenHan from Taikhoan where TenDangNhap = @taikhoan and MatKhau = @matkhau


GO


Create Proc [dbo].[layTenNhanVien]
@manhanvien varchar(5)
as
if(@manhanvien = '0')
begin
	Select MaNhanVien, TenNV from NhanVien
end
else
begin
	select TenNV from NhanVien where MaNhanVien = @manhanvien
end

-------------------------------------------------------------------------------------------------

GO


Create Proc [dbo].[layTenPBTuMaNV]
@manv varchar(5)
as
	select TenPB  from NhanVien inner join PhongBan on NhanVien.MaPB = PhongBan.MaPB where MaNhanVien = @manv
-------------------------------------------------------------------------------------------------

GO



Create Proc [dbo].[LayThongTinNV]
@manhanvien varchar(5)
as
if(@manhanvien = 'NV')
begin
	select MaNhanVien, TenNV, GioiTinh, ChucVu.TenCV 
	from (NhanVien inner join HopDong on NhanVien.MaHD = HopDong.MaHD) inner join ChucVu on HopDong.MaCV = ChucVu.maCV
end
else
	select MaNhanVien, NhanVien.MaPB, MaCV, NhanVien.HeSoLuong, NhanVien.MaHD, TenNV, GioiTinh, NgaySinh, SoCM, DienThoai, TrinhDoHV, DiaChi, Email, TTHonNhan, Hinh
	from NhanVien inner join HopDong on NhanVien.MaHD = HopDong.MaHD where MaNhanVien = @manhanvien

-------------------------------------------------------------------------------------------------

GO

Create proc [dbo].[LayThuongPhatNhanVien]
@mapb varchar(5),
@ngaydau date,
@ngaycuoi date
as
	if(@mapb = '0')
	begin
		select TenNV, Loai, Tien, LyDo
		from NhanVien left join ThuongPhat on NhanVien.MaNhanVien = ThuongPhat.MaNhanVien
		where (Ngay >= @ngaydau and Ngay <= @ngaycuoi)
	end
	else
	begin
		select TenNV, Loai, Tien, LyDo
		from NhanVien left join ThuongPhat on NhanVien.MaNhanVien = ThuongPhat.MaNhanVien
		where (@mapb = MaPB and (Ngay >= @ngaydau and Ngay <= @ngaycuoi))
	end
GO

Create proc [dbo].[LayTienPhuCap]
@manv varchar(5),
@ngay date
as
	select MaNhanVien, Sum(Tien) as Tien From PhuCap 
	where MaNhanVien = @manv and (TuNgay <= @ngay and DenNgay >= @ngay)
	group by MaNhanVien

------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------Bảng Lương-----------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------

GO

Create proc [dbo].[LayTienThuong]
@manv varchar(5),
@ngaydau date,
@ngaycuoi date
as
	select Tien, Loai from ThuongPhat
	where MaNhanVien = @manv and (Ngay >= @ngaydau and Ngay <= @ngaycuoi)

-------
GO


Create Proc [dbo].[Ma]
@manv nvarchar(50)
as
	select NhanVien.MaPB, MaCV, NhanVien.HeSoLuong, NhanVien.MaHD from NhanVien inner join HopDong on NhanVien.MaHD = HopDong.MaHD where MaNhanVien = @manv

-------------------------------------------------------------------------------------------------

GO

Create Proc [dbo].[NvCoTK]
@ma varchar(5)
as
if(@ma = '0')
begin
	select NhanVien.MaNhanVien, TenNV, TenDangNhap, MatKhau, TenQuyenHan
	from NhanVien right join Taikhoan on NhanVien.MaNhanVien = Taikhoan.MaNhanVien
end
else
begin
	select MaNhanVien, TenDangNhap, MatKhau, TenQuyenHan
	from TaiKhoan
	where MaNhanVien = @ma
end
-------------------------------------------------------------------------------------------------

GO

Create Proc [dbo].[NvCTaiKhoan]
@ma varchar(5)
as
if(@ma = '0')
begin
	select NhanVien.MaNhanVien, TenNV, ChucVu.TenCv 
	from ((NhanVien inner join HopDong on NhanVien.MaHD = HopDong.MaHD) inner join ChucVu on HopDong.MaCV = ChucVu.MaCV) 
		left join Taikhoan on NhanVien.MaNhanVien = Taikhoan.MaNhanVien
	where TenDangNhap is null
end

-------------------------------------------------------------------------------------------------

GO

Create proc [dbo].[pcLayNhanVien]
@ma varchar(5)
as
	if(@ma = '0')
	begin
		select MaNhanVien, TenNV from NhanVien
	end

-----------------------------------------------------------------------------------------

GO

Create proc [dbo].[SuaBaoHiem]
@manv varchar(5),
@loaibhcu nvarchar(50),
@loaibhmoi nvarchar(50),
@sothe varchar(20),
@ngaycap date,
@ngayhethan date,
@noicap nvarchar(100)
as
	update BaoHiem set MaNhanVien = @manv, LoaiBaoHiem = @loaibhmoi, SoThe = @sothe, NgayCap = @ngaycap, NgayHetHan = @ngayhethan, NoiCap = @noicap
	where MaNhanVien = @manv and LoaiBaohiem = @loaibhcu

---------------------------------------------------------------------------------------

GO

Create proc [dbo].[SuactChucVu]
@manv varchar(5),
@macv varchar(5),
@ngaykt date
as
	update ctChucVu set NgayKetThuc = @ngaykt where MaCV = @macv and MaNhanVien = @manv

-------------------------------------------------------------------------------------------

GO


Create Proc [dbo].[SuaNhanVien]
@manv varchar(5),
@mapb varchar(5),
@hesoluong int,
@mahd varchar(5),
@tennv Nvarchar(50),
@gioitinh nvarchar(5),
@ngaysinh date,
@socm varchar(20),
@sodt varchar(20),
@trinhdo nvarchar(50),
@diachi nvarchar(100),
@email nvarchar(50),
@honnhan nvarchar(10),
@hinh nvarchar(50)
as
	update NhanVien
	set MaNhanVien = @manv, MaPB = @mapb, HeSoLuong = @hesoluong, MaHD = @mahd, TenNV = @tennv, GioiTinh = @gioitinh, 
		NgaySinh = @ngaysinh, SoCM = @socm, DienThoai = @sodt, TrinhDoHV = @trinhdo, DiaChi = @diachi, Email = @email, 
		TTHonNhan = @honnhan, Hinh = @hinh
	where MaNhanVien = @manv

-------------------------------------------------------------------------------------------------

GO

Create proc [dbo].[SuaPhuCap]
@manv varchar(5),
@loaipcc nvarchar(50),
@loaipcm nvarchar(50),
@tien int,
@tungay date,
@denngay date
as
	update PhuCap set LoaiPC = @loaipcm, Tien = @tien, TuNgay = @tungay, DenNgay = @denngay
	where MaNhanVien = @manv and LoaiPC = @loaipcc

---------------------------------------------------------------------------------------

GO

Create Proc [dbo].[SuaThongTinNhanVien]
@manv varchar(5),
@tennv nvarchar(50),
@mapb varchar(5),
@hesoluong int,
@gioitinh nvarchar(5),
@ngaysinh date,
@socm varchar(20),
@sodt varchar(20),
@trinhdo nvarchar(50),
@diachi nvarchar(100),
@email nvarchar(50),
@honnhan nvarchar(10),
@hinh nvarchar(50)
as
	update NhanVien
	set MaNhanVien = @manv, TenNV = @tennv, MaPB = @mapb, HeSoLuong = @hesoluong, GioiTinh = @gioitinh, 
		NgaySinh = @ngaysinh, SoCM = @socm, DienThoai = @sodt, TrinhDoHV = @trinhdo, DiaChi = @diachi, Email = @email, 
		TTHonNhan = @honnhan, Hinh = @hinh
	where MaNhanVien = @manv

-------------------------------------------------------------------------------------------------

GO

Create Proc [dbo].[SuaTK]
@manv varchar(5),
@maqh varchar(5),
@taikhoan nvarchar(50),
@matkhau nvarchar(50)
as
	update Taikhoan set MaNhanVien = @manv, TenQuyenHan = @maqh, TenDangNhap = @taikhoan, MatKhau = @matkhau
	where MaNhanVien = @manv

-------------------------------------------------------------------------------------------------

GO

Create proc [dbo].[TatCaChucVu]
as
	begin
		select * from ChucVu
	end
GO

Create proc [dbo].[TatCaNhanVien]
as
	begin
		select * from NhanVien
	end
GO

Create proc [dbo].[ThemBaoHiem]
@manv varchar(5),
@loaibh nvarchar(50),
@sothe varchar(20),
@ngaycap date,
@ngayhethan date,
@noicap nvarchar(100)
as
	insert into BaoHiem(MaNhanVien, LoaiBaoHiem, SoThe, NgayCap, NgayHetHan, NoiCap) values(@manv, @loaibh, @sothe, @ngaycap, @ngayhethan, @noicap)

---------------------------------------------------------------------------------------

GO

Create Proc [dbo].[ThemChamCong]
@manv varchar(5),
@ngay date,
@tinhtrang Nvarchar(20)
as
	insert into ChamCong(MaNhanVien, Ngay, TinhTrang) values (@manv, @ngay, @tinhtrang)
	
-------------------------------------------------------------------------------------------------

GO

Create proc [dbo].[ThemChucVu]
@macv varchar(5),
@tencv nvarchar(50)
as
	insert into ChucVu(MaCV, TenCv) values(@macv, @tencv)

----------------------------------------------------------------------------------------------------------------------

GO

Create proc [dbo].[ThemctChucVu]
@manv varchar(5),
@macv varchar(5),
@ngaybd date,
@lydo nvarchar(100)
as
	insert into ctChucVU(MaNhanVien, MaCV, NgayBatDau, LyDo) values(@manv, @macv, @ngaybd, @lydo)
GO

Create Proc [dbo].[ThemHopDong]
@mahd varchar(5),
@ngayvaolam date,
@hesoluong int,
@macv varchar(5),
@mapb varchar(5)
as
	insert into HopDong(MaHD, NgayVaoLam, HeSoLuong, MaCV, MaPB) 
	values(@mahd, @ngayvaolam,  @hesoluong, @macv, @mapb)

-------------------------------------------------------------------------------------------------

GO

Create Proc [dbo].[ThemNhanVien]
@manv varchar(5),
@tennv nvarchar(50),
@mapb varchar(5),
@hesoluong int,
@mahd varchar(5),
@gioitinh nvarchar(5),
@ngaysinh date,
@socm varchar(20),
@sodt varchar(20),
@trinhdo nvarchar(50),
@diachi nvarchar(100),
@email nvarchar(50),
@honnhan nvarchar(10),
@hinh  nvarchar(50)
as
	insert into NhanVien(MaNhanVien, TenNV, MaPB, HeSoLuong, MaHD, GioiTinh, NgaySinh, SoCM, DienThoai, TrinhDoHV, DiaChi, Email, TTHonNhan, Hinh )
	values (@manv, @tennv, @mapb, @hesoluong, @mahd, @gioitinh, @ngaysinh, @socm, @sodt, @trinhdo, @diachi, @email, @honnhan, @hinh)
-------------------------------------------------------------------------------------------------

GO


Create Proc [dbo].[ThemPhongBan]
@maphong varchar(5),
@tenphong nvarchar(20)
as
	if(not exists(select MaPB from PhongBan where MaPB = @maphong))
	begin
		insert into PhongBan(MaPB, TenPB) values(@maphong, @tenphong)
	end
	else
		select err = 1


-------------------------------------------------------------------------------------------------

GO

Create proc [dbo].[ThemPhuCap]
@manv varchar(5),
@loaipc nvarchar(50),
@tien int,
@tungay date,
@denngay date
as
	insert into PhuCap(MaNhanVien, LoaiPC, Tien, TuNgay, DenNgay) values(@manv, @loaipc, @tien, @tungay, @denngay)

---------------------------------------------------------------------------------------

GO

Create Proc [dbo].[ThemTaiKhoan]
@manv varchar(5),
@taikhoan nvarchar(50),
@matkhau nvarchar(50),
@tenquyenhan nvarchar(20)
as
if(not exists(select TenDangNhap from Taikhoan where TenDangNhap = @taikhoan))
begin
	insert into Taikhoan(MaNhanVien, TenDangNhap, MatKhau, TenQuyenHan)
			values(@manv, @taikhoan,@matkhau, @tenquyenhan)
	select err = '0'
end
else select err = '1'

-------------------------------------------------------------------------------------------------

GO

Create proc [dbo].[ThemThuongPhat]
@manv varchar(5),
@loai nvarchar(100),
@tien int,
@lydo nvarchar(100),
@ngay date
as
	insert into ThuongPhat(MaNhanVien, Loai, Tien, LyDo, Ngay) values(@manv, @loai, @tien, @lydo, @ngay)

------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------ctChucVu-----------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------

GO


Create Proc [dbo].[ThongTinNhanVien]
@manhanvien varchar(5)
as
	select MaNhanVien, TenNV, GioiTinh, NgaySinh, SoCM, DienThoai, TrinhDoHV, DiaChi, Email, TTHonNhan, Hinh, ChucVu.TenCV, PhongBan.TenPB, 
			NhanVien.HeSoLuong
	from ((NhanVien inner join PhongBan on NhanVien.MaPB = PhongBan.MaPB) inner join HopDong on NhanVien.MaHD = HopDong.MaHD)
	inner join ChucVu on HopDong.MaCV = ChucVu.MaCV
	where MaNhanVien = @manhanvien

-------------------------------------------------------------------------------------------------

GO
CREATE proc [dbo].[tkccXemTheoTenVaPhongBan]
@manv nvarchar(50),
@mapb nvarchar(20),
@ngaydau date,
@ngaycuoi date,
@khoa int
as
	if(@khoa = 1)
	begin
		select NhanVien.MaNhanVien, TenNV, TinhTrang, Ngay
		from NhanVien inner join ChamCong on NhanVien.MaNhanVien = ChamCong.MaNhanVien
		where NhanVien.MaNhanVien=@manv and Ngay >= @ngaydau and Ngay <= @ngaycuoi
		order by NhanVien.MaNhanVien
	end
	else
	begin
		select NhanVien.MaNhanVien, TenNV, TinhTrang, Ngay
		from (NhanVien inner join ChamCong on NhanVien.MaNhanVien = ChamCong.MaNhanVien) inner join PhongBan
				on NhanVien.MaPB = PhongBan.MaPB
		where PhongBan.MaPB = @mapb and Ngay >= @ngaydau and Ngay <= @ngaycuoi
		order by NhanVien.MaNhanVien
	end
GO

Create proc [dbo].[tkNhanVien]
@tukhoa nvarchar(100),
@gt int
as
if(@gt = 1)
begin 
	select MaNhanVien, TenNV, GioiTinh, ChucVu.TenCV 
	from ((NhanVien inner join HopDong on NhanVien.MaHD = HopDong.MaHD) inner join PhongBan on NhanVien.MaPB = PhongBan.MaPB) inner join ChucVu on HopDong.MaCV = ChucVu.MaCV
	where (TenNV like '%'+@tukhoa+'%' or SoCM like '%'+@tukhoa+'%' or DienThoai like '%'+@tukhoa+'%' or TrinhDoHV like '%'+@tukhoa+'%' or DiaChi like '%'+@tukhoa+'%' 
		or Email like '%'+@tukhoa+'%' or TTHonNhan like '%'+@tukhoa+'%' or TenCv like '%'+@tukhoa+'%' or TenPB like '%'+@tukhoa+'%') and GioiTinh = N'Nam'
end
else if(@gt = 2)
begin 
	select MaNhanVien, TenNV, GioiTinh, ChucVu.TenCV 
	from ((NhanVien inner join HopDong on NhanVien.MaHD = HopDong.MaHD) inner join PhongBan on NhanVien.MaPB = PhongBan.MaPB) inner join ChucVu on HopDong.MaCV = ChucVu.MaCV
	where (TenNV like '%'+@tukhoa+'%' or SoCM like '%'+@tukhoa+'%' or DienThoai like '%'+@tukhoa+'%' or TrinhDoHV like '%'+@tukhoa+'%' or DiaChi like '%'+@tukhoa+'%' 
		or Email like '%'+@tukhoa+'%' or TTHonNhan like '%'+@tukhoa+'%' or TenCv like '%'+@tukhoa+'%' or TenPB like '%'+@tukhoa+'%') and GioiTinh = N'Nữ'
end
else
begin
	select MaNhanVien, TenNV, GioiTinh, ChucVu.TenCV 
	from ((NhanVien inner join HopDong on NhanVien.MaHD = HopDong.MaHD) inner join PhongBan on NhanVien.MaPB = PhongBan.MaPB) inner join ChucVu on HopDong.MaCV = ChucVu.MaCV
	where (TenNV like '%'+@tukhoa+'%' or SoCM like '%'+@tukhoa+'%' or DienThoai like '%'+@tukhoa+'%' or TrinhDoHV like '%'+@tukhoa+'%' or DiaChi like '%'+@tukhoa+'%' 
		or Email like '%'+@tukhoa+'%' or TTHonNhan like '%'+@tukhoa+'%' or TenCv like '%'+@tukhoa+'%' or TenPB like '%'+@tukhoa+'%')
end
GO


Create proc [dbo].[tkNhanVienNghi]
@ngaydau date,
@ngaycuoi date,
@khoa int
as
	if(@khoa = 1)
	begin
		select NhanVien.MaNhanVien, TenNV, Ngay
		from NhanVien inner join ChamCong on NhanVien.MaNhanVien = ChamCong.MaNhanVien
		where Ngay = @ngaydau and TinhTrang = N'Nghỉ Không Phép'
	end
	else
	begin
		select NhanVien.MaNhanVien, TenNV, Ngay
		from NhanVien inner join ChamCong on NhanVien.MaNhanVien = ChamCong.MaNhanVien
		where Ngay >= @ngaydau and Ngay <= @ngaycuoi and TinhTrang = N'Nghỉ Không Phép'
	end

-----------------------------------------------------------------------------------------------------

GO

Create proc [dbo].[tkNhanVienNghiCoPhep]
@ngaydau date,
@ngaycuoi date,
@khoa int
as
	if(@khoa = 1)
	begin
		select NhanVien.MaNhanVien, TenNV, Ngay
		from NhanVien inner join ChamCong on NhanVien.MaNhanVien = ChamCong.MaNhanVien
		where Ngay = @ngaydau and TinhTrang = N'Nghỉ Có Phép'
	end
	else
	begin
		select NhanVien.MaNhanVien, TenNV, Ngay
		from NhanVien inner join ChamCong on NhanVien.MaNhanVien = ChamCong.MaNhanVien
		where Ngay >= @ngaydau and Ngay <= @ngaycuoi and TinhTrang = N'Nghỉ Có Phép'
	end
-----------------------------------------------------------------------------------------------------

GO

Create proc [dbo].[tkSoNgayDiLamCuaNhanVien]
@ngaydau date,
@ngaycuoi date,
@khoa int
as
	if(@khoa = 1)
	begin
		select distinct NhanVien.MaNhanVien, TenNV, count(TinhTrang) as SoNN
		from NhanVien inner join ChamCong on NhanVien.MaNhanVien = ChamCong.MaNhanVien
		where Ngay >= @ngaydau and Ngay <= @ngaycuoi and TinhTrang = N'Đi Làm'
		group by NhanVien.MaNhanVien, TenNV
	end
	else if(@khoa = 2)
	begin
		select distinct NhanVien.MaNhanVien, TenNV, count(TinhTrang) as SoNN
		from NhanVien inner join ChamCong on NhanVien.MaNhanVien = ChamCong.MaNhanVien
		where Ngay >= @ngaydau and Ngay <= @ngaycuoi and TinhTrang = N'Nghỉ Có Phép'
		group by NhanVien.MaNhanVien, TenNV
	end
	else
	begin
		select distinct NhanVien.MaNhanVien, TenNV, count(TinhTrang) as SoNN
		from NhanVien inner join ChamCong on NhanVien.MaNhanVien = ChamCong.MaNhanVien
		where Ngay >= @ngaydau and Ngay <= @ngaycuoi and TinhTrang = N'Nghỉ Không Phép'
		group by NhanVien.MaNhanVien, TenNV
	end
-----------------------------------------------------------------------------------------------------

GO
CREATE proc [dbo].[TongLuongNV]
@ma varchar(5)
as
if(@ma = '0')
begin
	select MaNhanVien, TenNV, NhanVien.HeSoLuong, '0' as NL, '0' as T, '0' as P, '0' as TL, '0' as PC
	From NhanVien inner join Luong on NhanVien.HeSoLuong = Luong.HeSoLuong
end
else 
begin
	select LuongCB from NhanVien inner join Luong on NhanVien.HeSoLuong = Luong.HeSoLuong
	where MaNhanVien = @ma
end
GO

Create proc [dbo].[TongTienPhat]
@ngaydau date,
@ngaycuoi date
as
	begin
		select sum(Tien) as Tien from ThuongPhat where Loai=N'Phạt' and Ngay>=@ngaydau and Ngay<=@ngaycuoi
	end


GO

Create proc [dbo].[TongTienPhuCap]
@ngaydau date,
@ngaycuoi date
as
	begin
		select sum(Tien) as Tien from PhuCap where  @ngaycuoi<=DenNgay
	end
GO

Create proc [dbo].[TongTienThuong]
@ngaydau date,
@ngaycuoi date
as
	begin
		select sum(Tien) as Tien from ThuongPhat where Loai=N'Thưởng' and Ngay>=@ngaydau and Ngay<=@ngaycuoi
	end


GO


Create proc [dbo].[XoaBaoHiem]
@manv varchar(5),
@loaibh nvarchar(50)
as
	delete BaoHiem where MaNhanVien = @manv and LoaiBaohiem = @loaibh

---------------------------------------------------------------------------------------

GO

Create proc [dbo].[XoaBaoHiemTheoNV]
@manv varchar(5)
as
	delete BaoHiem where MaNhanVien = @manv
------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------PhuCap-----------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------

GO

Create proc [dbo].[XoaCapNhat]
@macv varchar(5)
as
	delete ChucVu where MaCV = @macv
------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------Bảng Thưởng Phạt-----------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------

GO

Create Proc [dbo].[XoaChamCong]
@manv varchar(5)
as
	delete ChamCong where MaNhanVien = @manv

GO


Create Proc [dbo].[XoaChamCongTheoNgay]
@ngay date
as
	delete ChamCong where Ngay = @ngay
GO

Create proc [dbo].[XoactChucVu]
@manv varchar(5)
as
	delete ctChucVu where MaNhanVien = @manv

GO


Create Proc [dbo].[XoaHopDong]
@mahd varchar(5)
as
delete HopDong where MaHD = @mahd
-------------------------------------------------------------------------------------------------

GO


Create Proc [dbo].[XoaNhanVien]
@manv varchar(5)
as
	if(exists(select MaNhanVien from NhanVien where MaNhanVien = @manv))
	begin
		delete NhanVien where MaNhanVien = @manv
	end
	else 
		select err = 1
-------------------------------------------------------------------------------------------------

GO

CREATE Proc [dbo].[XoaPhongBan]
@maphong varchar(5)
as
	begin
		delete PhongBan where MaPB = @maphong
	end
GO


Create proc [dbo].[XoaPhuCap]
@manv varchar(5),
@loaipc nvarchar(50)
as
	delete PhuCap where MaNhanVien = @manv and LoaiPC = @loaipc

---------------------------------------------------------------------------------------

GO


Create proc [dbo].[XoaPhuCapTheoNV]
@manv varchar(5)
as
	delete PhuCap where MaNhanVien = @manv
------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------Thống Kê-----------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------

GO


Create proc [dbo].[XoaThuongPhat]
@manv varchar(5),
@loai nvarchar(100),
@tien int,
@lydo nvarchar(100)
as
	delete ThuongPhat where (MaNhanVien = @manv and Loai = @loai and Tien = @tien and LyDo = @lydo)

------------------------------------------------------------------------------------------------

GO


Create proc [dbo].[XoaThuongPhatTheoNV]
@manv varchar(5)
as
	delete ThuongPhat where MaNhanVien = @manv
------------------------------------------------------------------------------------------------

GO


Create Proc [dbo].[XoaTK]
@ma varchar(5)
as
	delete Taikhoan where MaNhanVien = @ma

-------------------------------------------------------------------------------------------------

GO
USE [master]
GO
ALTER DATABASE [QlNhanSu] SET  READ_WRITE 
GO
