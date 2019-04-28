using System;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class QuanLy : Form
    {
        public static string ten = null;
        public static string quyenhan = null;

        public QuanLy()
        {
            InitializeComponent();
        }

        private void PhanQuyen(string quyen)
        {
            if (quyen == "User")
            {
                btnTaoTK.Enabled = false;
                btnPhongBan.Enabled = false;
                btnChamCong.Enabled = false;
                btnChucVu.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                btTKLuong.Enabled = false;
            }
            if (quyen == "Admin")
            {
                btnTaoTK.Enabled = false;
                btTKLuong.Enabled = false;
            }
            if (quyen == "Super Admin")
            {
                btnTaoTK.Enabled = true;
                btnPhongBan.Enabled = true;
                btnChamCong.Enabled = true;
                btnChucVu.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                btTKLuong.Enabled = true;
            }
        }

        private void load()
        {
            timer1.Start();
            tabControl1.SelectedTab = tpQuanLy;
            label1.Text = "Chào: " + ten;
            PhanQuyen(quyenhan.Trim());
            CT.NhanVien.quyenhan = quyenhan;
            CT.PhuCap.quyenhan = quyenhan;
            CT.BaoHiem.quyenhan = quyenhan;
        }

        private void QuanLy_Load(object sender, EventArgs e)
        {
            load();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = Convert.ToString(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            label3.Text = null;
            CT.DoiMatKhau dmk = new CT.DoiMatKhau();
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(dmk);
        }

        private void btnThongTinCN_Click(object sender, EventArgs e)
        {
            label3.Text = null;
            CT.DoiThongTin dtt = new CT.DoiThongTin();
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(dtt);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát?", "Chu Ý", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                Application.Exit();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn đăng xuất?", "Chu Ý", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                Application.Restart();
        }

        private void btnPhongBan_Click(object sender, EventArgs e)
        {
            label3.Text = null;
            CT.PhongBan pb = new CT.PhongBan();
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(pb);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            label3.Text = null;
            CT.NhanVien nv = new CT.NhanVien();
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(nv);
        }

        private void btnChucVu_Click(object sender, EventArgs e)
        {
            label3.Text = null;
            CT.ChucVu cv = new CT.ChucVu();
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(cv);
        }

        private void btnTaoTK_Click(object sender, EventArgs e)
        {
            label3.Text = null;
            pnLoad.Controls.Clear();
            CT.SuaTK stk = new CT.SuaTK();
            pnLoad.Controls.Add(stk);
            /*CT.TaoTaiKhoan ttk = new CT.TaoTaiKhoan();
            pnLoad.Controls.Add(ttk);*/
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            label3.Text = null;
            CT.ctChamCong cc = new CT.ctChamCong();
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(cc);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label3.Text = null;
            CT.TinhLuong tl = new CT.TinhLuong();
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(tl);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label3.Text = null;
            CT.ThuongPhat tp = new CT.ThuongPhat();
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(tp);
        }

        private void brnChamCong_Click(object sender, EventArgs e)
        {
            label3.Text = null;
            ThongKe.tkChamCong tkcc = new ThongKe.tkChamCong();
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(tkcc);
        }

        private void btnTKNhanVien_Click(object sender, EventArgs e)
        {
            label3.Text = null;
            CT.tkNhanVien tknv = new CT.tkNhanVien();
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(tknv);
        }

        private void btLSLam_Click(object sender, EventArgs e)
        {
            label3.Text = null;
            CT.tkLSLam tklslv = new CT.tkLSLam();
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(tklslv);
        }

        private void QuanLy_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btBaoHiem_Click(object sender, EventArgs e)
        {
            label3.Text = null;
            CT.BaoHiem bh = new CT.BaoHiem();
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(bh);
        }

        private void btPhuCap_Click(object sender, EventArgs e)
        {
            label3.Text = null;
            CT.PhuCap pc = new CT.PhuCap();
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(pc);
        }
    }
}