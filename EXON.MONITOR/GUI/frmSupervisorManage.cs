
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using MetroFramework.Forms;
using EXON.SubModel.Models;
using EXON.MONITOR.Common;
using EXON.SubData.Services;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Threading;
using MetroFramework;
using EXON.Common;

namespace EXON.MONITOR.GUI
{
    public partial class frmSupervisorManage : Form
    {
        private delegate void SendInfoToFrmSupervisor(DivisionShift ds);

        public bool checkTime = false;
      private   bool IsStop = true;
        private const int DIF_TIME = 1800; // đặt thời gian hiển thị các ca thi có starttime trong khoảng 45' mới cho hiện ra
        private const int DIF_TIME_OPEN = 1800; // chỉ có thể truy cập ca thi trong khoảng  30' trước khi ca thi bắt đầu
        private const int WIDTH = 300; // độ rộng của button
        private const int HEIGHT = 300; // chiều cao của button
        private int supervisorID;
        private int shiftID;
        private SHIFT shift = new SHIFT();
        private List<SHIFT> Shiftinfor = new List<SHIFT>();
        private Timer t = new Timer();
        private StaffService _StaffService;
        private ShiftService _ShiftService;
        private DivisionShiftService _DivisionShiftService;
        private ExaminationcouncilStaffService _ExaminationcouncilStaffService;
        private IRoomDiagramService _RoomDiagramService;
        private IContestantTestService _ContesttantTestService;
        private IAnswersheetDetailService _AnswersheetDetailService;
        private IAnswerService _AnswerService;
        private IAnswersheetService _AnswersheetService;
        private IContestantShiftService _ContestantShiftService;
        
        private int _ShiftDate;
        private int _ContestID;
        private int _LocaionID;
        public frmSupervisorManage(int _StaftID,int ContestID,int LocationID)
        {
            InitializeComponent();
            _StaffService = new StaffService();
            _ShiftService = new ShiftService();
            _DivisionShiftService = new DivisionShiftService();
            _RoomDiagramService = new RoomDiagramService();
            _LocaionID = LocationID;
            _ContestID = ContestID;
            try
            {
                DTO.frmServer = new frmServer();
                supervisorID = _StaftID;
                STAFF staff = _StaffService.GetById(supervisorID);
                AppSession.UserName = staff.FullName;
            }
            catch
            {
                MessageBox.Show("Không thể kết nối Server.");
                this.Dispose();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }
        private void frmSupervisorManage_Load(object sender, EventArgs e)
        {       
            analogClock1.Enabled = !analogClock1.Enabled;
            dgvListRoomTest.CellMouseClick += new DataGridViewCellMouseEventHandler(DgvListRoomTest_CellMouseClick);
            CreateNodeDate();
            GetInfoShift();

            t.Start();
            t.Tick += new EventHandler(t_Tick);


        }

        private void CreateNodeDate()
        {
            System.Windows.Forms.TreeView tvDate = new System.Windows.Forms.TreeView();
            using (MTAQuizDbContext Db = new MTAQuizDbContext())
            {
               
                var listdate = (from ds in Db.DIVISION_SHIFTS
                                from dsp in Db.DIVISIONSHIFT_SUPERVISOR
                                from exs in Db.EXAMINATIONCOUNCIL_STAFFS
                                where (ds.DivisionShiftID == dsp.DivisionShiftID
                               
                                && exs.ContestID==_ContestID 
                                && exs.LocationID==_LocaionID 
                                && exs.StaffID== supervisorID
                                 && dsp.SupervisorID == exs.ExaminationCouncil_StaffID)
                                select new
                                {
                                    date = ds.StartDate.Value / 86400,
                                    ShiftDate = ds.StartDate.Value
                                }).Distinct().OrderBy(x => x.date).ToList();
                TreeNode nodeParent = new TreeNode();
                nodeParent.Text = "Chọn ngày thi: ";
                nodeParent.Name = "nodeRoot";
                for (int i = 0; i < listdate.Count; i++)
                {
                    if (i == 0)
                    {
                        TreeNode Node = new TreeNode();
                        Node.Name = "Node" + i.ToString();
                        Node.Text = Common.DatetimeConvert.ConvertUnixToDateTime(listdate[i].ShiftDate).ToString("dd-MM-yyyy");
                        nodeParent.Nodes.Add(Node);
                    }
                    else
                    {
                        if (listdate[i].date != listdate[i - 1].date)
                        {
                            TreeNode Node = new TreeNode();
                            Node.Name = "Node" + i.ToString();
                            Node.Text = Common.DatetimeConvert.ConvertUnixToDateTime(listdate[i].ShiftDate).ToString("dd-MM-yyyy");
                            nodeParent.Nodes.Add(Node);

                        }
                    }

                }
                tvDate.AfterSelect += TvDate_AfterSelect;

                tvDate.Nodes.Add(nodeParent);
                tvDate.Dock = DockStyle.Fill;
                tvDate.ExpandAll();
                mpnlTreeViewNgayThi.Controls.Add(tvDate);
                this.Update();

            }

        }

        private void TvDate_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try

            {
                if (!e.Node.Name.Equals("nodeRoot"))
                {
                    DateTime temp = DateTime.ParseExact(((System.Windows.Forms.TreeView)sender).SelectedNode.Text, "dd-MM-yyyy", null);
                    _ShiftDate = Common.DatetimeConvert.ConvertDateTimeToUnix(temp) / 86400;
                    LoadDgvListRoom(_ShiftDate);
                }


            }
            catch(Exception ex)
            {
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR,  string.Format("Expetion : {0}  ", ex.Message));

            }

        }

