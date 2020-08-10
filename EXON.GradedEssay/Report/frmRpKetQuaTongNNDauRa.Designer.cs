namespace EXON.GradedEssay.Report
{
    partial class frmRpKetQuaTongNNDauRa
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
            this.KetQuaTongBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReportDataset = new EXON.GradedEssay.Report.ReportDataset();
            this.rpvSum = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.KetQuaTongBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDataset)).BeginInit();
            this.SuspendLayout();
            // 
            // KetQuaTongBindingSource
            // 
            this.KetQuaTongBindingSource.DataMember = "KetQuaTong";
            this.KetQuaTongBindingSource.DataSource = this.ReportDataset;
            // 
            // ReportDataset
            // 
            this.ReportDataset.DataSetName = "ReportDataset";
            this.ReportDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rpvSum
            // 
            this.rpvSum.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.KetQuaTongBindingSource;
            this.rpvSum.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvSum.LocalReport.ReportEmbeddedResource = "EXON.GradedEssay.Report.rpKetQuaTongDauRaNN.rdlc";
            this.rpvSum.Location = new System.Drawing.Point(0, 0);
            this.rpvSum.Name = "rpvSum";
            this.rpvSum.Size = new System.Drawing.Size(850, 749);
            this.rpvSum.TabIndex = 1;
            // 
            // frmRpKetQuaTongNNDauRa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 749);
            this.Controls.Add(this.rpvSum);
            this.Name = "frmRpKetQuaTongNNDauRa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết quả ngoại ngữ đầu ra";
            this.Load += new System.EventHandler(this.FrmRpKetQuaTongNNDauRa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KetQuaTongBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDataset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvSum;
        private System.Windows.Forms.BindingSource KetQuaTongBindingSource;
        private ReportDataset ReportDataset;
    }
}