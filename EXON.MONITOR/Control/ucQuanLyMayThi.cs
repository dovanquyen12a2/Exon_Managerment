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
using EXON.Common;

namespace EXON.MONITOR.Control
{
    public partial class ucQuanLyMayThi : UserControl
    {
        private IRoomDiagramService _RoomDiagramService;
        private List<ROOMDIAGRAM> lstRoomdiagram;
        List<RoomDiagramFromRoomTest> lstComputer;
        private int _RoomDiagramID;
        private int _roomTestID;
        #region Service

        private ContestService _ContestService;
        private ShiftService _ShiftService;
        private ScheduleService _ScheduleService;
        private SubjectService _SubjectService;
        private StaffService _StaffService;
        private DivisionShiftService _DivisionShiftService;
        private ContestantShiftService _ContestantShiftService;
        private TestNumberService _TestNumberService;
        private ContestantTestService _ContestantTestService;
        private AnswersheetService _AnswersheetService;
        private AnswersheetWritingService _AnswersheetWritingService;
        private TestService _TestService;
        private RoomTestService _RoomTestService;

        #endregion Service
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
        private int _LocationID { get; set; }
        private int _ContestID { get; set; }
        public ucQuanLyMayThi(int LocationID,int ContestID)
        {
            InitializeComponent();
            this._LocationID = LocationID;
            this._ContestID= ContestID;
            InitializeService();
            InitDataControl();
        }
        public ucQuanLyMayThi(int roomtestID)
        {
            InitializeComponent();
            this._roomTestID = roomtestID;
            InitializeService();
            InitDataControl();
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

        private void InitDataControl()
        {

            cbRoomTest.DataSource = _RoomTestService.GetAll().Where(x=>x.LocationID==_LocationID && x.LOCATION.ContestID==_ContestID).ToList();
            cbRoomTest.DisplayMember = "RoomTestName";
            cbRoomTest.ValueMember = "RoomTestID";
            lstRoomdiagram = new List<ROOMDIAGRAM>();
            _RoomDiagramService = new RoomDiagramService();
          lstComputer = new List<RoomDiagramFromRoomTest>();
            lstRoomdiagram = _RoomDiagramService.GetAllByRoomTest(CurrentRoomTestID).ToList();
            int count = 0;
            for (int i = 0; i < lstRoomdiagram.Count; i++)
            {
               
                        RoomDiagramFromRoomTest rd= new RoomDiagramFromRoomTest
                                    {
                                             RoomDiagramID = lstRoomdiagram[i].RoomDiagramID,
                                              STT = ++count,
                                            ComputerCode = lstRoomdiagram[i].ComputerCode,
                                            ComputerName= lstRoomdiagram[i].ComputerName,                                       
                                             Status = lstRoomdiagram[i].Status == 4001 ? "Tốt" : "Không phản hồi",
                                          
                                         };
                lstComputer.Add(rd);
            }

            if (lstComputer != null)
            {
                gvMain.DataSource = lstComputer;
                lbCount.Text = string.Format("Tổng Số {0} máy thi", lstRoomdiagram.Count);
            }
            else gvMain.DataSource = null;

        
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            for (int i = 0; i < lstRoomdiagram.Count; i++)
            {
                collection.Add(lstRoomdiagram[i].ComputerName);
                collection.Add(lstRoomdiagram[i].ComputerCode);
             
            }

            this.cmbKeyName.AutoCompleteCustomSource = collection;
            this.cmbKeyName.AutoCompleteMode = AutoCompleteMode.Suggest;

            //UpdateButtonEnable();
        }

        private void UpdateButtonEnable()
        {
            throw new NotImplementedException();
        }

        private void ucQuanLyMayThi_Load(object sender, EventArgs e)
        {
          //  SetBackColor();
            
        }

        private void SetBackColor()
        {
            foreach (DataGridViewRow row in gvMain.Rows)
            {
                if (row.Cells["cStatus"].Value.ToString() == "Không phản hồi")
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                else
                    row.DefaultCellStyle.BackColor = Color.Green;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string a = cmbKeyName.Text;
            gvMain.DataSource = lstComputer.Where(z => z.ComputerName.Contains(a) || z.ComputerCode.Contains(a)).ToList();
           // SetBackColor();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            gvMain.DataSource = lstComputer;
          //  SetBackColor();
        }

        private void btnCheckStatusCom_Click(object sender, EventArgs e)
        {
            _RoomDiagramService.UpdateStatusbyAgent(CurrentRoomTestID);
            InitDataControl();
           // SetBackColor();
        }

        private void btnAddnew_Click(object sender, EventArgs e)
        {
            EXON.MONITOR.GUI.frmAddComputer frm = new GUI.frmAddComputer(CurrentRoomTestID, false);
            frm.ShowDialog();
            InitDataControl();
           // SetBackColor();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
         
           // SetBackColor();
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            EXON.MONITOR.GUI.frmImportRoom frm = new GUI.frmImportRoom(CurrentRoomTestID);
            frm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có chắn chắn muốn xóa máy thi này khỏi phòng thi", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    _RoomDiagramService.Delete(_RoomDiagramID);
                    _RoomDiagramService.Save();
                    InitDataControl();
                   // SetBackColor();
                }
            }
            catch(Exception ex)
            {
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }
        }