        private void DgvListRoomTest_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dgvListRoomTest.Rows[e.RowIndex].Selected = true;
                dgvListRoomTest.CurrentCell = dgvListRoomTest[e.ColumnIndex, e.RowIndex];

                var pos = ((DataGridView)sender).GetCellDisplayRectangle(e.ColumnIndex,
                   e.RowIndex, false).Location;
                pos.X += e.X;
                pos.Y += e.Y;
                metroContextMenu2.Show((DataGridView)sender, pos);
            }
        }
        /// <summary>
        /// Vẽ đồng hồ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t_Tick(object sender, EventArgs e)
        {
            try
            {
                int ss = EXON.SubModel.GetDateTimeServer.GetDateTime().Second;
                int mm = EXON.SubModel.GetDateTimeServer.GetDateTime().Minute;
                int hh = EXON.SubModel.GetDateTimeServer.GetDateTime().Hour;

                lblTimeNow.Text = "Thời gian hiện tại: " + hh + ":" + mm + ":" + ss + "";
                if (hh <= 12)
                    lblTimeNow.Text += " AM";
                else
                    lblTimeNow.Text += " PM";
          
            }
            catch(Exception ex)
            {
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }
        }

        private DivisionShift ds;
        private void LoadDgvListRoom(int shiftDate)
        {
            try
            {
                _ExaminationcouncilStaffService = new ExaminationcouncilStaffService();
                _DivisionShiftService = new DivisionShiftService();
             

                MTAQuizDbContext Db = new MTAQuizDbContext();
              //  mlblContestName.Text = "Tên kỳ thi: " + exs.CONTEST.ContestName;
                var listRoom = (from ds in Db.DIVISION_SHIFTS
                                from rt in Db.ROOMTESTS
                                from dsp in Db.DIVISIONSHIFT_SUPERVISOR
                                from sh in Db.SHIFTS
                                from exs in Db.EXAMINATIONCOUNCIL_STAFFS
                                where (ds.DivisionShiftID == dsp.DivisionShiftID
                                && exs.StaffID.Value== supervisorID
                                && dsp.SupervisorID == exs.ExaminationCouncil_StaffID 
                                && rt.RoomTestID == ds.RoomTestID
                                && sh.ShiftID == ds.ShiftID
                                && sh.ShiftDate / 86400 == shiftDate)
                                select new
                                {
                                    ShiftID = sh.ShiftID,
                                    RoomTestID = rt.RoomTestID,
                                    RoomTestName = rt.RoomTestName,
                                    MaxSeatMount = rt.MaxSeatMount,
                                    Endtime = ds.EndTime,
                                    StartTime = ds.StartTime,
                                    StatusDivisionShift = ds.Status
                                }).OrderBy(x=>x.StartTime).ToList();

                if (listRoom.Count > 0)
                {
                    dgvListRoomTest.Rows.Clear();
                    for (int i = 0; i < listRoom.Count; i++)
                    {

                        dgvListRoomTest.Rows.Add();
                        dgvListRoomTest.Rows[i].Cells["STT"].Value = i + 1;
                        dgvListRoomTest.Rows[i].Cells["SHIFID"].Value = listRoom[i].ShiftID.ToString();
                        dgvListRoomTest.Rows[i].Cells["RoomTestID"].Value = listRoom[i].RoomTestID.ToString();
                        dgvListRoomTest.Rows[i].Cells["RoomTestName"].Value = listRoom[i].RoomTestName.ToString();
                        dgvListRoomTest.Rows[i].Cells["MaxSeatMount"].Value = listRoom[i].MaxSeatMount.ToString();
                        dgvListRoomTest.Rows[i].Cells["Endtime"].Value = DatetimeConvert.ConvertUnixToDateTime(listRoom[i].Endtime??default(int)).ToString("HH:mm:ss");
                        dgvListRoomTest.Rows[i].Cells["StartTime"].Value = DatetimeConvert.ConvertUnixToDateTime(listRoom[i].StartTime ?? default(int)).ToString("HH:mm:ss");

                        if (listRoom[i].StatusDivisionShift >= (int)Constant.StatusDivisionShift.STATUS_GENTEST && listRoom[i].StatusDivisionShift < (int)Constant.StatusDivisionShift.STATUS_COMPLETE)
                        {
                            dgvListRoomTest.Rows[i].Cells["StatusDivisionShift"].Value = Properties.Resources.MSG_GUI_003;
                            dgvListRoomTest.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
                        }
                        else if (listRoom[i].StatusDivisionShift == (int)Constant.StatusDivisionShift.STATUS_INIT)
                        {
                            dgvListRoomTest.Rows[i].Cells["StatusDivisionShift"].Value = Properties.Resources.MSG_GUI_004;
                        }
                        else if (listRoom[i].StatusDivisionShift == (int)Constant.StatusDivisionShift.STATUS_COMPLETE)
                        {
                            dgvListRoomTest.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                            dgvListRoomTest.Rows[i].Cells["StatusDivisionShift"].Value = Properties.Resources.MSG_GUI_005;
                        }
                        else if (listRoom[i].StatusDivisionShift == (int)Constant.StatusDivisionShift.STATUS_PAUSE)
                        {
                            dgvListRoomTest.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                            dgvListRoomTest.Rows[i].Cells["StatusDivisionShift"].Value = Properties.Resources.MSG_GUI_012;
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }
        }
        private void GetInfoShift()
        {
            _ShiftService = new ShiftService();
            _ExaminationcouncilStaffService = new ExaminationcouncilStaffService();
            _DivisionShiftService = new DivisionShiftService();
            EXAMINATIONCOUNCIL_STAFFS exs = _ExaminationcouncilStaffService.GetByStaffID(supervisorID);

            int logTime = AppSession.LogTime;
            int TimeNow = (int)EXON.SubModel.GetDateTimeServer.GetDateTime().TimeOfDay.TotalSeconds;


            shift = _ShiftService.GetShiftNow(TimeNow, logTime, DIF_TIME, supervisorID);
           this.Text += " -- Kỳ thi: " + exs.CONTEST.ContestName;

            if (shift != null)
            {
                shiftID = shift.ShiftID;

                //lblThongBao.Text = "Hiện tại có các phòng thi có diễn ra thi bên trên";
                checkTime = true;
            }
            else
            {
                //lblThongBao.Text = "Hiện tại ko có ca thi nào cả";
            }
        }

        private void dgvListRoomTest_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    int timeClick = (int)DatetimeConvert.GetDateTimeServer().TimeOfDay.TotalSeconds;
                    int datenow = DatetimeConvert.ConvertDateTimeToUnix(DatetimeConvert.GetDateTimeServer()) / 86400;
                    _ShiftService = new ShiftService();
                    _DivisionShiftService = new DivisionShiftService();
                    shiftID = int.Parse(dgvListRoomTest.Rows[e.RowIndex].Cells[6].Value.ToString());
                    // Được truy cập trước 30' trước khi ca thi diễn ra
                    int roomID = Convert.ToInt32(dgvListRoomTest.Rows[e.RowIndex].Cells[1].Value);

                    DIVISION_SHIFTS divisionShift = _DivisionShiftService.GetDivisionShift(shiftID, roomID);
                    SHIFT sh = _ShiftService.GetById(shiftID);
                    if (sh != null)
                    {
                        if (((timeClick > (sh.StartTime - DIF_TIME_OPEN)) && (timeClick < sh.EndTime) && datenow == sh.ShiftDate / 86400) || (divisionShift.Status >= (int)Constant.StatusDivisionShift.STATUS_GENTEST))
                        {

                            if (divisionShift != null)
                            {
                                int divisionShiftID = divisionShift.DivisionShiftID;
                                ds = new DivisionShift();
                                ds.ShiftID = shiftID;
                                ds.DivisionShiftID = divisionShiftID;

                                if (DTO.frmServer.IsDisposed)
                                {
                                    DTO.frmServer = new frmServer();
                                }
                                SendInfoToFrmSupervisor sits = new SendInfoToFrmSupervisor(DTO.frmServer.HandelInfo);
                                sits(ds);
                                DTO.frmServer.Show();
                            }
                            else
                            {
                                //lblThongBao.Text += ". Không có phòng thi nào của ca thi";
                                return;
                            }
                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, Properties.Resources.MSG_WAR_001, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, 100);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

                MessageBox.Show(ex.Message);
            }
        }




        /// <summary>
        /// Camera sử dụng sdk
        /// </summary>
        /// <param name="lLoginID"></param>
        /// <param name="pchDVRIP"></param>
        /// <param name="nDVRPort"></param>
        /// <param name="dwUser"></param>
     
        private void frmSupervisorManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Stop();
        }

        private void mItemMenuCheckinRoom_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dgvListRoomTest.SelectedRows;
            if (rows != null)
            {
                int index = dgvListRoomTest.CurrentRow.Index;
                int roomID = int.Parse(dgvListRoomTest.Rows[index].Cells[1].Value.ToString());

                frmRoomConfig frm = new frmRoomConfig(roomID);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Bạn cần chọn phòng thi");
            }
        }

        private void mItemMenuComein_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dgvListRoomTest.SelectedRows;
            if (rows != null)
            {
                int timeClick = (int)DatetimeConvert.GetDateTimeServer().TimeOfDay.TotalSeconds;
                int datenow = DatetimeConvert.ConvertDateTimeToUnix(DatetimeConvert.GetDateTimeServer()) / 86400;
                _ShiftService = new ShiftService();
                _DivisionShiftService = new DivisionShiftService();
                int index = dgvListRoomTest.CurrentCell.RowIndex;
                int roomID = int.Parse(dgvListRoomTest.Rows[index].Cells[1].Value.ToString());
                shiftID = int.Parse(dgvListRoomTest.Rows[index].Cells[6].Value.ToString());
                DIVISION_SHIFTS divisionShift = _DivisionShiftService.GetDivisionShift(shiftID, roomID);
                SHIFT sh = _ShiftService.GetById(shiftID);
                List<ROOMDIAGRAM> lstRoom = new List<ROOMDIAGRAM>();
                lstRoom = _RoomDiagramService.GetAllByRoomTest(roomID).ToList();
                if(lstRoom.Count==0)
                {
                    MessageBox.Show("Phòng chưa được nhập tên máy! Cần nhập tên máy trước khi vào phòng.", "Thông báo!");
                    return;
                }
                if (sh != null)
                {
                    if (((timeClick > (sh.StartTime - DIF_TIME_OPEN)) && (timeClick < sh.EndTime) && datenow == sh.ShiftDate / 86400) || (divisionShift.Status >= (int)Constant.StatusDivisionShift.STATUS_GENTEST))
                     {

                        if (divisionShift != null)
                        {
                            int divisionShiftID = divisionShift.DivisionShiftID;
                            ds = new DivisionShift();
                            ds.ShiftID = shiftID;
                            ds.DivisionShiftID = divisionShiftID;
                           
                            if (DTO.frmServer.IsDisposed)
                            {
                                DTO.frmServer = new frmServer();
                            }
                            SendInfoToFrmSupervisor sits = new SendInfoToFrmSupervisor(DTO.frmServer.HandelInfo);
                            sits(ds);
                            DTO.frmServer.Show();
                        }
                        else
                        {
                            //lblThongBao.Text += ". Không có phòng thi nào của ca thi";
                            return;
                        }
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, Properties.Resources.MSG_WAR_001, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, 100);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn cần nhấp chọn phòng thi");
            }
        }

        private void mItemMenuTurnOn_Click(object sender, EventArgs e)
        {
            LoadDgvListRoom(_ShiftDate);
        }


     
        private void btnPauseContest_Click(object sender, EventArgs e)
        {
            if (IsStop)
            {
                analogClock1.Stop();
                t.Stop();
                btnPauseContest.Text = "Tiếp tục cuộc thi";
                IsStop = false;

            }
            else
            {
                analogClock1.Start();
                btnPauseContest.Text = "Tạm dừng cuộc thi";
                IsStop = true;
                t.Start();
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MetroMessageBox.Show(this, "Bạn có chắc chắn chuyển trạng thái hoàn thành cho tất cả thí sinh?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, 100);
                if (dr == DialogResult.Yes)
                {

                    int ansID;

                    _ContesttantTestService = new ContestantTestService();
                    _ContestantShiftService = new ContestantShiftService();
                    _AnswersheetDetailService = new AnswersheetDetailService();
                    _AnswerService = new AnswerService();
                    _AnswersheetService = new AnswersheetService();
                    List<CONTESTANTS_SHIFTS> lst = new List<CONTESTANTS_SHIFTS>();
                    lst = _ContestantShiftService.GetAll().Where(x => x.Status == 3005).ToList();
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
                                        SumSCore += (float)Math.Round(aw.SUBQUESTION.Score.Value, 2);
                                    }
                                }
                            }

                            // cập nhập điểm cho thí sinh chưa hoàn thành nhưng có bài làm 
                            aws = _AnswersheetService.GetById(aws.AnswerSheetID);
                            aws.TestScores = Math.Round(SumSCore, 2);
                            _AnswersheetService.Update(aws);
                            _AnswersheetService.Save();

                        }
                    }
                    MetroMessageBox.Show(this, "Cập nhập thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  

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