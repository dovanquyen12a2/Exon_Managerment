namespace EXON.GradedEssay.Report
{
    partial class frmResultSum
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
               this.KetQuaTongBindingSource = new System.Windows.Forms.BindingSource(this.components);
               this.reportDataset = new EXON.GradedEssay.Report.ReportDataset();
               this.thiSinhBoThiBindingSource = new System.Windows.Forms.BindingSource(this.components);
               this.rpvSum = new Microsoft.Reporting.WinForms.ReportViewer();
               ((System.ComponentModel.ISupportInitialize)(this.KetQuaTongBindingSource)).BeginInit();
               ((System.ComponentModel.ISupportInitialize)(this.reportDataset)).BeginInit();
               ((System.ComponentModel.ISupportInitialize)(this.thiSinhBoThiBindingSource)).BeginInit();
               this.SuspendLayout();
               // 
               // KetQuaTongBindingSource
               // 
               this.KetQuaTongBindingSource.DataMember = "KetQuaTong";
               this.KetQuaTongBindingSource.DataSource = this.reportDataset;
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
               // rpvSum
               // 
               this.rpvSum.Dock = System.Windows.Forms.DockStyle.Fill;
               reportDataSource1.Name = "DataSet1";
               reportDataSource1.Value = this.KetQuaTongBindingSource;
               reportDataSource2.Name = "DataSet2";
               reportDataSource2.Value = this.thiSinhBoThiBindingSource;
               this.rpvSum.LocalReport.DataSources.Add(reportDataSource1);
               this.rpvSum.LocalReport.DataSources.Add(reportDataSource2);
               this.rpvSum.LocalReport.ReportEmbeddedResource = "EXON.GradedEssay.Report.rpKetQuaTongTNTL.rdlc";
               this.rpvSum.Location = new System.Drawing.Point(0, 0);
               this.rpvSum.Name = "rpvSum";
               this.rpvSum.Size = new System.Drawing.Size(649, 662);
               this.rpvSum.TabIndex = 0;
               // 
               // frmResultSum
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(649, 662);
               this.Controls.Add(this.rpvSum);
               this.Name = "frmResultSum";
               this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
               this.Text = "Kết quả tổng ba phần thi";
               this.Load += new System.EventHandler(this.frmResultSum_Load);
               ((System.ComponentModel.ISupportInitialize)(this.KetQuaTongBindingSource)).EndInit();
               ((System.ComponentModel.ISupportInitialize)(this.reportDataset)).EndInit();
               ((System.ComponentModel.ISupportInitialize)(this.thiSinhBoThiBindingSource)).EndInit();
               this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvSum;
        private ReportDataset reportDataset;
        private System.Windows.Forms.BindingSource thiSinhBoThiBindingSource;
        private System.Windows.Forms.BindingSource KetQuaTongBindingSource;
    }
}