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

using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using EXON.GradedEssay.Report;

namespace EXON.GradedEssay.Control
{
    public partial class ucSpeaking : UserControl
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
        //private int CurrentSubjectID
        //{
        //    get
        //    {
        //        try
        //        {
        //            return int.Parse(cbRoomTest.SelectedValue.ToString());
        //        }
        //        catch { return -1; }
        //    }
        //}
        private int _ContestID { get; set; }
        private int _LocationID { get; set; }
        public ucSpeaking(int contestID,int LocationID)
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
                _ShiftService = new ShiftService();
                _StaffService = new StaffService();
                _ScheduleService = new ScheduleService();
                _SubjectService = new SubjectService();
                _ContestantShiftService = new ContestantShiftService();
                _DivisionShiftService = new DivisionShiftService();
                cbShift.DataSource = (from ds in _DivisionShiftService.GetAll().Where(x => x.ROOMTEST.LocationID == _LocationID)
                                      select new {
                                          ShiftName=ds.SHIFT.ShiftName,
                                          ShiftID= ds.ShiftID
                                      } 
                    ).ToList();
                cbShift.DisplayMember = "ShiftName";
                cbShift.ValueMember = "ShiftID";
             
             
             
                // commbox roomtest
                cbRoomTest.DataSource = (from r in _RoomTestService.GetAllByLocation(_LocationID)        
                                         select r).ToList();
                cbRoomTest.DisplayMember = "RoomTestName";

                cbRoomTest.ValueMember = "RoomTestID";



