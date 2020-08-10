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
using Microsoft.Office.Interop.Word;
using EXON.Common;
using EXON.SubModel.Models;
using EXON.GradedEssay.Report;
using Word = Microsoft.Office.Interop.Word;

using System.Threading;
using System.Reflection;
using System.Diagnostics;

namespace EXON.GradedEssay.Control
{
    public partial class ucSpeakingContest : UserControl
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
        private BagOfTestService _BagOfTestService;
        private TestService _TestService;
        private RoomTestService _RoomTestService;




        #endregion Service

        private ucLoad Loading = new ucLoad();
        public delegate void SendWorking(int value);
        SendWorking s;
      
        private Word.Application objApp;
        private Word.Document objDoc;
        private string columnClick;
        private object pathFile = Constant.pathTempSpeaking;
        private object pathFileTemp = Constant.pathTempAnswer;
        MTAQuizDbContext db = new MTAQuizDbContext();
        List<PrintSpeakingQuestion> lstSubSpeaking = new List<PrintSpeakingQuestion>();
        private frmInput frmInput;
        private int _ContestID { get; set; }
        private int _LocationID { get; set; }
        public ucSpeakingContest(int contestID, int LocationID)
        {

        
            _ContestID = contestID;
            _LocationID = LocationID;
            InitializeComponent();
            InitializeService();
            InitializeControl();
            panel1.Height = 65;
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
        }

