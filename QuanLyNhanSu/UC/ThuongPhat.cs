using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhanSu.CT
{
    public partial class ThuongPhat : UserControl
    {
        public ThuongPhat()
        {
            InitializeComponent();
        }

        private CauLenh cl = new CauLenh();
        private DataTable dt = new DataTable();
        private SqlDataReader dr;
        private string mapb = null, manv = null, tenpb = null;
        private string tennv = null, loai = null;
        private int tien = 0, thang = DateTime.Now.Month, nam = DateTime.Now.Year;
        private DateTime nd, nc;

        private void load()
        {
            nd = Convert.ToDateTime("1/" + thang + "/" + nam);
            nc = Convert.ToDateTime("30/" + thang + "/" + nam);
            txtLyDo.Enabled = false;
            txtT.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            rdThuong.Enabled = false;
            rdPhat.Enabled = false;
            cbThang.Text = thang.ToString(); ;
            cbNam.Text = nam.ToString();
            dt.Clear();
            dt = cl.LayNhanVienTuMaPB("0", nd, nc);
            dataGridView1.DataSource = dt;
        }

        private void ThuongPhat_Load(object sender, EventArgs e)
        {
            load();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLyDo.Enabled = false;
            txtT.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            txtLyDo.Text = null;
            txtT.Text = null;
            dt.Clear();
            dt = cl.LayNhanVienTuMaPB(mapb, nd, nc);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            btnLuu.Enabled = false;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            rdThuong.Enabled = true;
            rdPhat.Enabled = true;
            tennv = dataGridView1.CurrentRow.Cells["TenNhanVien"].Value.ToString();
            if (dataGridView1.CurrentRow.Cells["Loai"].Value.ToString() == "Thưởng")
            {
                rdThuong.Checked = true;
                loai = "Thưởng";
            }
            else
            {
                rdPhat.Checked = true;
                loai = "Phạt";
            }

            txtLyDo.Text = dataGridView1.CurrentRow.Cells["LyDo"].Value.ToString();
            txtT.Text = dataGridView1.CurrentRow.Cells["VND"].Value.ToString();
            //cbPhongBan.Text = layTenPhongBan(layMaNhanVien(tennv));
        }

        private string layMaNhanVien(string tennv)
        {
            dr = cl.layMaNVTuTenNV(tennv);
            while (dr.Read())
                manv = dr.GetString(0);
            return manv;
        }

        private void Label7_Click(object sender, EventArgs e)
        {
        }

        private void Label2_Click(object sender, EventArgs e)
        {
        }

        private void RdPhat_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void RdThuong_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void Label5_Click(object sender, EventArgs e)
        {
        }

        private void Label6_Click(object sender, EventArgs e)
        {
        }

        private void TxtT_TextChanged(object sender, EventArgs e)
        {
        }

        private string layTenPhongBan(string ma)
        {
            dr = cl.layTenPBTuMaNV(ma);
            while (dr.Read())
                tenpb = dr.GetString(0);
            return tenpb;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtLyDo.Enabled = true;
            txtT.Enabled = true;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            rdThuong.Enabled = true;
            btnThem.Enabled = false;
            rdPhat.Enabled = true;
            txtLyDo.Text = null;
            txtT.Text = null;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (rdPhat.Checked == true)
                loai = "Phạt";
            else loai = "Thưởng";
            if (!string.IsNullOrEmpty(txtLyDo.Text))
            {
                if (!string.IsNullOrEmpty(txtT.Text))
                {
                    dr = cl.ThemThuongPhat(layMaNhanVien(tennv), loai, Convert.ToInt32(txtT.Text), txtLyDo.Text, DateTime.Now);
                    MessageBox.Show("Đã thêm thưởng/phạt cho nhân viên " + tennv, "Thưởng/Phạt", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    btnThem.Enabled = true;
                    load();
                }
                else
                {
                    Base.ShowError("Không được bỏ trống số tiền");
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            load();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (rdPhat.Checked == true)
                loai = "Phạt";
            else loai = "Thưởng";
            if (Base.ShowDialogResultMessage("thưởng/phạt của " + tennv) == DialogResult.Yes)
            {
                dr = cl.XoaThuongPhat(layMaNhanVien(tennv), loai, Convert.ToInt32(txtT.Text), txtLyDo.Text);
                Base.ShowCompleteMessage(3, " thưởng/phạt của " + tennv);
                load();
            }
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            nd = Convert.ToDateTime("1/" + cbThang.Text + "/" + cbNam.Text);
            nc = Convert.ToDateTime("30/" + cbThang.Text + "/" + cbNam.Text);
            dt.Clear();
            dt = cl.LayNhanVienTuMaPB("0", nd, nc);
            dataGridView1.DataSource = dt;
        }
    }
}