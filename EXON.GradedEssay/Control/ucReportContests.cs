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
    public partial class ucReportContests : UserControl
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
        public ucReportContests(int contestID, int LocationID)
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
            _AnswersheetDetailService = new AnswersheetDetailService();
            _AnswerService = new AnswerService();
        }

        private void InitializeControl()
        {

            try
            {
                _ContestantService = new ContestantService();
                _ContestantShiftService = new ContestantShiftService();

                cbSubject.DataSource = (from sj in _SubjectService.GetAll().ToList()
                                        from sch in _ScheduleService.GetAll().ToList()
                                        where sj.SubjectID == sch.SubjectID && sch.ContestID == _ContestID
                                        select new
                                        {
                                            SubjectName = sj.SubjectName,
                                            SubjectID = sj.SubjectID
                                        }
                                          ).ToList();

                cbSubject.DisplayMember = "SubjectName";
                cbSubject.ValueMember = "SubjectID";

            }
            catch
            {

            }
        }



        private void cbSubject_SelectedValueChanged(object sender, EventArgs e)
        {
            if (rbSubject.Checked && CurrentSubjectID != -1)
            {

                _ScheduleService = new ScheduleService();
                _DivisionShiftService = new DivisionShiftService();
                _ContestantShiftService = new ContestantShiftService();
                _SubjectService = new SubjectService();
                _ContestantService = new ContestantService();
                int index = 1;

                var listContestant = (from cs in _ContestantShiftService.GetAll().Where(x => x.SCHEDULE.SubjectID == CurrentSubjectID && x.DIVISION_SHIFTS.ROOMTEST.LocationID == _LocationID)
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
                                     //     ScoreListen = KetQuaNghe(cs.ContestantShiftID),
                                          Score = ((KetQuaTracNghiem(cs.ContestantShiftID))) ,
                                          SumScore = KetQuaTong(cs.ContestantShiftID),
                                          ContestantShiftID = cs.ContestantShiftID,
                                      }).ToList();
                gvMain.DataSource = listContestant;
            }
        }
        private float KetQuaTracNghiem(int contestantShiftID)
        {

               CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID);
               if (ct != null)
               {
                    ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);
                    if (anw != null)
                    {

                         if (anw.TestScores == null)
                              return 0;

                         return (float)Math.Round(anw.TestScores.Value, 2);

                    }


               }
               return 0;
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
                        return (anwritting.WritingScore + anw.TestScores).ToString();
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
        private float KetQuaNghe(int contestantShiftID)
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
                    return SumSCore;

                }


            }

            return 0;
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
        #region lấy điểm cũ
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
                if (rbSubject.Checked && CurrentSubjectID != -1)
                {

                    _DivisionShiftService = new DivisionShiftService();
                    MTAQuizDbContext db = new MTAQuizDbContext();
                    List<PrintSpeakingQuestion> lstSubSpeaking = new List<PrintSpeakingQuestion>();
                    Report.frmResultSum frm = new Report.frmResultSum(CurrentSubjectID);
                    frm.ShowDialog();
                    //}
                }
                else
                {
                    MessageBox.Show("Chọn môn!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!" + ex.ToString());
            }
        }


    }
}
