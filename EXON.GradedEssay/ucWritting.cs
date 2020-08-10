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
using Tung.Log;
using EXON.Common;
using Word = Microsoft.Office.Interop.Word;

using System.IO;
using System.Drawing;
using System.Threading;
using EXON.GradedEssay.Report;

namespace EXON.GradedEssay.Control
{
    public partial class ucWritting : UserControl
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
       

        public ucWritting(int contestID, int LocationID)
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
                List<ContestantResult> listContestant = (

                    from cs in _ContestantShiftService.GetAllByDivisionShiftID(CurrentDs.DivisionShiftID)
                    from tn in _TestNumberService.GetAll().Where(x=>x.ContestantShiftID==cs.ContestantShiftID)
                    where  cs.SCHEDULE.SubjectID == CurrentSubjectID
                    && cs.DIVISION_SHIFTS.Status == (int)Common.StatusDivisionShift.STATUS_COMPLETE
                    select new ContestantResult
                    {
                        TestNumberIndex = CurrentDs.DivisionShiftID.ToString() + "." +  tn.TestNumberIndex.ToString(),
                        ContestantShiftID = tn.ContestantShiftID ?? 0,
                        Score = GetScore(tn.ContestantShiftID ?? 0),
                        DaHoanThanh = CheckHasAnswer(cs.ContestantShiftID) ? "Đã hoàn thành" : "Không làm bài thi viết",
                        PrintAnswer = "Xem"
                    }).OrderBy(x => x.TestNumberIndex).ToList();

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
                MTAQuizDbContext db = new MTAQuizDbContext();
                if (gvMain.DataSource != null)
                {
                    int index = 0;
                    foreach (DataGridViewRow row in gvMain.Rows)
                    {
                        try
                        {
                            int contestantShiftID = int.Parse(row.Cells["cContestantShiftID"].Value.ToString());

                            string v = row.Cells["cScore"].Value.ToString();
                            float score;

                            // score = int.Parse(v);
                            CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID);
                            if (ct != null)
                            {
                                ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);

                                if (anw != null)
                                {
                                    if (v != "")

                                        if (v.IndexOf('.') >= 0) score = float.Parse(v);
                                        else score = int.Parse(v);
                                    else continue;

                                    ANSWERSHEET_WRITING aw = _AnswersheetWritingService.GetByAnwsersheetID(anw.AnswerSheetID);
                                    if (aw != null)
                                    {
                                        aw.WritingScore = score;
                                        aw.Status++;
                                        _AnswersheetWritingService.Update(aw);
                                    }
                                    else
                                    {
                                        aw = new ANSWERSHEET_WRITING
                                        {

                                            AnswerSheetID = anw.AnswerSheetID,
                                            WritingScore = score,
                                            Status = 1
                                        };

                                        _AnswersheetWritingService.Add(aw);
                                        _AnswersheetWritingService.Save();


                                    }




                                }
                                else
                                {
                                    MessageBox.Show(string.Format("Thí sinh {0} bỏ thi.", row.Cells["cTestNumberIndex"].Value.ToString()), "Thông Báo");
                                    continue;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Có Lối Xảy Ra", "Lối");
                                Log.Instance.WriteErrorLog(LogType.FATAL, string.Format("Contestant Test is null with ContestantShiftID = {0}", contestantShiftID));
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lối định dạng điểm thi hoặc ô để trống.", "Lối");

                            gvMain.ClearSelection();
                            gvMain.Rows[index].Selected = true;

                            Log.Instance.WriteErrorLog(LogType.ERROR, string.Format("Error when convert string to numver: {0}", ex.Message));
                            return;
                        }
                        index++;
                    }
                    _AnswersheetWritingService.Save();

                    MessageBox.Show("Nhập điểm thành công.", "Thông báo");
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
                string v = gvMain.Rows[e.RowIndex].Cells["cScore"].Value.ToString();
                if (v.IndexOf('.') >= 0) float.Parse(v);
                else int.Parse(v);
            }
            catch
            {
                MessageBox.Show("Chỉ Nhấp Số. Nếu là số thập phân sử dụng '.' thay vì ','.", "Sai Định Dạng");
                gvMain.CellValueChanged -= gvMain_CellValueChanged;
                gvMain.Rows[e.RowIndex].Cells["cScore"].Value = string.Empty;
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
                id = (int)gvMain.CurrentRow.Cells["cContestantShiftID"].Value;
                TestNumberIndex = gvMain.CurrentRow.Cells["cTestNumberIndex"].Value.ToString(); ;
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                 e.RowIndex >= 0)

