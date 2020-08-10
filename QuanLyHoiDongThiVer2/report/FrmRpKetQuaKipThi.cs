using EXON.SubModel.Models;
using Microsoft.Reporting.WinForms;
using QuanLyHoiDongThiVer2.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHoiDongThiVer2.report
{
    public partial class FrmRpKetQuaKipThi : Form
    {
        private MTAQuizDbContext db = DAO.DBService.db;
        private ROOMTEST phongthi = new ROOMTEST();
        private DateTime ngaythi = new DateTime();
        private int kip = 0;
        private KhoiThi khoithi = new KhoiThi();

        #region Hàm khởi tạo
        public FrmRpKetQuaKipThi(ROOMTEST _phongthi, DateTime _ngay, int _kip, KhoiThi kt)
        {
            InitializeComponent();

            phongthi = _phongthi;
            ngaythi = _ngay;
            kip = _kip;
            khoithi = kt;

            DAO.DBService.Reload();
        }
        #endregion

        #region LoadForm

        private bool ok(int x, DateTime k)
        {
            DateTime a = DAO.Helper.ConvertUnixToDateTime(x);

            if (a.Year != k.Year) return false;
            if (a.Month != k.Month) return false;
            if (a.Day != k.Day) return false;

            return true;
        }

        private String KetQua(CONTESTANT a, SUBJECT b)
        {
            try
            {
                // lấy thông tin của kip thi
                LOCATION diadiem = db.LOCATIONS.Where(p => p.LocationID == phongthi.LocationID).FirstOrDefault();
                CONTEST kithi = db.CONTESTS.Where(p => p.ContestID == diadiem.ContestID).FirstOrDefault();

                SCHEDULE sch = db.SCHEDULES.Where(p => p.Status > 0 && p.ContestID == kithi.ContestID && p.SubjectID == b.SubjectID).FirstOrDefault();
                CONTESTANTS_SHIFTS cs = db.CONTESTANTS_SHIFTS.Where(p => p.Status > 0 && p.ScheduleID == sch.ScheduleID && p.ContestantID == a.ContestantID).FirstOrDefault();

                float diem = 0;
                try
                {
                    diem = (float)
                            (
                                from ct in db.CONTESTANTS_TESTS.Where(k => k.Status > 0 && k.ContestantShiftID == cs.ContestantShiftID).ToList()
                                from ans in db.ANSWERSHEETS.Where(k => k.ContestantTestID == ct.ContestantTestID && k.Status > 0).ToList()
                                select ans
                            )
                            .FirstOrDefault()
                            .TestScores;
                }
                catch
                {
                    diem = 0;
                }

                return diem.ToString();
            }
            catch
            {

            }

            return "-";
        }

        
        private float Conv(string a)
        {
            try
            {
                return float.Parse(a);
            }
            catch
            {
                return 0;
            }
        }

        private string DiemTong(string a, string b, string c)
        {
            if (a == "-" && b == "-" && c == "-") return "-";
            return (Conv(a) + Conv(b) + Conv(c)).ToString();  
        }

        private void FrmRpKetQuaKipThi_Load(object sender, EventArgs e)
        {
            try
            {
                // lấy thông tin của kip thi
                LOCATION diadiem = db.LOCATIONS.Where(p => p.LocationID == phongthi.LocationID).FirstOrDefault();
                CONTEST kithi = db.CONTESTS.Where(p => p.ContestID == diadiem.ContestID).FirstOrDefault();

                // Lấy ra 3 ca thi đầu tiên
                var listCaThi = db.SHIFTS.Where(p => p.ContestID == kithi.ContestID && p.Status > 0).ToList()
                                .Where(p => ok(p.ShiftDate, ngaythi) && p.StartTime >= 43200 * kip && p.StartTime < 43200 * (kip + 1))
                                .Take(3)
                                .ToList();
                if (listCaThi.Count != 3) return;
              //  bool checkDate = ok(p.ShiftDate, ngaythi);
                // Lấy ra danh sách các ca thời gian của kíp thi
                var listDv = (
                                    from dv in db.DIVISION_SHIFTS.Where(p => p.StartTime >= 43200 * kip && p.StartTime < 43200 * (kip + 1)&& p.Status > 0 && p.RoomTestID == phongthi.RoomTestID).ToList()
                                    .Where(p => ok(p.StartDate.Value, ngaythi))
                                    select dv
                                 ).ToList();
                if (listDv.Count != 3) return;

                // Lấy ra danh sách môn thi
                var listMonThi = khoithi.listMonThi;
 
                // Lấy ra danh sách các thí sinh thi cả 3 môn
                List<CONTESTANT> listThiSinh = new List<CONTESTANT>();
                foreach (var ts in db.CONTESTANTS.ToList())
                {
                    // Check xem thí sinh có thi cả 3 môn không
                    bool oll = true;
                    DIVISION_SHIFTS dvShift;
                    SUBJECT monthi;
                    for (int i = 0; i < 3; i++)
                    {
                        dvShift = listDv[i];
                        monthi = listMonThi[i];
                        SCHEDULE sche = db.SCHEDULES.Where(p => p.ContestID == kithi.ContestID && p.Status > 0 && p.SubjectID == monthi.SubjectID).FirstOrDefault();
                        int cnt = db.CONTESTANTS_SHIFTS.Where(p => p.DivisionShiftID == dvShift.DivisionShiftID && p.ContestantID == ts.ContestantID && p.ScheduleID == sche.ScheduleID).ToList().Count;
                        if (cnt == 0)
                        {
                            oll = false;
                            break;
                        }
                    }

                    // nếu thí sinh thi cả 3 môn
                    if (oll == true) listThiSinh.Add(ts);
                }

                // Lấy ra kết quả thi
                int stt = 0;
                var listKetQua = listThiSinh
                                 .Select(p => new
                                 {
                                     STT = ++stt,
                                     SBD = p.ContestantCode,
                                     HoTen = p.FullName,
                                     NgaySinh = DAO.Helper.ConvertUnixToDateTime((int)p.DOB).ToString("dd/MM/yyyy"),
                                     GioiTinh = ((int)p.Sex == 0) ? "Nữ" : "Nam",
                                     MonThi1 = KetQua(p, listMonThi[0]),
                                     MonThi2 = KetQua(p, listMonThi[1]),
                                     MonThi3 = KetQua(p, listMonThi[2]),
                                     Tong = DiemTong(KetQua(p, listMonThi[0]),KetQua(p, listMonThi[1]),KetQua(p, listMonThi[2]))
                                 })
                                 .ToList();
                KetQuaTheoKipBindingSource.DataSource = listKetQua;


                // add parameter
                ReportParameter[] listPara = new ReportParameter[]{
                    new ReportParameter("ContestName",kithi.ContestName.ToUpper()),
                    new ReportParameter("LocationName",diadiem.LocationName.ToUpper()),
                    new ReportParameter("RoomTestName",phongthi.RoomTestName.ToLower()),
                    new ReportParameter("NgayThi",ngaythi.ToString("dd/MM/yyyy")),
                    new ReportParameter("KipThi", (kip == 0) ? "Sáng" : "Chiều"),
                    new ReportParameter("MonThi1", listMonThi[0].SubjectName),
                    new ReportParameter("MonThi2", listMonThi[1].SubjectName),
                    new ReportParameter("MonThi3", listMonThi[2].SubjectName),
                    new ReportParameter("Date",DateTime.Now.ToString(@"\n\g\à\y dd \t\h\á\n\g MM \n\ă\m yyyy"))
                };
                this.rpKetQuaKipThi.LocalReport.SetParameters(listPara);
                this.rpKetQuaKipThi.LocalReport.Refresh();
                this.rpKetQuaKipThi.RefreshReport();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            this.rpKetQuaKipThi.LocalReport.Refresh();
            this.rpKetQuaKipThi.RefreshReport();
        }
        #endregion
    }
}
