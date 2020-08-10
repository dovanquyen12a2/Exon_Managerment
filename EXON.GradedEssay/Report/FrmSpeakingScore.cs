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



namespace ReportRoomDiagrams
{
    public partial class FrmSpeakingScore : Form
    {
        private CONTEST kithi = new CONTEST();
        
        private int id;
        //private int dvs;
        public FrmSpeakingScore(int _ContestantShiftID)
        {        
            InitializeComponent();        
            id = _ContestantShiftID;
           
        }

        public DateTime ConvertUnixToDateTime(int unix)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return dt.AddSeconds(unix);
        }
        private void FrmSpeakingScore_Load(object sender, EventArgs e)
        {
            try
            {
                MTAQuizDbContext db = new MTAQuizDbContext();
                var list = (from ctt in db.CONTESTANTS_TESTS.Where(x => x.ContestantShiftID == id).ToList()
                            from asw in db.ANSWERSHEETS.Where(x => x.ContestantTestID == ctt.ContestantTestID).ToList()
                            //from aswdt in db.ANSWERSHEET_DETAILS.Where(x => x.AnswerSheetID == asw.AnswerSheetID).ToList()
                            //from sqt in db.SUBQUESTIONS.Where(x => x.SubQuestionID == aswdt.SubQuestionID).ToList()
                           // from qt in db.QUESTIONS.Where(x => x.QuestionID == sqt.QuestionID && x.Type == 5).ToList()
                            from cts in db.CONTESTANTS_SHIFTS.Where(x => x.ContestantShiftID == id).ToList()
                            from sch in db.SCHEDULES.Where(x => x.ScheduleID == cts.ScheduleID).ToList()
                            from sj in db.SUBJECTS.Where(x => x.SubjectID == sch.SubjectID).ToList()
                            from dvs in db.DIVISION_SHIFTS.Where(x => x.DivisionShiftID == cts.DivisionShiftID).ToList()
                            from aswsp in db.ANSWERSHEET_SPEAKING.Where(x => x.AnswerSheetID == asw.AnswerSheetID && x.SpeakingScore != null).ToList()
                            select new
                            {

                                score1 = aswsp.SpeakingScore,
                                score2 = 0

                            }
                            ).ToList();

                if (list.Count != 0)
                {
                    var shift = (
                                 from cts in db.CONTESTANTS_SHIFTS.Where(x => x.ContestantShiftID == id).ToList()
                                 from sch in db.SCHEDULES.Where(x => x.ScheduleID == cts.ScheduleID).ToList()
                                 from sj in db.SUBJECTS.Where(x => x.SubjectID == sch.SubjectID).ToList()
                                 from dvs in db.DIVISION_SHIFTS.Where(x => x.DivisionShiftID == cts.DivisionShiftID).ToList()
                                 from sh in db.SHIFTS.Where(x => x.ShiftID == dvs.ShiftID)
                                 select new
                                 {
                                     shiftName = sh.ShiftName,
                                     subjectName = sj.SubjectName,
                                     contestid = sh.ContestID
                                 }
                            ).FirstOrDefault();

                    //var teacher = (from ctt in db.CONTESTANTS_TESTS.Where(x => x.ContestantTestID == id).ToList()
                    //               from asw in db.ANSWERSHEETS.Where(x => x.ContestantTestID == ctt.ContestantTestID).ToList()
                    //               from aswr in db.ANSWERSHEET_WRITING.Where(x => x.AnswerSheetID == asw.AnswerSheetID).ToList()
                    //               from wrt in db.WRITING_TEACHER.Where(x => x.AnswerSheetWritingID == aswr.AnswerSheetWritingID).ToList()
                    //               select new
                    //               {
                    //                   idTeacher = wrt.ID
                    //               }
                    //            ).ToList();
                    var profile = (
                                   from cts in db.CONTESTANTS_SHIFTS.Where(x => x.ContestantShiftID == id).ToList()
                                   from ct in db.CONTESTANTS.Where(x => x.ContestantID == cts.ContestantID).ToList()
                                   select new
                                   {
                                       name = ct.FullName,
                                       dob = ct.DOB,
                                       code = ct.ContestantCode
                                   }
                                   ).ToList();

                    kithi = db.CONTESTS.Where(x => x.ContestID == shift.contestid).FirstOrDefault();
                    ReportParameter[] listPara = new ReportParameter[]{
                    new ReportParameter("contestName",kithi.ContestName.ToLower()),
                    new ReportParameter("CreateDate",DateTime.Now.ToString(@"\n\g\à\y\ dd \t\h\á\n\g\ MM \n\ă\m\ yyyy")),
                    new ReportParameter("Subject",shift.subjectName.ToString().ToUpper()),
                    new ReportParameter("ShiftName",shift.shiftName.ToString()),
                    new ReportParameter("DOB",ConvertUnixToDateTime(Convert.ToInt32(profile[0].dob)).ToString(@" dd \/ MM \/ yyyy")),
                    new ReportParameter("FullName",profile[0].name),
                    new ReportParameter("Code",profile[0].code),
                    new ReportParameter("Score1",list[0].score1.ToString()),
                    new ReportParameter("Score2",list[0].score2.ToString()),
                };
                    this.reportViewer1.LocalReport.SetParameters(listPara);
                    this.reportViewer1.RefreshReport();
                
                }
                else
                {
                    MessageBox.Show("Chưa chấm điểm thí sinh này.");
                    this.Dispose();
                }
             
            }
            catch(Exception ex)

            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void SpeakingScoreBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}


