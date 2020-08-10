using EXON.SubData.Services;
using EXON.SubModel.Models;
using MetroFramework.Forms;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using EXON.Common;
using Word = Microsoft.Office.Interop.Word;

using System.IO;
using System.Drawing;
using System.Threading;
using EXON.GradedEssay.Report;

namespace EXON.GradedEssay.Control
{
    public partial class ucWrittingPhucTra : UserControl
    {


        private ucLoad Loading = new ucLoad();
        public delegate void SendWorking(int value);
        private List<ListAnwser> listans;
        private List<Question> lstQuestion;
        private Word.Application objApp;
        private Word.Document objDoc;
        private object pathFileForAnswer = Constant.pathTempSpeaking;
        private object pathFileTemp = Constant.pathTempAnswer;
        SendWorking s;
        private object pathFile = Constant.pathTemp;
        //private DIVISION_SHIFTS ds;

        #region Service

        private IContestService _ContestService;
        private IShiftService _ShiftService;
        private IScheduleService _ScheduleService;
        private ISubjectService _SubjectService;
        private IStaffService _StaffService;
        private IDivisionShiftService _DivisionShiftService;
        private IContestantShiftService _ContestantShiftService;
        private ITestNumberService _TestNumberService;
        private IContestantTestService _ContestantTestService;
        private IAnswersheetService _AnswersheetService;
        private IAnswersheetWritingService _AnswersheetWritingService;
        private ITestService _TestService;
        private IRoomTestService _RoomTestService;
        private IAnswersheetDetailService _AnswersheetDetailService;
        private IAnswersheetSpeakingService _AnswersheetSpeakingService;
        private IAnswerService _AnswerService;
        #endregion Service
        private int _ContestID { get; set; }
        private int _LocationID { get; set; }
        private int SubjectID { get; set; }
        private int CurrentTeacherName1
        {
            get
            {
                try
                {
                    return int.Parse(cbStaff1.SelectedValue.ToString());
                }
                catch { return -1; }
            }
        }
        private int CurrentTeacherName2
        {
            get
            {
                try
                {
                    return int.Parse(cbStaff2.SelectedValue.ToString());
                }
                catch { return -1; }
            }
        }
      
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
        private int CurrentStaff1
        {
            get
            {
                try
                {
                    return int.Parse(cbStaff1.SelectedValue.ToString());
                }
                catch { return -1; }
            }
        }
        private int CurrentStaff2
        {
            get
            {
                try
                {
                    return int.Parse(cbStaff2.SelectedValue.ToString());
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
       

        public ucWrittingPhucTra(int contestID, int LocationID)
        {
            _ContestID = contestID;
            _LocationID = LocationID;
            InitializeComponent();
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
            _TestNumberService = new TestNumberService();
            _StaffService = new StaffService();
            _ContestantTestService = new ContestantTestService();
            _AnswersheetService = new AnswersheetService();
            _AnswersheetWritingService = new AnswersheetWritingService();
            _TestService = new TestService();
            _RoomTestService = new RoomTestService();
        }

        private void InitializeControl()
        {
            try
            {

                _ShiftService = new ShiftService();
                _StaffService = new StaffService();
                _ScheduleService = new ScheduleService();
                _SubjectService = new SubjectService();
                _ContestantShiftService = new ContestantShiftService();
                _DivisionShiftService = new DivisionShiftService();
                cbShift.DataSource = (
                                        from ds in _DivisionShiftService.GetAll().Where(x=>x.ROOMTEST.LocationID==_LocationID)
                                        from s in _ShiftService.GetAll(_ContestID).Where(x => x.Status > 0)                       
                                        where ds.ShiftID== s.ShiftID
                                      select s).ToList();
                cbShift.DisplayMember = "ShiftName";
                cbShift.ValueMember = "ShiftID";
               
                try
                {
                    List<STAFF> listStaff = _StaffService.GetAll().ToList();

                    cbStaff1.DataSource = listStaff;
                    cbStaff1.DisplayMember = "FullName";
                    cbStaff1.ValueMember = "StaffID";
                    List<STAFF> listStaff2 = _StaffService.GetAll().ToList();
                    cbStaff2.DataSource = listStaff2;
                    cbStaff2.DisplayMember = "FullName";
                    cbStaff2.ValueMember = "StaffID";
                }
                catch
                {
                    MessageBox.Show("Không Lấy Được Dữ Liệu Giáo Viên.", "Thông Báo");

                }
            
            }
            catch (Exception ex)
            { }

        }

        private void cbShift_SelectedValueChanged(object sender, EventArgs e)
        {
            _ShiftService = new ShiftService();
            _StaffService = new StaffService();
            _ScheduleService = new ScheduleService();
            _SubjectService = new SubjectService();
            _ContestantShiftService = new ContestantShiftService();
            _DivisionShiftService = new DivisionShiftService();
          
            cbRoomTest.DataSource = null;
            cbRoomTest.Text = "";
            // commbox roomtest
            cbRoomTest.DataSource = (from r in _RoomTestService.GetAllByLocation(_LocationID)
                                     from ds in _DivisionShiftService.GetAll()
                                     where CurrentShiftID == ds.ShiftID && r.RoomTestID == ds.RoomTestID && r.LocationID==_LocationID
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
                _ShiftService = new ShiftService();
                _StaffService = new StaffService();
                _ScheduleService = new ScheduleService();
                _SubjectService = new SubjectService();
                _ContestantShiftService = new ContestantShiftService();
                _DivisionShiftService = new DivisionShiftService();

                MTAQuizDbContext db = new MTAQuizDbContext();
                DIVISION_SHIFTS CurrentDs = new DIVISION_SHIFTS();
                CurrentDs = _DivisionShiftService.GetByShiftAndRoomTest(CurrentShiftID, CurrentRoomTestID);
                cbSubject.DataSource = (
                                        from ds in _ContestantShiftService.GetAllByDivisionShiftID(CurrentDs.DivisionShiftID)
                                        select new
                                        {
                                            SubjectName = ds.SCHEDULE.SUBJECT.SubjectName,
                                            SubjectID=ds.SCHEDULE.SUBJECT.SubjectID
                                        }).Distinct().ToList();
                cbSubject.DisplayMember = "SubjectName";
                cbSubject.ValueMember = "SubjectID";


                if (CurrentSubjectID == -1)
                {
                    gvMain.DataSource = null;
                }

            }

        }
        private string KetQuaTracNghiem(int contestantShiftID)
        {
            _AnswersheetSpeakingService = new AnswersheetSpeakingService();
            _ContestantTestService = new ContestantTestService();
            _AnswersheetWritingService = new AnswersheetWritingService();
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
            _AnswersheetSpeakingService = new AnswersheetSpeakingService();
            _ContestantTestService = new ContestantTestService();
            _AnswersheetWritingService = new AnswersheetWritingService();
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
        private string KetQuaNghe(int contestantShiftID)
        {
            _AnswersheetSpeakingService = new AnswersheetSpeakingService();
            _ContestantTestService = new ContestantTestService();
            _AnswersheetWritingService = new AnswersheetWritingService();
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
        private string KetQuaVietPhucTra(int contestantShiftID)
        {
            _AnswersheetSpeakingService = new AnswersheetSpeakingService();
            _ContestantTestService = new ContestantTestService();
            _AnswersheetWritingService = new AnswersheetWritingService();
            CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID);
            if (ct != null)
            {
                ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);
                if (anw != null)
                {

                    ANSWERSHEET_WRITING anwritting = _AnswersheetWritingService.GetByAnwsersheetID(anw.AnswerSheetID);
                    if (anwritting != null)
                    {
                        if (anwritting.WritingScore2 == null)
                            return 0.ToString();
                        return (anwritting.WritingScore2).ToString();
                    }
                }


            }
            return 0.ToString();
        }
        private string KetQuaViet(int contestantShiftID)
        {
            _AnswersheetSpeakingService = new AnswersheetSpeakingService();
            _ContestantTestService = new ContestantTestService();
            _AnswersheetWritingService = new AnswersheetWritingService();
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

        private void cbSubject_SelectedValueChanged(object sender, EventArgs e)
        {

            if (CurrentShiftID != -1 && CurrentRoomTestID != -1 && CurrentSubjectID != -1)
            {
                _ShiftService = new ShiftService();
                _StaffService = new StaffService();
                _ScheduleService = new ScheduleService();
                _SubjectService = new SubjectService();
                _ContestantShiftService = new ContestantShiftService();
                _DivisionShiftService = new DivisionShiftService();
                DIVISION_SHIFTS CurrentDs = new DIVISION_SHIFTS();
                CurrentDs = _DivisionShiftService.GetByShiftAndRoomTest(CurrentShiftID, CurrentRoomTestID);
              
                int index = 1;
                var listContestant = (from cs in _ContestantShiftService.GetAllByDivisionShiftID(CurrentDs.DivisionShiftID)
                                      where cs.SCHEDULE.SubjectID == CurrentSubjectID
                                      select new
                                      {
                                          STT = index++,

                                          ContestantCode = cs.CONTESTANT.ContestantCode,
                                          FullName = cs.CONTESTANT.FullName,
                                          DOB = DateTimeHelpers.ConvertUnixToDateTime(cs.CONTESTANT.DOB.Value)
                                            .ToShortDateString(),
                                          // TestID = ct.TestID,
                                         
                                          ScoreWritting = KetQuaViet(cs.ContestantShiftID),
                                          // ScoreListening = KetQuaNghe(cs.ContestantShiftID),
                                          Score = (float.Parse(KetQuaTracNghiem(cs.ContestantShiftID))),
                                          SumScore = KetQuaTong(cs.ContestantShiftID),
                                          ContestantShiftID = cs.ContestantShiftID,
                                          ScoreReWritting = KetQuaVietPhucTra(cs.ContestantShiftID),
                                          PrintAnswer = "Xem"
                                      }).ToList();
                gvMain.DataSource = listContestant;
            }
        }
        private string GetScore(int contestantShiftID)
        {
            if (contestantShiftID > 0)
            {
                CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID);
                if (ct != null)
                {
                    ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);
                    if (anw != null)
                    {
                        ANSWERSHEET_WRITING aw = _AnswersheetWritingService.GetByAnwsersheetID(anw.AnswerSheetID);
                        if (aw != null)
                        {
                            return aw.WritingScore.ToString();
                        }
                    }
                }
            }
            return string.Empty;
        }
        private void ucWritting_Load(object sender, EventArgs e)
        {
          
        }
   
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (btnSave.Text == "Nhập điểm")
                {
                    if (DialogResult.Yes == MessageBox.Show("Nhập điểm cho phần thi viết?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        gvMain.ReadOnly = false;
                        btnSave.Text = "Lưu lại";
                    }
                }
                else
                {
                    MTAQuizDbContext db = new MTAQuizDbContext();
                    if (gvMain.DataSource != null)
                    {
                        int index = 0;
                        foreach (DataGridViewRow row in gvMain.Rows)
                        {
                            index++;
                            try
                            {
                                int contestantShiftID = int.Parse(row.Cells["cContestantShiftID"].Value.ToString());
                                string v = row.Cells["cDiemVietPhucTra"].Value.ToString();
                                string v2 = row.Cells["cDiemTNPhucTra"].Value.ToString();

                                float scoreWritting;
                                float score;
                                // score = int.Parse(v);
                                CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID);
                                if (ct != null)
                                {
                                    ANSWERSHEET ans = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);
                                    if (ans != null)
                                    {
                                        if (v != "" )
                                            if (v.IndexOf('.') >= 0) scoreWritting = float.Parse(v);
                                            else scoreWritting = int.Parse(v);
                                        else continue;

                                        ANSWERSHEET_WRITING aw = _AnswersheetWritingService.GetByAnwsersheetID(ans.AnswerSheetID);
                                        if (aw != null)
                                        {
                                            aw.WritingScore2 = scoreWritting;
                                            aw.Status++;
                                            _AnswersheetWritingService.Update(aw);
                                        }
                                        else
                                        {
                                            aw = new ANSWERSHEET_WRITING
                                            {

                                                AnswerSheetID = ans.AnswerSheetID,
                                                WritingScore2 = scoreWritting,
                                                Status = 1
                                            };

                                            _AnswersheetWritingService.Add(aw);
                                            _AnswersheetWritingService.Save();


                                        }
                                        if (v2 != "")
                                            if (v2.IndexOf('.') >= 0) score = float.Parse(v);
                                            else score = int.Parse(v);
                                        else continue;

                                        ans.TestScores = score;

                                        _AnswersheetService.Update(ans);
                                        _AnswersheetService.Save();

                                    }
                                    else
                                    {
                                        MessageBox.Show(string.Format("Thí sinh {0} không có bài làm.", row.Cells["cTestNumberIndex"].Value.ToString()), "Thông Báo");
                                        continue;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Thí sinh chưa được phát đề", "Thông báo");
                                    Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_FATAL, string.Format("Contestant Test is null with ContestantShiftID = {0}", contestantShiftID));
                                    return;
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lối định dạng điểm thi tại dòng: " + index.ToString(), "Lối");

                                gvMain.ClearSelection();
                                gvMain.Rows[index].Selected = true;

                                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Error when convert string to numver: {0}", ex.Message));
                                return;
                            }
                            index++;
                        }
                        _AnswersheetWritingService.Save();

                        MessageBox.Show("Nhập điểm thành công.", "Thông báo");

                        btnSave.Text = "Nhâp điểm";
                        gvMain.ReadOnly = true;
                    }
                }

            }
            catch
            {
                MessageBox.Show("Không có dữ liệu!");

            }
        }

