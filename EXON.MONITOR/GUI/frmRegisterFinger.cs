using MetroFramework.Forms;

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
using EXON.MONITOR.Common;
using EXON.SubData.Services;
namespace EXON.MONITOR.GUI
{
    public partial class frmRegisterFinger : MetroForm
    {
        private int _shiftID = 0;
        private List<CONTESTANTDGV> lstInDGV;

        private ContestantService _ContestantService;
        private ContestantShiftService _ContestantShiftService;
        private RoomTestService _RoomTestService;
        private int currentcontestantID = 0;
        public frmRegisterFinger(int shiftID)
        {
            InitializeComponent();
            _ContestantService = new ContestantService();
            _ContestantShiftService = new ContestantShiftService();
            _RoomTestService = new RoomTestService();
            _shiftID = shiftID;
        }

        private void GetfingerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmIdentifyFinger frm = new frmIdentifyFinger(currentcontestantID, _shiftID);
            //frm.ShowDialog();
            //LoadDGV();
        }

        private void frmRegisterFinger_Load(object sender, EventArgs e)
        {
            LoadDGV();
            LoadCombox();
        }

        private void LoadDGV()
        {
           
            List<CONTESTANT> lstContestant = _ContestantShiftService.GetlistContestantByShitfID(_shiftID);
            lstInDGV = new List<CONTESTANTDGV>();
            int count = 0;
            if (lstContestant != null)
            {
                lstInDGV.AddRange(from obj in lstContestant
                                  select new CONTESTANTDGV
                                  {
                                      FullName = obj.FullName,
                                      DOB = obj.DOB.HasValue ? Common.DatetimeConvert.ConvertUnixToDateTime(obj.DOB.Value).Date.ToString("dd/MM/yyyy") : "",
                                      Sex = obj.Sex == 0 ? "Nữ" : "Nam",
                                      IdentityCardNumber = obj.IdentityCardNumber,
                                      StudentCode = obj.StudentCode,
                                      ContestantID = obj.ContestantID,
                                      ContestantCode = obj.ContestantCode,
                                      STT = ++count,
                                      Room = GetRoom(obj.ContestantID),
                                      IsImage = GetIsImage(obj.Image),
                                      IsGetFingerPrinter = IsFinger(obj.ContestantID)
                                  });
            }
            dgvMain.DataSource = lstInDGV;
            PaintDGV();
        }

        private void PaintDGV()
        {
            for (int i = 0; i < dgvMain.Rows.Count; i++)
            {
                dgvMain.Rows[i].DefaultCellStyle.BackColor = Color.White;
                dgvMain.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                if (!(bool)dgvMain.Rows[i].Cells["cIsGetFinger"].Value)
                {
                    if (!(bool)dgvMain.Rows[i].Cells["cIsImage"].Value)
                    {
                        dgvMain.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                    }
                    else
                    {
                        dgvMain.Rows[i].DefaultCellStyle.ForeColor = Color.DarkBlue;
                    }
                }
                else
                {
                    if (!(bool)dgvMain.Rows[i].Cells["cIsImage"].Value)
                    {
                        dgvMain.Rows[i].DefaultCellStyle.ForeColor = Color.DarkGreen;
                    }
                }
            }
        }

        private string GetRoom(int contestantid)
        {
            ROOMTEST room = _ContestantShiftService.GetContestantShiftByShiftAndContestant(contestantid, _shiftID).ROOMDIAGRAM.ROOMTEST;
            if (room != null)
            {
                return room.RoomTestName;
            }
            else return "";
        }

        private bool GetIsImage(byte[] im)
        {
            if (im.Length > 0)
                return true;
            else return false;
        }

