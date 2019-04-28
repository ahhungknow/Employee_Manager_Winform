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
    public partial class tkXemccTheoTen : UserControl
    {
        public tkXemccTheoTen()
        {
            InitializeComponent();
        }
        tkCauLenh tkcl = new tkCauLenh();
        CauLenh cl = new CauLenh();
        DataTable dt = new DataTable();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            btXem.Enabled = true;
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ngaydau = Convert.ToDateTime("01/" + Convert.ToInt32(cbThang.Text) + "/" + Convert.ToInt32(cbNam.Text) + " ");
                DateTime ngaycuoi = Convert.ToDateTime("29/" + Convert.ToInt32(cbThang.Text) + "/" + Convert.ToInt32(cbNam.Text) + " ");
                dt.Clear();
                dt = tkcl.tkccXemTheoTenVaPhongBan(cbTen.SelectedValue.ToString(), "abc", ngaydau, ngaycuoi, 1);
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi");
            }
        }
        private void load()
        {
            cbTen.DataSource = cl.TatCaNhanVien();
            cbTen.DisplayMember = "TenNV";
            cbTen.ValueMember = "MaNhanVien";
        }
        private void tkXemccTheoTen_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}
