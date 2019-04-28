using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhanSu.CT
{
    public partial class ChucVu : UserControl
    {
        public ChucVu()
        {
            InitializeComponent();
        }

        private CauLenh cl = new CauLenh();
        private SqlDataReader dr;
        private DataTable dt = new DataTable();

        private void load()
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            dt.Clear();
            dt = cl.LayChucVu("0");
            dataGridView1.DataSource = dt;
            btnLuu.Enabled = false;
            txtTenCV.Text = null;
            txtMaCV.Text = null;
            lbTB.Text = null;
        }

        private void ChucVu_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            txtTenCV.Text = null;
            txtMaCV.Text = "CV0";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //try
            //{
            bool check = false;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells["MaCV"].Value.ToString().Equals(txtMaCV.Text))
                {
                    Base.ShowErrorMessage(1, "Trùng mã chức vụ đã có!");
                    check = true;
                }
            }
            if ( check == false)
            {
                if (!string.IsNullOrEmpty(txtMaCV.Text))
                {
                    if (!string.IsNullOrEmpty(txtTenCV.Text))
                    {
                        dr = cl.ThemChucVu(txtMaCV.Text, txtTenCV.Text);
                        Base.ShowCompleteMessage(1, txtTenCV.Text);
                        load();
                    }
                    else
                    {
                        Base.ShowError("Không được bỏ trống tên chức vụ");
                        txtTenCV.Focus();
                    }
                }
                else
                {
                    Base.ShowError("Không được bỏ trống mã chức vụ");
                    txtMaCV.Focus();
                }
            }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Sai mã 'Chức Vụ'!!");
            //}
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtMaCV.Text))
                {
                    if (!string.IsNullOrEmpty(txtTenCV.Text))
                    {
                        dr = cl.CapNhatChucVu(txtMaCV.Text, txtTenCV.Text);
                        Base.ShowCompleteMessage(2, txtTenCV.Text);
                        load();
                    }
                    else
                    {
                        Base.ShowError("Không được bỏ trống tên chức vụ!!");
                        txtTenCV.Focus();
                    }
                }
                else
                {
                    Base.ShowError("Không được bỏ trống mã chức vụ!!");
                    txtMaCV.Focus();
                }
            }
            catch (Exception)
            {
                Base.ShowError("Vui lòng chuyển hết các nhân viên đang giữ chức vụ hiện tại trước khi sửa!!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (Base.ShowDialogResultMessage(txtTenCV.Text) == DialogResult.Yes)
                {
                    dr = cl.XoaCapNhat(txtMaCV.Text);
                    Base.ShowCompleteMessage(3, txtTenCV.Text);
                    load();
                }
            }
            catch (Exception)
            {
                Base.ShowError("Vui lòng chuyển hết nhân viên đang giữ chức vụ hiện tại trước khi xóa");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            txtMaCV.Text = dataGridView1.CurrentRow.Cells["MaCV"].Value.ToString();
            txtTenCV.Text = dataGridView1.CurrentRow.Cells["TenCV"].Value.ToString();
        }
    }
}