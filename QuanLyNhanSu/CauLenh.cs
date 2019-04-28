using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace QuanLyNhanSu
{
    public class CauLenh
    {
        public static string chuoiketnoi;
        SqlConnection con = new SqlConnection(chuoiketnoi);
        DataTable dt = new DataTable();
        public DataTable dangnhap(string tk, string mk)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            
            SqlCommand cm = new SqlCommand("DangNhap", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@taikhoan", tk);
            cm.Parameters.AddWithValue("@matkhau", mk);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
            return dt;
        }
        public SqlDataReader LayMaNhanVien(string tk)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("LayMaNV", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@tendangnhap", tk);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader LayQuyenHanNV(string tk, string mk)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("LayQuyenHanNV", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@taikhoan", tk);
            cm.Parameters.AddWithValue("@matkhau", mk);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader layMaNVTuTenNV(string tennv)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("layMaNVTuTenNV", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@tennv", tennv);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader LayTenNhanVien(string manhanvien)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("LayTenNhanVien", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manhanvien", manhanvien);
            dr = cm.ExecuteReader();
            return dr;
        }
        public DataTable LayTenNhanVien1(string manhanvien)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            SqlCommand cm = new SqlCommand("LayTenNhanVien", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manhanvien", manhanvien);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
            return dt;
        }
        public SqlDataReader LayThongTinNV(string manhanvien)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("LayThongTinNV", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manhanvien", manhanvien);
            dr = cm.ExecuteReader();
            return dr;
        }
        public DataTable LayThongTinNV1(string manhanvien)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlCommand cm = new SqlCommand("LayThongTinNV",con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manhanvien", manhanvien);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
            return dt;
        }

        public SqlDataReader ThongTinNhanVien(string manhanvien)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("ThongTinNhanVien", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manhanvien", manhanvien);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader SuaNhanVien(string manhanvien, string mapb, int hesoluong, string mahd, string tennv, string gioitinh,
                        DateTime ngaysinh, string socm, string sodt, string trinhdo, string diachi, string email, string honnhan, string hinh)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("SuaNhanVien", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manhanvien);
            cm.Parameters.AddWithValue("@mapb", mapb);
            cm.Parameters.AddWithValue("@hesoluong", hesoluong);
            cm.Parameters.AddWithValue("@mahd", mahd);
            cm.Parameters.AddWithValue("@tennv", tennv);
            cm.Parameters.AddWithValue("@gioitinh", gioitinh);
            cm.Parameters.AddWithValue("@ngaysinh", ngaysinh);
            cm.Parameters.AddWithValue("@socm", socm);
            cm.Parameters.AddWithValue("@sodt", sodt);
            cm.Parameters.AddWithValue("@trinhdo", trinhdo);
            cm.Parameters.AddWithValue("@diachi", diachi);
            cm.Parameters.AddWithValue("@email", email);
            cm.Parameters.AddWithValue("@honnhan", honnhan);
            cm.Parameters.AddWithValue("@hinh", hinh);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader DoiMatKhau(string manv, string taikhoan, string matkhau)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("DoiMatKhau", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            cm.Parameters.AddWithValue("@taikhoan", taikhoan);
            cm.Parameters.AddWithValue("@matkhaumoi", matkhau);
            dr = cm.ExecuteReader();
            return dr;
        }
        public DataTable HienPhongBan(string maphong)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlCommand cm = new SqlCommand("HienPhongBan", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@maphong", maphong);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
            return dt;
        }
        public SqlDataReader CapNhatPhongBan(string maphong, string tenphong)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("CapNhatPhongBan", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@maphong", maphong);
            cm.Parameters.AddWithValue("@tenphong", tenphong);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader XoaPhongBan(string maphong)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("XoaPhongBan", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@maphong", maphong);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader ThemPhongBan(string maphong, string tenphong)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("ThemPhongBan", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@maphong", maphong);
            cm.Parameters.AddWithValue("@tenphong", tenphong);
            dr = cm.ExecuteReader();
            return dr;
        }

        public SqlDataReader Ma(string manv)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("Ma", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader layMaPBTuTenPB(string tenpb)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("layMaPBTuTenPB", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@tenpb", tenpb);
            dr = cm.ExecuteReader();
            return dr;
        }
        public DataTable layMaPBTuTenPB1(string tenpb)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlCommand cm = new SqlCommand("layMaPBTuTenPB", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@tenpb", tenpb);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
            return dt;
        }
        public SqlDataReader layMaCVTuTenCV(string tencv)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("layMaCVTuTenCV", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@tencv", tencv);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader SuaThongTinNhanVien(string manv, string mapb, int hesoluong, string tennv, string gioitinh,
                        DateTime ngaysinh, string socm, string sodt, string trinhdo, string diachi, string email, string honnhan, string hinh)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("SuaThongTinNhanVien", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            cm.Parameters.AddWithValue("@tennv", tennv);
            cm.Parameters.AddWithValue("@mapb", mapb);
            cm.Parameters.AddWithValue("@hesoluong", hesoluong);
            cm.Parameters.AddWithValue("@gioitinh", gioitinh);
            cm.Parameters.AddWithValue("@ngaysinh", ngaysinh);
            cm.Parameters.AddWithValue("@socm", socm);
            cm.Parameters.AddWithValue("@sodt", sodt);
            cm.Parameters.AddWithValue("@trinhdo", trinhdo);
            cm.Parameters.AddWithValue("@diachi", diachi);
            cm.Parameters.AddWithValue("@email", email);
            cm.Parameters.AddWithValue("@honnhan", honnhan);
            cm.Parameters.AddWithValue("@hinh", hinh);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader XoaNhanVien(string manv)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("XoaNhanVien", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader XoaThuongPhatTheoNV(string manv)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("XoaThuongPhatTheoNV", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader XoaPhuCapTheoNV(string manv)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("XoaPhuCapTheoNV", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader XoaBaoHiemTheoNV(string manv)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("XoaBaoHiemTheoNV", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader XoaHopDong(string mahd)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("XoaHopDong", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@mahd", mahd);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader LayMaHopDong(string mahd)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("LayMaHopDong", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@mahd", mahd);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader ThemHopDong(string mahd, DateTime ngayvaolam, int hesoluong, string macv, string mapb)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("ThemHopDong", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@mahd", mahd);
            cm.Parameters.AddWithValue("@ngayvaolam", ngayvaolam);
            cm.Parameters.AddWithValue("@hesoluong", hesoluong);
            cm.Parameters.AddWithValue("@macv", macv);
            cm.Parameters.AddWithValue("@mapb", mapb);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader ThemNhanVien(string manv, string tennv, string mapb, int hesoluong, string mahd, string gioitinh,
                        DateTime ngaysinh, string socm, string sodt, string trinhdo, string diachi, string email, string honnhan, string hinh)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("ThemNhanVien", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            cm.Parameters.AddWithValue("@tennv", tennv);
            cm.Parameters.AddWithValue("@mapb", mapb);
            cm.Parameters.AddWithValue("@hesoluong", hesoluong);
            cm.Parameters.AddWithValue("@mahd", mahd);
            cm.Parameters.AddWithValue("@gioitinh", gioitinh);
            cm.Parameters.AddWithValue("@ngaysinh", ngaysinh);
            cm.Parameters.AddWithValue("@socm", socm);
            cm.Parameters.AddWithValue("@sodt", sodt);
            cm.Parameters.AddWithValue("@trinhdo", trinhdo);
            cm.Parameters.AddWithValue("@diachi", diachi);
            cm.Parameters.AddWithValue("@email", email);
            cm.Parameters.AddWithValue("@honnhan", honnhan);
            cm.Parameters.AddWithValue("@hinh", hinh);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader ThemctChucVu(string manv, string macv, DateTime ngaybd, string lydo)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("ThemctChucVu", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            cm.Parameters.AddWithValue("@macv", macv);
            cm.Parameters.AddWithValue("@ngaybd", ngaybd);
            cm.Parameters.AddWithValue("@lydo", lydo);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader XoactChucVu(string manv)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("XoactChucVu", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader layMaHopDongTuMaNV(string manv)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("layMaHopDongTuMaNV", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader CapNhatMaCvTrongHopDong(string mahd, string macv)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("CapNhatMaCvTrongHopDong", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@mahd", mahd);
            cm.Parameters.AddWithValue("@macv", macv);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader SuactChucVu(string manv, string macv, DateTime ngaykt)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("SuactChucVu", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            cm.Parameters.AddWithValue("@macv", macv);
            cm.Parameters.AddWithValue("@ngaykt", ngaykt);
            dr = cm.ExecuteReader();
            return dr;
        }
        public DataTable LayctChucVu(string manv)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlCommand cm = new SqlCommand("LayctChucVu", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
            return dt;
        }
        public DataTable NvCTaiKhoan(string ma)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlCommand cm = new SqlCommand("NvCTaiKhoan", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@ma", ma);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
            return dt;
        }
        public SqlDataReader ThemTaiKhoan(string manv, string taikhoan, string matkhau, string tenquyenhan)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("ThemTaiKhoan", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            cm.Parameters.AddWithValue("@taikhoan", taikhoan);
            cm.Parameters.AddWithValue("@matkhau", matkhau);
            cm.Parameters.AddWithValue("@tenquyenhan", tenquyenhan);
            dr = cm.ExecuteReader();
            return dr;
        }
        public DataTable NvCoTK(string ma)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlCommand cm = new SqlCommand("NvCoTK", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@ma", ma);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
            return dt;
        }
        public SqlDataReader NvCoTK1(string ma)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("NvCoTK", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@ma", ma);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader SuaTK(string manv, string maqh, string taikhoan, string matkhau)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("SuaTK", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            cm.Parameters.AddWithValue("@maqh", maqh);
            cm.Parameters.AddWithValue("@taikhoan", taikhoan);
            cm.Parameters.AddWithValue("@matkhau", matkhau);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader XoaTK(string ma)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("XoaTK", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@ma", ma);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader LayChamCong(string ma, DateTime ngay)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("LayChamCong", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@ma", ma);
            cm.Parameters.AddWithValue("@ngay", ngay);
            dr = cm.ExecuteReader();
            return dr;
        }
        public DataTable LayChamCong1(string ma, DateTime ngay)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlCommand cm = new SqlCommand("LayChamCong", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@ma", ma);
            cm.Parameters.AddWithValue("@ngay", ngay);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
            return dt;
        }
        public SqlDataReader XoaChamCong(string manv)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("XoaChamCong", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader XoaChamCongTheoNgay(DateTime ngay)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("XoaChamCongTheoNgay", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@ngay", ngay);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader ThemChamCong(string manv, DateTime ngay, string tinhtrang)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("ThemChamCong", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            cm.Parameters.AddWithValue("@ngay", ngay);
            cm.Parameters.AddWithValue("@tinhtrang", tinhtrang);
            dr = cm.ExecuteReader();
            return dr;
        }
        public DataTable TongLuongNV(string ma)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlCommand cm = new SqlCommand("TongLuongNV", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@ma", ma);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
            return dt;
        }
        public SqlDataReader TongLuongNV1(string manv)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("TongLuongNV", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@ma", manv);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader DemSoNgayLam(string manv, DateTime ngaydau, DateTime ngaycuoi)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("DemSoNgayLam", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            cm.Parameters.AddWithValue("@ngaydau", ngaydau);
            cm.Parameters.AddWithValue("@ngaycuoi", ngaycuoi);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader LayTienPhuCap(string manv, DateTime ngay)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("LayTienPhuCap", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            cm.Parameters.AddWithValue("@ngay", ngay);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader DemSoNgaynghiCoPhep(string manv, DateTime ngaydau, DateTime ngaycuoi)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("DemSoNgaynghiCoPhep", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            cm.Parameters.AddWithValue("@ngaydau", ngaydau);
            cm.Parameters.AddWithValue("@ngaycuoi", ngaycuoi);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader DemSoNgayNghiKhongPhep(string manv, DateTime ngaydau, DateTime ngaycuoi)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("DemSoNgayNghiKhongPhep", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            cm.Parameters.AddWithValue("@ngaydau", ngaydau);
            cm.Parameters.AddWithValue("@ngaycuoi", ngaycuoi);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader LayTienThuong(string manv, DateTime ngaydau, DateTime ngaycuoi)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("LayTienThuong", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            cm.Parameters.AddWithValue("@ngaydau", ngaydau);
            cm.Parameters.AddWithValue("@ngaycuoi", ngaycuoi);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader CapNhatLuong(int hesoluong, int luongcb)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("CapNhatLuong", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@hesoluong", hesoluong);
            cm.Parameters.AddWithValue("@luongcb", luongcb);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader LayLuongCB(int hesoluong)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("LayLuongCB", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@hesoluong", hesoluong);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader LayChucVuTuMaNV(string manv)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("LayChucVuTuMaNV", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader LayNgayVaoLam(string manv)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("LayNgayVaoLam", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader CapNhatNgayVaoLam(DateTime ngay, string manv)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("CapNhatNgayVaoLam", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@ngay", ngay);
            cm.Parameters.AddWithValue("@manv", manv);
            dr = cm.ExecuteReader();
            return dr;
        }
        public DataTable LayNhanVienTuMaPB(string mapb, DateTime ngaydau, DateTime ngaycuoi)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlCommand cm = new SqlCommand("LayNhanVienTuMaPB", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@mapb", mapb);
            cm.Parameters.AddWithValue("@ngaydau", ngaydau);
            cm.Parameters.AddWithValue("@ngaycuoi", ngaycuoi);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
            return dt;
        }
        public SqlDataReader XoaThuongPhat(string manv, string loai, int tien, string lydo)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("XoaThuongPhat", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            cm.Parameters.AddWithValue("@loai", loai);
            cm.Parameters.AddWithValue("@tien", tien);
            cm.Parameters.AddWithValue("@lydo", lydo);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader ThemThuongPhat(string manv, string loai, int tien, string lydo, DateTime ngay)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("ThemThuongPhat", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            cm.Parameters.AddWithValue("@loai", loai);
            cm.Parameters.AddWithValue("@tien", tien);
            cm.Parameters.AddWithValue("@lydo", lydo);
            cm.Parameters.AddWithValue("@ngay", ngay);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader layTenPBTuMaNV(string manv)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("layTenPBTuMaNV", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            dr = cm.ExecuteReader();
            return dr;
        }
        public DataTable LayChucVu(string ma)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlCommand cm = new SqlCommand("LayChucVu", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@ma", ma);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
            return dt;
        }
        public SqlDataReader ThemChucVu(string macv, string tencv)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("ThemChucVu", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@macv", macv);
            cm.Parameters.AddWithValue("@tencv", tencv);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader CapNhatChucVu(string macv, string tencv)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("CapNhatChucVu", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@macv", macv);
            cm.Parameters.AddWithValue("@tencv", tencv);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader XoaCapNhat(string macv)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("XoaCapNhat", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@macv", macv);
            dr = cm.ExecuteReader();
            return dr;
        }
        public DataTable LayBaoHiem(string ma, string loaibh)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlCommand cm = new SqlCommand("LayBaoHiem", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@ma", ma);
            cm.Parameters.AddWithValue("@loaibh", loaibh);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
            return dt;
        }
        public SqlDataReader LayBaoHiem1(string ma, string loaibh)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("LayBaoHiem", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@ma", ma);
            cm.Parameters.AddWithValue("@loaibh", loaibh);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader ThemBaoHiem(string manv, string loaibh, string sothe, DateTime ngaycap, DateTime ngayhethan, string noicap)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("ThemBaoHiem", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            cm.Parameters.AddWithValue("@loaibh", loaibh);
            cm.Parameters.AddWithValue("@sothe", sothe);
            cm.Parameters.AddWithValue("@ngaycap", ngaycap);
            cm.Parameters.AddWithValue("@ngayhethan", ngayhethan);
            cm.Parameters.AddWithValue("@noicap", noicap);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader SuaBaoHiem(string manv, string loaibhcu, string loaibhmoi, string sothe, DateTime ngaycap, DateTime ngayhethan, string noicap)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("SuaBaoHiem", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            cm.Parameters.AddWithValue("@loaibhcu", loaibhcu);
            cm.Parameters.AddWithValue("@loaibhmoi", loaibhmoi);
            cm.Parameters.AddWithValue("@sothe", sothe);
            cm.Parameters.AddWithValue("@ngaycap", ngaycap);
            cm.Parameters.AddWithValue("@ngayhethan", ngayhethan);
            cm.Parameters.AddWithValue("@noicap", noicap);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader XoaBaoHiem(string manv, string loaibh)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("XoaBaoHiem", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            cm.Parameters.AddWithValue("@loaibh", loaibh);
            dr = cm.ExecuteReader();
            return dr;
        }
        public DataTable pcLayNhanVien(string ma)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlCommand cm = new SqlCommand("pcLayNhanVien", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@ma", ma);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
            return dt;
        }
        public DataTable LayPhuCap(string ma)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlCommand cm = new SqlCommand("LayPhuCap", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@ma", ma);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
            return dt;
        }
        public SqlDataReader ThemPhuCap(string manv, string loaipc, int tien, DateTime tungay, DateTime denngay)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("ThemPhuCap", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            cm.Parameters.AddWithValue("@loaipc", loaipc);
            cm.Parameters.AddWithValue("@tien", tien);
            cm.Parameters.AddWithValue("@tungay", tungay);
            cm.Parameters.AddWithValue("@denngay", denngay);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader SuaPhuCap(string manv, string loaipcc, string loaipcm, int tien, DateTime tungay, DateTime denngay)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("SuaPhuCap", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            cm.Parameters.AddWithValue("@loaipcc", loaipcc);
            cm.Parameters.AddWithValue("@loaipcm", loaipcm);
            cm.Parameters.AddWithValue("@tien", tien);
            cm.Parameters.AddWithValue("@tungay", tungay);
            cm.Parameters.AddWithValue("@denngay", denngay);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader XoaPhuCap(string manv, string loaipc)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("XoaPhuCap", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            cm.Parameters.AddWithValue("@loaipc", loaipc);
            dr = cm.ExecuteReader();
            return dr;
        }
    }
}
