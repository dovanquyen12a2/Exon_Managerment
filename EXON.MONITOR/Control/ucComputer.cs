using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXON.SubModel.Models;
using EXON.SubData.Services;
using EXON.MONITOR.Common;
using EXON.Common;

namespace EXON.MONITOR.Control
{
    public partial class ucComputer : UserControl
    {
        //public bool CheckedConfirm;
        public bool CheckedConfirmtoload = false;
        public bool ChangedStatus = false;
        CONTESTANT _contestant = new CONTESTANT();
        CONTESTANTS_SHIFTS _contestantshift = new CONTESTANTS_SHIFTS();
        public int contestantid;
        public int contestanshifttid;
        private IContestantShiftService _ContestantShiftService;
        private IRoomDiagramService _RoomDiagramService;
          private IContestantService _ContestantService;
        int _divisionshiftid;
        int _roomdiagramid;
        int _contesttansid;
        public int status;
        public string ComputerName;
        private int _previousStatus=1;


        public ucComputer(ROOMDIAGRAM roomdia, int divisionShiftID)
        {
            InitializeComponent();
            _divisionshiftid = divisionShiftID;
            _roomdiagramid = roomdia.RoomDiagramID;                 
            _ContestantShiftService = new ContestantShiftService();
            _RoomDiagramService = new RoomDiagramService();
            string fullnameCom = roomdia.ComputerName;
            ComputerName = roomdia.ComputerName;

            if (roomdia.Status == 4002)
            {
                ptbImage.Image = EXON.MONITOR.Properties.Resources.monitor_hong;
                lbComputername.Text = fullnameCom;
                lbComputername.ForeColor = Color.Red;

            }
            else if (roomdia.Status == 4003)
            {
                ptbImage.Image = EXON.MONITOR.Properties.Resources.monitor_dubi;
                lbComputername.Text = fullnameCom;
                lbComputername.ForeColor = Color.Yellow;
            }
            else
            {
                lbComputername.Text = fullnameCom;
            }

            // this.po.Y = _y;
        }
          public ucComputer(CONTESTANTS_SHIFTS cONTESTANTS_SHIFTS , int divisionShiftID)
          {
               InitializeComponent();
               _divisionshiftid = divisionShiftID;
               _contesttansid = cONTESTANTS_SHIFTS.ContestantID;
               _RoomDiagramService = new RoomDiagramService();
               _ContestantShiftService = new ContestantShiftService();
               _ContestantService = new ContestantService();
               int fullnameCon = cONTESTANTS_SHIFTS.ContestantID;
              
               //if (cONTESTANTS_SHIFTS.Status == 4001)
               //{
               //     ptbImage.Image = EXON.MONITOR.Properties.Resources.monitor_hong;
               //     lbComputername.Text = fullnameCon.ToString();
               //     lbComputername.ForeColor = Color.Red;

               //}
               //else 
               if (cONTESTANTS_SHIFTS.Status == 4001)
               {
                    ptbImage.Image = EXON.MONITOR.Properties.Resources.monitor_khongcothisinh;
                    lbComputername.Text = fullnameCon.ToString();
                    lbComputername.ForeColor = Color.Yellow;
               }
               else
               {
                    lbComputername.Text = fullnameCon.ToString();
               }

               // this.po.Y = _y;
          }

        CONTESTANTS_SHIFTS GetContestantShiftByComName(int divisionshiftID, int comid)
        {
            CONTESTANTS_SHIFTS result = new CONTESTANTS_SHIFTS();
            MTAQuizDbContext Db = new MTAQuizDbContext();
            try
            {

                result = (from obj in Db.CONTESTANTS_SHIFTS
                          where obj.DivisionShiftID == divisionshiftID && obj.RoomDiagramID == comid
                          select obj).FirstOrDefault();
                return result;

            }
            catch(Exception ex) {
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

                return new CONTESTANTS_SHIFTS();
            }
        }
          
