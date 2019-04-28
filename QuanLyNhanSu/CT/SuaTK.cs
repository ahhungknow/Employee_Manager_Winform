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
    public partial class SuaTK : UserControl
    {
        public SuaTK()
        {
            InitializeComponent();
        }
        CauLenh cl = new CauLenh();
        DataTable dt = new DataTable();
        SqlDataReader dr;
        string manv = null;
        int dem = 0;
        public void load()
        {
            dem = 0;
            TaoTaiKhoan ttk = new TaoTaiKhoan();
            this.Controls.Clear();
            this.Controls.Add(ttk);
            dt.Clear();
            dt = cl.NvCoTK("0");
            dg.DataSource = dt;
            timer1.Start();
            txtTK.Text = null;
            cbQH.Text = null;
            txtMK.Text = null;
            btLuu.Enabled = false;
            btXoa.Enabled = false;
            lbMNV.Text = null;
        }
        private void btLuu_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtTK.Text))
            {
                if (!string.IsNullOrEmpty(txtMK.Text))
                {
                    if (!string.IsNullOrEmpty(cbQH.Text))
                    {
                        timer1.Start();
                        dr = cl.SuaTK(manv, cbQH.Text, txtTK.Text, txtMK.Text);
                        Base.ShowCompleteMessage(2, txtTK.Text);
                        load();
                    }
                    else
                    {
                        Base.ShowErrorMessage(2, "Không được bỏ trống quyền hạn");
                        cbQH.Focus();
                    }
                }
                else
                {
                    Base.ShowErrorMessage(2, "Không được bỏ trống mật khẩu");
                    txtMK.Focus();
                }
            }
            else
            {
                Base.ShowErrorMessage(2, "Không được bỏ trống tên tài khoản");
                txtTK.Focus();
            }
            
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            timer1.Start();
            if (Base.ShowDialogResultMessage(txtTK.Text) == DialogResult.Yes)
            {
                dr = cl.XoaTK(manv);
                Base.ShowCompleteMessage(3, txtTK.Text);
                load();
            }
        }

        private void SuaTK_Load(object sender, EventArgs e)
        {
            load();
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

        private void dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            timer1.Stop();
            btLuu.Enabled = true;
            btXoa.Enabled = true;
            manv = dg.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            dr = cl.NvCoTK1(manv);
            while (dr.Read())
            {
                lbMNV.Text = manv;
                txtTK.Text = dr.GetString(1);
                txtMK.Text = dr.GetString(2);
                cbQH.Text = dr.GetString(3);
            }
        }
    }
}
