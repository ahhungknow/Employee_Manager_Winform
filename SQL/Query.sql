Use QlNhanSu
go

------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------Bảng Tài Khoản-----------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------
Create Proc [Dbo].[NvCTaiKhoan]
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
go

Create Proc [Dbo].[NvCoTK]
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
go

Create Proc [Dbo].[ThemTaiKhoan]
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
go

Create Proc [Dbo].[SuaTK]
@manv varchar(5),
@maqh varchar(5),
@taikhoan nvarchar(50),
@matkhau nvarchar(50)
as
	update Taikhoan set MaNhanVien = @manv, TenQuyenHan = @maqh, TenDangNhap = @taikhoan, MatKhau = @matkhau
	where MaNhanVien = @manv

-------------------------------------------------------------------------------------------------
go

Create Proc [Dbo].[XoaTK]
@ma varchar(5)
as
	delete Taikhoan where MaNhanVien = @ma

-------------------------------------------------------------------------------------------------
go

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
go

Create Proc [Dbo].[DoiMatKhau]
@manv varchar(5),
@taikhoan nvarchar(50),
@matkhaumoi nvarchar(50)
as
	update TaiKhoan set MaNhanVien = @manv, TenDangNhap = @taikhoan, MatKhau = @matkhaumoi
	where TenDangNhap = @taikhoan

-------------------------------------------------------------------------------------------------
go

Create proc [dbo].[LayQuyenHanNV]
@taikhoan nvarchar(50),
@matkhau nvarchar(50)
as
	select TenQuyenHan from Taikhoan where TenDangNhap = @taikhoan and MatKhau = @matkhau

go
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
go

Create Proc [dbo].[Ma]
@manv nvarchar(50)
as
	select NhanVien.MaPB, MaCV, NhanVien.HeSoLuong, NhanVien.MaHD from NhanVien inner join HopDong on NhanVien.MaHD = HopDong.MaHD where MaNhanVien = @manv

-------------------------------------------------------------------------------------------------
go

Create Proc [Dbo].[layTenNhanVien]
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
go

Create Proc [Dbo].[layMaNVTuTenNV]
@tennv nvarchar(50)
as
	select MaNhanVien from NhanVien where TenNV = @tennv
-------------------------------------------------------------------------------------------------
go


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
go


Create Proc [Dbo].[ThongTinNhanVien]
@manhanvien varchar(5)
as
	select MaNhanVien, TenNV, GioiTinh, NgaySinh, SoCM, DienThoai, TrinhDoHV, DiaChi, Email, TTHonNhan, Hinh, ChucVu.TenCV, PhongBan.TenPB, 
			NhanVien.HeSoLuong
	from ((NhanVien inner join PhongBan on NhanVien.MaPB = PhongBan.MaPB) inner join HopDong on NhanVien.MaHD = HopDong.MaHD)
	inner join ChucVu on HopDong.MaCV = ChucVu.MaCV
	where MaNhanVien = @manhanvien

-------------------------------------------------------------------------------------------------
go


Create Proc [Dbo].[SuaNhanVien]
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
go

Create Proc [Dbo].[SuaThongTinNhanVien]
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
go

Create Proc [Dbo].[XoaNhanVien]
@manv varchar(5)
as
	if(exists(select MaNhanVien from NhanVien where MaNhanVien = @manv))
	begin
		delete NhanVien where MaNhanVien = @manv
	end
	else 
		select err = 1
-------------------------------------------------------------------------------------------------
go

Create Proc [Dbo].[ThemNhanVien]
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
go

Create proc [dbo].[LayNgayVaoLam]
@manv varchar(5)
as
	select NgayVaoLam from NhanVien inner join HopDong on NhanVien.MaHD = HopDong.MaHD where MaNhanVien = @manv

-------------------------------------------------------------------------------------------------
go

Create proc [dbo].[CapNhatNgayVaoLam]
@ngay date,
@manv varchar(5)
as
	update HopDong set NgayVaoLam = @ngay from NhanVien inner join HopDong on NhanVien.MaHD = HopDong.MaHD where MaNhanVien = @manv
------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------Bảng Hợp Đồng-----------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------
go

Create Proc [Dbo].[layMaHopDong]
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
go

Create Proc [Dbo].[layMaHopDongTuMaNV]
@manv  varchar(5)
as
	select MaHD from NhanVien where MaNhanVien = @manv
