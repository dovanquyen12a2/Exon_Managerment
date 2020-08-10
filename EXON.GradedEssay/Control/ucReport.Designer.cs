namespace EXON.GradedEssay.Control
{
    partial class ucReport
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
            this.gvMain = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbShift = new System.Windows.Forms.ComboBox();
            this.cbRoomTest = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnKetQuaLop = new System.Windows.Forms.Button();
            this.btnPrintResult = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbUnit = new System.Windows.Forms.RadioButton();
            this.rbSubject = new System.Windows.Forms.RadioButton();
            this.cbSubject = new System.Windows.Forms.ComboBox();
            this.cbLop = new System.Windows.Forms.ComboBox();
            this.cTestNumberIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScoreSpeaking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScoreWritting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDiemNghe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDiemTong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cContestantShiftID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.Column4,
            this.cMTS,
            this.Column1,
            this.Column2,
            this.ScoreSpeaking,
            this.cScore,
            this.ScoreWritting,
            this.cDiemNghe,
            this.cDiemTong,
            this.cContestantShiftID});
            this.gvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvMain.Location = new System.Drawing.Point(3, 16);
            this.gvMain.Name = "gvMain";
            this.gvMain.Size = new System.Drawing.Size(899, 247);
            this.gvMain.TabIndex = 59;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gvMain);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 102);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(905, 266);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách thí sinh";
            // 
            // cbShift
            // 
            this.cbShift.FormattingEnabled = true;
            this.cbShift.Location = new System.Drawing.Point(195, 24);
            this.cbShift.Name = "cbShift";
            this.cbShift.Size = new System.Drawing.Size(252, 21);
            this.cbShift.TabIndex = 72;
            this.cbShift.SelectedValueChanged += new System.EventHandler(this.cbShift_SelectedValueChanged);
            // 
            // cbRoomTest
            // 
            this.cbRoomTest.FormattingEnabled = true;
            this.cbRoomTest.Location = new System.Drawing.Point(195, 57);
            this.cbRoomTest.Name = "cbRoomTest";
            this.cbRoomTest.Size = new System.Drawing.Size(252, 21);
            this.cbRoomTest.TabIndex = 78;
            this.cbRoomTest.SelectedValueChanged += new System.EventHandler(this.cbRoomTest_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Ca Thi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(128, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 77;
            this.label5.Text = "Phòng thi";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnKetQuaLop);
            this.groupBox2.Controls.Add(this.btnPrintResult);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 368);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(905, 71);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // btnKetQuaLop
            // 
            this.btnKetQuaLop.Image = global::EXON.GradedEssay.Properties.Resources.print_65_445177;
            this.btnKetQuaLop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKetQuaLop.Location = new System.Drawing.Point(327, 18);
            this.btnKetQuaLop.Margin = new System.Windows.Forms.Padding(2);
            this.btnKetQuaLop.Name = "btnKetQuaLop";
            this.btnKetQuaLop.Size = new System.Drawing.Size(157, 36);
            this.btnKetQuaLop.TabIndex = 66;
            this.btnKetQuaLop.Text = "In kết quả  theo lớp";
            this.btnKetQuaLop.UseVisualStyleBackColor = true;
            this.btnKetQuaLop.Click += new System.EventHandler(this.btnKetQuaLop_Click);
            // 
            // btnPrintResult
            // 
            this.btnPrintResult.Image = global::EXON.GradedEssay.Properties.Resources.print_65_445177;
            this.btnPrintResult.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintResult.Location = new System.Drawing.Point(533, 18);
            this.btnPrintResult.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrintResult.Name = "btnPrintResult";
            this.btnPrintResult.Size = new System.Drawing.Size(157, 36);
            this.btnPrintResult.TabIndex = 65;
            this.btnPrintResult.Text = "In kết quả theo môn";
            this.btnPrintResult.UseVisualStyleBackColor = true;
            this.btnPrintResult.Click += new System.EventHandler(this.btnPrintResult_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbUnit);
            this.groupBox1.Controls.Add(this.rbSubject);
            this.groupBox1.Controls.Add(this.cbSubject);
            this.groupBox1.Controls.Add(this.cbLop);
            this.groupBox1.Controls.Add(this.cbShift);
            this.groupBox1.Controls.Add(this.cbRoomTest);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(905, 102);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Xuất báo cáo";
            // 
            // rbUnit
            // 
            this.rbUnit.AutoSize = true;
            this.rbUnit.Location = new System.Drawing.Point(496, 60);
            this.rbUnit.Name = "rbUnit";
            this.rbUnit.Size = new System.Drawing.Size(43, 17);
            this.rbUnit.TabIndex = 90;
            this.rbUnit.Text = "Lớp";
            this.rbUnit.UseVisualStyleBackColor = true;
            // 
            // rbSubject
            // 
            this.rbSubject.AutoSize = true;
            this.rbSubject.Checked = true;
            this.rbSubject.Location = new System.Drawing.Point(496, 28);
            this.rbSubject.Name = "rbSubject";
            this.rbSubject.Size = new System.Drawing.Size(60, 17);
            this.rbSubject.TabIndex = 89;
            this.rbSubject.TabStop = true;
            this.rbSubject.Text = "Môn thi";
            this.rbSubject.UseVisualStyleBackColor = true;
            // 
            // cbSubject
            // 
            this.cbSubject.FormattingEnabled = true;
            this.cbSubject.Location = new System.Drawing.Point(574, 24);
            this.cbSubject.Name = "cbSubject";
            this.cbSubject.Size = new System.Drawing.Size(193, 21);
            this.cbSubject.TabIndex = 88;
            this.cbSubject.SelectedValueChanged += new System.EventHandler(this.cbSubject_SelectedValueChanged);
            // 
            // cbLop
            // 
            this.cbLop.FormattingEnabled = true;
            this.cbLop.Location = new System.Drawing.Point(574, 60);
            this.cbLop.Name = "cbLop";
            this.cbLop.Size = new System.Drawing.Size(193, 21);
            this.cbLop.TabIndex = 86;
            this.cbLop.SelectedValueChanged += new System.EventHandler(this.cbLop_SelectedValueChanged);
            // 
            // cTestNumberIndex
            // 
            this.cTestNumberIndex.DataPropertyName = "STT";
            this.cTestNumberIndex.HeaderText = "STT";
            this.cTestNumberIndex.Name = "cTestNumberIndex";
            this.cTestNumberIndex.ReadOnly = true;
            this.cTestNumberIndex.Width = 50;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ShiftName";
            this.Column4.HeaderText = "Ca Thi";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            this.Column4.Width = 200;
            // 
            // cMTS
            // 
            this.cMTS.DataPropertyName = "ContestantCode";
            this.cMTS.HeaderText = "Mã Thí Sinh";
            this.cMTS.Name = "cMTS";
            this.cMTS.ReadOnly = true;
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
            // 
            // ScoreSpeaking
            // 
            this.ScoreSpeaking.DataPropertyName = "ScoreSpeaking";
            this.ScoreSpeaking.HeaderText = "Điểm Nói";
            this.ScoreSpeaking.Name = "ScoreSpeaking";
            // 
            // cScore
            // 
            this.cScore.DataPropertyName = "Score";
            this.cScore.HeaderText = "Điểm TN";
            this.cScore.Name = "cScore";
            // 
            // ScoreWritting
            // 
            this.ScoreWritting.DataPropertyName = "ScoreWritting";
            this.ScoreWritting.HeaderText = "Điểm Viết";
            this.ScoreWritting.Name = "ScoreWritting";
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
            // cContestantShiftID
            // 
            this.cContestantShiftID.DataPropertyName = "ContestantShiftID";
            this.cContestantShiftID.HeaderText = "ContestantShiftID";
            this.cContestantShiftID.Name = "cContestantShiftID";
            this.cContestantShiftID.Visible = false;
            // 
            // ucReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucReport";
            this.Size = new System.Drawing.Size(905, 439);
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView gvMain;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnPrintResult;
        private System.Windows.Forms.ComboBox cbShift;
        private System.Windows.Forms.ComboBox cbRoomTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbLop;
        private System.Windows.Forms.Button btnKetQuaLop;
        private System.Windows.Forms.RadioButton rbUnit;
        private System.Windows.Forms.RadioButton rbSubject;
        private System.Windows.Forms.ComboBox cbSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTestNumberIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScoreSpeaking;
        private System.Windows.Forms.DataGridViewTextBoxColumn cScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScoreWritting;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDiemNghe;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDiemTong;
        private System.Windows.Forms.DataGridViewTextBoxColumn cContestantShiftID;
    }
}