        private bool IsFinger(int regID)
        {
            CONTESTANT con;
            MTAQuizDbContext db = new MTAQuizDbContext();
            con = db.CONTESTANTS.Where(x => x.ContestantID == regID).FirstOrDefault();
            if (con == null)
                return false;
            else
            {
                int count = con.FINGERPRINTS.ToList().Count;
                if (count > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        private void LoadCombox()
        {
            if (lstInDGV != null)
            {
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                for (int i = 0; i < lstInDGV.ToList().Count; i++)
                {
                    collection.Add(lstInDGV.ToList()[i].FullName);
                    collection.Add(lstInDGV.ToList()[i].IdentityCardNumber);
                    collection.Add(lstInDGV.ToList()[i].StudentCode);
                    collection.Add(lstInDGV.ToList()[i].ContestantCode);
                }

                this.cmbKeyName.AutoCompleteCustomSource = collection;
                this.cmbKeyName.AutoCompleteMode = AutoCompleteMode.Suggest;
            }
        }

        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvMain.CurrentRow.Selected = true;
            }
            catch
            { }

            if (e.ColumnIndex != 0)
                return;
        }

        private void dgvMain_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    int rowSelected = e.RowIndex;
            //    if (e.RowIndex != -1)
            //    {
            //        //dgvMain.CurrentCell = dgvMain.Rows[rowSelected].Cells[0];
            //        //dgvMain.SelectedRows.Clear();
            //        this.dgvMain.Rows[rowSelected].Selected = true;
            //    }
            //    // you now have the selected row with the context menu showing for the user to delete etc.
            //}
        }

        private void dgvMain_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvMain.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            if (!(bool)dgvMain.Rows[e.RowIndex].Cells["cIsGetFinger"].Value)
            {
                if (!(bool)dgvMain.Rows[e.RowIndex].Cells["cIsImage"].Value)
                {
                    dgvMain.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.IndianRed;
                }
                else
                {
                    dgvMain.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkBlue;
                }
            }
            else
            {
                if (!(bool)dgvMain.Rows[e.RowIndex].Cells["cIsImage"].Value)
                {
                    dgvMain.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkGreen;
                }
            }
        }

        private void dgvMain_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //dgvMain.CurrentRow.Selected = true; //dữ liệu đc chọn cả dòng
                currentcontestantID = int.Parse(dgvMain.CurrentRow.Cells["cContestantID"].Value.ToString());
            }
            catch
            { }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<CONTESTANTDGV> lst = lstInDGV.Where(x => x.FullName.Contains(cmbKeyName.Text) || x.IdentityCardNumber.Contains(cmbKeyName.Text) || x.StudentCode.Contains(cmbKeyName.Text) || (x.ContestantCode != null && x.ContestantCode.Contains(cmbKeyName.Text))).ToList();
            dgvMain.DataSource = lst;
            PaintDGV();
        }

        private void cmbKeyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(sender, e);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (dgvMain.DataSource == null) return;

            string NeedStatus = string.Empty;
            if (rbtnLostImage.Checked)
            {
                dgvMain.DataSource = lstInDGV.Where(z => z.IsImage == false && z.ContestantID != 0).ToList();
            }
            else if (rbtnAll.Checked)
            {
                NeedStatus = string.Empty;
                dgvMain.DataSource = lstInDGV.ToList();
            }
            else if (rbtnNotgetFinger.Checked)
            {
                dgvMain.DataSource = lstInDGV.Where(z => z.IsGetFingerPrinter == false).ToList();
            }
            PaintDGV();
        }

        private void UpdateInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegister frm = new frmRegister(currentcontestantID);
            frm.ShowDialog();
            LoadDGV();
        }
    }

    public class CONTESTANTDGV
    {
        public int ContestantID { get; set; }
        public string ContestantCode { get; set; }
        public string FullName { get; set; }
        public string DOB { get; set; }
        public string Sex { get; set; }
        public string IdentityCardNumber { get; set; }
        public string StudentCode { get; set; }
        public int STT { get; set; }
        public bool IsImage { get; set; }
        public string Room { get; set; }
        public bool IsGetFingerPrinter { get; set; }
    }
}