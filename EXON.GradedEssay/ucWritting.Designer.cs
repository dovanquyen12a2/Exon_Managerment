namespace EXON.GradedEssay.Control
{
    partial class ucWritting
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
            this.cTestNumberIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cContestantShiftID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDaHoanThanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrintAnswer = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnInTatCaBaiLam = new System.Windows.Forms.Button();
            this.btnInDapAn = new System.Windows.Forms.Button();
            this.btnCreateAll = new System.Windows.Forms.Button();
            this.btnPrintResult = new System.Windows.Forms.Button();
            this.btnExportScoreWritting = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.gvMain.BackgroundColor = System.Drawing.Color.White;
            this.gvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cTestNumberIndex,
            this.cScore,
            this.cContestantShiftID,
            this.cDaHoanThanh,
            this.btnPrintAnswer});
            this.gvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvMain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gvMain.Location = new System.Drawing.Point(3, 16);
            this.gvMain.Name = "gvMain";
            this.gvMain.Size = new System.Drawing.Size(1354, 253);
            this.gvMain.TabIndex = 7;
            this.gvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMain_CellClick);
            this.gvMain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMain_CellContentClick);
            this.gvMain.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvMain_CellFormatting);
            // 
            // cTestNumberIndex
            // 
            this.cTestNumberIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cTestNumberIndex.DataPropertyName = "TestNumberIndex";
            this.cTestNumberIndex.HeaderText = "Số Phách";
            this.cTestNumberIndex.Name = "cTestNumberIndex";
            this.cTestNumberIndex.ReadOnly = true;
            // 
            // cScore
            // 
            this.cScore.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cScore.DataPropertyName = "Score";
            this.cScore.HeaderText = "Điểm";
            this.cScore.Name = "cScore";
            // 
            // cContestantShiftID
            // 
            this.cContestantShiftID.DataPropertyName = "ContestantShiftID";
            this.cContestantShiftID.HeaderText = "ContestantShiftID";
            this.cContestantShiftID.Name = "cContestantShiftID";
            this.cContestantShiftID.Visible = false;
            // 
            // cDaHoanThanh
            // 
            this.cDaHoanThanh.DataPropertyName = "DaHoanThanh";
            this.cDaHoanThanh.HeaderText = "Tình trạng";
            this.cDaHoanThanh.Name = "cDaHoanThanh";
            this.cDaHoanThanh.Width = 300;
            // 
            // btnPrintAnswer
            // 
            this.btnPrintAnswer.DataPropertyName = "PrintAnswer";
            this.btnPrintAnswer.HeaderText = "Bài làm";
            this.btnPrintAnswer.Name = "btnPrintAnswer";
            this.btnPrintAnswer.Text = "Xem";
            this.btnPrintAnswer.Width = 200;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnInTatCaBaiLam);
            this.groupBox2.Controls.Add(this.btnInDapAn);
            this.groupBox2.Controls.Add(this.btnCreateAll);
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
            // btnInTatCaBaiLam
            // 
            this.btnInTatCaBaiLam.Image = global::EXON.GradedEssay.Properties.Resources.print_22_157582;
            this.btnInTatCaBaiLam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInTatCaBaiLam.Location = new System.Drawing.Point(76, 18);
            this.btnInTatCaBaiLam.Margin = new System.Windows.Forms.Padding(2);
            this.btnInTatCaBaiLam.Name = "btnInTatCaBaiLam";
            this.btnInTatCaBaiLam.Size = new System.Drawing.Size(171, 36);
            this.btnInTatCaBaiLam.TabIndex = 31;
            this.btnInTatCaBaiLam.Text = "In tất cả bài làm ra";
            this.btnInTatCaBaiLam.UseVisualStyleBackColor = true;
            this.btnInTatCaBaiLam.Click += new System.EventHandler(this.btnInTatCaBaiLam_Click);
            // 
            // btnInDapAn
            // 
            this.btnInDapAn.Image = global::EXON.GradedEssay.Properties.Resources.print_22_157582;
            this.btnInDapAn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInDapAn.Location = new System.Drawing.Point(585, 19);
            this.btnInDapAn.Margin = new System.Windows.Forms.Padding(2);
            this.btnInDapAn.Name = "btnInDapAn";
            this.btnInDapAn.Size = new System.Drawing.Size(125, 36);
            this.btnInDapAn.TabIndex = 30;
            this.btnInDapAn.Text = "In đáp án";
            this.btnInDapAn.UseVisualStyleBackColor = true;
            this.btnInDapAn.Click += new System.EventHandler(this.btnInDapAn_Click);
            // 
            // btnCreateAll
            // 
            this.btnCreateAll.Image = global::EXON.GradedEssay.Properties.Resources.create_document_2_563795;
            this.btnCreateAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateAll.Location = new System.Drawing.Point(433, 18);
            this.btnCreateAll.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreateAll.Name = "btnCreateAll";
            this.btnCreateAll.Size = new System.Drawing.Size(125, 36);
            this.btnCreateAll.TabIndex = 29;
            this.btnCreateAll.Text = "Tạo tất cả bài làm";
            this.btnCreateAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreateAll.UseVisualStyleBackColor = true;
            this.btnCreateAll.Click += new System.EventHandler(this.btnCreateAll_Click);
            // 
            // btnPrintResult
            // 
            this.btnPrintResult.Image = global::EXON.GradedEssay.Properties.Resources.print_65_445177;
            this.btnPrintResult.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintResult.Location = new System.Drawing.Point(737, 20);
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
            this.btnSave.Location = new System.Drawing.Point(889, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 36);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "Lưu Lại";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
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
            this.cbStaff2.Location = new System.Drawing.Point(645, 53);
            this.cbStaff2.Name = "cbStaff2";
            this.cbStaff2.Size = new System.Drawing.Size(193, 21);
            this.cbStaff2.TabIndex = 80;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(545, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 79;
            this.label3.Text = "Giáo viên 2";
            // 
            // cbStaff1
            // 
            this.cbStaff1.FormattingEnabled = true;
            this.cbStaff1.Location = new System.Drawing.Point(206, 48);
            this.cbStaff1.Name = "cbStaff1";
            this.cbStaff1.Size = new System.Drawing.Size(177, 21);
            this.cbStaff1.TabIndex = 78;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(118, 56);
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
            // ucWritting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucWritting";
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
        private System.Windows.Forms.DataGridView gvMain;
        private System.Windows.Forms.Button btnCreateAll;
        private System.Windows.Forms.Button btnPrintResult;
        private System.Windows.Forms.Button btnExportScoreWritting;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnInDapAn;
        private System.Windows.Forms.ComboBox cbRoomTest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbStaff2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbStaff1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTestNumberIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn cScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn cContestantShiftID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDaHoanThanh;
        private System.Windows.Forms.DataGridViewButtonColumn btnPrintAnswer;
        private System.Windows.Forms.ComboBox cbSubject;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnInTatCaBaiLam;
    }
}
