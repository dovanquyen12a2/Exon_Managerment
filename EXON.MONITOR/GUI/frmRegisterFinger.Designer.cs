
namespace EXON.MONITOR.GUI
{
    partial class frmRegisterFinger
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.UpdateInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.GetfingerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFilter = new System.Windows.Forms.Button();
            this.rbtnNotgetFinger = new System.Windows.Forms.RadioButton();
            this.rbtnLostImage = new System.Windows.Forms.RadioButton();
            this.rbtnAll = new System.Windows.Forms.RadioButton();
            this.cmbKeyName = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.cContestantID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cContestantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStudentCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBoD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCMND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRoomTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIsGetFinger = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cIsImage = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.contextMenuMain.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuMain
            // 
            this.contextMenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpdateInfoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.GetfingerToolStripMenuItem});
            this.contextMenuMain.Name = "contextMenuMain";
            this.contextMenuMain.Size = new System.Drawing.Size(175, 76);
            // 
            // UpdateInfoToolStripMenuItem
            // 
            this.UpdateInfoToolStripMenuItem.Name = "UpdateInfoToolStripMenuItem";
            this.UpdateInfoToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.UpdateInfoToolStripMenuItem.Text = "Cập nhật thông tin";
            this.UpdateInfoToolStripMenuItem.Click += new System.EventHandler(this.UpdateInfoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(171, 6);
            // 
            // GetfingerToolStripMenuItem
            // 
            this.GetfingerToolStripMenuItem.Name = "GetfingerToolStripMenuItem";
            this.GetfingerToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.GetfingerToolStripMenuItem.Text = "Lấy dấu vân tay";
            this.GetfingerToolStripMenuItem.Click += new System.EventHandler(this.GetfingerToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnFilter);
            this.panel1.Controls.Add(this.rbtnNotgetFinger);
            this.panel1.Controls.Add(this.rbtnLostImage);
            this.panel1.Controls.Add(this.rbtnAll);
            this.panel1.Controls.Add(this.cmbKeyName);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1181, 48);
            this.panel1.TabIndex = 1;
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Location = new System.Drawing.Point(1103, 12);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 21);
            this.btnFilter.TabIndex = 16;
            this.btnFilter.Text = "Lọc";
            this.btnFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // rbtnNotgetFinger
            // 
            this.rbtnNotgetFinger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnNotgetFinger.AutoSize = true;
            this.rbtnNotgetFinger.Location = new System.Drawing.Point(983, 15);
            this.rbtnNotgetFinger.Name = "rbtnNotgetFinger";
            this.rbtnNotgetFinger.Size = new System.Drawing.Size(90, 17);
            this.rbtnNotgetFinger.TabIndex = 14;
            this.rbtnNotgetFinger.Text = "Thiếu vân tay";
            this.rbtnNotgetFinger.UseVisualStyleBackColor = true;
            // 
            // rbtnLostImage
            // 
            this.rbtnLostImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnLostImage.AutoSize = true;
            this.rbtnLostImage.Location = new System.Drawing.Point(890, 15);
            this.rbtnLostImage.Name = "rbtnLostImage";
            this.rbtnLostImage.Size = new System.Drawing.Size(73, 17);
            this.rbtnLostImage.TabIndex = 15;
            this.rbtnLostImage.Text = "Thiếu ảnh";
            this.rbtnLostImage.UseVisualStyleBackColor = true;
            // 
            // rbtnAll
            // 
            this.rbtnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnAll.AutoSize = true;
            this.rbtnAll.Checked = true;
            this.rbtnAll.Location = new System.Drawing.Point(815, 15);
            this.rbtnAll.Name = "rbtnAll";
            this.rbtnAll.Size = new System.Drawing.Size(57, 17);
            this.rbtnAll.TabIndex = 13;
            this.rbtnAll.TabStop = true;
            this.rbtnAll.Text = "Tất Cả";
            this.rbtnAll.UseVisualStyleBackColor = true;
            // 
            // cmbKeyName
            // 
            this.cmbKeyName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbKeyName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbKeyName.FormattingEnabled = true;
            this.cmbKeyName.Location = new System.Drawing.Point(83, 12);
            this.cmbKeyName.Name = "cmbKeyName";
            this.cmbKeyName.Size = new System.Drawing.Size(420, 21);
            this.cmbKeyName.TabIndex = 12;
            this.cmbKeyName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbKeyName_KeyDown);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(624, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 21);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Xóa";
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(543, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 21);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Tìm Kiếm";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tìm Kiếm";
            // 
            // dgvMain
            // 
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cContestantID,
            this.cSTT,
            this.cContestantCode,
            this.cStudentCode,
            this.cName,
            this.CBoD,
            this.cCMND,
            this.cSex,
            this.cRoomTest,
            this.cIsGetFinger,
            this.cIsImage});
            this.dgvMain.ContextMenuStrip = this.contextMenuMain;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.Location = new System.Drawing.Point(3, 16);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.Size = new System.Drawing.Size(1175, 377);
            this.dgvMain.TabIndex = 2;
            this.dgvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellClick);
            this.dgvMain.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMain_CellMouseDown);
            this.dgvMain.SelectionChanged += new System.EventHandler(this.dgvMain_SelectionChanged);
            // 
            // cContestantID
            // 
            this.cContestantID.DataPropertyName = "ContestantID";
            this.cContestantID.HeaderText = "cID";
            this.cContestantID.Name = "cContestantID";
            this.cContestantID.Visible = false;
            // 
            // cSTT
            // 
            this.cSTT.DataPropertyName = "STT";
            this.cSTT.HeaderText = "STT";
            this.cSTT.Name = "cSTT";
            this.cSTT.Width = 50;
            // 
            // cContestantCode
            // 
            this.cContestantCode.DataPropertyName = "ContestantCode";
            this.cContestantCode.HeaderText = "SBD";
            this.cContestantCode.Name = "cContestantCode";
            this.cContestantCode.Width = 120;
            // 
            // cStudentCode
            // 
            this.cStudentCode.DataPropertyName = "StudentCode";
            this.cStudentCode.HeaderText = "Mã sinh viên";
            this.cStudentCode.Name = "cStudentCode";
            this.cStudentCode.Visible = false;
            // 
            // cName
            // 
            this.cName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cName.DataPropertyName = "FullName";
            this.cName.HeaderText = "Họ và Tên";
            this.cName.Name = "cName";
            // 
            // CBoD
            // 
            this.CBoD.DataPropertyName = "DOB";
            this.CBoD.HeaderText = "Ngày Sinh";
            this.CBoD.Name = "CBoD";
            this.CBoD.Width = 120;
            // 
            // cCMND
            // 
            this.cCMND.DataPropertyName = "IdentityCardNumber";
            this.cCMND.HeaderText = "CMND";
            this.cCMND.Name = "cCMND";
            this.cCMND.Width = 150;
            // 
            // cSex
            // 
            this.cSex.DataPropertyName = "Sex";
            this.cSex.HeaderText = "Giới Tính";
            this.cSex.Name = "cSex";
            this.cSex.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cSex.Width = 120;
            // 
            // cRoomTest
            // 
            this.cRoomTest.DataPropertyName = "Room";
            this.cRoomTest.HeaderText = "Phòng Thi";
            this.cRoomTest.Name = "cRoomTest";
            // 
            // cIsGetFinger
            // 
            this.cIsGetFinger.DataPropertyName = "IsGetFingerPrinter";
            this.cIsGetFinger.HeaderText = "Đã lấy vân tay";
            this.cIsGetFinger.Name = "cIsGetFinger";
            this.cIsGetFinger.ReadOnly = true;
            this.cIsGetFinger.Width = 120;
            // 
            // cIsImage
            // 
            this.cIsImage.DataPropertyName = "IsImage";
            this.cIsImage.HeaderText = "Có ảnh";
            this.cIsImage.Name = "cIsImage";
            this.cIsImage.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvMain);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(20, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1181, 396);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách thí sinh trong ca thi";
            // 
            // frmRegisterFinger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 524);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "frmRegisterFinger";
            this.Text = "Đăng ký xác thực";
            this.Load += new System.EventHandler(this.frmRegisterFinger_Load);
            this.contextMenuMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuMain;
        private System.Windows.Forms.ToolStripMenuItem UpdateInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem GetfingerToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cContestantID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn cContestantCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStudentCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CBoD;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCMND;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRoomTest;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cIsGetFinger;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cIsImage;
        private System.Windows.Forms.ComboBox cmbKeyName;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.RadioButton rbtnNotgetFinger;
        private System.Windows.Forms.RadioButton rbtnLostImage;
        private System.Windows.Forms.RadioButton rbtnAll;
    }
}