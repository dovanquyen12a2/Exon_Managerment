using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXON.SubModel.Models;
using EXON.SubData.Services;
namespace EXON.MONITOR.Report
{
    public partial class frmBienBanContestantPause : Form
    {
        private IContestantShiftService _ContestantShiftService;
        private int _cshID;
        private int _ThoiGianGianDoan;
        private string _LyDoGianDoan;

        public frmBienBanContestantPause(int CSHID , int ThoiGianGianDoan, string LyDo)
        {
            InitializeComponent();
            _cshID = CSHID;
            _ThoiGianGianDoan = ThoiGianGianDoan;
            _LyDoGianDoan = LyDo;
            _ContestantShiftService = new ContestantShiftService();
        }

        private void frmBienBanContestantPause_Load(object sender, EventArgs e)
        {

            DIVISION_SHIFTS ds = new DIVISION_SHIFTS();
            CONTESTANTS_SHIFTS csh = new CONTESTANTS_SHIFTS();
            csh = _ContestantShiftService.GetById(_cshID);
            
            int NgaySinh = csh.CONTESTANT.DOB ?? default(int);
            string date = Common.DatetimeConvert.GetDateTimeServer().ToString(@"\n\g\à\y dd \t\h\á\n\g MM \n\ă\m yyyy");

            // add parameter
            ReportParameter[] listPara = new ReportParameter[]{
                    new ReportParameter("RoomTestName",csh.DIVISION_SHIFTS.ROOMTEST.RoomTestName),
                    new ReportParameter("NgayThi",Common.DatetimeConvert.ConvertUnixToDateTime(csh.DIVISION_SHIFTS.SHIFT.ShiftDate).ToString("dd/MM/yyyy")),
                     new ReportParameter("StartTime",Common.DatetimeConvert.ConvertUnixToDateTime(csh.DIVISION_SHIFTS.SHIFT.StartTime).ToString("HH: mm:ss")),
                     new ReportParameter("EndTime",Common.DatetimeConvert.ConvertUnixToDateTime(csh.DIVISION_SHIFTS.SHIFT.EndTime).ToString("HH: mm:ss")),
                    new ReportParameter("LocationName",csh.DIVISION_SHIFTS.ROOMTEST.LOCATION.LocationName.ToUpper()),

                new ReportParameter("ContestName",csh.DIVISION_SHIFTS.ROOMTEST.LOCATION.CONTEST.ContestName.ToUpper()),
                    
                      new ReportParameter("ContestantName",csh.CONTESTANT.FullName),
                      new ReportParameter("ContestantCode",csh.CONTESTANT.ContestantCode),
                      new ReportParameter("NgaySinh",Common.DatetimeConvert.ConvertUnixToDateTime(NgaySinh).ToString(@"\n\g\à\y dd \t\h\á\n\g MM \n\ă\m yyyy")),
                      new ReportParameter("Unit",csh.CONTESTANT.Unit),
                      new ReportParameter("TimePause",Common.DatetimeConvert.ConvertUnixToDateTime(_ThoiGianGianDoan).ToString("HH: mm:ss")),
                      new ReportParameter("ReasonPause",_LyDoGianDoan),
                        new ReportParameter("Date",date),
                };
            this.reportViewer1.LocalReport.SetParameters(listPara);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }
    }
}
