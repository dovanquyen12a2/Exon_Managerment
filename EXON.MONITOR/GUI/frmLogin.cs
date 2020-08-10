
using EXON.SubData.Services;

using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXON.MONITOR.Common;
using EXON.SubModel.Models;
using QuanLyHoiDongThiVer2.DAO;
using System.Net;
using EXON.Common;

namespace EXON.MONITOR.GUI
{

    public partial class frmLogin : MetroForm
    {

        private ExaminationcouncilStaffService _ExaminationcouncilStaffService;
        private ConfigApplication ca = new ConfigApplication();
        private bool blExitGS = false;
        private bool blExitDT = false;
        public frmLogin()
        {
            InitializeComponent();
            _ExaminationcouncilStaffService = new ExaminationcouncilStaffService();
            txtUserName.Focus();

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {

            try
            {
                blExitDT = false;
                blExitGS = false;
                if (Common.Controllers.Instance.HandleCheckDB())
                {
                    int CHECK_NAMEDB = Common.Controllers.Instance.GetDBName();
                    if (CHECK_NAMEDB == 1) // database dat tai dia diem thi
                    {
                        _ExaminationcouncilStaffService = new ExaminationcouncilStaffService();
                        if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text))
                        {
                            MessageBox.Show("Không được để trống", "Thông báo");
                            return;
                        }
                        else
                        {
                            if (_ExaminationcouncilStaffService.Login(txtUserName.Text, txtPassword.Text))
                            {

                                EXAMINATIONCOUNCIL_STAFFS staff = _ExaminationcouncilStaffService.GetStaffByLogin(txtUserName.Text, txtPassword.Text);
                                AppSession.UserName = txtUserName.Text.Trim();
                                AppSession.Password = txtPassword.Text.Trim();
                                AppSession.Permission = staff.EXAMINATIONCOUNCIL_POSITIONS.Permission ?? default(int);
                                AppSession.StaffID = staff.StaffID.Value;
                                AppSession.LogTime = DatetimeConvert.ConvertDateTimeToUnix(DatetimeConvert.GetDateTimeServer());
                                this.Hide();
                                if (staff.EXAMINATIONCOUNCIL_POSITIONS.Permission == 1)
                                {
                                    Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "LOGIN | DIEM TRUONG | ", string.Format("{0} LOGIN SUCCESS", staff.STAFF.FullName));

                                }
                                else
                                {
                                    Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "LOGIN | GIAM SAT | ", string.Format("{0} LOGIN SUCCESS", staff.STAFF.FullName));
                                }
                                frmMain frmGS = new frmMain(AppSession.StaffID,staff.ContestID.Value,staff.LocationID.Value);
                                frmGS.ShowDialog();
                                this.Show();

                            }
                            else
                            {
                                MessageBox.Show(Properties.Resources.NotLoginMessage, Properties.Resources.Notification);
                                txtPassword.Text = string.Empty;

                            }
                        }
                    }
                    else if(CHECK_NAMEDB == 0) // database dat tai trung tam
                    {
                        _ExaminationcouncilStaffService = new ExaminationcouncilStaffService();
                        if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text))
                        {
                            MessageBox.Show("Không được để trống", "Thông báo");
                            return;
                        }
                        else
                        {
                            if (_ExaminationcouncilStaffService.LoginAtCenter(txtUserName.Text, txtPassword.Text))
                            {
                                this.Hide();
                                frmTrungTam frmGS = new frmTrungTam(txtUserName.Text, txtPassword.Text);
                                frmGS.ShowDialog();
                                this.Show();

                            }
                            else
                            {
                                MessageBox.Show(Properties.Resources.NotLoginMessage, Properties.Resources.Notification);
                                txtPassword.Text = string.Empty;

                            }
                        }
                    }
                    else
                    {

                    MessageBox.Show("ERROR: Cannot Get DataSource!");
                    }

                }
                else
                {
                    MessageBox.Show(Properties.Resources.NotConnectServerMessage, Properties.Resources.MSG_ERR_001);
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Unkown exception: {0}", ex.Message));
                MessageBox.Show(Properties.Resources.NotConnectServerMessage, Properties.Resources.MSG_ERR_001);

                Application.Exit() ;
            }

        }

        private void Form_Sender(bool ExitForm)
        {
            if (ExitForm)
            {
                this.Show();

            }

        }

        private void FrmGS_Sender(bool ExitForm)
        {
            if (ExitForm && blExitDT)
            {
                this.Show();

            }
            else if (!blExitDT && ExitForm)
            {
                blExitGS = true;
            }
        }

        private void FrmDT_Sender(bool ExitForm)
        {
            if (ExitForm && blExitGS)
            {
                this.Show();

            }
            else if (!blExitGS && ExitForm)
            {
                blExitDT = true;
            }
        }

        private void ceHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (ceHienMatKhau.Checked)
                txtPassword.PasswordChar = '\0';
            else txtPassword.PasswordChar = '*';
        }
    }
}