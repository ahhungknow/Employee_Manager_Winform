use QlNhanSu
go
-----------------------------------------------------------------------------------------------------------------------
insert into PhongBan(MaPB, TenPB) values('PB01',N'Phòng Giám Đốc')
insert into PhongBan(MaPB, TenPB) values('PB02',N'Phòng Phó Giám Đốc')
insert into PhongBan(MaPB, TenPB) values('PB03',N'Phòng Kinh Doanh')
insert into PhongBan(MaPB, TenPB) values('PB04',N'Phòng Kế Toán')
insert into PhongBan(MaPB, TenPB) values('PB05',N'Phòng Kỹ Thuật')

-----------------------------------------------------------------------------------------------------------------------
insert into ChucVu(MaCV, TenCV) values('CV01',N'Giám Đốc')
insert into ChucVu(MaCV, TenCV) values('CV02',N'Phó Giám Đốc')
insert into ChucVu(MaCV, TenCV) values('CV03',N'Trưởng Phòng')
insert into ChucVu(MaCV, TenCV) values('CV04',N'Phó Phòng')
insert into ChucVu(MaCV, TenCV) values('CV05',N'Nhân Viên')

-----------------------------------------------------------------------------------------------------------------------
insert into Luong(HeSoLuong, LuongCB) values(10,15000000)
insert into Luong(HeSoLuong, LuongCB) values(9,12000000)
insert into Luong(HeSoLuong, LuongCB) values(8,10000000)
insert into Luong(HeSoLuong, LuongCB) values(7,7000000)
insert into Luong(HeSoLuong, LuongCB) values(6,5000000)
insert into Luong(HeSoLuong, LuongCB) values(5,4500000)
insert into Luong(HeSoLuong, LuongCB) values(4,4000000)
insert into Luong(HeSoLuong, LuongCB) values(3,3800000)
insert into Luong(HeSoLuong, LuongCB) values(2,3700000)
insert into Luong(HeSoLuong, LuongCB) values(1,3500000)


-----------------------------------------------------------------------------------------------------------------------
insert into HopDong(MaHD,NgayVaoLam,HeSoLuong,MaCV,MaPB) values('HD01','2014/01/25',10,'CV01','PB01')
insert into HopDong(MaHD,NgayVaoLam,HeSoLuong,MaCV,MaPB) values('HD02','2014/01/25',9,'CV02','PB02')

insert into HopDong(MaHD,NgayVaoLam,HeSoLuong,MaCV,MaPB) values('HD03','2014/01/25',8,'CV03','PB03')
insert into HopDong(MaHD,NgayVaoLam,HeSoLuong,MaCV,MaPB) values('HD04','2014/01/25',8,'CV03','PB04')
insert into HopDong(MaHD,NgayVaoLam,HeSoLuong,MaCV,MaPB) values('HD05','2014/01/25',8,'CV03','PB05')

insert into HopDong(MaHD,NgayVaoLam,HeSoLuong,MaCV,MaPB) values('HD06','2014/01/25',7,'CV04','PB03')
insert into HopDong(MaHD,NgayVaoLam,HeSoLuong,MaCV,MaPB) values('HD07','2014/01/25',7,'CV04','PB04')

insert into HopDong(MaHD,NgayVaoLam,HeSoLuong,MaCV,MaPB) values('HD08','2014/01/25',6,'CV05','PB03')
insert into HopDong(MaHD,NgayVaoLam,HeSoLuong,MaCV,MaPB) values('HD09','2014/01/25',6,'CV05','PB03')
insert into HopDong(MaHD,NgayVaoLam,HeSoLuong,MaCV,MaPB) values('HD10','2014/01/25',6,'CV05','PB03')
insert into HopDong(MaHD,NgayVaoLam,HeSoLuong,MaCV,MaPB) values('HD11','2014/01/25',6,'CV05','PB03')
insert into HopDong(MaHD,NgayVaoLam,HeSoLuong,MaCV,MaPB) values('HD12','2014/01/25',6,'CV05','PB03')
insert into HopDong(MaHD,NgayVaoLam,HeSoLuong,MaCV,MaPB) values('HD13','2014/01/25',6,'CV05','PB03')

insert into HopDong(MaHD,NgayVaoLam,HeSoLuong,MaCV,MaPB) values('HD14','2014/01/25',6,'CV05','PB04')
insert into HopDong(MaHD,NgayVaoLam,HeSoLuong,MaCV,MaPB) values('HD15','2014/01/25',6,'CV05','PB04')

