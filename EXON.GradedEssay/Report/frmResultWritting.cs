
using EXON.GradedEssay;
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
using EXON.SubData.Services;
namespace EXON.GradedEssay.Report
{
    public partial class frmResultWritting : Form
    {
        MTAQuizDbContext db = new MTAQuizDbContext();

        private DIVISION_SHIFTS divisionShift = new DIVISION_SHIFTS();
        private ISubjectService _SubjectService;
        private int _subjectID;
        public frmResultWritting(int divisionshiftID,int SubjectID)
        {
            InitializeComponent();
            divisionShift = db.DIVISION_SHIFTS.Where(x => x.DivisionShiftID == divisionshiftID).SingleOrDefault();
            _subjectID = SubjectID;
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
                                from answ in db.ANSWERSHEET_WRITING.Where(k=>k.AnswerSheetID==ans.AnswerSheetID)
                                select answ
                            )
                            .FirstOrDefault()
                            .WritingScore;
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
        private void frmResultWritting_Load(object sender, EventArgs e)
        {

            try
            {
                db = new MTAQuizDbContext();
                // lấy thông tin của kip thi

                LOCATION diadiem = db.LOCATIONS.Where(p => p.LocationID == divisionShift.ROOMTEST.LocationID).FirstOrDefault();
                CONTEST kithi = db.CONTESTS.Where(p => p.ContestID == diadiem.ContestID).FirstOrDefault();
                // Lấy ra danh sách các thí sinh thi c
                List<CONTESTANTS_SHIFTS> listThiSinh = new List<CONTESTANTS_SHIFTS>();
                listThiSinh = db.CONTESTANTS_SHIFTS.Where(x => x.DivisionShiftID == divisionShift.DivisionShiftID && x.Status == 3005 &&x.SCHEDULE.SubjectID==_subjectID).ToList();
                // Lấy ra kết quả thi
                int stt = 0;
                var listKetQua = listThiSinh
                                 .Select(p => new
                                 {
                                     STT = ++stt,
                                     SBD = p.CONTESTANT.ContestantCode,
                                     HoTen = p.CONTESTANT.FullName,
                                     NgaySinh = DatetimeConvert.ConvertUnixToDateTime((int)p.CONTESTANT.DOB).ToString("dd/MM/yyyy"),
                                     MonThi = p.SCHEDULE.SUBJECT.SubjectName,
                                     DiemThi = KetQua(p.CONTESTANT),                                    
                                 })
                                 .ToList();
                ThiSinhDangKyBindingSource.DataSource = listKetQua;
                List<CONTESTANTS_SHIFTS> listThiSinhBoThi = new List<CONTESTANTS_SHIFTS>();
                listThiSinhBoThi = db.CONTESTANTS_SHIFTS.Where(x => x.DivisionShiftID == divisionShift.DivisionShiftID && x.Status != 3005 && x.SCHEDULE.SubjectID == _subjectID).ToList();
                stt = 0;
                var lstThiSinhBoThi = listThiSinhBoThi
                                 .Select(p => new
                                 {
                                     STT = ++stt,
                                     SBD = p.CONTESTANT.ContestantCode,
                                     HoTen = p.CONTESTANT.FullName,
                                     NgaySinh = DatetimeConvert.ConvertUnixToDateTime((int)p.CONTESTANT.DOB).ToString("dd/MM/yyyy"),
                                     CMND = p.CONTESTANT.IdentityCardNumber,
                                     MonThi = p.SCHEDULE.SUBJECT.SubjectName,
                                 })
                                 .ToList();
                thiSinhBoThiBindingSource.DataSource = lstThiSinhBoThi;
                SUBJECT sj = new SUBJECT();
                _SubjectService = new SubjectService();
                sj = _SubjectService.GetById(_subjectID);
                // add parameter
                ReportParameter[] listPara = new ReportParameter[]{
                    new ReportParameter("ContestName",kithi.ContestName.ToUpper()),
                    new ReportParameter("SubjectName",sj.SubjectName),
                    new ReportParameter("RegisterDate",DatetimeConvert.GetDateTimeServer().ToString(@"\n\g\à\y dd \t\h\á\n\g MM \n\ă\m yyyy"))
                };
                this.rpvWritting.LocalReport.SetParameters(listPara);
                this.rpvWritting.LocalReport.Refresh();
                this.rpvWritting.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.rpvWritting.LocalReport.Refresh();
            this.rpvWritting.RefreshReport();
            this.rpvWritting.RefreshReport();
        }
        private int GetTestID(int contestantShiftID)
        {
            db = new MTAQuizDbContext();
            CONTESTANTS_TESTS cts = new CONTESTANTS_TESTS();
            cts = db.CONTESTANTS_TESTS.Where(x => x.ContestantShiftID == contestantShiftID).SingleOrDefault();
            if (cts != null)
            {
                return cts.TestID;
            }
            else
            {
                return -1;
            }
        }
    }
}
