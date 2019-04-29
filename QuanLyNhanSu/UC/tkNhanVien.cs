using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace QuanLyNhanSu.CT
{
    public partial class tkNhanVien : UserControl
    {
        public tkNhanVien()
        {
            InitializeComponent();
        }
        CauLenh cl = new CauLenh();
        tkCauLenh tkcl = new tkCauLenh();
        DataTable dt = new DataTable();
        private void lbH_Click(object sender, EventArgs e)
        {
            txtH.Text = "VD: Tên nhân viên, quê quán, chức vụ, phòng ban....";
        }

        private void txtH_Click(object sender, EventArgs e)
        {
            txtH.Text = "";
        }
        private void load()
        {
            dt.Clear();
            dt = cl.LayThongTinNV1("NV");
            dataGridView1.DataSource = dt;
        }
        private void tkNhanVien_Load(object sender, EventArgs e)
        {
            load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtH.Text))
            {
                if (txtH.Text.ToLower() == "all")
                    load();
                else
                {
                    int gt = 0;
                    if (radioButton1.Checked == true)
                        gt = 0;
                    if (radioButton2.Checked == true)
                        gt = 1;
                    if (radioButton3.Checked == true)
                        gt = 2;
                    dt.Clear();
                    dt = tkcl.tkNhanVien(txtH.Text, gt);
                    dataGridView1.DataSource = dt;
                }
            }
            else
                MessageBox.Show("Nhập nội dung cần tìm trước");
        }

    }
}
