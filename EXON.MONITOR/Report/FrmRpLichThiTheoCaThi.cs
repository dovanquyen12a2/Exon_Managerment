
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
using EXON.SubModel.Models;
using EXON.MONITOR.Common;
using EXON.Common;

namespace EXON.MONITOR.Report
{
    public partial class FrmRpLichThiTheoCaThi : Form
    {
        private DIVISION_SHIFTS dv = new DIVISION_SHIFTS();
        private MTAQuizDbContext db; 

        #region constructor
        public FrmRpLichThiTheoCaThi()
        {
            InitializeComponent();
             MTAQuizDbContext db = new MTAQuizDbContext();
        }

        public FrmRpLichThiTheoCaThi(DIVISION_SHIFTS tg)
        {
            InitializeComponent();
            dv = tg;
            MTAQuizDbContext db = new MTAQuizDbContext();
        }
        #endregion

        #region LoadForm
        private void FrmRpLichThiTheoCaThi_Load(object sender, EventArgs e)
        {
            try
            {
                EXON.MONITOR.Report.ReportDataset dataSet = new EXON.MONITOR.Report.ReportDataset();
                dataSet.Tables.Clear();
                db = new MTAQuizDbContext();
                ROOMTEST roomTest = db.ROOMTESTS.Where(p => p.RoomTestID == dv.RoomTestID).FirstOrDefault();
                LOCATION location = db.LOCATIONS.Where(p => p.LocationID == roomTest.LocationID).FirstOrDefault();
                CONTEST kithi = db.CONTESTS.Where(p => p.ContestID == location.ContestID).FirstOrDefault();
                SHIFT shift = db.SHIFTS.Where(p => p.ShiftID == dv.ShiftID).FirstOrDefault();
                STAFF staff = db.STAFFS.Where(p => p.StaffID == kithi.CreatedStaffID).FirstOrDefault();

                int i = 1;
                var lichthi = (
                               from lt in db.CONTESTANTS_SHIFTS.Where(pz => pz.DivisionShiftID == dv.DivisionShiftID).ToList()
                               from ts in db.CONTESTANTS.Where(pz => pz.Status > 0 && lt.ContestantID == pz.ContestantID).ToList()
                             
                               from mt in db.SCHEDULES.Where(pz => pz.Status == 1 && pz.ContestID == kithi.ContestID && pz.ScheduleID == lt.ScheduleID).ToList()
                               select new
                               {
                                   SBD = ts.ContestantCode,
                                   STT = i++,
                                   HoTen = ts.FullName,
                                   NgaySinh = EXON.Common.DateTimeHelpers.ConvertUnixToDateTime((int)ts.DOB).ToString("dd/MM/yyyy"),
                                   MonThi = db.SUBJECTS.Where(p => p.SubjectID == mt.SubjectID).FirstOrDefault().SubjectName,
                                   QueQuan = ts.CurrentAddress,
                                   Unit = ts.Unit
                               }
                              ).ToList();
                dataSet.Tables.Add(EXON.Common.Helper.ToDataTable(lichthi));

                ReportDataSource rp = new ReportDataSource("LichThi", dataSet.Tables[0]);

                ReportParameter[] listPara = new ReportParameter[]{
                    new ReportParameter("ContestName",kithi.ContestName.ToUpper()),
                    new ReportParameter("ShiftName",shift.ShiftName),
                    new ReportParameter("LocationName", location.LocationName),
                    new ReportParameter("RoomTestName", roomTest.RoomTestName),
                    new ReportParameter("ShiftDate", EXON.Common.DateTimeHelpers.ConvertUnixToDateTime(shift.ShiftDate).ToString("dd/MM/yyyy")),
                    new ReportParameter("StartTime",EXON.Common.DateTimeHelpers.ConvertUnixToDateTime(shift.StartTime).ToString("HH:mm")),
                    new ReportParameter("EndTime", EXON.Common.DateTimeHelpers.ConvertUnixToDateTime(shift.EndTime).ToString("HH:mm")),
                    new ReportParameter("FullName", staff.FullName.ToUpper())
                };
                this.reportViewer1.LocalReport.SetParameters(listPara);

                
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rp);
                

            }
            catch (Exception ex)
            {
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

                MessageBox.Show(ex.Message);
            }

            
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }
        #endregion
    }
}
