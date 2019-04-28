using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhanSu.CT
{
    public partial class TaoTaiKhoan : UserControl
    {
        public TaoTaiKhoan()
        {
            InitializeComponent();
        }

        private CauLenh cl = new CauLenh();
        private DataTable dt = new DataTable();
        private SqlDataReader dr1;
        private bool check = false;
        private string manv = null;
        private int dem = 0;

        private void load()
        {
            dem = 0;
            dt.Clear();
            dt = cl.NvCTaiKhoan("0");
            dataGridView1.DataSource = dt;
            btnLuu.Enabled = false;
            timer1.Start();
            txtTK.Clear();
            txtMK.Clear();
            cbQuyen.Text = null;
            lbMaNV.Text = null;
            cbQuyen.Enabled = false;
            txtMK.Enabled = false;
            txtTK.Enabled = false;
        }

        private void TaoTaiKhoan_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            timer1.Start();
            try
            {
                if (!string.IsNullOrEmpty(txtTK.Text))
                {
                    if (!string.IsNullOrEmpty(txtMK.Text))
                    {
                        if (!string.IsNullOrEmpty(cbQuyen.Text))
                        {
                            dr1 = cl.ThemTaiKhoan(manv, txtTK.Text, txtMK.Text, cbQuyen.Text);
                            while (dr1.Read())
                            {
                                if (dr1.GetString(0) == "0")
                                {
                                    Base.ShowCompleteMessage(1, txtTK.Text);
                                    check = true;
                                    load();
                                }
                                else
                                {
                                    Base.ShowErrorMessage(1, " Tài Khoản Đã Tồn Tại");
                                    check = false;
                                    txtTK.Clear();
                                    txtTK.Focus();
                                }
                            }
                        }
                        else
                        {
                            Base.ShowErrorMessage(1, "Chưa chọn quyền hạn");
                            cbQuyen.Focus();
                            timer1.Stop();
                        }
                    }
                    else
                    {
                        Base.ShowErrorMessage(1, "Chưa nhập mật khẩu");
                        txtMK.Focus();
                        timer1.Stop();
                    }
                }
                else
                {
                    Base.ShowErrorMessage(1, "Chưa nhập tên tài khoản");
                    txtTK.Focus();
                    timer1.Stop();
                }
            }
            catch (Exception)
            {
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            timer1.Stop();
            cbQuyen.Enabled = true;
            txtMK.Enabled = true;
            txtTK.Enabled = true;
            timer1.Stop();
            manv = dataGridView1.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            lbMaNV.Text = manv;
            btnLuu.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dem++;
            if (dem == 2)
            {
                timer1.Stop();
                load();
            }
        }

        private void txtTK_Leave(object sender, EventArgs e)
        {
            string t = txtTK.Text;
            if (t.Length < 5 && check == false)
            {
                Base.ShowError("Vui lòng nhập tài khoản trên 5 ký tự");
                txtTK.Focus();
            }
        }

        private void txtMK_Leave(object sender, EventArgs e)
        {
            string t = txtMK.Text;
            if (t.Length < 5 && check == false)
            {
                Base.ShowError("Vui lòng nhập mật khẩu trên 5 ký tự");
                txtMK.Focus();
            }
        }
    }
}