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
using OfficeOpenXml.Style;
using System.IO;
using OfficeOpenXml;
using QuanLyNhanSu.UC;
using System.Diagnostics;

namespace QuanLyNhanSu.CT
{
    public partial class TinhLuong : UserControl
    {
        public TinhLuong()
        {
            InitializeComponent();
        }

        private string pathExcel = "";
        CauLenh cl = new CauLenh();
        SqlDataReader dr;
        DataTable dt = new DataTable();
        public static int sendLuong=0;
        int thang = DateTime.Now.Month, nam = DateTime.Now.Year, ngay = DateTime.Now.Day, luongcoban = 0, tongluong = 0, tienthuong = 0, tienphat = 0, phucap = 0, m = 0;
        string manv = null, songaylam = null, songaynghicophep = null, songaynghikhongphep = null, chucvu = null;
        private void load()
        {
            DateTime ngaydau, ngaycuoi;
            songaylam = "0"; luongcoban = 0; tongluong = 0; tienthuong = 0; tienphat = 0; phucap = 0;
            if(m == 0)
            {
                ngaydau = Convert.ToDateTime( "01/" + thang + "/" + nam);
                ngaycuoi = Convert.ToDateTime("30/" + thang + "/" + nam);
            }
            else
            {
                ngaydau = Convert.ToDateTime( "01/" + txtThang.Text + "/" + txtNam.Text);
                ngaycuoi = Convert.ToDateTime("30/" + txtThang.Text + "/" + txtNam.Text);
            }
            btCapNhat.Enabled = false;
            lbTen.Text = null;
            lbChucVu.Text = null;
            lbTB.Text = null;
            dt.Clear();
            dt = cl.TongLuongNV("0");
            dataGridView1.DataSource = dt;
            int sendLuong1 = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                manv = dataGridView1.Rows[i].Cells["Ma"].Value.ToString();
                dataGridView1.Rows[i].Cells["SNL"].Value = LaySoNgayLam(manv, ngaydau, ngaycuoi);
                dataGridView1.Rows[i].Cells["T"].Value = TienThuong(manv, ngaydau, ngaycuoi);
                dataGridView1.Rows[i].Cells["P"].Value = TienPhat(manv, ngaydau, ngaycuoi);
                dataGridView1.Rows[i].Cells["PC"].Value = tienPhuCap(manv, ngaycuoi);
                tongluong = TinhLuong1(manv, songaylam, tienthuong.ToString(), tienphat.ToString(), ngaydau, ngaycuoi);
                sendLuong1 += tongluong;
                dataGridView1.Rows[i].Cells["TL"].Value = String.Format("{0:0,0}", tongluong);
                //MessageBox.Show(songaylam + "\n" + tienthuong + "\n" + tienphat + "\n" + tongluong.ToString());

            }
            sendLuong = sendLuong1;
         
        }
        private string LaySoNgayLam(string manv, DateTime ngaydau, DateTime ngaycuoi)
        {
            dr = cl.DemSoNgayLam(manv, ngaydau, ngaycuoi);
            while (dr.Read())
            {
                songaylam = dr.GetInt32(1).ToString();
            }
            return songaylam;
        }
        private string NghiKhongPhep(string manv, DateTime ngaydau, DateTime ngaycuoi)
        {
            dr = cl.DemSoNgayNghiKhongPhep(manv, ngaydau, ngaycuoi);
            while (dr.Read())
            {
                songaynghikhongphep = dr.GetInt32(1).ToString();
            }
            return songaynghikhongphep;
        }
        private string NghiCoPhep(string manv, DateTime ngaydau, DateTime ngaycuoi)
        {
            dr = cl.DemSoNgaynghiCoPhep(manv, ngaydau, ngaycuoi);
            while (dr.Read())
            {
                songaynghicophep = dr.GetInt32(1).ToString();
            }
            return songaynghicophep;
        }
        private int TienThuong(string manv, DateTime nd, DateTime nc)
        {
            tienthuong = 0;
            string ld = null;
            int tien = 0;
            try
            {
                dr = cl.LayTienThuong(manv, nd, nc);
                while (dr.Read())
                {
                    
                    tien = dr.GetInt32(0);
                    ld = dr.GetString(1);
                    if (ld == "Thưởng")
                        tienthuong += tien;
                }
            }
            catch (Exception)
            {
                tienthuong = 0;
            }

            return tienthuong;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CreateExcelFile();
            try
            {
                if (File.Exists(pathExcel))
                {
                    Process.Start(pathExcel);
                }
                else
                {
                    Base.ShowError("Không tìm thấy file thống kê!");
                }
            }
            catch
            {
                Base.ShowError("Có lỗi xảy ra!");
            }
        }

