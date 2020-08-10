namespace EXON.MONITOR.GUI
{
    partial class frmTrungTam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrungTam));
            this.panelStatus = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvContest = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKiThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.mbtnChuyenDuLieuVe = new MetroFramework.Controls.MetroButton();
            this.mbtnExit = new MetroFramework.Controls.MetroButton();
            this.mbtnCauHinhHeThong = new MetroFramework.Controls.MetroButton();
            this.btnDanhSachKeHoach = new MetroFramework.Controls.MetroButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStaffName = new System.Windows.Forms.Label();
            this.panelMain = new MetroFramework.Controls.MetroPanel();
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.panelStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContest)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.metroContextMenu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelStatus
            // 
            this.panelStatus.Controls.Add(this.pictureBox1);
            this.panelStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStatus.Location = new System.Drawing.Point(0, 0);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(1336, 144);
            this.panelStatus.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::EXON.MONITOR.Properties.Resources.LogoHVnew3;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1336, 144);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.panelStatus);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1336, 673);
            this.panel2.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvContest);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 144);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1336, 471);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách các kì thi được phân công";
            // 
            // dgvContest
            // 
            this.dgvContest.AllowUserToResizeColumns = false;
            this.dgvContest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContest.BackgroundColor = System.Drawing.Color.White;
            this.dgvContest.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvContest.ColumnHeadersHeight = 30;
            this.dgvContest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.LocationID,
            this.Column1,
            this.STT,
            this.TenKiThi,
            this.cLocation,
            this.TrangThai});
            this.dgvContest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvContest.EnableHeadersVisualStyles = false;
            this.dgvContest.GridColor = System.Drawing.Color.Black;
            this.dgvContest.Location = new System.Drawing.Point(3, 16);
            this.dgvContest.MultiSelect = false;
            this.dgvContest.Name = "dgvContest";
            this.dgvContest.ReadOnly = true;
            this.dgvContest.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvContest.RowHeadersWidth = 25;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvContest.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvContest.RowTemplate.Height = 30;
            this.dgvContest.RowTemplate.ReadOnly = true;
            this.dgvContest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContest.Size = new System.Drawing.Size(1063, 452);
            this.dgvContest.TabIndex = 1;
            this.dgvContest.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvContest_CellMouseClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // LocationID
            // 
            this.LocationID.DataPropertyName = "LocationID";
            this.LocationID.HeaderText = "LocationID";
            this.LocationID.Name = "LocationID";
            this.LocationID.ReadOnly = true;
            this.LocationID.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "StaffID";
            this.Column1.HeaderText = "staffID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // STT
            // 
            this.STT.DataPropertyName = "STT";
            this.STT.FillWeight = 30F;
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // TenKiThi
            // 
            this.TenKiThi.DataPropertyName = "TenKiThi";
            this.TenKiThi.HeaderText = "Tên kì thi";
            this.TenKiThi.Name = "TenKiThi";
            this.TenKiThi.ReadOnly = true;
            // 
            // cLocation
            // 
            this.cLocation.DataPropertyName = "Location";
            this.cLocation.HeaderText = "Địa điểm tổ chức";
            this.cLocation.Name = "cLocation";
            this.cLocation.ReadOnly = true;
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng thái kì thi";
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.mbtnChuyenDuLieuVe);
            this.panel3.Controls.Add(this.mbtnExit);
            this.panel3.Controls.Add(this.mbtnCauHinhHeThong);
            this.panel3.Controls.Add(this.btnDanhSachKeHoach);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(1066, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(267, 452);
            this.panel3.TabIndex = 6;
            // 
            // mbtnChuyenDuLieuVe
            // 
            this.mbtnChuyenDuLieuVe.BackColor = System.Drawing.Color.SeaGreen;
            this.mbtnChuyenDuLieuVe.DisplayFocus = true;
            this.mbtnChuyenDuLieuVe.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.mbtnChuyenDuLieuVe.ForeColor = System.Drawing.Color.Black;
            this.mbtnChuyenDuLieuVe.Location = new System.Drawing.Point(7, 21);
            this.mbtnChuyenDuLieuVe.Name = "mbtnChuyenDuLieuVe";
            this.mbtnChuyenDuLieuVe.Size = new System.Drawing.Size(255, 42);
            this.mbtnChuyenDuLieuVe.Style = MetroFramework.MetroColorStyle.Green;
            this.mbtnChuyenDuLieuVe.TabIndex = 4;
            this.mbtnChuyenDuLieuVe.Text = "     Chuyển dữ liệu thi về";
            this.mbtnChuyenDuLieuVe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mbtnChuyenDuLieuVe.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mbtnChuyenDuLieuVe.UseCustomBackColor = true;
            this.mbtnChuyenDuLieuVe.UseCustomForeColor = true;
            this.mbtnChuyenDuLieuVe.UseSelectable = true;
            this.mbtnChuyenDuLieuVe.UseStyleColors = true;
            this.mbtnChuyenDuLieuVe.Click += new System.EventHandler(this.MbtnChuyenDuLieuVe_Click);
            // 
            // mbtnExit
            // 
            this.mbtnExit.BackColor = System.Drawing.Color.SeaGreen;
            this.mbtnExit.DisplayFocus = true;
            this.mbtnExit.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.mbtnExit.ForeColor = System.Drawing.Color.Black;
            this.mbtnExit.Location = new System.Drawing.Point(7, 165);
            this.mbtnExit.Name = "mbtnExit";
            this.mbtnExit.Size = new System.Drawing.Size(255, 42);
            this.mbtnExit.Style = MetroFramework.MetroColorStyle.Green;
            this.mbtnExit.TabIndex = 100;
            this.mbtnExit.Text = "     Đăng xuất";
            this.mbtnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mbtnExit.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mbtnExit.UseCustomBackColor = true;
            this.mbtnExit.UseCustomForeColor = true;
            this.mbtnExit.UseSelectable = true;
            this.mbtnExit.UseStyleColors = true;
            this.mbtnExit.Click += new System.EventHandler(this.MbtnExit_Click);
            // 
            // mbtnCauHinhHeThong
            // 
            this.mbtnCauHinhHeThong.BackColor = System.Drawing.Color.SeaGreen;
            this.mbtnCauHinhHeThong.DisplayFocus = true;
            this.mbtnCauHinhHeThong.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.mbtnCauHinhHeThong.ForeColor = System.Drawing.Color.Black;
            this.mbtnCauHinhHeThong.Location = new System.Drawing.Point(7, 117);
            this.mbtnCauHinhHeThong.Name = "mbtnCauHinhHeThong";
            this.mbtnCauHinhHeThong.Size = new System.Drawing.Size(255, 42);
            this.mbtnCauHinhHeThong.Style = MetroFramework.MetroColorStyle.Green;
            this.mbtnCauHinhHeThong.TabIndex = 3;
            this.mbtnCauHinhHeThong.Text = "     Cấu hình hệ thống";
            this.mbtnCauHinhHeThong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mbtnCauHinhHeThong.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mbtnCauHinhHeThong.UseCustomBackColor = true;
            this.mbtnCauHinhHeThong.UseCustomForeColor = true;
            this.mbtnCauHinhHeThong.UseSelectable = true;
            this.mbtnCauHinhHeThong.UseStyleColors = true;
            this.mbtnCauHinhHeThong.Click += new System.EventHandler(this.MbtnCauHinhHeThong_Click);
            // 
            // btnDanhSachKeHoach
            // 
            this.btnDanhSachKeHoach.BackColor = System.Drawing.Color.SeaGreen;
            this.btnDanhSachKeHoach.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnDanhSachKeHoach.ForeColor = System.Drawing.Color.Black;
            this.btnDanhSachKeHoach.Location = new System.Drawing.Point(7, 69);
            this.btnDanhSachKeHoach.Name = "btnDanhSachKeHoach";
            this.btnDanhSachKeHoach.Size = new System.Drawing.Size(255, 42);
            this.btnDanhSachKeHoach.Style = MetroFramework.MetroColorStyle.Green;
            this.btnDanhSachKeHoach.TabIndex = 10;
            this.btnDanhSachKeHoach.Text = "     Xem lại các kì thi";
            this.btnDanhSachKeHoach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhSachKeHoach.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnDanhSachKeHoach.UseCustomBackColor = true;
            this.btnDanhSachKeHoach.UseCustomForeColor = true;
            this.btnDanhSachKeHoach.UseSelectable = true;
            this.btnDanhSachKeHoach.UseStyleColors = true;
            this.btnDanhSachKeHoach.Click += new System.EventHandler(this.BtnDanhSachKeHoach_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblStaffName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.DarkRed;
            this.panel1.Location = new System.Drawing.Point(0, 615);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1336, 58);
            this.panel1.TabIndex = 7;
            // 
            // lblStaffName
            // 
            this.lblStaffName.AutoSize = true;
            this.lblStaffName.Location = new System.Drawing.Point(16, 19);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(78, 20);
            this.lblStaffName.TabIndex = 0;
            this.lblStaffName.Text = "Xin Chào:";
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.panel2);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.HorizontalScrollbarBarColor = true;
            this.panelMain.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMain.HorizontalScrollbarSize = 12;
            this.panelMain.Location = new System.Drawing.Point(20, 60);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1338, 675);
            this.panelMain.TabIndex = 1;
            this.panelMain.VerticalScrollbarBarColor = true;
            this.panelMain.VerticalScrollbarHighlightOnWheel = false;
            this.panelMain.VerticalScrollbarSize = 12;
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem,
            this.toolStripMenuItem1});
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(150, 32);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.toolsToolStripMenuItem.Text = "&Chọn cuộc thi";
            this.toolsToolStripMenuItem.Click += new System.EventHandler(this.ToolsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(146, 6);
            // 
            // frmTrungTam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 755);
            this.Controls.Add(this.panelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTrungTam";
            this.Text = "Hệ thống giám sát cuộc thi";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContest)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.metroContextMenu1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private MetroFramework.Controls.MetroPanel panelMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvContest;
        private System.Windows.Forms.Panel panel3;
        private MetroFramework.Controls.MetroButton mbtnChuyenDuLieuVe;
        private MetroFramework.Controls.MetroButton mbtnExit;
        private MetroFramework.Controls.MetroButton mbtnCauHinhHeThong;
        private MetroFramework.Controls.MetroButton btnDanhSachKeHoach;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblStaffName;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKiThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
    }
}