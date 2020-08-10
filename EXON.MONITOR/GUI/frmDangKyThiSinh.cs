using EXON.Common;
using EXON.SubData.Services;
using EXON.SubModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXON.MONITOR.GUI
{
    public partial class frmDangKyThiSinh : MetroFramework.Forms.MetroForm
    {
        #region Service
        private IContestService _ContestService;
        private IShiftService _ShiftService;
        private IScheduleService _ScheduleService;
        private ISubjectService _SubjectService;
        private IStaffService _StaffService;
        private IDivisionShiftService _DivisionShiftService;
        private IContestantShiftService _ContestantShiftService;
        private IContestantService _ContestantService;
        private IContestantTestService _ContestantTestService;
        private IAnswersheetService _AnswersheetService;
        private IAnswersheetSpeakingService _AnswersheetSpeakingService;
        private IAnswersheetWritingService _AnswersheetWritingService;
        private IBagOfTestService _BagOfTestService;
        private ITestService _TestService;
        private IRoomTestService _RoomTestService;
        private IContestantTestService _ContesttantTestService;

        #endregion Service
        private int CurrentSubject
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
        private string CurrentUnit
        {
            get
            {
                try
                {
                    return cbUnit.Text.ToString();
                }
                catch { return string.Empty; }
            }
        }
        private int _DivisionShiftID;
        private const int GiaTriTy = 1000000000;
        public frmDangKyThiSinh(int DivisionShiftID)
        {
            InitializeComponent();
            _DivisionShiftID = DivisionShiftID; 
            InitializeService();
            InitializeControl();
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
            _ContesttantTestService = new ContestantTestService();
        }

        private void InitializeControl()
        {

            _ScheduleService = new ScheduleService();
            _DivisionShiftService = new DivisionShiftService();
            _ContestantShiftService = new ContestantShiftService();
            _SubjectService = new SubjectService();
            _ContestantService = new ContestantService();
            List<CONTESTANT> lstct = new List<CONTESTANT>();
            lstct = _ContestantService.GetAll().ToList();
            lblSoBaoDanhTruocDo.Text ="SBD trước đó: " +lstct[lstct.Count - 1].ContestantCode.ToString();
         
            DIVISION_SHIFTS CurrentDs = new DIVISION_SHIFTS();
            CurrentDs = _DivisionShiftService.GetById(_DivisionShiftID);

            cbSubject.DataSource = (from r in _ScheduleService.GetAll()
                                    from ds in _ContestantShiftService.GetAllByDivisionShiftID(CurrentDs.DivisionShiftID)
                                    from sj in _SubjectService.GetAll()
                                    where r.ScheduleID == ds.ScheduleID && r.SubjectID == sj.SubjectID
                                    select new
                                    {
                                        SubjectName = sj.SubjectName,
                                        SubjectID = sj.SubjectID
                                    }).Distinct().ToList();
            cbSubject.DisplayMember = "SubjectName";
            cbSubject.ValueMember = "SubjectID";
            cbUnit.DataSource = (
                                    from ds in _ContestantShiftService.GetAllByDivisionShiftID(CurrentDs.DivisionShiftID)

                                    select new
                                    {
                                        TenLop = ds.CONTESTANT.Unit
                                    }
                                    ).Distinct().ToList();
            cbUnit.DisplayMember = "TenLop";

        }
        public static string FormatProperCase(string str)
        {
            CultureInfo cultureInfo = new CultureInfo("vi-VN");
            TextInfo textInfo = cultureInfo.TextInfo;
            str = textInfo.ToLower(str);
            // Replace multiple white space to 1 white  space
            str = System.Text.RegularExpressions.Regex.Replace(str, @"\s{2,}", " ");
            //Upcase like Title
            return textInfo.ToTitleCase(str);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                CONTESTANT tt = new CONTESTANT();
                CONTESTANTS_SHIFTS cs = new CONTESTANTS_SHIFTS();
              
                SCHEDULE sc = new SCHEDULE();
                DIVISION_SHIFTS DS = new DIVISION_SHIFTS();

                _ContestantService = new ContestantService();
                _ContestantShiftService = new ContestantShiftService();
                _ScheduleService = new ScheduleService();
                _DivisionShiftService = new DivisionShiftService();
                _ContesttantTestService = new ContestantTestService();
                List<CONTESTANT> lstct = new List<CONTESTANT>();
                List<CONTESTANT> lstcsCheck = new List<CONTESTANT>();
                lstcsCheck = _ContestantService.GetAll().Where(x=>x.ContestantCode.ToUpper()==txtSBD.Text.ToUpper()).ToList();
                if(lstcsCheck.Count>0)
                {
                    MessageBox.Show("Đã có số báo danh. Vui lòng nhập lại", "Thông báo ");
                    return;
                }
                _ContestantService = new ContestantService();
                _ContestantShiftService = new ContestantShiftService();
                _ScheduleService = new ScheduleService();
                List<CONTESTANTS_SHIFTS> lstcs = new List<CONTESTANTS_SHIFTS>();
                lstct = _ContestantService.GetAll().ToList();
                lstcs = _ContestantShiftService.GetAll().ToList();
                DS = _DivisionShiftService.GetById(_DivisionShiftID);
                
                var schedule = (from r in _ScheduleService.GetAll()
                                from ds in _ContestantShiftService.GetAllByDivisionShiftID(_DivisionShiftID)
                                from sj in _SubjectService.GetAll().Where(x => x.SubjectID == CurrentSubject)
                                where r.ScheduleID == ds.ScheduleID && r.SubjectID == sj.SubjectID
                                select new
                                {
                                    scheduleID = r.ScheduleID,
                                    ContestID = r.ContestID
                                }
                        ).Distinct().ToList();
                int scheduleID = schedule[0].scheduleID;
                int contestID = schedule[0].ContestID.Value;
                int CountCS = lstcs.Count;
                tt.FullName = FormatProperCase(txtFullName.Text);

                tt.DOB = EXON.Common.DateTimeHelpers.ConvertDateTimeToUnix(dtpDOB.Value);
                tt.ContestantCode = txtSBD.Text;
               
                tt.IdentityCardNumber = txtIdentityCardNumber.Text;
                tt.ContestantID = contestID - GiaTriTy + lstct.Count  + 1;
                tt.Sex = rbtnFemale.Checked ? 0 : 1;
                tt.Unit = CurrentUnit;
                tt.Status = 4001;

              
                _ContestantService.Add(tt);
                _ContestantService.Save();

                cs.ContestantShiftID = contestID*10000 - GiaTriTy+ lstcs.Count    + 1;
                cs.DivisionShiftID = _DivisionShiftID;
                cs.ContestantID = tt.ContestantID;
                cs.Status = 4001;
                cs.ScheduleID = scheduleID;
                _ContestantShiftService.Add(cs);
                _ContestantShiftService.Save();
                if (DS.Status >= (int)Constant.StatusDivisionShift.STATUS_GENTEST)
                {
                    List<int> listTestIDForSubject = (from bagoftest in _BagOfTestService.GetAll().Where(x => x.DivisionShiftID == DS.DivisionShiftID)
                                                      from Test in _TestService.GetAll().Where(x => x.BagOfTestID == bagoftest.BagOfTestID && x.SubjectID == CurrentSubject)
                                                      select Test.TestID
                                                               ).ToList();
                    Random rnd = new Random();
                    int rndvalue = rnd.Next(listTestIDForSubject.Count);
                   
                        CONTESTANTS_TESTS contestantTest = new CONTESTANTS_TESTS();
                        contestantTest.ContestantShiftID = cs.ContestantShiftID;
                        contestantTest.TestID = listTestIDForSubject[rndvalue];
                        contestantTest.Status = 4001;
                        _ContesttantTestService.Add(contestantTest);
                        _ContesttantTestService.Save();

               
                }
                MessageBox.Show("Đăng ký thí sinh thành công.", "Thông báo");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đăng ký thí sinh không thành công.", "Thông báo");
            }
        }
    }
}
