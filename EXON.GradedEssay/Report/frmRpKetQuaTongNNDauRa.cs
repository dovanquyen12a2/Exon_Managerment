
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
    public partial class frmRpKetQuaTongNNDauRa : Form
    {

        MTAQuizDbContext db = new MTAQuizDbContext();

       
        #region Service
     
        private IContestantShiftService _ContestantShiftService;
        private IContestantService _ContestantService;
        private IContestantTestService _ContestantTestService;
        private IAnswersheetService _AnswersheetService;
        private IAnswersheetSpeakingService _AnswersheetSpeakingService;
        private IAnswersheetWritingService _AnswersheetWritingService;
        private IBagOfTestService _BagOfTestService;
        private ITestService _TestService;
        private IRoomTestService _RoomTestService;
        private ITestNumberService _TestNumberService;
        private IAnswersheetDetailService _AnswersheetDetailService;
        private IAnswerService _AnswerService;
        #endregion Service

     
        private string _Unit;
        private int _LocationID;
        public frmRpKetQuaTongNNDauRa(int LocationID, string unit)
        {
            InitializeComponent();
            InitializeService();
            _LocationID = LocationID;
            _Unit = unit;
         
        }
        private void InitializeService()
        {
           
            _ContestantTestService = new ContestantTestService();
            _AnswersheetService = new AnswersheetService();
            _AnswersheetSpeakingService = new AnswersheetSpeakingService();
            _BagOfTestService = new BagOfTestService();
            _TestService = new TestService();
            _RoomTestService = new RoomTestService();
            _AnswersheetWritingService = new AnswersheetWritingService();
            _TestNumberService = new TestNumberService();
            _AnswersheetDetailService = new AnswersheetDetailService();
        }

        private float KetQuaTong(int contestantShiftID)
        {
            _ContestantTestService = new ContestantTestService();
            CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID);
            if (ct != null)
            {
                _AnswersheetService = new AnswersheetService();
                _AnswersheetSpeakingService = new AnswersheetSpeakingService();
                _AnswersheetWritingService = new AnswersheetWritingService();
                float result = 0;
                ANSWERSHEET anw = new ANSWERSHEET();
                  anw=  _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);
                if (anw != null)
                {
                    ANSWERSHEET_SPEAKING aw = _AnswersheetSpeakingService.GetByAnwsersheetID(anw.AnswerSheetID);
                    ANSWERSHEET_WRITING anwritting = _AnswersheetWritingService.GetByAnwsersheetID(anw.AnswerSheetID);
                    if (aw != null && anwritting != null)
                        if (aw.SpeakingScore != null && anwritting.WritingScore != null)
                        {

                            return (float)(aw.SpeakingScore + anwritting.WritingScore + anw.TestScores);
                        }
                        else if (aw.SpeakingScore == null && anwritting.WritingScore != null)
                        {
                            return (float)(anwritting.WritingScore + anw.TestScores);
                        }
                        else if (aw.SpeakingScore != null && anwritting.WritingScore == null)
                        {
                            if (anw.TestScores == null)
                            {
                                return (float)(aw.SpeakingScore);
                            }

                            return (float)(aw.SpeakingScore + anw.TestScores);
                        }
                        else
                        {
                            if (anw.TestScores == null)
                            {
                                return 0;
                            }
                            return (float)(anw.TestScores);
                        }
                    else if (aw != null && anwritting == null)
                        if (aw.SpeakingScore != null)
                        {

                            return (float)(aw.SpeakingScore + anw.TestScores);
                        }
                        else
                        {
                            if (anw.TestScores == null)
                            {
                                return 0;
                            }
                            return (float)(anw.TestScores);
                        }
                    else if (aw == null && anwritting != null)
                        if (anwritting.WritingScore != null)
                        {

                            return (float)(anwritting.WritingScore + anw.TestScores);
                        }
                        else
                        {
                            if (anw.TestScores == null)
                            {
                                return 0;
                            }
                            return (float)(anw.TestScores);
                        }
                    else if (aw == null && anwritting == null)
                    {
                        if (anw.TestScores == null)
                        {
                            return 0;
                        }
                        return (float)(anw.TestScores);
                    }

                }
                //else
                //{
                //    ANSWERSHEET_SPEAKING aw = _AnswersheetSpeakingService.GetByAnwsersheetID(anw.AnswerSheetID);
                //    ANSWERSHEET_WRITING anwritting = _AnswersheetWritingService.GetByAnwsersheetID(anw.AnswerSheetID);
                //    if (aw != null && anwritting != null)
                //        if (aw.SpeakingScore != null && anwritting.WritingScore != null)
                //        {

                //            return (float)(aw.SpeakingScore + anwritting.WritingScore + anw.TestScores);
                //        }
                //        else if (aw.SpeakingScore == null && anwritting.WritingScore != null)
                //        {
                //            return (float)(anwritting.WritingScore);
                //        }
                //        else if (aw.SpeakingScore != null && anwritting.WritingScore == null)
                //        {

                //            return (float)(aw.SpeakingScore);

                //        }
                //        else
                //        {
                //            return 0;

                //        }
                //    else if (aw != null && anwritting == null)
                //        if (aw.SpeakingScore != null)
                //        {

                //            return (float)(aw.SpeakingScore);
                //        }
                //        else
                //        {

                //            return 0;

                //        }
                //    else if (aw == null && anwritting != null)
                //        if (anwritting.WritingScore != null)
                //        {

                //            return (float)(anwritting.WritingScore + anw.TestScores);
                //        }
                //        else
                //        {

                //            return 0;

                //        }
                //    else if (aw == null && anwritting == null)
                //    {

                //        return 0;

                //    }
                //}


            }
            return 0;
        }
        private float KetQuaNghe(int contestantShiftID)
        {

            _ContestantTestService = new ContestantTestService();
            CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID);

            if (ct != null)
            {
                _AnswersheetService = new AnswersheetService();
                _AnswersheetSpeakingService = new AnswersheetSpeakingService();
                _AnswersheetWritingService = new AnswersheetWritingService();
                ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);
                float SumSCore = 0;
                if (anw != null)
                {
                    int ansID;
                    _AnswersheetDetailService = new AnswersheetDetailService();
                    List<ANSWERSHEET_DETAILS> lstaws = _AnswersheetDetailService.getAllByAnswerID(anw.AnswerSheetID).ToList();
                    ANSWER aw = new ANSWER();
                    foreach (ANSWERSHEET_DETAILS item in lstaws)
                    {
                        ansID = item.ChoosenAnswer ?? default(int);
                        _AnswerService = new AnswerService();
                        aw = _AnswerService.GetById(ansID);
                        if (aw != null)
                        {
                            if (aw.IsCorrect && aw.SUBQUESTION.QUESTION.Audio != null)
                            {
                                SumSCore += (float)Math.Round(aw.SUBQUESTION.Score.Value, 2);
                            }
                        }
                    }
                    return SumSCore;

                }


            }

            return 0;
        }
        private float KetQuaNoi(int contestantShiftID)
        {

            _ContestantTestService = new ContestantTestService();
            CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID);
            if (ct != null)
            {
                _AnswersheetService = new AnswersheetService();
                _AnswersheetSpeakingService = new AnswersheetSpeakingService();
                _AnswersheetWritingService = new AnswersheetWritingService();
                ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);
                if (anw != null)
                {
                    ANSWERSHEET_SPEAKING aw = _AnswersheetSpeakingService.GetByAnwsersheetID(anw.AnswerSheetID);

                    if (aw != null)
                    {
                        if (aw.SpeakingScore == null)
                            return 0;
                        return (float)(aw.SpeakingScore);
                    }
                }


            }
            return 0;
        }
        private float KetQuaViet(int contestantShiftID)
        {

            _ContestantTestService = new ContestantTestService();
            CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID);
            if (ct != null)
            {
                _AnswersheetService = new AnswersheetService();
                _AnswersheetSpeakingService = new AnswersheetSpeakingService();
                _AnswersheetWritingService = new AnswersheetWritingService();
                ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);
                
                if (anw != null)
                {

                    ANSWERSHEET_WRITING anwritting = _AnswersheetWritingService.GetByAnwsersheetID(anw.AnswerSheetID);
                    if (anwritting != null)
                    {
                        if (anwritting.WritingScore == null)
                            return 0;
                        return (float)(anwritting.WritingScore);
                    }
                }


            }
            return 0;
        }
        private float KetQuaTracNghiem(int contestantShiftID)
        {

            _ContestantTestService = new ContestantTestService();
            CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID);
            if (ct != null)
            {
                ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);
                if (anw != null)
                {

                    if (anw.TestScores == null)
                        return 0;
                    return (float)(anw.TestScores);

                }


            }
            return 0;
        }

        private string DiemLamTron(int contestantShiftID)
        {
            CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID);
            if (ct != null)
            {
                ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);
                if (anw != null)
                {
                    _AnswersheetSpeakingService = new AnswersheetSpeakingService();
                    _AnswersheetWritingService = new AnswersheetWritingService();
                    ANSWERSHEET_SPEAKING aw = _AnswersheetSpeakingService.GetByAnwsersheetID(anw.AnswerSheetID);
                    ANSWERSHEET_WRITING anwritting = _AnswersheetWritingService.GetByAnwsersheetID(anw.AnswerSheetID);
                    if (aw != null && anwritting != null)
                    {
                        float sumscore = (float)(Math.Round(aw.SpeakingScore.Value + anwritting.WritingScore.Value + anw.TestScores.Value, 2));
                        return LamTronSo(sumscore);
                    }
                }


            }
            return string.Empty;
        }
        private string LamTronSo(float sumscore)
        {
            int multiplier = 100;
            float float_value = sumscore;
            int float_result = (int)((float_value - (int)float_value) * multiplier);
            if (float_result >= 0 && float_result < 25)
            {
                int result = (int)float_value;
                return result.ToString();
            }
            else if (float_result >= 25 && float_result < 75)
            {

                float result = (float)((int)float_value + 0.5);
                return result.ToString();
            }
            else
            {
                int result = (int)float_value + 1;

                return result.ToString();
            }


        }
        private void FrmRpKetQuaTongNNDauRa_Load(object sender, EventArgs e)
        {
            try
            {
                
                    db = new MTAQuizDbContext();
                    // lấy thông tin của kip thi

                    LOCATION diadiem = db.LOCATIONS.Where(p => p.LocationID == _LocationID).FirstOrDefault();
                    CONTEST kithi = db.CONTESTS.Where(p => p.ContestID == diadiem.ContestID).FirstOrDefault();
                    // Lấy ra danh sách các thí sinh thi c
                 
                 
                    string Monthi = "";
                   
                   if (_Unit != string.Empty)
                    {
                        _ContestantService = new ContestantService();
                        List<CONTESTANT> lstct = new List<CONTESTANT>();
                        lstct = _ContestantService.GetMultiByUnit(_Unit).ToList();
                        List<KetQuaTongNNDauRa> lstKQ = new List<KetQuaTongNNDauRa>();
                    int stt = 1;
                    foreach (CONTESTANT ct in lstct)
                        {
                            
                            float TongDiem = 0;
                            List<CONTESTANTS_SHIFTS> lstcs = new List<CONTESTANTS_SHIFTS>();
                            _ContestantShiftService = new ContestantShiftService();
                            KetQuaTongNNDauRa kq = new KetQuaTongNNDauRa();
                            lstcs = _ContestantShiftService.GetAllByContestantID(ct.ContestantID).ToList();
                            foreach (CONTESTANTS_SHIFTS cs in lstcs)
                            {
                                //if (cs.SCHEDULE.SUBJECT.SubjectCode == "TTN_TN_CB" || cs.SCHEDULE.SUBJECT.SubjectCode == "TTN_TA_CB")
                                //{
                                    kq.STT = stt;
                                    kq.HoTen = ct.FullName;
                                    kq.SBD = ct.ContestantCode;
                                    kq.NgaySinh = DatetimeConvert.ConvertUnixToDateTime(ct.DOB.Value).ToString("dd/MM/yyyy");
                                    kq.PhongThi = cs.DIVISION_SHIFTS.ROOMTEST.RoomTestName;
                                    kq.Unit = ct.Unit;
                                 kq.DiemNghe = KetQuaNghe(cs.ContestantShiftID);
                                kq.DiemDoc = ((KetQuaTracNghiem(cs.ContestantShiftID))-kq.DiemNghe).ToString();
                                  
                                    kq.DiemNoi = KetQuaNoi(cs.ContestantShiftID).ToString();
                                    kq.DiemViet = KetQuaViet(cs.ContestantShiftID).ToString();
                                    TongDiem +=  KetQuaTong(cs.ContestantShiftID);

                                //}
                                //else
                                //{
                                //    kq.DiemDocCN = KetQuaTracNghiem(cs.ContestantShiftID).ToString();
                                //    kq.DiemVietCN = KetQuaViet(cs.ContestantShiftID).ToString();
                                //    TongDiem += KetQuaTong(cs.ContestantShiftID);

                                //}

                            }
                            kq.DiemTongCNCB = TongDiem.ToString();
                            lstKQ.Add(kq);
                            stt++;
                        }



                    KetQuaTongBindingSource.DataSource = lstKQ;
                    // add parameter
                    ReportParameter[] listPara = new ReportParameter[]{
                    new ReportParameter("ContestName",kithi.ContestName.ToUpper()),
                      
                 
                    new ReportParameter("RegisterDate",DatetimeConvert.GetDateTimeServer().ToString(@"\n\g\à\y dd \t\h\á\n\g MM \n\ă\m yyyy"))
                };
                    this.rpvSum.LocalReport.SetParameters(listPara);
                    this.rpvSum.LocalReport.Refresh();
                    this.rpvSum.RefreshReport();
                }
                
                




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }
     
    }
    public class KetQuaTongNNDauRa
    {
        public int STT { get; set; }
        public string SBD { get; set; }
        public string HoTen { get; set; }
        public string PhongThi { get; set; }
 
        public string NgaySinh { get; set; }
        public string DiemNoi { get; set; }
        public float DiemNghe { get; set; }
        public string DiemViet { get; set; }
        public string DiemDoc { get; set; }

        public string DiemDocCN { get; set; }
        public string DiemVietCN { get; set; }
        public string DiemTongCNCB { get; set; }

        public string MonThi { get; set; }
        
        public string Unit { get; set; }
                         
    }
}
