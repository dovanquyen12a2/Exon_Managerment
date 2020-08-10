namespace EXON.MONITOR.GUI
{
    partial class frmSupervisorManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSupervisorManage));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.maintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.metroContextMenu2 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.mItemMenuCheckinRoom = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemMenuComein = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mItemMenuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPauseContest = new MetroFramework.Controls.MetroButton();
            this.analogClock1 = new AnalogClock.AnalogClock();
            this.lblTimeNow = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.dgvListRoomTest = new MetroFramework.Controls.MetroGrid();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomTestID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomTestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxSeatMount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Endtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHIFID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusDivisionShift = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DivisionShiftID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mpnlTreeViewNgayThi = new MetroFramework.Controls.MetroPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.metroContextMenu1.SuspendLayout();
            this.metroContextMenu2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListRoomTest)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = null;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Green;
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maintenanceToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.toolStripMenuItem1});
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(172, 54);
            // 
            // maintenanceToolStripMenuItem
            // 
            this.maintenanceToolStripMenuItem.Name = "maintenanceToolStripMenuItem";
            this.maintenanceToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.maintenanceToolStripMenuItem.Text = "&Đổi mật khẩu";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.toolsToolStripMenuItem.Text = "&Thông tin cá nhân";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(168, 6);
            // 
            // metroContextMenu2
            // 
            this.metroContextMenu2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemMenuCheckinRoom,
            this.mItemMenuComein,
            this.toolStripSeparator1,
            this.mItemMenuRefresh});
            this.metroContextMenu2.Name = "metroContextMenu1";
            this.metroContextMenu2.Size = new System.Drawing.Size(174, 76);
            // 
            // mItemMenuCheckinRoom
            // 
            this.mItemMenuCheckinRoom.Name = "mItemMenuCheckinRoom";
            this.mItemMenuCheckinRoom.Size = new System.Drawing.Size(173, 22);
            this.mItemMenuCheckinRoom.Text = "&Kiểm tra phòng thi";
            this.mItemMenuCheckinRoom.Visible = false;
            this.mItemMenuCheckinRoom.Click += new System.EventHandler(this.mItemMenuCheckinRoom_Click);
            // 
            // mItemMenuComein
            // 
            this.mItemMenuComein.Name = "mItemMenuComein";
            this.mItemMenuComein.Size = new System.Drawing.Size(173, 22);
            this.mItemMenuComein.Text = "&Vào phòng thi";
            this.mItemMenuComein.Click += new System.EventHandler(this.mItemMenuComein_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(170, 6);
            // 
            // mItemMenuRefresh
            // 
            this.mItemMenuRefresh.Name = "mItemMenuRefresh";
            this.mItemMenuRefresh.Size = new System.Drawing.Size(173, 22);
            this.mItemMenuRefresh.Text = "Làm mới";
            this.mItemMenuRefresh.Click += new System.EventHandler(this.mItemMenuTurnOn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.metroButton1);
            this.groupBox2.Controls.Add(this.btnPauseContest);
            this.groupBox2.Controls.Add(this.analogClock1);
            this.groupBox2.Controls.Add(this.lblTimeNow);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(887, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(365, 359);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Giờ hệ thống";
            // 
            // btnPauseContest
            // 
            this.btnPauseContest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(182)))), ((int)(((byte)(246)))));
            this.btnPauseContest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPauseContest.ForeColor = System.Drawing.Color.White;
            this.btnPauseContest.Location = new System.Drawing.Point(110, 311);
            this.btnPauseContest.Name = "btnPauseContest";
            this.btnPauseContest.Size = new System.Drawing.Size(187, 45);
            this.btnPauseContest.TabIndex = 3;
            this.btnPauseContest.Text = "Tạm dừng cuộc thi";
            this.btnPauseContest.UseCustomBackColor = true;
            this.btnPauseContest.UseCustomForeColor = true;
            this.btnPauseContest.UseSelectable = true;
            this.btnPauseContest.Visible = false;
            this.btnPauseContest.Click += new System.EventHandler(this.btnPauseContest_Click);
            // 
            // analogClock1
            // 
            this.analogClock1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.analogClock1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.analogClock1.CalendarType = AnalogClock.AnalogClock.CalendarTypes.Gregorian;
            this.analogClock1.Caption = "MTA Clock";
            this.analogClock1.ClockStyle = AnalogClock.AnalogClock.ClockStyles.Standard;
            this.analogClock1.DateStyle = AnalogClock.AnalogClock.DateStyles.Full;
            this.analogClock1.Enabled = false;
            this.analogClock1.HandColor = System.Drawing.Color.Black;
            this.analogClock1.HandStyle = AnalogClock.AnalogClock.HandStyles.Uniform;
            this.analogClock1.InnerColor = System.Drawing.Color.SkyBlue;
            this.analogClock1.Location = new System.Drawing.Point(51, 25);
            this.analogClock1.Margin = new System.Windows.Forms.Padding(4);
            this.analogClock1.MinimumSize = new System.Drawing.Size(75, 69);
            this.analogClock1.Name = "analogClock1";
            this.analogClock1.NumberStyle = AnalogClock.AnalogClock.NumberStyles.All;
            this.analogClock1.OuterColor = System.Drawing.Color.SteelBlue;
            this.analogClock1.SecondHandColor = System.Drawing.Color.Red;
            this.analogClock1.Size = new System.Drawing.Size(283, 209);
            this.analogClock1.TabIndex = 2;
            this.analogClock1.TextColor = System.Drawing.Color.Black;
            this.analogClock1.TickColor = System.Drawing.Color.Black;
            this.analogClock1.TickStyle = AnalogClock.AnalogClock.TickStyles.All;
            // 
            // lblTimeNow
            // 
            this.lblTimeNow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimeNow.AutoSize = true;
            this.lblTimeNow.Location = new System.Drawing.Point(106, 274);
            this.lblTimeNow.Name = "lblTimeNow";
            this.lblTimeNow.Size = new System.Drawing.Size(0, 19);
            this.lblTimeNow.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(887, 359);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách ca thi được phân công";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.metroPanel3);
            this.panel2.Controls.Add(this.mpnlTreeViewNgayThi);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(881, 334);
            this.panel2.TabIndex = 3;
            // 
            // metroPanel3
            // 
            this.metroPanel3.Controls.Add(this.dgvListRoomTest);
            this.metroPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(164, 0);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(717, 334);
            this.metroPanel3.TabIndex = 7;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // dgvListRoomTest
            // 
            this.dgvListRoomTest.AllowUserToAddRows = false;
            this.dgvListRoomTest.AllowUserToDeleteRows = false;
            this.dgvListRoomTest.AllowUserToResizeRows = false;
            this.dgvListRoomTest.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvListRoomTest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListRoomTest.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvListRoomTest.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListRoomTest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListRoomTest.ColumnHeadersHeight = 30;
            this.dgvListRoomTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.RoomTestID,
            this.RoomTestName,
            this.MaxSeatMount,
            this.StartTime,
            this.Endtime,
            this.SHIFID,
            this.StatusDivisionShift,
            this.DivisionShiftID});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListRoomTest.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListRoomTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListRoomTest.EnableHeadersVisualStyles = false;
            this.dgvListRoomTest.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvListRoomTest.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvListRoomTest.Location = new System.Drawing.Point(0, 0);
            this.dgvListRoomTest.MultiSelect = false;
            this.dgvListRoomTest.Name = "dgvListRoomTest";
            this.dgvListRoomTest.ReadOnly = true;
            this.dgvListRoomTest.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListRoomTest.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListRoomTest.RowHeadersVisible = false;
            this.dgvListRoomTest.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvListRoomTest.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvListRoomTest.RowTemplate.Height = 30;
            this.dgvListRoomTest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvListRoomTest.Size = new System.Drawing.Size(717, 334);
            this.dgvListRoomTest.TabIndex = 6;
            this.dgvListRoomTest.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListRoomTest_CellDoubleClick);
            // 
            // STT
            // 
            this.STT.FillWeight = 30F;
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 40;
            // 
            // RoomTestID
            // 
            this.RoomTestID.HeaderText = "Mã phòng thi";
            this.RoomTestID.Name = "RoomTestID";
            this.RoomTestID.ReadOnly = true;
            this.RoomTestID.Visible = false;
            // 
            // RoomTestName
            // 
            this.RoomTestName.HeaderText = "Tên phòng thi";
            this.RoomTestName.Name = "RoomTestName";
            this.RoomTestName.ReadOnly = true;
            this.RoomTestName.Width = 110;
            // 
            // MaxSeatMount
            // 
            this.MaxSeatMount.HeaderText = "Số chỗ ngồi";
            this.MaxSeatMount.Name = "MaxSeatMount";
            this.MaxSeatMount.ReadOnly = true;
            // 
            // StartTime
            // 
            this.StartTime.HeaderText = "Thời gian bắt đầu";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            this.StartTime.Width = 130;
            // 
            // Endtime
            // 
            this.Endtime.HeaderText = "Thời gian kết thúc";
            this.Endtime.Name = "Endtime";
            this.Endtime.ReadOnly = true;
            this.Endtime.Width = 130;
            // 
            // SHIFID
            // 
            this.SHIFID.HeaderText = "ShiftID";
            this.SHIFID.Name = "SHIFID";
            this.SHIFID.ReadOnly = true;
            this.SHIFID.Visible = false;
            // 
            // StatusDivisionShift
            // 
            this.StatusDivisionShift.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StatusDivisionShift.HeaderText = "Trạng thái";
            this.StatusDivisionShift.Name = "StatusDivisionShift";
            this.StatusDivisionShift.ReadOnly = true;
            // 
            // DivisionShiftID
            // 
            this.DivisionShiftID.HeaderText = "DivisionShiftID";
            this.DivisionShiftID.Name = "DivisionShiftID";
            this.DivisionShiftID.ReadOnly = true;
            this.DivisionShiftID.Visible = false;
            // 
            // mpnlTreeViewNgayThi
            // 
            this.mpnlTreeViewNgayThi.BackColor = System.Drawing.Color.Silver;
            this.mpnlTreeViewNgayThi.Dock = System.Windows.Forms.DockStyle.Left;
            this.mpnlTreeViewNgayThi.HorizontalScrollbarBarColor = true;
            this.mpnlTreeViewNgayThi.HorizontalScrollbarHighlightOnWheel = false;
            this.mpnlTreeViewNgayThi.HorizontalScrollbarSize = 10;
            this.mpnlTreeViewNgayThi.Location = new System.Drawing.Point(0, 0);
            this.mpnlTreeViewNgayThi.Name = "mpnlTreeViewNgayThi";
            this.mpnlTreeViewNgayThi.Size = new System.Drawing.Size(164, 334);
            this.mpnlTreeViewNgayThi.TabIndex = 6;
            this.mpnlTreeViewNgayThi.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mpnlTreeViewNgayThi.VerticalScrollbarBarColor = true;
            this.mpnlTreeViewNgayThi.VerticalScrollbarHighlightOnWheel = false;
            this.mpnlTreeViewNgayThi.VerticalScrollbarSize = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(1252, 379);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(182)))), ((int)(((byte)(246)))));
            this.metroButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton1.ForeColor = System.Drawing.Color.White;
            this.metroButton1.Location = new System.Drawing.Point(110, 302);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(187, 45);
            this.metroButton1.TabIndex = 4;
            this.metroButton1.Text = "Cập nhập điểm thi";
            this.metroButton1.UseCustomBackColor = true;
            this.metroButton1.UseCustomForeColor = true;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click_1);
            // 
            // frmSupervisorManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 379);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSupervisorManage";
            this.ShowInTaskbar = false;
            this.Tag = "  ";
            this.Text = "Giám sát thi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSupervisorManage_FormClosing);
            this.Load += new System.EventHandler(this.frmSupervisorManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.metroContextMenu1.ResumeLayout(false);
            this.metroContextMenu2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.metroPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListRoomTest)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
        private System.Windows.Forms.ToolStripMenuItem maintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu2;
        private System.Windows.Forms.ToolStripMenuItem mItemMenuCheckinRoom;
        private System.Windows.Forms.ToolStripMenuItem mItemMenuComein;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mItemMenuRefresh;
        private System.Windows.Forms.GroupBox groupBox2;
        private AnalogClock.AnalogClock analogClock1;
        private System.Windows.Forms.Label lblTimeNow;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel2;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroGrid dgvListRoomTest;
        private MetroFramework.Controls.MetroPanel mpnlTreeViewNgayThi;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroButton btnPauseContest;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomTestID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomTestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxSeatMount;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Endtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHIFID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusDivisionShift;
        private System.Windows.Forms.DataGridViewTextBoxColumn DivisionShiftID;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}