insert into HopDong(MaHD,NgayVaoLam,HeSoLuong,MaCV,MaPB) values('HD16','2014/01/25',6,'CV05','PB05')
insert into HopDong(MaHD,NgayVaoLam,HeSoLuong,MaCV,MaPB) values('HD17','2014/01/25',6,'CV05','PB05')
insert into HopDong(MaHD,NgayVaoLam,HeSoLuong,MaCV,MaPB) values('HD18','2014/01/25',6,'CV05','PB05')

-----------------------------------------------------------------------------------------------------------------------
Insert Into NhanVien(MaNhanVien, MaPB, HeSoLuong, MaHD, TenNV, GioiTinh, NgaySinh, SoCM, DienThoai, TrinhDoHV, DiaChi, Email, TTHonNhan, Hinh)
		Values('NV01','PB01',10,'HD01',N'Trần Dũng Lộc',N'Nam','1985/09/02',88888888,01638345699,N'Đại Học',N'Biên Hòa, Đồng nai','@gmail.com',N'Đã Kết Hôn','Hinh/TaoTaikhoan.png')
Insert Into NhanVien(MaNhanVien, MaPB, HeSoLuong, MaHD, TenNV, GioiTinh, NgaySinh, SoCM, DienThoai, TrinhDoHV, DiaChi, Email, TTHonNhan, Hinh)
		Values('NV02','PB02',9,'HD02',N'Trần Thanh Hiền',N'Nam','1985/09/02',88888888,01638345699,N'Đại Học',N'Biên Hòa, Đồng nai','@gmail.com',N'Đã Kết Hôn','Hinh/TaoTaikhoan.png')

Insert Into NhanVien(MaNhanVien, MaPB, HeSoLuong, MaHD, TenNV, GioiTinh, NgaySinh, SoCM, DienThoai, TrinhDoHV, DiaChi, Email, TTHonNhan, Hinh)
		Values('NV03','PB03',8,'HD03',N'Trương Minh Sang',N'Nam','1985/09/02',88888888,01638345699,N'Đại Học',N'Biên Hòa, Đồng nai','@gmail.com',N'Đã Kết Hôn','Hinh/TaoTaikhoan.png')
Insert Into NhanVien(MaNhanVien, MaPB, HeSoLuong, MaHD, TenNV, GioiTinh, NgaySinh, SoCM, DienThoai, TrinhDoHV, DiaChi, Email, TTHonNhan, Hinh)
		Values('NV04','PB04',8,'HD04',N'Nguyễn Thị Lệ Thu',N'Nữ','1985/09/02',88888888,01638345699,N'Đại Học',N'Biên Hòa, Đồng nai','@gmail.com',N'Đã Kết Hôn','Hinh/TaoTaikhoan.png')
Insert Into NhanVien(MaNhanVien, MaPB, HeSoLuong, MaHD, TenNV, GioiTinh, NgaySinh, SoCM, DienThoai, TrinhDoHV, DiaChi, Email, TTHonNhan, Hinh)
		Values('NV05','PB05',8,'HD05',N'Trần Minh Siêu',N'Nam','1985/09/02',88888888,01638345699,N'Đại Học',N'Biên Hòa, Đồng nai','@gmail.com',N'Đã Kết Hôn','Hinh/TaoTaikhoan.png')

Insert Into NhanVien(MaNhanVien, MaPB, HeSoLuong, MaHD, TenNV, GioiTinh, NgaySinh, SoCM, DienThoai, TrinhDoHV, DiaChi, Email, TTHonNhan, Hinh)
		Values('NV06','PB03',7,'HD06',N'Trần Ngọc Tuyết',N'Nữ','1985/09/02',88888888,01638345699,N'Đại Học',N'Biên Hòa, Đồng nai','@gmail.com',N'Đã Kết Hôn','Hinh/TaoTaikhoan.png')
Insert Into NhanVien(MaNhanVien, MaPB, HeSoLuong, MaHD, TenNV, GioiTinh, NgaySinh, SoCM, DienThoai, TrinhDoHV, DiaChi, Email, TTHonNhan, Hinh)
		Values('NV07','PB05',7,'HD07',N'Nguyễn Hữu Minh',N'Nam','1985/09/02',88888888,01638345699,N'Đại Học',N'Biên Hòa, Đồng nai','@gmail.com',N'Đã Kết Hôn','Hinh/TaoTaikhoan.png')