-------------------------------------------------------------------------------------------------
go

Create Proc [Dbo].[ThemHopDong]
@mahd varchar(5),
@ngayvaolam date,
@hesoluong int,
@macv varchar(5),
@mapb varchar(5)
as
	insert into HopDong(MaHD, NgayVaoLam, HeSoLuong, MaCV, MaPB) 
	values(@mahd, @ngayvaolam,  @hesoluong, @macv, @mapb)

-------------------------------------------------------------------------------------------------
go

Create Proc [Dbo].[XoaHopDong]
@mahd varchar(5)
as
delete HopDong where MaHD = @mahd
-------------------------------------------------------------------------------------------------
go

Create Proc [Dbo].[CapNhatMaCvTrongHopDong]
@mahd varchar(5),
@macv varchar(5)
as
	update HopDong set MaCV = @macv where MaHD = @mahd
------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------Bảng Chấm Công-----------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------

go

Create Proc [Dbo].[ThemChamCong]
@manv varchar(5),
@ngay date,
@tinhtrang Nvarchar(20)
as
	insert into ChamCong(MaNhanVien, Ngay, TinhTrang) values (@manv, @ngay, @tinhtrang)
	
-------------------------------------------------------------------------------------------------
go

Create Proc [Dbo].[XoaChamCongTheoNgay]
@ngay date
as
	delete ChamCong where Ngay = @ngay


-------------------------------------------------------------------------------------------------
go

---Fixing xoa cham cong---
Create Proc [Dbo].[XoaChamCong]
@manv varchar(5)
as
	delete ChamCong where MaNhanVien = @manv

-------------------------------------------------------------------------------------------------
go

Create Proc [Dbo].[LayChamCong]
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
go

-------------------------------------------------------------------------------------------------
go

------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------Bảng Phòng Ban-----------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------

Create Proc [Dbo].[layMaPBTuTenPB]
@tenpb nvarchar(100)
as
	if(exists(select TenPB from PhongBan where TenPB = @tenpb))
	begin
		select MaPB from PhongBan where TenPB = @tenpb
	end
	else
		select err = 1

-------------------------------------------------------------------------------------------------
go

Create Proc [Dbo].[layMaCVTuTenCV]
@tencv nvarchar(100)
as
	if(exists(select TenCV from ChucVu where TenCV = @tencv))
	begin
		select MaCV from ChucVu where TenCV = @tencv
	end
	else
		select err = 1

-------------------------------------------------------------------------------------------------
go

Create Proc [Dbo].[layTenPBTuMaNV]
@manv varchar(5)
as
	select TenPB  from NhanVien inner join PhongBan on NhanVien.MaPB = PhongBan.MaPB where MaNhanVien = @manv
-------------------------------------------------------------------------------------------------
go

----Fixing---
Create Proc [Dbo].[layMaCCTuTenNV]
@tennv nvarchar(50)
as
	select MaHD from NhanVien inner join ChamCong on NhanVien.MaNhanVien = ChamCong.MaNhanVien
	where TenNV = @tennv
-------------------------------------------------------------------------------------------------
go
Create Proc [Dbo].[HienPhongBan]
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
go


Create Proc [Dbo].[CapNhatPhongBan]
@maphong varchar(5),
@tenphong nvarchar(20)
as
	update PhongBan set MaPB = @maphong, TenPB = @tenphong
	where MaPB = @maphong

-------------------------------------------------------------------------------------------------
go


Create Proc [Dbo].[XoaPhongBan]
@maphong varchar(5)
as
	if((not exists(select MaPB from NhanVien where MaPB = @maphong)) and (not exists (Select MaPB from HopDong where MaPB = @maphong)))
	begin
		delete PhongBan where MaPB = @maphong
	end
	else
		select err = 1

-------------------------------------------------------------------------------------------------
go


Create Proc [Dbo].[ThemPhongBan]
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
go

------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------Tính Lương-----------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------
go


Create proc [dbo].[DemSoNgayLam]
@manv varchar(5),
@ngaydau date,
@ngaycuoi date
as
	select MaNhanVien, COUNT(Ngay)as NgayLam from ChamCong 
	where MaNhanVien = @manv and (Ngay >= @ngaydau and Ngay <= @ngaycuoi) and TinhTrang = N'Đi Làm'
	Group By MaNhanVien

