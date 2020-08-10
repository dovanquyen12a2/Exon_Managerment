using EXON.Common;
using EXON.MONITOR.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXON.MONITOR.Report
{
    public partial class frmBienBanChuyenCaThi : Form
    {
        private string code;
        private string FullName;
        private string Reason;
        private string CMND;
        private int divisionShiftID;

        public frmBienBanChuyenCaThi()
        {
            InitializeComponent();
        }

        public frmBienBanChuyenCaThi(string _code, string _FullName, string _Reason, string _CMND, int _divisionShiftID)
        {
            InitializeComponent();
            this.code = _code;
            this.FullName = _FullName;
            this.Reason = _Reason;
            this.CMND = _CMND;
            this.divisionShiftID = _divisionShiftID;
        }

        private void frmBienBanChuyenCaThi_Load(object sender, EventArgs e)
        {
            try
            {
                this.sHIFTSTableAdapter.Connection.ConnectionString = AppConfig.GetConnectString("MTA_QUIZ_1");
                this.rOOMTESTSTableAdapter.Connection.ConnectionString = AppConfig.GetConnectString("MTA_QUIZ_1");
                this.sHIFTSTableAdapter.Fill(mTA_QUIZ_8DataSet.SHIFTS, divisionShiftID);
                this.rOOMTESTSTableAdapter.Fill(mTA_QUIZ_8DataSet.ROOMTESTS, divisionShiftID);
                Microsoft.Reporting.WinForms.ReportParameter[] para = new Microsoft.Reporting.WinForms.ReportParameter[]
    {
            new Microsoft.Reporting.WinForms.ReportParameter("ReasonChange",Reason),
            new Microsoft.Reporting.WinForms.ReportParameter("CMND",CMND),
            new Microsoft.Reporting.WinForms.ReportParameter("FullName",FullName),
            new Microsoft.Reporting.WinForms.ReportParameter("Code",code)
    };
                reportViewer1.LocalReport.SetParameters(para);
                this.reportViewer1.RefreshReport();
            }
            catch(Exception ex)
            {
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }
        }
    }
}