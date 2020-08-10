using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXON.SubData.Services;
using EXON.SubModel.Models;
using Microsoft.Reporting.WinForms;

namespace EXON.MONITOR.Report
{
    public partial class frmBienBanTamDungPhong : Form
    {
        private IDivisionShiftService _DivisionShiftService;
        private int _ThoiGianGianDoan;
        private int _DivisionShiftID;
        private string _LyDoGianDoan;
        public frmBienBanTamDungPhong(int DivisionShiftID, int ThoiGianBu, string LyDo)
        {
            InitializeComponent();
            _DivisionShiftID = DivisionShiftID;
            _ThoiGianGianDoan = ThoiGianBu;
            _LyDoGianDoan = LyDo;
        }

        private void frmBienBanTamDungPhong_Load(object sender, EventArgs e)
        {
            DIVISION_SHIFTS ds = new DIVISION_SHIFTS();
            _DivisionShiftService = new DivisionShiftService();
            ds = _DivisionShiftService.GetById(_DivisionShiftID);

            string date = Common.DatetimeConvert.GetDateTimeServer().ToString(@"\n\g\à\y dd \t\h\á\n\g MM \n\ă\m yyyy");
            // add parameter
            ReportParameter[] listPara = new ReportParameter[]{
                  new ReportParameter("RoomTestName",ds.ROOMTEST.RoomTestName.ToLower()),
                    new ReportParameter("ContestName",ds.ROOMTEST.LOCATION.CONTEST.ContestName.ToUpper()),
                    new ReportParameter("LocationName",ds.ROOMTEST.LOCATION.LocationName.ToUpper()),
                  
                     new ReportParameter("StartTime",Common.DatetimeConvert.ConvertUnixToDateTime(ds.SHIFT.StartTime).ToString("HH: mm:ss")),
                     new ReportParameter("EndTime",Common.DatetimeConvert.ConvertUnixToDateTime(ds.SHIFT.EndTime).ToString("HH: mm:ss")),
                    new ReportParameter("NgayThi",Common.DatetimeConvert.ConvertUnixToDateTime(ds.SHIFT.ShiftDate).ToString("dd/MM/yyyy")),
                    new ReportParameter("Date",date),
                  
                      new ReportParameter("TimePause",Common.DatetimeConvert.ConvertUnixToDateTime(_ThoiGianGianDoan).ToString("HH: mm:ss")),
                      new ReportParameter("ReasonPause",_LyDoGianDoan),
                };
            this.reportViewer1.LocalReport.SetParameters(listPara);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
       
        }
    }
}
