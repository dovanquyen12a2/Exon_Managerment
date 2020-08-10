namespace QuanLyHoiDongThiVer2.report
{
    partial class frmRpKetQuaCaThi
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportDataSet = new QuanLyHoiDongThiVer2.report.ReportDataSet();
            this.rpKetQuaKipThi = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ketQuaThiTheoCaThi1BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.thiSinhBoThiBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.reportDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ketQuaThiTheoCaThi1BindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thiSinhBoThiBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportDataSet
            // 
            this.reportDataSet.DataSetName = "ReportDataSet";
            this.reportDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rpKetQuaKipThi
            // 
            this.rpKetQuaKipThi.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet2";
            reportDataSource1.Value = this.ketQuaThiTheoCaThi1BindingSource1;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.thiSinhBoThiBindingSource1;
            this.rpKetQuaKipThi.LocalReport.DataSources.Add(reportDataSource1);
            this.rpKetQuaKipThi.LocalReport.DataSources.Add(reportDataSource2);
            this.rpKetQuaKipThi.LocalReport.ReportEmbeddedResource = "QuanLyHoiDongThiVer2.report.rpKetQuaTheoCaThi2.rdlc";
            this.rpKetQuaKipThi.Location = new System.Drawing.Point(0, 0);
            this.rpKetQuaKipThi.Name = "rpKetQuaKipThi";
            this.rpKetQuaKipThi.Size = new System.Drawing.Size(712, 701);
            this.rpKetQuaKipThi.TabIndex = 1;
            // 
            // ketQuaThiTheoCaThi1BindingSource1
            // 
            this.ketQuaThiTheoCaThi1BindingSource1.DataMember = "KetQuaThiTheoCaThi1";
            this.ketQuaThiTheoCaThi1BindingSource1.DataSource = this.reportDataSet;
            // 
            // thiSinhBoThiBindingSource1
            // 
            this.thiSinhBoThiBindingSource1.DataMember = "ThiSinhBoThi";
            this.thiSinhBoThiBindingSource1.DataSource = this.reportDataSet;
            // 
            // frmRpKetQuaCaThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 701);
            this.Controls.Add(this.rpKetQuaKipThi);
            this.Name = "frmRpKetQuaCaThi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết quả ca thi";
            this.Load += new System.EventHandler(this.FrmRpKetQuaCaThi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ketQuaThiTheoCaThi1BindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thiSinhBoThiBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpKetQuaKipThi;
        private ReportDataSet reportDataSet;
        private System.Windows.Forms.BindingSource ketQuaThiTheoCaThi1BindingSource1;
        private System.Windows.Forms.BindingSource thiSinhBoThiBindingSource1;
    }
}