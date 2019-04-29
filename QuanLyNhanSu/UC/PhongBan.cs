using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhanSu.CT
{
    public partial class PhongBan : UserControl
    {
        public PhongBan()
        {
            InitializeComponent();
        }

        private CauLenh cl = new CauLenh();
        private SqlDataReader dr;
        private DataTable dt = new DataTable();
        private string maphong = null, tenphong = null, sonv = null;

        private void load()
        {
            dt.Clear();
            dt = cl.HienPhongBan("0");
            dataGridView1.DataSource = dt;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            label5.Text = null;
            label6.Text = null;
            lbSoNV.Text = null;
        }

        private void PhongBan_Load(object sender, EventArgs e)
        {
            load();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            maphong = dataGridView1.CurrentRow.Cells["MaPB"].Value.ToString();
            tenphong = dataGridView1.CurrentRow.Cells["TenPB"].Value.ToString();
            sonv = dataGridView1.CurrentRow.Cells["SonNV"].Value.ToString();
            txtMaPB.Text = maphong;
            txtTen.Text = tenphong;
            lbSoNV.Text = sonv;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (Base.ShowDialogResultMessage(txtTen.Text) == DialogResult.Yes)
                {
                    dr = cl.XoaPhongBan(maphong);
                    Base.ShowCompleteMessage(3, txtTen.Text);
                    txtMaPB.ResetText();
                    txtTen.ResetText();
                }
            }
            catch (Exception ee)
            {
                Base.ShowError("Có lỗi xảy ra " + ee);
            }
            load();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaPB.Text))
            {
                if (!string.IsNullOrEmpty(txtTen.Text))
                {
                    dr = cl.CapNhatPhongBan(maphong, txtTen.Text);
                    Base.ShowCompleteMessage(2, txtTen.Text);
                    load();
                }
                else
                {
                    Base.ShowError("Không được để trống tên phòng ban!");
                }
            }
            else
            {
                Base.ShowError("Không được để trống mã phòng ban!");
            }
        }

        private void BtnLuu_Click_1(object sender, EventArgs e)
        {
            bool check = false;
            foreach(DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells["MaPB"].Value.ToString().Equals(txtMaPB.Text))
                {
                    Base.ShowErrorMessage(1, "Trùng mã phòng ban đã có!!");
                    check = true;
                }
            }

            if (!string.IsNullOrEmpty(txtMaPB.Text) && check==false)
            {
                if (!string.IsNullOrEmpty(txtTen.Text))
                {
                    dr = cl.ThemPhongBan(txtMaPB.Text, txtTen.Text);
                    Base.ShowCompleteMessage(1, txtTen.Text);
                    load();
                }
                else
                {
                    Base.ShowError("Không được bỏ trống tên phòng ban");
                }
            }
            else
            {
                Base.ShowError("Không được bỏ trống mã phòng ban");
            }

            
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaPB.Text = "PB0";
            label5.Text = null;
            label6.Text = null;
            label7.Text = null;
            txtTen.Text = null;
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
        }
    }
}