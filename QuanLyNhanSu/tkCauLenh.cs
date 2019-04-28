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
    public class tkCauLenh
    {
        public static string chuoiketnoi;
        SqlConnection con = new SqlConnection(chuoiketnoi);
        DataTable dt = new DataTable();

        public DataTable tkNhanVienNghi(DateTime ngaydau, DateTime ngaycuoi, int khoa)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            SqlCommand cm = new SqlCommand("tkNhanVienNghi", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@ngaydau", ngaydau);
            cm.Parameters.AddWithValue("@ngaycuoi", ngaycuoi);
            cm.Parameters.AddWithValue("@khoa", khoa);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
            return dt;
        }
        public DataTable tkNhanVienNghiCoPhep(DateTime ngaydau, DateTime ngaycuoi, int khoa)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            SqlCommand cm = new SqlCommand("tkNhanVienNghiCoPhep", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@ngaydau", ngaydau);
            cm.Parameters.AddWithValue("@ngaycuoi", ngaycuoi);
            cm.Parameters.AddWithValue("@khoa", khoa);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
            return dt;
        }
        public DataTable tkccXemTheoTenVaPhongBan(string tennv, string tenpb, DateTime ngaydau, DateTime ngaycuoi, int khoa)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            SqlCommand cm = new SqlCommand("tkccXemTheoTenVaPhongBan", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@tennv", tennv);
            cm.Parameters.AddWithValue("@tenpb", tenpb);
            cm.Parameters.AddWithValue("@ngaydau", ngaydau);
            cm.Parameters.AddWithValue("@ngaycuoi", ngaycuoi);
            cm.Parameters.AddWithValue("@khoa", khoa);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
            return dt;
        }
        public DataTable tkSoNgayDiLamCuaNhanVien(DateTime ngaydau, DateTime ngaycuoi, int khoa)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            SqlCommand cm = new SqlCommand("tkSoNgayDiLamCuaNhanVien", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@ngaydau", ngaydau);
            cm.Parameters.AddWithValue("@ngaycuoi", ngaycuoi);
            cm.Parameters.AddWithValue("@khoa", khoa);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
            return dt;
        }
        public DataTable tkNhanVien(string tukhoa, int gt)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();

            SqlCommand cm = new SqlCommand("tkNhanVien", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@tukhoa", tukhoa);
            cm.Parameters.AddWithValue("@gt", gt);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
            return dt;
        }
    }
}
