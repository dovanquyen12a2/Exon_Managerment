namespace EXON.GradedEssay.Control
{
    partial class ucReportKetQuaNN
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
            this.gvMain = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnKetQuaLop = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbUnit = new System.Windows.Forms.RadioButton();
            this.cbLop = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvMain
            // 
            this.gvMain.AllowUserToAddRows = false;
            this.gvMain.AllowUserToDeleteRows = false;
            this.gvMain.AllowUserToOrderColumns = true;
            this.gvMain.BackgroundColor = System.Drawing.Color.White;
            this.gvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvMain.Location = new System.Drawing.Point(3, 16);
            this.gvMain.Name = "gvMain";
            this.gvMain.Size = new System.Drawing.Size(899, 247);
            this.gvMain.TabIndex = 59;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gvMain);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 102);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(905, 266);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách thí sinh";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnKetQuaLop);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 368);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(905, 71);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // btnKetQuaLop
            // 
            this.btnKetQuaLop.Image = global::EXON.GradedEssay.Properties.Resources.print_65_445177;
            this.btnKetQuaLop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKetQuaLop.Location = new System.Drawing.Point(327, 18);
            this.btnKetQuaLop.Margin = new System.Windows.Forms.Padding(2);
            this.btnKetQuaLop.Name = "btnKetQuaLop";
            this.btnKetQuaLop.Size = new System.Drawing.Size(157, 36);
            this.btnKetQuaLop.TabIndex = 66;
            this.btnKetQuaLop.Text = "In kết quả  theo lớp";
            this.btnKetQuaLop.UseVisualStyleBackColor = true;
            this.btnKetQuaLop.Click += new System.EventHandler(this.btnKetQuaLop_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbUnit);
            this.groupBox1.Controls.Add(this.cbLop);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(905, 102);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Xuất báo cáo";
            // 
            // rbUnit
            // 
            this.rbUnit.AutoSize = true;
            this.rbUnit.Checked = true;
            this.rbUnit.Location = new System.Drawing.Point(249, 47);
            this.rbUnit.Name = "rbUnit";
            this.rbUnit.Size = new System.Drawing.Size(43, 17);
            this.rbUnit.TabIndex = 90;
            this.rbUnit.TabStop = true;
            this.rbUnit.Text = "Lớp";
            this.rbUnit.UseVisualStyleBackColor = true;
            // 
            // cbLop
            // 
            this.cbLop.FormattingEnabled = true;
            this.cbLop.Location = new System.Drawing.Point(327, 47);
            this.cbLop.Name = "cbLop";
            this.cbLop.Size = new System.Drawing.Size(274, 21);
            this.cbLop.TabIndex = 86;
            this.cbLop.SelectedValueChanged += new System.EventHandler(this.cbLop_SelectedValueChanged);
            // 
            // ucReportKetQuaNN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucReportKetQuaNN";
            this.Size = new System.Drawing.Size(905, 439);
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView gvMain;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbLop;
        private System.Windows.Forms.Button btnKetQuaLop;
        private System.Windows.Forms.RadioButton rbUnit;
    }
}
