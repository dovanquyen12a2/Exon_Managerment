namespace QuanLyHoiDongThiVer2.GUI
{
    partial class ucTrangThaiDiaDiemThiHK
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.dgvListRoomTest = new MetroFramework.Controls.MetroGrid();
            this.RoomTestID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomTestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxSeatMount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Endtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHIFID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusDS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DivisionShiftID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mpnlTreeViewNgayThi = new MetroFramework.Controls.MetroPanel();
            this.metroContextMenu2 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.mItemMenuComein = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemMenuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mItemMenuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListRoomTest)).BeginInit();
            this.metroContextMenu2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1302, 596);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách ca thi";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.metroPanel3);
            this.panel2.Controls.Add(this.mpnlTreeViewNgayThi);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1296, 571);
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
            this.metroPanel3.Size = new System.Drawing.Size(1132, 571);
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListRoomTest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListRoomTest.ColumnHeadersHeight = 30;
            this.dgvListRoomTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RoomTestID,
            this.RoomTestName,
            this.MaxSeatMount,
            this.StartTime,
            this.Endtime,
            this.SHIFID,
            this.StatusDS,
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
            this.dgvListRoomTest.Size = new System.Drawing.Size(1132, 571);
            this.dgvListRoomTest.TabIndex = 6;
            this.dgvListRoomTest.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvListRoomTest_CellMouseClick);
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
            // StatusDS
            // 
            this.StatusDS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StatusDS.HeaderText = "Trạng thái";
            this.StatusDS.Name = "StatusDS";
            this.StatusDS.ReadOnly = true;
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
            this.mpnlTreeViewNgayThi.Size = new System.Drawing.Size(164, 571);
            this.mpnlTreeViewNgayThi.TabIndex = 6;
            this.mpnlTreeViewNgayThi.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mpnlTreeViewNgayThi.VerticalScrollbarBarColor = true;
            this.mpnlTreeViewNgayThi.VerticalScrollbarHighlightOnWheel = false;
            this.mpnlTreeViewNgayThi.VerticalScrollbarSize = 10;
            // 
            // metroContextMenu2
            // 
            this.metroContextMenu2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemMenuComein,
            this.mItemMenuReport,
            this.toolStripSeparator1,
            this.mItemMenuRefresh});
            this.metroContextMenu2.Name = "metroContextMenu1";
            this.metroContextMenu2.Size = new System.Drawing.Size(176, 76);
            // 
            // mItemMenuComein
            // 
            this.mItemMenuComein.Name = "mItemMenuComein";
            this.mItemMenuComein.Size = new System.Drawing.Size(175, 22);
            this.mItemMenuComein.Text = "Trạng thái thí sinh";
            this.mItemMenuComein.Click += new System.EventHandler(this.MItemMenuComein_Click);
            // 
            // mItemMenuReport
            // 
            this.mItemMenuReport.Name = "mItemMenuReport";
            this.mItemMenuReport.Size = new System.Drawing.Size(175, 22);
            this.mItemMenuReport.Text = "Báo cáo kết quả thi";
            this.mItemMenuReport.Click += new System.EventHandler(this.MItemMenuReport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(172, 6);
            // 
            // mItemMenuRefresh
            // 
            this.mItemMenuRefresh.Name = "mItemMenuRefresh";
            this.mItemMenuRefresh.Size = new System.Drawing.Size(175, 22);
            this.mItemMenuRefresh.Text = "Làm mới";
            this.mItemMenuRefresh.Click += new System.EventHandler(this.MItemMenuRefresh_Click);
            // 
            // ucTrangThaiDiaDiemThiHK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Name = "ucTrangThaiDiaDiemThiHK";
            this.Size = new System.Drawing.Size(1302, 596);
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.metroPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListRoomTest)).EndInit();
            this.metroContextMenu2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel2;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroGrid dgvListRoomTest;
        private MetroFramework.Controls.MetroPanel mpnlTreeViewNgayThi;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu2;
        private System.Windows.Forms.ToolStripMenuItem mItemMenuComein;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mItemMenuRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomTestID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomTestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxSeatMount;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Endtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHIFID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusDS;
        private System.Windows.Forms.DataGridViewTextBoxColumn DivisionShiftID;
        private System.Windows.Forms.ToolStripMenuItem mItemMenuReport;
    }
}