                DIVISION_SHIFTS CurrentDs = new DIVISION_SHIFTS();
                CurrentDs = _DivisionShiftService.GetByShiftAndRoomTest(CurrentShiftID, CurrentRoomTestID);
                cbSubject.DataSource = (from r in _ScheduleService.GetAll()
                                        from ds in _ContestantShiftService.GetAllByDivisionShiftID(CurrentDs.DivisionShiftID)
                                        from sj in _SubjectService.GetAll()
                                        where r.ScheduleID == ds.ScheduleID && r.SubjectID == sj.SubjectID
                                        select sj).Distinct().ToList();
                cbSubject.DisplayMember = "SubjectName";
                cbSubject.ValueMember = "SubjectID";
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
                int index = 1;
                List<ContestantSpeakingResult> listContestant = (from cs in _ContestantShiftService.GetAllByDivisionShiftID(CurrentDs.DivisionShiftID)
                                                                 from c in _ContestantService.GetAll()
                                                                 where cs.ContestantID == c.ContestantID && cs.SCHEDULE.SubjectID == CurrentSubjectID                                                        
                                                                 select new ContestantSpeakingResult
                                                                 {
                                                                     STT = index++,

                                                                     ContestantCode = c.ContestantCode,
                                                                     FullName = c.FullName,
                                                                     DOB = DateTimeHelpers.ConvertUnixToDateTime(c.DOB.Value)
                                                                       .ToShortDateString(),
                                                                     Unit = c.Unit,
                                                                     Score = GetScore(cs.ContestantShiftID),
                                                                     ContestantShiftID = cs.ContestantShiftID,

                                                                 }).ToList();
                gvMain.DataSource = listContestant;
            }
            catch
            {

            }
           
        }
        DIVISION_SHIFTS ds = new DIVISION_SHIFTS();
        private void cbShift_SelectedValueChanged(object sender, EventArgs e)
        {
            _ShiftService = new ShiftService();
            _StaffService = new StaffService();
            _ScheduleService = new ScheduleService();
            _SubjectService = new SubjectService();
            cbRoomTest.DataSource = null;
            cbRoomTest.Text = "";
            // commbox roomtest
            cbRoomTest.DataSource = (
                                     from ds in _DivisionShiftService.GetAll().Where(x=>x.ShiftID==CurrentShiftID && x.ROOMTEST.LocationID==_LocationID)
                                     
                                     select new
                                     {
                                         RoomTestName = ds.ROOMTEST.RoomTestName,
                                         RoomTestID = ds.RoomTestID
                                     } 
                                     ).ToList();
            cbRoomTest.DisplayMember = "RoomTestName";
            cbRoomTest.ValueMember = "RoomTestID";
            if (CurrentRoomTestID == -1)
            {
                gvMain.DataSource = null;
            }

        }
    
        private string GetScore(int? contestantShiftID)
        {
            if (contestantShiftID.HasValue)
            {
                _ContestantTestService = new ContestantTestService();
                CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID.Value);
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

        private void cbRoomTest_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CurrentShiftID != -1 && CurrentRoomTestID != -1)
            {
                _ShiftService = new ShiftService();
                _StaffService = new StaffService();
                _ScheduleService = new ScheduleService();
                _SubjectService = new SubjectService();
                
                DIVISION_SHIFTS CurrentDs = new DIVISION_SHIFTS();
                CurrentDs = _DivisionShiftService.GetByShiftAndRoomTest(CurrentShiftID, CurrentRoomTestID);
                cbSubject.DataSource = (from r in _ScheduleService.GetAll()
                                        from ds in _ContestantShiftService.GetAllByDivisionShiftID(CurrentDs.DivisionShiftID)
                                        from sj in _SubjectService.GetAll()
                                        where r.ScheduleID == ds.ScheduleID && r.SubjectID == sj.SubjectID
                                        select sj).Distinct().ToList();
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
                int index = 1;
                DIVISION_SHIFTS CurrentDs = new DIVISION_SHIFTS();
                CurrentDs = _DivisionShiftService.GetByShiftAndRoomTest(CurrentShiftID, CurrentRoomTestID);
                List<ContestantSpeakingResult> listContestant = (from cs in _ContestantShiftService.GetAllByDivisionShiftID(CurrentDs.DivisionShiftID)
                                                                 from c in _ContestantService.GetAll().Where(x => x.ContestantID == cs.ContestantID)

                                                                 where cs.SCHEDULE.SubjectID == CurrentSubjectID
                                                                   && cs.DIVISION_SHIFTS.Status == (int)Common.StatusDivisionShift.STATUS_COMPLETE

                                                                 select new ContestantSpeakingResult
                                                                 {
                                                                     STT = index++,

                                                                     ContestantCode = c.ContestantCode,
                                                                     FullName = c.FullName,
                                                                     DOB = DateTimeHelpers.ConvertUnixToDateTime(c.DOB.Value)
                                                                       .ToShortDateString(),
                                                                     Unit = c.Unit,
                                                                     Score = GetScore(cs.ContestantShiftID),
                                                                     ContestantShiftID = cs.ContestantShiftID,

                                                                 }).ToList();
                gvMain.DataSource = listContestant;
            }

        }
        private void ucSpeaking_Load(object sender, EventArgs e)
        {

        }

        private void gvMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (gvMain.DataSource == null || (columnClick != "cScore"))
            //    return;
            //try
            //{
            //    string v = gvMain.Rows[e.RowIndex].Cells[columnClick].Value.ToString();
            //    if (v.IndexOf('.') >= 0) float.Parse(v);
            //    else int.Parse(v);
            //}
            //catch
            //{
            //    MessageBox.Show("Chỉ Nhấp Số. Nếu là số thập phân sử dụng '.' thay vì ','.", "Sai Định Dạng");
            //    gvMain.CellValueChanged -= gvMain_CellValueChanged;
            //    gvMain.Rows[e.RowIndex].Cells[columnClick].Value = string.Empty;
            //    gvMain.CellValueChanged += gvMain_CellValueChanged;
            //}
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
                                    MessageBox.Show(string.Format("Thí sinh {0} không có bài làm.", row.Cells["cTestNumberIndex"].Value.ToString()), "Thông Báo");
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

        private void gvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            columnClick = gvMain.Columns[e.ColumnIndex].Name;
        }
        //public void addContestantTestList()
        //{
        //    if (CurrentShiftID > 0 && CurrentSubjectID > 0)
        //    {
        //        DIVISION_SHIFTS ds = _DivisionShiftService.GetById(CurrentShiftID);
        //        sc = new SCHEDULE();
        //        sc = _ScheduleService.GetByContestAndSubject(CurrentContestID, CurrentSubjectID);

        //        //xem đã có contestantTest chưa?
        //        List<CONTESTANTS_TESTS> ctList = _ContestantTestService.GetAll().ToList();


        //        if (ctList.Count > 0)
        //        {
        //            //Lấy túi đề thi theo ca thi
        //            BAGOFTEST bag = _BagOfTestService.GetByDIvisionShiftID(ds.DivisionShiftID);

        //            if (bag != null)
        //            {
        //                //Lay Tests theo bagOfTest
        //                List<TEST> testList = _TestService.GetByBagOfTestID(bag.BagOfTestID).ToList();
        //                if (testList.Count > 0)
        //                {
        //                    //them vao contestantTest
        //                    var listContestantTest = (from cs in _ContestantShiftService.GetAllByScheduleShift(sc.ScheduleID, ds.DivisionShiftID)
        //                                              from c in _ContestantService.GetAll()
        //                                                  //from t in testList
        //                                              where cs.ContestantID == c.ContestantID
        //                                              select new ContestantTestResult
        //                                              {
        //                                                  ContestantShiftID = cs.ContestantShiftID,
        //                                                  Status = 4002
        //                                              }).ToList();


        //                    foreach (ContestantTestResult c in listContestantTest)
        //                    {

        //                        CONTESTANTS_TESTS ct = new CONTESTANTS_TESTS();
        //                        ct.ContestantShiftID = c.ContestantShiftID;
        //                        ct.TestID = testList[0].TestID;
        //                        ct.Status = 4002;
        //                        _ContestantTestService.Add(ct);
        //                    }
        //                    _ContestantTestService.Save();
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Không có đề thi trong túi đề thi này!");
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Túi đề thi trống!");
        //                return;
        //            }


        //        }
        //    }

        //}

        private void gvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            int id;
            try
            {
                id = (int)gvMain.CurrentRow.Cells["cContestantShiftID"].Value;
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                 e.RowIndex >= 0)
                {

                    ReportRoomDiagrams.FrmSpeakingScore frm = new ReportRoomDiagrams.FrmSpeakingScore(id);
                    if (frm != null)
                        frm.ShowDialog();

                }
            }
            catch
            {

            }
        }

        private void btnPrintResult_Click(object sender, EventArgs e)
        {
            if (CurrentSubjectID != -1)
            {
                DIVISION_SHIFTS CurrentDs = new DIVISION_SHIFTS();
                _DivisionShiftService = new DivisionShiftService();
                CurrentDs = _DivisionShiftService.GetByShiftAndRoomTest(CurrentShiftID, CurrentRoomTestID);
                EXON.MONITOR.Report.frmResultSpeaking frm = new MONITOR.Report.frmResultSpeaking(CurrentDs.DivisionShiftID, CurrentSubjectID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Chọn môn");
            }
        }

        private void btnExportScoreSpeaking_Click(object sender, EventArgs e)
        {
            DIVISION_SHIFTS CurrentDs = new DIVISION_SHIFTS();
            _DivisionShiftService = new DivisionShiftService();
            _StaffService = new StaffService();
            STAFF stff1 = new STAFF();
            stff1 = _StaffService.GetById(CurrentTeacherName1);
            STAFF stff2 = new STAFF();
            stff2 = _StaffService.GetById(CurrentTeacherName2);

            CurrentDs = _DivisionShiftService.GetByShiftAndRoomTest(CurrentShiftID, CurrentRoomTestID);
            frmReportPhieuDiemThiNoi frm = new frmReportPhieuDiemThiNoi(CurrentDs.DivisionShiftID, stff1.FullName, stff2.FullName,CurrentSubjectID);
            frm.ShowDialog();
        }
        public bool TypePrint = false;
        private void btnPrintRandom_Click(object sender, EventArgs e)
        {

            TypePrint = false;
            frmInput = new frmInput();
            frmInput.TopMost = true;
            frmInput.Show();
            frmInput.Sender += Frm_Sender;
        }
        private void btnPrintTestSpeaking_Click(object sender, EventArgs e)
        {
            try
            {
                TypePrint = true;
                frmInput = new frmInput();
                frmInput.TopMost = true;
                frmInput.Show();
                frmInput.Sender += Frm_Sender;
            }
            catch

            {
                MessageBox.Show("Có lỗi!");

            }
        }

        private void Frm_Sender(int SoDeIn)
        {
            try
            {
                if (SoDeIn > 0 && TypePrint)
                {
                    frmInput.Close();
                    _DivisionShiftService = new DivisionShiftService();
                    db = new MTAQuizDbContext();
                    ds = _DivisionShiftService.GetByShiftID(CurrentShiftID);

                    lstSubSpeaking = new List<PrintSpeakingQuestion>();

                    lstSubSpeaking = (
                              from dvs in db.DIVISION_SHIFTS.Where(x => x.DivisionShiftID == ds.DivisionShiftID).ToList()
                              from cts in db.CONTESTANTS_SHIFTS.Where(x => x.DivisionShiftID == dvs.DivisionShiftID).Take(SoDeIn).ToList()
                              from ctt in db.CONTESTANTS_TESTS.Where(x => x.ContestantShiftID == cts.ContestantShiftID).ToList()
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
                else if (SoDeIn > 0 && !TypePrint)
                {
                    frmInput.Close();

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
            catch
            {
                MessageBox.Show("Có lỗi!");
            }

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
            catch
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

        private void BtnXacNhanGiaoVien_Click(object sender, EventArgs e)
        {
            DIVISION_SHIFTS CurrentDs = new DIVISION_SHIFTS();
            _DivisionShiftService = new DivisionShiftService();
            _StaffService = new StaffService();
            STAFF stff1 = new STAFF();
            stff1 = _StaffService.GetById(CurrentTeacherName1);
            STAFF stff2 = new STAFF();
            stff2 = _StaffService.GetById(CurrentTeacherName2);

            CurrentDs = _DivisionShiftService.GetByShiftAndRoomTest(CurrentShiftID, CurrentRoomTestID);
            frmReportPhieuDiemThiNoiXacNhan frm = new frmReportPhieuDiemThiNoiXacNhan(CurrentDs.DivisionShiftID, stff1.FullName, stff2.FullName, CurrentSubjectID);
            frm.ShowDialog();
        }
    }
    public class ContestantSpeakingResult
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
        //  public string PrintResult { get; set; }
    }

    public class PrintSpeakingQuestion
    {
        public int TestID { get; set; }
        public string SubContent { get; set; }
    }
    public class ContestantTestResult
    {
        public int ContestantShiftID { get; set; }

        public int TestID { get; set; }

        public int Status;

    }
}

