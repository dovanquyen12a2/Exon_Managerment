﻿
using EXON.SubData.Services;
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

namespace EXON.GradedEssay.Report
{
    public partial class frmResultSumTNTL : Form
    {
        MTAQuizDbContext db = new MTAQuizDbContext();

        private DIVISION_SHIFTS divisionShift = new DIVISION_SHIFTS();
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
        private TestNumberService _TestNumberService;

        #endregion Service
        private int _SubjectID;
        private string _Unit;
        public frmResultSumTNTL(int SubjectID)
        {
         
            InitializeComponent();
            InitializeService();
            _SubjectID = SubjectID;
        }
        public frmResultSumTNTL(int divisionshiftID, int SubjectID)
        {
            InitializeComponent();
            InitializeService();
            _SubjectID = SubjectID;
            divisionShift = db.DIVISION_SHIFTS.Where(x => x.DivisionShiftID == divisionshiftID).SingleOrDefault();
        }

        public frmResultSumTNTL(int divisionshiftID, string unit)
        {
            InitializeComponent();
            InitializeService();
            _Unit = unit;
            divisionShift = db.DIVISION_SHIFTS.Where(x => x.DivisionShiftID == divisionshiftID).SingleOrDefault();
        }
        private void InitializeService()
        {
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
            _TestNumberService = new TestNumberService();
        }
        private string KetQua(int contestantShiftID)
        {

            CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID);
            if (ct != null)
            {
                ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);
                if (anw != null)
                {

                    ANSWERSHEET_WRITING anwritting = _AnswersheetWritingService.GetByAnwsersheetID(anw.AnswerSheetID);
                    if (anwritting != null)
                    {
                        return (anwritting.WritingScore + anw.TestScores).ToString();
                    }
                }


            }
            return string.Empty;
        }
        private string KetQua1(int contestantShiftID)
        {

            CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID);
            if (ct != null)
            {
                ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);
                if (anw != null)
                {
                    ANSWERSHEET_SPEAKING aw = _AnswersheetSpeakingService.GetByAnwsersheetID(anw.AnswerSheetID);

                    if (aw != null)
                    {
                        return (aw.SpeakingScore).ToString();
                    }
                }


            }
            return string.Empty;
        }
        private string KetQua2(int contestantShiftID)
        {

            CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID);
            if (ct != null)
            {
                ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);
                if (anw != null)
                {

                    ANSWERSHEET_WRITING anwritting = _AnswersheetWritingService.GetByAnwsersheetID(anw.AnswerSheetID);
                    if (anwritting != null)
                    {
                        return (anwritting.WritingScore).ToString();
                    }
                }


            }
            return string.Empty;
        }
        private string KetQua3(int contestantShiftID)
        {

            CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID);
            if (ct != null)
            {
                ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);
                if (anw != null)
                {

                    return (anw.TestScores).ToString();

                }


            }
            return string.Empty;
        }
        private string DiemLamTron(int contestantShiftID)
        {
            CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID);
            if (ct != null)
            {
                ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);
                if (anw != null)
                {

                    ANSWERSHEET_WRITING anwritting = _AnswersheetWritingService.GetByAnwsersheetID(anw.AnswerSheetID);
                    if (anwritting != null)
                    {
                        float sumscore =(float)(Math.Round(anwritting.WritingScore.Value + anw.TestScores.Value,2));
                       return LamTronSo(sumscore);
                    }
                    else
                    {
                        float sumscore = (float)(Math.Round( anw.TestScores.Value, 2));
                        return LamTronSo(sumscore);
                    }
                }


            }
            return string.Empty;
        }
        private string  LamTronSo ( float sumscore)
        {
            int multiplier = 100;
            float float_value = sumscore;
            int float_result = (int)((float_value - (int)float_value) * multiplier);
            if(float_result>=0&& float_result< 25)
            {
                int result = (int)float_value;
                return result.ToString();
            }
            else if (float_result >= 25 && float_result <75)
            {
                
                float result =(float)( (int)float_value + 0.5);
                return result.ToString();
            }
             else
            {
                int result = (int)float_value + 1;

                return result.ToString();
            }


        }
        private void frmResultSum_Load(object sender, EventArgs e)
        {
            try
            {
                if (divisionShift.DivisionShiftID>0)
                {
                    db = new MTAQuizDbContext();
                    // lấy thông tin của kip thi

                    LOCATION diadiem = db.LOCATIONS.Where(p => p.LocationID == divisionShift.ROOMTEST.LocationID).FirstOrDefault();
                    CONTEST kithi = db.CONTESTS.Where(p => p.ContestID == diadiem.ContestID).FirstOrDefault();
                    // Lấy ra danh sách các thí sinh thi c
                    List<CONTESTANTS_SHIFTS> listThiSinh = new List<CONTESTANTS_SHIFTS>();
                    listThiSinh = db.CONTESTANTS_SHIFTS.Where(x => x.DivisionShiftID == divisionShift.DivisionShiftID && x.Status == 3005).ToList();
                    // Lấy ra kết quả thi
                    int stt = 0;
                    string Monthi = "";
                    if (_SubjectID > 0)
                    {
                        var listKetQua = (
                           //from ds in _DivisionShiftService.GetByShift(CurrentShiftID)
                           from cs in _ContestantShiftService.GetAllByDivisionShiftID(divisionShift.DivisionShiftID).Where(x => x.Status == 3005 && x.SCHEDULE.SubjectID == _SubjectID)
                           from tn in _TestNumberService.GetAll()
                           where cs.ContestantShiftID == tn.ContestantShiftID
                           select new
                           {
                               STT = ++stt,
                               SBD = cs.CONTESTANT.ContestantCode,
                               HoTen = cs.CONTESTANT.FullName,
                               PhongThi = cs.DIVISION_SHIFTS.ROOMTEST.RoomTestName,
                               SoPhach = divisionShift.DivisionShiftID.ToString() + "." + tn.TestNumberIndex.ToString(),
                               NgaySinh = DatetimeConvert.ConvertUnixToDateTime((int)cs.CONTESTANT.DOB).ToString("dd/MM/yyyy"),
                               Phongthi = cs.DIVISION_SHIFTS.ROOMTEST.RoomTestName,
                               MonThi = cs.SCHEDULE.SUBJECT.SubjectName,
                               DiemViet = KetQua2(cs.ContestantShiftID),
                               DiemDoc = KetQua3(cs.ContestantShiftID),
                               DiemTong = KetQua(cs.ContestantShiftID),
                               Unit = cs.CONTESTANT.Unit,
                               DiemLamTron = DiemLamTron(cs.ContestantShiftID)
                           }).ToList();

                        KetQuaTongBindingSource.DataSource = listKetQua;
                        List<CONTESTANTS_SHIFTS> listThiSinhBoThi = new List<CONTESTANTS_SHIFTS>();
                        listThiSinhBoThi = db.CONTESTANTS_SHIFTS.Where(x => x.DivisionShiftID == divisionShift.DivisionShiftID && x.Status != 3005 && x.SCHEDULE.SubjectID == _SubjectID).ToList();
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
                                             Unit = p.CONTESTANT.Unit,

                                         })
                                         .ToList();
                        thiSinhBoThiBindingSource.DataSource = lstThiSinhBoThi;
                        if (listKetQua.Count > 0)
                        {
                            Monthi = listKetQua[0].MonThi;
                        }
                        else
                        {
                            Monthi = lstThiSinhBoThi[0].MonThi;
                        }

                    }
                    if (_Unit != string.Empty && _Unit != null)
                    {
                        var listKetQua = (
                        //from ds in _DivisionShiftService.GetByShift(CurrentShiftID)
                        from cs in _ContestantShiftService.GetAllByDivisionShiftID(divisionShift.DivisionShiftID).Where(x => x.Status == 3005 && x.CONTESTANT.Unit == _Unit)

                        from tn in _TestNumberService.GetAll()
                        where cs.ContestantShiftID == tn.ContestantShiftID
                        select new
                        {
                            STT = ++stt,
                            SBD = cs.CONTESTANT.ContestantCode,
                            HoTen = cs.CONTESTANT.FullName,
                            PhongThi = cs.DIVISION_SHIFTS.ROOMTEST.RoomTestName,
                            SoPhach = divisionShift.DivisionShiftID.ToString() + "." + tn.TestNumberIndex.ToString(),
                            NgaySinh = DatetimeConvert.ConvertUnixToDateTime((int)cs.CONTESTANT.DOB).ToString("dd/MM/yyyy"),
                            Phongthi = cs.DIVISION_SHIFTS.ROOMTEST.RoomTestName,

                            DiemViet = KetQua2(cs.ContestantShiftID),
                            DiemDoc = KetQua3(cs.ContestantShiftID),
                            DiemTong = KetQua(cs.ContestantShiftID),
                            Unit = cs.CONTESTANT.Unit,
                            MonThi = cs.SCHEDULE.SUBJECT.SubjectName,
                            DiemLamTron = DiemLamTron(cs.ContestantShiftID)
                        }).ToList();

                        KetQuaTongBindingSource.DataSource = listKetQua;
                        List<CONTESTANTS_SHIFTS> listThiSinhBoThi = new List<CONTESTANTS_SHIFTS>();
                        listThiSinhBoThi = db.CONTESTANTS_SHIFTS.Where(x => x.DivisionShiftID == divisionShift.DivisionShiftID && x.Status != 3005 && x.CONTESTANT.Unit == _Unit).ToList();
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
                                             Unit = p.CONTESTANT.Unit
                                         })
                                         .ToList();
                        thiSinhBoThiBindingSource.DataSource = lstThiSinhBoThi;
                        if (listKetQua.Count > 0)
                        {
                            Monthi = listKetQua[0].MonThi;
                        }
                        else
                        {
                            Monthi = lstThiSinhBoThi[0].MonThi;
                        }
                    }





                    // add parameter
                    ReportParameter[] listPara = new ReportParameter[]{
                    new ReportParameter("ContestName",kithi.ContestName.ToUpper()),
                        new ReportParameter("ShiftName", divisionShift.SHIFT.ShiftName),
                             new ReportParameter("ShiftName", divisionShift.SHIFT.ShiftName),
                                  new ReportParameter("StartDate", DatetimeConvert.ConvertUnixToDateTime(divisionShift.SHIFT.ShiftDate).ToString("dd/MM/yyyy")),
                    new ReportParameter("SubjectName",Monthi.ToUpper()),
                    new ReportParameter("RegisterDate",DatetimeConvert.GetDateTimeServer().ToString(@"\n\g\à\y dd \t\h\á\n\g MM \n\ă\m yyyy"))
                };
                    this.rpvSum.LocalReport.SetParameters(listPara);
                    this.rpvSum.LocalReport.Refresh();
                    this.rpvSum.RefreshReport();
                }
                else
                {
                    if (_SubjectID > 0)
                    {
                        db = new MTAQuizDbContext();
                        // lấy thông tin của kip thi

                        _ScheduleService = new ScheduleService();
                        SCHEDULE sc = new SCHEDULE();
                        sc = _ScheduleService.GetAll().Where(x => x.SubjectID == _SubjectID).SingleOrDefault();
                        CONTEST kithi = db.CONTESTS.Where(p => p.ContestID == sc.ContestID).FirstOrDefault();
                        // Lấy ra danh sách các thí sinh thi c

                        // Lấy ra kết quả thi
                        int stt = 0;
                        string Monthi = "";

                        var listKetQua = (

                       from cs in _ContestantShiftService.GetAll().Where(x => x.Status == 3005 && x.SCHEDULE.SubjectID == _SubjectID)

                       from tn in _TestNumberService.GetAll()
                       where cs.ContestantShiftID == tn.ContestantShiftID
                       select new
                       {
                           STT = ++stt,
                           SBD = cs.CONTESTANT.ContestantCode,
                           HoTen = cs.CONTESTANT.FullName,
                           PhongThi = cs.DIVISION_SHIFTS.ROOMTEST.RoomTestName,
                           SoPhach = divisionShift.DivisionShiftID.ToString() + "." + tn.TestNumberIndex.ToString(),
                           NgaySinh = DatetimeConvert.ConvertUnixToDateTime((int)cs.CONTESTANT.DOB).ToString("dd/MM/yyyy"),
                           Phongthi = cs.DIVISION_SHIFTS.ROOMTEST.RoomTestName,
                           DiemNoi = KetQua1(cs.ContestantShiftID),
                           DiemViet = KetQua2(cs.ContestantShiftID),
                           DiemDoc = KetQua3(cs.ContestantShiftID),
                           DiemTong = KetQua(cs.ContestantShiftID),
                           DiemLamTron = DiemLamTron(cs.ContestantShiftID),
                           MonThi = cs.SCHEDULE.SUBJECT.SubjectName,
                           Unit = cs.CONTESTANT.Unit
                       }).ToList();
                        KetQuaTongBindingSource.DataSource = listKetQua;
                        List<CONTESTANTS_SHIFTS> listThiSinhBoThi = new List<CONTESTANTS_SHIFTS>();
                        listThiSinhBoThi = db.CONTESTANTS_SHIFTS.Where(x => x.DivisionShiftID == divisionShift.DivisionShiftID && x.Status != 3005 && x.SCHEDULE.SubjectID == _SubjectID).ToList();
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
                                             Unit = p.CONTESTANT.Unit
                                         })
                                         .ToList();
                        thiSinhBoThiBindingSource.DataSource = lstThiSinhBoThi;
                        if (listKetQua.Count > 0)
                        {
                            Monthi = listKetQua[0].MonThi;
                        }
                        else
                        {
                            Monthi = lstThiSinhBoThi[0].MonThi;
                        }
                        ReportParameter[] listPara = new ReportParameter[]{
                    new ReportParameter("ContestName",kithi.ContestName.ToUpper()),
                        new ReportParameter("ShiftName", ""),
                             new ReportParameter("ShiftName", ""),
                                  new ReportParameter("StartDate", ""),
                    new ReportParameter("SubjectName",Monthi.ToUpper()),
                    new ReportParameter("RegisterDate",DatetimeConvert.GetDateTimeServer().ToString(@"\n\g\à\y dd \t\h\á\n\g MM \n\ă\m yyyy"))
                };
                        this.rpvSum.LocalReport.SetParameters(listPara);
                        this.rpvSum.LocalReport.Refresh();
                        this.rpvSum.RefreshReport();
                    }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.rpvSum.LocalReport.Refresh();
            this.rpvSum.RefreshReport();
            this.rpvSum.RefreshReport();
            this.rpvSum.RefreshReport();
        }
    }
}