-------------------------------------------------------------------------------------------------
go

Create proc [dbo].[DemSoNgaynghiCoPhep]
@manv varchar(5),
@ngaydau date,
@ngaycuoi date
as
	select MaNhanVien, COUNT(Ngay)as NgayLam from ChamCong 
	where MaNhanVien = @manv and (Ngay >= @ngaydau and Ngay <= @ngaycuoi) and TinhTrang = N'Nghỉ Có Phép'
	Group By MaNhanVien

-------------------------------------------------------------------------------------------------
go

Create proc [dbo].[DemSoNgayNghiKhongPhep]
@manv varchar(5),
@ngaydau date,
@ngaycuoi date
as
	select MaNhanVien, COUNT(Ngay)as NgayLam from ChamCong 
	where MaNhanVien = @manv and (Ngay >= @ngaydau and Ngay <= @ngaycuoi) and TinhTrang = N'Nghỉ Không Phép'
	Group By MaNhanVien

-------------------------------------------------------------------------------------------------
go


---Fixing lay tien thuong---
Create proc [dbo].[LayTienThuong]
@manv varchar(5),
@ngaydau date,
@ngaycuoi date
as
	select Tien, Loai from ThuongPhat
	where MaNhanVien = @manv and (Ngay >= @ngaydau and Ngay <= @ngaycuoi)

-------------------------------------------------------------------------------------------------
go


Create proc [dbo].[TongLuongNV]
@ma varchar(5)
as
if(@ma = '0')
begin
	select MaNhanVien, TenNV, NhanVien.HeSoLuong, '0' as NL, '0' as T, '0' as P, '0' as Tien, '0' as TL
	From NhanVien inner join Luong on NhanVien.HeSoLuong = Luong.HeSoLuong
end
else 
begin
	select LuongCB from NhanVien inner join Luong on NhanVien.HeSoLuong = Luong.HeSoLuong
	where MaNhanVien = @ma
end

-------------------------------------------------------------------------------------------------
go

Create proc [dbo].[LayLuongCBTuHSL]
@hsl int
as
	select LuongCB from Luong where HeSoLuong = @hsl

-------------------------------------------------------------------------------------------------
go

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
go

Create proc [dbo].[CapNhatLuong]
@hesoluong int,
@luongcb int
as
	Update Luong set LuongCB = @luongcb where HeSoLuong = @hesoluong

-------------------------------------------------------------------------------------------------
go

Create proc [dbo].[LayLuongCB]
@hesoluong int
as
	select LuongCB From Luong where HeSoLuong = @hesoluong


------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------Bảng Chức Vụ-----------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------
go

Create proc [dbo].[LayChucVuTuMaNV]
@manv varchar(5)
as
	select TenCV from (NhanVien inner join HopDong on NhanVien.MaHD = HopDong.MaHD) inner join ChucVu on HopDong.MaCV = ChucVu.MaCV
	where MaNhanVien = @manv

----------------------------------------------------------------------------------------------------------------------
go

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
go

Create proc [dbo].[ThemChucVu]
@macv varchar(5),
@tencv nvarchar(50)
as
	insert into ChucVu(MaCV, TenCv) values(@macv, @tencv)

----------------------------------------------------------------------------------------------------------------------
go

Create proc [dbo].[CapNhatChucVu]
@macv varchar(5),
@tencv nvarchar(50)
as
	if(exists(select MaCV from ChucVu where MaCV = @macv))
	begin
		update ChucVu set MaCV = @macv, TenCV = @tencv where MaCV = @macv
	end

----------------------------------------------------------------------------------------------------------------------
go

Create proc [dbo].[XoaCapNhat]
@macv varchar(5)
as
	delete ChucVu where MaCV = @macv
------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------Bảng Thưởng Phạt-----------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------
go

Create proc [dbo].[LayNhanVienTuMaPB]
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
go

Create proc [dbo].[XoaThuongPhat]
@manv varchar(5),
@loai nvarchar(100),
@tien int,
@lydo nvarchar(100)
as
	delete ThuongPhat where (MaNhanVien = @manv and Loai = @loai and Tien = @tien and LyDo = @lydo)

------------------------------------------------------------------------------------------------
go

Create proc [dbo].[XoaThuongPhatTheoNV]
@manv varchar(5)
as
	delete ThuongPhat where MaNhanVien = @manv
