using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXON.SubData.Services;
using EXON.SubModel.Models;
using EXON.Common;


namespace EXON.GradedEssay.Control
{
    public partial class ucReport : UserControl
    {
        #region Service
        private IContestService _ContestService;
        private IShiftService _ShiftService;
        private IScheduleService _ScheduleService;
        private ISubjectService _SubjectService;
        private IStaffService _StaffService;
        private IDivisionShiftService _DivisionShiftService;
        private IContestantShiftService _ContestantShiftService;
        private IContestantService _ContestantService;
        private IContestantTestService _ContestantTestService;
        private IAnswersheetService _AnswersheetService;
        private IAnswersheetSpeakingService _AnswersheetSpeakingService;
        private IAnswersheetWritingService _AnswersheetWritingService;
        private IBagOfTestService _BagOfTestService;
        private ITestService _TestService;
        private IRoomTestService _RoomTestService;
        private IAnswersheetDetailService _AnswersheetDetailService;
        private IAnswerService _AnswerService;

        #endregion Service

        private int CurrentShiftID
        {
            get
            {
                try
                {
                    return int.Parse(cbShift.SelectedValue.ToString());
                }
                catch { return -1; }
            }
        }
        private int CurrentRoomTestID
        {
            get
            {
                try
                {
                    return int.Parse(cbRoomTest.SelectedValue.ToString());
                }
                catch { return -1; }
            }
        }
        private string CurrentUnit
        {
            get
            {
                try
                {
                    return cbLop.Text.ToString();
                }
                catch { return string.Empty; }
            }
        }
        private int CurrentSubjectID
        {
            get
            {
                try
                {
                    return int.Parse(cbSubject.SelectedValue.ToString());
                }
                catch { return -1; }
            }
        }
        private int _ContestID { get; set; }
        private int _LocationID { get; set; }
        public ucReport(int contestID, int LocationID)
        {
            _ContestID = contestID;
            _LocationID = LocationID;
            InitializeComponent();
            //btnPrintResult.Location = new Point(10,Screen.PrimaryScreen.WorkingArea.Width/2);
            InitializeService();
            InitializeControl();
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

        private void InitializeControl()
        {
               cbShift.DataSource = (from ds in _DivisionShiftService.GetAll().Where(x => x.ROOMTEST.LocationID == _LocationID)
                                     from s in _ShiftService.GetAll(_ContestID).Where(x => x.Status > 0)
                                     where ds.ShiftID == s.ShiftID
                                     select s).ToList();
               cbShift.DisplayMember = "ShiftName";
               cbShift.ValueMember = "ShiftID";
               // commbox roomtest
               cbRoomTest.DataSource = (from r in _RoomTestService.GetAllByLocation(_LocationID)
                                        from ds in _DivisionShiftService.GetAll()
                                        where CurrentShiftID == ds.ShiftID && r.RoomTestID == ds.RoomTestID
                                        select r).ToList();
               cbRoomTest.DisplayMember = "RoomTestName";
               cbRoomTest.ValueMember = "RoomTestID";

          }

        private void cbShift_SelectedValueChanged(object sender, EventArgs e)
        {

            _RoomTestService = new RoomTestService();
            _DivisionShiftService = new DivisionShiftService();

            cbRoomTest.DataSource = null;
            cbRoomTest.Text = "";
            // commbox roomtest
            cbRoomTest.DataSource = (from r in _RoomTestService.GetAll().Where(x => x.LOCATION.LocationID==_LocationID)
                                     from ds in _DivisionShiftService.GetAll()
                                     where CurrentShiftID == ds.ShiftID && r.RoomTestID == ds.RoomTestID
                                     select new
                                     {
                                         RoomTestName = r.RoomTestName,
                                         RoomTestID = r.RoomTestID
                                     }).ToList();
            cbRoomTest.DisplayMember = "RoomTestName";
            cbRoomTest.ValueMember = "RoomTestID";
            if (CurrentRoomTestID == -1)
            {
                gvMain.DataSource = null;
            }

        }

        private void cbRoomTest_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CurrentShiftID != -1 && CurrentRoomTestID != -1)
            {

                _ScheduleService = new ScheduleService();
                _DivisionShiftService = new DivisionShiftService();
                _ContestantShiftService = new ContestantShiftService();
                _SubjectService = new SubjectService();

              
                DIVISION_SHIFTS CurrentDs = new DIVISION_SHIFTS();
                CurrentDs = _DivisionShiftService.GetByShiftAndRoomTest(CurrentShiftID, CurrentRoomTestID);

                cbSubject.DataSource = (from r in _ScheduleService.GetAll()
                                        from ds in _ContestantShiftService.GetAllByDivisionShiftID(CurrentDs.DivisionShiftID)
                                        from sj in _SubjectService.GetAll()
                                        where r.ScheduleID == ds.ScheduleID && r.SubjectID == sj.SubjectID
                                        select new
                                        {
                                            SubjectName = sj.SubjectName,
                                            SubjectID = sj.SubjectID
                                        }).Distinct().ToList();
                cbSubject.DisplayMember = "SubjectName";
                cbSubject.ValueMember = "SubjectID";
                cbLop.DataSource = (
                                        from ds in _ContestantShiftService.GetAllByDivisionShiftID(CurrentDs.DivisionShiftID)

                                        select new
                                        {
                                            TenLop = ds.CONTESTANT.Unit
                                        }
                                        ).Distinct().ToList();
                cbLop.DisplayMember = "TenLop";


                if (CurrentSubjectID == -1 && rbSubject.Checked)
                {
                    gvMain.DataSource = null;
                }
                else if (CurrentUnit == string.Empty && rbUnit.Checked)
                {
                    gvMain.DataSource = null;
                }

            }
        }
        private void cbSubject_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CurrentShiftID != -1 && CurrentRoomTestID != -1 && CurrentSubjectID != -1 && rbSubject.Checked)
            {

                _ScheduleService = new ScheduleService();
                _DivisionShiftService = new DivisionShiftService();
                _ContestantShiftService = new ContestantShiftService();
                _SubjectService = new SubjectService();
                _ContestantService = new ContestantService();
                int index = 1;
                DIVISION_SHIFTS CurrentDs = new DIVISION_SHIFTS();
                CurrentDs = _DivisionShiftService.GetByShiftAndRoomTest(CurrentShiftID, CurrentRoomTestID);
                var listContestant = (from cs in _ContestantShiftService.GetAllByDivisionShiftID(CurrentDs.DivisionShiftID)
                                      where  cs.SCHEDULE.SubjectID == CurrentSubjectID
                                      select new
                                      {
                                          STT = index++,

                                          ContestantCode = cs.CONTESTANT.ContestantCode,
                                          FullName = cs.CONTESTANT.FullName,
                                          DOB = DateTimeHelpers.ConvertUnixToDateTime(cs.CONTESTANT.DOB.Value)
                                            .ToShortDateString(),
                                          // TestID = ct.TestID,
                                          ScoreSpeaking = KetQuaNoi(cs.ContestantShiftID),
                                          ScoreWritting = KetQuaViet(cs.ContestantShiftID),
                                         // ScoreListening = KetQuaNghe(cs.ContestantShiftID),
                                          Score = (float.Parse(KetQuaTracNghiem(cs.ContestantShiftID))) ,
                                          SumScore = KetQuaTong(cs.ContestantShiftID),
                                          ContestantShiftID = cs.ContestantShiftID,
                                        
                                      }).ToList();
                gvMain.DataSource = listContestant;
            }
        }
        private void cbLop_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CurrentShiftID != -1 && CurrentRoomTestID != -1 && CurrentUnit != string.Empty && rbUnit.Checked)
            {

                _ScheduleService = new ScheduleService();
                _DivisionShiftService = new DivisionShiftService();
                _ContestantShiftService = new ContestantShiftService();
                _SubjectService = new SubjectService();
                _ContestantService = new ContestantService();
                int index = 1;
                DIVISION_SHIFTS CurrentDs = new DIVISION_SHIFTS();
                CurrentDs = _DivisionShiftService.GetByShiftAndRoomTest(CurrentShiftID, CurrentRoomTestID);
                var listContestant = (from cs in _ContestantShiftService.GetAllByDivisionShiftID(CurrentDs.DivisionShiftID).Where(x=>x.CONTESTANT.Unit==CurrentUnit)
                                      
                                      select new
                                      {
                                          STT = index++,

                                          ContestantCode = cs.CONTESTANT.ContestantCode,
                                          FullName = cs.CONTESTANT.FullName,
                                          DOB = DateTimeHelpers.ConvertUnixToDateTime(cs.CONTESTANT.DOB.Value)
                                            .ToShortDateString(),
                                          // TestID = ct.TestID,
                                          ScoreSpeaking = KetQuaNoi(cs.ContestantShiftID),
                                          ScoreWritting = KetQuaViet(cs.ContestantShiftID),
                                          //ScoreListening = KetQuaNghe(cs.ContestantShiftID),
                                          Score = (float.Parse(KetQuaTracNghiem(cs.ContestantShiftID))),
                                          SumScore = KetQuaTong(cs.ContestantShiftID),
                                          ContestantShiftID = cs.ContestantShiftID,
                                         
                                      }).ToList();
                gvMain.DataSource = listContestant;
            }
        }
        private string KetQuaTracNghiem(int contestantShiftID)
        {

            CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID);
            if (ct != null)
            {
                ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);
                if (anw != null)
                {

                    if (anw.TestScores == null)
                        return 0.ToString();
                    return (anw.TestScores).ToString();

                }


            }
            return 0.ToString();
        }

        private string KetQuaTong(int contestantShiftID)
        {

            CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID);
            if (ct != null)
            {
                ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);
                if (anw != null)
                {
                    ANSWERSHEET_SPEAKING aw = _AnswersheetSpeakingService.GetByAnwsersheetID(anw.AnswerSheetID);
                    ANSWERSHEET_WRITING anwritting = _AnswersheetWritingService.GetByAnwsersheetID(anw.AnswerSheetID);
                    if (aw != null && anwritting != null)
                    {
                        return (aw.SpeakingScore + anwritting.WritingScore + anw.TestScores).ToString();
                    }
                    else if (aw == null && anwritting != null)
                    {
                        return (anwritting.WritingScore + anw.TestScores ).ToString();
                    }
                    else if (aw != null && anwritting == null)
                    {
                        return (aw.SpeakingScore + anw.TestScores).ToString();
                    }
                    else
                    {
                        return (anw.TestScores).ToString();
                    }
                }


            }
            return 0.ToString();
        }
        private string KetQuaNghe(int contestantShiftID)
        {

            CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID);

            if (ct != null)
            {
                ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);
                float SumSCore = 0;
                if (anw != null)
                {
                    int ansID;
                    _AnswersheetDetailService = new AnswersheetDetailService();
                    List<ANSWERSHEET_DETAILS> lstaws = _AnswersheetDetailService.getAllByAnswerID(anw.AnswerSheetID).ToList();
                    ANSWER aw = new ANSWER();
                    foreach (ANSWERSHEET_DETAILS item in lstaws)
                    {
                        ansID = item.ChoosenAnswer ?? default(int);
                        _AnswerService = new AnswerService();
                        aw = _AnswerService.GetById(ansID);
                        if (aw != null)
                        {
                            if (aw.IsCorrect && aw.SUBQUESTION.QUESTION.Audio != null)
                            {
                                SumSCore += (float)Math.Round(aw.SUBQUESTION.Score.Value, 2);
                            }
                        }
                    }
                    return SumSCore.ToString();

                }


            }

            return 0.ToString();
        }
        private string KetQuaNoi(int contestantShiftID)
        {

            CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID);
            if (ct != null)
            {
                ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);
                if (anw != null)
                {
                    ANSWERSHEET_SPEAKING aw = _AnswersheetSpeakingService.GetByAnwsersheetID(anw.AnswerSheetID);

                    if (aw != null)
                    {
                        if (aw.SpeakingScore == null)
                            return 0.ToString();
                        return (aw.SpeakingScore).ToString();
                    }
                }


            }
            return 0.ToString();
        }
        private string KetQuaViet(int contestantShiftID)
        {

            CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID);
            if (ct != null)
            {
                ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);
                if (anw != null)
                {

                    ANSWERSHEET_WRITING anwritting = _AnswersheetWritingService.GetByAnwsersheetID(anw.AnswerSheetID);
                    if (anwritting != null)
                    {
                        if (anwritting.WritingScore == null)
                            return 0.ToString();
                        return (anwritting.WritingScore).ToString();
                    }
                }


            }
            return 0.ToString();
        }
          #region
          //private string GetScore(int? contestantShiftID)
          //{
          //    if (contestantShiftID.HasValue)
          //    {
          //        CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID.Value);
          //        if (ct != null)
          //        {
          //            ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);
          //            if (anw != null)
          //            {
          //                return (anw.TestScores).ToString();
          //            }

          //        }
          //    }
          //    return string.Empty;
          //}
          //private string GetScoreSpeaking(int? contestantShiftID)
          //{
          //    if (contestantShiftID.HasValue)
          //    {
          //        CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID.Value);
          //        if (ct != null)
          //        {
          //            ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);
          //            if (anw != null)
          //            {
          //                ANSWERSHEET_SPEAKING aw = _AnswersheetSpeakingService.GetByAnwsersheetID(anw.AnswerSheetID);

          //                if (aw != null)
          //                {
          //                    return (aw.SpeakingScore).ToString();
          //                }
          //            }

          //        }
          //    }
          //    return string.Empty;
          //}
          //private string GetScoreWritting(int? contestantShiftID)
          //{
          //    if (contestantShiftID.HasValue)
          //    {
          //        CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID.Value);
          //        if (ct != null)
          //        {
          //            ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);
          //            if (anw != null)
          //            {
          //                ANSWERSHEET_WRITING aw = _AnswersheetWritingService.GetByAnwsersheetID(anw.AnswerSheetID);

          //                if (aw != null)
          //                {
          //                    return (aw.WritingScore).ToString();
          //                }
          //            }

          //        }
          //    }
          //    return string.Empty;
          //}
          #endregion
          private void btnPrintResult_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbSubject.Checked)
                {
                    DIVISION_SHIFTS CurrentDs = new DIVISION_SHIFTS();
                    _DivisionShiftService = new DivisionShiftService();
                    MTAQuizDbContext db = new MTAQuizDbContext();
                    List<PrintSpeakingQuestion> lstSubSpeaking = new List<PrintSpeakingQuestion>();

                    lstSubSpeaking = (

                                  from cts in _ContestantShiftService.GetAllByDivisionShiftID(CurrentDs.DivisionShiftID).ToList()
                                  from ctt in _ContestantTestService.GetAll().Where(x => x.ContestantShiftID == cts.ContestantShiftID).ToList()
                                  from td in db.TEST_DETAILS.Where(x => x.TestID == ctt.TestID).ToList()
                                  from qt in db.QUESTIONS.Where(x => x.QuestionID == td.QuestionID && x.Type == 5).ToList()
                                  from sqt in qt.SUBQUESTIONS.ToList()
                                  where cts.SCHEDULE.SubjectID == CurrentSubjectID
                                  select new PrintSpeakingQuestion
                                  {
                                      TestID = ctt.TestID

                                  }
                              ).OrderBy(x => x.TestID).ToList();
                    CurrentDs = _DivisionShiftService.GetByShiftAndRoomTest(CurrentShiftID, CurrentRoomTestID);
                    if (lstSubSpeaking.Count > 0)

                    {
                        Report.frmResultSum frm = new Report.frmResultSum(CurrentDs.DivisionShiftID,CurrentSubjectID);
                        frm.ShowDialog();
                    }
                    else
                    {
                        Report.frmResultSumTNTL frm = new Report.frmResultSumTNTL(CurrentDs.DivisionShiftID, CurrentSubjectID);
                        frm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Chọn môn!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("|Lỗi!");
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }
        }

        private void btnKetQuaLop_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbUnit.Checked)
                {
                    DIVISION_SHIFTS CurrentDs = new DIVISION_SHIFTS();
                    _DivisionShiftService = new DivisionShiftService();
                    MTAQuizDbContext db = new MTAQuizDbContext();
                    List<PrintSpeakingQuestion> lstSubSpeaking = new List<PrintSpeakingQuestion>();

                    lstSubSpeaking = (

                                  from cts in _ContestantShiftService.GetAllByDivisionShiftID(CurrentDs.DivisionShiftID).ToList()
                                  from ctt in _ContestantTestService.GetAll().Where(x => x.ContestantShiftID == cts.ContestantShiftID).ToList()
                                  from td in db.TEST_DETAILS.Where(x => x.TestID == ctt.TestID).ToList()
                                  from qt in db.QUESTIONS.Where(x => x.QuestionID == td.QuestionID && x.Type == 5).ToList()
                                  from sqt in qt.SUBQUESTIONS.ToList()
                                  where cts.SCHEDULE.SubjectID == CurrentSubjectID
                                  select new PrintSpeakingQuestion
                                  {
                                      TestID = ctt.TestID

                                  }
                              ).OrderBy(x => x.TestID).ToList();
                    CurrentDs = _DivisionShiftService.GetByShiftAndRoomTest(CurrentShiftID, CurrentRoomTestID);
                    if (lstSubSpeaking.Count > 0)

                    {
                        Report.frmResultSum frm = new Report.frmResultSum(CurrentDs.DivisionShiftID,CurrentUnit);
                        frm.ShowDialog();
                    }
                    else
                    {
                        Report.frmResultSumTNTL frm = new Report.frmResultSumTNTL(CurrentDs.DivisionShiftID,CurrentUnit);
                        frm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Chọn lớp!");
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}
