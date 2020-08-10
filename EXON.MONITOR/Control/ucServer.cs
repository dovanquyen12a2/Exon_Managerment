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
using EXON.MONITOR.Common;
using System.Collections;
using GeneralManagement.Supervisors;

using MetroFramework;
using System.Net;
using EXON.MONITOR.GUI;
using EXON.MONITOR.Report;
using EXON.Common;

namespace EXON.MONITOR.Control
{
    public partial class ucServer : UserControl
    {

        #region Service
        private IContestantShiftService _ContestantShiftService;
        private IContestantTestService _ContesttantTestService;
        private IContestantService _ContestantService;
        private IRoomDiagramService _RoomdiagramService;
        private ITestNumberService _TestNumberService;
        private IDivisionShiftService _DivisionShiftService;
        private IScheduleService _ScheduleService;
        private IBagOfTestService _BagOfTestService;
        private ITestService _TestService;
        private IShiftService _ShiftService;
        private IAnswersheetDetailService _AnswersheetDetailService;
        private IAnswerService _AnswerService;
        private IAnswersheetService _AnswersheetService;
        private IContestantPauseService _ContestantPauseService;
        private IDivisionShiftPauseService _DivisionShiftPauseService;
        #endregion

        #region Declare var

        private DIVISION_SHIFTS ds;
        private int countContestant = 0;
        private int _divisionShiftID;
        private int _roomTestID;
        private int _shiftID;
        private int _StatusDivisionShift; // trạng thái ca thi
        public delegate void WorkCompletedCallBack();
        private int TimeNowStartTest; // thời gian bắt đầu làm bài
        private int maxtime; // thời gian làm bài
        private int InPutTime = 0;
        private bool isDecrypt; // biến đã giải mã hay chưa
        public bool CheckDivisionTest = false; // phát đề 
        private int _ctID; // contestantID khi nhấp vào pic
        private int _cshID;
        Timer TimerLoadStatusContestant = new Timer(); // timer load status của thí sính 1s 
        Timer TimerWorked = new Timer();
        private int TimeWorker =0;
        private string Reason;
        #endregion
        #region Constructor
        public ucServer()
        {
            InitializeComponent();
        }
        public ucServer(DIVISION_SHIFTS _ds)
        {
            this.ds = _ds;
            this._divisionShiftID = ds.DivisionShiftID;
            this._roomTestID = ds.RoomTestID;
            this._shiftID = ds.ShiftID;
            this._StatusDivisionShift = ds.Status;
            InitializeComponent();
            InitializeService();
            metroContextMenu1.Enabled = true;
            menuContestantComplete.Enabled = true;
            menuDeleteSeat.Enabled = true;
            MenuItemChangeShift.Enabled = true;
            MenuItemPauseC.Enabled = true;
            MenuItemSigned.Enabled = true;
            MenuItemScore.Enabled = true;
            menuItemUpdateDoingTest.Enabled = true;
          

        }

        private void InitializeService()
        {
            _RoomdiagramService = new RoomDiagramService();
            _ContestantService = new ContestantService();
            _ContestantShiftService = new ContestantShiftService();
            _ShiftService = new ShiftService();
            _ScheduleService = new ScheduleService();
            _DivisionShiftService = new DivisionShiftService();
            _ContestantShiftService = new ContestantShiftService();
            _TestNumberService = new TestNumberService();
            _AnswersheetService = new AnswersheetService();
            _TestService = new TestService();
            _ContestantPauseService = new ContestantPauseService();
            _DivisionShiftPauseService = new DivisionShiftPauseService();
        }
        #endregion
        private void GenNumberIndex()
        {
            _DivisionShiftService = new DivisionShiftService();
            _RoomdiagramService = new RoomDiagramService();
            _TestNumberService = new TestNumberService();
            _ContestantShiftService = new ContestantShiftService();
            List<int> listContestantShiftID = _ContestantShiftService.ListContestantShiftID(_divisionShiftID);
            List<int> listCountContestantShiftID = new List<int>();
            for (int i = 1; i <= listContestantShiftID.Count; i++)
            {
                listCountContestantShiftID.Add(i);
            }

            Hashtable hasData = new Hashtable();
            //sinh so phach
            GenTestNumberindex(listContestantShiftID, listCountContestantShiftID, out hasData);
            foreach (DictionaryEntry entry in hasData)
            {
                TESTNUMBER tn = new TESTNUMBER();

                tn.ContestantShiftID = Convert.ToInt32(entry.Key);
                if ((int)entry.Value < 10)
                {
                    tn.TestNumberIndex = "00" + entry.Value.ToString();
                }
                else if ((int)entry.Value < 100)
                {
                    tn.TestNumberIndex = "0" + entry.Value.ToString();
                }
                else
                {
                    tn.TestNumberIndex = entry.Value.ToString();
                }
                _TestNumberService.Add(tn);
                _TestNumberService.Save();


            }
        }
        /// <summary>
        /// Xếp chỗ cho từng thí sinh
        /// </summary>
        private void ArrangeContestant()
        {
            int count_error = 0;
            try
            {

                _DivisionShiftService = new DivisionShiftService();
                _RoomdiagramService = new RoomDiagramService();
                _TestNumberService = new TestNumberService();
                txtMessageBox.Clear();
                _ContestantShiftService = new ContestantShiftService();
                List<int> listContestantShiftID = _ContestantShiftService.ListContestantShiftID(_divisionShiftID);
                List<int> listRoomDiaID = _RoomdiagramService.ListRoomDiaID(_roomTestID);
                List<int> listCountContestantShiftID = new List<int>();
                for (int i = 1; i <= listContestantShiftID.Count; i++)
                {
                    listCountContestantShiftID.Add(i);
                }
                if (listContestantShiftID.Count <= listRoomDiaID.Count)
                {
                    Hashtable hasData = new Hashtable();
                    //sinh so phach
                    GenTestNumberindex(listContestantShiftID, listCountContestantShiftID, out hasData);
                    foreach (DictionaryEntry entry in hasData)
                    {
                        TESTNUMBER tn = new TESTNUMBER();

                        tn.ContestantShiftID = Convert.ToInt32(entry.Key);
                        if ((int)entry.Value < 10)
                        {
                            tn.TestNumberIndex = "00" + entry.Value.ToString();
                        }
                        else if ((int)entry.Value < 100)
                        {
                            tn.TestNumberIndex = "0" + entry.Value.ToString();
                        }
                        else
                        {
                            tn.TestNumberIndex = entry.Value.ToString();
                        }
                        _TestNumberService.Add(tn);
                        _TestNumberService.Save();
                        // ArrangeContestant();
                        return;
                    }

                    // xep cho
                    ArrangeForContestant(listContestantShiftID, listRoomDiaID, out hasData);

                    #region tiến hành xếp chỗ

                    foreach (DictionaryEntry entry in hasData)
                    {
                        CONTESTANTS_SHIFTS contestantShift = new CONTESTANTS_SHIFTS();
                        contestantShift = _ContestantShiftService.GetById(Convert.ToInt32(entry.Key));
                        contestantShift.RoomDiagramID = Convert.ToInt32(entry.Value);
                        ROOMDIAGRAM roomDia = new ROOMDIAGRAM();
                        roomDia = _RoomdiagramService.GetById(Convert.ToInt32(entry.Value));
                        //????? contestantShift.ClientIP = roomDia.ClientIP;
                        _ContestantShiftService.Update(contestantShift);
                        _ContestantShiftService.Save();
                    }
                    if (count_error != 0)
                    {
                        txtMessageBox.Text = string.Format("Xếp chỗ bị sai {0}  vị trí. Xếp lại", (listContestantShiftID.Count - listRoomDiaID.Count));
                    }
                    else
                    {
                        // lsbTrace.Items.Add(string.Format(" Xếp chỗ thành công"));
                        //lsbTrace.SelectedIndex = lsbTrace.Items.Count - 1;

                        _DivisionShiftService.UpdateStatus(_divisionShiftID, (int)Constant.StatusDivisionShift.STATUS_GENTEST);
                    }

                    #endregion tiến hành xếp chỗ
                }
                else
                {
                    txtMessageBox.Text = string.Format("Không đủ chỗ để xếp. Thiếu {0} chỗ để xếp được, Bổ xung hoặc chuyển ca", count_error);
                    //  lsbTrace.SelectedIndex = lsbTrace.Items.Count - 1;
                }
            }
            catch(Exception ex)
            {
                count_error++;
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }
        }