        private int TienPhat(string manv, DateTime nd, DateTime nc)
        {
            tienphat = 0;
            string ld = null;
            int tien = 0;
            try
            {
                dr = cl.LayTienThuong(manv, nd, nc);
                while (dr.Read())
                {

                    tien = dr.GetInt32(0);
                    ld = dr.GetString(1);
                    if (ld == "Phạt")
                        tienphat += tien;
                }
            }
            catch (Exception)
            {
                tienphat = 0;
            }

            return tienphat;
        }
        private int LayLuongCoBan(string manv)
        {
            dr = cl.TongLuongNV1(manv);
            while (dr.Read())
            {
                luongcoban = dr.GetInt32(0);
            }
            return luongcoban;
        }
        private string LayChucVuTuMaNV1(string manv)
        {
            dr = cl.LayChucVuTuMaNV(manv);
             while (dr.Read())
            {
                chucvu = dr.GetString(0);
            }
             return chucvu;
        }
        private int tienPhuCap(string manv, DateTime n)
        {
            phucap = 0;
            try
            {
                dr = cl.LayTienPhuCap(manv, n);
                while (dr.Read())
                    phucap += dr.GetInt32(1);
            }
            catch (Exception)
            {

                phucap = 0;
            }
            return phucap;
        }
        private int TinhLuong1(string manv, string soNgayLam, string tienThuong, string tienPhat, DateTime ngaydau, DateTime ngaycuoi)
        {
            
            int a = Convert.ToInt32(tienThuong) - Convert.ToInt32(tienPhat);
            int ncp = Convert.ToInt32(NghiCoPhep(manv, ngaydau, ngaycuoi));
            int nkp = Convert.ToInt32(NghiKhongPhep(manv, ngaydau, ngaycuoi));
            int luongCoBan = LayLuongCoBan(manv);
            int nl = Convert.ToInt32(songaylam);
            int p = tienPhuCap(manv,ngaycuoi);
            if (ncp > 3)
                nl = nl + 3 - (ncp % 3);
            else
                nl = nl + ncp;
            tongluong = ((luongCoBan / 22) * nl) + a + p;
            //MessageBox.Show(ncp.ToString() + "\n" + nl.ToString() + "\n" + a.ToString() + "\n" + tongluong.ToString());
            return tongluong;
        }
        private void TinhLuong_Load(object sender, EventArgs e)
        {
            load();
            txtThang.Text = "05";
            txtNam.Text = "2019";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lbTen.Text = dataGridView1.CurrentRow.Cells["TenNV"].Value.ToString();
            cbHeSoLuong.Text = dataGridView1.CurrentRow.Cells["HeSoLuong"].Value.ToString();
            btCapNhat.Enabled = true;
            txtLCB.Text = LayLuongCoBan(dataGridView1.CurrentRow.Cells["Ma"].Value.ToString()).ToString();
            lbChucVu.Text = LayChucVuTuMaNV1(dataGridView1.CurrentRow.Cells["Ma"].Value.ToString());
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(cbHeSoLuong.Text);
            if(!string.IsNullOrEmpty(cbHeSoLuong.Text))
            {
                if(!string.IsNullOrEmpty(txtLCB.Text))
                {
                    if (a > 0 && a < 11)
                    {
                        dr = cl.CapNhatLuong(Convert.ToInt32(cbHeSoLuong.Text), Convert.ToInt32(txtLCB.Text));
                        Base.ShowCompleteMessage(2, cbHeSoLuong.Text);
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Không tồn tại Hệ số lương đang nhập");
                        cbHeSoLuong.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi!!");
                    txtLCB.Focus();
                }
            }
            else
            {
                MessageBox.Show("Lỗi!!");
                cbHeSoLuong.Focus();
            }
        }

        private void cbHeSoLuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(cbHeSoLuong.Text);
            if (a > 0 && a < 11)
            {
                dr = cl.LayLuongCB(a);
                while (dr.Read())
                    txtLCB.Text = dr.GetInt32(0).ToString();
                btCapNhat.Enabled = true;
            }
            else
            {

            }
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtThang.Text))
            {
                if (!string.IsNullOrEmpty(txtNam.Text))
                {
                    if (Convert.ToInt32(txtThang.Text) > 12 || Convert.ToInt32(txtThang.Text) < 1)
                    {
                        lbTB.Text = "Tháng không hợp lệ";
                    }
                    else
                    {
                        m = 1;
                        dataGridView1.Refresh();
                        load();
                        lbTB.Text = null;
                    }
                }
                else
                {
                    lbTB.Text = "Lỗi";
                }
            }
            else
            {
                lbTB.Text = "Lỗi";
            }
           
        }

        private void txtThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CreateExcelFile()
        {
            List<ModelLuong> luongModels = new List<ModelLuong>();
            
            foreach(DataGridViewRow item in dataGridView1.Rows)
            {
                string[] a = item.Cells[6].Value.ToString().Split('.');
                string tongluong2 = "";
                for(int i = 0; i <a.Length; i++)
                {
                    tongluong2 += a[i];
                }

                luongModels.Add(new ModelLuong()
                {
                    MaNhanVien=item.Cells[0].Value.ToString(),
                    TenNhanVien= item.Cells[1].Value.ToString(),
                    HeSoLuong= Convert.ToInt32(item.Cells[2].Value.ToString()),
                    NgayLam = Convert.ToInt32(item.Cells[3].Value.ToString()),
                    TienThuong = Convert.ToInt32(item.Cells[4].Value.ToString()),
                    TienPhat = Convert.ToInt32(item.Cells[5].Value.ToString()),
                    PhuCap = Convert.ToInt32(item.Cells[7].Value.ToString()),
                    TongLuong = Convert.ToInt32(tongluong2),
                });
            }

            {
                string filePath = "";
                // tạo SaveFileDialog để lưu file excel
                SaveFileDialog dialog = new SaveFileDialog();

                // chỉ lọc ra các file có định dạng Excel
                dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";

                // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = dialog.FileName;
                }

                // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
                if (string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("Đường dẫn file không hợp lệ");
                    return;
                }

                try
                {
                    using (ExcelPackage p = new ExcelPackage())
                    {
                        // đặt tên người tạo file
                        p.Workbook.Properties.Author = "Quang Nguyễn";

                        // đặt tiêu đề cho file
                        p.Workbook.Properties.Title = "Thống kê lương tháng " + DateTime.Now.Month + "/" + DateTime.Now.Year;

                        //Tạo một sheet để làm việc trên đó
                        p.Workbook.Worksheets.Add("Sheet1");

                        // lấy sheet vừa add ra để thao tác
                        ExcelWorksheet ws = p.Workbook.Worksheets[1];

                        // đặt tên cho sheet
                        ws.Name = "Lương tháng " + DateTime.Now.Month + "/" + DateTime.Now.Year;
                        // fontsize mặc định cho cả sheet
                        ws.Cells.Style.Font.Size = 11;
                        // font family mặc định cho cả sheet
                        ws.Cells.Style.Font.Name = "Calibri";

                        // Tạo danh sách các column header
                        string[] arrColumnHeader = {
                                                "Mã nhân viên",
                                                "Tên nhân viên",
                                                "Hệ số lương",
                                                "Ngày làm",
                                                "Tiền thưởng",
                                                "Phụ cấp",
                                                "Tiền phạt",
                                                "Tổng lương"
                                                    };

                        // lấy ra số lượng cột cần dùng dựa vào số lượng header
                        var countColHeader = arrColumnHeader.Count();

                        // merge các column lại từ column 1 đến số column header
                        // gán giá trị cho cell vừa merge là Thống kê thông tni User Kteam
                        ws.Cells[1, 1].Value = "Thống kê lương tháng " + DateTime.Now.Month + "/" + DateTime.Now.Year;
                        ws.Cells[1, 1, 1, countColHeader].Merge = true;
                        // in đậm
                        ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                        // căn giữa
                        ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        int colIndex = 1;
                        int rowIndex = 2;

                        //tạo các header từ column header đã tạo từ bên trên
                        foreach (var item in arrColumnHeader)
                        {
                            var cell = ws.Cells[rowIndex, colIndex];

                            //set màu thành gray
                            var fill = cell.Style.Fill;
                            fill.PatternType = ExcelFillStyle.Solid;
                            fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                            //căn chỉnh các border
                            var border = cell.Style.Border;
                            border.Bottom.Style =
                                border.Top.Style =
                                border.Left.Style =
                                border.Right.Style = ExcelBorderStyle.Thin;

                            //gán giá trị
                            cell.Value = item;

                            colIndex++;
                        }

                        // lấy ra danh sách UserInfo từ ItemSource của DataGrid

                        // với mỗi item trong danh sách sẽ ghi trên 1 dòng
                        foreach (var item in luongModels)
                        {
                            // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                            colIndex = 1;

                            // rowIndex tương ứng từng dòng dữ liệu
                            rowIndex++;

                            //gán giá trị cho từng cell
                            ws.Cells[rowIndex, colIndex++].Value = item.MaNhanVien;
                            ws.Cells[rowIndex, colIndex++].Value = item.TenNhanVien;
                            ws.Cells[rowIndex, colIndex++].Value = item.HeSoLuong;
                            ws.Cells[rowIndex, colIndex++].Value = item.NgayLam;
                            ws.Cells[rowIndex, colIndex++].Value = item.TienThuong;
                            ws.Cells[rowIndex, colIndex++].Value = item.PhuCap;
                            ws.Cells[rowIndex, colIndex++].Value = item.TienPhat;
                            ws.Cells[rowIndex, colIndex++].Value = item.TongLuong;
                        }

                        //Lưu file lại
                        Byte[] bin = p.GetAsByteArray();
                        File.WriteAllBytes(filePath, bin);
                    }
                    MessageBox.Show("Xuất file excel thành công!");
                    pathExcel = filePath;
                }
                catch (Exception EE)
                {
                    MessageBox.Show("Có lỗi khi lưu file!");
                }
            }
        }

    }
}
