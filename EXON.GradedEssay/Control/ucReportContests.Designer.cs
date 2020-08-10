namespace EXON.GradedEssay.Control
{
    partial class ucReportContests
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPrintResult = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSubject = new System.Windows.Forms.RadioButton();
            this.cbSubject = new System.Windows.Forms.ComboBox();
            this.cTestNumberIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScoreSpeaking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScoreWritting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cScoreListenning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cContestantShiftID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSumScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.ScoreWritting,
            this.cScore,
            this.cScoreListenning,
            this.cContestantShiftID,
            this.cSumScore});
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPrintResult);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 368);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(905, 71);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // btnPrintResult
            // 
            this.btnPrintResult.Image = global::EXON.GradedEssay.Properties.Resources.print_65_445177;
            this.btnPrintResult.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintResult.Location = new System.Drawing.Point(399, 18);
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
            this.groupBox1.Controls.Add(this.rbSubject);
            this.groupBox1.Controls.Add(this.cbSubject);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(905, 102);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Xuất báo cáo";
            // 
            // rbSubject
            // 
            this.rbSubject.AutoSize = true;
            this.rbSubject.Checked = true;
            this.rbSubject.Location = new System.Drawing.Point(219, 46);
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
            this.cbSubject.Location = new System.Drawing.Point(300, 46);
            this.cbSubject.Name = "cbSubject";
            this.cbSubject.Size = new System.Drawing.Size(431, 21);
            this.cbSubject.TabIndex = 88;
            this.cbSubject.SelectedValueChanged += new System.EventHandler(this.cbSubject_SelectedValueChanged);
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
            this.cMTS.HeaderText = "Số báo danh";
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
            this.ScoreSpeaking.HeaderText = "Điểm thi nói";
            this.ScoreSpeaking.Name = "ScoreSpeaking";
            // 
            // ScoreWritting
            // 
            this.ScoreWritting.DataPropertyName = "ScoreWritting";
            this.ScoreWritting.HeaderText = "Tự luận";
            this.ScoreWritting.Name = "ScoreWritting";
            // 
            // cScore
            // 
            this.cScore.DataPropertyName = "Score";
            this.cScore.HeaderText = "Điểm TN";
            this.cScore.Name = "cScore";
            // 
            // cScoreListenning
            // 
            this.cScoreListenning.DataPropertyName = "ScoreListen";
            this.cScoreListenning.HeaderText = "Điểm nghe";
            this.cScoreListenning.Name = "cScoreListenning";
            this.cScoreListenning.Visible = false;
            // 
            // cContestantShiftID
            // 
            this.cContestantShiftID.DataPropertyName = "ContestantShiftID";
            this.cContestantShiftID.HeaderText = "ContestantShiftID";
            this.cContestantShiftID.Name = "cContestantShiftID";
            this.cContestantShiftID.Visible = false;
            // 
            // cSumScore
            // 
            this.cSumScore.DataPropertyName = "SumScore";
            this.cSumScore.HeaderText = "Điểm tổng";
            this.cSumScore.Name = "cSumScore";
            // 
            // ucReportContests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucReportContests";
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbSubject;
        private System.Windows.Forms.ComboBox cbSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTestNumberIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScoreSpeaking;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScoreWritting;
        private System.Windows.Forms.DataGridViewTextBoxColumn cScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn cScoreListenning;
        private System.Windows.Forms.DataGridViewTextBoxColumn cContestantShiftID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSumScore;
    }
}
