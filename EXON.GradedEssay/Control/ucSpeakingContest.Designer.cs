namespace EXON.GradedEssay.Control
{
    partial class ucSpeakingContest
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.gvMain = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbSubject = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPrintResult = new System.Windows.Forms.Button();
            this.btnPrintTestSpeaking = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cTestNumberIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhongThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cContestantShiftID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1360, 368);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách tất cả thí sinh ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gvMain);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1354, 284);
            this.panel2.TabIndex = 64;
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
            this.PhongThi,
            this.cMTS,
            this.Column1,
            this.cScore,
            this.cUnit,
            this.Column2,
            this.cContestantShiftID});
            this.gvMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gvMain.Location = new System.Drawing.Point(0, 3);
            this.gvMain.Name = "gvMain";
            this.gvMain.Size = new System.Drawing.Size(1354, 281);
            this.gvMain.TabIndex = 61;
            this.gvMain.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.GvMain_CellValueChanged_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbSubject);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.MaximumSize = new System.Drawing.Size(0, 65);
            this.panel1.MinimumSize = new System.Drawing.Size(0, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1354, 65);
            this.panel1.TabIndex = 63;
            // 
            // cbSubject
            // 
            this.cbSubject.FormattingEnabled = true;
            this.cbSubject.Location = new System.Drawing.Point(339, 21);
            this.cbSubject.Name = "cbSubject";
            this.cbSubject.Size = new System.Drawing.Size(376, 21);
            this.cbSubject.TabIndex = 61;
            this.cbSubject.SelectedValueChanged += new System.EventHandler(this.cbSubject_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Môn thi";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPrintResult);
            this.groupBox2.Controls.Add(this.btnPrintTestSpeaking);
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
            this.btnPrintResult.Location = new System.Drawing.Point(407, 18);
            this.btnPrintResult.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrintResult.Name = "btnPrintResult";
            this.btnPrintResult.Size = new System.Drawing.Size(125, 36);
            this.btnPrintResult.TabIndex = 67;
            this.btnPrintResult.Text = "In kết quả ";
            this.btnPrintResult.UseVisualStyleBackColor = true;
            this.btnPrintResult.Click += new System.EventHandler(this.BtnPrintResult_Click);
            // 
            // btnPrintTestSpeaking
            // 
            this.btnPrintTestSpeaking.Image = global::EXON.GradedEssay.Properties.Resources.print_22_157582;
            this.btnPrintTestSpeaking.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintTestSpeaking.Location = new System.Drawing.Point(580, 19);
            this.btnPrintTestSpeaking.Name = "btnPrintTestSpeaking";
            this.btnPrintTestSpeaking.Size = new System.Drawing.Size(169, 36);
            this.btnPrintTestSpeaking.TabIndex = 66;
            this.btnPrintTestSpeaking.Text = "In Đề Thi Nói Ngẫu Nhiên";
            this.btnPrintTestSpeaking.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrintTestSpeaking.UseVisualStyleBackColor = true;
            this.btnPrintTestSpeaking.Click += new System.EventHandler(this.btnPrintTestSpeaking_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Image = global::EXON.GradedEssay.Properties.Resources.save_309_1098126;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(810, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 36);
            this.btnSave.TabIndex = 63;
            this.btnSave.Text = "Lưu Lại";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.DataPropertyName = "ShiftName";
            this.Column4.HeaderText = "Ca Thi";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // PhongThi
            // 
            this.PhongThi.DataPropertyName = "PhongThi";
            this.PhongThi.HeaderText = "Phòng thi";
            this.PhongThi.Name = "PhongThi";
            // 
            // cMTS
            // 
            this.cMTS.DataPropertyName = "ContestantCode";
            this.cMTS.HeaderText = "Số Báo Danh";
            this.cMTS.Name = "cMTS";
            this.cMTS.ReadOnly = true;
            this.cMTS.Width = 200;
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
            this.cScore.Width = 150;
            // 
            // cUnit
            // 
            this.cUnit.DataPropertyName = "Unit";
            this.cUnit.HeaderText = "Lớp";
            this.cUnit.Name = "cUnit";
            this.cUnit.Width = 200;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "DOB";
            this.Column2.HeaderText = "Ngày Sinh";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // cContestantShiftID
            // 
            this.cContestantShiftID.DataPropertyName = "ContestantShiftID";
            this.cContestantShiftID.HeaderText = "ContestantShiftID";
            this.cContestantShiftID.Name = "cContestantShiftID";
            this.cContestantShiftID.Visible = false;
            // 
            // ucSpeakingContest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "ucSpeakingContest";
            this.Size = new System.Drawing.Size(1360, 439);
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnPrintTestSpeaking;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSubject;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gvMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPrintResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTestNumberIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhongThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cContestantShiftID;
    }
}
