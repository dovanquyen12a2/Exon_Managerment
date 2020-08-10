namespace EXON.GradedEssay.Control
{
    partial class ucWrittingPhucTra
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gvMain = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPrintResult = new System.Windows.Forms.Button();
            this.btnExportScoreWritting = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDivisionShiftID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbSubject = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbStaff2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbStaff1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbRoomTest = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbShift = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cTestNumberIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScoreSpeaking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cScoreWritting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDiemNghe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDiemTong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cScoreTNPhucTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDiemVietPhucTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbtnXemBaiLam = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cContestantShiftID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gvMain);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 96);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1360, 272);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách thí sinh";
            // 
            // gvMain
            // 
            this.gvMain.AllowUserToAddRows = false;
            this.gvMain.AllowUserToDeleteRows = false;
            this.gvMain.AllowUserToOrderColumns = true;
            this.gvMain.BackgroundColor = System.Drawing.Color.White;
            this.gvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cTestNumberIndex,
            this.cMTS,
            this.Column1,
            this.Column2,
            this.ScoreSpeaking,
            this.cScore,
            this.cScoreWritting,
            this.cDiemNghe,
            this.cDiemTong,
            this.cScoreTNPhucTra,
            this.cDiemVietPhucTra,
            this.cbtnXemBaiLam,
            this.cContestantShiftID});
            this.gvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvMain.Location = new System.Drawing.Point(3, 16);
            this.gvMain.Name = "gvMain";
            this.gvMain.Size = new System.Drawing.Size(1354, 253);
            this.gvMain.TabIndex = 60;
            this.gvMain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMain_CellContentClick);
            this.gvMain.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMain_CellValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPrintResult);
            this.groupBox2.Controls.Add(this.btnExportScoreWritting);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 368);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1360, 71);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // btnPrintResult
            // 
            this.btnPrintResult.Image = global::EXON.GradedEssay.Properties.Resources.print_65_445177;
            this.btnPrintResult.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintResult.Location = new System.Drawing.Point(427, 19);
            this.btnPrintResult.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrintResult.Name = "btnPrintResult";
            this.btnPrintResult.Size = new System.Drawing.Size(125, 36);
            this.btnPrintResult.TabIndex = 28;
            this.btnPrintResult.Text = "In kết quả ";
            this.btnPrintResult.UseVisualStyleBackColor = true;
            this.btnPrintResult.Click += new System.EventHandler(this.btnPrintResult_Click);
            // 
            // btnExportScoreWritting
            // 
            this.btnExportScoreWritting.BackColor = System.Drawing.Color.Transparent;
            this.btnExportScoreWritting.Image = global::EXON.GradedEssay.Properties.Resources.export_40_602457;
            this.btnExportScoreWritting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportScoreWritting.Location = new System.Drawing.Point(281, 19);
            this.btnExportScoreWritting.Name = "btnExportScoreWritting";
            this.btnExportScoreWritting.Size = new System.Drawing.Size(125, 36);
            this.btnExportScoreWritting.TabIndex = 27;
            this.btnExportScoreWritting.Text = "Xuất phiếu điểm";
            this.btnExportScoreWritting.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportScoreWritting.UseVisualStyleBackColor = false;
            this.btnExportScoreWritting.Click += new System.EventHandler(this.btnExportScoreWritting_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Image = global::EXON.GradedEssay.Properties.Resources.save_309_1098126;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(578, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 36);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "Nhập điểm";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDivisionShiftID);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbSubject);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbStaff2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbStaff1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbRoomTest);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbShift);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1360, 96);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chấm thi viết";
            // 
            // txtDivisionShiftID
            // 
            this.txtDivisionShiftID.Enabled = false;
            this.txtDivisionShiftID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDivisionShiftID.Location = new System.Drawing.Point(206, 60);
            this.txtDivisionShiftID.Name = "txtDivisionShiftID";
            this.txtDivisionShiftID.Size = new System.Drawing.Size(100, 23);
            this.txtDivisionShiftID.TabIndex = 86;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(119, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 85;
            this.label6.Text = "Mã ca";
            // 
            // cbSubject
            // 
            this.cbSubject.FormattingEnabled = true;
            this.cbSubject.Location = new System.Drawing.Point(952, 18);
            this.cbSubject.Name = "cbSubject";
            this.cbSubject.Size = new System.Drawing.Size(309, 21);
            this.cbSubject.TabIndex = 82;
            this.cbSubject.SelectedValueChanged += new System.EventHandler(this.cbSubject_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(884, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 81;
            this.label5.Text = "Môn thi";
            // 
            // cbStaff2
            // 
            this.cbStaff2.FormattingEnabled = true;
            this.cbStaff2.Location = new System.Drawing.Point(951, 60);
            this.cbStaff2.Name = "cbStaff2";
            this.cbStaff2.Size = new System.Drawing.Size(193, 21);
            this.cbStaff2.TabIndex = 80;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(884, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 79;
            this.label3.Text = "Giáo viên 2";
            // 
            // cbStaff1
            // 
            this.cbStaff1.FormattingEnabled = true;
            this.cbStaff1.Location = new System.Drawing.Point(645, 60);
            this.cbStaff1.Name = "cbStaff1";
            this.cbStaff1.Size = new System.Drawing.Size(177, 21);
            this.cbStaff1.TabIndex = 78;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(545, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 77;
            this.label4.Text = "Giáo viên 1";
            // 
            // cbRoomTest
            // 
            this.cbRoomTest.FormattingEnabled = true;
            this.cbRoomTest.Location = new System.Drawing.Point(645, 18);
            this.cbRoomTest.Name = "cbRoomTest";
            this.cbRoomTest.Size = new System.Drawing.Size(193, 21);
            this.cbRoomTest.TabIndex = 17;
            this.cbRoomTest.SelectedValueChanged += new System.EventHandler(this.cbRoomTest_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(545, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Phòng thi";
            // 
            // cbShift
            // 
            this.cbShift.FormattingEnabled = true;
            this.cbShift.Location = new System.Drawing.Point(206, 18);
            this.cbShift.Name = "cbShift";
            this.cbShift.Size = new System.Drawing.Size(292, 21);
            this.cbShift.TabIndex = 15;
            this.cbShift.SelectedValueChanged += new System.EventHandler(this.cbShift_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Ca Thi";
            // 
            // cTestNumberIndex
            // 
            this.cTestNumberIndex.DataPropertyName = "STT";
            this.cTestNumberIndex.HeaderText = "STT";
            this.cTestNumberIndex.Name = "cTestNumberIndex";
            this.cTestNumberIndex.ReadOnly = true;
            this.cTestNumberIndex.Width = 50;
            // 
            // cMTS
            // 
            this.cMTS.DataPropertyName = "ContestantCode";
            this.cMTS.HeaderText = "Mã Thí Sinh";
            this.cMTS.Name = "cMTS";
            this.cMTS.ReadOnly = true;
            this.cMTS.Width = 120;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "FullName";
            this.Column1.HeaderText = "Họ Tên";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "DOB";
            this.Column2.HeaderText = "Ngày Sinh";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 120;
            // 
            // ScoreSpeaking
            // 
            this.ScoreSpeaking.DataPropertyName = "ScoreSpeaking";
            this.ScoreSpeaking.HeaderText = "Điểm Nói";
            this.ScoreSpeaking.Name = "ScoreSpeaking";
            this.ScoreSpeaking.Visible = false;
            // 
            // cScore
            // 
            this.cScore.DataPropertyName = "Score";
            this.cScore.HeaderText = "Điểm TN";
            this.cScore.Name = "cScore";
            // 
            // cScoreWritting
            // 
            this.cScoreWritting.DataPropertyName = "ScoreWritting";
            this.cScoreWritting.HeaderText = "Điểm Viết";
            this.cScoreWritting.Name = "cScoreWritting";
            // 
            // cDiemNghe
            // 
            this.cDiemNghe.DataPropertyName = "ScoreListening";
            this.cDiemNghe.HeaderText = "Điểm Nghe";
            this.cDiemNghe.Name = "cDiemNghe";
            this.cDiemNghe.Visible = false;
            // 
            // cDiemTong
            // 
            this.cDiemTong.DataPropertyName = "SumScore";
            this.cDiemTong.HeaderText = "Tổng Điểm";
            this.cDiemTong.Name = "cDiemTong";
            // 
            // cScoreTNPhucTra
            // 
            this.cScoreTNPhucTra.DataPropertyName = "ScoreReWritting";
            this.cScoreTNPhucTra.HeaderText = "Điểm TN chấm lại";
            this.cScoreTNPhucTra.Name = "cScoreTNPhucTra";
            this.cScoreTNPhucTra.Visible = false;
            // 
            // cDiemVietPhucTra
            // 
            this.cDiemVietPhucTra.DataPropertyName = "ScoreReWritting";
            this.cDiemVietPhucTra.HeaderText = "Điểm viết phúc tra";
            this.cDiemVietPhucTra.Name = "cDiemVietPhucTra";
            // 
            // cbtnXemBaiLam
            // 
            this.cbtnXemBaiLam.DataPropertyName = "PrintAnswer";
            this.cbtnXemBaiLam.HeaderText = "Bài làm";
            this.cbtnXemBaiLam.Name = "cbtnXemBaiLam";
            this.cbtnXemBaiLam.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cbtnXemBaiLam.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cbtnXemBaiLam.Width = 120;
            // 
            // cContestantShiftID
            // 
            this.cContestantShiftID.DataPropertyName = "ContestantShiftID";
            this.cContestantShiftID.HeaderText = "ContestantShiftID";
            this.cContestantShiftID.Name = "cContestantShiftID";
            this.cContestantShiftID.Visible = false;
            // 
            // ucWrittingPhucTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucWrittingPhucTra";
            this.Size = new System.Drawing.Size(1360, 439);
            this.Load += new System.EventHandler(this.ucWritting_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbShift;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrintResult;
        private System.Windows.Forms.Button btnExportScoreWritting;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbRoomTest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbStaff2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbStaff1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbSubject;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDivisionShiftID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView gvMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTestNumberIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScoreSpeaking;
        private System.Windows.Forms.DataGridViewTextBoxColumn cScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn cScoreWritting;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDiemNghe;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDiemTong;
        private System.Windows.Forms.DataGridViewTextBoxColumn cScoreTNPhucTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDiemVietPhucTra;
        private System.Windows.Forms.DataGridViewButtonColumn cbtnXemBaiLam;
        private System.Windows.Forms.DataGridViewTextBoxColumn cContestantShiftID;
    }
}
