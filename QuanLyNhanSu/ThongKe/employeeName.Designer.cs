namespace QuanLyNhanSu.ThongKe
{
    partial class employeeName
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTen = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tên Nhân Viên";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // cbTen
            // 
            this.cbTen.FormattingEnabled = true;
            this.cbTen.Location = new System.Drawing.Point(87, 5);
            this.cbTen.Name = "cbTen";
            this.cbTen.Size = new System.Drawing.Size(141, 21);
            this.cbTen.TabIndex = 5;
            this.cbTen.SelectedIndexChanged += new System.EventHandler(this.cbTen_SelectedIndexChanged);
            // 
            // employeeName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbTen);
            this.Name = "employeeName";
            this.Size = new System.Drawing.Size(345, 30);
            this.Load += new System.EventHandler(this.abc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTen;
        private System.Windows.Forms.Timer timer1;
    }
}
