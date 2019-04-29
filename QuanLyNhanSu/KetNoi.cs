using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace QuanLyNhanSu
{
    public partial class KetNoi : Form
    {
        public KetNoi()
        {
            InitializeComponent();
        }

        SqlConnection conn = null;
        private void ketnoidulieu()
        {
            FileStream fs = new FileStream(@"KetNoi\ketnoi.ini", FileMode.Open);
            StreamReader rd = new StreamReader(fs, Encoding.UTF8);
            String c = rd.ReadToEnd();
            string[] kq = c.Split('\n');
            CauLenh.chuoiketnoi = "Data Source=" + kq[0].Trim() + ";Initial Catalog=" + kq[1].Trim() + ";Integrated Security=True";
            tkCauLenh.chuoiketnoi = "Data Source=" + kq[0].Trim() + ";Initial Catalog=" + kq[1].Trim() + ";Integrated Security=True";
            rd.Close();
            this.Hide();
            DangNhap dn = new DangNhap();
            dn.Show();
        }
        private void KetNoi_Load(object sender, EventArgs e)
        {
            label3.Text = null;
            FileStream fs = new FileStream(@"KetNoi\ketnoi.ini", FileMode.Open);
            StreamReader rd = new StreamReader(fs, Encoding.UTF8);
            String c = rd.ReadToEnd();
            string[] kq = c.Split('\n');
            txtSN.Text = kq[0].Trim();
            txtD.Text = kq[1].Trim();
            rd.Close();
            if (txtD.Text == "quangnv@dft.vn")
            {
                label3.Text = "Nhập server name lúc connect vô sql của máy bạn!!";
                txtD.Text = "QlNhanSu";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string a = txtSN.Text.Trim();
            string b = txtD.Text.Trim();
            conn = new SqlConnection(@"Data Source=" + a + ";Initial Catalog=" + b + ";Integrated Security=True");
            try
            {
                conn.Open();
                string[] dl = new string[] {a,b};
                using (StreamWriter sw = new StreamWriter(@"KetNoi\ketnoi.ini"))
                {
                    foreach (string s in dl)
                    {
                        sw.WriteLine(s);
                    }
                }
                MessageBox.Show("Kết nối thành công");
                ketnoidulieu();
            }
            catch (Exception)
            {

                label3.Text = "Lỗi Kết Nối";
            }
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            ketnoidulieu();
        }

        private void txtSN_MouseDown(object sender, MouseEventArgs e)
        {
            txtSN.Text = null;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
