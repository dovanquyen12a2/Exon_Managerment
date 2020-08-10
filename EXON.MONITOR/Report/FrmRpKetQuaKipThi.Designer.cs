namespace EXON.MONITOR.Report
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ketQuaThiTheoCaThiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportDataset = new EXON.MONITOR.Report.ReportDataset();
            this.thiSinhBoThiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpKetQuaKipThi = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ketQuaThiTheoCaThiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportDataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thiSinhBoThiBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ketQuaThiTheoCaThiBindingSource
            // 
            this.ketQuaThiTheoCaThiBindingSource.DataMember = "KetQuaThiTheoCaThi";
            this.ketQuaThiTheoCaThiBindingSource.DataSource = this.reportDataset;
            // 
            // reportDataset
            // 
            this.reportDataset.DataSetName = "ReportDataset";
            this.reportDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // thiSinhBoThiBindingSource
            // 
            this.thiSinhBoThiBindingSource.DataMember = "ThiSinhBoThi";
            this.thiSinhBoThiBindingSource.DataSource = this.reportDataset;
            // 
            // rpKetQuaKipThi
            // 
            this.rpKetQuaKipThi.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet2";
            reportDataSource1.Value = this.ketQuaThiTheoCaThiBindingSource;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.thiSinhBoThiBindingSource;
            this.rpKetQuaKipThi.LocalReport.DataSources.Add(reportDataSource1);
            this.rpKetQuaKipThi.LocalReport.DataSources.Add(reportDataSource2);
            this.rpKetQuaKipThi.LocalReport.ReportEmbeddedResource = "EXON.MONITOR.Report.rpKetQuaTheoCaThi.rdlc";
            this.rpKetQuaKipThi.Location = new System.Drawing.Point(0, 0);
            this.rpKetQuaKipThi.Name = "rpKetQuaKipThi";
            this.rpKetQuaKipThi.Size = new System.Drawing.Size(712, 701);
            this.rpKetQuaKipThi.TabIndex = 0;
            // 
            // FrmRpKetQuaKipThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 701);
            this.Controls.Add(this.rpKetQuaKipThi);
            this.MaximizeBox = false;
            this.Name = "FrmRpKetQuaKipThi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết quả kíp thi";
            this.Load += new System.EventHandler(this.FrmRpKetQuaKipThi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ketQuaThiTheoCaThiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportDataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thiSinhBoThiBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpKetQuaKipThi;
        private System.Windows.Forms.BindingSource ketQuaThiTheoCaThiBindingSource;
        private EXON.MONITOR.Report.ReportDataset reportDataset;
        private System.Windows.Forms.BindingSource thiSinhBoThiBindingSource;
    }
}