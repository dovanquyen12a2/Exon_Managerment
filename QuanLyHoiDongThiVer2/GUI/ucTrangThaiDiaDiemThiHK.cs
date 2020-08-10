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
using EXON.SubData;
using EXON.Common;
using EXON.SubModel.Models;
namespace QuanLyHoiDongThiVer2.GUI
{
    public partial class ucTrangThaiDiaDiemThiHK : UserControl
    {
        #region Service
        private IContestService _ContestService;

        private IDivisionShiftService _DivisionShiftService;



        #endregion Service
        private int _ContestID { get; set; }
        private int _LocaionID { get; set; }
        private int _ShiftDate { get; set; }
        private int _StaffID { get; set; }
        public ucTrangThaiDiaDiemThiHK(int ContestID, int LocationID, int StaffID)
        {
            InitializeComponent();
            _ContestID = ContestID;
            _LocaionID = LocationID;
            _StaffID = StaffID;
            InitService();
            InitializeControl();

        }

        private void InitService()
        {

            _ContestService = new ContestService();

            _DivisionShiftService = new DivisionShiftService();

        }



        private void InitializeControl()
        {
            CreateNodeDate();
        }
        private void CreateNodeDate()
        {
            System.Windows.Forms.TreeView tvDate = new System.Windows.Forms.TreeView();
            using (EXON.SubModel.Models.MTAQuizDbContext Db = new EXON.SubModel.Models.MTAQuizDbContext())
            {
                _DivisionShiftService = new DivisionShiftService();

                var listdate = (from ds in Db.DIVISION_SHIFTS
                                from dsp in Db.DIVISIONSHIFT_SUPERVISOR
                                from exs in Db.EXAMINATIONCOUNCIL_STAFFS
                                where (ds.DivisionShiftID == dsp.DivisionShiftID

                                && exs.ContestID == _ContestID
                                && exs.LocationID == _LocaionID
                                && exs.StaffID == _StaffID
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
                        Node.Text = DateTimeHelpers.ConvertUnixToDateTime(listdate[i].ShiftDate).ToString("dd-MM-yyyy");
                        nodeParent.Nodes.Add(Node);
                    }
                    else
                    {
                        if (listdate[i].date != listdate[i - 1].date)
                        {
                            TreeNode Node = new TreeNode();
                            Node.Name = "Node" + i.ToString();
                            Node.Text = DateTimeHelpers.ConvertUnixToDateTime(listdate[i].ShiftDate).ToString("dd-MM-yyyy");
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
                    _ShiftDate = DateTimeHelpers.ConvertDateTimeToUnix(temp) / 86400;
                    LoadDgvListRoom(_ShiftDate);
                }


            }
            catch

            { }
        }

        private void LoadDgvListRoom(int shiftDate)
        {
            //  mlblContestName.Text = "Tên kỳ thi: " + exs.CONTEST.ContestName;
            try
            {
                using (EXON.SubModel.Models.MTAQuizDbContext Db = new EXON.SubModel.Models.MTAQuizDbContext())
                {

                    var listRoom = (from ds in Db.DIVISION_SHIFTS
                                    from dsp in Db.DIVISIONSHIFT_SUPERVISOR
                                    from exs in Db.EXAMINATIONCOUNCIL_STAFFS
                                    where (
                                 ds.StartDate / 86400 == shiftDate
                                    && exs.ContestID == _ContestID
                                    && exs.LocationID == _LocaionID
                                    && dsp.SupervisorID == exs.ExaminationCouncil_StaffID
                                    && exs.StaffID==_StaffID
                                           )
                                    select new
                                    {

                                        SHIFTID = ds.SHIFT.ShiftID,
                                        RoomTestID = ds.ROOMTEST.RoomTestID,
                                        RoomTestName = ds.ROOMTEST.RoomTestName,
                                        MaxSeatMount = ds.ROOMTEST.MaxSeatMount,
                                        Endtime = ds.EndTime,
                                        StartTime = ds.StartTime,
                                        StatusDS = ds.Status,
                                        DivsionShiftID = ds.DivisionShiftID
                                    }).Distinct().OrderBy(x => x.StartTime).ToList();
                    if (listRoom.Count > 0)
                    {
                        dgvListRoomTest.Rows.Clear();
                        for (int i = 0; i < listRoom.Count; i++)
                        {

                            dgvListRoomTest.Rows.Add();

                            dgvListRoomTest.Rows[i].Cells["SHIFID"].Value = listRoom[i].SHIFTID.ToString();
                            dgvListRoomTest.Rows[i].Cells["RoomTestID"].Value = listRoom[i].RoomTestID.ToString();
                            dgvListRoomTest.Rows[i].Cells["RoomTestName"].Value = listRoom[i].RoomTestName.ToString();
                            dgvListRoomTest.Rows[i].Cells["MaxSeatMount"].Value = listRoom[i].MaxSeatMount.ToString();
                            dgvListRoomTest.Rows[i].Cells["Endtime"].Value = DateTimeHelpers.ConvertUnixToDateTime(listRoom[i].Endtime ?? default(int)).ToString("HH:mm:ss");
                            dgvListRoomTest.Rows[i].Cells["StartTime"].Value = DateTimeHelpers.ConvertUnixToDateTime(listRoom[i].StartTime ?? default(int)).ToString("HH:mm:ss");
                            if (listRoom[i].StatusDS == (int)StatusDivisionShift.STATUS_GENTEST)
                            {
                                dgvListRoomTest.Rows[i].DefaultCellStyle.BackColor = Color.Blue;

                            }

                            else if (listRoom[i].StatusDS == (int)StatusDivisionShift.STATUS_DECRYPT)
                            {

                                dgvListRoomTest.Rows[i].DefaultCellStyle.BackColor = Color.Lavender;

                            }
                            if (listRoom[i].StatusDS == (int)StatusDivisionShift.STATUS_DIVISIONTEST)
                            {
                                dgvListRoomTest.Rows[i].DefaultCellStyle.BackColor = Color.DarkOrange;


                            }
                            if (listRoom[i].StatusDS == (int)StatusDivisionShift.STATUS_STARTTEST)
                            {
                                dgvListRoomTest.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;


                            }
                            else if (listRoom[i].StatusDS == (int)StatusDivisionShift.STATUS_COMPLETE)
                            {
                                dgvListRoomTest.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                            }
                            else if (listRoom[i].StatusDS == (int)StatusDivisionShift.STATUS_PAUSE)
                            {
                                dgvListRoomTest.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                            }
                            dgvListRoomTest.Rows[i].Cells["StatusDS"].Value = ConvertToString(listRoom[i].StatusDS);

                            dgvListRoomTest.Rows[i].Cells["DivisionShiftID"].Value = listRoom[i].DivsionShiftID;

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                dgvListRoomTest.DataSource = null;

            }
        }

        private string ConvertToString(int status)
        {

            switch (status)
            {

                case (int)EXON.Common.StatusDivisionShift.STATUS_GENTEST:
                    return "Đã chia đề";
                case (int)StatusDivisionShift.STATUS_DECRYPT:
                    return "Đã giải mã đề";
                case (int)StatusDivisionShift.STATUS_DIVISIONTEST:
                    return "Đã phát đề";
                case (int)StatusDivisionShift.STATUS_STARTTEST:
                    return "Bắt đầu thi";
                case (int)StatusDivisionShift.STATUS_COMPLETE:
                    return "Ca thi kết thúc";
                default: return "Ca thi chưa mở";
            }

        }

        private void MItemMenuRefresh_Click(object sender, EventArgs e)
        {
            InitializeControl();
        }

        private void MItemMenuComein_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dgvListRoomTest.SelectedRows;
            if (rows != null)
            {
                int index = dgvListRoomTest.CurrentRow.Index;
                int dsID = int.Parse(dgvListRoomTest.Rows[index].Cells["DivisionShiftID"].Value.ToString());
                _DivisionShiftService = new DivisionShiftService();
                DIVISION_SHIFTS ds = new DIVISION_SHIFTS();
                ds = _DivisionShiftService.GetById(dsID);
                if (ds != null)
                {
                    FrmTrangThaiPhongThi frm = new FrmTrangThaiPhongThi(ds);
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Lỗi khi lấy dữ liệu phòng thi");
                }

            }
            else
            {
                MessageBox.Show("Bạn cần chọn phòng thi");
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

        private void MItemMenuReport_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dgvListRoomTest.SelectedRows;
            if (rows != null)
            {
                int index = dgvListRoomTest.CurrentRow.Index;
                int dsID = int.Parse(dgvListRoomTest.Rows[index].Cells["DivisionShiftID"].Value.ToString());
                _DivisionShiftService = new DivisionShiftService();
                DIVISION_SHIFTS ds = new DIVISION_SHIFTS();
                ds = _DivisionShiftService.GetById(dsID);
                if (ds != null)
                {
                    report.frmRpKetQuaCaThi frm = new report.frmRpKetQuaCaThi(ds.DivisionShiftID);
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Lỗi khi lấy dữ liệu phòng thi");
                }

            }
            else
            {
                MessageBox.Show("Bạn cần chọn phòng thi");
            }
        }
    }
}
