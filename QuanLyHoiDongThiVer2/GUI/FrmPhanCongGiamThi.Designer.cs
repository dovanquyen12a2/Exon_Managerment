namespace QuanLyHoiDongThiVer2.GUI
{
    partial class FrmPhanCongGiamThi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupThongTin = new System.Windows.Forms.GroupBox();
            this.txtShiftDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEndTime = new System.Windows.Forms.Label();
            this.txtStartTime = new System.Windows.Forms.Label();
            this.cbxSupervisorID = new System.Windows.Forms.ComboBox();
            this.cbxDivisionShiftID = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvPhanCongGiamThi = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenCanBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhongThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.groupThongTin.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanCongGiamThi)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupThongTin
            // 
            this.groupThongTin.BackColor = System.Drawing.Color.White;
            this.groupThongTin.Controls.Add(this.rbAll);
            this.groupThongTin.Controls.Add(this.txtShiftDate);
            this.groupThongTin.Controls.Add(this.label3);
            this.groupThongTin.Controls.Add(this.txtEndTime);
            this.groupThongTin.Controls.Add(this.txtStartTime);
            this.groupThongTin.Controls.Add(this.cbxSupervisorID);
            this.groupThongTin.Controls.Add(this.cbxDivisionShiftID);
            this.groupThongTin.Controls.Add(this.label13);
            this.groupThongTin.Controls.Add(this.label11);
            this.groupThongTin.Controls.Add(this.label10);
            this.groupThongTin.Controls.Add(this.label9);
            this.groupThongTin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupThongTin.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupThongTin.Location = new System.Drawing.Point(0, 348);
            this.groupThongTin.Name = "groupThongTin";
            this.groupThongTin.Size = new System.Drawing.Size(1309, 210);
            this.groupThongTin.TabIndex = 0;
            this.groupThongTin.TabStop = false;
            this.groupThongTin.Text = "Thông tin phân công";
            // 
            // txtShiftDate
            // 
            this.txtShiftDate.AutoSize = true;
            this.txtShiftDate.Location = new System.Drawing.Point(464, 80);
            this.txtShiftDate.Name = "txtShiftDate";
            this.txtShiftDate.Size = new System.Drawing.Size(58, 16);
            this.txtShiftDate.TabIndex = 28;
            this.txtShiftDate.Text = "2/3/2017";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(332, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "Ngày thi : ";
            // 
            // txtEndTime
            // 
            this.txtEndTime.AutoSize = true;
            this.txtEndTime.Location = new System.Drawing.Point(741, 122);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.Size = new System.Drawing.Size(47, 16);
            this.txtEndTime.TabIndex = 26;
            this.txtEndTime.Text = "09 : 20";
            // 
            // txtStartTime
            // 
            this.txtStartTime.AutoSize = true;
            this.txtStartTime.Location = new System.Drawing.Point(464, 122);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(47, 16);
            this.txtStartTime.TabIndex = 25;
            this.txtStartTime.Text = "09 : 10";
            // 
            // cbxSupervisorID
            // 
            this.cbxSupervisorID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSupervisorID.FormattingEnabled = true;
            this.cbxSupervisorID.Location = new System.Drawing.Point(467, 166);
            this.cbxSupervisorID.Name = "cbxSupervisorID";
            this.cbxSupervisorID.Size = new System.Drawing.Size(321, 23);
            this.cbxSupervisorID.TabIndex = 24;
            // 
            // cbxDivisionShiftID
            // 
            this.cbxDivisionShiftID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDivisionShiftID.FormattingEnabled = true;
            this.cbxDivisionShiftID.Location = new System.Drawing.Point(467, 31);
            this.cbxDivisionShiftID.Name = "cbxDivisionShiftID";
            this.cbxDivisionShiftID.Size = new System.Drawing.Size(493, 23);
            this.cbxDivisionShiftID.TabIndex = 23;
            this.cbxDivisionShiftID.SelectedIndexChanged += new System.EventHandler(this.cbxDivisionShiftID_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(332, 169);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 16);
            this.label13.TabIndex = 22;
            this.label13.Text = "Giám thị : ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(593, 122);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 16);
            this.label11.TabIndex = 21;
            this.label11.Text = "Thời gian kết thúc : ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(332, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 16);
            this.label10.TabIndex = 20;
            this.label10.Text = "Thời gian bắt đầu : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(332, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 16);
            this.label9.TabIndex = 19;
            this.label9.Text = "Ca thi - phòng thi : ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvPhanCongGiamThi);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1309, 304);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách phân công";
            // 
            // dgvPhanCongGiamThi
            // 
            this.dgvPhanCongGiamThi.AllowUserToResizeColumns = false;
            this.dgvPhanCongGiamThi.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvPhanCongGiamThi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvPhanCongGiamThi.ColumnHeadersHeight = 30;
            this.dgvPhanCongGiamThi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.STT,
            this.TenCanBo,
            this.PhongThi,
            this.CaThi});
            this.dgvPhanCongGiamThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhanCongGiamThi.EnableHeadersVisualStyles = false;
            this.dgvPhanCongGiamThi.GridColor = System.Drawing.Color.Black;
            this.dgvPhanCongGiamThi.Location = new System.Drawing.Point(3, 16);
            this.dgvPhanCongGiamThi.MultiSelect = false;
            this.dgvPhanCongGiamThi.Name = "dgvPhanCongGiamThi";
            this.dgvPhanCongGiamThi.ReadOnly = true;
            this.dgvPhanCongGiamThi.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhanCongGiamThi.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPhanCongGiamThi.RowHeadersWidth = 25;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPhanCongGiamThi.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPhanCongGiamThi.RowTemplate.Height = 30;
            this.dgvPhanCongGiamThi.RowTemplate.ReadOnly = true;
            this.dgvPhanCongGiamThi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhanCongGiamThi.Size = new System.Drawing.Size(1303, 285);
            this.dgvPhanCongGiamThi.TabIndex = 2;
            this.dgvPhanCongGiamThi.SelectionChanged += new System.EventHandler(this.dgvPhanCongGiamThi_SelectionChanged);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // STT
            // 
            this.STT.DataPropertyName = "STT";
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // TenCanBo
            // 
            this.TenCanBo.DataPropertyName = "TenCanBo";
            this.TenCanBo.HeaderText = "Tên cán bộ";
            this.TenCanBo.Name = "TenCanBo";
            this.TenCanBo.ReadOnly = true;
            this.TenCanBo.Width = 400;
            // 
            // PhongThi
            // 
            this.PhongThi.DataPropertyName = "PhongThi";
            this.PhongThi.HeaderText = "Phòng thi";
            this.PhongThi.Name = "PhongThi";
            this.PhongThi.ReadOnly = true;
            this.PhongThi.Width = 369;
            // 
            // CaThi
            // 
            this.CaThi.DataPropertyName = "CaThi";
            this.CaThi.HeaderText = "Ca thi";
            this.CaThi.Name = "CaThi";
            this.CaThi.ReadOnly = true;
            this.CaThi.Width = 400;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnDong);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 304);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1309, 44);
            this.panel2.TabIndex = 3;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.White;
            this.btnThem.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(769, 0);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(180, 44);
            this.btnThem.TabIndex = 33;
            this.btnThem.Text = "Thêm phân công";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.White;
            this.btnXoa.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(949, 0);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(180, 44);
            this.btnXoa.TabIndex = 32;
            this.btnXoa.Text = "Xóa phân công";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.White;
            this.btnDong.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDong.Location = new System.Drawing.Point(1129, 0);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(180, 44);
            this.btnDong.TabIndex = 31;
            this.btnDong.Text = "Đóng chức năng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Location = new System.Drawing.Point(999, 34);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(91, 20);
            this.rbAll.TabIndex = 30;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "Chọn tất cả";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // FrmPhanCongGiamThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 558);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupThongTin);
            this.Name = "FrmPhanCongGiamThi";
            this.Text = "Phân công giám thị";
            this.Load += new System.EventHandler(this.FrmPhanCongGiamThi_Load);
            this.groupThongTin.ResumeLayout(false);
            this.groupThongTin.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanCongGiamThi)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupThongTin;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvPhanCongGiamThi;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label txtShiftDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtEndTime;
        private System.Windows.Forms.Label txtStartTime;
        private System.Windows.Forms.ComboBox cbxSupervisorID;
        private System.Windows.Forms.ComboBox cbxDivisionShiftID;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenCanBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhongThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn CaThi;
        private System.Windows.Forms.RadioButton rbAll;
    }
}