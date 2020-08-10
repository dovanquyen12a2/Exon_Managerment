

namespace EXON.MONITOR.Report
{
    partial class frmBienBan
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
            this.sHIFTSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mTA_QUIZ_8DataSet = new MTA_QUIZ_8DataSet();
            this.rOOMTESTSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sHIFTSTableAdapter = new MTA_QUIZ_8DataSetTableAdapters.SHIFTSTableAdapter();
            this.rOOMTESTSTableAdapter = new MTA_QUIZ_8DataSetTableAdapters.ROOMTESTSTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sHIFTSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTA_QUIZ_8DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOOMTESTSBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // sHIFTSBindingSource
            // 
            this.sHIFTSBindingSource.DataMember = "SHIFTS";
            this.sHIFTSBindingSource.DataSource = this.mTA_QUIZ_8DataSet;
            // 
            // mTA_QUIZ_8DataSet
            // 
            this.mTA_QUIZ_8DataSet.DataSetName = "MTA_QUIZ_8DataSet";
            this.mTA_QUIZ_8DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rOOMTESTSBindingSource
            // 
            this.rOOMTESTSBindingSource.DataMember = "ROOMTESTS";
            this.rOOMTESTSBindingSource.DataSource = this.mTA_QUIZ_8DataSet;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sHIFTSBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.rOOMTESTSBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "EXON.MONITOR.Report.ReportChangeComputer.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(696, 661);
            this.reportViewer1.TabIndex = 0;
            // 
            // sHIFTSTableAdapter
            // 
            this.sHIFTSTableAdapter.ClearBeforeFill = true;
            // 
            // rOOMTESTSTableAdapter
            // 
            this.rOOMTESTSTableAdapter.ClearBeforeFill = true;
            // 
            // frmBienBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 661);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmBienBan";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biên bản chuyển chỗ";
            this.Load += new System.EventHandler(this.frmBienBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sHIFTSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTA_QUIZ_8DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOOMTESTSBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sHIFTSBindingSource;
        private MTA_QUIZ_8DataSet mTA_QUIZ_8DataSet;
        private System.Windows.Forms.BindingSource rOOMTESTSBindingSource;
        private MTA_QUIZ_8DataSetTableAdapters.SHIFTSTableAdapter sHIFTSTableAdapter;
        private MTA_QUIZ_8DataSetTableAdapters.ROOMTESTSTableAdapter rOOMTESTSTableAdapter;
    }
}