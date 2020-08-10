using EXON.Common;
using EXON.GradedEssay;
using EXON.MONITOR.Control;
using EXON.MONITOR.GUI;
using EXON.SubData.Services;
using EXON.SubModel.Models;
using QuanLyHoiDongThiVer2.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXON.MONITOR
{
    public partial class frmMain : MetroFramework.Forms.MetroForm
    {
        #region Service
        private StaffService _StaffService;
        private ShiftService _ShiftService;
        private DivisionShiftService _DivisionShiftService;
        private ExaminationcouncilStaffService _ExaminationcouncilStaffService;
        private EXAMINATIONCOUNCIL_STAFFS exs;
        #endregion
        public delegate void SendClose(bool ExitForm);
       
        private int _StaffID { get; set; }
        private int _ContestID { get; set; }
        private int _LocationID { get; set; }
        public frmMain(int StaffID, int ContestID ,int LocationID)
        {
            InitializeComponent();

            InitializeService();
            _StaffID = StaffID;
            _ExaminationcouncilStaffService = new ExaminationcouncilStaffService();
            _DivisionShiftService = new DivisionShiftService();
            exs = _ExaminationcouncilStaffService.GetByStaffID(_StaffID);

            if (exs != null)
            {
                if (exs.EXAMINATIONCOUNCIL_POSITIONS.ExaminationCouncil_PositionCode == "DT")
                {
                    rbQuanLyHoiDong.Visible = true;
                }

                _ContestID = ContestID;
                _LocationID = LocationID;

            }
        }
        private void InitializeService()
        {

            _ShiftService = new ShiftService();
            _StaffService = new StaffService();
            _ExaminationcouncilStaffService = new ExaminationcouncilStaffService();
        }

        private void rbtnGiamSat_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowSplashScreen();
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() != typeof(frmSupervisorManage))
                {
                    f.Close();
                    f.Dispose();

                }
                else
              if (f.GetType() == typeof(GUI.frmSupervisorManage))
                {
                    f.Activate();
                    SplashScreenManager.CloseForm();
                    return;
                }
            }

            frmSupervisorManage form1 = new frmSupervisorManage(_StaffID, _ContestID, _LocationID);

            form1.MdiParent = this;

            form1.Show();
            SplashScreenManager.CloseForm();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            SplashScreenManager.ShowSplashScreen();
            frmSupervisorManage form1 = new frmSupervisorManage(_StaffID, _ContestID, _LocationID);

            form1.MdiParent = this;
            form1.Show();
            SplashScreenManager.CloseForm();
        }

        private void rbtnStatusComputer_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowSplashScreen();
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() != typeof(frmRoomConfig))
                {
                    f.Close();
                    f.Dispose();

                }
                else
              if (f.GetType() == typeof(GUI.frmRoomConfig))
                {
                    f.Activate();
                    SplashScreenManager.CloseForm();
                    return;
                }
            }
            frmRoomConfig form1 = new frmRoomConfig(_ContestID, _LocationID);
            form1.MdiParent = this;
            form1.Show();
            SplashScreenManager.CloseForm();
        }
        // cham thi ngoai ngu
      
        private void rbtnSpeaking1_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowSplashScreen();
            Thread.Sleep(100);

            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() != typeof(frmSpeaking))
                {
                    f.Close();
                    f.Dispose();

                }
                else
                if (f.GetType() == typeof(frmSpeaking))
                {
                    if (cbContest.Checked)
                    {
                        (f as frmSpeaking)._TypeShow = 1;
                        (f as frmSpeaking).InitControl();
                    }
                    else
                    {
                        (f as frmSpeaking)._TypeShow = 2;
                        (f as frmSpeaking).InitControl();
                    }
                    f.Refresh();
                    f.Activate();
                    SplashScreenManager.CloseForm();
                    return;
                }
            }

            rbtnSpeaking1.Checked = true;
            rbtnWritting.Checked = false;
            rbtnReport.Checked = false;
            if (cbContest.Checked)
            {
                frmSpeaking form1 = new frmSpeaking(_ContestID, 1, _LocationID);
                form1.MdiParent = this;
                form1.Show();
            }
            else
            {
                frmSpeaking form1 = new frmSpeaking(_ContestID, 2, _LocationID);
                form1.MdiParent = this;
                form1.Show();
            }
            this.Update();
            SplashScreenManager.CloseForm();
        }
        private void rbtnWritting_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowSplashScreen();
            Thread.Sleep(100);
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() != typeof(frmWriting))
                {
                    f.Close();
                    f.Dispose();

                }
                else if (f.GetType() == typeof(frmWriting))
                {

                    if (cbContest.Checked)
                    {
                        (f as frmWriting)._TypeShow = 1;
                        (f as frmWriting).InitControl();
                    }
                    else
                    {
                        (f as frmWriting)._TypeShow = 2;
                        (f as frmWriting).InitControl();
                    }
                    f.Refresh();
                    f.Activate();
                    SplashScreenManager.CloseForm();
                    return;
                }
            }
            rbtnWritting.Checked = true;
            rbtnSpeaking1.Checked = false;
            rbtnReport.Checked = false;

            if (cbContest.Checked)
            {


                frmWriting form1 = new frmWriting(_ContestID, 1, _LocationID);
                form1.MdiParent = this;
                form1.Show();


            }
            else
            {

                frmWriting form1 = new frmWriting(_ContestID, 2, _LocationID);
                form1.MdiParent = this;
                form1.Show();

            }
            this.Update();
            SplashScreenManager.CloseForm();
        }

        private void rbtnReport_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowSplashScreen();
            Thread.Sleep(100);

            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() != typeof(frmReportEL))
                {
                    f.Close();
                    f.Dispose();

                }
                else
                 if (f.GetType() == typeof(frmReportEL))
                {

                    if (cbContest.Checked)
                    {
                        (f as frmReportEL)._TypeShow = 1;
                        (f as frmReportEL).InitControl();
                    }
                    else
                    {
                        (f as frmReportEL)._TypeShow = 2;
                        (f as frmReportEL).InitControl();
                    }
                    f.Refresh();
                    f.Activate();
                    SplashScreenManager.CloseForm();
                    return;
                }
            }
            rbtnWritting.Checked = false;
            rbtnSpeaking1.Checked = false;
            rbtnReport.Checked = true;
            if (cbContest.Checked)
            {
                frmReportEL form1 = new frmReportEL(_ContestID, 1, _LocationID);
                form1.MdiParent = this;
                form1.Show();
            }
            else
            {
                frmReportEL form1 = new frmReportEL(_ContestID, 2, _LocationID);
                form1.MdiParent = this;
                form1.Show();
            }
            this.Update();
            SplashScreenManager.CloseForm();
        }

        private void rbAttach_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"D:\";
            saveFileDialog1.Title = "Chọn thư mục lưu";
            //  saveFileDialog1.CheckFileExists = true;
            // saveFileDialog1.CheckPathExists = true;
            ///  saveFileDialog1.DefaultExt = "bak";
            saveFileDialog1.Filter = "Text files (*.bak)|*.bak";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string backupFileName = saveFileDialog1.FileName;
                var connectionString = ConfigurationManager.ConnectionStrings["MTA_QUIZ_1"].ConnectionString;
                var sqlConStrBuilder = new SqlConnectionStringBuilder(connectionString);
                frmLoadingGIF frm = new frmLoadingGIF();
                frm.Show();

                using (var connection = new SqlConnection(sqlConStrBuilder.ConnectionString))
                {
                    var query = String.Format("BACKUP DATABASE {0} TO DISK='{1}'",
                        sqlConStrBuilder.InitialCatalog, backupFileName);
                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                frm.Close();


            }



            // set backupfilename (you will get something like: "C:/temp/MyDatabase-2013-12-07.bak")

        }
        public static void DetachDatabase(string pathToSave)
        {
            String databaseConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MTAQuizDbContext"].ConnectionString;
            string YOUR_DATABASE = databaseConnectionString.Split(';')[1].Substring(16);
            string[] pathFile = new string[2]; /* local path file*/

            using (SqlConnection sqlDatabaseConnection = new SqlConnection(databaseConnectionString))
            {
                try
                {
                    //       SplashScreen.ShowSplashScreen();
                    sqlDatabaseConnection.Open();

                    //     SplashScreen.SetStatus("Lấy đường dẫn vật lý của file mdf.");
                    string commandString = $"use {YOUR_DATABASE}; SELECT * FROM sys.database_files";
                    SqlCommand sqlDatabaseCommand = new SqlCommand(commandString, sqlDatabaseConnection);
                    SqlDataReader reader = sqlDatabaseCommand.ExecuteReader();

                    int index = 0;
                    while (reader.Read() && index < 2)
                    {
                        pathFile[index++] = reader.GetString(reader.GetOrdinal("physical_name"));
                    }

                    //   SplashScreen.SetStatus("Copy file đến thư mục yêu cầu.");
                    pathToSave = Path.Combine(pathToSave, DateTimeHelpers.GetDatePathString());
                    if (!Directory.Exists(pathToSave)) Directory.CreateDirectory(pathToSave);

                    string fileName = Path.Combine(pathToSave, YOUR_DATABASE + ".mdf");

                    commandString = $"ALTER DATABASE {YOUR_DATABASE} SET OFFLINE WITH ROLLBACK IMMEDIATE ALTER DATABASE {YOUR_DATABASE} SET MULTI_USER EXEC sp_detach_db '{YOUR_DATABASE}'";
                    sqlDatabaseCommand = new SqlCommand(commandString, sqlDatabaseConnection);
                    sqlDatabaseCommand.ExecuteNonQuery();

                    // SplashScreen.SetStatus($"Copy mdf đến thư mục {pathToSave}");
                    File.Copy(pathFile[0], fileName, true);
                    //SplashScreen.SetStatus($"Copy log đến thư mục {pathToSave}");
                    File.Copy(pathFile[1], fileName.Replace(".mdf", "_log.ldf"), true);
                    //SplashScreen.SetStatus("Xong!!!.");
                }
                catch
                {
                    //NotificationBox.Show(Properties.Resources.HasErrorMessage, NotificationBox.AlertType.error);
                    //Log.Instance.WriteErrorLog(LogType.ERROR, ex.Message);
                }
                finally
                {
                    string commandString = $"EXEC sp_attach_db @dbname = '{YOUR_DATABASE}', @filename1 = N'{pathFile[0]}'";
                    SqlCommand sqlDatabaseCommand = new SqlCommand(commandString, sqlDatabaseConnection);
                    sqlDatabaseCommand.ExecuteNonQuery();

                    sqlDatabaseConnection.Close();
                    //SplashScreen.CloseForm();
                    //NotificationBox.Show(Properties.Resources.Success, NotificationBox.AlertType.success);
                }
            }
        }


        public delegate void SendWorking(int value);
        SendWorking s;
        private void rbtnBackupDB_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowSplashScreen();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"D:\";
            saveFileDialog1.Title = "Chọn thư mục lưu";
            //  saveFileDialog1.CheckFileExists = true;
            // saveFileDialog1.CheckPathExists = true;
            ///  saveFileDialog1.DefaultExt = "bak";
            saveFileDialog1.Filter = "Text files (*.bak)|*.bak";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string backupFileName = saveFileDialog1.FileName;
                var connectionString = ConfigurationManager.ConnectionStrings["MTA_QUIZ_1"].ConnectionString;
                var sqlConStrBuilder = new SqlConnectionStringBuilder(connectionString);


                using (var connection = new SqlConnection(sqlConStrBuilder.ConnectionString))
                {
                    var query = String.Format("BACKUP DATABASE {0} TO DISK='{1}'",
                        sqlConStrBuilder.InitialCatalog, backupFileName);
                    using (var command = new SqlCommand(query, connection))
                    {
                        //GradedEssay.Control.ucLoad loading = new GradedEssay.Control.ucLoad();
                        //loading.TopMost = true;
                        //s = new SendWorking(loading.UpdateValue2);
                        //loading.Show();
                        //s(50);
                        SplashScreenManager.ShowSplashScreen();
                        connection.Open();
                        command.ExecuteNonQuery();
                       // s(90);
                      //  loading.Close();
                        connection.Close();
                        SplashScreenManager.CloseForm();
                    }
                }


            }
            SplashScreenManager.CloseForm();
        }

        private void cbContest_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            if (cbContest.Checked)
            {
                cbShift.Checked = false;
            }
        }

        private void cbShift_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            if (cbShift.Checked)
            {
                cbContest.Checked = false;
            }
        }

        private void rbtnStatusContest_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() != typeof(frmTrangThaiDiaDiemThi))
                {
                    f.Close();
                    f.Dispose();

                }
                else
              if (f.GetType() == typeof(frmTrangThaiDiaDiemThi))
                {
                    f.Activate();
                    return;
                }
            }
            frmTrangThaiDiaDiemThi form1 = new frmTrangThaiDiaDiemThi(_LocationID);
            form1.MdiParent = this;
            form1.Show();
        }
        private void rbtnPhanCong_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() != typeof(FrmPhanCongGiamThi))
                {
                    f.Close();
                    f.Dispose();

                }
                else
              if (f.GetType() == typeof(FrmPhanCongGiamThi))
                {
                    f.Activate();
                    return;
                }
            }
            FrmPhanCongGiamThi form1 = new FrmPhanCongGiamThi(_LocationID);
            form1.MdiParent = this;
            form1.Show();
        }

        private void rbtnTrangThaiDiaDiem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() != typeof(frmTrangThaiDiaDiemThi))
                {
                    f.Close();
                    f.Dispose();

                }
                else
              if (f.GetType() == typeof(frmTrangThaiDiaDiemThi))
                {
                    f.Activate();
                    return;
                }
            }
            frmTrangThaiDiaDiemThi form1 = new frmTrangThaiDiaDiemThi(_LocationID);
            form1.MdiParent = this;
            form1.Show();
        }

        private void rbtnStopShift_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() != typeof(frmTrangThaiDiaDiemThi))
                {
                    f.Close();
                    f.Dispose();

                }
                else
              if (f.GetType() == typeof(frmTrangThaiDiaDiemThi))
                {
                    f.Activate();
                    return;
                }
            }
            frmTrangThaiDiaDiemThi form1 = new frmTrangThaiDiaDiemThi(_LocationID);
            form1.MdiParent = this;
            form1.Show();
        }

        private void rbtnDanhSachThiSinh_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowSplashScreen();
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() != typeof(frmQuanLyThiSinh))
                {
                    f.Close();
                    f.Dispose();

                }
                else
              if (f.GetType() == typeof(frmQuanLyThiSinh))
                {
                    f.Activate();
                    SplashScreenManager.CloseForm();
                    return;

                }
            }
            frmQuanLyThiSinh form1 = new frmQuanLyThiSinh(_ContestID, _LocationID);
            form1.MdiParent = this;
            form1.Show();
            SplashScreenManager.CloseForm();
        }

        private void RbtnLocationReport_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() != typeof(frmTrangThaiDDThi))
                {
                    f.Close();
                    f.Dispose();

                }
                else
              if (f.GetType() == typeof(frmTrangThaiDDThi))
                {
                    f.Activate();
                    return;
                }
            }
            frmTrangThaiDDThi form1 = new frmTrangThaiDDThi(_ContestID,_LocationID,_StaffID);
            form1.MdiParent = this;
            form1.Show();
        }

        private void RibbonButton1_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowSplashScreen();
            Thread.Sleep(100);

            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() != typeof(frmKetQuaDauRa))
                {
                    f.Close();
                    f.Dispose();

                }
                else
                 if (f.GetType() == typeof(frmKetQuaDauRa))
                {

                   
                    f.Refresh();
                    f.Activate();
                    SplashScreenManager.CloseForm();
                    return;
                }
            }
            rbtnWritting.Checked = false;
            rbtnSpeaking1.Checked = false;
            rbtnReport.Checked = true;


            frmKetQuaDauRa form1 = new frmKetQuaDauRa(_ContestID,  _LocationID);
                form1.MdiParent = this;
                form1.Show();

            this.Update();
            SplashScreenManager.CloseForm();
        }

        private void RReScore_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowSplashScreen();
            Thread.Sleep(100);
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() != typeof(frmWritingPhucTra))
                {
                    f.Close();
                    f.Dispose();

                }
                else if (f.GetType() == typeof(frmWritingPhucTra))
                {

                    //if (cbContest.Checked)
                    //{
                    //    (f as frmWriting)._TypeShow = 1;
                    //    (f as frmWriting).InitControl();
                    //}
                    //else
                    //{
                    //    (f as frmWriting)._TypeShow = 2;
                    //    (f as frmWriting).InitControl();
                    //}
                    (f as frmWritingPhucTra).InitControl();
                    f.Refresh();
                    f.Activate();
                    SplashScreenManager.CloseForm();
                    return;
                }
            }
            frmWritingPhucTra form1 = new frmWritingPhucTra(_ContestID, _LocationID);
                form1.MdiParent = this;
                form1.Show();

            this.Update();
            SplashScreenManager.CloseForm();
        }

    
    }
}
