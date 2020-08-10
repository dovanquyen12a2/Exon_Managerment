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
    public partial class frmReportPhieuDiemThiVietXacNhan : Form
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
        private TestNumberService _TestNumberService;


        #endregion Service
        MTAQuizDbContext db = new MTAQuizDbContext();

        private int _DivisionShiftID { get; set; }
        private string _TeacherName1 { get; set; }
        private string _TeacherName2 { get; set; }
        private int _SubjectID { get; set; }
        public frmReportPhieuDiemThiVietXacNhan(int DivisionShiftID, string TeacherName1, string TeacherName2,int subjectID)
        {
            InitializeComponent();
            InitializeService();
            _DivisionShiftID = DivisionShiftID;
            _TeacherName1 = TeacherName1;
            _TeacherName2 = TeacherName2;
            _SubjectID = subjectID;
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
            _TestNumberService = new TestNumberService();
            _AnswersheetSpeakingService = new AnswersheetSpeakingService();
            _BagOfTestService = new BagOfTestService();
            _TestService = new TestService();
            _RoomTestService = new RoomTestService();
            _AnswersheetWritingService = new AnswersheetWritingService();
        }
        private string KetQua(int csID)
        {
            try
            {
                CONTESTANTS_SHIFTS cs = db.CONTESTANTS_SHIFTS.Where(p => p.ContestantShiftID== csID).SingleOrDefault();
                float diem = 0;
                try
                {
                    diem = (float)
                              (
                                  from ct in db.CONTESTANTS_TESTS.Where(k => k.Status > 0 && k.ContestantShiftID == cs.ContestantShiftID).ToList()
                                  from ans in db.ANSWERSHEETS.Where(k => k.ContestantTestID == ct.ContestantTestID).ToList()
                                  from answ in db.ANSWERSHEET_WRITING.Where(k => k.AnswerSheetID == ans.AnswerSheetID)
                                  select answ
                              )
                              .FirstOrDefault()
                              .WritingScore;
                }
                catch
                {
                    diem = 0;
                }

                return diem.ToString();
            }
            catch
            {

            }

            return "-";
        }
        private void frmReportPhieuDiemThiViet_Load(object sender, EventArgs e)
        {
            try
            {
                DIVISION_SHIFTS ds = new DIVISION_SHIFTS();
                ds = _DivisionShiftService.GetById(_DivisionShiftID);
                db = new MTAQuizDbContext();
                int stt = 0;
                var listContestant = (
                        //from ds in _DivisionShiftService.GetByShift(CurrentShiftID)
                        from cs in _ContestantShiftService.GetAllByDivisionShiftID(ds.DivisionShiftID)

                        from tn in _TestNumberService.GetAll()
                        where cs.ContestantShiftID == tn.ContestantShiftID && cs.SCHEDULE.SubjectID == _SubjectID
                        select new
                        {
                            STT = ++stt,
                            SoPhach = ds.DivisionShiftID.ToString() + "." + tn.TestNumberIndex.ToString(),
                            MaDe = _ContestantTestService.GetByContestantShiftId(cs.ContestantShiftID).TestID,
                            DiemThi = KetQua(cs.ContestantShiftID)
                        }).OrderBy(x => x.SoPhach).ToList();

                // lấy thông tin của kip thi
                _SubjectService = new SubjectService();
                SUBJECT sj = new SUBJECT();
                sj = _SubjectService.GetById(_SubjectID);
                LOCATION diadiem = db.LOCATIONS.Where(p => p.LocationID == ds.ROOMTEST.LocationID).FirstOrDefault();
                CONTEST kithi = db.CONTESTS.Where(p => p.ContestID == diadiem.ContestID).FirstOrDefault();
                if (listContestant.Count > 0)
                {

                    PhieuDiemThiVietBindingSource.DataSource = listContestant;

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
                    new ReportParameter("SubjectName",sj.SubjectName.ToUpper()+" - Phần viết"),
                    new ReportParameter("Date",DatetimeConvert.GetDateTimeServer().ToString((@"\n\g\à\y dd \t\h\á\n\g MM \n\ă\m yyyy")))
                };
                    this.rpvPhieuDiemViet.LocalReport.SetParameters(listPara);
                    this.rpvPhieuDiemViet.LocalReport.Refresh();
                }
                this.rpvPhieuDiemViet.RefreshReport();
            }

            catch (Exception ex)
            {

            }
        }
    }
   
}
