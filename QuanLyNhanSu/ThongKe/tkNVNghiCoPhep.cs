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
    public partial class tkNVNghiCoPhep : UserControl
    {
        public tkNVNghiCoPhep()
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
                DateTime ngaydau = Convert.ToDateTime("01/" + Convert.ToInt32(cbThang.Text) + "/" + Convert.ToInt32(cbNam.Text) + " ");
                DateTime ngaycuoi = Convert.ToDateTime("29/" + Convert.ToInt32(cbThang.Text) + "/" + Convert.ToInt32(cbNam.Text) + " ");
                if (rdNTN.Checked == true)
                {
                    try
                    {
                        n = Convert.ToDateTime(Convert.ToInt32(Convert.ToInt32(txtNgay.Text) + "/" + cbThang.Text) + "/" + Convert.ToInt32(cbNam.Text));
                        dt.Clear();
                        dt = tkcl.tkNhanVienNghiCoPhep(n, n, 1);
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
                        dt = tkcl.tkNhanVienNghiCoPhep(ngaydau, ngaycuoi, 0);
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
        private void tkNVNghiCoPhep_Load(object sender, EventArgs e)
        {
            load();
        }

        private void rdNTN_CheckedChanged(object sender, EventArgs e)
        {
            txtNgay.Enabled = true;
            cbThang.Enabled = true;
            cbNam.Enabled = true;
            btXem.Enabled = true;
        }

        private void rdT_CheckedChanged(object sender, EventArgs e)
        {
            txtNgay.Enabled = false;
            cbThang.Enabled = true;
            cbNam.Enabled = true;
            btXem.Enabled = true;
        }
    }
}