        private void ArrangeForContestant(List<int> listContestantShiftID, List<int> listRoomDiaID, out Hashtable hasData)
        {
            List<int> lstTest = listRoomDiaID;
            Hashtable htbReturnData = new Hashtable();
            Random rnd = new Random();
            foreach (int contestantShiftID in listContestantShiftID.ToList())
            {
                int rndvalue = rnd.Next(listRoomDiaID.Count);
                htbReturnData.Add(contestantShiftID, listRoomDiaID[rndvalue]);
                listRoomDiaID.RemoveAt(rndvalue);
            }
            hasData = htbReturnData;
        }

        // Sinh số phách dành cho thi ngoại ngữ
        private void GenTestNumberindex(List<int> listContestantShiftID, List<int> listCountContestantShiftID, out Hashtable hasData)
        {
            Hashtable htbReturnData = new Hashtable();
            Random rnd = new Random();
            foreach (int contestantShiftID in listContestantShiftID.ToList())
            {
                int rndvalue = rnd.Next(listCountContestantShiftID.Count);
                htbReturnData.Add(contestantShiftID, listCountContestantShiftID[rndvalue]);
                listCountContestantShiftID.RemoveAt(rndvalue);
            }
            hasData = htbReturnData;
        }

        private void ucServer_Load(object sender, EventArgs e)
        {
            try
            {
                LoadComputer1(pnlUcComputer);
                if (ds.Status == (int)Constant.StatusDivisionShift.STATUS_INIT)
                {
                    GenerateTestForContestant();
                    GenNumberIndex();
                }

                TimerLoadStatusContestant.Interval = 1000;
                TimerLoadStatusContestant.Tick += new EventHandler(TimerLoadStatusContestant_Tick);
                TimerLoadStatusContestant.Start();
                EnableButton(ds.Status);

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.ToString(), "Lỗi! Đề nghị liên hệ với quản trị viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

                return;
            }
        }


