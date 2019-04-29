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
using Xceed.Words.NET;
using System.IO;
using System.Diagnostics;

namespace QuanLyNhanSu.ThongKe
{
    public partial class tkNVNghiTrongNgay : UserControl
    {
        public tkNVNghiTrongNgay()
        {
            InitializeComponent();
        }
        tkCauLenh tkcl = new tkCauLenh();
        DataTable dt = new DataTable();
        int thang = DateTime.Now.Month, nam = DateTime.Now.Year, ngay = DateTime.Now.Day;
        DateTime n;
        int check = 0;
        private void btXem_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ngaydau = Convert.ToDateTime( "01/" + Convert.ToInt32(cbThang.Text) + "/" + Convert.ToInt32(cbNam.Text) + " ");
                DateTime ngaycuoi = Convert.ToDateTime("29/" + Convert.ToInt32(cbThang.Text) + "/" + Convert.ToInt32(cbNam.Text) + " ");
                if (radioButton1.Checked == true)
                {
                    try
                    {
                        n = Convert.ToDateTime( Convert.ToInt32(txtNgay.Text) + "/" + Convert.ToInt32(cbThang.Text) + "/" + Convert.ToInt32(cbNam.Text));
                        dt.Clear();
                        dt = tkcl.tkNhanVienNghi(n, n, 1);
                        dtgv.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
                else
                {
                    txtNgay.Enabled = false;
                    try
                    {
                        dt.Clear();
                        dt = tkcl.tkNhanVienNghi(ngaydau, ngaycuoi, 0);
                        dtgv.DataSource = dt;
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập đầy đủ thông tin!!");
            }
            
        }

        private void load()
        {
            txtNgay.Enabled = false;
            cbThang.Enabled = false;
            cbNam.Enabled = false;
            btXem.Enabled = false;
        }
        private void tkNVNghiTrongNgay_Load(object sender, EventArgs e)
        {
            load();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            exportFile();
            try
            {
                if (File.Exists(@"newNghiLamReport.docx"))
                {
                    Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"\newNghiLamReport.docx");
                }
                else
                {
                    Base.ShowError("Không tìm thấy file báo cáo!");
                }
            }
            catch
            {
                Base.ShowError("Có lỗi xảy ra!");
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtNgay.Enabled = true;
            cbThang.Enabled = true;
            cbNam.Enabled = true;
            btXem.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtNgay.Enabled = false;
            cbThang.Enabled = true;
            cbNam.Enabled = true;
            btXem.Enabled = true;
        }

        #region DocX
        public void exportFile()
        {
            DocX docX;
            try
            {
                if (File.Exists(@"NghiLamReportTemplate.docx"))
                {
                    docX = CreateWordFromTemplate(DocX.Load(@"NghiLamReportTemplate.docx"));
                    docX.SaveAs(@"newNghiLamReport.docx");
                }
                else
                {
                    Base.ShowError("Không tìm thấy file mẫu báo cáo!");
                }
            }
            catch (Exception ex)
            {
                Base.ShowError("Lỗi khi tạo báo cáo!");
            }
        }
        public DocX CreateWordFromTemplate(DocX template)
        {
            template.AddCustomProperty(new CustomProperty("ReportTitle", "Báo cáo nhân viên nghỉ làm"));
            if (check == 1)
            {
                template.AddCustomProperty(new CustomProperty("Ngay", ngay + "/" + thang + "/" + nam));
                check = 0;
            }
            else
                template.AddCustomProperty(new CustomProperty("Ngay", "00/" + thang + "/" + nam));
            template.AddCustomProperty(new CustomProperty("CountNV", dtgv.Rows.Count));

            var t = template.Tables[0];
            CreateAndInsertWordTableAfter(t, ref template);
            t.Remove();
            return template;
        }

        private void TxtNgay_TextChanged(object sender, EventArgs e)
        {
            check = 1;
        }

        private void TxtNgay_TextChanged_1(object sender, EventArgs e)
        {
            check = 1;
        }

        public Table CreateAndInsertWordTableAfter(Table t, ref DocX document)
        {
            var data = GetDataFromDatabase();

            var invoiceTable = t.InsertTableAfterSelf(data.Rows.Count + 1, data.Columns.Count);
            invoiceTable.Design = TableDesign.DarkListAccent5;
            invoiceTable.Alignment = Alignment.center;


            var tableTitle = new Xceed.Words.NET.Formatting();

            tableTitle.Bold = true;


            invoiceTable.Rows[0].Cells[0].InsertParagraph("Mã nhân viên", false, tableTitle);
            invoiceTable.Rows[0].Cells[1].InsertParagraph("Tên nhân viên", false, tableTitle);
            invoiceTable.Rows[0].Cells[2].InsertParagraph("Ngày", false, tableTitle);

            for (var row = 1; row < invoiceTable.RowCount; row++)
            {
                for (var cell = 0; cell < invoiceTable.ColumnCount; cell++)
                {
                    invoiceTable.Rows[row].Cells[cell].InsertParagraph(data.Rows[row - 1].ItemArray[cell].ToString(), false);
                }
            }
            return invoiceTable;
        }

        public DataTable GetDataFromDatabase()
        {
            var table = new DataTable();
            table.Columns.AddRange(new DataColumn[]
            {
                new DataColumn(),
                new DataColumn(),
                new DataColumn()
            });

            foreach (DataGridViewRow item in dtgv.Rows)
            {
                table.Rows.Add(item.Cells[0].Value.ToString(), item.Cells[1].Value.ToString(), Convert.ToDateTime(item.Cells[2].Value.ToString()).ToShortDateString());
            }

            return table;
        }
        #endregion

    }
}
