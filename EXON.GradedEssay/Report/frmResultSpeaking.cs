using EXON.GradedEssay;
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

namespace EXON.MONITOR.Report
{
    public partial class frmResultSpeaking : Form
    {
        MTAQuizDbContext db = new MTAQuizDbContext();
        private ISubjectService _SubjectService;

        private DIVISION_SHIFTS divisionShift = new DIVISION_SHIFTS();
        private int _subjectID;
        #region Service
        private ContestService _ContestService;
        private ShiftService _ShiftService;
        private ScheduleService _ScheduleService;

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
        private int _divisionShiftID = 0;
        #endregion Service
        public frmResultSpeaking(int divisionshiftID, int SubjectID)
        {
            InitializeComponent();
            divisionShift = db.DIVISION_SHIFTS.Where(x => x.DivisionShiftID == divisionshiftID).SingleOrDefault();
            _divisionShiftID = divisionshiftID;
            _subjectID = SubjectID;
        }
        public frmResultSpeaking(int SubjectID)
        {
            InitializeComponent();

            _subjectID = SubjectID;
        }
        private string KetQua(int contestantShiftID)
        {
            _ContestantTestService = new ContestantTestService();
            _AnswersheetService = new AnswersheetService();
            _AnswersheetSpeakingService = new AnswersheetSpeakingService();
            CONTESTANTS_TESTS ct = new CONTESTANTS_TESTS();
            ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID);
            if (ct != null)
            {
                ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);
                if (anw != null)
                {
                    ANSWERSHEET_SPEAKING aw = _AnswersheetSpeakingService.GetByAnwsersheetID(anw.AnswerSheetID);

                    if (aw != null)
                    {
                        return (aw.SpeakingScore).ToString();
                    }
                }


            }
            return string.Empty;
        }
        private int GetTestID(int contestantShiftID)
        {
            db = new MTAQuizDbContext();
            CONTESTANTS_TESTS cts = new CONTESTANTS_TESTS();
            cts = db.CONTESTANTS_TESTS.Where(x => x.ContestantShiftID == contestantShiftID).SingleOrDefault();
            if (cts != null)
            {
                return cts.TestID;
            }
            else
            {
                return -1;
            }
        }
        private void frmResultSpeaking_Load(object sender, EventArgs e)
        {
            try
            {
                if (_divisionShiftID > 0)
                {
                    db = new MTAQuizDbContext();
                    // lấy thông tin của kip thi

                    LOCATION diadiem = db.LOCATIONS.Where(p => p.LocationID == divisionShift.ROOMTEST.LocationID).FirstOrDefault();
                    CONTEST kithi = db.CONTESTS.Where(p => p.ContestID == diadiem.ContestID).FirstOrDefault();
                    // Lấy ra danh sách các thí sinh thi c
                    List<CONTESTANTS_SHIFTS> listThiSinh = new List<CONTESTANTS_SHIFTS>();
                    listThiSinh = db.CONTESTANTS_SHIFTS.Where(x => x.DivisionShiftID == divisionShift.DivisionShiftID /*&& x.Status == 3005*/).ToList();
                    // Lấy ra kết quả thi
                    int stt = 0;
                    var listKetQua = listThiSinh
                                     .Select(p => new
                                     {
                                         STT = ++stt,
                                         SBD = p.CONTESTANT.ContestantCode,
                                         HoTen = p.CONTESTANT.FullName,
                                         NgaySinh = DatetimeConvert.ConvertUnixToDateTime((int)p.CONTESTANT.DOB).ToString("dd/MM/yyyy"),

                                         MonThi = p.SCHEDULE.SUBJECT.SubjectName,
                                         DiemThi = KetQua(p.ContestantShiftID),
                                         Lop = p.CONTESTANT.Unit
                                     })
                                     .ToList();
                    ThiSinhDangKyBindingSource.DataSource = listKetQua;
                    List<CONTESTANTS_SHIFTS> listThiSinhBoThi = new List<CONTESTANTS_SHIFTS>();
                    listThiSinhBoThi = db.CONTESTANTS_SHIFTS.Where(x => x.DivisionShiftID == divisionShift.DivisionShiftID && x.Status == 4001).ToList();
                    stt = 0;
                    var lstThiSinhBoThi = listThiSinhBoThi
                                     .Select(p => new
                                     {
                                         STT = ++stt,
                                         SBD = p.CONTESTANT.ContestantCode,
                                         HoTen = p.CONTESTANT.FullName,
                                         NgaySinh = DatetimeConvert.ConvertUnixToDateTime((int)p.CONTESTANT.DOB).ToString("dd/MM/yyyy"),
                                         // CMND = p.CONTESTANT.IdentityCardNumber,
                                        
                                     })
                                     .ToList();
                    thiSinhBoThiBindingSource.DataSource = lstThiSinhBoThi;
                    SUBJECT sj = new SUBJECT();
                    _SubjectService = new SubjectService();
                    sj = _SubjectService.GetById(_subjectID);

                    // add parameter
                    ReportParameter[] listPara = new ReportParameter[]{
                    new ReportParameter("ContestName",kithi.ContestName.ToUpper()),
                    new ReportParameter("SubjectName",sj.SubjectName),
                    new ReportParameter("RegisterDate",DatetimeConvert.GetDateTimeServer().ToString((@"\n\g\à\y dd \t\h\á\n\g MM \n\ă\m yyyy")))
                };
                    this.rpvSpeaking.LocalReport.SetParameters(listPara);
                    this.rpvSpeaking.LocalReport.Refresh();
                    this.rpvSpeaking.RefreshReport();
                }
                else
                {
                    if (_subjectID > 0)
                    {
                        int stt = 0;
                        _ContestantShiftService = new ContestantShiftService();
                        _TestNumberService = new TestNumberService();
                                var listKetQua = (

                             from cs in _ContestantShiftService.GetAll().Where(x => x.SCHEDULE.SubjectID == _subjectID)

                             from tn in _TestNumberService.GetAll()
                             where cs.ContestantShiftID == tn.ContestantShiftID && cs.SCHEDULE.SubjectID == _subjectID
                             select new
                                                         {
                                 STT = ++stt,

                                 SBD = cs.CONTESTANT.ContestantCode,
                                 HoTen = cs.CONTESTANT.FullName,
                                 NgaySinh = DatetimeConvert.ConvertUnixToDateTime((int)cs.CONTESTANT.DOB).ToString("dd/MM/yyyy"),

                                 MonThi = cs.SCHEDULE.SUBJECT.SubjectName,
                                 DiemThi = KetQua(cs.ContestantShiftID),
                                 Lop = cs.CONTESTANT.Unit

                             }).ToList();
                        ThiSinhDangKyBindingSource.DataSource = listKetQua;
                        SUBJECT sj = new SUBJECT();
                        _SubjectService = new SubjectService();
                        sj = _SubjectService.GetById(_subjectID);

                        // add parameter
                        ReportParameter[] listPara = new ReportParameter[]{
                    new ReportParameter("ContestName","Tốt nghiệp ngoại ngữ Khóa 50 (Tháng 9.2019)"),
                    new ReportParameter("SubjectName",sj.SubjectName),
                    new ReportParameter("RegisterDate",DatetimeConvert.GetDateTimeServer().ToString((@"\n\g\à\y dd \t\h\á\n\g MM \n\ă\m yyyy")))
                };
                        this.rpvSpeaking.LocalReport.SetParameters(listPara);
                        this.rpvSpeaking.LocalReport.Refresh();
                        this.rpvSpeaking.RefreshReport();
                    }
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.rpvSpeaking.LocalReport.Refresh();
            this.rpvSpeaking.RefreshReport();
            this.rpvSpeaking.RefreshReport();
        }
    }
}
