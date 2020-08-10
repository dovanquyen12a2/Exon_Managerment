using EXON.SubData.Services;
using EXON.SubModel.Models;
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

namespace EXON.GradedEssay.Report
{
    public partial class frmReportPhieuDiemThiNoi : Form
    {
        #region Service
        private ContestService _ContestService;
        private ShiftService _ShiftService;
        private ScheduleService _ScheduleService;
        private SubjectService _SubjectService;
        private StaffService _StaffService;
        private DivisionShiftService _DivisionShiftService;
        private ContestantShiftService _ContestantShiftService;
        private ContestantService _ContestantService;
        private ContestantTestService _ContestantTestService;
        private AnswersheetService _AnswersheetService;
        private AnswersheetSpeakingService _AnswersheetSpeakingService;
        private AnswersheetWritingService _AnswersheetWritingService;
        private BagOfTestService _BagOfTestService;
        private TestService _TestService;
        private RoomTestService _RoomTestService;


        #endregion Service
        MTAQuizDbContext db = new MTAQuizDbContext();

        private int _DivisionShiftID { get; set; }
        private string _TeacherName1 { get; set; }
        private string _TeacherName2 { get; set; }
        private int _SubjectID { get; set; }
        public frmReportPhieuDiemThiNoi(int DivisionShiftID, string TeacherName1, string TeacherName2,int SubjectID)
        {
            InitializeComponent();
            InitializeService();
          
            _DivisionShiftID = DivisionShiftID;
            _TeacherName1 = TeacherName1;
            _TeacherName2 = TeacherName2;
            _SubjectID = SubjectID;
        }

        private void InitializeControl()
        {
            throw new NotImplementedException();
        }

        private void InitializeService()
        {
            _ContestService = new ContestService();
            _ShiftService = new ShiftService();
            _ScheduleService = new ScheduleService();
            _SubjectService = new SubjectService();
            _DivisionShiftService = new DivisionShiftService();
            _ContestantShiftService = new ContestantShiftService();
            _ContestantService = new ContestantService();
            _StaffService = new StaffService();
            _ContestantTestService = new ContestantTestService();
            _AnswersheetService = new AnswersheetService();
            _AnswersheetSpeakingService = new AnswersheetSpeakingService();
            _BagOfTestService = new BagOfTestService();
            _TestService = new TestService();
            _RoomTestService = new RoomTestService();
            _AnswersheetWritingService = new AnswersheetWritingService();
        }
        private void frmReportPhieuDiemThiNoi_Load(object sender, EventArgs e)
        {
            DIVISION_SHIFTS ds = new DIVISION_SHIFTS();
            ds = _DivisionShiftService.GetById(_DivisionShiftID);
            List<CONTESTANTS_SHIFTS> lstcs = new List<CONTESTANTS_SHIFTS>();
            lstcs = _ContestantShiftService.GetAllByDivisionShiftID(_DivisionShiftID).ToList();
            db = new MTAQuizDbContext();
            // lấy thông tin của kip thi

            LOCATION diadiem = db.LOCATIONS.Where(p => p.LocationID == ds.ROOMTEST.LocationID).FirstOrDefault();
            CONTEST kithi = db.CONTESTS.Where(p => p.ContestID == diadiem.ContestID).FirstOrDefault();
            if (lstcs.Count > 0)
            {
                int stt = 0;
                var listKetQua = lstcs
                                   .Select(p => new
                                   {
                                       STT = ++stt,
                                       SBD = p.CONTESTANT.ContestantCode,
                                       HoTen=p.CONTESTANT.FullName,
                                       NgaySinh = DatetimeConvert.ConvertUnixToDateTime((int)p.CONTESTANT.DOB).ToString("dd/MM/yyyy"),
                                   })
                                   .ToList();
                KetQuaThiTheoCaThiBindingSource.DataSource = listKetQua;
                _SubjectService = new SubjectService();
                SUBJECT sj = new SUBJECT();
                sj = _SubjectService.GetById(_SubjectID);

                // add parameter
                ReportParameter[] listPara = new ReportParameter[]{
                    new ReportParameter("ContestName",kithi.ContestName.ToUpper()),
                    new ReportParameter("LocationName",diadiem.LocationName),
                    new ReportParameter("NgayThi", DatetimeConvert.ConvertUnixToDateTime(ds.SHIFT.ShiftDate).ToString("dd/MM/yyyy")),
                      new ReportParameter("TeacherName1",_TeacherName1),
                      new ReportParameter("TeacherName2",_TeacherName2),
          
                    new ReportParameter("RoomTestName",ds.ROOMTEST.RoomTestName.ToUpper()),
                    new ReportParameter("StartTime",DatetimeConvert.ConvertUnixToDateTime(ds.SHIFT.StartTime).ToString("HH:mm")),
                    new ReportParameter("EndTime",DatetimeConvert.ConvertUnixToDateTime(ds.SHIFT.EndTime).ToString("HH:mm")),
                    new ReportParameter("SubjectName",sj.SubjectName.ToUpper()+" - Phần nói"),
                    new ReportParameter("Date",DatetimeConvert.GetDateTimeServer().ToString((@"\n\g\à\y dd \t\h\á\n\g MM \n\ă\m yyyy")))
                };
                this.rpvPhieuDiemNoi.LocalReport.SetParameters(listPara);
                this.rpvPhieuDiemNoi.LocalReport.Refresh();
            }
            this.rpvPhieuDiemNoi.RefreshReport();


        }
    }
    public class ContestantSpeaking
    {
        public string ContestantCode { get; set; }
        public int STT { get; set; }
        public string DOB { get; set; }
    }
}
