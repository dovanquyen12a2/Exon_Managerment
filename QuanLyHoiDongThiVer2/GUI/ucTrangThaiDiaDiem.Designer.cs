namespace QuanLyHoiDongThiVer2.GUI
{
    partial class ucTrangThaiDiaDiem
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTrangThaiDiaDiem));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxKhoiThi = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxKip = new System.Windows.Forms.ComboBox();
            this.dateNgayThi = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvPhongThi = new System.Windows.Forms.DataGridView();
            this.IDPhongThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STTPhongThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoCho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTrangThaiPhongThi = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvCaThi = new System.Windows.Forms.DataGridView();
            this.IDCaThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STTCaThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenCaThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KetThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnIn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongThi)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaThi)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.btnTrangThaiPhongThi);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.btnIn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1302, 596);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxKhoiThi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbxKip);
            this.groupBox1.Controls.Add(this.dateNgayThi);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(893, 57);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kíp thi";
            // 
            // cbxKhoiThi
            // 
            this.cbxKhoiThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxKhoiThi.FormattingEnabled = true;
            this.cbxKhoiThi.Location = new System.Drawing.Point(551, 17);
            this.cbxKhoiThi.Name = "cbxKhoiThi";
            this.cbxKhoiThi.Size = new System.Drawing.Size(326, 25);
            this.cbxKhoiThi.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(480, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khối thi :";
            // 
            // cbxKip
            // 
            this.cbxKip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxKip.FormattingEnabled = true;
            this.cbxKip.Items.AddRange(new object[] {
            "Sáng",
            "Chiều"});
            this.cbxKip.Location = new System.Drawing.Point(264, 17);
            this.cbxKip.Name = "cbxKip";
            this.cbxKip.Size = new System.Drawing.Size(196, 25);
            this.cbxKip.TabIndex = 3;
            this.cbxKip.SelectedIndexChanged += new System.EventHandler(this.cbxKip_SelectedIndexChanged);
            // 
            // dateNgayThi
            // 
            this.dateNgayThi.CustomFormat = "dd/MM/yyyy";
            this.dateNgayThi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNgayThi.Location = new System.Drawing.Point(82, 20);
            this.dateNgayThi.Name = "dateNgayThi";
            this.dateNgayThi.Size = new System.Drawing.Size(117, 24);
            this.dateNgayThi.TabIndex = 2;
            this.dateNgayThi.ValueChanged += new System.EventHandler(this.dateNgayThi_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kíp:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngày:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvPhongThi);
            this.groupBox3.Location = new System.Drawing.Point(666, 66);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(631, 522);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách phòng thi";
            // 
            // dgvPhongThi
            // 
            this.dgvPhongThi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhongThi.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvPhongThi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvPhongThi.ColumnHeadersHeight = 30;
            this.dgvPhongThi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDPhongThi,
            this.STTPhongThi,
            this.TenPhong,
            this.SoCho});
            this.dgvPhongThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhongThi.EnableHeadersVisualStyles = false;
            this.dgvPhongThi.GridColor = System.Drawing.Color.Black;
            this.dgvPhongThi.Location = new System.Drawing.Point(3, 20);
            this.dgvPhongThi.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPhongThi.MultiSelect = false;
            this.dgvPhongThi.Name = "dgvPhongThi";
            this.dgvPhongThi.ReadOnly = true;
            this.dgvPhongThi.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvPhongThi.RowHeadersWidth = 25;
            this.dgvPhongThi.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPhongThi.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPhongThi.RowTemplate.Height = 30;
            this.dgvPhongThi.RowTemplate.ReadOnly = true;
            this.dgvPhongThi.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhongThi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhongThi.Size = new System.Drawing.Size(625, 499);
            this.dgvPhongThi.TabIndex = 4;
            // 
            // IDPhongThi
            // 
            this.IDPhongThi.DataPropertyName = "ID";
            this.IDPhongThi.HeaderText = "ID";
            this.IDPhongThi.Name = "IDPhongThi";
            this.IDPhongThi.ReadOnly = true;
            this.IDPhongThi.Visible = false;
            // 
            // STTPhongThi
            // 
            this.STTPhongThi.DataPropertyName = "STT";
            this.STTPhongThi.FillWeight = 5F;
            this.STTPhongThi.HeaderText = "STT";
            this.STTPhongThi.Name = "STTPhongThi";
            this.STTPhongThi.ReadOnly = true;
            // 
            // TenPhong
            // 
            this.TenPhong.DataPropertyName = "TenPhong";
            this.TenPhong.FillWeight = 24F;
            this.TenPhong.HeaderText = "Tên phòng";
            this.TenPhong.Name = "TenPhong";
            this.TenPhong.ReadOnly = true;
            // 
            // SoCho
            // 
            this.SoCho.DataPropertyName = "SoCho";
            this.SoCho.FillWeight = 12F;
            this.SoCho.HeaderText = "Số chỗ";
            this.SoCho.Name = "SoCho";
            this.SoCho.ReadOnly = true;
            // 
            // btnTrangThaiPhongThi
            // 
            this.btnTrangThaiPhongThi.BackColor = System.Drawing.Color.White;
            this.btnTrangThaiPhongThi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrangThaiPhongThi.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrangThaiPhongThi.Image = ((System.Drawing.Image)(resources.GetObject("btnTrangThaiPhongThi.Image")));
            this.btnTrangThaiPhongThi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrangThaiPhongThi.Location = new System.Drawing.Point(1103, 12);
            this.btnTrangThaiPhongThi.Name = "btnTrangThaiPhongThi";
            this.btnTrangThaiPhongThi.Size = new System.Drawing.Size(194, 45);
            this.btnTrangThaiPhongThi.TabIndex = 36;
            this.btnTrangThaiPhongThi.Text = "Trạng thái phòng thi";
            this.btnTrangThaiPhongThi.UseVisualStyleBackColor = false;
            this.btnTrangThaiPhongThi.Click += new System.EventHandler(this.btnTrangThaiPhongThi_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvCaThi);
            this.groupBox2.Location = new System.Drawing.Point(3, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(657, 522);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách ca thi";
            // 
            // dgvCaThi
            // 
            this.dgvCaThi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCaThi.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvCaThi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCaThi.ColumnHeadersHeight = 30;
            this.dgvCaThi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDCaThi,
            this.STTCaThi,
            this.TenCaThi,
            this.NgayThi,
            this.BatDau,
            this.KetThuc});
            this.dgvCaThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCaThi.EnableHeadersVisualStyles = false;
            this.dgvCaThi.GridColor = System.Drawing.Color.Black;
            this.dgvCaThi.Location = new System.Drawing.Point(3, 20);
            this.dgvCaThi.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCaThi.MultiSelect = false;
            this.dgvCaThi.Name = "dgvCaThi";
            this.dgvCaThi.ReadOnly = true;
            this.dgvCaThi.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCaThi.RowHeadersWidth = 25;
            this.dgvCaThi.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCaThi.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCaThi.RowTemplate.Height = 30;
            this.dgvCaThi.RowTemplate.ReadOnly = true;
            this.dgvCaThi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCaThi.Size = new System.Drawing.Size(651, 499);
            this.dgvCaThi.TabIndex = 3;
            // 
            // IDCaThi
            // 
            this.IDCaThi.DataPropertyName = "ID";
            this.IDCaThi.HeaderText = "ID";
            this.IDCaThi.Name = "IDCaThi";
            this.IDCaThi.ReadOnly = true;
            this.IDCaThi.Visible = false;
            // 
            // STTCaThi
            // 
            this.STTCaThi.DataPropertyName = "STT";
            this.STTCaThi.FillWeight = 8F;
            this.STTCaThi.HeaderText = "STT";
            this.STTCaThi.Name = "STTCaThi";
            this.STTCaThi.ReadOnly = true;
            // 
            // TenCaThi
            // 
            this.TenCaThi.DataPropertyName = "TenCaThi";
            this.TenCaThi.FillWeight = 24F;
            this.TenCaThi.HeaderText = "Tên ca thi";
            this.TenCaThi.Name = "TenCaThi";
            this.TenCaThi.ReadOnly = true;
            // 
            // NgayThi
            // 
            this.NgayThi.DataPropertyName = "NgayThi";
            this.NgayThi.FillWeight = 12F;
            this.NgayThi.HeaderText = "Ngày thi";
            this.NgayThi.Name = "NgayThi";
            this.NgayThi.ReadOnly = true;
            // 
            // BatDau
            // 
            this.BatDau.DataPropertyName = "BatDau";
            this.BatDau.FillWeight = 12F;
            this.BatDau.HeaderText = "Bắt đầu";
            this.BatDau.Name = "BatDau";
            this.BatDau.ReadOnly = true;
            // 
            // KetThuc
            // 
            this.KetThuc.DataPropertyName = "KetThuc";
            this.KetThuc.FillWeight = 12F;
            this.KetThuc.HeaderText = "Kết thúc";
            this.KetThuc.Name = "KetThuc";
            this.KetThuc.ReadOnly = true;
            // 
            // btnIn
            // 
            this.btnIn.BackColor = System.Drawing.Color.White;
            this.btnIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIn.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Image = ((System.Drawing.Image)(resources.GetObject("btnIn.Image")));
            this.btnIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIn.Location = new System.Drawing.Point(905, 12);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(194, 45);
            this.btnIn.TabIndex = 35;
            this.btnIn.Text = "In kết quả kíp thi";
            this.btnIn.UseVisualStyleBackColor = false;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // ucTrangThaiDiaDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucTrangThaiDiaDiem";
            this.Size = new System.Drawing.Size(1302, 596);
            this.Load += new System.EventHandler(this.ucTrangThaiDiaDiem_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongThi)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaThi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnTrangThaiPhongThi;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvCaThi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxKip;
        private System.Windows.Forms.DateTimePicker dateNgayThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCaThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn STTCaThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenCaThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn KetThuc;
        private System.Windows.Forms.DataGridView dgvPhongThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPhongThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn STTPhongThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoCho;
        private System.Windows.Forms.ComboBox cbxKhoiThi;
        private System.Windows.Forms.Label label3;
    }
}
