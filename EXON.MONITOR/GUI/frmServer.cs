using EXON.MONITOR.Common;
using EXON.SubModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXON.MONITOR.Control;
using EXON.SubData.Services;
using MetroFramework.Controls;
using MetroFramework.Forms;

using System.Net;
using MetroFramework;
using EXON.MONITOR.Report;
using EXON.Common;

namespace EXON.MONITOR.GUI
{
    public partial class frmServer : MetroForm
    {   
        #region Declare
        private int supervisorID;
        
        #region Service
        private IStaffService _StaffService;
        private IShiftService _ShiftService;
        private IRoomTestService _RoomTestService;
        private IDivisionShiftService _DivisionShiftService;
        private IContestantShiftService _ContestantShiftService;
        private IRoomDiagramService _RoomdiagramService;
     
        #endregion
        public delegate void SendWorking(bool isprogress);
        public int TimeOfTest = 120000; /// thoi gian lam bai khai bao cho lon
        public bool VisibleLabelTime = false;
        private int index;
        private int countDivisionShift;
        private int divisionShiftID;
        private int shiftID;
        private int roomTestID;
        private int[] indexPage = new int[10];
        private int[] ListShiftID = new int[10];
        private int[] ListDivisionShiftID = new int[10];
        private SHIFT shift;
        private ROOMTEST room;
      

   
        static public int check = 0;
        #endregion
        public frmServer()
        {
            InitializeComponent();
            InitializeService();
            InitializeControl();
        }

        private void InitializeControl()
        {
            supervisorID = AppSession.StaffID;
            setFullScreen();
            STAFF staff = _StaffService.GetById(supervisorID);
          
        }

        private void InitializeService()
        {

            _StaffService = new StaffService();
            _ShiftService = new ShiftService();
            _RoomTestService = new RoomTestService();
            _DivisionShiftService = new DivisionShiftService();
            _RoomdiagramService = new RoomDiagramService();
            _ContestantShiftService = new ContestantShiftService();
        }

        public void HandelInfo(DivisionShift ds)
        {
            for (int i = 0; i < ListDivisionShiftID.Count(); i++)
            {
                if (ds.DivisionShiftID == ListDivisionShiftID[i])
                {
                    tabMain.SelectedIndex = i;
                    return;
                }
            }

            ListDivisionShiftID[countDivisionShift] = ds.DivisionShiftID;

            ListShiftID[countDivisionShift] = ds.ShiftID;
            this.shiftID = ds.ShiftID;
            this.divisionShiftID = ds.DivisionShiftID;
            countDivisionShift++;
            DIVISION_SHIFTS divisionShift = _DivisionShiftService.GetById(divisionShiftID);
            if (divisionShift != null)
            {
                roomTestID = Convert.ToInt32(divisionShift.RoomTestID);
            }
            GetInfoShift();
            handelPannelDiagram();

        }
        public void handelPannelDiagram()
        {
          TabPage tabroom = new TabPage();
            indexPage[index] = index++;

            DIVISION_SHIFTS divisionShift = _DivisionShiftService.GetById(divisionShiftID);
            tabroom.Name = divisionShift.RoomTestID.ToString();
            tabroom.Text = "Phòng: " + divisionShift.ROOMTEST.RoomTestName;
            Control.ucServer ucserver = new Control.ucServer(divisionShift);
          
            ucserver.Dock = DockStyle.Fill;
            tabroom.Controls.Add(ucserver);
            this.tabMain.Controls.Add(tabroom);

        }
        private void GetInfoShift()
        {
            _ShiftService = new ShiftService();
            shift = _ShiftService.GetById(shiftID);

            if (shift != null)
            {
                if (shift.ShiftName != null)
                {
                    lblShiftName.Text = "Ca:" + shift.ShiftName;
                    lblStartTime.Text = Properties.Resources.MSG_GUI_001 + DatetimeConvert.ConvertUnixToDateTime(shift.StartTime).ToString("HH:mm:ss");
                    lblEndTime.Text = Properties.Resources.MSG_GUI_002 + DatetimeConvert.ConvertUnixToDateTime(shift.EndTime).ToString("HH:mm:ss");

                    DIVISION_SHIFTS divisionShift = _DivisionShiftService.GetById(divisionShiftID);
                    roomTestID = divisionShift.RoomTestID;
                    if (divisionShift != null)
                    {
                        room = _RoomTestService.GetById(Convert.ToInt32(divisionShift.RoomTestID));
                        roomTestID = Convert.ToInt32(divisionShift.RoomTestID);
                        if (room != null)
                        {
                            roomTestID = room.RoomTestID;
                        }
                    }
                }
                else
                {
                    lblShiftName.Text = "Mã ca: " + shift.ShiftID;
                }
            }
        }
        public void UpdateLabelShiftTime()
        {

            _ShiftService = new ShiftService();
            shift = _ShiftService.GetById(shiftID);

            if (shift != null)
            {
                lblShiftName.Text = "Ca:" + shift.ShiftName;
                lblStartTime.Text = Properties.Resources.MSG_GUI_001 + DatetimeConvert.ConvertUnixToDateTime(shift.StartTime).ToString("HH:mm:ss");
                lblEndTime.Text = Properties.Resources.MSG_GUI_002 + DatetimeConvert.ConvertUnixToDateTime(shift.EndTime).ToString("HH:mm:ss");
            }
        }
        private void setFullScreen()
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            this.WindowState = FormWindowState.Normal;
        }

