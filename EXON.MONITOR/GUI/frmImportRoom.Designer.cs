namespace EXON.MONITOR.GUI
{
    partial class frmImportRoom
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportRoom));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgvCauHinh = new System.Windows.Forms.DataGridView();
            this.mbtnChooseFile = new MetroFramework.Controls.MetroButton();
            this.mbtnInputFile = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCauHinh)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(162, 276);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(178, 26);
            this.textBox1.TabIndex = 2;
            // 
            // dgvCauHinh
            // 
            this.dgvCauHinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCauHinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCauHinh.Location = new System.Drawing.Point(4, 60);
            this.dgvCauHinh.Name = "dgvCauHinh";
            this.dgvCauHinh.Size = new System.Drawing.Size(467, 202);
            this.dgvCauHinh.TabIndex = 6;
            // 
            // mbtnChooseFile
            // 
            this.mbtnChooseFile.Highlight = true;
            this.mbtnChooseFile.Location = new System.Drawing.Point(46, 268);
            this.mbtnChooseFile.Name = "mbtnChooseFile";
            this.mbtnChooseFile.Size = new System.Drawing.Size(83, 34);
            this.mbtnChooseFile.TabIndex = 7;
            this.mbtnChooseFile.Text = "Chọn File";
            this.mbtnChooseFile.UseSelectable = true;
            this.mbtnChooseFile.Click += new System.EventHandler(this.mbtnChooseFile_Click);
            // 
            // mbtnInputFile
            // 
            this.mbtnInputFile.Highlight = true;
            this.mbtnInputFile.Location = new System.Drawing.Point(205, 308);
            this.mbtnInputFile.Name = "mbtnInputFile";
            this.mbtnInputFile.Size = new System.Drawing.Size(86, 34);
            this.mbtnInputFile.TabIndex = 8;
            this.mbtnInputFile.Text = "Nhập dữ liệu";
            this.mbtnInputFile.UseSelectable = true;
            this.mbtnInputFile.Click += new System.EventHandler(this.mbtnInputFile_Click);
            // 
            // frmImportRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 349);
            this.Controls.Add(this.mbtnInputFile);
            this.Controls.Add(this.mbtnChooseFile);
            this.Controls.Add(this.dgvCauHinh);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmImportRoom";
            this.Resizable = false;
            this.ShowIcon = false;
            this.Text = "Nhập dữ liệu từ Excel";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCauHinh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgvCauHinh;
        private MetroFramework.Controls.MetroButton mbtnChooseFile;
        private MetroFramework.Controls.MetroButton mbtnInputFile;
    }
}