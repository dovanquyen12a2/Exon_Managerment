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
    public partial class frmSuaThiSinh : MetroFramework.Forms.MetroForm
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
        private AnswersheetWritingService _AnswersheetWritingService;
        private BagOfTestService _BagOfTestService;
        private TestService _TestService;
        private RoomTestService _RoomTestService;


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
        private int _ContestantShiftID;
        public frmSuaThiSinh(int DivisionShiftID, int ContestantShiftID)
        {
            InitializeComponent();
            _DivisionShiftID = DivisionShiftID;
            _ContestantShiftID = ContestantShiftID;
            InitializeService();
            InitializeControl();
            LoadContestant();
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
        }
        private void LoadContestant()
        {
            try
            {


                _ContestantShiftService = new ContestantShiftService();
                CONTESTANTS_SHIFTS cs = new CONTESTANTS_SHIFTS();
                cs = _ContestantShiftService.GetById(_ContestantShiftID);
                if (cs != null)
                {
                    txtFullName.Text = cs.CONTESTANT.FullName;
                    txtIdentityCardNumber.Text = cs.CONTESTANT.IdentityCardNumber;
                    txtSBD.Text = cs.CONTESTANT.ContestantCode;
                    cbSubject.Text = cs.SCHEDULE.SUBJECT.SubjectName;
                    cbUnit.Text = cs.CONTESTANT.Unit;
                    txtStudentCode.Text = cs.CONTESTANT.StudentCode;
                    if (cs.CONTESTANT.DOB.HasValue)
                    {
                        dtpDOB.Value = EXON.Common.DateTimeHelpers.ConvertUnixToDateTime(cs.CONTESTANT.DOB.Value);
                    }
                    if (cs.CONTESTANT.Sex == 1)
                    {
                        rbtnMale.Checked = true;

                    }
                    else
                    {
                        rbtnFemale.Checked = true;
                    }

                }
            }
            catch
            {
                MessageBox.Show("Lỗi dữ liệu!");
            }
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
                _ContestantService = new ContestantService();
                _ContestantShiftService = new ContestantShiftService();
                _ScheduleService = new ScheduleService();
                List<CONTESTANT> lstct = new List<CONTESTANT>();
                List<CONTESTANT> lstcsCheck = new List<CONTESTANT>();
                //lstcsCheck = _ContestantService.GetAll().Where(x => x.ContestantCode.ToUpper() == txtSBD.Text.ToUpper() || x.StudentCode.ToUpper() == txtStudentCode.Text.ToUpper()).ToList();
                //if (lstcsCheck.Count > 0)
                //{
                //    MessageBox.Show("Đã có số báo danh Hoặc đã có Mã SV. Vui lòng nhập lại", "Thông báo ");
                //    return;
                //}
                _ContestantService = new ContestantService();
                _ContestantShiftService = new ContestantShiftService();
                _ScheduleService = new ScheduleService();
                cs = _ContestantShiftService.GetById(_ContestantShiftID);
                if(cs!=null)
                {
                    tt = _ContestantService.GetById(cs.ContestantID);
                    if(tt!=null)
                    {
                        tt.FullName = FormatProperCase(txtFullName.Text);
                        tt.DOB = EXON.Common.DateTimeHelpers.ConvertDateTimeToUnix(dtpDOB.Value);
                     //   tt.ContestantCode = txtSBD.Text;

                        tt.IdentityCardNumber = txtIdentityCardNumber.Text;
                     
                        tt.Sex = rbtnFemale.Checked ? 0 : 1;
                        tt.Unit = CurrentUnit;
                     // tt.StudentCode = txtStudentCode.Text;
                        _ContestantService.Update(tt);
                        _ContestantService.Save();
                    }
                    var schedule = (from r in _ScheduleService.GetAll()
                                    from ds in _ContestantShiftService.GetAllByDivisionShiftID(_DivisionShiftID)
                                    from sj in _SubjectService.GetAll().Where(x => x.SubjectID == CurrentSubject)
                                    where r.ScheduleID == ds.ScheduleID && r.SubjectID == sj.SubjectID
                                    select new
                                    {
                                        scheduleID = r.ScheduleID
                                    }
                     ).Distinct().ToList();
                    int scheduleID = schedule[0].scheduleID;
                    cs.Status = 4001;
                    cs.ScheduleID = scheduleID;
                    _ContestantShiftService.Update(cs);
                    _ContestantShiftService.Save();
                    MessageBox.Show("Sửa thí sinh thành công.", "Thông báo");
                }

             
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đăng ký thí sinh không thành công.", "Thông báo");
            }
        }
    }
}