        private void tabControl1_ControlAdded(object sender, ControlEventArgs e)
        {
            frmServer_Load(sender, e);

        }
        // bieen dem so lan khi mo form
        int countOpenFrm = 0;
        private void frmServer_Load(object sender, EventArgs e)
        {

            this.ShowInTaskbar = true;
            setFullScreen();
            GetInfoShift();
            tabMain.SelectedIndex = countDivisionShift - 1;
     

        }

        private void mbtnPrint_Click(object sender, EventArgs e)
        {
            metroContextMenu2.Show(mbtnPrint, new Point(0, mbtnPrint.Height));
        }

        private void mItemPrintContestant_Click(object sender, EventArgs e)
        {
            try
            {
                _DivisionShiftService = new DivisionShiftService();
                DIVISION_SHIFTS ds = _DivisionShiftService.GetById(divisionShiftID);

                Report.FrmRpLichThiTheoCaThi lichthi = new FrmRpLichThiTheoCaThi(ds);
                lichthi.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi" + ex.Message.ToString());
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }
        }

        private void mItemPrintResultContestant_Click(object sender, EventArgs e)
        {
           
            FrmRpKetQuaKipThi frm = new FrmRpKetQuaKipThi(divisionShiftID);
            frm.ShowDialog();
        }



        private void frmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            foreach (int i in indexPage)
            {
                if (e.TabPageIndex == i)
                {
                    divisionShiftID = ListDivisionShiftID[i];
                    shiftID = ListShiftID[i];
                }
            }
        }
        //TODO
        private void mItemStartForAll_Click(object sender, EventArgs e)
        {
            
        }
        private void UpdateShiftForKip(int TimeShiftStart, int TimeOfTest)
        {
            _ShiftService = new ShiftService();
            SHIFT sh = new SHIFT();
            List<SHIFT> lstShift = new List<SHIFT>();
            sh = _ShiftService.GetById(shiftID);
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

        private void TsmReadytest_Click(object sender, EventArgs e)
        {
            try
            {
                if(DialogResult.Yes == MessageBox.Show("Bạn chắc chắn chuyển trạng thái cho tất cả thí sinh?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question))
                {
                    _DivisionShiftService = new DivisionShiftService();
                    _ContestantShiftService = new ContestantShiftService();
                    DIVISION_SHIFTS ds = _DivisionShiftService.GetById(divisionShiftID);
                    List<CONTESTANTS_SHIFTS> lstcs = new List<CONTESTANTS_SHIFTS>();
                    lstcs = _ContestantShiftService.GetAllByDivisionShiftID(divisionShiftID).ToList();
                    foreach (CONTESTANTS_SHIFTS cs in lstcs)
                    {
                        cs.Status =Constant.STATUS_READY;

                        _ContestantShiftService.Update(cs);
                        _ContestantShiftService.Save();
                    }
                    MetroMessageBox.Show(this, "Cập nhập thành công! Vui lòng chọn cập nhập trạng thái. ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, 100);
                }
              
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi cập nhập dữ liệu!");
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }
        }

        private void TsmTesting_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn chắc chắn chuyển trạng thái cho tất cả thí sinh?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    _DivisionShiftService = new DivisionShiftService();
                    _ContestantShiftService = new ContestantShiftService();
                    DIVISION_SHIFTS ds = _DivisionShiftService.GetById(divisionShiftID);
                    List<CONTESTANTS_SHIFTS> lstcs = new List<CONTESTANTS_SHIFTS>();
                    lstcs = _ContestantShiftService.GetAllByDivisionShiftID(divisionShiftID).ToList();
                    foreach (CONTESTANTS_SHIFTS cs in lstcs)
                    {
                        cs.Status = Constant.STATUS_DOING;

                        _ContestantShiftService.Update(cs);
                        _ContestantShiftService.Save();
                    }
                    MetroMessageBox.Show(this, "Cập nhập thành công! Vui lòng chọn cập nhập trạng thái.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, 100);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhập dữ liệu!");
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }
        }

        private void TsmCompleteTest_Click(object sender, EventArgs e)
        {
            try
            {

                if (DialogResult.Yes == MessageBox.Show("Bạn chắc chắn chuyển trạng thái cho tất cả thí sinh?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    _DivisionShiftService = new DivisionShiftService();
                    _ContestantShiftService = new ContestantShiftService();
                    DIVISION_SHIFTS ds = _DivisionShiftService.GetById(divisionShiftID);
                    List<CONTESTANTS_SHIFTS> lstcs = new List<CONTESTANTS_SHIFTS>();
                    lstcs = _ContestantShiftService.GetAllByDivisionShiftID(divisionShiftID).ToList();
                    foreach (CONTESTANTS_SHIFTS cs in lstcs)
                    {
                        cs.Status = Constant.STATUS_FINISHED;

                        _ContestantShiftService.Update(cs);
                        _ContestantShiftService.Save();
                    }
                    MetroMessageBox.Show(this, "Cập nhập thành công! Vui lòng chọn cập nhập trạng thái.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, 100);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhập dữ liệu!");
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }
        }
    }
}