                {
                    try
                    {

                        OpenFileAnsewer(TestNumberIndex);
                       
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

        private void OpenFileAnsewer(string testNumberIndex)
        {
            killProcessMSWord();
            objApp = new Word.Application();
            object missing = Missing.Value;
            objApp.Visible = false;
            objDoc = new Word.Document();
            object objMiss = System.Reflection.Missing.Value;

            object readOnly = false;
            DIVISION_SHIFTS CurrentDs = new DIVISION_SHIFTS();
            _DivisionShiftService = new DivisionShiftService();

            CurrentDs = _DivisionShiftService.GetByShiftAndRoomTest(CurrentShiftID, CurrentRoomTestID);
            if (!Directory.Exists(Path.Combine(pathFileTemp.ToString(), CurrentDs.DivisionShiftID.ToString() + "." + CurrentSubjectID.ToString())))
            {
                MessageBox.Show("Chưa tạo bài làm");
                return;
            }
            object szPath = pathFileTemp+"\\" + CurrentDs.DivisionShiftID.ToString() +"." +CurrentSubjectID.ToString() +"\\" + testNumberIndex + ".docx";
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
        public void GetAnswer(int id, string TestNumberIndex)
        {
            MTAQuizDbContext db = new MTAQuizDbContext();

            listans = new List<ListAnwser>();
            listans = (from ctt in db.CONTESTANTS_TESTS.Where(x => x.ContestantShiftID == id)
                       from aswdt in db.ANSWERSHEET_DETAILS.Where(x => x.ANSWERSHEET.ContestantTestID == ctt.ContestantTestID).ToList()
                       from sqt in db.SUBQUESTIONS.Where(x => x.SubQuestionID == aswdt.SubQuestionID && ((x.QUESTION.Type == (int)QuizTypeEnum.Essay) || (x.QUESTION.Type == (int)QuizTypeEnum.Fill))).ToList()

                       select new ListAnwser
                       {
                           anwser = aswdt.AnswerContent,
                           subid = sqt.SubQuestionID,
                       }
                         ).ToList();
            if (listans.Count != 0)
            {
                lstQuestion = new List<Question>();

                lstQuestion = (from ctt in db.CONTESTANTS_TESTS.Where(x => x.ContestantShiftID == id).ToList()
                               from tdt in db.TEST_DETAILS.Where(x => x.TestID == ctt.TestID).ToList()
                               from qt in db.QUESTIONS.Where(x => x.QuestionID == tdt.QuestionID && ((x.Type == (int)QuizTypeEnum.Essay) || (x.Type == (int)QuizTypeEnum.ReWritting))).ToList()
                               from sqt in db.SUBQUESTIONS.Where(x => x.QuestionID == qt.QuestionID && x.SubQuestionContent != null).ToList()
                               select new Question
                               {
                                   QuestionID = sqt.QuestionID,
                                   QuestionContent = sqt.QUESTION.QuestionContent,
                                   SubQuestionContent = sqt.SubQuestionContent,
                                   Testid = ctt.TestID,
                                   Answer = getans(listans, sqt.SubQuestionID),
                                   Score = (int)sqt.Score,
                               }
                     ).ToList();

                if (lstQuestion.Count > 0)
                {
                    CONTEST ct = new CONTEST();
                    ct = _ContestService.GetById(_ContestID);
                    Loading = new ucLoad();
                    // Form Loading 
                    s = new SendWorking(Loading.UpdateValue);
                    s(0);
                    //  Loading.UpdateValue(0);
                    Loading.Show();
                    CreateDocument(lstQuestion, TestNumberIndex, ct.ContestName);
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Thí sinh Không làm bài thi viết");
            }
        }

        public string CheckAnswer(string s)
        {
            string a = "";
            if (s == "")
            {
                a = "Thí sinh bỏ qua câu hỏi này";
                return a;
            }

            return s;
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
        public void FindAndReplace2(Word.Document doc, string Findtext, string ReplaceText)
        {
            Word.Range myStoryRange = doc.Range();

            //First search the main document using the Selection
            Word.Find myFind = myStoryRange.Find;
            myFind.Text = Findtext;
            myFind.Replacement.Text = ReplaceText;
            myFind.Forward = true;
            myFind.Wrap = Word.WdFindWrap.wdFindContinue;
            myFind.Format = false;
            myFind.MatchCase = false;
            myFind.MatchWholeWord = false;
            myFind.MatchWildcards = false;
            myFind.MatchSoundsLike = false;
            myFind.MatchAllWordForms = false;
            myFind.Execute(Replace: Word.WdReplace.wdReplaceAll);

            //'Now search all other stories using Ranges
            foreach (Word.Range otherStoryRange in doc.StoryRanges)
            {
                if (otherStoryRange.StoryType != Word.WdStoryType.wdMainTextStory)
                {
                    Word.Find myOtherFind = otherStoryRange.Find;
                    myOtherFind.Text = Findtext;
                    myOtherFind.Replacement.Text = ReplaceText;
                    myOtherFind.Wrap = Word.WdFindWrap.wdFindContinue;
                    myOtherFind.Execute(Replace: Word.WdReplace.wdReplaceAll);
                }

                // 'Now search all next stories of other stories (doc.storyRanges dont seem to cascades in sub story)
                Word.Range nextStoryRange = otherStoryRange.NextStoryRange;
                while (nextStoryRange != null)
                {
                    Word.Find myNextStoryFind = nextStoryRange.Find;
                    myNextStoryFind.Text = Findtext;
                    myNextStoryFind.Replacement.Text = ReplaceText;
                    myNextStoryFind.Wrap = Word.WdFindWrap.wdFindContinue;
                    myNextStoryFind.Execute(Replace: Word.WdReplace.wdReplaceAll);

                    nextStoryRange = nextStoryRange.NextStoryRange;
                }

            }
        }
        #region taoj file cho tung thi sinh
        private void CreateDocument(List<Question> list, string numberIndex, string ContestName)
        {
            killProcessMSWord();
            objApp = new Word.Application();
            object missing = Missing.Value;
            objDoc = new Word.Document();
            try
            {
                object objMiss = System.Reflection.Missing.Value;
                object readOnly = false;
                objApp.Visible = false;
                objDoc = objApp.Documents.Open(ref pathFile, ref missing, ref readOnly,
                                         ref missing, ref missing, ref missing,
                                         ref missing, ref missing, ref missing,
                                         ref missing, ref missing, ref missing,
                                         ref missing, ref missing, ref missing, ref missing);
                objDoc.Activate();

                Word.Range range = objDoc.Range(0, 0);

                string CauHoi = "";
                for (int i = 0; i < list.Count; i++)
                {

                    CauHoi += string.Format("Câu {0}: ... đ ", i + 1);
                }
                CauHoi += "--------------";
                CauHoi += "Tổng : ... đ";
                //Word.Frame objText;
                //Word.Range range2 = objDoc.Range(0, 0);
                //if (range2.Find.Execute("CAU"))
                //{
                //    objText = objDoc.Frames.Add(range2);
                //    TextBox txtCau = new TextBox();

                //    txtCau.Text = CauHoi;
                //    txtCau.SelectAll();
                //    txtCau.Copy();
                //    objText.Range.PasteAndFormat(WdRecoveryType.wdSingleCellText);
                //}

                this.FindAndReplace2(objDoc, "CAU", CauHoi);
                string datenow = DatetimeConvert.GetDateTimeServer().ToString(@"\N\g\à\y dd \t\h\á\n\g MM \n\ă\m yyyy");
                this.FindAndReplace(objApp, "DATENOW", datenow);
                this.FindAndReplace(objApp, "TESTID", list[0].Testid.ToString());
                this.FindAndReplace(objApp, "NumberIndex", numberIndex);
                this.FindAndReplace(objApp, "ContestName", "Kì thi: " + ContestName);
                if (range.Find.Execute("CONTENT"))
                {
                    Word.Table objTab1;
                    int RowMax = list.Count * 2;
                    objTab1 = objDoc.Tables.Add(range, RowMax, 1, ref objMiss, ref objMiss); //add table object in word document
                    objTab1.Range.ParagraphFormat.SpaceAfter = 2;

                    int iRow;
                    int cursor = 0;


                    for (iRow = 1; iRow <= RowMax; iRow++)

                    {
                        float Per = ((float)iRow / (float)RowMax) * 90;
                        s((int)Per);
                        if (iRow % 2 != 0)
                        {
                            if (cursor < list.Count)
                            {
                                RichTextBox rtfQuestion = new RichTextBox();
                                if (list[cursor].QuestionContent != null)
                                {
                                    if ((cursor == 0) || (cursor > 0 && list[cursor].QuestionID != list[cursor - 1].QuestionID))
                                    {
                                        // câu hỏi lớn 
                                        RichTextBox rtfNumberIndex = new RichTextBox();
                                        rtfNumberIndex.Text = string.Format("Câu hỏi {0} ({1} điểm): ", cursor + 1, list[cursor].Score);
                                        rtfNumberIndex.AppendText("\n");
                                        rtfNumberIndex.Font = new System.Drawing.Font("Times New Roman", 13, FontStyle.Bold);
                                        rtfNumberIndex.Select(rtfNumberIndex.TextLength, 0);
                                        rtfNumberIndex.SelectedRtf = list[cursor].SubQuestionContent;

                                        rtfQuestion.Rtf = list[cursor].QuestionContent;
                                        rtfQuestion.Select(rtfQuestion.TextLength, 0);
                                        rtfQuestion.SelectedRtf = rtfNumberIndex.Rtf;
                                        rtfQuestion.SelectAll();
                                        rtfQuestion.Copy();
                                        objTab1.Cell(iRow, 1).Range.PasteAndFormat(WdRecoveryType.wdSingleCellText);
                                        //rtfQuestion.Rtf = list[cursor].SubQuestionContent;
                                        //rtfQuestion.SelectAll();
                                        //rtfQuestion.Copy();
                                        //objTab1.Cell(iRow, 1).Range.PasteAppendTable();
                                    }
                                    else
                                    {
                                        RichTextBox rtfNumberIndex = new RichTextBox();
                                        rtfNumberIndex.Text = string.Format("Câu hỏi {0} ({1} điểm): ", cursor + 1, list[cursor].Score);
                                        rtfNumberIndex.AppendText("\n");
                                        rtfNumberIndex.Font = new System.Drawing.Font("Times New Roman", 13, FontStyle.Bold);
                                        rtfQuestion.Rtf = rtfNumberIndex.Rtf;
                                        rtfQuestion.Select(rtfQuestion.TextLength, 0);
                                        rtfQuestion.SelectedRtf = list[cursor].SubQuestionContent;
                                        rtfQuestion.SelectAll();
                                        rtfQuestion.Copy();
                                        objTab1.Cell(iRow, 1).Range.PasteAndFormat(WdRecoveryType.wdSingleCellText);
                                    }
                                }
                                else
                                {
                                    RichTextBox rtfNumberIndex = new RichTextBox();
                                    rtfNumberIndex.Text = string.Format("Câu hỏi {0} ({1} điểm): ", cursor + 1, list[cursor].Score);

                                    rtfNumberIndex.Font = new System.Drawing.Font("Times New Roman", 13, FontStyle.Bold);
                                    rtfQuestion.Rtf = rtfNumberIndex.Rtf;
                                    rtfQuestion.Select(rtfQuestion.TextLength, 0);
                                    rtfQuestion.SelectedRtf = list[cursor].SubQuestionContent;
                                    rtfQuestion.SelectAll();
                                    rtfQuestion.Copy();

                                    objTab1.Cell(iRow, 1).Range.PasteAndFormat(WdRecoveryType.wdSingleCellText);
                                }

                                // objTab1.Cell(iRow, 1).Range.PasteAndFormat(WdRecoveryType.wdSingleCellText); //add some text to cell
                            }
                        }
                        else
                        {
                            if (cursor < list.Count)
                            {
                                RichTextBox rtfa = new RichTextBox();
                                if (list[cursor].Answer.Length < 100 && list[cursor].Answer != "")
                                {
                                    RichTextBox rtfReply = new RichTextBox();
                                    rtfa.Text = "Trả lời: ";
                                    rtfReply.Text += list[cursor].Answer;
                                    rtfa.Text += rtfReply.Text;
                                    rtfa.Font = new System.Drawing.Font("Times New Roman", 13, FontStyle.Regular);
                                }
                                else if (list[cursor].Answer != "")
                                {
                                    RichTextBox rtfReply = new RichTextBox();
                                    rtfa.Text = "Trả lời: ";

                                    rtfReply.Rtf += list[cursor].Answer;
                                    rtfa.Text += rtfReply.Text;
                                    rtfa.Font = new System.Drawing.Font("Times New Roman", 13, FontStyle.Regular);
                                }
                                else
                                {
                                    rtfa.Text = "Trả lời: Thí sinh bỏ qua câu hỏi này";
                                    rtfa.Font = new System.Drawing.Font("Times New Roman", 13, FontStyle.Bold);
                                }
                                rtfa.SelectAll();
                                rtfa.Copy();
                                objTab1.Cell(iRow, 1).Range.PasteAndFormat(WdRecoveryType.wdSingleCellText);
                                //  objTab1.Cell(iRow, 1).Range.Text = "Answer :" + CheckAnswer(list[cursor].Answer); //add some text to cell
                                cursor++;
                            }
                        }

                        //objTab1.Rows[iRow].Range.Font.Bold = 1; //make first row of table BOLD
                        objTab1.Columns[1].Width = objApp.InchesToPoints(7); //increase first column width
                    }
                }

                object szPath = pathFileTemp + numberIndex + ".docx";
                //  object szPath = "test.docx"; //your file gets saved with name 'test.docx'
                // objDoc.SaveAs(ref szPath);
                objDoc.SaveAs2(ref szPath, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);

                s(100);
                Loading.Close();
                Loading.Dispose();

                objApp.Documents.Open(ref szPath, ref missing, ref readOnly,
                                         ref missing, ref missing, ref missing,
                                         ref missing, ref missing, ref missing,
                                         ref missing, ref missing, ref missing,
                                         ref missing, ref missing, ref missing, ref missing);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi trong quá trình tạo Word. Vui lòng thử lại! ");
                Loading.Close();
                Loading.Dispose();
            }
            finally
            {
                //you can dispose object here
            }
        }
        #endregion

        public void killProcessMSWord()
        {
            //List<int> processIds = new List<int>();
            //foreach (Process process in Process.GetProcessesByName("WINWORD"))
            //{
            //    processIds.Add(process.Id);
            //}

            // Do whatever you have to
            // And finally - KILL IT!
            foreach (Process process in Process.GetProcessesByName("WINWORD"))
            {

                process.Kill();

            }
        }


        private void cbContest_SelectedValueChanged(object sender, EventArgs e)
        {
            cbShift.DataSource = _ShiftService.GetAll(_ContestID).ToList();
            cbShift.DisplayMember = "ShiftName";
            cbShift.ValueMember = "ShiftID";
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

        private void gvMain_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCreateAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentSubjectID != -1)
                {
                    DIVISION_SHIFTS CurrentDs = new DIVISION_SHIFTS();
                    _DivisionShiftService = new DivisionShiftService();

                    CurrentDs = _DivisionShiftService.GetByShiftAndRoomTest(CurrentShiftID, CurrentRoomTestID);
                    string PathFolderTemp = CurrentDs.DivisionShiftID.ToString()+"." +CurrentSubjectID.ToString();
                    if (CurrentDs.Status != (int)Common.StatusDivisionShift.STATUS_COMPLETE)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Ca thi chưa kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                        return;
                    }
                    List<ContestantResult> listContestant = new List<ContestantResult>();
                    listContestant = (
                        from cs in _ContestantShiftService.GetAllByDivisionShiftID(CurrentDs.DivisionShiftID)
                        from tn in _TestNumberService.GetAll()
                        where cs.ContestantShiftID == tn.ContestantShiftID && cs.SCHEDULE.SubjectID == CurrentSubjectID
                        select new ContestantResult
                        {
                            TestNumberIndex = CurrentDs.DivisionShiftID.ToString() + "." + tn.TestNumberIndex.ToString(),
                            ContestantShiftID = tn.ContestantShiftID ?? 0,
                            Score = GetScore(tn.ContestantShiftID ?? 0),
                            DaHoanThanh = CheckHasAnswer(cs.ContestantShiftID) ? "Đã hoàn thành" : "Không làm bài thi viết",
                            PrintAnswer = "Xem"
                        }).OrderBy(x => x.TestNumberIndex).ToList();
                    int sum = 0;
                    foreach (ContestantResult ct in listContestant)
                    {
                        if (ct.DaHoanThanh.Equals("Đã hoàn thành"))
                        {

                            sum++;
                        }

                    }
                    if (sum > 0)
                    {
                        Loading = new ucLoad();
                        Loading.TopMost = true;
                        // Form Loading 
                        s = new SendWorking(Loading.UpdateValue);
                        s(0);

                        Loading.Show();
                        int count = 0;

                        foreach (ContestantResult ct in listContestant)
                        {
                            if (ct.DaHoanThanh.Equals("Đã hoàn thành"))
                            {

                                count++;
                                float Per = ((float)count / (float)sum) * 90;
                                s((int)Per);
                                int Return = GetAnswerForAll(ct.ContestantShiftID, ct.TestNumberIndex, PathFolderTemp);

                                if (count == sum && Return == 1)
                                {
                                    s(100);
                                    Loading.Close();
                                    Loading.Dispose();
                                    killProcessMSWord();
                                    MetroFramework.MetroMessageBox.Show(this, "Đã tạo tất cả bài làm xong!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else if (count == sum && Return == -1)
                                {
                                    s(100);
                                    Loading.Close();
                                    Loading.Dispose();
                                    killProcessMSWord();
                                    MetroFramework.MetroMessageBox.Show(this, "Có lỗi trong quá trình tạo! Vui lòng chọn tạo lại.", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.ToString());
            }


        }
        public int GetAnswerForAll(int id, string TestNumberIndex, string PathFolderTemp)
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
                lstQuestion = new List<Question>();
                int number = 0;
                lstQuestion = (from ctt in db.CONTESTANTS_TESTS.Where(x => x.ContestantShiftID == id).ToList()
                               from tdt in db.TEST_DETAILS.Where(x => x.TestID == ctt.TestID).ToList()
                               from qt in db.QUESTIONS.Where(x => x.QuestionID == tdt.QuestionID/* && (x.Type != (int)QuizTypeEnum.Speaking || (x.Type == (int)QuizTypeEnum.FillAudio))*//* || (x.Type == (int)QuizTypeEnum.Fill) || (x.Type == (int)QuizTypeEnum.FillAudio))*/).ToList()
                               from sqt in db.SUBQUESTIONS.Where(x => x.QuestionID == qt.QuestionID /*&& x.SubQuestionContent != null*/).ToList()
                               select new Question
                               {
                                   NO = ++number,
                                   QuestionID = sqt.QuestionID,
                                   QuestionContent = sqt.QUESTION.QuestionContent,
                                   SubQuestionContent = sqt.SubQuestionContent,
                                   Testid = ctt.TestID,
                                   Answer = getans(listans, sqt.SubQuestionID),
                                   Score = (int)sqt.Score,
                                   Type = sqt.QUESTION.Type ?? default(int)
                               }
                     ).ToList();
                lstQuestion.RemoveAll(x => x.Type == (int)QuizTypeEnum.Regular || x.Type == (int)QuizTypeEnum.Speaking || x.Type == (int)QuizTypeEnum.Audio || x.Type == (int)QuizTypeEnum.Matching || (x.Type == (int)QuizTypeEnum.FillAudio) || (x.Type == (int)QuizTypeEnum.Fill));

                if (lstQuestion.Count > 0)
                {
                    CONTEST ct = new CONTEST();
                    ct = _ContestService.GetById(_ContestID);
                    //Loading = new ucLoad();
                    //// Form Loading 
                    //s = new SendWorking(Loading.UpdateValue);
                    //s(0);
                    ////  Loading.UpdateValue(0);
                    //Loading.Show();

                    return CreateDocumentForAll(lstQuestion, TestNumberIndex, ct.ContestName, PathFolderTemp);
                }

            }
            return -1;
        }
        private int CreateDocumentForAll(List<Question> list, string numberIndex, string ContestName, string PathFolderTemp)
        {
            killProcessMSWord();
            objApp = new Word.Application();
            object missing = Missing.Value;
            objDoc = new Word.Document();
            try
            {
                object objMiss = System.Reflection.Missing.Value;
                object readOnly = false;
                objApp.Visible = false;
                objDoc = objApp.Documents.Open(ref pathFile, ref missing, ref readOnly,
                                         ref missing, ref missing, ref missing,
                                         ref missing, ref missing, ref missing,
                                         ref missing, ref missing, ref missing,
                                         ref missing, ref missing, ref missing, ref missing);
                objDoc.Activate();

                Word.Range range = objDoc.Range(0, 0);
                string CauHoi = "";
                for (int i = 0; i < list.Count; i++)
                {
                    CauHoi += string.Format("Câu {0}: ... đ ", list[i].NO);
                }
                CauHoi += "--------------";
                CauHoi += "Tổng : ... đ";
                //Word.Frame objText;
                //Word.Range range2 = objDoc.Range(0, 0);
                //if (range2.Find.Execute("CAU"))
                //{
                //    objText = objDoc.Frames.Add(range2);
                //    TextBox txtCau = new TextBox();

                //    txtCau.Text = CauHoi;
                //    txtCau.SelectAll();
                //    txtCau.Copy();
                //    objText.Range.PasteAndFormat(WdRecoveryType.wdSingleCellText);
                //}

                this.FindAndReplace2(objDoc, "CAU", CauHoi);

                string datenow = DatetimeConvert.GetDateTimeServer().ToString(@"\N\g\à\y dd \t\h\á\n\g MM \n\ă\m yyyy");
                this.FindAndReplace(objApp, "DATENOW", datenow);
                this.FindAndReplace(objApp, "SubjectName", cbSubject.Text.ToUpper());
                this.FindAndReplace(objApp, "TESTID", list[0].Testid.ToString());
                this.FindAndReplace(objApp, "NumberIndex", numberIndex);
                this.FindAndReplace(objApp, "ContestName", "Kì thi: " + ContestName);
                if (range.Find.Execute("CONTENT"))
                {
                    Word.Table objTab1;
                    int RowMax = list.Count * 2;
                    objTab1 = objDoc.Tables.Add(range, RowMax, 1, ref objMiss, ref objMiss); //add table object in word document
                    objTab1.Range.ParagraphFormat.SpaceAfter = 2;

                    int iRow;
                    int cursor = 0;


                    for (iRow = 1; iRow <= RowMax; iRow++)

                    {
                        float Per = ((float)iRow / (float)RowMax) * 90;

                        if (iRow % 2 != 0)
                        {
                            if (cursor < list.Count)
                            {
                                RichTextBox rtfQuestion = new RichTextBox();
                                if (list[cursor].QuestionContent != null)
                                {
                                    if ((cursor == 0) || (cursor > 0 && list[cursor].QuestionID != list[cursor - 1].QuestionID))
                                    {
                                        // câu hỏi lớn 
                                        RichTextBox rtfNumberIndex = new RichTextBox();

                                        rtfNumberIndex.Text = string.Format("Câu hỏi {0} ({1} điểm): ", list[cursor].NO, list[cursor].Score);
                                        rtfNumberIndex.AppendText("\n");
                                        rtfNumberIndex.Font = new System.Drawing.Font("Times New Roman", 13, FontStyle.Bold);
                                        rtfNumberIndex.Select(rtfNumberIndex.TextLength, 0);
                                        rtfNumberIndex.SelectedRtf = list[cursor].SubQuestionContent;

                                        rtfQuestion.Rtf = list[cursor].QuestionContent;
                                        rtfQuestion.Select(rtfQuestion.TextLength, 0);
                                        rtfQuestion.SelectedRtf = rtfNumberIndex.Rtf;
                                        bool CheckCopy = true;
                                        while (CheckCopy)
                                        {
                                            Clipboard.Clear();
                                            rtfQuestion.SelectAll();
                                            rtfQuestion.Copy();

                                            try
                                            {
                                                objTab1.Cell(iRow, 1).Range.PasteAndFormat(WdRecoveryType.wdSingleCellText);
                                                CheckCopy = false;
                                            }
                                            catch
                                            {
                                                rtfQuestion.SelectAll();
                                                rtfQuestion.Copy();
                                                objTab1.Cell(iRow, 1).Range.PasteAndFormat(WdRecoveryType.wdSingleCellText);
                                                CheckCopy = false;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        RichTextBox rtfNumberIndex = new RichTextBox();
                                        rtfNumberIndex.Text = string.Format("Câu hỏi {0} ({1} điểm): ", list[cursor].NO, list[cursor].Score);
                                        rtfNumberIndex.AppendText("\n");
                                        rtfNumberIndex.Font = new System.Drawing.Font("Times New Roman", 13, FontStyle.Bold);
                                        rtfQuestion.Rtf = rtfNumberIndex.Rtf;
                                        rtfQuestion.Select(rtfQuestion.TextLength, 0);
                                        rtfQuestion.SelectedRtf = list[cursor].SubQuestionContent;
                                        Clipboard.Clear();

                                        bool CheckCopy = true;
                                        while (CheckCopy)
                                        {
                                            Clipboard.Clear();
                                            rtfQuestion.SelectAll();
                                            rtfQuestion.Copy();
                                            try
                                            {
                                                objTab1.Cell(iRow, 1).Range.PasteAndFormat(WdRecoveryType.wdSingleCellText);
                                                CheckCopy = false;
                                            }
                                            catch
                                            {
                                                rtfQuestion.SelectAll();
                                                rtfQuestion.Copy();
                                                objTab1.Cell(iRow, 1).Range.PasteAndFormat(WdRecoveryType.wdSingleCellText);
                                                CheckCopy = false;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    RichTextBox rtfNumberIndex = new RichTextBox();
                                    rtfNumberIndex.Text = string.Format("Câu hỏi {0} ({1} điểm): ", list[cursor].NO, list[cursor].Score);

                                    rtfNumberIndex.Font = new System.Drawing.Font("Times New Roman", 13, FontStyle.Bold);
                                    rtfQuestion.Rtf = rtfNumberIndex.Rtf;
                                    rtfQuestion.Select(rtfQuestion.TextLength, 0);
                                    rtfQuestion.SelectedRtf = list[cursor].SubQuestionContent;

                                    bool CheckCopy = true;
                                    while (CheckCopy)

                                    {
                                        Clipboard.Clear();
                                        rtfQuestion.SelectAll();
                                        rtfQuestion.Copy();
                                        try
                                        {
                                            objTab1.Cell(iRow, 1).Range.PasteAndFormat(WdRecoveryType.wdSingleCellText);
                                            CheckCopy = false;
                                        }
                                        catch
                                        {
                                            rtfQuestion.SelectAll();
                                            rtfQuestion.Copy();
                                            objTab1.Cell(iRow, 1).Range.PasteAndFormat(WdRecoveryType.wdSingleCellText);
                                            CheckCopy = false;
                                        }
                                    }


                                }

                                // objTab1.Cell(iRow, 1).Range.PasteAndFormat(WdRecoveryType.wdSingleCellText); //add some text to cell
                            }
                        }
                        else
                        {
                            if (cursor < list.Count)
                            {
                                RichTextBox rtfa = new RichTextBox();
                                if (list[cursor].Answer.Length < 100 && list[cursor].Answer != "")
                                {
                                    RichTextBox rtfReply = new RichTextBox();
                                    rtfa.Text = "Trả lời: ";
                                    rtfReply.Text += list[cursor].Answer;
                                    rtfa.Text += rtfReply.Text;
                                    rtfa.Font = new System.Drawing.Font("Times New Roman", 13, FontStyle.Regular);
                                }
                                else if (list[cursor].Answer != "")
                                {
                                    rtfa.Text = "Trả lời: ";
                                    rtfa.Select(rtfa.TextLength, 0);
                                    rtfa.SelectedRtf = list[cursor].Answer;

                                    rtfa.Font = new System.Drawing.Font("Times New Roman", 13, FontStyle.Regular);
                                }
                                else
                                {
                                    rtfa.Text = "Trả lời: Thí sinh bỏ qua câu hỏi này";
                                    rtfa.Font = new System.Drawing.Font("Times New Roman", 13, FontStyle.Bold);
                                }
                                bool checkCopy = true;
                                while (checkCopy)
                                {
                                    Clipboard.Clear();
                                    rtfa.SelectAll();
                                    rtfa.Copy();
                                    try
                                    {
                                        objTab1.Cell(iRow, 1).Range.PasteAndFormat(WdRecoveryType.wdSingleCellText);
                                        checkCopy = false;
                                    }
                                    catch
                                    {
                                        rtfa.SelectAll();
                                        rtfa.Copy();
                                        objTab1.Cell(iRow, 1).Range.PasteAndFormat(WdRecoveryType.wdSingleCellText);
                                        checkCopy = false;
                                    }

                                }


                                //  objTab1.Cell(iRow, 1).Range.Text = "Answer :" + CheckAnswer(list[cursor].Answer); //add some text to cell
                                cursor++;
                            }
                        }

                        //objTab1.Rows[iRow].Range.Font.Bold = 1; //make first row of table BOLD
                        objTab1.Columns[1].Width = objApp.InchesToPoints(7); //increase first column width
                    }
                }

             
                if (!Directory.Exists(Path.Combine(pathFileTemp.ToString(), PathFolderTemp)))
                    Directory.CreateDirectory(Path.Combine(Path.Combine(pathFileTemp.ToString(), PathFolderTemp)));
                object szPath = pathFileTemp + "\\"+PathFolderTemp+"\\" + numberIndex + ".docx";
                //  object szPath = "test.docx"; //your file gets saved with name 'test.docx'
                // objDoc.SaveAs(ref szPath);
                object read = true;
                objDoc.SaveAs2(ref szPath, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref read,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);
                objDoc.Close();

                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi trong quá trình tạo Word. Vui lòng thử lại! ");
                Loading.Close();
                Loading.Dispose();
                return -1;
            }
            finally
            {
                //you can dispose object here
            }
        }

        private void gvMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gvMain.Rows[e.RowIndex].Cells["cDaHoanThanh"].Value.ToString() == "Đã hoàn thành")
            {
                gvMain.Rows[e.RowIndex].Cells["cDaHoanThanh"].Style = new DataGridViewCellStyle { ForeColor = Color.Black, BackColor = Color.MediumSpringGreen };
            }
        }

        private void btnInDapAn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentSubjectID != -1)
                {

                    DIVISION_SHIFTS ds = new DIVISION_SHIFTS();
                    _DivisionShiftService = new DivisionShiftService();
                    _ContestantShiftService = new ContestantShiftService();
                    MTAQuizDbContext db = new MTAQuizDbContext();
                    ds = _DivisionShiftService.GetByShiftAndRoomTest(CurrentShiftID, CurrentRoomTestID);

                    if (ds.Status != (int)Common.StatusDivisionShift.STATUS_COMPLETE)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Ca thi chưa kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                        return;
                    }
                    List<PrintWritingAnswerQuestion> lstWriting = new List<PrintWritingAnswerQuestion>();


                    var lstWriting1 = (

                                 from cts in _ContestantShiftService.GetAllByDivisionShiftID(ds.DivisionShiftID).ToList()
                                 from ctt in db.CONTESTANTS_TESTS.Where(x => x.ContestantShiftID == cts.ContestantShiftID).ToList()
                                 from td in db.TEST_DETAILS.Where(x => x.TestID == ctt.TestID).ToList()
                                 from qt in db.QUESTIONS.Where(x => x.QuestionID == td.QuestionID && ((x.Type == (int)QuizTypeEnum.Essay)|| x.Type == (int)QuizTypeEnum.ReWritting)).ToList()

                                 from sqt in qt.SUBQUESTIONS.ToList()
                                 from ans in db.ANSWERS.Where(x => x.SubQuestionID == sqt.SubQuestionID).ToList()
                                 where cts.SCHEDULE.SubjectID == CurrentSubjectID
                                 select new
                                 {
                                     QuestionID = qt.QuestionID,
                                     SubQuestionContent = sqt.SubQuestionContent,
                                     AnswerContent = ans.AnswerContent,
                                     QuestionContent = qt.QuestionContent,
                                     Score = (float)sqt.Score

                                 }
                         ).Distinct().ToList();
                    foreach (var item in lstWriting1)
                    {
                        PrintWritingAnswerQuestion prt = new PrintWritingAnswerQuestion();
                        prt.QuestionID = item.QuestionID;
                        prt.SubQuestionContent = item.SubQuestionContent;
                        prt.AnswerContent = item.AnswerContent;
                        prt.QuestionContent = item.QuestionContent;
                        prt.Score = item.Score;
                        lstWriting.Add(prt);
                    }
                    if (lstWriting.Count > 0)
                    {
                        Loading = new ucLoad();
                        Loading.TopMost = true;
                        // Form Loading 
                        s = new SendWorking(Loading.UpdateValue);
                        s(0);
                        //  Loading.UpdateValue(0);
                        Loading.Show();
                        CreateDocumentForAnswer(lstWriting);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Không có dữ liệu!");

            }
        }
        private void CreateDocumentForAnswer(List<PrintWritingAnswerQuestion> list)
        {
            killProcessMSWord();
            objApp = new Word.Application();
            object missing = Missing.Value;
            objDoc = new Word.Document();
            try
            {
                object objMiss = System.Reflection.Missing.Value;
                object readOnly = false;
                objApp.Visible = false;
                objDoc = objApp.Documents.Open(ref pathFileForAnswer, ref missing, ref readOnly,
                                         ref missing, ref missing, ref missing,
                                         ref missing, ref missing, ref missing,
                                         ref missing, ref missing, ref missing,
                                         ref missing, ref missing, ref missing, ref missing);
                objDoc.Activate();

                Word.Range range = objDoc.Range(0, 0);
                if (range.Find.Execute("CONTENT"))
                {
                    Word.Table objTab1;
                    int RowMax = list.Count * 2;
                    objTab1 = objDoc.Tables.Add(range, RowMax, 1, ref objMiss, ref objMiss); //add table object in word document
                    objTab1.Range.ParagraphFormat.SpaceAfter = 2;

                    int iRow;
                    int cursor = 0;
                    int Number = 0;

                    for (iRow = 1; iRow <= RowMax; iRow++)

                    {
                        float Per = ((float)iRow / (float)RowMax) * 90;
                        s((int)Per);
                        if (iRow % 2 != 0)
                        {

                            if (cursor < list.Count)
                            {
                                RichTextBox rtfQuestion = new RichTextBox();
                                //if (list[cursor].QuestionContent != null)
                                //{
                                if ((cursor == 0) || (cursor > 0 && list[cursor].QuestionID != list[cursor - 1].QuestionID))
                                {


                                    // câu hỏi lớn 
                                    RichTextBox rtfNumberIndex = new RichTextBox();

                                    rtfNumberIndex.Text += string.Format("Câu hỏi {0} ({1} điểm): ", Number + 1, list[cursor].Score);
                                    rtfNumberIndex.AppendText("\n");
                                    rtfNumberIndex.Font = new System.Drawing.Font("Times New Roman", 13, FontStyle.Bold);
                                    rtfNumberIndex.Select(rtfNumberIndex.TextLength, 0);
                                    rtfNumberIndex.SelectedRtf = list[cursor].SubQuestionContent;
                                    //rtfQuestion.Text = string.Format("Mã đề: {0}", list[cursor].TestID.ToString());
                                    rtfQuestion.AppendText("\n");
                                    rtfQuestion.Select(rtfQuestion.TextLength, 0);
                                    rtfQuestion.SelectedRtf = list[cursor].QuestionContent;
                                    rtfQuestion.Select(rtfQuestion.TextLength, 0);
                                    rtfQuestion.SelectedRtf = rtfNumberIndex.Rtf;

                                    bool CheckCopy = true;
                                    while (CheckCopy)
                                    {
                                        Clipboard.Clear();
                                        rtfQuestion.SelectAll();
                                        Thread.Sleep(100);
                                        rtfQuestion.Copy();

                                        try
                                        {
                                            objTab1.Cell(iRow, 1).Range.PasteAndFormat(WdRecoveryType.wdSingleCellText);
                                            CheckCopy = false;
                                        }
                                        catch
                                        {
                                            rtfQuestion.SelectAll();
                                            Thread.Sleep(100);
                                            rtfQuestion.Copy();
                                            objTab1.Cell(iRow, 1).Range.PasteAndFormat(WdRecoveryType.wdSingleCellText);
                                            CheckCopy = false;

                                        }

                                        Number++;
                                    }
                                }
                                else
                                {

                                    RichTextBox rtfNumberIndex = new RichTextBox();
                                    rtfNumberIndex.Text = string.Format("Câu hỏi {0} ({1} điểm): ", Number + 1, list[cursor].Score);
                                    rtfNumberIndex.AppendText("\n");
                                    rtfNumberIndex.Font = new System.Drawing.Font("Times New Roman", 13, FontStyle.Bold);
                                    rtfQuestion.Rtf = rtfNumberIndex.Rtf;
                                    rtfQuestion.Select(rtfQuestion.TextLength, 0);
                                    rtfQuestion.SelectedRtf = list[cursor].SubQuestionContent;
                                    bool CheckCopy = true;
                                    while (CheckCopy)
                                    {
                                        Clipboard.Clear();
                                        rtfQuestion.SelectAll();

                                        Thread.Sleep(100);
                                        rtfQuestion.Copy();


                                        try
                                        {
                                            objTab1.Cell(iRow, 1).Range.PasteAndFormat(WdRecoveryType.wdSingleCellText);
                                            CheckCopy = false;
                                        }
                                        catch
                                        {
                                            rtfQuestion.SelectAll();
                                            Thread.Sleep(100);
                                            rtfQuestion.Copy();
                                            objTab1.Cell(iRow, 1).Range.PasteAndFormat(WdRecoveryType.wdSingleCellText);
                                            CheckCopy = false;
                                        }
                                        Number++;
                                    }
                                }

                                
                            }
                        }
                        else
                        {
                            if (cursor < list.Count)
                            {
                                RichTextBox rtfa = new RichTextBox();

                                if (list[cursor].AnswerContent != null)
                                {
                                    RichTextBox rtfReply = new RichTextBox();
                                    rtfReply.Text = "Đáp án: ";
                                    rtfReply.Font = new System.Drawing.Font("Times New Roman", 13, FontStyle.Bold);
                                    //   rtfReply.Rtf += list[cursor].AnswerContent;
                                    rtfa.Rtf = rtfReply.Rtf;
                                    rtfa.Select(rtfa.TextLength, 0);
                                    rtfa.SelectedRtf = list[cursor].AnswerContent;

                                }
                                else
                                {
                                    rtfa.Text = "Không có đáp án cho câu hỏi này";
                                    rtfa.Font = new System.Drawing.Font("Times New Roman", 13, FontStyle.Bold);
                                }

                                Thread.Sleep(500);
                                bool CheckCopy = true;
                                while (CheckCopy)
                                {
                                    try
                                    {
                                        Clipboard.Clear();
                                        rtfa.SelectAll();
                                        rtfa.Copy();
                                        objTab1.Cell(iRow, 1).Range.PasteAndFormat(WdRecoveryType.wdSingleCellText);
                                        CheckCopy = false;
                                    }
                                    catch
                                    {
                                        rtfa.SelectAll();
                                        Thread.Sleep(100);
                                        rtfa.Copy();
                                        objTab1.Cell(iRow, 1).Range.PasteAndFormat(WdRecoveryType.wdSingleCellText);
                                        CheckCopy = false;
                                    }

                                }
                                //  objTab1.Cell(iRow, 1).Range.Text = "Answer :" + CheckAnswer(list[cursor].Answer); //add some text to cell
                                cursor++;
                            }
                        }

                        //objTab1.Rows[iRow].Range.Font.Bold = 1; //make first row of table BOLD
                        objTab1.Columns[1].Width = objApp.InchesToPoints(7); //increase first column width
                    }
                    Thread.Sleep(200);
                }


                object szPath = pathFileTemp + "DapAnThiViet.docx";
                //  object szPath = "test.docx"; //your file gets saved with name 'test.docx'
                // objDoc.SaveAs(ref szPath);
                objDoc.SaveAs2(ref szPath, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);
                s(100);
                Loading.Close();
                Loading.Dispose();
                objApp.Documents.Open(ref szPath, ref missing, ref readOnly,
                                         ref missing, ref missing, ref missing,
                                         ref missing, ref missing, ref missing,
                                         ref missing, ref missing, ref missing,
                                         ref missing, ref missing, ref missing, ref missing);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi trong quá trình tạo Word. Vui lòng thử lại!");
                Loading.Close();
                Loading.Dispose();
            }
            finally
            {
                //you can dispose object here
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

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

        private void btnInTatCaBaiLam_Click(object sender, EventArgs e)
        {
            try
            {

                DIVISION_SHIFTS CurrentDs = new DIVISION_SHIFTS();
                _DivisionShiftService = new DivisionShiftService();

                CurrentDs = _DivisionShiftService.GetByShiftAndRoomTest(CurrentShiftID, CurrentRoomTestID);
                if (!Directory.Exists(Path.Combine(pathFileTemp.ToString(),CurrentDs.DivisionShiftID.ToString()+"." + CurrentSubjectID.ToString())))
                {
                    MessageBox.Show("Chưa tạo bài làm");
                    return;
                }
                else
                {
                    string outputFileName = (pathFileTemp.ToString() + "\\" + CurrentDs.DivisionShiftID.ToString() + "." + CurrentSubjectID.ToString() + "\\" + "bailamtatca.docx");
                  
                    File.Delete(outputFileName);
                    string[] filePaths = Directory.GetFiles(pathFileTemp.ToString() + "\\" + CurrentDs.DivisionShiftID.ToString() + "." + CurrentSubjectID.ToString() + "\\");
                    string[] documentsToMerge = filePaths;
                    Merge(documentsToMerge, outputFileName, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không có dữ liệu! Vui lòng thử lại");
                Log.Instance.WriteErrorLog(LogType.ERROR, "Loi" + ex.ToString());
            }


        }
        public void Merge(string[] filesToMerge, string outputFilename, bool insertPageBreaks)
        {
        
            object missing = System.Type.Missing;
            object pageBreak = Word.WdBreakType.wdSectionBreakNextPage;
            object outputFile = outputFilename;
             killProcessMSWord();
            // Create a new Word application
            Word.Application wordApplication = new Word.Application();

            try
            {
                // Create a new file based on our template
                Word.Document wordDocument = wordApplication.Documents.Add(
                                              ref missing
                                            , ref missing
                                            , ref missing
                                            , ref missing);

                // Make a Word selection object.
                Word.Selection selection = wordApplication.Selection;
                selection.Font.Name = "Times New Roman";
                //Count the number of documents to insert;
                int documentCount = filesToMerge.Length;

                //A counter that signals that we shoudn't insert a page break at the end of document.
                int breakStop = 0;
                int LenghtFile = filesToMerge.Length;
                int index = 0;
                frmProgress frm = new frmProgress(LenghtFile);
                frm.Show();
                // Loop thru each of the Word documents
                foreach (string file in filesToMerge)
                {
                    breakStop++;
                    index++;
                    // Insert the files to our template
                    selection.InsertFile( file
                                            , ref missing
                                            , ref missing
                                            , ref missing
                                            , ref missing);

                   
                    //Do we want page breaks added after each documents?
                    if (insertPageBreaks && breakStop != documentCount)
                    {
                        selection.InsertBreak(ref pageBreak);
                    }
                    frm.UpdateValue(index);
                }

                // Save the document to it's output file.
               object read = true;
                wordDocument.SaveAs2(ref outputFile, ref missing, ref missing, ref missing,
                   ref missing, ref missing,  read,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing);
                wordDocument.Close();

             
                // Clean up!

                killProcessMSWord();
                objApp = new Word.Application();
              
                objApp.Visible = false;
                objDoc = new Word.Document();
                object objMiss = System.Reflection.Missing.Value;
                object readOnly = false;
             
                objDoc = objApp.Documents.Open(ref outputFile, ref missing, ref readOnly,
                                          ref missing, ref missing, ref missing,
                                          ref missing, ref missing, ref missing,
                                          ref missing, ref missing, ref missing,
                                          ref missing, ref missing, ref missing, ref missing);
                objDoc.Activate();
                frm.Close();
                objApp.Documents.Open(ref outputFile, ref missing, ref readOnly,
                                           ref missing, ref missing, ref missing,
                                           ref missing, ref missing, ref missing,
                                           ref missing, ref missing, ref missing,
                                           ref missing, ref missing, ref missing, ref missing);
                

            }
            catch (Exception ex)
            {
                //I didn't include a default error handler so i'm just throwing the error
                throw ex;
            }
        
        }

       
    }

}
internal class ListAnwser
{
    public string anwser { get; set; }
    public int subid { get; set; }
}
public class PrintWritingAnswerQuestion
{
    public int TestID { get; set; }
    public string SubQuestionContent { get; set; }
    public string AnswerContent { get; set; }
    public string QuestionContent { get; set; }
    public float Score { get; set; }
    public int QuestionID { get; set; }
}
internal class Question
{
    public int QuestionID { get; set; }
    public string SubQuestionContent { get; set; }
    public string QuestionContent { get; set; }
    public int Testid { get; set; }
    public int NO { get; set; }
    public int Type { get; set; }
    public int Score { get; set; }
    public string Answer { get; set; }
}

public class ContestantShift
{
    public string ContestantShiftID { get; set; }
    public string NumberIndex { get; set; }
    public string QuestionContent { get; set; }
    public string Anwser { get; set; }
}

public class ContestantResult
{
    public string TestNumberIndex { get; set; }
    public int ContestantShiftID { get; set; }
    public string Score { get; set; }
    public string DaHoanThanh { get; set; }
    private string Save { get; set; }
    public string PrintAnswer { get; set; }
}