Insert Into NhanVien(MaNhanVien, MaPB, HeSoLuong, MaHD, TenNV, GioiTinh, NgaySinh, SoCM, DienThoai, TrinhDoHV, DiaChi, Email, TTHonNhan, Hinh)
		Values('NV08','PB03',6,'HD08',N'Huỳnh Thị Yến Lê',N'Nữ','1985/09/02',88888888,01638345699,N'Đại Học',N'Biên Hòa, Đồng nai','@gmail.com',N'Đã Kết Hôn','Hinh/TaoTaikhoan.png')
Insert Into NhanVien(MaNhanVien, MaPB, HeSoLuong, MaHD, TenNV, GioiTinh, NgaySinh, SoCM, DienThoai, TrinhDoHV, DiaChi, Email, TTHonNhan, Hinh)
		Values('NV09','PB03',6,'HD09',N'Nguyễn Thị Kim Thoa',N'Nữ','1985/09/02',88888888,01638345699,N'Đại Học',N'Biên Hòa, Đồng nai','@gmail.com',N'Đã Kết Hôn','Hinh/TaoTaikhoan.png')
Insert Into NhanVien(MaNhanVien, MaPB, HeSoLuong, MaHD, TenNV, GioiTinh, NgaySinh, SoCM, DienThoai, TrinhDoHV, DiaChi, Email, TTHonNhan, Hinh)
		Values('NV10','PB03',6,'HD10',N'Nguyễn Thị Bích Hằng',N'Nữ','1985/09/02',88888888,01638345699,N'Đại Học',N'Biên Hòa, Đồng nai','@gmail.com',N'Đã Kết Hôn','Hinh/TaoTaikhoan.png')
Insert Into NhanVien(MaNhanVien, MaPB, HeSoLuong, MaHD, TenNV, GioiTinh, NgaySinh, SoCM, DienThoai, TrinhDoHV, DiaChi, Email, TTHonNhan, Hinh)
		Values('NV11','PB03',6,'HD11',N'Hồ Mạnh Tiến',N'Nam','1985/09/02',88888888,01638345699,N'Đại Học',N'Biên Hòa, Đồng nai','@gmail.com',N'Đã Kết Hôn','Hinh/TaoTaikhoan.png')
Insert Into NhanVien(MaNhanVien, MaPB, HeSoLuong, MaHD, TenNV, GioiTinh, NgaySinh, SoCM, DienThoai, TrinhDoHV, DiaChi, Email, TTHonNhan, Hinh)
		Values('NV12','PB03',6,'HD12',N'Nguyễn Tăng Quốc',N'Nam','1985/09/02',88888888,01638345699,N'Đại Học',N'Biên Hòa, Đồng nai','@gmail.com',N'Đã Kết Hôn','Hinh/TaoTaikhoan.png')

Insert Into NhanVien(MaNhanVien, MaPB, HeSoLuong, MaHD, TenNV, GioiTinh, NgaySinh, SoCM, DienThoai, TrinhDoHV, DiaChi, Email, TTHonNhan, Hinh)
		Values('NV13','PB04',6,'HD13',N'Lê Thị Tịnh',N'Nữ','1985/09/02',88888888,01638345699,N'Đại Học',N'Biên Hòa, Đồng nai','@gmail.com',N'Đã Kết Hôn','Hinh/TaoTaikhoan.png')
Insert Into NhanVien(MaNhanVien, MaPB, HeSoLuong, MaHD, TenNV, GioiTinh, NgaySinh, SoCM, DienThoai, TrinhDoHV, DiaChi, Email, TTHonNhan, Hinh)
		Values('NV14','PB04',6,'HD14',N'Bùi Thị Sương',N'Nữ','1985/09/02',88888888,01638345699,N'Đại Học',N'Biên Hòa, Đồng nai','@gmail.com',N'Đã Kết Hôn','Hinh/TaoTaikhoan.png')

Insert Into NhanVien(MaNhanVien, MaPB, HeSoLuong, MaHD, TenNV, GioiTinh, NgaySinh, SoCM, DienThoai, TrinhDoHV, DiaChi, Email, TTHonNhan, Hinh)
		Values('NV15','PB05',6,'HD15',N'Bùi Văn Long',N'Nam','1985/09/02',88888888,01638345699,N'Đại Học',N'Biên Hòa, Đồng nai','@gmail.com',N'Đã Kết Hôn','Hinh/TaoTaikhoan.png')
