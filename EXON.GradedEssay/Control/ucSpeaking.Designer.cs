namespace EXON.GradedEssay.Control
{
    partial class ucSpeaking
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbSubject = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbStaff2 = new System.Windows.Forms.ComboBox();
            this.cbShift = new System.Windows.Forms.ComboBox();
            this.cbRoomTest = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbStaff1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnXacNhanGiaoVien = new System.Windows.Forms.Button();
            this.btnPrintRandom = new System.Windows.Forms.Button();
            this.btnExportScoreSpeaking = new System.Windows.Forms.Button();
            this.btnPrintTestSpeaking = new System.Windows.Forms.Button();
            this.btnPrintResult = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gvMain = new System.Windows.Forms.DataGridView();
            this.cTestNumberIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cContestantShiftID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbSubject);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbStaff2);
            this.groupBox1.Controls.Add(this.cbShift);
            this.groupBox1.Controls.Add(this.cbRoomTest);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbStaff1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1360, 108);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chấm thi nói";
            // 
            // cbSubject
            // 
            this.cbSubject.FormattingEnabled = true;
            this.cbSubject.Location = new System.Drawing.Point(983, 33);
            this.cbSubject.Name = "cbSubject";
            this.cbSubject.Size = new System.Drawing.Size(294, 21);
            this.cbSubject.TabIndex = 84;
            this.cbSubject.SelectedValueChanged += new System.EventHandler(this.cbSubject_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(915, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 83;
            this.label4.Text = "Môn thi";
            // 
            // cbStaff2
            // 
            this.cbStaff2.FormattingEnabled = true;
            this.cbStaff2.Location = new System.Drawing.Point(668, 63);
            this.cbStaff2.Name = "cbStaff2";
            this.cbStaff2.Size = new System.Drawing.Size(178, 21);
            this.cbStaff2.TabIndex = 76;
            // 
            // cbShift
            // 
            this.cbShift.FormattingEnabled = true;
            this.cbShift.Location = new System.Drawing.Point(203, 30);
            this.cbShift.Name = "cbShift";
            this.cbShift.Size = new System.Drawing.Size(319, 21);
            this.cbShift.TabIndex = 72;
            this.cbShift.SelectedValueChanged += new System.EventHandler(this.cbShift_SelectedValueChanged);
            // 
            // cbRoomTest
            // 
            this.cbRoomTest.FormattingEnabled = true;
            this.cbRoomTest.Location = new System.Drawing.Point(668, 30);
            this.cbRoomTest.Name = "cbRoomTest";
            this.cbRoomTest.Size = new System.Drawing.Size(178, 21);
            this.cbRoomTest.TabIndex = 78;
            this.cbRoomTest.SelectedValueChanged += new System.EventHandler(this.cbRoomTest_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(601, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 75;
            this.label3.Text = "Giáo viên 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Ca Thi";
            // 
            // cbStaff1
            // 
            this.cbStaff1.FormattingEnabled = true;
            this.cbStaff1.Location = new System.Drawing.Point(203, 63);
            this.cbStaff1.Name = "cbStaff1";
            this.cbStaff1.Size = new System.Drawing.Size(178, 21);
            this.cbStaff1.TabIndex = 74;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(601, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 77;
            this.label5.Text = "Phòng thi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 73;
            this.label2.Text = "Giáo viên 1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnXacNhanGiaoVien);
            this.groupBox2.Controls.Add(this.btnPrintRandom);
            this.groupBox2.Controls.Add(this.btnExportScoreSpeaking);
            this.groupBox2.Controls.Add(this.btnPrintTestSpeaking);
            this.groupBox2.Controls.Add(this.btnPrintResult);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 368);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1360, 71);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnXacNhanGiaoVien
            // 
            this.btnXacNhanGiaoVien.BackColor = System.Drawing.Color.Transparent;
            this.btnXacNhanGiaoVien.Image = global::EXON.GradedEssay.Properties.Resources.export_40_602457;
            this.btnXacNhanGiaoVien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXacNhanGiaoVien.Location = new System.Drawing.Point(20, 18);
            this.btnXacNhanGiaoVien.Name = "btnXacNhanGiaoVien";
            this.btnXacNhanGiaoVien.Size = new System.Drawing.Size(184, 36);
            this.btnXacNhanGiaoVien.TabIndex = 68;
            this.btnXacNhanGiaoVien.Text = "Xuất phiếu điểm xác nhận ";
            this.btnXacNhanGiaoVien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXacNhanGiaoVien.UseVisualStyleBackColor = false;
            this.btnXacNhanGiaoVien.Click += new System.EventHandler(this.BtnXacNhanGiaoVien_Click);
            // 
            // btnPrintRandom
            // 
            this.btnPrintRandom.Image = global::EXON.GradedEssay.Properties.Resources.print_22_157582;
            this.btnPrintRandom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintRandom.Location = new System.Drawing.Point(380, 18);
            this.btnPrintRandom.Name = "btnPrintRandom";
            this.btnPrintRandom.Size = new System.Drawing.Size(157, 36);
            this.btnPrintRandom.TabIndex = 67;
            this.btnPrintRandom.Text = "In đề thi nói ngẫu nhiên";
            this.btnPrintRandom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrintRandom.UseVisualStyleBackColor = true;
            this.btnPrintRandom.Click += new System.EventHandler(this.btnPrintRandom_Click);
            // 
            // btnExportScoreSpeaking
            // 
            this.btnExportScoreSpeaking.BackColor = System.Drawing.Color.Transparent;
            this.btnExportScoreSpeaking.Image = global::EXON.GradedEssay.Properties.Resources.export_40_602457;
            this.btnExportScoreSpeaking.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportScoreSpeaking.Location = new System.Drawing.Point(224, 18);
            this.btnExportScoreSpeaking.Name = "btnExportScoreSpeaking";
            this.btnExportScoreSpeaking.Size = new System.Drawing.Size(125, 36);
            this.btnExportScoreSpeaking.TabIndex = 64;
            this.btnExportScoreSpeaking.Text = "Xuất phiếu điểm";
            this.btnExportScoreSpeaking.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportScoreSpeaking.UseVisualStyleBackColor = false;
            this.btnExportScoreSpeaking.Click += new System.EventHandler(this.btnExportScoreSpeaking_Click);
            // 
            // btnPrintTestSpeaking
            // 
            this.btnPrintTestSpeaking.Image = global::EXON.GradedEssay.Properties.Resources.print_22_157582;
            this.btnPrintTestSpeaking.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintTestSpeaking.Location = new System.Drawing.Point(568, 19);
            this.btnPrintTestSpeaking.Name = "btnPrintTestSpeaking";
            this.btnPrintTestSpeaking.Size = new System.Drawing.Size(134, 36);
            this.btnPrintTestSpeaking.TabIndex = 66;
            this.btnPrintTestSpeaking.Text = "In đề thi nói theo ca";
            this.btnPrintTestSpeaking.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrintTestSpeaking.UseVisualStyleBackColor = true;
            this.btnPrintTestSpeaking.Click += new System.EventHandler(this.btnPrintTestSpeaking_Click);
            // 
            // btnPrintResult
            // 
            this.btnPrintResult.Image = global::EXON.GradedEssay.Properties.Resources.print_65_445177;
            this.btnPrintResult.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintResult.Location = new System.Drawing.Point(733, 18);
            this.btnPrintResult.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrintResult.Name = "btnPrintResult";
            this.btnPrintResult.Size = new System.Drawing.Size(125, 36);
            this.btnPrintResult.TabIndex = 65;
            this.btnPrintResult.Text = "In kết quả ";
            this.btnPrintResult.UseVisualStyleBackColor = true;
            this.btnPrintResult.Click += new System.EventHandler(this.btnPrintResult_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Image = global::EXON.GradedEssay.Properties.Resources.save_309_1098126;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(889, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 36);
            this.btnSave.TabIndex = 63;
            this.btnSave.Text = "Lưu Lại";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gvMain);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 108);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1360, 260);
            this.groupBox3.TabIndex = 2;
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
            this.Column4,
            this.cMTS,
            this.Column1,
            this.cScore,
            this.Column2,
            this.cUnit,
            this.cContestantShiftID});
            this.gvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvMain.Location = new System.Drawing.Point(3, 16);
            this.gvMain.Name = "gvMain";
            this.gvMain.Size = new System.Drawing.Size(1354, 241);
            this.gvMain.TabIndex = 59;
            this.gvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMain_CellClick);
            this.gvMain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMain_CellContentClick);
            this.gvMain.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMain_CellValueChanged);
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
            this.cMTS.HeaderText = "Số Báo Danh";
            this.cMTS.Name = "cMTS";
            this.cMTS.ReadOnly = true;
            this.cMTS.Width = 210;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "FullName";
            this.Column1.HeaderText = "Họ Tên";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // cScore
            // 
            this.cScore.DataPropertyName = "Score";
            this.cScore.HeaderText = "Điểm";
            this.cScore.Name = "cScore";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.DataPropertyName = "DOB";
            this.Column2.HeaderText = "Ngày Sinh";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // cUnit
            // 
            this.cUnit.DataPropertyName = "Unit";
            this.cUnit.HeaderText = "Lớp";
            this.cUnit.Name = "cUnit";
            this.cUnit.Width = 300;
            // 
            // cContestantShiftID
            // 
            this.cContestantShiftID.DataPropertyName = "ContestantShiftID";
            this.cContestantShiftID.HeaderText = "ContestantShiftID";
            this.cContestantShiftID.Name = "cContestantShiftID";
            this.cContestantShiftID.Visible = false;
            // 
            // ucSpeaking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucSpeaking";
            this.Size = new System.Drawing.Size(1360, 439);
            this.Load += new System.EventHandler(this.ucSpeaking_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnExportScoreSpeaking;
        private System.Windows.Forms.Button btnPrintTestSpeaking;
        private System.Windows.Forms.Button btnPrintResult;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView gvMain;
        private System.Windows.Forms.ComboBox cbStaff2;
        private System.Windows.Forms.ComboBox cbShift;
        private System.Windows.Forms.ComboBox cbRoomTest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbStaff1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrintRandom;
        private System.Windows.Forms.ComboBox cbSubject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnXacNhanGiaoVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTestNumberIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn cContestantShiftID;
    }
}
