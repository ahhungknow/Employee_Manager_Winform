using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhanSu.CT
{
    public partial class ctChamCong : UserControl
    {
        public ctChamCong()
        {
            InitializeComponent();
        }

        private CauLenh cl = new CauLenh();
        private DataTable dt = new DataTable();
        private SqlDataReader dr;
        private int ngay = DateTime.Now.Day, thang = DateTime.Now.Month, nam = DateTime.Now.Year, dem = 0;
        private string manv = null, a = null, b = null;

        private void load()
        {
            label2.Text = null;
            lbMa.Text = null;
            lbTen.Text = null;
            //lbTinhTrang.Text = null;
            btCapNhat.Enabled = false;
            dr = cl.LayChamCong("1", DateTime.Now);
            if (dr != null)
            {
                while (dr.Read())
                {
                    DateTime kq = dr.GetDateTime(0);
                    a = kq.ToString();
                }
            }

            if (ngay < 10)
                b = "0" + ngay;
            if (thang < 10)
                b = b + "/0" + thang;

            b = b +"/"+ nam + " 12:00:00 SA";

            if (a == b)
            {
                label6.Text = "Đã chấm công ngày hôm nay!";
                dt.Clear();
                dataGridView1.Refresh();
                dt = cl.LayChamCong1("0", DateTime.Now);
                dataGridView1.DataSource = dt;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dt.Rows[i]["TinhTrang"].ToString() == "Đi Làm")
                        dataGridView1.Rows[i].Cells["TinhTrang"].Value = "Đi Làm";
                    if (dt.Rows[i]["TinhTrang"].ToString() == "Nghỉ Có Phép")
                        dataGridView1.Rows[i].Cells["TinhTrang"].Value = "Nghỉ Có Phép";
                    if (dt.Rows[i]["TinhTrang"].ToString() == "Nghỉ Không Phép")
                        dataGridView1.Rows[i].Cells["TinhTrang"].Value = "Nghỉ Không Phép";
                }
                dem = 1;
            }
            else
            {
                btCapNhat.Enabled = true;
                dt.Clear();
                dataGridView1.Refresh();
                dt = cl.LayTenNhanVien1("0");
                dataGridView1.DataSource = dt;
                dem = 0;
            }
        }

        private void ctChamCong_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            int d = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells["TinhTrang"].Value == null)
                {
                    Base.ShowError("Vui lòng chọn đủ trước khi chấm công!");
                    dataGridView1.Rows[i].Cells["TinhTrang"].Selected = true;
                    d = 0;
                }
                else d++;
            }
            if (d != 0)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    string tinhtrang = dataGridView1.Rows[i].Cells["TinhTrang"].Value.ToString();
                    manv = dataGridView1.Rows[i].Cells["Ma"].Value.ToString();
                    dr = cl.ThemChamCong(manv, DateTime.Now, tinhtrang);
                }
                load();
                MessageBox.Show("Đã chấm công ngày hôm nay!", "Chấm công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0 && dem == 1)
            {
                lbMa.Text = dataGridView1.CurrentRow.Cells["Ma"].Value.ToString();
                lbTen.Text = dataGridView1.CurrentRow.Cells["Ten"].Value.ToString();

                // lbTinhTrang.Text = dataGridView1.CurrentRow.Cells["TinhTrang"].Value.ToString();
            }
            else if (e.ColumnIndex != 0 && dem == 0)
            {
                lbMa.Text = dataGridView1.CurrentRow.Cells["Ma"].Value.ToString();
                lbTen.Text = dataGridView1.CurrentRow.Cells["Ten"].Value.ToString();
                //lbTinhTrang.Text = "Chưa có giá trị";
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (Base.ShowDialogResultMessage("chấm công ngày đã chọn") == DialogResult.Yes)
                {
                    dr = cl.XoaChamCongTheoNgay(dtpNgay.Value);
                    a = null;
                    b = null;
                    Base.ShowCompleteMessage(3, "chấm công");
                    load();
                }
            }
            catch (Exception)
            {
                Base.ShowError("Có lỗi xảy ra khi xóa chấm công!!");
            }
        }

        private void cbCC_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCC.Checked == true)
                for (int i = 0; i < dataGridView1.RowCount; i++)
                    dataGridView1.Rows[i].Cells["TinhTrang"].Value = "Đi Làm";
            else
                for (int i = 0; i < dataGridView1.RowCount; i++)
                    dataGridView1.Rows[i].Cells["TinhTrang"].Value = "";
        }
    }
}