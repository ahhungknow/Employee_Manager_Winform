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
    public partial class employeeName : UserControl
    {
        public employeeName()
        {
            InitializeComponent();
        }
        CauLenh cl = new CauLenh();
        DataTable dt1 = new DataTable();
        private void abc_Load(object sender, EventArgs e)
        {
            layTenNhanVien();
        }
        private void layTenNhanVien()
        {
                dt1.Clear();
                dt1 = cl.pcLayNhanVien("0");
                cbTen.DataSource = dt1;
                cbTen.DisplayMember = "TenNV";
                cbTen.ValueMember = "MaNhanVien";
        }
        private void cbTen_SelectedIndexChanged(object sender, EventArgs e)
        {
                CT.PhuCap.manv = cbTen.SelectedValue.ToString();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
