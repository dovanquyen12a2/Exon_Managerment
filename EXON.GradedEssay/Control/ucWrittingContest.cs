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
using EXON.Common;
using EXON.SubModel.Models;


namespace EXON.GradedEssay.Control
{
    public partial class ucWrittingContest : UserControl
    {
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
        private BagOfTestService _BagOfTestService;
        private TestService _TestService;
        private RoomTestService _RoomTestService;
        private TestNumberService _TestNumberService;
        private AnswersheetWritingService _AnswersheetWritingService;
        #endregion Service
        private int CurrentSubjectID
        {
            get
            {
                try
                {
                    return int.Parse(cbSubject.SelectedValue.ToString());
                }
                catch { return -1; }
            }
        }
        private int _ContestID { get; set; }
        private int _LocationID { get; set; }
        public ucWrittingContest(int contestID,int LocationID)
        {
            _ContestID = contestID;
            _LocationID = LocationID;
            InitializeComponent();
            InitializeService();
            InitializeControl();
        }

        private void InitializeControl()
        {
            try
            {
                _ContestantService = new ContestantService();
                _ContestantShiftService = new ContestantShiftService();
                _TestNumberService = new TestNumberService();
                _ScheduleService = new ScheduleService();
                cbSubject.DataSource =( from sj in _SubjectService.GetAll().ToList()
                                       from sch in _ScheduleService.GetAll().ToList()
                                       where sj.SubjectID == sch.SubjectID && sch.ContestID == _ContestID
                                       select new
                                       {
                                           SubjectName = sj.SubjectName,
                                           SubjectID = sj.SubjectID
                                       }).ToList();
                                       
                cbSubject.DisplayMember = "SubjectName";
                cbSubject.ValueMember = "SubjectID";
            
              
            }
            catch
            {
            }

        }
        private string GetScore(int contestantShiftID)
        {
            if (contestantShiftID > 0)
            {
                CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID);
                if (ct != null)
                {
                    ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);
                    if (anw != null)
                    {
                        ANSWERSHEET_WRITING aw = _AnswersheetWritingService.GetByAnwsersheetID(anw.AnswerSheetID);
                        if (aw != null)
                        {
                            return aw.WritingScore.ToString();
                        }
                    }
                }
            }
            return string.Empty;
        }
        private void InitializeService()
        {
            _TestNumberService = new TestNumberService();

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
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
           
            if (gvMain.DataSource != null)
            {
                int index = 0;
                foreach (DataGridViewRow row in gvMain.Rows)
                {
                    try
                    {
                        int contestantShiftID = int.Parse(row.Cells["cContestantShiftID"].Value.ToString());

                        string v = row.Cells["cScore"].Value.ToString();
                        float score;

                        // score = int.Parse(v);
                        CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID);
                        if (ct != null)
                        {
                            ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);

                            if (anw != null)
                            {
                                if (v != "")

                                    if (v.IndexOf('.') >= 0) score = float.Parse(v);
                                    else score = int.Parse(v);
                                else continue;

                                ANSWERSHEET_WRITING aw = _AnswersheetWritingService.GetByAnwsersheetID(anw.AnswerSheetID);
                                if (aw != null)
                                {
                                    aw.WritingScore = score;
                                    aw.Status++;


                                    _AnswersheetWritingService.Update(aw);
                                }
                                else
                                {
                                    aw = new ANSWERSHEET_WRITING
                                    {

                                        AnswerSheetID = anw.AnswerSheetID,
                                        WritingScore = score,
                                        Status = 1
                                    };

                                    _AnswersheetWritingService.Add(aw);
                                    _AnswersheetWritingService.Save();


                                }



                            }
                            else
                            {
                                //MessageBox.Show(string.Format("Thí sinh {0} bỏ thi.", row.Cells["cTestNumberIndex"].Value.ToString()), "Thông Báo");
                                continue;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Thí sinh chưa được phát đề", "Thông báo");

                            Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_FATAL, string.Format("Contestant Test is null with ContestantShiftID = {0}", contestantShiftID));
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lối định dạng điểm thi hoặc ô để trống.", "Lối");

                        gvMain.ClearSelection();
                        gvMain.Rows[index].Selected = true;

                        Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Error when convert string to numver: {0}", ex.Message));
                        return;
                    }
                    index++;
                }
                _AnswersheetWritingService.Save();

                MessageBox.Show("Nhập điểm thành công.", "Thông báo");
            }
        }

        private void cbSubject_SelectedValueChanged(object sender, EventArgs e)
        {
            if(CurrentSubjectID!=-1)
            {
                _ContestantService = new ContestantService();
                _ContestantShiftService = new ContestantShiftService();
                _TestNumberService = new TestNumberService();
            
                List<ContestantWrittingResultContest> lstContestantShift = new List<ContestantWrittingResultContest>();
                lstContestantShift = (from cs in _ContestantShiftService.GetAll().Where(x=>x.SCHEDULE.SubjectID == CurrentSubjectID && x.SCHEDULE.ContestID ==_ContestID && x.DIVISION_SHIFTS.ROOMTEST.LocationID== _LocationID)                                 
                                      from tn in _TestNumberService.GetAll().Where(x=>x.ContestantShiftID == cs.ContestantShiftID)
                                      select new ContestantWrittingResultContest
                                      {                                     
                                          SoPhach = cs.DivisionShiftID.ToString() + "." + tn.TestNumberIndex.ToString(),
                                          ShiftName = cs.DIVISION_SHIFTS.SHIFT.ShiftName,
                                          PhongThi = cs.DIVISION_SHIFTS.ROOMTEST.RoomTestName,      
                                          Score = GetScore(cs.ContestantShiftID),
                                          ContestantShiftID = cs.ContestantShiftID,
                                      }
                                         ).OrderBy(x => x.SoPhach).ToList();
                gvMain.DataSource = lstContestantShift;
            }
        }

        private void GvMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (gvMain.CurrentRow != null)
                {

                    try
                    {
                        int contestantShiftID = int.Parse(gvMain.CurrentRow.Cells["cContestantShiftID"].Value.ToString());

                        string v = gvMain.CurrentRow.Cells["cScore"].Value.ToString();

                        float score = 0;
                        // score = int.Parse(v);
                        CONTESTANTS_TESTS ct = _ContestantTestService.GetByContestantShiftId(contestantShiftID);
                        if (ct != null)
                        {
                            _AnswersheetService = new AnswersheetService();
                            ANSWERSHEET anw = _AnswersheetService.GetByContestantTestID(ct.ContestantTestID);

                            if (anw != null)
                            {
                                if (v != "")

                                    if (v.IndexOf('.') >= 0) score = float.Parse(v);
                                    else score = int.Parse(v);


                                ANSWERSHEET_WRITING aw = _AnswersheetWritingService.GetByAnwsersheetID(anw.AnswerSheetID);
                                if (aw != null)
                                {
                                    aw.WritingScore = score;
                                    aw.Status++;
                                    _AnswersheetWritingService.Update(aw);
                                }
                                else
                                {
                                    aw = new ANSWERSHEET_WRITING
                                    {

                                        AnswerSheetID = anw.AnswerSheetID,
                                        WritingScore = score,
                                        Status = 1
                                    };

                                    _AnswersheetWritingService.Add(aw);
                                    _AnswersheetWritingService.Save();


                                }
                                _AnswersheetWritingService.Save();

                              //  MessageBox.Show("Nhập điểm thành công.", "Thông báo");

                            }
                            else
                            {

                                MessageBox.Show(string.Format("Thí sinh {0} bỏ thi.", gvMain.CurrentRow.Cells["cTestNumberIndex"].Value.ToString()), "Thông Báo");

                            }
                        }
                        else
                        {
                            MessageBox.Show("Thí sinh chưa được phát đề", "Thông báo");
                            Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_FATAL, string.Format("Contestant Test is null with ContestantShiftID = {0}", contestantShiftID));
                            return;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lối định dạng điểm thi ", "Lối");

                        gvMain.ClearSelection();

                        Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Error when convert string to numver: {0}", ex.Message));
                        return;
                    }
                }
            }
            catch
            {

            }
        }
    }
    public class ContestantWrittingResultContest
    {
     
        public string SoPhach { get; set; }
        public string ShiftName { get; set; }

        public string Score { get; set; }
        public string PhongThi { get; set; }
        public int ContestantShiftID { get; set; }
        //  public string PrintResult { get; set; }
    }

}
