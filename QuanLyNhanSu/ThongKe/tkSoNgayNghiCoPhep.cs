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
    public partial class tkSoNgayNghiCoPhep : UserControl
    {
        public tkSoNgayNghiCoPhep()
        {
            InitializeComponent();
        }
        tkCauLenh tkcl = new tkCauLenh();
        DataTable dt = new DataTable();
        int thang = DateTime.Now.Month, nam = DateTime.Now.Year, ngay = DateTime.Now.Day;
        private void tkSoNgayNghiCoPhep_Load(object sender, EventArgs e)
        {
            load();
        }
        private void load()
        {
            btXem.Enabled = false;
        }
        private void btXem_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ngaydau = Convert.ToDateTime("01/" + Convert.ToInt32(cbThang.Text) + "/" + Convert.ToInt32(cbNam.Text) + " ");
                DateTime ngaycuoi = Convert.ToDateTime("29/" + Convert.ToInt32(cbThang.Text) + "/" + Convert.ToInt32(cbNam.Text) + " ");
                dt.Clear();
                dt = tkcl.tkSoNgayDiLamCuaNhanVien(ngaydau, ngaycuoi, 2);
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void cbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            btXem.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