Insert Into NhanVien(MaNhanVien, MaPB, HeSoLuong, MaHD, TenNV, GioiTinh, NgaySinh, SoCM, DienThoai, TrinhDoHV, DiaChi, Email, TTHonNhan, Hinh)
		Values('NV16','PB05',6,'HD16',N'Đỗ Hữu Tiến',N'Nam','1985/09/02',88888888,01638345699,N'Đại Học',N'Biên Hòa, Đồng nai','@gmail.com',N'Đã Kết Hôn','Hinh/TaoTaikhoan.png')
Insert Into NhanVien(MaNhanVien, MaPB, HeSoLuong, MaHD, TenNV, GioiTinh, NgaySinh, SoCM, DienThoai, TrinhDoHV, DiaChi, Email, TTHonNhan, Hinh)
		Values('NV17','PB05',6,'HD17',N'Phạm Văn Mạnh',N'Nam','1985/09/02',88888888,01638345699,N'Đại Học',N'Biên Hòa, Đồng nai','@gmail.com',N'Đã Kết Hôn','Hinh/TaoTaikhoan.png')

-----------------------------------------------------------------------------------------------------------------------
insert into Taikhoan(MaNhanVien, TenQuyenHan, TenDangNhap, MatKhau) values('NV01','Super Admin','admin','admin')
insert into Taikhoan(MaNhanVien, TenQuyenHan, TenDangNhap, MatKhau) values('NV02','Admin','admin1','admin')

-----------------------------------------------------------------------------------------------------------------------
insert into ctChucVu(MaNhanVien, MaCV, NgayBatDau, LyDo) values('NV01','CV01','10/01/2014',N'Tuyển Nhân Viên')
insert into ctChucVu(MaNhanVien, MaCV, NgayBatDau, LyDo) values('NV02','CV02','10/01/2014',N'Tuyển Nhân Viên')
insert into ctChucVu(MaNhanVien, MaCV, NgayBatDau, LyDo) values('NV03','CV03','10/01/2014',N'Tuyển Nhân Viên')
insert into ctChucVu(MaNhanVien, MaCV, NgayBatDau, LyDo) values('NV04','CV03','10/01/2014',N'Tuyển Nhân Viên')
insert into ctChucVu(MaNhanVien, MaCV, NgayBatDau, LyDo) values('NV05','CV03','10/01/2014',N'Tuyển Nhân Viên')
insert into ctChucVu(MaNhanVien, MaCV, NgayBatDau, LyDo) values('NV06','CV04','10/01/2014',N'Tuyển Nhân Viên')
insert into ctChucVu(MaNhanVien, MaCV, NgayBatDau, LyDo) values('NV07','CV04','10/01/2014',N'Tuyển Nhân Viên')
insert into ctChucVu(MaNhanVien, MaCV, NgayBatDau, LyDo) values('NV08','CV05','10/01/2014',N'Tuyển Nhân Viên')
insert into ctChucVu(MaNhanVien, MaCV, NgayBatDau, LyDo) values('NV09','CV05','10/01/2014',N'Tuyển Nhân Viên')
insert into ctChucVu(MaNhanVien, MaCV, NgayBatDau, LyDo) values('NV10','CV05','10/01/2014',N'Tuyển Nhân Viên')
insert into ctChucVu(MaNhanVien, MaCV, NgayBatDau, LyDo) values('NV11','CV05','10/01/2014',N'Tuyển Nhân Viên')
insert into ctChucVu(MaNhanVien, MaCV, NgayBatDau, LyDo) values('NV12','CV05','10/01/2014',N'Tuyển Nhân Viên')
insert into ctChucVu(MaNhanVien, MaCV, NgayBatDau, LyDo) values('NV13','CV05','10/01/2014',N'Tuyển Nhân Viên')
insert into ctChucVu(MaNhanVien, MaCV, NgayBatDau, LyDo) values('NV14','CV05','10/01/2014',N'Tuyển Nhân Viên')
insert into ctChucVu(MaNhanVien, MaCV, NgayBatDau, LyDo) values('NV15','CV05','10/01/2014',N'Tuyển Nhân Viên')
insert into ctChucVu(MaNhanVien, MaCV, NgayBatDau, LyDo) values('NV16','CV05','10/01/2014',N'Tuyển Nhân Viên')
insert into ctChucVu(MaNhanVien, MaCV, NgayBatDau, LyDo) values('NV17','CV05','10/01/2014',N'Tuyển Nhân Viên')
-----------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------------------