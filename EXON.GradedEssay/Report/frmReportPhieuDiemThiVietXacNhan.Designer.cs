﻿namespace EXON.GradedEssay.Report
{
    partial class frmReportPhieuDiemThiVietXacNhan
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
            this.rpvPhieuDiemViet = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ReportDataset = new EXON.GradedEssay.Report.ReportDataset();
            this.PhieuDiemThiVietBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ReportDataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhieuDiemThiVietBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvPhieuDiemViet
            // 
            this.rpvPhieuDiemViet.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.PhieuDiemThiVietBindingSource;
            this.rpvPhieuDiemViet.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvPhieuDiemViet.LocalReport.ReportEmbeddedResource = "EXON.GradedEssay.Report.rpPhieuDiemThiVietXacNhan.rdlc";
            this.rpvPhieuDiemViet.Location = new System.Drawing.Point(0, 0);
            this.rpvPhieuDiemViet.Name = "rpvPhieuDiemViet";
            this.rpvPhieuDiemViet.Size = new System.Drawing.Size(649, 662);
            this.rpvPhieuDiemViet.TabIndex = 1;
            // 
            // ReportDataset
            // 
            this.ReportDataset.DataSetName = "ReportDataset";
            this.ReportDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PhieuDiemThiVietBindingSource
            // 
            this.PhieuDiemThiVietBindingSource.DataMember = "PhieuDiemThiViet";
            this.PhieuDiemThiVietBindingSource.DataSource = this.ReportDataset;
            // 
            // frmReportPhieuDiemThiVietXacNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 662);
            this.Controls.Add(this.rpvPhieuDiemViet);
            this.Name = "frmReportPhieuDiemThiVietXacNhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu điểm thi viết";
            this.Load += new System.EventHandler(this.frmReportPhieuDiemThiViet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportDataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhieuDiemThiVietBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvPhieuDiemViet;
        private System.Windows.Forms.BindingSource PhieuDiemThiVietBindingSource;
        private ReportDataset ReportDataset;
    }
}