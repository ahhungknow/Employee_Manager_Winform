using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace QuanLyNhanSu
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }
        private int dem = 0;
        public static string hinh = @"Hinh\ajax-loader.gif";
        private void timer1_Tick(object sender, EventArgs e)
        {
            dem++;
            if (dem == 2)
            {
                timer1.Stop();
                this.Hide();
                DangNhap dn = new DangNhap();
                dn.ShowDialog();
            }
            if( dem > 2)
            {
                timer1.Stop();
                this.Hide();
                KetNoi kn = new KetNoi();
                kn.Show();
            }

        }

        private void Start_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(hinh);
            FileStream fs = new FileStream(@"KetNoi\ketnoi.ini", FileMode.Open);
            StreamReader rd = new StreamReader(fs, Encoding.UTF8);
            String c = rd.ReadToEnd();
            string[] kq = c.Split('\n');
            string ch = @"Data Source=" + kq[0].Trim() + " ;Initial Catalog=" + kq[1].Trim() + " ;Integrated Security=True";
            CauLenh.chuoiketnoi = Convert.ToString(ch);
            tkCauLenh.chuoiketnoi = Convert.ToString(ch);
            rd.Close();
            timer1.Start();

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
