using EXON.SubData.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXON.SubModel.Models;
namespace EXON.MONITOR.GUI
{
    public partial class frmQuanLyThiSinh : Form
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
        private IRoomTestService _RoomTestService;
        #endregion
        private int _locationID { get; set; }
        public frmQuanLyThiSinh(int ContestID, int LocationID)
        {
            InitializeComponent();
            InitService();
            CurrentContestID = ContestID;
            _locationID = LocationID;
            InitControl();

        }
        private int CurrentContestID
        {
            get;

            set;
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
        private void InitControl()
        {
            _ShiftService = new ShiftService();
            _RoomTestService = new RoomTestService();
            cbShift.DataSource = (from s in _ShiftService.GetAll(CurrentContestID).Where(x => x.Status > 0)

                                  select s).ToList();
            cbShift.DisplayMember = "ShiftName";
            cbShift.ValueMember = "ShiftID";
            cbRoomTest.DataSource = (from r in _RoomTestService.GetAll().Where(x => x.LOCATION.ContestID == CurrentContestID)
                                     from ds in _DivisionShiftService.GetAll()
                                     where CurrentShiftID == ds.ShiftID && r.RoomTestID == ds.RoomTestID
                                     select r).ToList();
            cbRoomTest.DisplayMember = "RoomTestName";

            cbRoomTest.ValueMember = "RoomTestID";
        }

        private void InitService()
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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void cbRoomTest_SelectedValueChanged(object sender, EventArgs e)
        {

            if (CurrentShiftID != -1 && CurrentRoomTestID != -1)
            {
                _ShiftService = new ShiftService();

                _ScheduleService = new ScheduleService();

                _ContestantShiftService = new ContestantShiftService();
                _DivisionShiftService = new DivisionShiftService();
                DIVISION_SHIFTS CurrentDs = new DIVISION_SHIFTS();
                int STT = 1;
                CurrentDs = _DivisionShiftService.GetByShiftAndRoomTest(CurrentShiftID, CurrentRoomTestID);
                var listContestant = (

                    from cs in _ContestantShiftService.GetAllByDivisionShiftID(CurrentDs.DivisionShiftID)
                    select new
                    {
                        ContestantShiftID = cs.ContestantShiftID,
                        STT = STT++,
                        ContestantCode = cs.CONTESTANT.ContestantCode,
                        DOB = cs.CONTESTANT.DOB,
                        IdentityCardNumber = cs.CONTESTANT.IdentityCardNumber,
                        Subject = cs.SCHEDULE.SUBJECT.SubjectName,
                        FullName = cs.CONTESTANT.FullName,
                        Unit = cs.CONTESTANT.Unit
                    }).ToList();

                gvMain.DataSource = listContestant;
                lblSum.Text = listContestant.Count.ToString();
            }
        }
        private void RefreshData()
        {
            if (CurrentShiftID != -1 && CurrentRoomTestID != -1)
            {
                _ShiftService = new ShiftService();

                _ScheduleService = new ScheduleService();

                _ContestantShiftService = new ContestantShiftService();
                _DivisionShiftService = new DivisionShiftService();
                DIVISION_SHIFTS CurrentDs = new DIVISION_SHIFTS();
                int STT = 1;
                CurrentDs = _DivisionShiftService.GetByShiftAndRoomTest(CurrentShiftID, CurrentRoomTestID);
                var listContestant = (

                    from cs in _ContestantShiftService.GetAllByDivisionShiftID(CurrentDs.DivisionShiftID)
                    select new
                    {
                        ContestantID = cs.ContestantID,
                        STT = STT++,
                        ContestantCode = cs.CONTESTANT.ContestantCode,
                        DOB = cs.CONTESTANT.DOB,
                        IdentityCardNumber = cs.CONTESTANT.IdentityCardNumber,
                        Subject = cs.SCHEDULE.SUBJECT.SubjectName,
                        FullName = cs.CONTESTANT.FullName,
                        Unit = cs.CONTESTANT.Unit
                    }).ToList();

                gvMain.DataSource = listContestant;
                lblSum.Text = listContestant.Count.ToString();
            }
        }
        private void cbShift_SelectedValueChanged(object sender, EventArgs e)
        {
            cbRoomTest.DataSource = (from r in _RoomTestService.GetAll().Where(x => x.LOCATION.ContestID == CurrentContestID)
                                     from ds in _DivisionShiftService.GetAll()
                                     where CurrentShiftID == ds.ShiftID && r.RoomTestID == ds.RoomTestID
                                     select r).ToList();
            cbRoomTest.DisplayMember = "RoomTestName";

            cbRoomTest.ValueMember = "RoomTestID";
            if (CurrentRoomTestID == -1)
            {
                gvMain.DataSource = null;
            }
        }

        private void btnAddnew_Click(object sender, EventArgs e)
        {
            try
            {
                _ContestantShiftService = new ContestantShiftService();
                _DivisionShiftService = new DivisionShiftService();
                DIVISION_SHIFTS CurrentDs = new DIVISION_SHIFTS();
                int STT = 1;
                CurrentDs = _DivisionShiftService.GetByShiftAndRoomTest(CurrentShiftID, CurrentRoomTestID);
                //if (CurrentDs.Status != (int)Common.Constant.StatusDivisionShift.STATUS_INIT)
                //{
                //    MessageBox.Show("Ca thi đã bắt đầu. Bạn không thể đăng ký thí sinh", "Thông báo");
                //    return;

                //}
                frmDangKyThiSinh frm = new frmDangKyThiSinh(CurrentDs.DivisionShiftID);
                frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Không có dữ liệu.", "Thông báo");
            }
        }

        private void BtnRefesh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void BtnChiTietThiSinh_Click(object sender, EventArgs e)
        {
            
        }
        private int _ContestantShiftID;
        private void GvMain_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    gvMain.Rows[e.RowIndex].Selected = true;
                    gvMain.CurrentCell = gvMain[e.ColumnIndex, e.RowIndex];
                    var pos = ((DataGridView)sender).GetCellDisplayRectangle(e.ColumnIndex,
                       e.RowIndex, false).Location;
                    pos.X += e.X;
                    pos.Y += e.Y;
                    int index = gvMain.CurrentCell.RowIndex;
                    _ContestantShiftID = int.Parse(gvMain.Rows[index].Cells["cID"].Value.ToString());
                    contextMenuMain.Show((DataGridView)sender, pos);
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void MenuitemEdit_Click(object sender, EventArgs e)
        {
            if (CurrentShiftID != -1 && CurrentRoomTestID != -1)
            {
               
                _DivisionShiftService = new DivisionShiftService();
                DIVISION_SHIFTS CurrentDs = new DIVISION_SHIFTS();
              
                CurrentDs = _DivisionShiftService.GetByShiftAndRoomTest(CurrentShiftID, CurrentRoomTestID);
                if(CurrentDs!=null)
                {
                    frmSuaThiSinh frm = new frmSuaThiSinh(CurrentDs.DivisionShiftID, _ContestantShiftID);
                    frm.ShowDialog();
                    RefreshData();

                }

            }
        }

        private void FrmQuanLyThiSinh_Load(object sender, EventArgs e)
        {
            gvMain.CellMouseClick += new DataGridViewCellMouseEventHandler(GvMain_CellMouseClick);
        }

        private void GvMain_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
