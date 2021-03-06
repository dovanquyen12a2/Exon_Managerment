﻿using EXON.Common;
using EXON.MONITOR.Common;
using EXON.SubModel.Models;
using Microsoft.Reporting.WinForms;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXON.MONITOR.Report
{
    public partial class FrmRpKetQuaKipThi : Form
    {
        MTAQuizDbContext db = new MTAQuizDbContext();

        private DIVISION_SHIFTS divisionShift = new DIVISION_SHIFTS();

        #region Hàm khởi tạo
        public FrmRpKetQuaKipThi(int divisionshiftID)
        {
            InitializeComponent();
            divisionShift = db.DIVISION_SHIFTS.Where(x => x.DivisionShiftID == divisionshiftID).SingleOrDefault();
        }
        #endregion

        #region LoadForm

        private bool ok(int x, DateTime k)
        {
            DateTime a = Common.DatetimeConvert.ConvertUnixToDateTime(x);

            if (a.Year != k.Year) return false;
            if (a.Month != k.Month) return false;
            if (a.Day != k.Day) return false;

            return true;
        }

        private string KetQua(CONTESTANT a)
        {
            try
            {
                CONTESTANTS_SHIFTS cs = db.CONTESTANTS_SHIFTS.Where(p => p.Status > 0 && p.DivisionShiftID == divisionShift.DivisionShiftID && p.ContestantID == a.ContestantID).FirstOrDefault();
                float diem = 0;
                try
                {

                    diem = (float)
                            (
                                from ct in db.CONTESTANTS_TESTS.Where(k => k.Status > 0 && k.ContestantShiftID == cs.ContestantShiftID).ToList()
                                from ans in db.ANSWERSHEETS.Where(k => k.ContestantTestID == ct.ContestantTestID).ToList()
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
            catch(Exception ex)
            {
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }

            return "-";
        }


        private int Conv(string a)
        {
            try
            {
                return Int32.Parse(a);
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
                db = new MTAQuizDbContext();
                // lấy thông tin của kip thi
                
                LOCATION diadiem = db.LOCATIONS.Where(p => p.LocationID == divisionShift.ROOMTEST.LocationID).FirstOrDefault();
                CONTEST kithi = db.CONTESTS.Where(p => p.ContestID == diadiem.ContestID).FirstOrDefault();
                // Lấy ra danh sách các thí sinh thi c
                List<CONTESTANTS_SHIFTS> listThiSinh = new List<CONTESTANTS_SHIFTS>();
                listThiSinh = db.CONTESTANTS_SHIFTS.Where(x => x.DivisionShiftID == divisionShift.DivisionShiftID && x.Status==3005).ToList();
                // Lấy ra kết quả thi
                int stt = 0;
                var listKetQua = listThiSinh
                                 .Select(p => new
                                 {
                                     STT = ++stt,
                                     SBD = p.CONTESTANT.ContestantCode,
                                     HoTen = p.CONTESTANT.FullName,
                                     NgaySinh = Common.DatetimeConvert.ConvertUnixToDateTime((int)p.CONTESTANT.DOB).ToString("dd/MM/yyyy"),

                                     MonThi = p.SCHEDULE.SUBJECT.SubjectName,
                                     DiemThi = KetQua(p.CONTESTANT),
                                     MaDe = GetTestID(p.ContestantShiftID),
                                     Unit = p.CONTESTANT.Unit
                                 })
                                 .ToList();
                ketQuaThiTheoCaThiBindingSource.DataSource = listKetQua;
                List<CONTESTANTS_SHIFTS> listThiSinhBoThi = new List<CONTESTANTS_SHIFTS>();
                listThiSinhBoThi = db.CONTESTANTS_SHIFTS.Where(x => x.DivisionShiftID == divisionShift.DivisionShiftID && x.Status == 4001).ToList();
                var lstThiSinhBoThi = listThiSinhBoThi
                                 .Select(p => new
                                 {
                                     STT = ++stt,
                                     SBD = p.CONTESTANT.ContestantCode,
                                     HoTen = p.CONTESTANT.FullName,
                                     NgaySinh = Common.DatetimeConvert.ConvertUnixToDateTime((int)p.CONTESTANT.DOB).ToString("dd/MM/yyyy"),
                                     CMND = p.CONTESTANT.IdentityCardNumber,
                                     MonThi = p.SCHEDULE.SUBJECT.SubjectName,
                                     Unit = p.CONTESTANT.Unit
                                 })
                                 .ToList();
                thiSinhBoThiBindingSource.DataSource = lstThiSinhBoThi;

                // add parameter
                ReportParameter[] listPara = new ReportParameter[]{
                    new ReportParameter("ContestName",kithi.ContestName.ToUpper()),
                    new ReportParameter("LocationName",diadiem.LocationName.ToUpper()),
                    new ReportParameter("RoomTestName",divisionShift.ROOMTEST.RoomTestName.ToLower()),
                     new ReportParameter("StartTime",Common.DatetimeConvert.ConvertUnixToDateTime(divisionShift.SHIFT.StartTime).ToString("HH: mm:ss")),
                     new ReportParameter("EndTime",Common.DatetimeConvert.ConvertUnixToDateTime(divisionShift.SHIFT.EndTime).ToString("HH: mm:ss")),
                    new ReportParameter("NgayThi",Common.DatetimeConvert.ConvertUnixToDateTime(divisionShift.SHIFT.ShiftDate).ToString("dd/MM/yyyy")),
                    new ReportParameter("Date",DateTime.Now.ToString(@"\n\g\à\y dd \t\h\á\n\g MM \n\ă\m yyyy"))
                };
                this.rpKetQuaKipThi.LocalReport.SetParameters(listPara);
                this.rpKetQuaKipThi.LocalReport.Refresh();
                this.rpKetQuaKipThi.RefreshReport();
            }
            catch (Exception ex)
            {
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

                MessageBox.Show(ex.Message);
            }
            this.rpKetQuaKipThi.LocalReport.Refresh();
            this.rpKetQuaKipThi.RefreshReport();
            this.rpKetQuaKipThi.RefreshReport();
        }

        private int GetTestID(int contestantShiftID)
        {
            db = new MTAQuizDbContext();
            CONTESTANTS_TESTS cts = new CONTESTANTS_TESTS();
            cts = db.CONTESTANTS_TESTS.Where(x => x.ContestantShiftID == contestantShiftID).SingleOrDefault();
            if(cts!=null)
            {
                return cts.TestID;
            }
            else
            {
                return -1;
            }
        }
        #endregion
    }
}
