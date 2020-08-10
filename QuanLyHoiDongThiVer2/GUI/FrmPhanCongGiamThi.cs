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

namespace QuanLyHoiDongThiVer2.GUI
{
    public partial class FrmPhanCongGiamThi : Form
    {
        private MTAQuizDbContext db = DAO.DBService.db;
      
        private int index = 0, index1 = 0;
        private int _LocationID;
        #region Constructor
        public FrmPhanCongGiamThi()
        {
            InitializeComponent();
            DAO.DBService.Reload();
        }

        public FrmPhanCongGiamThi(int LocationID)
        {
            InitializeComponent();
            DAO.DBService.Reload();
            _LocationID = LocationID;
        }
        #endregion

        #region LoadForm

        private void LoadInitControl()
        {
          
            // cbxDivisionShift
            cbxDivisionShiftID.DataSource = (
                                    from dv in db.DIVISION_SHIFTS.Where(p => p.Status > 0).ToList()
                                    from rt in db.ROOMTESTS.Where(p => p.LocationID == _LocationID && p.Status > 0).ToList()
                                    where dv.RoomTestID == rt.RoomTestID
                                    select new
                                    {
                                        DivisionShiftID = dv.DivisionShiftID,
                                        Name = "Phòng " + rt.RoomTestName + " " + db.SHIFTS.Where(p=>p.ShiftID == dv.ShiftID).FirstOrDefault().ShiftName
                                    }
                                 )
                                 .ToList();
            cbxDivisionShiftID.DisplayMember = "Name";
            cbxDivisionShiftID.ValueMember = "DivisionShiftID";

            // thong tin ca thi
            //DIVISION_SHIFTS Dv = db.DIVISION_SHIFTS.Where(p => p.DivisionShiftID == (int)cbxDivisionShiftID.SelectedValue).FirstOrDefault();
            //SHIFT shift = db.SHIFTS.Where(p => p.ShiftID == Dv.ShiftID).FirstOrDefault();
            //txtShiftDate.Text = DAO.Helper.ConvertUnixToDateTime(shift.ShiftDate).ToString("dd/MM/yyyy");
            //txtStartTime.Text = DAO.Helper.ConvertUnixToDateTime(shift.StartTime).ToString("HH:mm");
            //txtEndTime.Text = DAO.Helper.ConvertUnixToDateTime(shift.EndTime).ToString("HH:mm");
                                  
            //cbxGiamThi
            cbxSupervisorID.DataSource = (
                                            from st in db.STAFFS.Where(p => p.Status > 0).ToList()
                                            from pc in db.EXAMINATIONCOUNCIL_STAFFS.Where(p => p.Status > 0 && p.LocationID == _LocationID).ToList()
                                            where st.StaffID == pc.StaffID
                                            select new {
                                                FullName = st.FullName,
                                                ExaminationCouncil_StaffID= pc.ExaminationCouncil_StaffID
                                            } 
                                        ).ToList();
            cbxSupervisorID.DisplayMember = "FullName";
            cbxSupervisorID.ValueMember = "ExaminationCouncil_StaffID";

            // group Thong tin
            groupThongTin.Enabled = false;
        }

        private void LoadDgv()
        {
          
    
            try
            {
                db = new MTAQuizDbContext();
                int i = 1;
                dgvPhanCongGiamThi.DataSource = (
                                                    from pc in db.DIVISIONSHIFT_SUPERVISOR.ToList()
                                                    from dv in db.DIVISION_SHIFTS.Where(p => p.Status > 0).ToList()
                                                    where pc.DivisionShiftID == dv.DivisionShiftID
                                                    from rt in db.ROOMTESTS.Where(p => p.Status > 0 && p.LocationID == _LocationID).ToList()
                                                    where rt.RoomTestID == dv.RoomTestID
                                                    select new
                                                    {
                                                        ID = pc.DivisionShift_SupervisorID,
                                                        STT = i++,
                                                        TenCanBo = pc.EXAMINATIONCOUNCIL_STAFFS.STAFF.FullName,
                                                        PhongThi = rt.RoomTestName,
                                                        CaThi = dv.SHIFT.ShiftName
                                                    }
                                                )
                                                .ToList();
                // cập nhật lại chỉ
                index = index1;
                dgvPhanCongGiamThi.Rows[index].Selected = true;
                dgvPhanCongGiamThi.Select();
            }
            catch
            {

            }
        }
        private void FrmPhanCongGiamThi_Load(object sender, EventArgs e)
        {
            LoadInitControl();
            LoadDgv();
        }
        #endregion

