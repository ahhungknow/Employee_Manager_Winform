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
    public partial class PhuCap : UserControl
    {
        public PhuCap()
        {
            InitializeComponent();
        }
        CauLenh cl = new CauLenh();
        SqlDataReader dr;
        DataTable dt2 = new DataTable();
        public static string manv = null;
        public static string quyenhan = null;
        string ma = null, loai = null;
        string[] mang = null;
        int d = 0;
        private void PhanQuyen(string quyen)
        {
            if (quyen.Trim() == "User" || quyen.Trim() == "Admin")
            {
                btThem.Enabled = false;
                btSua.Enabled = false;
                btXoa.Enabled = false;
                btLuu.Enabled = false;
                dataGridView1.Enabled = false;
            }
        }
        private void PhuCap_Load(object sender, EventArgs e)
        {
            load();
        }
        private void load()
        {
            dt2.Clear();
            dt2 = cl.LayPhuCap("0");
            dataGridView1.DataSource = dt2;
            ThongKe.employeeName abc = new ThongKe.employeeName();
            panel1.Controls.Add(abc);
            btLuu.Enabled = false;
            btXoa.Enabled = false;
            btSua.Enabled = false;
            PhanQuyen(quyenhan);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void rdTat_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTat.Checked == true)
            {
                panel1.Enabled = false;
                d = 1;
            }
        }

        private void rdTen_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTen.Checked == true)
            {
                panel1.Enabled = true;
                d = 0;
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            btLuu.Enabled = true;
            txtTen.Clear();
            txtTien.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ThongKe.employeeName abcd = new ThongKe.employeeName(dataGridView1.CurrentRow.Cells["MaNhanVien"].Value.ToString());
            panel1.Controls.Clear();
            panel1.Controls.Add(abcd);
            txtTen.Text = dataGridView1.CurrentRow.Cells["TenPC"].Value.ToString();
            loai = dataGridView1.CurrentRow.Cells["TenPC"].Value.ToString();
            txtTien.Text = dataGridView1.CurrentRow.Cells["Tien"].Value.ToString();
            dtpTu.Text = dataGridView1.CurrentRow.Cells["TuNgay"].Value.ToString();
            dtpDen.Text = dataGridView1.CurrentRow.Cells["DenNgay"].Value.ToString();
            ma = dataGridView1.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            btSua.Enabled = true;
            btXoa.Enabled = true;
        }
        private void btLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (d == 0)
                    dr = cl.ThemPhuCap(manv, txtTen.Text, Convert.ToInt32(txtTien.Text), dtpTu.Value, dtpDen.Value);
                else
                {
                    string m = null;
                    dr = cl.LayMaNhanVien("0");
                    while (dr.Read())
                        m += dr.GetString(0) + " ";

                    m = m.Trim();
                    mang = m.Split(' ');
                    for (int i = 0; i < mang.Count(); i++)
                        dr = cl.ThemPhuCap(mang[i], txtTen.Text, Convert.ToInt32(txtTien.Text), dtpTu.Value, dtpDen.Value);
                }
                MessageBox.Show("Thêm phụ cấp thành công", "Phụ cấp", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                load();
            }
            catch
            {
                MessageBox.Show("Thêm phụ cấp không thành công!", "Phụ cấp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            try
            {
                dr = cl.SuaPhuCap(ma, loai, txtTen.Text, Convert.ToInt32(txtTien.Text), dtpTu.Value, dtpDen.Value);
                MessageBox.Show("Sửa phụ cấp thành công", "Phụ cấp", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                load();
            }
            catch
            {
                MessageBox.Show("Sửa phụ cấp không thành công!", "Phụ cấp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn thật sự muốn xóa?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    dr = cl.XoaPhuCap(ma, loai);
                    MessageBox.Show("Xóa phụ cấp thành công!", "Phụ cấp", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    load();
                }
            }
            catch
            {
                MessageBox.Show("Xóa phụ cấp không thành công!", "Phụ cấp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
