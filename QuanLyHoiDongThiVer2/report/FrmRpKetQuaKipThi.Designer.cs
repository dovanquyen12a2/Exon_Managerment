namespace QuanLyHoiDongThiVer2.report
{
    partial class FrmRpKetQuaKipThi
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rpKetQuaKipThi = new Microsoft.Reporting.WinForms.ReportViewer();
            this.KetQuaTheoKipBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReportDataSet = new QuanLyHoiDongThiVer2.report.ReportDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.KetQuaTheoKipBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // rpKetQuaKipThi
            // 
            this.rpKetQuaKipThi.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.KetQuaTheoKipBindingSource;
            this.rpKetQuaKipThi.LocalReport.DataSources.Add(reportDataSource1);
            this.rpKetQuaKipThi.LocalReport.ReportEmbeddedResource = "QuanLyHoiDongThiVer2.report.rpKetQuaTheoCaThi.rdlc";
            this.rpKetQuaKipThi.Location = new System.Drawing.Point(0, 0);
            this.rpKetQuaKipThi.Name = "rpKetQuaKipThi";
            this.rpKetQuaKipThi.Size = new System.Drawing.Size(665, 701);
            this.rpKetQuaKipThi.TabIndex = 0;
            // 
            // KetQuaTheoKipBindingSource
            // 
            this.KetQuaTheoKipBindingSource.DataMember = "KetQuaTheoKip";
            this.KetQuaTheoKipBindingSource.DataSource = this.ReportDataSet;
            // 
            // ReportDataSet
            // 
            this.ReportDataSet.DataSetName = "ReportDataSet";
            this.ReportDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FrmRpKetQuaKipThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 701);
            this.Controls.Add(this.rpKetQuaKipThi);
            this.MaximizeBox = false;
            this.Name = "FrmRpKetQuaKipThi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết quả kíp thi";
            this.Load += new System.EventHandler(this.FrmRpKetQuaKipThi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KetQuaTheoKipBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpKetQuaKipThi;
        private System.Windows.Forms.BindingSource KetQuaTheoKipBindingSource;
        private ReportDataSet ReportDataSet;
    }
}