        private void gvMain_SelectionChanged(object sender, EventArgs e)
        {
            _RoomDiagramID = int.Parse(gvMain.CurrentRow.Cells["cID"].Value.ToString());
        }

        private void btnFilt_Click(object sender, EventArgs e)
        {
            if (gvMain.DataSource == null) return;

            string NeedStatus = string.Empty;
            if (rdOK.Checked)
            {
                gvMain.DataSource = lstComputer.Where(z => z.Status == "Tốt").ToList();    
            }
            else if (rbError.Checked)
            {
                gvMain.DataSource = lstComputer.Where(z => z.Status == "Không phản hồi").ToList();                
            }
            else if (rbAll.Checked)
                gvMain.DataSource = lstComputer;
           // SetBackColor();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InitDataControl();
           // SetBackColor();
        }

        private void gvMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gvMain.Rows[e.RowIndex].Cells["cStatus"].Value.ToString() == "Tốt")
            {
                gvMain.Rows[e.RowIndex].Cells["cStatus"].Style = new DataGridViewCellStyle { ForeColor = Color.Black, BackColor = Color.Green };
            }
            else
            {
                gvMain.Rows[e.RowIndex].Cells["cStatus"].Style = new DataGridViewCellStyle { ForeColor = Color.Black, BackColor = Color.Red };
            }
        }

        private void cbRoomTest_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CurrentRoomTestID > -1)
            {
                _RoomDiagramService = new RoomDiagramService();
                lstRoomdiagram = new List<ROOMDIAGRAM>();
                lstComputer = new List<RoomDiagramFromRoomTest>();
                lstRoomdiagram = _RoomDiagramService.GetAllByRoomTest(CurrentRoomTestID).ToList();
                int count = 0;
                for (int i = 0; i < lstRoomdiagram.Count; i++)
                {

                    RoomDiagramFromRoomTest rd = new RoomDiagramFromRoomTest
                    {
                        RoomDiagramID = lstRoomdiagram[i].RoomDiagramID,
                        STT = ++count,
                        ComputerCode = lstRoomdiagram[i].ComputerCode,
                        ComputerName = lstRoomdiagram[i].ComputerName,
                        Status = lstRoomdiagram[i].Status == 4001 ? "Tốt" : "Không phản hồi",

                    };
                    lstComputer.Add(rd);
                }

                if (lstComputer != null)
                {
                    gvMain.DataSource = lstComputer;
                    lbCount.Text = string.Format("Tổng Số {0} máy thi", lstRoomdiagram.Count);
                }
                else gvMain.DataSource = null;


                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                for (int i = 0; i < lstRoomdiagram.Count; i++)
                {
                    collection.Add(lstRoomdiagram[i].ComputerName);
                    collection.Add(lstRoomdiagram[i].ComputerCode);

                }

                this.cmbKeyName.AutoCompleteCustomSource = collection;
                this.cmbKeyName.AutoCompleteMode = AutoCompleteMode.Suggest;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EXON.MONITOR.GUI.frmAddComputer frm = new GUI.frmAddComputer(_RoomDiagramID, true);
            frm.ShowDialog();
            InitDataControl();
        }
    }
    public enum StatusCom { error,ok};
    public class RoomDiagramFromRoomTest
    {
        public int RoomDiagramID { get; set; }
        public string ComputerCode { get; set; }
        public string ComputerName { get; set; }
          public int STT { get; set; }
        public string  Status { get; set; }
      
    }
}