        private void TimerLoadStatusContestant_Tick(object sender, EventArgs e)
        {
            foreach (ucComputer uc in pnlUcComputer.Controls)
            {
                uc.LoadInfoContestant();
                try
                {
                    if (uc.CheckedConfirmtoload)
                    {
                        countContestant++;
                        string text = countContestant.ToString();
                        SetText(text);
                        uc.CheckedConfirmtoload = false;
                    }
                }
                catch(Exception ex)
                {

                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));
                    //todo
                }


            }
        }
        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
          
            if (this.lblCount.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                lblCount.Text = text;

            }
        }
        // ham enable button chuc nang du vao trang thai ca thi
        private void EnableButton(int _status)
        {
            // check status tam dung, check xem ca thi den giai doan nao
            if (_status == (int)Constant.StatusDivisionShift.STATUS_PAUSE)
            {
                mbtnDecry.Enabled = false;
                mbtnDivsionTest.Enabled = false;
                mbtnStartTest.Enabled = false;
                mbtnCompleteDivisionShift.Enabled = false;
                mbtnDivisionShiftPause.Enabled = true;
                mbtnDivisionShiftPause.Text = Properties.Resources.MSG_GUI_010;
                metroContextMenu1.Enabled = false;
            }
            else
            {
                // enable cac nut trang thai
                if (_status == (int)Constant.StatusDivisionShift.STATUS_INIT)
                {
                    mbtnDecry.Enabled = true;
                    mbtnDivsionTest.Enabled = false;
                    mbtnStartTest.Enabled = false;
                }
                else if (_status == (int)Constant.StatusDivisionShift.STATUS_GENTEST)
                {

                    mbtnDecry.Enabled = true;
                    mbtnDivsionTest.Enabled = false;
                    mbtnStartTest.Enabled = false;
                    lblStatusDivisionShift.Text = Properties.Resources.MSG_GUI_009.ToString();
                }

                else if (_status == (int)Constant.StatusDivisionShift.STATUS_DECRYPT)
                {
                    mbtnDecry.Enabled = false;
                    isDecrypt = true;
                    mbtnDivsionTest.Enabled = true;
                    //mbtnDivsionTest.Enabled = true;
                    mbtnStartTest.Enabled = false;
                    lblStatusDivisionShift.Text = Properties.Resources.MSG_GUI_006.ToString();
                }
                else if (_status == (int)Constant.StatusDivisionShift.STATUS_DIVISIONTEST)
                {

                    isDecrypt = true;
                    mbtnDecry.Enabled = false;
                    mbtnStartTest.Enabled = true;
                    mbtnDivsionTest.Enabled = false;
                    lblStatusDivisionShift.Text = Properties.Resources.MSG_GUI_007.ToString();
                }
                else if (_status == (int)Constant.StatusDivisionShift.STATUS_STARTTEST)
                {
                    metroContextMenu1.Enabled = true;
                    mbtnDecry.Enabled = false;
                    isDecrypt = true;
                    mbtnDivsionTest.Enabled = false;
                    mbtnStartTest.Enabled = false;
                    mbtnCompleteDivisionShift.Enabled = true;
                    mbtnDivisionShiftPause.Enabled = true;
                    mbtnDivisionShiftPause.Text = Properties.Resources.MSG_GUI_011;
                    _ContestantShiftService = new ContestantShiftService();
                    int TimeStartForCT = 0;
                    int TimeNow = DatetimeConvert.ConvertDateTimeToUnix(DatetimeConvert.GetDateTimeServer());
                    int TimeOfTest = 0;
                    lblStatusDivisionShift.Text = Properties.Resources.MSG_GUI_008.ToString();
                    List<CONTESTANTS_SHIFTS> lstCS = new List<CONTESTANTS_SHIFTS>();
                    lstCS = _ContestantShiftService.GetAllByDivisionShiftID(_divisionShiftID).ToList();
                    foreach (CONTESTANTS_SHIFTS item in lstCS)
                    {
                        if (item.TimeStarted != null)
                        {
                            TimeStartForCT = item.TimeStarted ?? default(int);
                            TimeOfTest = item.SCHEDULE.TimeOfTest;
                            break;
                        }
                    }
                    lblTimeRemain.Visible = true;
                    TimeWorker = TimeNow - TimeStartForCT;
                    TimerWorked = new Timer();
                    TimerWorked.Interval = 1000;
                    TimerWorked.Tick += TimerWorked_Tick;
                    TimerWorked.Start();
                }

                else
                {
                    mbtnDecry.Enabled = false;
                    mbtnDivsionTest.Enabled = false;
                    mbtnStartTest.Enabled = false;
                    mbtnCompleteDivisionShift.Enabled = false;
                    mbtnDivisionShiftPause.Enabled = false;
                    metroContextMenu1.Enabled = false;
                    TimerLoadStatusContestant.Stop();
                    lblStatusDivisionShift.Text = "Trạng thái ca thi: " + Properties.Resources.MSG_GUI_005.ToString();
                }
            }

        }


        /// <summary>
        /// sinh đề cho từng thí sinh
        /// </summary>
        private void GenerateTestForContestant()
        {
            _ContestantShiftService = new ContestantShiftService();
            _ScheduleService = new ScheduleService();
            _DivisionShiftService = new DivisionShiftService();
            _ContesttantTestService = new ContestantTestService();
            _TestService = new TestService();
            _BagOfTestService = new BagOfTestService();
            try
            {
                List<SCHEDULE> listSchedule = (from obj in _ContestantShiftService.GetAllByDivisionShiftID(_divisionShiftID).Select(x => x.ScheduleID).Distinct()
                                               from schedule in _ScheduleService.GetAll().Where(x => x.ScheduleID == obj)
                                               select schedule
                                             ).ToList();

                if (listSchedule.Count > 0)
                {
                    foreach (SCHEDULE item in listSchedule)
                    {
                        if (item != null && item.SubjectID > 0)
                        {
                            List<int> listContestantShiftID = (from obj in _ContestantShiftService.GetAllByScheduleShift(item.ScheduleID, _divisionShiftID)
                                                               select obj.ContestantShiftID
                                                              ).ToList();
                            List<int> listTestIDForSubject = (from bagoftest in _BagOfTestService.GetAll().Where(x => x.DivisionShiftID == _divisionShiftID)
                                                              from Test in _TestService.GetAll().Where(x => x.BagOfTestID == bagoftest.BagOfTestID && x.SubjectID == item.SubjectID)
                                                              select Test.TestID
                                                              ).ToList();

                            if (listContestantShiftID.Count <= listTestIDForSubject.Count)
                            {
                                Hashtable hasData = new Hashtable();
                                GenerateTestForContestantOutHash(listContestantShiftID, listTestIDForSubject, out hasData);
                                foreach (DictionaryEntry entry in hasData)
                                {
                                    int contestantShiftID = Convert.ToInt32(entry.Key);
                                    CONTESTANTS_TESTS ct = _ContesttantTestService.GetByContestantShiftId(contestantShiftID);
                                    if (ct != null)
                                    {
                                        CONTESTANTS_TESTS contestantTest = _ContesttantTestService.GetAll().Where(x => x.ContestantShiftID == contestantShiftID).SingleOrDefault();
                                        contestantTest.TestID = Convert.ToInt32(entry.Value);
                                        _ContesttantTestService.Update(contestantTest);
                                        _ContesttantTestService.Save();

                                    }
                                    else
                                    {
                                        CONTESTANTS_TESTS contestantTest = new CONTESTANTS_TESTS();
                                        contestantTest.ContestantShiftID = contestantShiftID;
                                        contestantTest.TestID = Convert.ToInt32(entry.Value);
                                        contestantTest.Status = 4001;
                                        _ContesttantTestService.Add(contestantTest);
                                        _ContesttantTestService.Save();

                                    }
                                }
                            }
                        }
                    }
                    _DivisionShiftService.UpdateStatus(_divisionShiftID, (int)Constant.StatusDivisionShift.STATUS_GENTEST);

                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }
        }

        private void GenerateTestForContestantOutHash(List<int> listContestantShiftID, List<int> listTestIDForSubject, out Hashtable hasData)
        {
            Hashtable htbReturnData = new Hashtable();
            Random rnd = new Random();
            foreach (int contestantShiftID in listContestantShiftID)
            {
                int rndvalue = rnd.Next(listTestIDForSubject.Count);
                htbReturnData.Add(contestantShiftID, listTestIDForSubject[rndvalue]);
                listTestIDForSubject.RemoveAt(rndvalue);
            }
            hasData = htbReturnData;
        }


        #region UC Computer
        private void LoadComputer1(Panel pnl)
        {
            pnl.Controls.Clear();
            _DivisionShiftService = new DivisionShiftService();
            _RoomdiagramService = new RoomDiagramService();

            Point newP = new Point(5, 20);
            List<ROOMDIAGRAM> lstRoomdiagram = new List<ROOMDIAGRAM>();
            lstRoomdiagram = _RoomdiagramService.GetAll().Where(x => x.RoomTestID == _roomTestID).ToList();
            if (lstRoomdiagram.Count > 0)
            {
                for (int i = 0; i < lstRoomdiagram.Count; i++)
                {
                    ucComputer uccomputer = new ucComputer(lstRoomdiagram[i], _DivisionShiftService.GetByShiftAndRoomTest(_shiftID, _roomTestID).DivisionShiftID);
                    if (i % 6 == 0 && i != 0)
                    {
                        //newP = uccomputer.Location;
                        newP.X = 5;
                        newP.Y += uccomputer.Height + 20;
                    }
                    else if (i != 0)
                    {
                        newP.X += uccomputer.Width + 10;
                    }
                    uccomputer.Location = newP;
                    uccomputer.Name = lstRoomdiagram[i].ComputerName;
                    uccomputer.ImageClick += new EventHandler(UserControl_ButtonClick);
                    uccomputer.RightClick += new EventHandler(Uccomputer_RightClick);
                    pnl.Controls.Add(uccomputer);
           
                }
              
            }
        }
        protected void UserControl_ButtonClick(object sender, EventArgs e)
        {
            //handle the event
            try
            {
                ucComputer uc = (ucComputer)sender;
                txtMessageBox.Clear();
                CONTESTANTS_SHIFTS cs = new CONTESTANTS_SHIFTS();
                _ContestantShiftService = new ContestantShiftService();
                cs = _ContestantShiftService.GetById(uc.contestanshifttid);
                if (cs != null)
                {

                    #region hiển thị thông tin contestant

                    txtFullName.Text = cs.CONTESTANT.FullName;
                    txtContestantCode.Text = cs.CONTESTANT.ContestantCode;
                    txtIdentity.Text = cs.CONTESTANT.IdentityCardNumber;
                    txtDOB.Text = DatetimeConvert.ConvertUnixToDateTime((int)cs.CONTESTANT.DOB).ToShortDateString();
                    txtContestantID.Text = cs.CONTESTANT.ContestantID.ToString();

                    txtComputerName.Text = cs.ROOMDIAGRAM.ComputerName;
                    txtSubject.Text = cs.SCHEDULE.SUBJECT.SubjectName;

                    int contestantID = Convert.ToInt32(txtContestantID.Text);
                    #endregion hiển thị thông tin contestant
                }
            }
            catch (Exception ex)
            {
                txtMessageBox.Text = String.Format(ex.Message);
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }
        }

        private void Uccomputer_RightClick(object sender, EventArgs e)
        {

            try
            {
                ucComputer uc = (ucComputer)sender;
                txtMessageBox.Clear();
                _ContestantShiftService = new ContestantShiftService();
                CONTESTANTS_SHIFTS cs = new CONTESTANTS_SHIFTS();
                cs = _ContestantShiftService.GetById(uc.contestanshifttid);
                if (cs != null)
                {
                    if (cs.Status == Constant.STATUS_PAUSE)
                    {
                        MenuItemPauseC.Text = "Cho phép thí sính tiếp tục thi";
                    }
                    else
                    {
                        MenuItemPauseC.Text = "Tạm dừng thí sinh";
                    }
                    metroContextMenu1.Show(uc, new Point(45, 45));
                    _ctID = cs.ContestantID;
                    _cshID = cs.ContestantShiftID;
                    miResetContestant.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                txtMessageBox.Text = String.Format(ex.Message);
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }
        }
        #endregion


        #region Quy trinh tổ chức thi 

        // giải mã
        private void mbtnDecry_Click(object sender, EventArgs e)
        {
            _DivisionShiftService = new DivisionShiftService();

            DIVISION_SHIFTS DS = new DIVISION_SHIFTS();
            DS = _DivisionShiftService.GetById(_divisionShiftID);
            if (DS.Status == (int)Constant.StatusDivisionShift.STATUS_GENTEST)
            {
                frmInputKey frm = new frmInputKey(_divisionShiftID);
                frm.Show();
                frm.Sender += Frm_Sender;
            }
        }
        private void Frm_Sender(bool _IsDecrypt)
        {
            isDecrypt = _IsDecrypt;
            if (isDecrypt)
            {
                //if (CheckDivisionTest)
                //{
                mbtnDivsionTest.Enabled = true;
                // }
                mbtnDecry.Enabled = false;

                lblStatusDivisionShift.Text = Properties.Resources.MSG_GUI_006.ToString();

            }
        }

        public event EventHandler btnDivisionTestClick;
        // phát đề
        private void mbtnDivsionTest_Click(object sender, EventArgs e)
        {
            try
            {

                _DivisionShiftService = new DivisionShiftService();

                DIVISION_SHIFTS DS = new DIVISION_SHIFTS();
                DS = _DivisionShiftService.GetById(_divisionShiftID);
                if (DS.Status != (int)Constant.StatusDivisionShift.STATUS_STARTTEST && DS.Status == (int)Constant.StatusDivisionShift.STATUS_DECRYPT)
                {
                    mbtnDivsionTest.Enabled = false;
                    List<DIVISION_SHIFTS> lstDS = new List<DIVISION_SHIFTS>();
                    lstDS = _DivisionShiftService.GetByShift(_shiftID).ToList();

                    _DivisionShiftService.UpdateStatus(_divisionShiftID, (int)Constant.StatusDivisionShift.STATUS_DIVISIONTEST);

                    mbtnStartTest.Enabled = true;

                    if (btnDivisionTestClick != null)
                    {
                        btnDivisionTestClick(this, e);
                    }
                    lblStatusDivisionShift.Text = Properties.Resources.MSG_GUI_007.ToString();
                }
                else
                {
                    if (DS.Status != (int)Constant.StatusDivisionShift.STATUS_STARTTEST)
                        MetroMessageBox.Show(this, Properties.Resources.MSG_WAR_002, Properties.Resources.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning, 100);
                    else
                        MetroMessageBox.Show(this, Properties.Resources.MSG_WAR_003, Properties.Resources.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning, 100);
                    EnableButton(DS.Status);
                }
            }
            catch(Exception ex)
            {
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }

        }
        // bắt đầu làm bài
        private void mbtnStartTest_Click(object sender, EventArgs e)
        {
            try
            {
                _DivisionShiftService = new DivisionShiftService();
                DIVISION_SHIFTS DS = new DIVISION_SHIFTS();
                DS = _DivisionShiftService.GetById(_divisionShiftID);
                if (DS.Status != (int)Constant.StatusDivisionShift.STATUS_STARTTEST)
                {
                    DialogResult dr = MetroMessageBox.Show(this, "Thời gian làm bài của thí sinh được tính từ bây giờ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information, 100);
                    if (dr == DialogResult.Yes)
                    {
                        _ContestantShiftService = new ContestantShiftService();

                        _DivisionShiftService = new DivisionShiftService();
                        CONTESTANTS_SHIFTS CSH = new CONTESTANTS_SHIFTS();
                      
                        /// thêm 1s lúc bắt đầu làm bài
                        TimeNowStartTest = DatetimeConvert.ConvertDateTimeToUnix(DatetimeConvert.GetDateTimeServer()) + 1;
                        int TimeShiftStart = (int)DatetimeConvert.ConvertUnixToDateTime(TimeNowStartTest).TimeOfDay.TotalSeconds;
                        // lstDS = _DivisionShiftService.GetByShift(_shiftID).ToList();
                        CSH = _ContestantShiftService.GetFirstByDivisionShiftID(_divisionShiftID);
                        this.maxtime = CSH.SCHEDULE.TimeOfTest;
                        _ContestantShiftService.UpdateTimeStartForContestantShift(_divisionShiftID, TimeNowStartTest);
                        _DivisionShiftService.UpdateStatus(_divisionShiftID, (int)Constant.StatusDivisionShift.STATUS_STARTTEST);

                      
                        lblTimeRemain.Visible = true;
                        lblStatusDivisionShift.Text = Properties.Resources.MSG_GUI_008.ToString();
                        TimerWorked = new Timer();
                        TimerWorked.Interval = 1000;
                        TimerWorked.Tick += TimerWorked_Tick;
                        TimerWorked.Start();
                        mbtnStartTest.Enabled = false;
                        mbtnCompleteDivisionShift.Enabled = true;
                        mbtnDivisionShiftPause.Enabled = true;
                    }
                }
                else
                {
                    MetroMessageBox.Show(this, Properties.Resources.MSG_WAR_002, Properties.Resources.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning, 100);
                    EnableButton(DS.Status);
                }

            }
            catch (Exception ex)
            {
                txtMessageBox.Text = ex.ToString();
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }
        }

        private void TimerWorked_Tick(object sender, EventArgs e)
        {
            TimeWorker++;
            lblTimeRemain.Text = Controllers.Instance.HandleCountDown(TimeWorker);
        }

        // kết thúc ca thi
        private void mbtnCompleteDivisionShift_Click(object sender, EventArgs e)
        {
            _DivisionShiftService = new DivisionShiftService();
            DIVISION_SHIFTS DS = new DIVISION_SHIFTS();
            DS = _DivisionShiftService.GetById(_divisionShiftID);
            if (DS.Status != (int)Constant.StatusDivisionShift.STATUS_COMPLETE)
            {
                if (CheckContestantLoadTest())
                {
                    DialogResult dr = MetroMessageBox.Show(this, "Hoàn thành ca thi", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, 100);
                    if (dr == DialogResult.Yes)
                    {
                        List<DIVISION_SHIFTS> lstDS = new List<DIVISION_SHIFTS>();
                        _DivisionShiftService = new DivisionShiftService();


                        _DivisionShiftService.UpdateStatus(ds.DivisionShiftID, (int)Constant.StatusDivisionShift.STATUS_COMPLETE);
                        lblStatusDivisionShift.Text = "Trạng thái ca thi: " + Properties.Resources.MSG_GUI_005.ToString();

                        mbtnCompleteDivisionShift.Enabled = false;
                        TimerWorked.Stop();
                        EnableButton((int)Constant.StatusDivisionShift.STATUS_COMPLETE);

                    }
                }
                else
                {
                    MetroMessageBox.Show(this, Properties.Resources.MSG_WAR_006, Properties.Resources.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning, 100);
                }

            }
            else
            {
                MetroMessageBox.Show(this, Properties.Resources.MSG_WAR_004, Properties.Resources.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning, 100);
                EnableButton(DS.Status);

            }

        }
        // Tạm dừng phòng thi
        private void mbtnDivisionShiftPause_Click(object sender, EventArgs e)
        {
            try
            {
                if (mbtnDivisionShiftPause.Text == Properties.Resources.MSG_GUI_010)
                {
                    DialogResult dr = MetroMessageBox.Show(this, Properties.Resources.MSG_GUI_010 + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, 100);
                    if (dr == DialogResult.Yes)
                    {
                        _DivisionShiftService = new DivisionShiftService();

                        _ContestantShiftService = new ContestantShiftService();


                        DIVISION_SHIFTS DS = new DIVISION_SHIFTS();
                        List<CONTESTANTS_SHIFTS> lstCS = new List<CONTESTANTS_SHIFTS>();

                        CONTESTANTS_TESTS ct = new CONTESTANTS_TESTS();
                        DS = _DivisionShiftService.GetById(_divisionShiftID);

                        if (DS != null)
                        {
                            _ContestantShiftService = new ContestantShiftService();
                            _ContestantShiftService.UpdateStatusForContestantShift(_divisionShiftID, Constant.STATUS_DOING_BUT_INTERRUPT);
                            _DivisionShiftService.UpdateStatus(_divisionShiftID, (int)Constant.StatusDivisionShift.STATUS_STARTTEST);
                            EnableButton((int)Constant.StatusDivisionShift.STATUS_STARTTEST);
                            LoadComputer1(pnlUcComputer);
                        }
                        else
                        {
                            txtMessageBox.Text = "Lỗi!";
                        }



                    }
                }
                else
                {
                    DialogResult dr = MetroMessageBox.Show(this, Properties.Resources.MSG_GUI_011 + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, 100);
                    if (dr == DialogResult.Yes)
                    {
                        frmInputDateTime frm = new frmInputDateTime();
                        frm.Sender += Frm_Sender1;
                        frm.ShowDialog();
                        if (InPutTime > 0 && Reason != null)
                        {
                            _DivisionShiftService = new DivisionShiftService();
                            _ContesttantTestService = new ContestantTestService();
                            _ContestantShiftService = new ContestantShiftService();
                            _ContestantPauseService = new ContestantPauseService();

                            DIVISION_SHIFTS DS = new DIVISION_SHIFTS();
                            List<CONTESTANTS_SHIFTS> lstCS = new List<CONTESTANTS_SHIFTS>();

                            CONTESTANTS_TESTS ct = new CONTESTANTS_TESTS();
                            DS = _DivisionShiftService.GetById(_divisionShiftID);

                            if (DS != null)
                            {
                                _DivisionShiftService.UpdateStatus(_divisionShiftID, (int)Constant.StatusDivisionShift.STATUS_PAUSE);
                                lstCS = _ContestantShiftService.GetAllByDivisionShiftID(_divisionShiftID).ToList();
                                int timeClickPause = DatetimeConvert.ConvertDateTimeToUnix(DatetimeConvert.GetDateTimeServer());
                                _ContestantShiftService = new ContestantShiftService();
                                _ContestantShiftService.UpdateStatusForContestantShift(_divisionShiftID, Constant.STATUS_PAUSE);
                                foreach (CONTESTANTS_SHIFTS CS in lstCS)
                                {
                                    ct = new CONTESTANTS_TESTS();
                                    ct = _ContesttantTestService.GetByContestantShiftId(CS.ContestantShiftID);
                                    if (ct != null && CS.Status != Constant.STATUS_INITIALIZE)
                                    {
                                        CONTESTANTPAUSE cp = new CONTESTANTPAUSE();

                                        cp.ContestantTestID = ct.ContestantTestID;
                                        cp.ContestantRealPauseTime = InPutTime;
                                        cp.ContestantPauseClickTime = timeClickPause;
                                        cp.Note = Reason;
                                        _ContestantPauseService.Add(cp);
                                        _ContestantPauseService.Save();
                                    }

                                }
                                InPutTime = 0;
                                Reason = "";
                                EnableButton((int)Constant.StatusDivisionShift.STATUS_PAUSE);

                           
                                frmBienBanTamDungPhong frmBB = new frmBienBanTamDungPhong(DS.DivisionShiftID, InPutTime, Reason);

                                frmBB.ShowDialog();
                                LoadComputer1(pnlUcComputer);
                            }
                            else
                            {
                                txtMessageBox.Text = "Lỗi không lấy được dữ liệu";
                            }
                        }


                    }
                }

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "Có lỗi khi tạm dừng phòng thi" + ex.Message.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }
        }

        private void Frm_Sender1(int ThoiGianGianDoan, string note)
        {


            if (ThoiGianGianDoan > 0 && note != null)
            {
                InPutTime = ThoiGianGianDoan;
                Reason = note;
            }
        }

        // Check xem tat ca thi sinh đã ở trạng thái sẵn sàng thi chưa
        private bool CheckContestantLoadTest()
        {
            foreach (ucComputer uc in pnlUcComputer.Controls)
            {
                uc.LoadInfoContestant();
                if (uc.status != (int)Constant.STATUS_FINISHED && uc.status > 0)
                {
                    return false;
                }

            }
            return true;
        }

        //cập nhập thời gian cho ca thi
        private void UpdateShiftForKip(int TimeShiftStart, int TimeOfTest)
        {
            _ShiftService = new ShiftService();
            SHIFT sh = new SHIFT();
            List<SHIFT> lstShift = new List<SHIFT>();
            sh = _ShiftService.GetById(_shiftID);
            //thoi gian bat dau kip sang
            int BatDauKipSang = 25200;
            int KetThucKipSang = 43200;
            //thoi gian bat dau kip chieu
            int BatDauKipChieu = 46800;
            int KetThucKipChieu = 64800;
            int LastEndTime = 0;
            lstShift = _ShiftService.GetMultiByStartDate(sh.ShiftDate).OrderBy(x => x.StartTime).ToList();
            foreach (SHIFT shift in lstShift)
            {

                if (shift.EndTime <= KetThucKipSang && BatDauKipSang <= sh.StartTime && sh.StartTime <= KetThucKipSang)
                {
                    if (shift.StartTime == sh.StartTime)
                    {
                        _ShiftService = new ShiftService();
                        SHIFT _sh = new SHIFT();
                        _sh = _ShiftService.GetById(shift.ShiftID);
                        _sh.StartTime = TimeShiftStart;
                        _sh.EndTime = TimeShiftStart + TimeOfTest;
                        LastEndTime = _sh.EndTime;
                        _ShiftService.Update(_sh);
                        _ShiftService.Save();
                    }
                    else if (shift.StartTime > sh.StartTime)
                    {
                        _ShiftService = new ShiftService();
                        SHIFT _sh = new SHIFT();
                        _sh = _ShiftService.GetById(shift.ShiftID);
                        int subStartEnd = shift.EndTime - shift.StartTime;
                        //Cộng cho ca sau 5p thời gian bắt đầu
                        _sh.StartTime = LastEndTime + 300;
                        _sh.EndTime = _sh.StartTime + subStartEnd;
                        LastEndTime = _sh.EndTime;
                        _ShiftService.Update(_sh);
                        _ShiftService.Save();
                    }
                }
                else if (shift.StartTime >= BatDauKipChieu && BatDauKipChieu <= sh.StartTime && sh.StartTime <= KetThucKipChieu)
                {
                    if (shift.StartTime == sh.StartTime)
                    {
                        _ShiftService = new ShiftService();
                        SHIFT _sh = new SHIFT();
                        _sh = _ShiftService.GetById(shift.ShiftID);
                        _sh.StartTime = TimeShiftStart;
                        _sh.EndTime = TimeShiftStart + TimeOfTest;
                        LastEndTime = _sh.EndTime;
                        _ShiftService.Update(_sh);
                        _ShiftService.Save();
                    }
                    else if (shift.StartTime > sh.StartTime)
                    {
                        _ShiftService = new ShiftService();
                        SHIFT _sh = new SHIFT();
                        _sh = _ShiftService.GetById(shift.ShiftID);
                        int subStartEnd = shift.EndTime - shift.StartTime;
                        //Cộng cho ca sau 5p thời gian bắt đầu
                        _sh.StartTime = LastEndTime + 300;
                        _sh.EndTime = _sh.StartTime + subStartEnd;
                        LastEndTime = _sh.EndTime;
                        _ShiftService.Update(_sh);
                        _ShiftService.Save();
                    }
                }
            }

            frmServer frm = (frmServer)this.ParentForm;
            frm.UpdateLabelShiftTime();

        }


        #endregion

        #region Xử lý từng thí sinh
        /// reset trạng thái thí sinh
        private void MenuItemResetuc_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MetroMessageBox.Show(this, "Bạn có chắc chắn sửa lỗi đăng nhập cho thí sinh?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information, 100);
                if (dr == DialogResult.Yes)
                {
                    _ContestantShiftService = new ContestantShiftService();
                    CONTESTANTS_SHIFTS cs = new CONTESTANTS_SHIFTS();
                    cs = _ContestantShiftService.GetById(_cshID);

                    int TimeStartForCT = 0;
                    List<CONTESTANTS_SHIFTS> lstCS = new List<CONTESTANTS_SHIFTS>();
                    lstCS = _ContestantShiftService.GetAllByDivisionShiftID(_divisionShiftID).ToList();
                    foreach (CONTESTANTS_SHIFTS item in lstCS)
                    {
                        if (item.TimeStarted != null)
                        {
                            TimeStartForCT = item.TimeStarted ?? default(int);
                            break;
                        }
                    }
                    if (cs != null)
                    {
                        if (TimeStartForCT > 0)
                        {
                            cs.TimeStarted = TimeStartForCT;
                            cs.Status = 3004;
                        }
                        else
                        {
                            cs.Status = 4001;
                        }
                        _ContestantShiftService.Update(cs);
                        _ContestantShiftService.Save();
                        LoadComputer1(pnlUcComputer);
                    }
                    else
                    {
                        txtMessageBox.Text = "Không có thí sinh";
                    }

                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "Có lỗi trong quá trình đặt lại trạng thái thí sinh " + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void MenuItemChangeShift_Click(object sender, EventArgs e)
        {
            _ContestantShiftService = new ContestantShiftService();
            CONTESTANTS_SHIFTS contestantShift = _ContestantShiftService.GetById(_cshID);
            if (contestantShift != null)
            {
                frmThongBaoChuyen frmTB = new frmThongBaoChuyen();
                frmTB.Show();
                frmTB.sendWorking += new frmThongBaoChuyen.SendNotifi(FrmTB_sendWorking);
            }
        }
        private void FrmTB_sendWorking(string Reason)
        {
            try
            {
                _ContestantShiftService = new ContestantShiftService();
                CONTESTANTS_SHIFTS contestantShift = _ContestantShiftService.GetById(_cshID);
                if (contestantShift != null)
                {
                    contestantShift.Status = Constant.STATUS_CHANGE_SHIFT;
                    contestantShift.IsCheckFingerprint = null;
                    contestantShift.RoomDiagramID = null;
                    _ContestantShiftService.Update(contestantShift);
                    _ContestantShiftService.Save();

                    txtMessageBox.Clear();
                    txtMessageBox.Text = "Chuyển ca thi thành công!";
                    LoadComputer1(pnlUcComputer);
                    frmBienBanChuyenCaThi frmBB = new frmBienBanChuyenCaThi(txtContestantCode.Text, txtFullName.Text, Reason, txtIdentity.Text, _divisionShiftID);
                    frmBB.Show();


                }
            }
            catch
            {
                MetroMessageBox.Show(this, "Có lỗi trong quá trình chuyển chỗ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        // Violation


        private void btnChangeComputerName_Click(object sender, EventArgs e)
        {
            try
            {
                _RoomdiagramService = new RoomDiagramService();
                _ContestantShiftService = new ContestantShiftService();
                _ContestantService = new ContestantService();
                txtMessageBox.Clear();
                ROOMDIAGRAM roomDia = new ROOMDIAGRAM();
                CONTESTANT contestant = new CONTESTANT();
                if (txtContestantID.Text != "" && cmbComName.SelectedValue != null)
                {
                    DialogResult dr = MetroMessageBox.Show(this, string.Format("Bạn có chắn chắn chuyển chỗ ngồi từ {0} sang {1}?", txtComputerName.Text, cmbComName.Text), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        int contestantID;
                        contestantID = Convert.ToInt32(txtContestantID.Text);
                        contestant = _ContestantService.GetById(contestantID);
                        List<CONTESTANTS_SHIFTS> lstCSH = new List<CONTESTANTS_SHIFTS>();
                        lstCSH = _ContestantShiftService.GetAllByContestantID(contestantID).ToList();
                        roomDia = _RoomdiagramService.GetByComputername(txtComputerName.Text);
                        roomDia.Status = 4002;
                        _RoomdiagramService.Update(roomDia);
                        _RoomdiagramService.Save();
                        roomDia = _RoomdiagramService.GetById((int)cmbComName.SelectedValue);
                        foreach (CONTESTANTS_SHIFTS CSH in lstCSH)
                        {

                            CSH.RoomDiagramID = roomDia.RoomDiagramID;
                            _ContestantShiftService.Update(CSH);
                            _ContestantShiftService.Save();
                        }
                        frmBienBan frmbb = new frmBienBan(roomDia.ComputerName, cmbComName.Text, roomDia.ROOMTEST.RoomTestName, roomDia.ROOMTEST.RoomTestName, _divisionShiftID, contestant.FullName, contestant.ContestantCode);
                        frmbb.ShowDialog();
                        cmbComName.Text = null;
                        txtMessageBox.Text = "Chuyển chỗ thành công";
                        LoadComputer1(pnlUcComputer);
                    }

                }
                else
                {
                    txtMessageBox.Text = " Hết vị trí có thể chuyển tới. Bạn cần tích vào chuyển chỗ và chọn máy muốn đổi tới";
                    txtMessageBox.ForeColor = Color.Red;
                }
            }
            catch(Exception ex)
            {
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }
        }

        private void cmbComName_Click(object sender, EventArgs e)
        {
            LoadCmbComputerChange();
        }
        private void LoadCmbComputerChange()
        {
            cmbComName.Text = "";
            List<ROOMDIAGRAM> listRoomDia = _RoomdiagramService.GetListRoomByDs(_divisionShiftID, _roomTestID);
            if (listRoomDia.Count > 0)
            {
                cmbComName.DataSource = listRoomDia;
                cmbComName.DisplayMember = "ComputerName";
                cmbComName.ValueMember = "RoomDiagramID";

                cmbComName.SelectedIndex = -1;
            }
            else
            {
                cmbComName.DataSource = null;
                cmbComName.Text = "Không có máy nào có thể chuyển đến";
            }
        }

        private void mbtnRefreshUC_Click(object sender, EventArgs e)
        {
            LoadComputer1(pnlUcComputer);
        }

        private void MenuItemScore_Click(object sender, EventArgs e)
        {
            _ContesttantTestService = new ContestantTestService();
            _AnswersheetDetailService = new AnswersheetDetailService();
            _AnswerService = new AnswerService();
            ANSWERSHEET aws = _ContesttantTestService.GetByContestantShiftId(_cshID).ANSWERSHEETS.SingleOrDefault();
            List<ANSWERSHEET_DETAILS> lstaws = _AnswersheetDetailService.getAllByAnswerID(aws.AnswerSheetID).ToList();
            ANSWER aw = new ANSWER();
            int ansID;
            float SumSCore = 0;
            foreach (ANSWERSHEET_DETAILS item in lstaws)
            {
                ansID = item.ChoosenAnswer ?? default(int);
                aw = _AnswerService.GetbySubQuestionID(item.SubQuestionID, ansID);
                if (aw != null)
                {
                    if (aw.IsCorrect)
                    {
                        SumSCore += (float)aw.SUBQUESTION.Score;

                    }
                }
            }
            MetroMessageBox.Show(this, "Điểm của thí sinh là " + SumSCore, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void menuItemUpdateDoingTest_Click(object sender, EventArgs e)
        {

        }

        private void menuContestantDoing_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MetroMessageBox.Show(this, "Bạn có chắc chắn chuyển trạng thái đang thi cho thí sinh?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, 100);
                if (dr == DialogResult.Yes)
                {
                    _ContestantShiftService = new ContestantShiftService();
                    CONTESTANTS_SHIFTS cs = new CONTESTANTS_SHIFTS();
                    cs = _ContestantShiftService.GetById(_cshID);

                    if (cs != null)
                    {
                        cs.Status = 3003;
                        _ContestantShiftService.Update(cs);
                        _ContestantShiftService.Save();
                        LoadComputer1(pnlUcComputer);
                    }
                    else
                    {
                        txtMessageBox.Text = "Không có thí sinh";
                    }

                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "Có lỗi trong quá trình đặt lại trạng thái thí sinh " + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }
        }
        private void MenuItemPauseC_Click(object sender, EventArgs e)
        {

            try
            {
                CONTESTANTS_SHIFTS cs = new CONTESTANTS_SHIFTS();
                CONTESTANTS_TESTS ct = new CONTESTANTS_TESTS();
                _ContestantShiftService = new ContestantShiftService();
                _ContesttantTestService = new ContestantTestService();
                cs = _ContestantShiftService.GetById(_cshID);
                ct = _ContesttantTestService.GetByContestantShiftId(_cshID);
                if (cs != null && ct != null)
                {
                    if (cs.Status == Constant.STATUS_PAUSE)
                    {

                        DialogResult dr = MetroMessageBox.Show(this, "Cho phép thí sinh tiếp tục thi?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, 100);
                        if (dr == DialogResult.Yes)
                        {
                            cs.Status = Constant.STATUS_DOING_BUT_INTERRUPT;
                            _ContestantShiftService.Update(cs);
                            _ContestantShiftService.Save();

                        }

                    }
                    else
                    {
                        DialogResult dr = MetroMessageBox.Show(this, "Bạn có chắc chắn tạm ngừng thí sinh?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, 100);
                        if (dr == DialogResult.Yes)
                        {
                            frmInputDateTime frm = new frmInputDateTime();
                            frm.Sender += Frm_Sender1;
                            frm.ShowDialog();

                            if (InPutTime > 0 && Reason != null)
                            {
                               
                                _ContestantPauseService = new ContestantPauseService();
                                cs.Status = Constant.STATUS_PAUSE;
                                _ContestantShiftService.Update(cs);
                                _ContestantShiftService.Save();
                                int timeClickPause = DatetimeConvert.ConvertDateTimeToUnix(DatetimeConvert.GetDateTimeServer());
                                CONTESTANTPAUSE cp = new CONTESTANTPAUSE();
                                cp.ContestantTestID = ct.ContestantTestID;
                                cp.ContestantPauseClickTime = timeClickPause;
                                cp.ContestantRealPauseTime = InPutTime;
                                cp.Note = Reason;
                                _ContestantPauseService.Add(cp);
                                _ContestantPauseService.Save();
                                frmBienBanContestantPause frmBienBan = new frmBienBanContestantPause(cs.ContestantShiftID, InPutTime, Reason);
                                frmBienBan.ShowDialog();
                                InPutTime = 0;
                                Reason = "";
                            }

                        }

                    }



                    LoadComputer1(pnlUcComputer);

                }
                else
                {
                    txtMessageBox.Text = "Không có thí sinh";
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "Có lỗi khi tạm dừng thí sinh " + ex.Message.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }
        }



        private void menuContestantComplete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MetroMessageBox.Show(this, "Bạn có chắc chắn chuyển trạng thái hoàn thành cho thí sinh?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, 100);
                if (dr == DialogResult.Yes)
                {

                    int ansID;
                    float SumSCore = 0;
                    _ContesttantTestService = new ContestantTestService();
                    _ContestantShiftService = new ContestantShiftService();
                    _AnswersheetDetailService = new AnswersheetDetailService();
                    _AnswerService = new AnswerService();
                    _AnswersheetService = new AnswersheetService();
                    
                    CONTESTANTS_SHIFTS cs = new CONTESTANTS_SHIFTS();
                    ANSWERSHEET aws = _ContesttantTestService.GetByContestantShiftId(_cshID).ANSWERSHEETS.SingleOrDefault();
                    if (aws != null)
                    {
                        List<ANSWERSHEET_DETAILS> lstaws = _AnswersheetDetailService.getAllByAnswerID(aws.AnswerSheetID).ToList();
                        ANSWER aw = new ANSWER();
                        cs = _ContestantShiftService.GetById(_cshID);

                        if (cs != null)
                        {
                            cs.Status = 3005;
                            _ContestantShiftService.Update(cs);
                            _ContestantShiftService.Save();

                        }
                        else
                        {
                            txtMessageBox.Text = "Không có thí sinh";
                        }


                        foreach (ANSWERSHEET_DETAILS item in lstaws)
                        {
                            ansID = item.ChoosenAnswer ?? default(int);
                            aw = _AnswerService.GetbySubQuestionID(item.SubQuestionID, ansID);
                            if (aw != null)
                            {
                                if (aw.IsCorrect)
                                {
                                    SumSCore += (float)Math.Round(aw.SUBQUESTION.Score.Value, 2);
                                }
                            }
                        }

                        // cập nhập điểm cho thí sinh chưa hoàn thành nhưng có bài làm 
                        aws = _AnswersheetService.GetById(aws.AnswerSheetID);
                        aws.TestScores = Math.Round(SumSCore, 2);
                        _AnswersheetService.Update(aws);
                        _AnswersheetService.Save();
                        MetroMessageBox.Show(this, "Cập nhập thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadComputer1(pnlUcComputer);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Thí sinh chưa đăng nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "Có lỗi trong quá trình đặt lại trạng thái thí sinh " + ex.Message.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }
        }

        private void menuDeleteSeat_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MetroMessageBox.Show(this, "Bạn có chắc chắn chuyển trạng thái hoàn thành cho thí sinh?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, 100);
                if (dr == DialogResult.Yes)
                {
                    _ContestantShiftService = new ContestantShiftService();
                    List<CONTESTANTS_SHIFTS> lstcs = new List<CONTESTANTS_SHIFTS>();
                    lstcs = _ContestantShiftService.GetAllByContestantID(_ctID).ToList();
                    foreach (CONTESTANTS_SHIFTS cs in lstcs)
                    {
                        cs.RoomDiagramID = null;
                        _ContestantShiftService.Update(cs);
                        _ContestantShiftService.Save();

                    }
                    LoadComputer1(pnlUcComputer);
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "Có lỗi trong quá trình đặt lại trạng thái thí sinh " + ex.Message.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }
        }

        private void MenuItemSigned_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MetroMessageBox.Show(this, "Bạn có chắc chắn xác nhận thí sinh đã ký nộp bài?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, 100);
                if (dr == DialogResult.Yes)
                {
                    _ContestantShiftService = new ContestantShiftService();
                    CONTESTANTS_SHIFTS cs = new CONTESTANTS_SHIFTS();
                    cs = _ContestantShiftService.GetById(_cshID);

                    if (cs != null)
                    {
                        cs.Status = 5002;
                        _ContestantShiftService.Update(cs);
                        _ContestantShiftService.Save();
                        LoadComputer1(pnlUcComputer);
                        MenuItemSigned.Enabled = false;

                    }
                    else
                    {
                        txtMessageBox.Text = "Không có thí sinh";
                    }

                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "Có lỗi trong quá trình đặt lại trạng thái thí sinh " + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MetroMessageBox.Show(this, "Bạn có chắc chắn xác nhận thí sinh ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, 100);
                if (dr == DialogResult.Yes)
                {
                    _ContestantShiftService = new ContestantShiftService();
                    _ContesttantTestService = new ContestantTestService();
                    _BagOfTestService = new BagOfTestService();
                    _TestService = new TestService();
                    CONTESTANTS_SHIFTS cs = new CONTESTANTS_SHIFTS();
                    cs = _ContestantShiftService.GetById(_cshID);

                    if (cs != null)
                    {
                        Random random = new Random();
                        List<int> listTestIDForSubject = (from bagoftest in _BagOfTestService.GetAll().Where(x => x.DivisionShiftID == _divisionShiftID)
                                                          from Test in _TestService.GetAll().Where(x => x.BagOfTestID == bagoftest.BagOfTestID && x.SubjectID == cs.SCHEDULE.SubjectID)
                                                          select Test.TestID
                                                         ).ToList();
                        CONTESTANTS_TESTS ct = new CONTESTANTS_TESTS();
                        int index = random.Next(listTestIDForSubject.Count);
                        ct = _ContesttantTestService.GetByContestantShiftId(cs.ContestantShiftID);
                        if(ct!=null)
                        {
                            ct.TestID = listTestIDForSubject[index];
                            _ContesttantTestService.Update(ct);
                            _ContesttantTestService.Save();
                        }
                        else
                        {
                            ct = new CONTESTANTS_TESTS();
                            ct.ContestantShiftID = cs.ContestantShiftID;
                            ct.TestID = listTestIDForSubject[index];
                            ct.Status = 4001;
                            _ContesttantTestService.Add(ct);
                            _ContesttantTestService.Save();
                        }
                        MetroMessageBox.Show(this, "Đổi đề thành công","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        txtMessageBox.Text = "Không có thí sinh";
                    }

                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "Có lỗi trong quá trình đặt lại trạng thái thí sinh " + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MetroMessageBox.Show(this, "Bạn có chắc chắn chuyển trạng thái hoàn thành cho thí sinh?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, 100);
                if (dr == DialogResult.Yes)
                {

                    int ansID;
                  
                    _ContesttantTestService = new ContestantTestService();
                    _ContestantShiftService = new ContestantShiftService();
                    _AnswersheetDetailService = new AnswersheetDetailService();
                    _AnswerService = new AnswerService();
                    _AnswersheetService = new AnswersheetService();
                    List<CONTESTANTS_SHIFTS> lst = new List<CONTESTANTS_SHIFTS>();
                    lst = _ContestantShiftService.GetAll().Where(x=>x.Status==3005).ToList();
                    // CONTESTANTS_SHIFTS cs = new CONTESTANTS_SHIFTS();
                    foreach (CONTESTANTS_SHIFTS cs in lst)
                    {
                        _AnswersheetService = new AnswersheetService();
                        _AnswersheetDetailService = new AnswersheetDetailService();
                        float SumSCore = 0;
                        ANSWERSHEET aws = _ContesttantTestService.GetByContestantShiftId(cs.ContestantShiftID).ANSWERSHEETS.SingleOrDefault();

                        if (aws != null)
                        {
                            List<ANSWERSHEET_DETAILS> lstaws = _AnswersheetDetailService.getAllByAnswerID(aws.AnswerSheetID).ToList();
                            ANSWER aw = new ANSWER();
                      

                            foreach (ANSWERSHEET_DETAILS item in lstaws)
                            {
                                ansID = item.ChoosenAnswer ?? default(int);
                                aw = _AnswerService.GetbySubQuestionID(item.SubQuestionID, ansID);
                                if (aw != null)
                                {
                                    if (aw.IsCorrect)
                                    {
                                        SumSCore += (float)Math.Round(aw.SUBQUESTION.Score.Value,2);
                                    }
                                }
                            }

                     
                            aws = _AnswersheetService.GetById(aws.AnswerSheetID);
                            aws.TestScores = Math.Round(SumSCore,2);
                            _AnswersheetService.Update(aws);
                            _AnswersheetService.Save();
                             
                        }
                    }
                    MetroMessageBox.Show(this, "ok", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
               

                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "Có lỗi trong quá trình đặt lại trạng thái thí sinh " + ex.Message.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }
        }
    }
}
