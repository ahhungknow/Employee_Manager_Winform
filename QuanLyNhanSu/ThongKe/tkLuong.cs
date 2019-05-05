using OfficeOpenXml;
using OfficeOpenXml.Style;
using QuanLyNhanSu.CT;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyNhanSu.ThongKe
{
    public partial class tkLuong : UserControl
    {
        public tkLuong()
        {
            InitializeComponent();
        }

        private string pathExcel = "";

        private int tongchi = 0;
        private DateTime tungay = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
        private DateTime denngay = Convert.ToDateTime("30/" + DateTime.Now.Month + "/" + DateTime.Now.Year);


        private void Button1_Click(object sender, EventArgs e)
        {
        }

        private void TkLuong_Load(object sender, EventArgs e)
        {
            load();
        }

        private void load()
        {
            tongchi = TinhLuong.sendLuong;

            txtTong.Text = tongchi.ToString();
            CauLenh cl1 = new CauLenh();
            txtThuong.Text = cl1.TongTienThuong(tungay, denngay).Rows[0]["Tien"].ToString();
            CauLenh cl2 = new CauLenh();
            txtPhat.Text = cl2.TongTienPhat(tungay, denngay).Rows[0]["Tien"].ToString();
            CauLenh cl3 = new CauLenh();
            txtPhuCap.Text = cl3.TongTienPhuCap(tungay, denngay).Rows[0]["Tien"].ToString();
            try
            {
                Convert.ToInt32(txtThuong.Text);
            }
            catch
            {
                txtThuong.Text = "0";
            }
            try
            {
                Convert.ToInt32(txtPhat.Text);
            }
            catch
            {
                txtPhat.Text = "0";
            }
            try
            {
                Convert.ToInt32(txtPhuCap.Text);
            }
            catch
            {
                txtPhuCap.Text = "0";
            }
            int luong = Convert.ToInt32(txtTong.Text) - Convert.ToInt32(txtThuong.Text) + Convert.ToInt32(txtPhat.Text) - Convert.ToInt32(txtPhuCap.Text);
            txtLuong.Text = luong.ToString();
        }

        private void Label4_Click(object sender, EventArgs e)
        {
        }

        private void Label5_Click(object sender, EventArgs e)
        {
        }

        private void TxtPhat_TextChanged(object sender, EventArgs e)
        {
        }

        private void TxtThuong_TextChanged(object sender, EventArgs e)
        {
        }

        private void Button2_Click(object sender, EventArgs e)
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

        private void CreateExcelFile()
        {
            List<LuongModel> luongModels = new List<LuongModel>();
            luongModels.Add(new LuongModel()
            {
                TienLuong = Convert.ToInt32(txtLuong.Text),
                TienThuong = Convert.ToInt32(txtThuong.Text),
                TienPhuCap = Convert.ToInt32(txtPhuCap.Text),
                TienPhat = Convert.ToInt32(txtPhat.Text),
                TongChi = tongchi,
            });
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
                                                "Tiền lương",
                                                "Tiền thưởng",
                                                "Tiền phụ cấp",
                                                "Tiền phạt",
                                                "Tổng chi"
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
                            ws.Cells[rowIndex, colIndex++].Value = item.TienLuong;
                            ws.Cells[rowIndex, colIndex++].Value = item.TienThuong;
                            ws.Cells[rowIndex, colIndex++].Value = item.TienPhat;
                            ws.Cells[rowIndex, colIndex++].Value = item.TienPhuCap;
                            ws.Cells[rowIndex, colIndex++].Value = item.TongChi;
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