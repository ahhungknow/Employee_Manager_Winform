using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace QuanLyNhanSu.CT
{
    public partial class TinhLuong : UserControl
    {
        public TinhLuong()
        {
            InitializeComponent();
        }
        CauLenh cl = new CauLenh();
        SqlDataReader dr;
        DataTable dt = new DataTable();
        int thang = DateTime.Now.Month, nam = DateTime.Now.Year, ngay = DateTime.Now.Day, luongcoban = 0, tongluong = 0, tienthuong = 0, tienphat = 0, phucap = 0, m = 0;
        string manv = null, songaylam = null, songaynghicophep = null, songaynghikhongphep = null, chucvu = null;
        private void load()
        {
            DateTime ngaydau, ngaycuoi;
            songaylam = "0"; luongcoban = 0; tongluong = 0; tienthuong = 0; tienphat = 0; phucap = 0;
            if(m == 0)
            {
                ngaydau = Convert.ToDateTime( "01/" + thang + "/" + nam);
                ngaycuoi = Convert.ToDateTime("30/" + thang + "/" + nam);
            }
            else
            {
                ngaydau = Convert.ToDateTime( "01/" + txtThang.Text + "/" + txtNam.Text);
                ngaycuoi = Convert.ToDateTime("30/" + txtThang.Text + "/" + txtNam.Text);
            }
            btCapNhat.Enabled = false;
            lbTen.Text = null;
            lbChucVu.Text = null;
            lbTB.Text = null;
            dt.Clear();
            dt = cl.TongLuongNV("0");
            dataGridView1.DataSource = dt;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                manv = dataGridView1.Rows[i].Cells["Ma"].Value.ToString();
                dataGridView1.Rows[i].Cells["SNL"].Value = LaySoNgayLam(manv, ngaydau, ngaycuoi);
                dataGridView1.Rows[i].Cells["T"].Value = TienThuong(manv, ngaydau, ngaycuoi);
                dataGridView1.Rows[i].Cells["P"].Value = TienPhat(manv, ngaydau, ngaycuoi);
                dataGridView1.Rows[i].Cells["PC"].Value = tienPhuCap(manv, ngaycuoi);
                tongluong = TinhLuong1(manv, songaylam, tienthuong.ToString(), tienphat.ToString(), ngaydau, ngaycuoi);
                dataGridView1.Rows[i].Cells["TL"].Value = String.Format("{0:0,0}", tongluong);
                //MessageBox.Show(songaylam + "\n" + tienthuong + "\n" + tienphat + "\n" + tongluong.ToString());

            }
         
        }
        private string LaySoNgayLam(string manv, DateTime ngaydau, DateTime ngaycuoi)
        {
            dr = cl.DemSoNgayLam(manv, ngaydau, ngaycuoi);
            while (dr.Read())
            {
                songaylam = dr.GetInt32(1).ToString();
            }
            return songaylam;
        }
        private string NghiKhongPhep(string manv, DateTime ngaydau, DateTime ngaycuoi)
        {
            dr = cl.DemSoNgayNghiKhongPhep(manv, ngaydau, ngaycuoi);
            while (dr.Read())
            {
                songaynghikhongphep = dr.GetInt32(1).ToString();
            }
            return songaynghikhongphep;
        }
        private string NghiCoPhep(string manv, DateTime ngaydau, DateTime ngaycuoi)
        {
            dr = cl.DemSoNgaynghiCoPhep(manv, ngaydau, ngaycuoi);
            while (dr.Read())
            {
                songaynghicophep = dr.GetInt32(1).ToString();
            }
            return songaynghicophep;
        }
        private int TienThuong(string manv, DateTime nd, DateTime nc)
        {
            tienthuong = 0;
            string ld = null;
            int tien = 0;
            try
            {
                dr = cl.LayTienThuong(manv, nd, nc);
                while (dr.Read())
                {
                    
                    tien = dr.GetInt32(0);
                    ld = dr.GetString(1);
                    if (ld == "Thưởng")
                        tienthuong += tien;
                }
            }
            catch (Exception)
            {
                tienthuong = 0;
            }

            return tienthuong;
        }
        private int TienPhat(string manv, DateTime nd, DateTime nc)
        {
            tienphat = 0;
            string ld = null;
            int tien = 0;
            try
            {
                dr = cl.LayTienThuong(manv, nd, nc);
                while (dr.Read())
                {

                    tien = dr.GetInt32(0);
                    ld = dr.GetString(1);
                    if (ld == "Phạt")
                        tienphat += tien;
                }
            }
            catch (Exception)
            {
                tienphat = 0;
            }

            return tienphat;
        }
        private int LayLuongCoBan(string manv)
        {
            dr = cl.TongLuongNV1(manv);
            while (dr.Read())
            {
                luongcoban = dr.GetInt32(0);
            }
            return luongcoban;
        }
        private string LayChucVuTuMaNV1(string manv)
        {
            dr = cl.LayChucVuTuMaNV(manv);
             while (dr.Read())
            {
                chucvu = dr.GetString(0);
            }
             return chucvu;
        }
        private int tienPhuCap(string manv, DateTime n)
        {
            phucap = 0;
            try
            {
                dr = cl.LayTienPhuCap(manv, n);
                while (dr.Read())
                    phucap += dr.GetInt32(1);
            }
            catch (Exception)
            {

                phucap = 0;
            }
            return phucap;
        }
        private int TinhLuong1(string manv, string soNgayLam, string tienThuong, string tienPhat, DateTime ngaydau, DateTime ngaycuoi)
        {
            
            int a = Convert.ToInt32(tienThuong) - Convert.ToInt32(tienPhat);
            int ncp = Convert.ToInt32(NghiCoPhep(manv, ngaydau, ngaycuoi));
            int nkp = Convert.ToInt32(NghiKhongPhep(manv, ngaydau, ngaycuoi));
            int luongCoBan = LayLuongCoBan(manv);
            int nl = Convert.ToInt32(songaylam);
            int p = tienPhuCap(manv,ngaycuoi);
            if (ncp > 3)
                nl = nl - nkp - (ncp % 3);
            else
                nl = nl - nkp + ncp;
            tongluong = ((luongCoBan / 22) * nl) + a + p;
            //MessageBox.Show(ncp.ToString() + "\n" + nl.ToString() + "\n" + a.ToString() + "\n" + tongluong.ToString());
            return tongluong;
        }
        private void TinhLuong_Load(object sender, EventArgs e)
        {
            load();
            txtThang.Text = "05";
            txtNam.Text = "2019";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lbTen.Text = dataGridView1.CurrentRow.Cells["TenNV"].Value.ToString();
            cbHeSoLuong.Text = dataGridView1.CurrentRow.Cells["HeSoLuong"].Value.ToString();
            btCapNhat.Enabled = true;
            txtLCB.Text = LayLuongCoBan(dataGridView1.CurrentRow.Cells["Ma"].Value.ToString()).ToString();
            lbChucVu.Text = LayChucVuTuMaNV1(dataGridView1.CurrentRow.Cells["Ma"].Value.ToString());
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(cbHeSoLuong.Text);
            if(!string.IsNullOrEmpty(cbHeSoLuong.Text))
            {
                if(!string.IsNullOrEmpty(txtLCB.Text))
                {
                    if (a > 0 && a < 11)
                    {
                        dr = cl.CapNhatLuong(Convert.ToInt32(cbHeSoLuong.Text), Convert.ToInt32(txtLCB.Text));
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Không tồn tại Hệ số lương đang nhập");
                        cbHeSoLuong.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi!!");
                    txtLCB.Focus();
                }
            }
            else
            {
                MessageBox.Show("Lỗi!!");
                cbHeSoLuong.Focus();
            }
        }

        private void cbHeSoLuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(cbHeSoLuong.Text);
            if (a > 0 && a < 11)
            {
                dr = cl.LayLuongCB(a);
                while (dr.Read())
                    txtLCB.Text = dr.GetInt32(0).ToString();
                btCapNhat.Enabled = true;
            }
            else
            {

            }
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtThang.Text))
            {
                if (!string.IsNullOrEmpty(txtNam.Text))
                {
                    if (Convert.ToInt32(txtThang.Text) > 12 || Convert.ToInt32(txtThang.Text) < 1)
                    {
                        lbTB.Text = "Tháng không hợp lệ";
                    }
                    else
                    {
                        m = 1;
                        dataGridView1.Refresh();
                        load();
                        lbTB.Text = null;
                    }
                }
                else
                {
                    lbTB.Text = "Lỗi";
                }
            }
            else
            {
                lbTB.Text = "Lỗi";
            }
           
        }

        private void txtThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
