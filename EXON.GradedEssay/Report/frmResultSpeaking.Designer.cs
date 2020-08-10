using EXON.GradedEssay.Report;

namespace EXON.MONITOR.Report
{
    partial class frmResultSpeaking
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
            this.ThiSinhDangKyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReportDataset = new EXON.GradedEssay.Report.ReportDataset();
            this.thiSinhBoThiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvSpeaking = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ThiSinhDangKyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thiSinhBoThiBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ThiSinhDangKyBindingSource
            // 
            this.ThiSinhDangKyBindingSource.DataMember = "ThiSinhDangKy";
            this.ThiSinhDangKyBindingSource.DataSource = this.ReportDataset;
            // 
            // ReportDataset
            // 
            this.ReportDataset.DataSetName = "ReportDataset";
            this.ReportDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // thiSinhBoThiBindingSource
            // 
            this.thiSinhBoThiBindingSource.DataMember = "ThiSinhBoThi";
            this.thiSinhBoThiBindingSource.DataSource = this.ReportDataset;
            // 
            // rpvSpeaking
            // 
            this.rpvSpeaking.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "ThiSinhDangKy";
            reportDataSource1.Value = this.ThiSinhDangKyBindingSource;
            reportDataSource2.Name = "Dataset1";
            reportDataSource2.Value = this.thiSinhBoThiBindingSource;
            this.rpvSpeaking.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvSpeaking.LocalReport.DataSources.Add(reportDataSource2);
            this.rpvSpeaking.LocalReport.ReportEmbeddedResource = "EXON.GradedEssay.Report.rpKetQuaTheoMonThi.rdlc";
            this.rpvSpeaking.Location = new System.Drawing.Point(0, 0);
            this.rpvSpeaking.Name = "rpvSpeaking";
            this.rpvSpeaking.Size = new System.Drawing.Size(665, 701);
            this.rpvSpeaking.TabIndex = 1;
            // 
            // frmResultSpeaking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 701);
            this.Controls.Add(this.rpvSpeaking);
            this.Name = "frmResultSpeaking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết quả thi nói";
            this.Load += new System.EventHandler(this.frmResultSpeaking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ThiSinhDangKyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thiSinhBoThiBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvSpeaking;
        private ReportDataset ReportDataset;
        private System.Windows.Forms.BindingSource thiSinhBoThiBindingSource;
        private System.Windows.Forms.BindingSource ThiSinhDangKyBindingSource;
    }
}