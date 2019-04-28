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
    public partial class tkXemccTheoPhong : UserControl
    {
        public tkXemccTheoPhong()
        {
            InitializeComponent();
        }
        tkCauLenh tkcl = new tkCauLenh();
        CauLenh cl = new CauLenh();
        DataTable dt = new DataTable();
        private void btXem_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ngaydau = Convert.ToDateTime("01/" + Convert.ToInt32(cbThang.Text) + "/" + Convert.ToInt32(cbNam.Text) + " ");
                DateTime ngaycuoi = Convert.ToDateTime("29/" + Convert.ToInt32(cbThang.Text) + "/" + Convert.ToInt32(cbNam.Text) + " ");
                dt.Clear();
                dt = tkcl.tkccXemTheoTenVaPhongBan("abc", cbPhong.SelectedValue.ToString(), ngaydau, ngaycuoi, 0);
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi");
            }
        }
        private void load()
        {
             
            cbPhong.DataSource= cl.LayPhongBan();
            cbPhong.DisplayMember = "TenPB";
            cbPhong.ValueMember = "MaPB";
        }
        private void tkXemccTheoPhong_Load(object sender, EventArgs e)
        {
            load();
        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {
            btXem.Enabled = true;
        }

        private void txtTen_MouseHover(object sender, EventArgs e)
        {

        }
    }
}