------------------------------------------------------------------------------------------------
go

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
go

Create proc [dbo].[ThemctChucVu]
@manv varchar(5),
@macv varchar(5),
@ngaybd date,
@lydo nvarchar(100)
as
	insert into ctChucVU(MaNhanVien, MaCV, NgayBatDau, LyDo) values(@manv, @macv, @ngaybd, @lydo)

-------------------------------------------------------------------------------------------
go

---Fixing Xoa ct chuc vu----
Create proc [dbo].[XoactChucVu]
@manv varchar(5)
as
	delete ctChucVu where MaNhanVien = @manv

-------------------------------------------------------------------------------------------
go

Create proc [dbo].[SuactChucVu]
@manv varchar(5),
@macv varchar(5),
@ngaykt date
as
	update ctChucVu set NgayKetThuc = @ngaykt where MaCV = @macv and MaNhanVien = @manv

-------------------------------------------------------------------------------------------
go

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
go

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
go

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
go

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
go

Create proc [dbo].[XoaBaoHiem]
@manv varchar(5),
@loaibh nvarchar(50)
as
	delete BaoHiem where MaNhanVien = @manv and LoaiBaohiem = @loaibh

---------------------------------------------------------------------------------------
go

Create proc [dbo].XoaBaoHiemTheoNV
@manv varchar(5)
as
	delete BaoHiem where MaNhanVien = @manv
------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------PhuCap-----------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------
go

Create proc [dbo].[pcLayNhanVien]
@ma varchar(5)
as
	if(@ma = '0')
	begin
		select MaNhanVien, TenNV from NhanVien
	end

-----------------------------------------------------------------------------------------
go

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
go

Create proc [dbo].[ThemPhuCap]
@manv varchar(5),
@loaipc nvarchar(50),
@tien int,
@tungay date,
@denngay date
as
	insert into PhuCap(MaNhanVien, LoaiPC, Tien, TuNgay, DenNgay) values(@manv, @loaipc, @tien, @tungay, @denngay)

---------------------------------------------------------------------------------------
go

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
go

Create proc [dbo].[XoaPhuCap]
@manv varchar(5),
@loaipc nvarchar(50)
as
	delete PhuCap where MaNhanVien = @manv and LoaiPC = @loaipc

---------------------------------------------------------------------------------------
go

Create proc [dbo].[XoaPhuCapTheoNV]
@manv varchar(5)
as
	delete PhuCap where MaNhanVien = @manv
------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------Thống Kê-----------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------
go


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
go

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
go

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
go

Create proc [dbo].[tkccXemTheoTenVaPhongBan]
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
		where TenNV like @tennv and Ngay >= @ngaydau and Ngay <= @ngaycuoi
		order by NhanVien.MaNhanVien
	end
	else
	begin
		select NhanVien.MaNhanVien, TenNV, TinhTrang, Ngay
		from (NhanVien inner join ChamCong on NhanVien.MaNhanVien = ChamCong.MaNhanVien) inner join PhongBan
				on NhanVien.MaPB = PhongBan.MaPB
		where TenPB = @tenPB and Ngay >= @ngaydau and Ngay <= @ngaycuoi
		order by NhanVien.MaNhanVien
	end

-----------------------------------------------------------------------------------------------------
go

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

go

Create proc [dbo].[LayPhongBan]
as
	begin
		select * from PhongBan
	end

go

Create proc [dbo].[TatCaNhanVien]
as
	begin
		select * from NhanVien
	end


go

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


go

Create proc [dbo].[TongTienThuong]
@ngaydau date,
@ngaycuoi date
as
	begin
		select sum(Tien) as Tien from ThuongPhat where Loai=N'Thưởng' and Ngay>=@ngaydau and Ngay<=@ngaycuoi
	end

go

Create proc [dbo].[TongTienPhat]
@ngaydau date,
@ngaycuoi date
as
	begin
		select sum(Tien) as Tien from ThuongPhat where Loai=N'Phạt' and Ngay>=@ngaydau and Ngay<=@ngaycuoi
	end

go

Create proc [dbo].[TongTienPhuCap]
@ngaydau date,
@ngaycuoi date
as
	begin
		select sum(Tien) as Tien from PhuCap where  @ngaycuoi<=DenNgay
	end



