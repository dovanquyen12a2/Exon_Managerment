using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyHoiDongThiVer2.report;
using QuanLyHoiDongThiVer2.DTO;
using EXON.SubModel.Models;

namespace QuanLyHoiDongThiVer2.GUI
{
    public partial class ucTrangThaiDiaDiem : UserControl
    {
        private MTAQuizDbContext db = DAO.DBService.db;
        private LOCATION diadiem = new LOCATION();

        #region Hàm khởi tạo
        public ucTrangThaiDiaDiem(LOCATION a)
        {
            InitializeComponent();
            diadiem = a;
            DAO.DBService.Reload();
        }

        #endregion

        #region LoadForm
        private void LoadDgvPhongThi()
        {
            try
            {
                int stt = 0;
                var listPhongThi = db.ROOMTESTS.Where(p => p.LocationID == diadiem.LocationID).ToList()
                                   .Select(p => new
                                   {
                                       ID = p.RoomTestID,
                                       STT = ++stt,
                                       TenPhong = p.RoomTestName,
                                       SoCho = p.MaxSeatMount
                                   })
                                   .ToList();
                dgvPhongThi.DataSource = listPhongThi;
            }
            catch { }
        }

        private void LoadInitControl()
        {
            try
            {
                CONTEST kithi = db.CONTESTS.Where(p => p.ContestID == diadiem.ContestID && p.Status > 0).FirstOrDefault();
                DateTime dt = DAO.Helper.ConvertUnixToDateTime((int)kithi.CreatedQuestionEndDate);
                dateNgayThi.Value = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);

                cbxKip.SelectedIndex = 0;
            }
            catch { }
        }

        private void LoadDgvCaThi()
        {
            // 43200 là 12 giờ trưa

            try
            {
                CONTEST kithi = db.CONTESTS.Where(p => p.ContestID == diadiem.ContestID).FirstOrDefault();
                int stt = 0;
                var listCaThi = db.SHIFTS.Where(p => p.ContestID == kithi.ContestID && p.Status > 0).ToList()
                                .Where(p => ok(p.ShiftDate, dateNgayThi.Value) && p.StartTime >= 43200 * cbxKip.SelectedIndex && p.StartTime < 43200 * (cbxKip.SelectedIndex + 1))
                                .ToList()
                                .Select(p => new
                                {
                                    ID = p.ShiftID,
                                    STT = ++stt,
                                    TenCaThi = p.ShiftName,
                                    NgayThi = DAO.Helper.ConvertUnixToDateTime(p.ShiftDate).ToString("dd/MM/yyyy"),
                                    BatDau = DAO.Helper.ConvertUnixToDateTime(p.StartTime).ToString("HH:mm"),
                                    KetThuc = DAO.Helper.ConvertUnixToDateTime(p.EndTime).ToString("HH:mm")
                                })
                                .ToList();

                dgvCaThi.DataSource = listCaThi;
            }
            catch
            {

            }
        }

