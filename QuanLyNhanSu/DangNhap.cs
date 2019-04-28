using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyNhanSu
{
    public partial class DangNhap : Form
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        CauLenh cl = new CauLenh();
        public static string chuoi;
        public DangNhap()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = null;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            KetNoi kn = new KetNoi();
            kn.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private string layQHNhanVien(string tk, string mk)
        {
            string qh = null;
            dr = cl.LayQuyenHanNV(tk, mk);
            while(dr.Read())
            {
                qh = dr.GetString(0);
            }
            return qh;
        }
        private string layTenNhanVien(string manv)
        {
            string ten = null;
            dr = cl.LayTenNhanVien(manv);
            while (dr.Read())
            {
                ten = dr.GetString(0);
            }
            return ten;
        }
        private string layMaNhanVien(string tk)
        {
            string manv = null;
            dr = cl.LayMaNhanVien(tk);
            while (dr.Read())
            {
                manv = dr.GetString(0);
            }
            return manv;
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTaiKhoan.Text))
            {
                if (!string.IsNullOrEmpty(txtMatKhau.Text))
                {
                    dt.Clear();
                    dt = cl.dangnhap(txtTaiKhoan.Text, txtMatKhau.Text);
                    if (dt.Rows[0]["err"].ToString() == "0")
                    {
                        QuanLy ql = new QuanLy();
                        CT.DoiThongTin.ma = layMaNhanVien(txtTaiKhoan.Text);
                        CT.DoiMatKhau.manv = layMaNhanVien(txtTaiKhoan.Text);
                        CT.DoiMatKhau.taikhoan = txtTaiKhoan.Text;
                        QuanLy.ten = layTenNhanVien(layMaNhanVien(txtTaiKhoan.Text));
                        QuanLy.quyenhan = layQHNhanVien(txtTaiKhoan.Text, txtMatKhau.Text);
                        this.Hide();
                        ql.Show();
                    }
                    else
                    {
                        label2.Text = " Lỗi!! Sai tài khoản hoặc mật khẩu";
                        txtTaiKhoan.Clear();
                        txtMatKhau.Clear();
                        txtTaiKhoan.Focus();
                    }
                }
                else
                {
                    label2.Text = " Lỗi!! nhập mật khẩu";
                    txtMatKhau.Focus();
                }
            }
            else
            {
                label2.Text = " Lỗi!! Nhập tài khoản của bạn";
                txtTaiKhoan.Focus();
            }
        }


    }
}