        #region sự kiện ngầm
        private void cbxDivisionShiftID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DIVISION_SHIFTS dv = db.DIVISION_SHIFTS.Where(p => p.DivisionShiftID == (int)cbxDivisionShiftID.SelectedValue).FirstOrDefault();
                SHIFT shift = db.SHIFTS.Where(p => p.ShiftID == dv.ShiftID).FirstOrDefault();
                txtShiftDate.Text = DAO.Helper.ConvertUnixToDateTime(shift.ShiftDate).ToString("dd/MM/yyyy");
                txtStartTime.Text = DAO.Helper.ConvertUnixToDateTime(shift.StartTime).ToString("HH:mm");
                txtEndTime.Text = DAO.Helper.ConvertUnixToDateTime(shift.EndTime).ToString("HH:mm");
            }
            catch
            {

            }
        }

        private void dgvPhanCongGiamThi_SelectionChanged(object sender, EventArgs e)
        {
            UpdateThongTin();
        }
        #endregion

        #region Hàm chức năng
        private void ClearControl()
        {
            cbxDivisionShiftID.SelectedIndex = 0;
            cbxSupervisorID.SelectedIndex = 0;
        }

        private void UpdateThongTin()
        {
            try
            {
                DIVISIONSHIFT_SUPERVISOR tg = GetPCWithID();
                cbxSupervisorID.SelectedValue = tg.SupervisorID;
                cbxDivisionShiftID.SelectedValue = tg.DivisionShiftID;

                index1 = index;
                index = dgvPhanCongGiamThi.SelectedRows[0].Index;
            }
            catch
            {

            }
        }

        private bool Check()
        {
            int cnt;
            DIVISIONSHIFT_SUPERVISOR tg = GetPCWithGroupThongTin();

            cnt = db.DIVISIONSHIFT_SUPERVISOR.Where(p => p.SupervisorID == tg.SupervisorID && p.DivisionShiftID == tg.DivisionShiftID)
                  .ToList().Count;
            if (cnt > 0)
            {
                MessageBox.Show("Giám thị này đã được phân công ở ca thi này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private bool CheckALL(int DivsionShiftID, int SupervisorID)
        {
            int cnt;
          
            cnt = db.DIVISIONSHIFT_SUPERVISOR.Where(p => p.SupervisorID == SupervisorID && p.DivisionShiftID == DivsionShiftID)
                  .ToList().Count;
            if (cnt > 0)
            {
                MessageBox.Show("Giám thị này đã được phân công ở ca thi này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private DIVISIONSHIFT_SUPERVISOR GetPCWithID()
        {
            try
            {
                int id = (int) dgvPhanCongGiamThi.SelectedRows[0].Cells["ID"].Value;
                return db.DIVISIONSHIFT_SUPERVISOR.Where(p => p.DivisionShift_SupervisorID == id).FirstOrDefault();
            }
            catch
            {
                return new DIVISIONSHIFT_SUPERVISOR();
            }
        }

        private DIVISIONSHIFT_SUPERVISOR GetPCWithGroupThongTin()
        {
            DIVISIONSHIFT_SUPERVISOR ans = new DIVISIONSHIFT_SUPERVISOR();
            ans.DivisionShiftID = (int) cbxDivisionShiftID.SelectedValue;
            ans.SupervisorID = (int)cbxSupervisorID.SelectedValue;
            return ans;
        }

        #endregion

        #region sự kiện
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm phân công")
            {
                btnThem.Text = "Lưu";
                btnXoa.Text = "Hủy";

                groupThongTin.Enabled = true;
                dgvPhanCongGiamThi.Enabled = false;

                ClearControl();
                return;
            }

            if (btnThem.Text == "Lưu")
            {
                if(rbAll.Checked)
                {
                    List<int> lstDivionshiftID = (from dv in db.DIVISION_SHIFTS.Where(p => p.Status > 0).ToList()
                                                  from rt in db.ROOMTESTS.Where(p => p.LocationID == _LocationID && p.Status > 0).ToList()
                                                  where dv.RoomTestID == rt.RoomTestID
                                                  select new
                                                  {
                                                      dv.DivisionShiftID
                                                     
                                                  }).Select(x=>x.DivisionShiftID).ToList();

                    int SupervsionID = (int)cbxSupervisorID.SelectedValue;
                    foreach( int dsID in lstDivionshiftID )
                    {
                       
                        if(CheckALL(dsID,SupervsionID))
                        {
                            DIVISIONSHIFT_SUPERVISOR tg =new DIVISIONSHIFT_SUPERVISOR();
                            tg.DivisionShiftID = dsID;
                            tg.SupervisorID = SupervsionID;
                            db.DIVISIONSHIFT_SUPERVISOR.Add(tg);
                            db.SaveChanges();
                        }

                    }
                    btnThem.Text = "Thêm phân công";
                    btnXoa.Text = "Xóa phân công";

                    groupThongTin.Enabled = false;
                    dgvPhanCongGiamThi.Enabled = true;
                  
                    MessageBox.Show("Thêm thông tin phân công thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgv();
                    return;
                }
                if (Check())
                {
                    btnThem.Text = "Thêm phân công";
                    btnXoa.Text = "Xóa phân công";

                    groupThongTin.Enabled = false;
                    dgvPhanCongGiamThi.Enabled = true;

                    DIVISIONSHIFT_SUPERVISOR tg = GetPCWithGroupThongTin();
                    db.DIVISIONSHIFT_SUPERVISOR.Add(tg);
                    db.SaveChanges();

                    MessageBox.Show("Thêm thông tin phân công thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgv();
                }
                return;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (btnXoa.Text == "Xóa phân công")
            {
                DIVISIONSHIFT_SUPERVISOR tg = GetPCWithID();
                if (tg.DivisionShift_SupervisorID == 0)
                {
                    MessageBox.Show("Chưa có phân công nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult rs = MessageBox.Show("Đồng chí có chắc chắn xóa phân công này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                if (rs == DialogResult.Cancel) return;

                db.DIVISIONSHIFT_SUPERVISOR.Remove(tg);
                db.SaveChanges();

                MessageBox.Show("Xóa thông tin phân công thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDgv();

                return;
            }

            if (btnXoa.Text == "Hủy")
            {
                btnXoa.Text = "Xóa phân công";
                btnThem.Text = "Thêm phân công";

                dgvPhanCongGiamThi.Enabled = true;
                groupThongTin.Enabled = false;

                UpdateThongTin();
                return;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }
    }
}
