using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace QuanLyNhanSu.CT
{
    public partial class tkLSLam : UserControl
    {
        public tkLSLam()
        {
            InitializeComponent();
        }
        CauLenh cl = new CauLenh();
        DataTable dt = new DataTable();
        string tennv = null, manv = null, tencv = null;
        SqlDataReader dr;
        private void load()
        {
            dt.Clear();
            dt = cl.LayctChucVu("0");
            dataGridView1.DataSource = dt;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                string manhanvien = dataGridView1.Rows[i].Cells["MaNV"].Value.ToString();
                dataGridView1.Rows[i].Cells["TenNV"].Value = laytennvtumanv(manhanvien);
                dataGridView1.Rows[i].Cells["TenCV"].Value = laytencvtumanv(manhanvien);
            }

        }
        private void tkLSLam_Load(object sender, EventArgs e)
        {
            load();
        }
        private string laytennvtumanv(string ma)
        {
            dr = cl.LayTenNhanVien(ma);
            while (dr.Read())
                tennv = dr.GetString(0);
            return tennv;
        }
        private string laytencvtumanv(string ma)
        {
            dr = cl.LayChucVuTuMaNV(ma);
            while (dr.Read())
                tencv = dr.GetString(0);
            return tencv;
        }
        private string laymanvtutennv(string ma)
        {
            dr = cl.layMaNVTuTenNV(txtTen.Text);
            while (dr.Read())
                manv = dr.GetString(0);
            return manv;
        }
        private void btXem_Click(object sender, EventArgs e)
        {
            try
            {
                manv = laymanvtutennv(txtTen.Text);
                dt.Clear();
                dt = cl.LayctChucVu(manv);
                dataGridView1.DataSource = dt;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    string manhanvien = dataGridView1.Rows[i].Cells["MaNV"].Value.ToString();
                    dataGridView1.Rows[i].Cells["TenNV"].Value = laytennvtumanv(manhanvien);
                    dataGridView1.Rows[i].Cells["TenCV"].Value = laytencvtumanv(manhanvien);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hoặc không tồn tại tên nhân viên vừa nhập"); 
               
            }
            
        }
    }
}
