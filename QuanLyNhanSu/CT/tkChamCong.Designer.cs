namespace QuanLyNhanSu.ThongKe
{
    partial class tkChamCong
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.rdNCPNN = new System.Windows.Forms.RadioButton();
            this.rdNNN = new System.Windows.Forms.RadioButton();
            this.rdKN = new System.Windows.Forms.RadioButton();
            this.rdNCP = new System.Windows.Forms.RadioButton();
            this.rdNTT = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pnLoad = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.radioButton7);
            this.panel1.Controls.Add(this.radioButton6);
            this.panel1.Controls.Add(this.rdNCPNN);
            this.panel1.Controls.Add(this.rdNNN);
            this.panel1.Controls.Add(this.rdKN);
            this.panel1.Controls.Add(this.rdNCP);
            this.panel1.Controls.Add(this.rdNTT);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(20, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 460);
            this.panel1.TabIndex = 0;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton7.Location = new System.Drawing.Point(16, 417);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(164, 23);
            this.radioButton7.TabIndex = 1;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "Xem theo Phòng ban";
            this.radioButton7.UseVisualStyleBackColor = true;
            this.radioButton7.CheckedChanged += new System.EventHandler(this.radioButton7_CheckedChanged);
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton6.Location = new System.Drawing.Point(16, 356);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(188, 23);
            this.radioButton6.TabIndex = 1;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Xem theo tên Nhân viên";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // rdNCPNN
            // 
            this.rdNCPNN.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdNCPNN.Location = new System.Drawing.Point(16, 280);
            this.rdNCPNN.Name = "rdNCPNN";
            this.rdNCPNN.Size = new System.Drawing.Size(242, 55);
            this.rdNCPNN.TabIndex = 1;
            this.rdNCPNN.TabStop = true;
            this.rdNCPNN.Text = "Xem số ngày nghỉ không phép của Nhân viên";
            this.rdNCPNN.UseVisualStyleBackColor = true;
            this.rdNCPNN.CheckedChanged += new System.EventHandler(this.rdNCPNN_CheckedChanged);
            // 
            // rdNNN
            // 
            this.rdNNN.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdNNN.Location = new System.Drawing.Point(16, 216);
            this.rdNNN.Name = "rdNNN";
            this.rdNNN.Size = new System.Drawing.Size(253, 46);
            this.rdNNN.TabIndex = 1;
            this.rdNNN.TabStop = true;
            this.rdNNN.Text = "Xem số ngày nghỉ có phép của Nhân viên";
            this.rdNNN.UseVisualStyleBackColor = true;
            this.rdNNN.CheckedChanged += new System.EventHandler(this.rdNNN_CheckedChanged);
            // 
            // rdKN
            // 
            this.rdKN.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdKN.Location = new System.Drawing.Point(16, 155);
            this.rdKN.Name = "rdKN";
            this.rdKN.Size = new System.Drawing.Size(265, 55);
            this.rdKN.TabIndex = 1;
            this.rdKN.TabStop = true;
            this.rdKN.Text = "Xem số ngày đi làm của Nhân viên trong tháng";
            this.rdKN.UseVisualStyleBackColor = true;
            this.rdKN.CheckedChanged += new System.EventHandler(this.rdKN_CheckedChanged);
            // 
            // rdNCP
            // 
            this.rdNCP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdNCP.Location = new System.Drawing.Point(16, 97);
            this.rdNCP.Name = "rdNCP";
            this.rdNCP.Size = new System.Drawing.Size(253, 52);
            this.rdNCP.TabIndex = 1;
            this.rdNCP.TabStop = true;
            this.rdNCP.Text = "Xem Nhân viên nghỉ có phép trong ngày";
            this.rdNCP.UseVisualStyleBackColor = true;
            this.rdNCP.CheckedChanged += new System.EventHandler(this.rdNCP_CheckedChanged);
            // 
            // rdNTT
            // 
            this.rdNTT.AutoSize = true;
            this.rdNTT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdNTT.Location = new System.Drawing.Point(16, 51);
            this.rdNTT.Name = "rdNTT";
            this.rdNTT.Size = new System.Drawing.Size(265, 23);
            this.rdNTT.TabIndex = 1;
            this.rdNTT.TabStop = true;
            this.rdNTT.Text = "Xem Nhân viên nghỉ làm trong ngày";
            this.rdNTT.UseVisualStyleBackColor = true;
            this.rdNTT.CheckedChanged += new System.EventHandler(this.rdNTT_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Sách";
            // 
            // pnLoad
            // 
            this.pnLoad.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnLoad.Location = new System.Drawing.Point(353, 20);
            this.pnLoad.Name = "pnLoad";
            this.pnLoad.Size = new System.Drawing.Size(610, 460);
            this.pnLoad.TabIndex = 1;
            // 
            // tkChamCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.pnLoad);
            this.Controls.Add(this.panel1);
            this.Name = "tkChamCong";
            this.Size = new System.Drawing.Size(990, 502);
            this.Load += new System.EventHandler(this.tkChamCong_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton rdNCPNN;
        private System.Windows.Forms.RadioButton rdNNN;
        private System.Windows.Forms.RadioButton rdKN;
        private System.Windows.Forms.RadioButton rdNCP;
        private System.Windows.Forms.RadioButton rdNTT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnLoad;
    }
}