        private void gvMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gvMain.DataSource == null)
                return;
            try
            {
                string v = gvMain.Rows[e.RowIndex].Cells["cDiemVietPhucTra"].Value.ToString();
                if (v.IndexOf('.') >= 0) float.Parse(v);
                else int.Parse(v);

                string v2 = gvMain.Rows[e.RowIndex].Cells["cDiemTNPhucTra"].Value.ToString();
                if (v2.IndexOf('.') >= 0) float.Parse(v);
                else int.Parse(v2);
            }
            catch
            {
                MessageBox.Show("Chỉ Nhấp Số. Nếu là số thập phân sử dụng '.' thay vì ','.", "Sai Định Dạng");
                gvMain.CellValueChanged -= gvMain_CellValueChanged;
                gvMain.Rows[e.RowIndex].Cells["cDiemVietPhucTra"].Value = string.Empty;
                gvMain.Rows[e.RowIndex].Cells["cDiemTNPhucTra"].Value = string.Empty;
                gvMain.CellValueChanged += gvMain_CellValueChanged;
            }
        }

        /// <summary>
        ///  click xem bài làm của thí sinh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            int id;
            string TestNumberIndex;
            try
            {

                DIVISION_SHIFTS CurrentDs = new DIVISION_SHIFTS();
                _DivisionShiftService = new DivisionShiftService();
                _TestNumberService = new TestNumberService();
                CurrentDs = _DivisionShiftService.GetByShiftAndRoomTest(CurrentShiftID, CurrentRoomTestID);
                if (CurrentDs.Status != (int)Common.StatusDivisionShift.STATUS_COMPLETE)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Ca thi chưa kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                    return;
                }
                id = (int)gvMain.CurrentRow.Cells["cContestantShiftID"].Value;
                TESTNUMBER tn = new TESTNUMBER();
                    tn = _TestNumberService.GetAll().Where(x => x.ContestantShiftID == id).SingleOrDefault();
                TestNumberIndex = CurrentDs.DivisionShiftID.ToString() + "." + tn.TestNumberIndex.ToString();
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                 e.RowIndex >= 0)

                {
                    try
                    {
                        frmProgress frm = new frmProgress(2);
                        frm.Show();
                        frm.UpdateValue2(1);
                        GetAnswerForAll(id, TestNumberIndex, CurrentDs.DivisionShiftID);
                        frm.UpdateValue2(2);
                       
                        OpenFileAnsewer(TestNumberIndex);
                        frm.Close();
                    }
                    catch (Exception ex)
                    {       
                        MetroFramework.MetroMessageBox.Show(this, "Chưa tạo bài làm tất cả hoặc thí sinh chưa hoàn thành bài làm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        public int GetAnswerForAll(int id, string TestNumberIndex, int DivisionShiftID)
        {
            MTAQuizDbContext db = new MTAQuizDbContext();
            listans = new List<ListAnwser>();
            listans = (from ctt in db.CONTESTANTS_TESTS.Where(x => x.ContestantShiftID == id)
                       from aswdt in db.ANSWERSHEET_DETAILS.Where(x => x.ANSWERSHEET.ContestantTestID == ctt.ContestantTestID).ToList()
                       from sqt in db.SUBQUESTIONS.Where(x => x.SubQuestionID == aswdt.SubQuestionID && ((x.QUESTION.Type != (int)QuizTypeEnum.Speaking))).ToList()
                       select new ListAnwser
                       {
                           anwser = aswdt.AnswerContent,
                           subid = sqt.SubQuestionID,
                           ChoosenAnswer = aswdt.ChoosenAnswer ?? default(int)
                       }
                         ).ToList();
            if (listans.Count != 0)
            {
                lstQuestion = new List<Question>();
                int number = 0;
                lstQuestion = (from ctt in db.CONTESTANTS_TESTS.Where(x => x.ContestantShiftID == id).ToList()
                               from tdt in db.TEST_DETAILS.Where(x => x.TestID == ctt.TestID).ToList()
                               from qt in db.QUESTIONS.Where(x => x.QuestionID == tdt.QuestionID
                               && (x.Type != (int)QuizTypeEnum.Speaking)).ToList()
                               from sqt in db.SUBQUESTIONS.Where(x => x.QuestionID == qt.QuestionID).ToList()
                               select new Question
                               {
                                   NO = ++number,
                                   QuestionID = sqt.QuestionID,
                                   QuestionContent = sqt.QUESTION.QuestionContent,
                                   SubQuestionID = sqt.SubQuestionID,
                                   SubQuestionContent = sqt.SubQuestionContent,
                                   Testid = ctt.TestID,
                                   Answer = getans(listans, sqt.SubQuestionID),
                                   Score = (float)sqt.Score,
                                   Type = sqt.QUESTION.Type ?? default(int),
                                   AnswerForRegular = getAnswerForRegulargetans(listans, sqt.SubQuestionID),
                               }
                     ).OrderBy(x=>x.NO).ToList();

                // bỏ câu không phải là câu viết đánh số thứ tự
                // lstQuestion.RemoveAll(x => x.Type == (int)QuizTypeEnum.Regular || x.Type == (int)QuizTypeEnum.Speaking || x.Type == (int)QuizTypeEnum.Audio || x.Type == (int)QuizTypeEnum.Matching || (x.Type == (int)QuizTypeEnum.FillAudio) || (x.Type == (int)QuizTypeEnum.Fill));

                if (lstQuestion.Count > 0)
                {
                    CONTEST ct = new CONTEST();
                    _SubjectService = new SubjectService();
                    _ContestService = new ContestService();
                    ct = _ContestService.GetById(_ContestID);
                    string SubjectName = _SubjectService.GetById(CurrentSubjectID).SubjectName;
                    string FileNameOutput = pathFileTemp.ToString() +"\\"+"PhucTra" +"\\" + DivisionShiftID.ToString() + "." + SubjectName.Trim() + "\\" + TestNumberIndex + ".docx";
                    string FolderNameOutput = pathFileTemp.ToString() + "\\" + "PhucTra"  + "\\" + DivisionShiftID.ToString() + "." + SubjectName.Trim() + "\\" + TestNumberIndex + "\\";

                    if (!Directory.Exists(Path.Combine(FolderNameOutput.ToString())))
                        Directory.CreateDirectory(Path.Combine(Path.Combine(FolderNameOutput.ToString())));
                    if (!File.Exists(FileNameOutput))
                    {
                        return SaveFileAnswer(lstQuestion, TestNumberIndex, ct.ContestName, FolderNameOutput, FileNameOutput); ;

                    }
                    else
                    {
                        return 1;
                    }


                    //return CreateDocumentForAll(lstQuestion, TestNumberIndex, ct.ContestName, PathFolderTemp);
                }

            }
            return -1;
        }
        private string getans(List<ListAnwser> listans, int subid)
        {
            foreach (var it in listans)
            {
                if (subid == it.subid)
                {
                    return it.anwser;
                }
            }
            return "";
        }
        public void killProcessMSWord()
        {
            foreach (Process process in Process.GetProcessesByName("WINWORD"))
            {

                process.Kill();

            }
        }
        private string getAnswerForRegulargetans(List<ListAnwser> listans, int subQuestionID)
        {

            _AnswerService = new AnswerService();
            ANSWER ans = new ANSWER();

            foreach (var it in listans)
            {
                if (subQuestionID == it.subid)
                {
                    if (it.ChoosenAnswer > 0)
                    {
                        ans = _AnswerService.GetById(it.ChoosenAnswer);
                        if (ans != null)
                            return ans.AnswerContent;
                    }

                }
            }
            return "";
        }

        private int SaveFileAnswer(List<Question> list, string numberIndex, string ContestName, string FolderNameOutput, string FileNameOutput)
        {
            try
            {
                CreateFileHead(numberIndex, ContestName, FolderNameOutput, list[0].Testid);
                foreach (Question QA in list)
                {

                    if (QA.QuestionContent != null)
                    {
                        string FileNameQA = FolderNameOutput + QA.SubQuestionID + ".rtf";
                        RichTextBox rtfNumberIndex = new RichTextBox();
                        float score = (float)Math.Round(QA.Score, 2);
                        rtfNumberIndex.Text = string.Format("Câu hỏi {0} ({1} điểm): ", QA.NO, score);
                        rtfNumberIndex.AppendText("\n");
                        rtfNumberIndex.Font = new System.Drawing.Font("Times New Roman", 13, FontStyle.Bold);
                        rtfNumberIndex.Select(rtfNumberIndex.TextLength, 0);
                        rtfNumberIndex.SelectedRtf = QA.SubQuestionContent;
                        RichTextBox rtfQA = new RichTextBox();
                        rtfQA.Rtf = QA.QuestionContent;
                        rtfQA.Select(rtfQA.TextLength, 0);

                        rtfQA.SelectedRtf = rtfNumberIndex.Rtf;
                        RichTextBox rtfa = new RichTextBox();
                        if (QA.AnswerForRegular != "")
                        {
                            rtfa.Text = "Trả lời: ";
                            rtfa.Select(rtfa.TextLength, 0);
                            rtfa.SelectedRtf = QA.AnswerForRegular;

                            rtfa.Font = new System.Drawing.Font("Times New Roman", 13, FontStyle.Regular);
                        }
                        else
                        {
                            if (QA.Answer != "")
                            {
                                rtfa.Text = "Trả lời: ";
                                rtfa.Select(rtfa.TextLength, 0);
                                rtfa.SelectedRtf = QA.Answer;
                                rtfa.Font = new System.Drawing.Font("Times New Roman", 13, FontStyle.Regular);
                            }
                            else
                            {
                                rtfa.Text = "Trả lời: Thí sinh bỏ qua câu hỏi này";
                                rtfa.Font = new System.Drawing.Font("Times New Roman", 13, FontStyle.Bold);
                            }
                            rtfQA.Select(rtfQA.TextLength, 0);

                            rtfQA.SelectedRtf = rtfa.Rtf;
                            rtfQA.SaveFile(FileNameQA);
                        }
                        

                    }
                    else
                    {
                        string FileNameQA = FolderNameOutput + QA.SubQuestionID + ".rtf";
                        RichTextBox rtfNumberIndex = new RichTextBox();
                        float score= (float)Math.Round(QA.Score, 2);
                        rtfNumberIndex.Text = string.Format("Câu hỏi {0} ({1} điểm): ", QA.NO, score);
                        rtfNumberIndex.AppendText("\n");
                        rtfNumberIndex.Font = new System.Drawing.Font("Times New Roman", 13, FontStyle.Bold);
                        rtfNumberIndex.Select(rtfNumberIndex.TextLength, 0);
                        rtfNumberIndex.SelectedRtf = QA.SubQuestionContent;
                        RichTextBox rtfa = new RichTextBox();
                        if (QA.AnswerForRegular != "")
                        {
                            rtfa.Text = "Trả lời: ";
                            rtfa.Select(rtfa.TextLength, 0);
                            rtfa.SelectedRtf = QA.AnswerForRegular;

                            rtfa.Font = new System.Drawing.Font("Times New Roman", 13, FontStyle.Regular);
                        }
                        else
                        {
                            if (QA.Answer != "")
                            {
                                rtfa.Text = "Trả lời: ";
                                rtfa.Select(rtfa.TextLength, 0);
                                rtfa.SelectedRtf = QA.Answer;
                                rtfa.Font = new System.Drawing.Font("Times New Roman", 13, FontStyle.Regular);
                            }
                            else
                            {
                                rtfa.Text = "Trả lời: Thí sinh bỏ qua câu hỏi này";
                                rtfa.Font = new System.Drawing.Font("Times New Roman", 13, FontStyle.Bold);
                            }
                        }
                        rtfNumberIndex.Select(rtfNumberIndex.TextLength, 0);
                        rtfNumberIndex.SelectedRtf = rtfa.Rtf;
                        rtfNumberIndex.SaveFile(FileNameQA);
                    }
                }

                return Mergefile(FileNameOutput, FolderNameOutput, numberIndex); ;

            }
            catch (Exception ex)
            {
                return -1;
            }



        }
        private int Mergefile(string FileNameOutput, string FolderNameOutput, string numberIndex)
        {

            object missing = System.Type.Missing;
            object pageBreak = Word.WdBreakType.wdSectionBreakNextPage;
            object outputFile = FileNameOutput;
         
            Word.Application wordApplication = new Word.Application();

            try
            {

                Word.Document wordDocument = wordApplication.Documents.Add(
                                              ref missing
                                            , ref missing
                                            , ref missing
                                            , ref missing);

                // add header



                Word.Selection selection = wordApplication.Selection;
                selection.Font.Name = "Times New Roman";
                string[] filesToMerge = Directory.GetFiles(FolderNameOutput);
                string[] documentsToMerge = filesToMerge;
                int documentCount = filesToMerge.Length;


                int breakStop = 0;
                int LenghtFile = filesToMerge.Length;
                int index = 0;

                // Loop thru each of the Word documents
                foreach (string file in filesToMerge)
                {
                    breakStop++;
                    index++;
                    // Insert the files to our template
                    selection.InsertFile(file
                                            , ref missing
                                            , ref missing
                                            , ref missing
                                            , ref missing);
                }
                // Save the document to it's output file.
                object read = true;


                //Add footer at the right
                foreach (Microsoft.Office.Interop.Word.Section section in wordDocument.Sections)
                {

                    Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                    headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    headerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
                    headerRange.Font.Size = 12;
                    headerRange.Text = "Số phách: " + numberIndex;
                }
                //Add the footers into the document

                foreach (Microsoft.Office.Interop.Word.Section wordSection in wordDocument.Sections)
                {

                    Microsoft.Office.Interop.Word.Range footerRange = wordSection.Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    footerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
                    footerRange.Font.Size = 12;
                    footerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    footerRange.Fields.Add(footerRange, Type: Word.WdFieldType.wdFieldPage);
                }

                wordDocument.SaveAs2(ref outputFile, ref missing, ref missing, ref missing,
                   ref missing, ref missing, read,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);
                wordDocument.Close();


                return 1;


            }
            catch (Exception ex)
            {

                return -1;
            }
        }
        private void CreateFileHead(string numberIndex, string ContestName, string FolderNameOutput, int TestID)
        {
          
            objApp = new Word.Application();
            object missing = Missing.Value;
            objDoc = new Word.Document();
            object objMiss = System.Reflection.Missing.Value;
            object readOnly = false;
            objDoc = objApp.Documents.Open(ref pathFile, ref missing, ref missing,
                                       ref missing, ref missing, ref missing,
                                       ref missing, ref missing, ref missing,
                                       ref missing, ref missing, ref missing,
                                       ref missing, ref missing, ref missing, ref missing);
            objDoc.Activate();
            string datenow = DatetimeConvert.GetDateTimeServer().ToString(@"\N\g\à\y dd \t\h\á\n\g MM \n\ă\m yyyy");
            this.FindAndReplace(objApp, "DATENOW", datenow);
            this.FindAndReplace(objApp, "SubjectName", cbSubject.Text.ToUpper());
            this.FindAndReplace(objApp, "ContestName", "Kì thi: " + ContestName);
            object szPath = FolderNameOutput + "\\" + "0000.docx";
            objDoc.SaveAs(ref szPath, ref missing, ref missing, ref missing,
               ref missing, ref missing, ref missing,
               ref missing, ref missing, ref missing,
               ref missing, ref missing, ref missing,
               ref missing, ref missing, ref missing);
            objDoc.Close();

        }
        private void OpenFileAnsewer(string testNumberIndex)
        {
           
            objApp = new Word.Application();
            object missing = Missing.Value;
            objApp.Visible = false;
            objDoc = new Word.Document();
            object objMiss = System.Reflection.Missing.Value;

            object readOnly = false;
            DIVISION_SHIFTS CurrentDs = new DIVISION_SHIFTS();
            _DivisionShiftService = new DivisionShiftService();
            _SubjectService = new SubjectService();
            CurrentDs = _DivisionShiftService.GetByShiftAndRoomTest(CurrentShiftID, CurrentRoomTestID);

            int dsID = CurrentDs.DivisionShiftID;
            string SubjectName = _SubjectService.GetById(CurrentSubjectID).SubjectName;

          
            if (!Directory.Exists(Path.Combine(pathFileTemp.ToString(),  "PhucTra" + "\\" +CurrentDs.DivisionShiftID.ToString() + "." + SubjectName.Trim().ToString())))
            {
                MessageBox.Show("Chưa tạo bài làm");
                return;
            }
            object szPath = pathFileTemp + "PhucTra" + "\\" + dsID.ToString() + "." + SubjectName.Trim() + "\\" + testNumberIndex + ".docx";
            objDoc = objApp.Documents.Open(ref szPath, ref missing, ref readOnly,
                                      ref missing, ref missing, ref missing,
                                      ref missing, ref missing, ref missing,
                                      ref missing, ref missing, ref missing,
                                      ref missing, ref missing, ref missing, ref missing);
            objDoc.Activate();

            objApp.Documents.Open(ref szPath, ref missing, ref readOnly,
                                       ref missing, ref missing, ref missing,
                                       ref missing, ref missing, ref missing,
                                       ref missing, ref missing, ref missing,
                                       ref missing, ref missing, ref missing, ref missing);
        }

        private bool CheckHasAnswer(int id)
        {

            MTAQuizDbContext db = new MTAQuizDbContext();

            listans = new List<ListAnwser>();
            listans = (from ctt in db.CONTESTANTS_TESTS.Where(x => x.ContestantShiftID == id)
                       from aswdt in db.ANSWERSHEET_DETAILS.Where(x => x.ANSWERSHEET.ContestantTestID == ctt.ContestantTestID).ToList()
                       from sqt in db.SUBQUESTIONS.Where(x => x.SubQuestionID == aswdt.SubQuestionID && ((x.QUESTION.Type == (int)QuizTypeEnum.Essay) || (x.QUESTION.Type == (int)QuizTypeEnum.ReWritting))).ToList()

                       select new ListAnwser
                       {
                           anwser = aswdt.AnswerContent,
                           subid = sqt.SubQuestionID,
                       }
                         ).ToList();
            if (listans.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    

        private void FindAndReplace(Microsoft.Office.Interop.Word.Application wordApp, object findText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            wordApp.Selection.Find.Execute(ref findText,
                        ref matchCase, ref matchWholeWord,
                        ref matchWildCards, ref matchSoundLike,
                        ref nmatchAllForms, ref forward,
                        ref wrap, ref format, ref replaceWithText,
                        ref replace, ref matchKashida,
                        ref matchDiactitics, ref matchAlefHamza,
                        ref matchControl);
        }

        private void btnPrintResult_Click(object sender, EventArgs e)
        {
            try
            {

                DIVISION_SHIFTS CurrentDs = new DIVISION_SHIFTS();
                _DivisionShiftService = new DivisionShiftService();
                CurrentDs = _DivisionShiftService.GetByShiftAndRoomTest(CurrentShiftID, CurrentRoomTestID);
                Report.frmResultWritting frm = new Report.frmResultWritting(CurrentDs.DivisionShiftID, CurrentSubjectID);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không có dữ liệu!");

            }
        }


        private void gvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    

        private void gvMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gvMain.Rows[e.RowIndex].Cells["cDaHoanThanh"].Value.ToString() == "Đã hoàn thành")
            {
                gvMain.Rows[e.RowIndex].Cells["cDaHoanThanh"].Style = new DataGridViewCellStyle { ForeColor = Color.Black, BackColor = Color.MediumSpringGreen };
            }
        }

      
     

       

        private void btnExportScoreWritting_Click(object sender, EventArgs e)
        {
            try
            {
                DIVISION_SHIFTS CurrentDs = new DIVISION_SHIFTS();
                _DivisionShiftService = new DivisionShiftService();
                _StaffService = new StaffService();
                STAFF stff1 = new STAFF();
                stff1 = _StaffService.GetById(CurrentTeacherName1);
                STAFF stff2 = new STAFF();
                stff2 = _StaffService.GetById(CurrentTeacherName2);

                CurrentDs = _DivisionShiftService.GetByShiftAndRoomTest(CurrentShiftID, CurrentRoomTestID);
                frmReportPhieuDiemThiViet frm = new frmReportPhieuDiemThiViet(CurrentDs.DivisionShiftID, stff1.FullName, stff2.FullName, CurrentSubjectID);
                frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Không có dữ liệu!");
            }
        }

     
    }

}