        List<KhoiThi> listKhoiThi = new List<KhoiThi>();
        private void LoadKhoiThi()
        {
            try
            {
                listKhoiThi = new List<KhoiThi>();

                // Lấy ra phòng thi
                int RoomtestID = (int)dgvPhongThi.SelectedRows[0].Cells["IDPhongThi"].Value;
                ROOMTEST phongthi = db.ROOMTESTS.Where(p => p.RoomTestID == RoomtestID).FirstOrDefault();
                DateTime ngaythi = dateNgayThi.Value;
                int kip = cbxKip.SelectedIndex;

                // lấy thông tin của kip thi
                LOCATION diadiem = db.LOCATIONS.Where(p => p.LocationID == phongthi.LocationID).FirstOrDefault();
                CONTEST kithi = db.CONTESTS.Where(p => p.ContestID == diadiem.ContestID).FirstOrDefault();

                // Lấy ra 3 ca thi đầu tiên
                //var listCaThi = db.SHIFTS.Where(p => p.ContestID == kithi.ContestID && p.Status > 0).ToList()
                //                .Where(p => ok(p.ShiftDate, ngaythi) && p.StartTime >= 43200 * kip && p.StartTime < 43200 * (kip + 1))
                //                .Take(3)
                //                .ToList();
                //if (listCaThi.Count != 3) return;

                // Lấy ra danh sách các ca thời gian của kíp thi
                var listDv = (
                                    
                                    from dv in db.DIVISION_SHIFTS.Where(p => p.Status > 0  && p.RoomTestID == phongthi.RoomTestID).ToList()
                                    .Where(p => ok(p.StartDate.Value, ngaythi) && p.StartTime >= 43200 * kip && p.StartTime < 43200 * (kip + 1))
                                    select dv
                                 ).ToList();
                if (listDv.Count != 3) return;

                // Lấy ra danh sách môn thi
                var listMonThi = listDv
                                .Select(p => db.CONTESTANTS_SHIFTS.Where(z => z.DivisionShiftID == p.DivisionShiftID).FirstOrDefault())
                                .Select(p => db.SCHEDULES.Where(z => z.ScheduleID == p.ScheduleID).FirstOrDefault())
                                .Select(p => db.SUBJECTS.Where(z => z.SubjectID == p.SubjectID).FirstOrDefault())
                                .ToList();

                // Lấy ra danh sách các thí sinh thi cả 3 ca
                foreach (var ts in db.CONTESTANTS.ToList())
                {
                    // Lấy ra khối thi mà thí sinh đó thi trong 3 ca thời gian
                    KhoiThi khoithi = new KhoiThi();

                    bool oll = true;
                    DIVISION_SHIFTS dvShift;
                    for (int i = 0; i < 3; i++)
                    {
                        dvShift = listDv[i];
                        CONTESTANTS_SHIFTS lichthi = db.CONTESTANTS_SHIFTS.ToList()
                                                    .Where(p => p.Status > 0 && p.DivisionShiftID == dvShift.DivisionShiftID && p.ContestantID == ts.ContestantID)
                                                    .ToList().FirstOrDefault();
                        if (lichthi == null || lichthi.ContestantShiftID == 0)
                        {
                            // nếu thí sinh này không thi môn nào trong ca này
                            oll = false;
                            break;
                        }

                        SCHEDULE t = db.SCHEDULES.Where(p => p.ScheduleID == lichthi.ScheduleID).FirstOrDefault();
                        SUBJECT monthi = db.SUBJECTS.Where(p => p.SubjectID == t.SubjectID).FirstOrDefault();
                        khoithi.listMonThi.Add(monthi);
                        khoithi.Cnt_MonThi++;
                    }

                    int dem = listKhoiThi.Where(p => p.str == khoithi.toString()).ToList().Count;
                    if (dem > 0) oll = false;

                    if (oll == true)
                    {

                        khoithi.ID = listKhoiThi.Count;
                        khoithi.str = khoithi.toString();
                        listKhoiThi.Add(khoithi);
                    }
                }

                // Gán giá trị của combobox
                cbxKhoiThi.DataSource = listKhoiThi.ToList();
                cbxKhoiThi.ValueMember = "ID";
                cbxKhoiThi.DisplayMember = "str";
            }
            catch
            {

            }
        }
        private void ucTrangThaiDiaDiem_Load(object sender, EventArgs e)
        {
            LoadInitControl();
            LoadDgvPhongThi();
            LoadDgvCaThi();
            LoadKhoiThi();
        }
        #endregion

        #region sự kiện ngầm
        private void dateNgayThi_ValueChanged(object sender, EventArgs e)
        {
            LoadDgvCaThi();
            LoadKhoiThi();
        }

        private void cbxKip_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDgvCaThi();
            LoadKhoiThi();
        }
        #endregion

        #region Hàm chức năng
        private bool ok(int x, DateTime k)
        {
            DateTime a = DAO.Helper.ConvertUnixToDateTime(x);

            if (a.Year != k.Year) return false;
            if (a.Month != k.Month) return false;
            if (a.Day != k.Day) return false;

            return true;
        }

        private DIVISION_SHIFTS GetDivisionShiftWithiD()
        {
            try
            {
                int shiftID, RoomtestID;
                shiftID = (int)dgvCaThi.SelectedRows[0].Cells["IDCaThi"].Value;
                RoomtestID = (int)dgvPhongThi.SelectedRows[0].Cells["IDPhongThi"].Value;
                return db.DIVISION_SHIFTS.Where(p => p.Status > 0 && p.ShiftID == shiftID && p.RoomTestID == RoomtestID).First();
            }
            catch { }
            return new DIVISION_SHIFTS();
        }

        #endregion

        #region Sự kiện
        private void btnTrangThaiPhongThi_Click(object sender, EventArgs e)
        {
            DIVISION_SHIFTS dv = GetDivisionShiftWithiD();
            if (dv.DivisionShiftID == 0)
            {
                MessageBox.Show("Chưa có ca thi nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmTrangThaiPhongThi tg = new FrmTrangThaiPhongThi(dv);
            tg.ShowDialog();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            int RoomtestID = (int)dgvPhongThi.SelectedRows[0].Cells["IDPhongThi"].Value;
            ROOMTEST phongthi = db.ROOMTESTS.Where(p => p.RoomTestID == RoomtestID).FirstOrDefault();
            KhoiThi kt = listKhoiThi.Where(p => p.ID == (int)cbxKhoiThi.SelectedValue).FirstOrDefault();

            if (kt == null)
            {
                MessageBox.Show("Chưa có khối thi nào đưược chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmRpKetQuaKipThi form = new FrmRpKetQuaKipThi(phongthi, dateNgayThi.Value, cbxKip.SelectedIndex, kt);
            form.ShowDialog();
        }
        #endregion
    }
}
