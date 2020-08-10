namespace EXON.MONITOR
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
               System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
               this.ribbon1 = new System.Windows.Forms.Ribbon();
               this.rbQuanLyHoiDong = new System.Windows.Forms.RibbonTab();
               this.ribbonPanel5 = new System.Windows.Forms.RibbonPanel();
               this.rbtnPhanCong = new System.Windows.Forms.RibbonButton();
               this.rbtnTrangThaiDiaDiem = new System.Windows.Forms.RibbonButton();
               this.rbtnLocationReport = new System.Windows.Forms.RibbonButton();
               this.rbMonitor = new System.Windows.Forms.RibbonTab();
               this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
               this.rbtnGiamSat = new System.Windows.Forms.RibbonButton();
               this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
               this.rbtnStatusComputer = new System.Windows.Forms.RibbonButton();
               this.ribbonPanel6 = new System.Windows.Forms.RibbonPanel();
               this.rbtnDanhSachThiSinh = new System.Windows.Forms.RibbonButton();
               this.ribbonPanel8 = new System.Windows.Forms.RibbonPanel();
               this.rbtnBackupDB = new System.Windows.Forms.RibbonButton();
               this.rbTestEL = new System.Windows.Forms.RibbonTab();
               this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
               this.rbtnSpeaking1 = new System.Windows.Forms.RibbonButton();
               this.rbtnWritting = new System.Windows.Forms.RibbonButton();
               this.rbtnReport = new System.Windows.Forms.RibbonButton();
               this.rReScore = new System.Windows.Forms.RibbonButton();
               this.cbContest = new System.Windows.Forms.RibbonCheckBox();
               this.cbShift = new System.Windows.Forms.RibbonCheckBox();
               this.pnlXuatKetQuaDauRa = new System.Windows.Forms.RibbonPanel();
               this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
               this.rbHelp = new System.Windows.Forms.RibbonTab();
               this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
               this.rbtnHelp = new System.Windows.Forms.RibbonButton();
               this.rbtnVersion = new System.Windows.Forms.RibbonButton();
               this.rbtnStatusContest = new System.Windows.Forms.RibbonButton();
               this.SuspendLayout();
               // 
               // ribbon1
               // 
               this.ribbon1.CaptionBarVisible = false;
               this.ribbon1.Font = new System.Drawing.Font("Trebuchet MS", 9F);
               this.ribbon1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
               this.ribbon1.Location = new System.Drawing.Point(20, 60);
               this.ribbon1.Minimized = false;
               this.ribbon1.Name = "ribbon1";
               // 
               // 
               // 
               this.ribbon1.OrbDropDown.BorderRoundness = 8;
               this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
               this.ribbon1.OrbDropDown.Name = "";
               this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 447);
               this.ribbon1.OrbDropDown.TabIndex = 0;
               this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
               this.ribbon1.OrbText = "";
               this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
               this.ribbon1.Size = new System.Drawing.Size(982, 129);
               this.ribbon1.TabIndex = 0;
               this.ribbon1.Tabs.Add(this.rbQuanLyHoiDong);
               this.ribbon1.Tabs.Add(this.rbMonitor);
               this.ribbon1.Tabs.Add(this.rbTestEL);
               this.ribbon1.Tabs.Add(this.rbHelp);
               this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(5, 2, 20, 0);
               this.ribbon1.TabSpacing = 4;
               this.ribbon1.Text = "ribbon1";
               this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Green;
               // 
               // rbQuanLyHoiDong
               // 
               this.rbQuanLyHoiDong.Name = "rbQuanLyHoiDong";
               this.rbQuanLyHoiDong.Panels.Add(this.ribbonPanel5);
               this.rbQuanLyHoiDong.Text = "Quản lý hội đồng thi";
               this.rbQuanLyHoiDong.Visible = false;
               // 
               // ribbonPanel5
               // 
               this.ribbonPanel5.Items.Add(this.rbtnPhanCong);
               this.ribbonPanel5.Items.Add(this.rbtnTrangThaiDiaDiem);
               this.ribbonPanel5.Items.Add(this.rbtnLocationReport);
               this.ribbonPanel5.Name = "ribbonPanel5";
               this.ribbonPanel5.Text = "Quản lý hội đồng thi";
               // 
               // rbtnPhanCong
               // 
               this.rbtnPhanCong.Image = global::EXON.MONITOR.Properties.Resources.study;
               this.rbtnPhanCong.LargeImage = global::EXON.MONITOR.Properties.Resources.study;
               this.rbtnPhanCong.MaximumSize = new System.Drawing.Size(100, 0);
               this.rbtnPhanCong.MinimumSize = new System.Drawing.Size(70, 0);
               this.rbtnPhanCong.Name = "rbtnPhanCong";
               this.rbtnPhanCong.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnPhanCong.SmallImage")));
               this.rbtnPhanCong.Text = "Phân công ";
               this.rbtnPhanCong.Click += new System.EventHandler(this.rbtnPhanCong_Click);
               // 
               // rbtnTrangThaiDiaDiem
               // 
               this.rbtnTrangThaiDiaDiem.Image = global::EXON.MONITOR.Properties.Resources.placeholder;
               this.rbtnTrangThaiDiaDiem.LargeImage = global::EXON.MONITOR.Properties.Resources.placeholder;
               this.rbtnTrangThaiDiaDiem.MinimumSize = new System.Drawing.Size(100, 0);
               this.rbtnTrangThaiDiaDiem.Name = "rbtnTrangThaiDiaDiem";
               this.rbtnTrangThaiDiaDiem.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnTrangThaiDiaDiem.SmallImage")));
               this.rbtnTrangThaiDiaDiem.Text = "Trạng thái địa điểm thi";
               this.rbtnTrangThaiDiaDiem.Click += new System.EventHandler(this.rbtnTrangThaiDiaDiem_Click);
               // 
               // rbtnLocationReport
               // 
               this.rbtnLocationReport.Image = global::EXON.MONITOR.Properties.Resources.report;
               this.rbtnLocationReport.LargeImage = global::EXON.MONITOR.Properties.Resources.report;
               this.rbtnLocationReport.MinimumSize = new System.Drawing.Size(80, 0);
               this.rbtnLocationReport.Name = "rbtnLocationReport";
               this.rbtnLocationReport.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnLocationReport.SmallImage")));
               this.rbtnLocationReport.Text = "Xuất báo cáo ca thi";
               this.rbtnLocationReport.Click += new System.EventHandler(this.RbtnLocationReport_Click);
               // 
               // rbMonitor
               // 
               this.rbMonitor.Name = "rbMonitor";
               this.rbMonitor.Panels.Add(this.ribbonPanel1);
               this.rbMonitor.Panels.Add(this.ribbonPanel2);
               this.rbMonitor.Panels.Add(this.ribbonPanel6);
               this.rbMonitor.Panels.Add(this.ribbonPanel8);
               this.rbMonitor.Text = "Giám sát cuộc thi";
               // 
               // ribbonPanel1
               // 
               this.ribbonPanel1.Items.Add(this.rbtnGiamSat);
               this.ribbonPanel1.Name = "ribbonPanel1";
               this.ribbonPanel1.Text = "Giám sát cuộc thi";
               // 
               // rbtnGiamSat
               // 
               this.rbtnGiamSat.Image = global::EXON.MONITOR.Properties.Resources.television;
               this.rbtnGiamSat.LargeImage = global::EXON.MONITOR.Properties.Resources.television;
               this.rbtnGiamSat.MinimumSize = new System.Drawing.Size(70, 80);
               this.rbtnGiamSat.Name = "rbtnGiamSat";
               this.rbtnGiamSat.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnGiamSat.SmallImage")));
               this.rbtnGiamSat.Text = "Giám sát";
               this.rbtnGiamSat.Click += new System.EventHandler(this.rbtnGiamSat_Click);
               // 
               // ribbonPanel2
               // 
               this.ribbonPanel2.Items.Add(this.rbtnStatusComputer);
               this.ribbonPanel2.Name = "ribbonPanel2";
               this.ribbonPanel2.Text = "Kiểm tra phòng thi";
               // 
               // rbtnStatusComputer
               // 
               this.rbtnStatusComputer.Image = global::EXON.MONITOR.Properties.Resources.stick_man;
               this.rbtnStatusComputer.LargeImage = global::EXON.MONITOR.Properties.Resources.stick_man;
               this.rbtnStatusComputer.MinimumSize = new System.Drawing.Size(70, 80);
               this.rbtnStatusComputer.Name = "rbtnStatusComputer";
               this.rbtnStatusComputer.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnStatusComputer.SmallImage")));
               this.rbtnStatusComputer.Text = "Tình trạng máy";
               this.rbtnStatusComputer.Click += new System.EventHandler(this.rbtnStatusComputer_Click);
               // 
               // ribbonPanel6
               // 
               this.ribbonPanel6.Items.Add(this.rbtnDanhSachThiSinh);
               this.ribbonPanel6.Name = "ribbonPanel6";
               this.ribbonPanel6.Text = "Quản lý thí sinh";
               // 
               // rbtnDanhSachThiSinh
               // 
               this.rbtnDanhSachThiSinh.Image = global::EXON.MONITOR.Properties.Resources.student;
               this.rbtnDanhSachThiSinh.LargeImage = global::EXON.MONITOR.Properties.Resources.student;
               this.rbtnDanhSachThiSinh.MinimumSize = new System.Drawing.Size(80, 0);
               this.rbtnDanhSachThiSinh.Name = "rbtnDanhSachThiSinh";
               this.rbtnDanhSachThiSinh.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnDanhSachThiSinh.SmallImage")));
               this.rbtnDanhSachThiSinh.Text = "Danh sách thí sinh";
               this.rbtnDanhSachThiSinh.Click += new System.EventHandler(this.rbtnDanhSachThiSinh_Click);
               // 
               // ribbonPanel8
               // 
               this.ribbonPanel8.Items.Add(this.rbtnBackupDB);
               this.ribbonPanel8.Name = "ribbonPanel8";
               this.ribbonPanel8.Text = "Sao lưu CSDL";
               // 
               // rbtnBackupDB
               // 
               this.rbtnBackupDB.Image = ((System.Drawing.Image)(resources.GetObject("rbtnBackupDB.Image")));
               this.rbtnBackupDB.LargeImage = ((System.Drawing.Image)(resources.GetObject("rbtnBackupDB.LargeImage")));
               this.rbtnBackupDB.Name = "rbtnBackupDB";
               this.rbtnBackupDB.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnBackupDB.SmallImage")));
               this.rbtnBackupDB.Click += new System.EventHandler(this.rbtnBackupDB_Click);
               // 
               // rbTestEL
               // 
               this.rbTestEL.Name = "rbTestEL";
               this.rbTestEL.Panels.Add(this.ribbonPanel3);
               this.rbTestEL.Panels.Add(this.pnlXuatKetQuaDauRa);
               this.rbTestEL.Text = "Chấm điểm ";
               // 
               // ribbonPanel3
               // 
               this.ribbonPanel3.Items.Add(this.rbtnSpeaking1);
               this.ribbonPanel3.Items.Add(this.rbtnWritting);
               this.ribbonPanel3.Items.Add(this.rbtnReport);
               this.ribbonPanel3.Items.Add(this.rReScore);
               this.ribbonPanel3.Items.Add(this.cbContest);
               this.ribbonPanel3.Items.Add(this.cbShift);
               this.ribbonPanel3.Name = "ribbonPanel3";
               this.ribbonPanel3.Text = "Chấm thi            ";
               // 
               // rbtnSpeaking1
               // 
               this.rbtnSpeaking1.Image = ((System.Drawing.Image)(resources.GetObject("rbtnSpeaking1.Image")));
               this.rbtnSpeaking1.LargeImage = ((System.Drawing.Image)(resources.GetObject("rbtnSpeaking1.LargeImage")));
               this.rbtnSpeaking1.MinimumSize = new System.Drawing.Size(70, 80);
               this.rbtnSpeaking1.Name = "rbtnSpeaking1";
               this.rbtnSpeaking1.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnSpeaking1.SmallImage")));
               this.rbtnSpeaking1.Text = "Chấm thi nói";
               this.rbtnSpeaking1.Click += new System.EventHandler(this.rbtnSpeaking1_Click);
               // 
               // rbtnWritting
               // 
               this.rbtnWritting.Image = ((System.Drawing.Image)(resources.GetObject("rbtnWritting.Image")));
               this.rbtnWritting.LargeImage = ((System.Drawing.Image)(resources.GetObject("rbtnWritting.LargeImage")));
               this.rbtnWritting.MinimumSize = new System.Drawing.Size(70, 80);
               this.rbtnWritting.Name = "rbtnWritting";
               this.rbtnWritting.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnWritting.SmallImage")));
               this.rbtnWritting.Text = "Chấm thi viêt";
               this.rbtnWritting.Click += new System.EventHandler(this.rbtnWritting_Click);
               // 
               // rbtnReport
               // 
               this.rbtnReport.Image = ((System.Drawing.Image)(resources.GetObject("rbtnReport.Image")));
               this.rbtnReport.LargeImage = ((System.Drawing.Image)(resources.GetObject("rbtnReport.LargeImage")));
               this.rbtnReport.MinimumSize = new System.Drawing.Size(70, 80);
               this.rbtnReport.Name = "rbtnReport";
               this.rbtnReport.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnReport.SmallImage")));
               this.rbtnReport.Text = "Xuất báo cáo";
               this.rbtnReport.Click += new System.EventHandler(this.rbtnReport_Click);
               // 
               // rReScore
               // 
               this.rReScore.Image = global::EXON.MONITOR.Properties.Resources.checklist;
               this.rReScore.LargeImage = global::EXON.MONITOR.Properties.Resources.checklist;
               this.rReScore.MaximumSize = new System.Drawing.Size(80, 0);
               this.rReScore.MinimumSize = new System.Drawing.Size(60, 0);
               this.rReScore.Name = "rReScore";
               this.rReScore.SmallImage = ((System.Drawing.Image)(resources.GetObject("rReScore.SmallImage")));
               this.rReScore.Text = "Phúc tra";
               this.rReScore.Click += new System.EventHandler(this.RReScore_Click);
               // 
               // cbContest
               // 
               this.cbContest.Name = "cbContest";
               this.cbContest.Text = "Cuộc thi";
               this.cbContest.CheckBoxCheckChanged += new System.EventHandler(this.cbContest_CheckBoxCheckChanged);
               // 
               // cbShift
               // 
               this.cbShift.Checked = true;
               this.cbShift.Name = "cbShift";
               this.cbShift.Text = "Ca thi";
               this.cbShift.CheckBoxCheckChanged += new System.EventHandler(this.cbShift_CheckBoxCheckChanged);
               // 
               // pnlXuatKetQuaDauRa
               // 
               this.pnlXuatKetQuaDauRa.Items.Add(this.ribbonButton1);
               this.pnlXuatKetQuaDauRa.Name = "pnlXuatKetQuaDauRa";
               this.pnlXuatKetQuaDauRa.Text = "Xuất kết quả";
               // 
               // ribbonButton1
               // 
               this.ribbonButton1.Image = global::EXON.MONITOR.Properties.Resources.report;
               this.ribbonButton1.LargeImage = global::EXON.MONITOR.Properties.Resources.report;
               this.ribbonButton1.MinimumSize = new System.Drawing.Size(80, 0);
               this.ribbonButton1.Name = "ribbonButton1";
               this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
               this.ribbonButton1.Text = "Kết quả ngoại ngữ";
               this.ribbonButton1.Click += new System.EventHandler(this.RibbonButton1_Click);
               // 
               // rbHelp
               // 
               this.rbHelp.Name = "rbHelp";
               this.rbHelp.Panels.Add(this.ribbonPanel4);
               this.rbHelp.Text = "Trợ giúp";
               // 
               // ribbonPanel4
               // 
               this.ribbonPanel4.Items.Add(this.rbtnHelp);
               this.ribbonPanel4.Items.Add(this.rbtnVersion);
               this.ribbonPanel4.Name = "ribbonPanel4";
               this.ribbonPanel4.Text = "Thông tin";
               // 
               // rbtnHelp
               // 
               this.rbtnHelp.Image = global::EXON.MONITOR.Properties.Resources.question;
               this.rbtnHelp.LargeImage = global::EXON.MONITOR.Properties.Resources.question;
               this.rbtnHelp.MinimumSize = new System.Drawing.Size(70, 80);
               this.rbtnHelp.Name = "rbtnHelp";
               this.rbtnHelp.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnHelp.SmallImage")));
               this.rbtnHelp.Text = "Hướng dẫn";
               // 
               // rbtnVersion
               // 
               this.rbtnVersion.Image = global::EXON.MONITOR.Properties.Resources.info;
               this.rbtnVersion.LargeImage = global::EXON.MONITOR.Properties.Resources.info;
               this.rbtnVersion.MinimumSize = new System.Drawing.Size(70, 80);
               this.rbtnVersion.Name = "rbtnVersion";
               this.rbtnVersion.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnVersion.SmallImage")));
               this.rbtnVersion.Text = "Thông tin ";
               // 
               // rbtnStatusContest
               // 
               this.rbtnStatusContest.Image = global::EXON.MONITOR.Properties.Resources.report;
               this.rbtnStatusContest.LargeImage = global::EXON.MONITOR.Properties.Resources.report;
               this.rbtnStatusContest.MinimumSize = new System.Drawing.Size(70, 80);
               this.rbtnStatusContest.Name = "rbtnStatusContest";
               this.rbtnStatusContest.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnStatusContest.SmallImage")));
               this.rbtnStatusContest.Text = "Xuất báo cáo";
               this.rbtnStatusContest.Click += new System.EventHandler(this.rbtnStatusContest_Click);
               // 
               // frmMain
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(1022, 559);
               this.Controls.Add(this.ribbon1);
               this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
               this.IsMdiContainer = true;
               this.KeyPreview = true;
               this.Name = "frmMain";
               this.Text = "Chương trình tổ chức thi";
               this.TransparencyKey = System.Drawing.Color.Empty;
               this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
               this.Load += new System.EventHandler(this.frmMain_Load);
               this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab rbMonitor;
 
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
       
        private System.Windows.Forms.RibbonTab rbTestEL;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonButton rbtnGiamSat;

  
        private System.Windows.Forms.RibbonTab rbHelp;

        private System.Windows.Forms.RibbonPanel ribbonPanel8;
        private System.Windows.Forms.RibbonButton rbtnBackupDB;
        private System.Windows.Forms.RibbonButton rbtnWritting;
        private System.Windows.Forms.RibbonButton rbtnSpeaking1;
        private System.Windows.Forms.RibbonCheckBox cbContest;
        private System.Windows.Forms.RibbonCheckBox cbShift;
        private System.Windows.Forms.RibbonButton rbtnReport;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonButton rbtnStatusComputer;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonButton rbtnHelp;
        private System.Windows.Forms.RibbonButton rbtnVersion;
        private System.Windows.Forms.RibbonTab rbQuanLyHoiDong;
        private System.Windows.Forms.RibbonPanel ribbonPanel5;
        private System.Windows.Forms.RibbonButton rbtnPhanCong;
        private System.Windows.Forms.RibbonButton rbtnTrangThaiDiaDiem;
        private System.Windows.Forms.RibbonPanel ribbonPanel6;
        private System.Windows.Forms.RibbonButton rbtnDanhSachThiSinh;
        private System.Windows.Forms.RibbonButton rbtnStatusContest;
        private System.Windows.Forms.RibbonButton rbtnLocationReport;
        private System.Windows.Forms.RibbonPanel pnlXuatKetQuaDauRa;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonButton rReScore;
    }
}