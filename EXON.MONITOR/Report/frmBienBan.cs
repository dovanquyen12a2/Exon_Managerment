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
    public partial class frmBienBan : Form
    {
        public frmBienBan()
        {
            InitializeComponent();
        }

        private string ContestantFullName;
        private string ContestantCode;

        private string OldLocation;
        private string NewLocation;
        private string OldRoom;
        private string NewRoom;
        private int divisionShiftID;

        public frmBienBan(string _OldLocation, string _NewLocation, string _OldRoom, string _NewRoom, int _divisionShiftID, string _FullName, string _Code)
        {
            InitializeComponent();
            this.OldLocation = _OldLocation;
            this.NewLocation = _NewLocation;
            this.OldRoom = _OldRoom;
            this.NewRoom = _NewRoom;
            this.divisionShiftID = _divisionShiftID;
            this.ContestantFullName = _FullName;
            this.ContestantCode = _Code;
        }

        private void frmBienBan_Load(object sender, EventArgs e)
        {
            this.sHIFTSTableAdapter.Connection.ConnectionString = EXON.MONITOR.Common.AppConfig.GetConnectString("MTA_QUIZ_1");
            this.rOOMTESTSTableAdapter.Connection.ConnectionString = AppConfig.GetConnectString("MTA_QUIZ_1");
            this.sHIFTSTableAdapter.Fill(mTA_QUIZ_8DataSet.SHIFTS, divisionShiftID);
            this.rOOMTESTSTableAdapter.Fill(mTA_QUIZ_8DataSet.ROOMTESTS, divisionShiftID);
            Microsoft.Reporting.WinForms.ReportParameter[] para = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
            new Microsoft.Reporting.WinForms.ReportParameter("OldLocation",OldLocation),
            new Microsoft.Reporting.WinForms.ReportParameter("NewLocation",NewLocation),
            new Microsoft.Reporting.WinForms.ReportParameter("NewRoom",NewRoom),
            new Microsoft.Reporting.WinForms.ReportParameter("FullName",ContestantFullName),
            new Microsoft.Reporting.WinForms.ReportParameter("Code",ContestantCode)
            };
            reportViewer1.LocalReport.SetParameters(para);
            this.reportViewer1.RefreshReport();
        }
    }
}