        private void InitializeControl()
        {
            try
            {
                _ContestantService = new ContestantService();
                _ContestantShiftService = new ContestantShiftService();
                _ScheduleService = new ScheduleService();
                cbSubject.DataSource = (from sj in _SubjectService.GetAll().ToList()
                                        from sch in _ScheduleService.GetAll().Where(x=>x.ContestID==_ContestID).ToList()
                                        where sj.SubjectID == sch.SubjectID 
                                        select new
                                        {
                                            SubjectName = sj.SubjectName,
                                            SubjectID= sj.SubjectID
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
            if(CurrentSubjectID!=-1)
            {
                _ContestantService = new ContestantService();
                _ContestantShiftService = new ContestantShiftService();
              
               
                int index = 0;
                List<ContestantSpeakingResultContest> lstContestantShift = new List<ContestantSpeakingResultContest>();
                lstContestantShift = (from cs in _ContestantShiftService.GetAll()
                                      .Where(x=>x.SCHEDULE.SubjectID == CurrentSubjectID 
                                      && x.SCHEDULE.ContestID==_ContestID 
                                      && x.DIVISION_SHIFTS.ROOMTEST.LOCATION.LocationID==_LocationID)
                                   
                                      select new ContestantSpeakingResultContest
                                      {
                                          STT = ++index,
                                          // ShiftName = GetShiftName(cs.DivisionShiftID),
                                          ContestantCode = cs.CONTESTANT.ContestantCode,
                                          FullName = cs.CONTESTANT.FullName,
                                          DOB = DateTimeHelpers.ConvertUnixToDateTime(cs.CONTESTANT.DOB.Value)
                                                                       .ToShortDateString(),
                                          ShiftName = cs.DIVISION_SHIFTS.SHIFT.ShiftName,
                                          PhongThi = cs.DIVISION_SHIFTS.ROOMTEST.RoomTestName,
                                          Unit = cs.CONTESTANT.Unit,
                                          // TestID = ct.TestID,
                                          Score = GetScore(cs.ContestantShiftID),
                                          ContestantShiftID = cs.ContestantShiftID,
                                      }
                                      ).ToList();
                gvMain.DataSource = lstContestantShift;
            }
        }
        private string GetScore(int contestantShiftID)
        {

            if (contestantShiftID>0)
            {
                _ContestantTestService = new ContestantTestService();
                CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID);
                if (ct != null)
                {
                    ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);
                    if (anw != null)
                    {
                        ANSWERSHEET_SPEAKING aw = _AnswersheetSpeakingService.GetByAnwsersheetID(anw.AnswerSheetID);
                        if (aw != null)
                        {
                            return aw.SpeakingScore.ToString();
                        }
                    }
                    else
                    {
                        anw = new ANSWERSHEET
                        {
                            ContestantTestID = ct.ContestantTestID,
                            Status = 4002
                        };
                        _AnswersheetService.Add(anw);
                        _AnswersheetService.Save();
                    }
                }
            }
            return string.Empty;
        }

        private void gvMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gvMain.DataSource == null || (columnClick != "cScore"))
                return;
            try
            {
                string v = gvMain.Rows[e.RowIndex].Cells[columnClick].Value.ToString();
                if (v.IndexOf('.') >= 0) float.Parse(v);
                else int.Parse(v);
            }
            catch
            {
                MessageBox.Show("Chỉ Nhấp Số. Nếu là số thập phân sử dụng '.' thay vì ','.", "Sai Định Dạng");
                gvMain.CellValueChanged -= gvMain_CellValueChanged;
                gvMain.Rows[e.RowIndex].Cells[columnClick].Value = string.Empty;
                gvMain.CellValueChanged += gvMain_CellValueChanged;
            }
        }

        private void gvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            columnClick = gvMain.Columns[e.ColumnIndex].Name;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (gvMain.DataSource != null)
            {
                int index = 0;
                foreach (DataGridViewRow row in gvMain.Rows)
                {
                    try
                    {
                        //contestantShiftID
                        int contestantShiftID = int.Parse(row.Cells["cContestantShiftID"].Value.ToString());

                        //score
                        string v = row.Cells["cScore"].Value.ToString();
                        float score;
                        if (v != "")
                        {
                            if (v.IndexOf('.') >= 0) score = float.Parse(v);
                            else score = int.Parse(v);
                        }
                        else
                        {
                            continue;
                        }


                        //get ContestantTest by ContestantShiftID
                        CONTESTANTS_TESTS ct1;
                        ct1 = _ContestantTestService.GetByContestantShiftId(contestantShiftID);


                        //Add or update Answersheet_Speaking
                        if (ct1 != null)
                        {
                            if (ct1.ContestantTestID > 0)
                            {
                                ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(int.Parse(ct1.ContestantTestID.ToString()));
                                if (anw != null)
                                {
                                    ANSWERSHEET_SPEAKING aw = _AnswersheetSpeakingService.GetByAnwsersheetID(anw.AnswerSheetID);
                                    if (aw != null)
                                    {
                                        aw.SpeakingScore = score;
                                        aw.Status++;
                                        _AnswersheetSpeakingService.Update(aw);
                                    }
                                    else
                                    {
                                        aw = new ANSWERSHEET_SPEAKING
                                        {
                                            AnswerSheetID = anw.AnswerSheetID,
                                            SpeakingScore = score,
                                            Status = 1
                                        };
                                        _AnswersheetSpeakingService.Add(aw);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(string.Format("Thí sinh {0} bỏ thi.", row.Cells["cTestNumberIndex"].Value.ToString()), "Thông Báo");
                                    continue;
                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show("Có Lối Xảy Ra", "Lối");
                            Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_FATAL, string.Format("Contestant Test is null with ContestantShiftID = {0}", contestantShiftID));
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lối định dạng điểm thi hoặc ô để trống.", "Lối");
                        MessageBox.Show(ex.Message);
                        gvMain.ClearSelection();
                        gvMain.Rows[index].Selected = true;

                        Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Error when convert string to numver: {0}", ex.Message));
                        return;
                    }
                    index++;
                }
                _AnswersheetSpeakingService.Save();
                MessageBox.Show("Nhập điểm thành công.", "Thông báo");
            }
        }

        private void btnPrintTestSpeaking_Click(object sender, EventArgs e)
        {
          
            frmInput = new frmInput();
            frmInput.TopMost = true;
            frmInput.Show();
            frmInput.Sender += Frm_Sender;
        }
        private List<TEST> GetTestRandom(List<TEST> lstTest, int Sode)
        {
            Random rn = new Random();
            List<TEST> lstResult = new List<TEST>();
            for (int i = 1; i <= Sode; i++)
            {
                int rnindex = rn.Next(lstTest.Count);
                lstResult.Add(lstTest[rnindex]);
            }
            return lstResult;
        }
        private void Frm_Sender(int SoDeIn)
        {
            if (SoDeIn > 0)
            {  
                    frmInput.Close();
                    _DivisionShiftService = new DivisionShiftService();
                    _TestService = new TestService();
                 
                    //List<TEST_DETAILS> lsttd = new List<TEST_DETAILS>();
                    List<TEST> lstTest = new List<TEST>();
                    List<TEST> lstTestRandom = new List<TEST>();

                    lstTest = _TestService.GetAll().ToList();
                    if (SoDeIn > lstTest.Count)
                    {
                        MessageBox.Show("Số đề in vượt quá", "Thông báo!");

                    }
                    else
                    {
                        lstTestRandom = GetTestRandom(lstTest, SoDeIn);

                        lstSubSpeaking = new List<PrintSpeakingQuestion>();

                        lstSubSpeaking = (
                                  from ctt in lstTestRandom
                                  from td in db.TEST_DETAILS.Where(x => x.TestID == ctt.TestID).ToList()
                                  from qt in db.QUESTIONS.Where(x => x.QuestionID == td.QuestionID && x.Type == 5).ToList()
                                  from sqt in qt.SUBQUESTIONS.ToList()
                                  select new PrintSpeakingQuestion
                                  {
                                      TestID = ctt.TestID,
                                      SubContent = sqt.SubQuestionContent
                                  }
                          ).OrderBy(x => x.TestID).ToList();
                        if (SoDeIn > lstSubSpeaking.Count)
                        {
                            MessageBox.Show(string.Format("chỉ tạo được {0} đề!", lstSubSpeaking.Count), "Thông báo");
                        }
                        if (lstSubSpeaking.Count > 0)
                        {
                            Loading = new ucLoad();
                        Loading.TopMost = true;
                        // Form Loading 
                        s = new SendWorking(Loading.UpdateValue);
                            s(0);
                            //  Loading.UpdateValue(0);
                            Loading.Show();
                            CreateDocument(lstSubSpeaking);
                        }
                    }
            }
        }
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
        private void CreateDocument(List<PrintSpeakingQuestion> list)
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
                if (range.Find.Execute("CONTENT"))
                {
                    Word.Table objTab1;
                    int RowMax = list.Count;
                    objTab1 = objDoc.Tables.Add(range, RowMax, 1, ref objMiss, ref objMiss); //add table object in word document
                    objTab1.Range.ParagraphFormat.SpaceAfter = 2;

                    int iRow;
                    int cursor = 0;
                    int No = 0;

                    for (iRow = 1; iRow <= RowMax; iRow++)

                    {
                        float Per = ((float)iRow / (float)RowMax) * 90;
                        s((int)Per);
                        if (cursor < RowMax)
                        {
                            if ((cursor == 0) || (cursor > 0 && list[cursor].TestID != list[cursor - 1].TestID))
                            {
                                No = 0;
                                No++;
                                if (cursor > 0)
                                {
                                    objDoc.Words.Last.InsertBreak(Word.WdBreakType.wdPageBreak);
                                }
                                RichTextBox rtfa = new RichTextBox();
                                RichTextBox rtfReply = new RichTextBox();
                                rtfReply.Font = new System.Drawing.Font("Times New Roman", 13, FontStyle.Bold);

                                rtfReply.Text = "Mã đề: " + list[cursor].TestID.ToString();
                                rtfReply.AppendText("\n");
                                rtfReply.Text += string.Format("Question {0}", No++);
                                rtfa.Rtf = rtfReply.Rtf;
                                rtfa.AppendText("\n");
                                rtfa.Select(rtfa.TextLength, 0);
                                rtfa.SelectedRtf = list[cursor].SubContent;
                                Thread.Sleep(100);
                                rtfa.SelectAll();
                                rtfa.Copy();
                                try
                                {
                                    objTab1.Cell(iRow, 1).Range.PasteAndFormat(WdRecoveryType.wdSingleCellText);
                                }
                                catch
                                {
                                    Thread.Sleep(100);
                                    rtfa.SelectAll();
                                    rtfa.Copy();
                                    objTab1.Cell(iRow, 1).Range.PasteAndFormat(WdRecoveryType.wdSingleCellText);
                                }

                            }
                            else
                            {
                                RichTextBox rtfa = new RichTextBox();

                                RichTextBox rtfReply = new RichTextBox();
                                rtfReply.Font = new System.Drawing.Font("Times New Roman", 13, FontStyle.Bold);

                                rtfReply.Text = string.Format("Question {0}", No++);

                                rtfa.Rtf = rtfReply.Rtf;
                                rtfa.AppendText("\n");
                                rtfa.Select(rtfa.TextLength, 0);
                                rtfa.SelectedRtf = list[cursor].SubContent;

                                Thread.Sleep(100);
                                rtfa.SelectAll();
                                rtfa.Copy();
                                try
                                {
                                    objTab1.Cell(iRow, 1).Range.PasteAndFormat(WdRecoveryType.wdSingleCellText);
                                }
                                catch
                                {
                                    Thread.Sleep(100);
                                    rtfa.SelectAll();
                                    rtfa.Copy();
                                    objTab1.Cell(iRow, 1).Range.PasteAndFormat(WdRecoveryType.wdSingleCellText);
                                }
                            }

                            cursor++;


                            Thread.Sleep(100);
                            //objTab1.Rows[iRow].Range.Font.Bold = 1; //make first row of table BOLD
                            objTab1.Columns[1].Width = objApp.InchesToPoints(7);//increase first column width
                        }
                        else
                        {
                            break;
                        }
                    }
                }


                object szPath = pathFileTemp + "DeThiNoi.docx";
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

        private void GvMain_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (gvMain.CurrentRow != null)
                {

                    try
                    {
                        int contestantShiftID = int.Parse(gvMain.CurrentRow.Cells["cContestantShiftID"].Value.ToString());

                        string v = gvMain.CurrentRow.Cells["cScore"].Value.ToString();

                        float score = 0;
                        // score = int.Parse(v);
                        CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID);
                        if (ct != null)
                        {
                            _AnswersheetService = new AnswersheetService();
                            _AnswersheetSpeakingService = new AnswersheetSpeakingService();
                            ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);

                            if (anw != null)
                            {
                                if (v != "")

                                    if (v.IndexOf('.') >= 0) score = float.Parse(v);
                                    else score = int.Parse(v);

                                ANSWERSHEET_SPEAKING aw = _AnswersheetSpeakingService.GetByAnwsersheetID(anw.AnswerSheetID);
                                if (aw != null)
                                {
                                    aw.SpeakingScore = score;
                                    aw.Status++;
                                    _AnswersheetSpeakingService.Update(aw);
                                }
                                else
                                {
                                    aw = new ANSWERSHEET_SPEAKING
                                    {

                                        AnswerSheetID = anw.AnswerSheetID,
                                        SpeakingScore = score,
                                        Status = 1
                                    };

                                    _AnswersheetSpeakingService.Add(aw);
                                    _AnswersheetSpeakingService.Save();


                                }
                                _AnswersheetSpeakingService.Save();

                               // MessageBox.Show("Nhập điểm thành công.", "Thông báo");

                            }
                            else
                            {

                                MessageBox.Show(string.Format("Thí sinh {0} bỏ thi.", gvMain.CurrentRow.Cells["cTestNumberIndex"].Value.ToString()), "Thông Báo");

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
                        MessageBox.Show("Lối định dạng điểm thi ", "Lối");

                        gvMain.ClearSelection();

                        Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Error when convert string to numver: {0}", ex.Message));
                        return;
                    }
                }
            }
            catch
            {

            }
        }

        private void BtnPrintResult_Click(object sender, EventArgs e)
        {
            if (CurrentSubjectID != -1)
            {

                EXON.MONITOR.Report.frmResultSpeaking frm = new MONITOR.Report.frmResultSpeaking(CurrentSubjectID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Chọn môn");
            }
        }
    }
    public class ContestantSpeakingResultContest
    {
        public int STT { get; set; }
        public string ShiftName { get; set; }
        public string ContestantCode { get; set; }
        //public int TestID { get; set; }
        public int ContestantShiftID { get; set; }
        public string FullName { get; set; }
        public string DOB { get; set; }
        public string Unit { get; set; }

        public string Score { get; set; }
        public string PhongThi { get; set; }
        //  public string PrintResult { get; set; }
    }

}
