using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Xceed.Words.NET;

namespace QuanLyNhanSu.ThongKe
{
    public partial class tkXemccTheoTen : UserControl
    {
        public tkXemccTheoTen()
        {
            InitializeComponent();
        }

        private tkCauLenh tkcl = new tkCauLenh();
        private CauLenh cl = new CauLenh();
        private DataTable dt = new DataTable();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            btXem.Enabled = true;
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ngaydau = Convert.ToDateTime("01/" + Convert.ToInt32(cbThang.Text) + "/" + Convert.ToInt32(cbNam.Text) + " ");
                DateTime ngaycuoi = Convert.ToDateTime("29/" + Convert.ToInt32(cbThang.Text) + "/" + Convert.ToInt32(cbNam.Text) + " ");
                dt.Clear();
                dt = tkcl.tkccXemTheoTenVaPhongBan(cbTen.SelectedValue.ToString(), "abc", ngaydau, ngaycuoi, 1);
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void load()
        {
            cbTen.DataSource = cl.TatCaNhanVien();
            cbTen.DisplayMember = "TenNV";
            cbTen.ValueMember = "MaNhanVien";
        }

        private void tkXemccTheoTen_Load(object sender, EventArgs e)
        {
            load();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            exportFile();
            try
            {
                if (File.Exists(@"newThongKeTheoTenReport.docx"))
                {
                    Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"\newThongKeTheoTenReport.docx");
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

        #region DocX

        public void exportFile()
        {
            DocX docX;
            try
            {
                if (File.Exists(@"ThongKeTheoTenReportTemplate.docx"))
                {
                    docX = CreateWordFromTemplate(DocX.Load(@"ThongKeTheoTenReportTemplate.docx"));
                    docX.SaveAs(@"newThongKeTheoTenReport.docx");
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
            int songaydilam=0,songaynghilam=0;
            int i = 0;
            foreach(DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells[2].Value.ToString().Equals("Đi Làm"))
                {
                    i++;
                }
            }

            songaydilam = i;
            songaynghilam = dataGridView1.Rows.Count - i;
            i = 0;

            template.AddCustomProperty(new CustomProperty("ReportTitle", "Báo cáo tình trạng đi làm của nhân viên"));
            template.AddCustomProperty(new CustomProperty("TenNV", cbTen.Text));
            template.AddCustomProperty(new CustomProperty("Thang", cbThang.Text + "/" + cbNam.Text));
            template.AddCustomProperty(new CustomProperty("SoNgayDiLam", songaydilam));
            template.AddCustomProperty(new CustomProperty("SoNgayNghi", songaynghilam));

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
            invoiceTable.Rows[0].Cells[2].InsertParagraph("Tình trạng", false, tableTitle);
            invoiceTable.Rows[0].Cells[3].InsertParagraph("Ngày", false, tableTitle);



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
                new DataColumn(),
                new DataColumn()
            });

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                table.Rows.Add(item.Cells[0].Value.ToString(), item.Cells[1].Value.ToString(),item.Cells[2].Value.ToString(), Convert.ToDateTime(item.Cells[3].Value.ToString()).ToShortDateString());
            }

            return table;
        }

        #endregion DocX
    }
}