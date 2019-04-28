using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu.ThongKe
{
    public partial class tkChamCong : UserControl
    {
        public tkChamCong()
        {
            InitializeComponent();
        }

        private void tkChamCong_Load(object sender, EventArgs e)
        {

        }

        private void rdNTT_CheckedChanged(object sender, EventArgs e)
        {
            ThongKe.tkNVNghiTrongNgay tknvntn = new ThongKe.tkNVNghiTrongNgay();
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(tknvntn);
        }

        private void rdNCP_CheckedChanged(object sender, EventArgs e)
        {
            ThongKe.tkNVNghiCoPhep tknvncp = new ThongKe.tkNVNghiCoPhep();
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(tknvncp);
        }

        private void rdKN_CheckedChanged(object sender, EventArgs e)
        {
            ThongKe.tkSoNgayDiLam tksndl = new ThongKe.tkSoNgayDiLam();
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(tksndl);
        }

        private void rdNNN_CheckedChanged(object sender, EventArgs e)
        {
            ThongKe.tkSoNgayNghiCoPhep tksnncp = new ThongKe.tkSoNgayNghiCoPhep();
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(tksnncp);
        }

        private void rdNCPNN_CheckedChanged(object sender, EventArgs e)
        {
            ThongKe.tkSoNgayNghiKhongPhep tksnnkp = new ThongKe.tkSoNgayNghiKhongPhep();
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(tksnnkp);
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            ThongKe.tkXemccTheoTen tkxtt = new ThongKe.tkXemccTheoTen();
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(tkxtt);
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            ThongKe.tkXemccTheoPhong tkxtp = new ThongKe.tkXemccTheoPhong();
            pnLoad.Controls.Clear();
            pnLoad.Controls.Add(tkxtp);
        }
    }
}
