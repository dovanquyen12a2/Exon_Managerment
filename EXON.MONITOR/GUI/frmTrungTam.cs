using EXON.SubData.Services;
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
using EXON.Common;
namespace EXON.MONITOR.GUI
{
    public partial class frmTrungTam : MetroFramework.Forms.MetroForm
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
        private AnswersheetWritingService _AnswersheetWritingService;
        private BagOfTestService _BagOfTestService;
        private TestService _TestService;
        private RoomTestService _RoomTestService;
        private ExaminationcouncilStaffService _ExaminationcouncilStaffService;

        #endregion Service
        private int StaffID;
        private string _username;
        private string _password;
        public frmTrungTam(string username, string password)
        {
            InitializeComponent();
            _username = username;
            _password = password;
            InitializeService();
            InitControl();
        }

        private void InitControl()
        {
            _ExaminationcouncilStaffService = new ExaminationcouncilStaffService();
            int stt = 0;
            List<EXAMINATIONCOUNCIL_STAFFS> lstStaff = new List<EXAMINATIONCOUNCIL_STAFFS>();
            lstStaff = _ExaminationcouncilStaffService.GetMutilByAccAtCenter(_username, _password).ToList();

            if (lstStaff.Count > 0)
            {
                lblStaffName.Text = "Xin Chào: " + lstStaff[0].STAFF.FullName ;

                dgvContest.DataSource = (from ct in lstStaff
                                         select new
                                         {
                                             ID = ct.ContestID,
                                             LocationID =ct.LocationID,
                                             StaffID= ct.StaffID,
                                             TenKiThi = ct.CONTEST.ContestName,
                                             STT = stt++,
                                             Location = ct.LOCATION.LocationName,
                                             TrangThai = CheckStatus(ct.CONTEST.Status)
                                         }
                                  ).ToList();
            }
        }

        private string CheckStatus(int status)
        {
            switch (status)
            {
                case (int)ContestStatus.ContestDone: return "Đã tổ chức thi";
                default: return "Đã chuyển đề về";




             }

        }

        private void InitializeService()
        {
            _ExaminationcouncilStaffService = new ExaminationcouncilStaffService();
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

        private void MbtnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();

        }

        private void BtnDanhSachKeHoach_Click(object sender, EventArgs e)
        {

        }

        private void MbtnChuyenDuLieuVe_Click(object sender, EventArgs e)
        {

        }

        private void MbtnCauHinhHeThong_Click(object sender, EventArgs e)
        {

        }

        private void ToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dgvContest.SelectedRows;
            //int index = dgvListRoomTest.SelectedRows[0].Index;

            if (rows != null)
            {
                int index = dgvContest.CurrentCell.RowIndex;
                int ContestID = int.Parse(dgvContest.Rows[index].Cells[0].Value.ToString());
                int LocationID = int.Parse(dgvContest.Rows[index].Cells[1].Value.ToString());
                int StaffID = int.Parse(dgvContest.Rows[index].Cells[2].Value.ToString());
                
                frmMain frm = new frmMain(StaffID, LocationID, ContestID);
                this.Hide();
                frm.ShowDialog();
                this.Show();

            }
            }

        private void DgvContest_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dgvContest.Rows[e.RowIndex].Selected = true;
                dgvContest.CurrentCell = dgvContest[e.ColumnIndex, e.RowIndex];

                var pos = ((DataGridView)sender).GetCellDisplayRectangle(e.ColumnIndex,
                   e.RowIndex, false).Location;
                pos.X += e.X;
                pos.Y += e.Y;
                metroContextMenu1.Show((DataGridView)sender, pos);
            }
        }
    }
}
