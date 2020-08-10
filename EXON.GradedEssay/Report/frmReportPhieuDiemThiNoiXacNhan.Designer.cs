namespace EXON.GradedEssay.Report
{
    partial class frmReportPhieuDiemThiNoiXacNhan
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
            this.ReportDataset = new EXON.GradedEssay.Report.ReportDataset();
            this.KetQuaThiTheoCaThiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvPhieuDiemNoi = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KetQuaThiTheoCaThiBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportDataset
            // 
            this.ReportDataset.DataSetName = "ReportDataset";
            this.ReportDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // KetQuaThiTheoCaThiBindingSource
            // 
            this.KetQuaThiTheoCaThiBindingSource.DataMember = "KetQuaThiTheoCaThi";
            this.KetQuaThiTheoCaThiBindingSource.DataSource = this.ReportDataset;
            // 
            // rpvPhieuDiemNoi
            // 
            this.rpvPhieuDiemNoi.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.KetQuaThiTheoCaThiBindingSource;
            this.rpvPhieuDiemNoi.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvPhieuDiemNoi.LocalReport.ReportEmbeddedResource = "EXON.GradedEssay.Report.rpPhieuDiemThiNoiXacNhan.rdlc";
            this.rpvPhieuDiemNoi.Location = new System.Drawing.Point(0, 0);
            this.rpvPhieuDiemNoi.Name = "rpvPhieuDiemNoi";
            this.rpvPhieuDiemNoi.Size = new System.Drawing.Size(649, 662);
            this.rpvPhieuDiemNoi.TabIndex = 0;
            // 
            // frmReportPhieuDiemThiNoiXacNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 662);
            this.Controls.Add(this.rpvPhieuDiemNoi);
            this.Name = "frmReportPhieuDiemThiNoiXacNhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu điểm thi nói";
            this.Load += new System.EventHandler(this.frmReportPhieuDiemThiNoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportDataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KetQuaThiTheoCaThiBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvPhieuDiemNoi;
        private System.Windows.Forms.BindingSource KetQuaThiTheoCaThiBindingSource;
        private ReportDataset ReportDataset;
    }
}