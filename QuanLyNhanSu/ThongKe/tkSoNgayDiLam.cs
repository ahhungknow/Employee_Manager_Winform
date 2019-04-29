using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Xceed.Words.NET;

namespace QuanLyNhanSu.ThongKe
{
    public partial class tkSoNgayDiLam : UserControl
    {
        public tkSoNgayDiLam()
        {
            InitializeComponent();
        }

        private tkCauLenh tkcl = new tkCauLenh();
        private DataTable dt = new DataTable();
        private int thang = DateTime.Now.Month, nam = DateTime.Now.Year, ngay = DateTime.Now.Day;

        private void tkSoNgayDiLam_Load(object sender, EventArgs e)
        {
            load();
        }

        private void load()
        {
            btXem.Enabled = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            exportFile();
            try
            {
                if (File.Exists(@"newSoNgayLamReport.docx"))
                {
                    Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"\newSoNgayLamReport.docx");
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

        private void btXem_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ngaydau = Convert.ToDateTime("01/" + Convert.ToInt32(cbThang.Text) + "/" + Convert.ToInt32(cbNam.Text) + " ");
                DateTime ngaycuoi = Convert.ToDateTime("29/" + Convert.ToInt32(cbThang.Text) + "/" + Convert.ToInt32(cbNam.Text) + " ");
                dt.Clear();
                dt = tkcl.tkSoNgayDiLamCuaNhanVien(ngaydau, ngaycuoi, 1);
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void cbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            btXem.Enabled = true;
        }

        #region DocX

        public void exportFile()
        {
            DocX docX;
            try
            {
                if (File.Exists(@"SoNgayLamReportTemplate.docx"))
                {
                    docX = CreateWordFromTemplate(DocX.Load(@"SoNgayLamReportTemplate.docx"));
                    docX.SaveAs(@"newSoNgayLamReport.docx");
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
            template.AddCustomProperty(new CustomProperty("ReportTitle", "Báo cáo số ngày làm việc của nhân viên"));
            template.AddCustomProperty(new CustomProperty("Ngay", "00/" + thang + "/" + nam));
            template.AddCustomProperty(new CustomProperty("CountNV", dataGridView1.Rows.Count));

            var t = template.Tables[0];
            CreateAndInsertWordTableAfter(t, ref template);
            t.Remove();
            return template;
        }

        private void TxtNgay_TextChanged(object sender, EventArgs e)
        {

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

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                table.Rows.Add(item.Cells[0].Value.ToString(), item.Cells[1].Value.ToString(), item.Cells[2].Value.ToString());
            }

            return table;
        }

        #endregion DocX
    }
}