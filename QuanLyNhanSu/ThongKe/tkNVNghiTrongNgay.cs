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

namespace QuanLyNhanSu.ThongKe
{
    public partial class tkNVNghiTrongNgay : UserControl
    {
        public tkNVNghiTrongNgay()
        {
            InitializeComponent();
        }
        tkCauLenh tkcl = new tkCauLenh();
        DataTable dt = new DataTable();
        int thang = DateTime.Now.Month, nam = DateTime.Now.Year, ngay = DateTime.Now.Day;
        DateTime n;
        private void btXem_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ngaydau = Convert.ToDateTime( "01/" + Convert.ToInt32(cbThang.Text) + "/" + Convert.ToInt32(cbNam.Text) + " ");
                DateTime ngaycuoi = Convert.ToDateTime("29/" + Convert.ToInt32(cbThang.Text) + "/" + Convert.ToInt32(cbNam.Text) + " ");
                if (radioButton1.Checked == true)
                {
                    try
                    {
                        n = Convert.ToDateTime( Convert.ToInt32(txtNgay.Text) + "/" + Convert.ToInt32(cbThang.Text) + "/" + Convert.ToInt32(cbNam.Text));
                        dt.Clear();
                        dt = tkcl.tkNhanVienNghi(n, n, 1);
                        dtgv.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
                else
                {
                    txtNgay.Enabled = false;
                    try
                    {
                        dt.Clear();
                        dt = tkcl.tkNhanVienNghi(ngaydau, ngaycuoi, 0);
                        dtgv.DataSource = dt;
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập đầy đủ thông tin!!");
            }
            
        }

        private void load()
        {
            txtNgay.Enabled = false;
            cbThang.Enabled = false;
            cbNam.Enabled = false;
            btXem.Enabled = false;
        }
        private void tkNVNghiTrongNgay_Load(object sender, EventArgs e)
        {
            load();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtNgay.Enabled = true;
            cbThang.Enabled = true;
            cbNam.Enabled = true;
            btXem.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtNgay.Enabled = false;
            cbThang.Enabled = true;
            cbNam.Enabled = true;
            btXem.Enabled = true;
        }
    }
}