        CONTESTANT GetInfoContestant(int contestantID)
        {
            CONTESTANT result = new CONTESTANT();
            MTAQuizDbContext Db = new MTAQuizDbContext();

            try
            {
                result = Db.CONTESTANTS.Where(x => x.ContestantID == contestantID).FirstOrDefault();
                return result;
            }
            catch
            {
                return new CONTESTANT();
            }

        }
        delegate void SetTextCallback(string text, Color color);
        private void SetText(string text, Color color)
        {

            if (this.lbStatus.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text, color });
            }
            else
            {
                lbStatus.Text = text;
                lbStatus.BackColor = color;
            }
        }
        public void LoadInfoContestant()
        {
            _contestantshift = new CONTESTANTS_SHIFTS();
               //_contestantshift = GetContestantShiftByComName(_divisionshiftid, _roomdiagramid);
            _contestantshift = _ContestantShiftService.GetByContestantID(_divisionshiftid, _contesttansid);
            if (_contestantshift != null)
            {
                status = _contestantshift.Status;
                contestantid = _contestantshift.ContestantID;
                contestanshifttid = _contestantshift.ContestantShiftID;
                _contestant = new CONTESTANT();
                _contestant = GetInfoContestant(_contestantshift.ContestantID);

                lbContestantCode.Text = _contestant.ContestantCode;
                lbContestantName.Text = _contestant.FullName;
                //cBCheckFP.Enabled = CheckedConfirmtoload;
                if (_contestantshift.Status != (int)Constant.STATUS_DOING_BUT_INTERRUPT)
                {
                    _previousStatus = _contestantshift.Status;
                   
                }             
                #region status
                string statusStr = "";
                //if (_contestantshift.IsCheckFingerprint == 1 || _contestantshift.IsCheckFingerprint == 2)
                if(_contestantshift.ContestantShiftID ==  3000)
                {
                    ptbImage.Image = EXON.MONITOR.Properties.Resources.monitor;
                    //   cBCheckFP.Checked = true;
                    this.BackColor = Color.White;
                }
                else
                {
                    //  cBCheckFP.Checked = false;
                    this.BackColor = Color.Gray;
                    //ptbImage.Image = EXON.MONITOR.Properties.Resources.monitor_khongcothisinh;
                }
                Color color = new Color();
                switch (_contestantshift.Status)
                {
                    case 3000:
                        statusStr = "Đăng nhập";
                        color = Color.SpringGreen;
                        if (!ChangedStatus)
                        {
                            ChangedStatus = true;
                            CheckedConfirmtoload = true;
                        }

                        break;
                    case 3001:
                        statusStr = "Đăng nhập lại ";
                        color = Color.GreenYellow;
                        break;
                    case 3002:
                        statusStr = "Sẵn sàng thi";
                        color = Color.DeepSkyBlue;
                        break;
                    case 3003:
                        statusStr = "Đang thi";
                        color = Color.DodgerBlue;
                        break;
                    case 3004:

                        statusStr = "Mất kết nối";
                        color = Color.Fuchsia;
                        if (_previousStatus  !=3004 && _previousStatus>1)
                        {
                            EXON.Common.NotificationBox.Show(String.Format("Thí sinh tại máy {0} mất kết nối", ComputerName), EXON.Common.NotificationBox.AlertType.error);
                            _previousStatus = _contestantshift.Status;
                        }
                        break;
                    case 3005:
                        statusStr = "Hoàn thành thi";
                        color = Color.Turquoise;
                        break;

                    case 3009:
                        statusStr = "Bắt đầu thi";
                        break;
                    case 3010:
                        statusStr = "Sẵn sàng nhận đề";
                        break;
                    case 3011:
                        statusStr = "Phát đề";
                        break;
                    case 4001:
                        statusStr = "Chưa đăng nhập";
                        color = Color.Yellow;
                        break;
                    case 5000:
                        statusStr = "Tạm ngừng";
                        color = Color.Yellow;
                        break;
                }
                SetText(statusStr, color);

                //this.BackColor = color;
                #endregion
            }
            else
            {
                lbContestantName.Text = "Không có thí sinh";
                this.BackColor = Color.Gray;
                ptbImage.Image = EXON.MONITOR.Properties.Resources.monitor_khongcothisinh;
                lbContestantCode.Text = "SBD";
                lbStatus.Text = "Trạng thái";
                lbStatus.BackColor = Color.Gray;
            }

        }
        public void LoadInfoContestantByContestantID(int _divisionShiftId, int _ContestantId)
        {
            _contestantshift = new CONTESTANTS_SHIFTS();
            _contestantshift = _ContestantShiftService.GetByContestantID(_divisionshiftid, _ContestantId);

            if (_contestantshift != null)
            {
                contestantid = _contestantshift.ContestantID;
                contestanshifttid = _contestantshift.ContestantShiftID;
                _contestant = new CONTESTANT();
                _contestant = GetInfoContestant(_contestantshift.ContestantID);
                lbContestantCode.Text = _contestant.ContestantCode;
                lbContestantName.Text = _contestant.FullName;

                #region status;
                if (_contestantshift.IsCheckFingerprint == 1 || _contestantshift.IsCheckFingerprint == 2)
                {
                    ptbImage.Image = Properties.Resources.monitor;

                    this.BackColor = Color.White;
                }
                else
                {

                    this.BackColor = Color.Gray;
                    ptbImage.Image = Properties.Resources.monitor_khongcothisinh;
                }

                #endregion
            }
            else
            {
                lbContestantName.Text = "Không có thí sinh";
                this.BackColor = Color.Gray;
            }

        }

        private void ucComputer_Load(object sender, EventArgs e)
        {
               LoadInfoContestant();

        }

        public event EventHandler RightClick;

        public event EventHandler ImageClick;
        protected void ptbImage_Click(object sender, EventArgs e)
        {
            // bubble the event up to the parent
            if (this.ImageClick != null)
                this.ImageClick(this, e);
        }





        private void ptbImage_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (this.RightClick != null)
                    this.RightClick(this, e);
            }
        }

         
     }
}
