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
using MetroFramework.Forms;
namespace QuanLyHoiDongThiVer2.GUI
{
    public partial class FrmTrangThaiPhongThi : MetroForm
    {
        private MTAQuizDbContext db = DAO.DBService.db;
        private DIVISION_SHIFTS dv = new DIVISION_SHIFTS();
        private int indexGT = 0, indexGT1 = 0;
        private int indexTS = 0, indexTS1 = 0;

        #region constructor
        public FrmTrangThaiPhongThi()
        {
            InitializeComponent();
            DAO.DBService.Reload();
        }

        public FrmTrangThaiPhongThi(DIVISION_SHIFTS tg)
        {
            InitializeComponent();
            DAO.DBService.Reload();
            dv = tg;
        }
        #endregion

        #region LoadForm

        private void LoadInitControl()
        {
            // contest name
            CONTEST contest = (
                                from rt in db.ROOMTESTS.Where(p => p.RoomTestID == dv.RoomTestID).ToList()
                                from lc in db.LOCATIONS.Where(p => p.LocationID == rt.LocationID).ToList()
                                from ct in db.CONTESTS.Where(p => p.ContestID == lc.ContestID).ToList()
                                select ct
                                )
                                .ToList()
                                .FirstOrDefault();
            txtContestName.Text = contest.ContestName.ToUpper();

            // location name
            txtLocationName.Text = (
                                    from rt in db.ROOMTESTS.Where(p => p.RoomTestID == dv.RoomTestID)
                                    from lc in db.LOCATIONS.Where(p => p.LocationID == rt.LocationID)
                                    select lc
                                    )
                                    .ToList()
                                    .FirstOrDefault()
                                    .LocationName
                                    .ToUpper();

            // Roomtest name
            txtRoomTestName.Text = db.ROOMTESTS.Where(p => p.RoomTestID == dv.RoomTestID).FirstOrDefault().RoomTestName.ToUpper();

            // shift
            SHIFT shift = db.SHIFTS.Where(p => p.ShiftID == dv.ShiftID).FirstOrDefault();
            txtShiftName.Text = shift.ShiftName.ToUpper();
            txtShiftDate.Text = DAO.Helper.ConvertUnixToDateTime((int)shift.ShiftDate).ToString("dd/MM/yyyy");
            txtBatDau.Text = DAO.Helper.ConvertUnixToDateTime((int)shift.StartTime).ToString("HH:mm");
            txtKetThuc.Text = DAO.Helper.ConvertUnixToDateTime((int)shift.EndTime).ToString("HH:mm");

            // txtStatus
            txtStatus.Text = DAO.Helper.TrangThaiPhongThi(dv.Status);
        }

        private void LoadDgvGiamThi()
        {
            int i = 1;
            dgvGiamThi.DataSource = (
                                        from pc in db.DIVISIONSHIFT_SUPERVISOR.Where(p => p.DivisionShiftID == dv.DivisionShiftID).ToList()
                                        from nv in db.EXAMINATIONCOUNCIL_STAFFS.Where(nv => nv.ExaminationCouncil_StaffID == pc.SupervisorID).ToList()
                                        select new
                                        {
                                            ID = pc.DivisionShift_SupervisorID,
                                            STT = i++,
                                            HoTen = nv.STAFF.FullName
                                        }
                                    )
                                    .ToList();

            // Load Index
            try
            {
                indexGT = indexGT1;
                dgvGiamThi.Rows[indexGT].Cells["STTGiamThi"].Selected = true;
                dgvGiamThi.Select();
            }
            catch { }
        }

        private void LoadDgvThiSinh()
        {
            int i = 1;
            dgvThiSinh.DataSource = (
                                        from lt in db.CONTESTANTS_SHIFTS.Where(p => p.DivisionShiftID == dv.DivisionShiftID && p.Status > 0).ToList()
                                        from ts in db.CONTESTANTS.Where(p => p.Status > 0 && p.ContestantID == lt.ContestantID).ToList()
                                        from mtkt in db.SCHEDULES.Where(p => p.Status > 0 && p.ScheduleID == lt.ScheduleID).ToList()
                                        from mt in db.SUBJECTS.Where(p => p.Status > 0 && p.SubjectID == mtkt.SubjectID).ToList()
                                        select new
                                        {
                                            ID = lt.ContestantID,
                                            STT = i++,
                                            HoTen = ts.FullName,
                                            MonThi = mt.SubjectName,
                                            NgaySinh = DAO.Helper.ConvertUnixToDateTime((int)ts.DOB).ToString("dd/MM/yyyy"),
                                            QueQuan = ts.PlaceOfBirth,
                                            ThoiGian = mtkt.TimeOfTest / 60 + " phút",
                                            TrangThai = DAO.Helper.TrangThaiThiSinh(lt.Status)

                                        }
                                    )
                                    .ToList();

            // Load Index
            try
            {
                indexTS = indexTS1;
                dgvThiSinh.Rows[indexTS].Cells["STTThiSinh"].Selected = true;
                dgvThiSinh.Select();
            }
            catch { }
        }

        private void Loadz()
        {
            LoadInitControl();
            LoadDgvGiamThi();
            LoadDgvThiSinh();
            timer1.Start();
        }
        private void FrmTrangThaiPhongThi_Load(object sender, EventArgs e)
        {
            Loadz();
        }
        #endregion

        #region Sự kiện ngầm
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (txtStatus.ForeColor == Color.Green)
                txtStatus.ForeColor = Color.Red;
            else
                txtStatus.ForeColor = Color.Green;
            Loadz();
        }

        private void FrmTrangThaiPhongThi_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }
        #endregion

        #region sự kiện
        private void dgvGiamThi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGiamThi.SelectedRows.Count < 1) return;
            try
            {
                indexGT1 = indexGT;
                indexGT = dgvGiamThi.SelectedRows[0].Index;
            }
            catch { }
        }

        private void dgvThiSinh_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvThiSinh.SelectedRows.Count < 1) return;
            try
            {
                indexTS1 = indexTS;
                indexTS = dgvThiSinh.SelectedRows[0].Index;
            }
            catch { }
        }
        #endregion


    }
}
