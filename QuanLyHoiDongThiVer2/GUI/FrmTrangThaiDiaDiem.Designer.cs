namespace QuanLyHoiDongThiVer2.GUI
{
    partial class FrmTrangThaiDiaDiem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTrangThaiDiaDiem));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvCaThi = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STTCaThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenCaThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KetThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvRoomTest = new System.Windows.Forms.DataGridView();
            this.IDPhongThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STTPhongThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenPhongThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTrangThaiPhongThi = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaThi)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomTest)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvCaThi);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(802, 596);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách ca thi";
            // 
            // dgvCaThi
            // 
            this.dgvCaThi.AllowUserToResizeColumns = false;
            this.dgvCaThi.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCaThi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCaThi.ColumnHeadersHeight = 30;
            this.dgvCaThi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.STTCaThi,
            this.TenCaThi,
            this.NgayThi,
            this.BatDau,
            this.KetThuc});
            this.dgvCaThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCaThi.EnableHeadersVisualStyles = false;
            this.dgvCaThi.GridColor = System.Drawing.Color.Black;
            this.dgvCaThi.Location = new System.Drawing.Point(3, 16);
            this.dgvCaThi.MultiSelect = false;
            this.dgvCaThi.Name = "dgvCaThi";
            this.dgvCaThi.ReadOnly = true;
            this.dgvCaThi.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCaThi.RowHeadersWidth = 25;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCaThi.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCaThi.RowTemplate.Height = 30;
            this.dgvCaThi.RowTemplate.ReadOnly = true;
            this.dgvCaThi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCaThi.Size = new System.Drawing.Size(796, 577);
            this.dgvCaThi.TabIndex = 3;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // STTCaThi
            // 
            this.STTCaThi.DataPropertyName = "STT";
            this.STTCaThi.HeaderText = "STT";
            this.STTCaThi.Name = "STTCaThi";
            this.STTCaThi.ReadOnly = true;
            this.STTCaThi.Width = 70;
            // 
            // TenCaThi
            // 
            this.TenCaThi.DataPropertyName = "TenCaThi";
            this.TenCaThi.HeaderText = "Tên ca thi";
            this.TenCaThi.Name = "TenCaThi";
            this.TenCaThi.ReadOnly = true;
            this.TenCaThi.Width = 269;
            // 
            // NgayThi
            // 
            this.NgayThi.DataPropertyName = "NgayThi";
            this.NgayThi.HeaderText = "Ngày thi";
            this.NgayThi.Name = "NgayThi";
            this.NgayThi.ReadOnly = true;
            this.NgayThi.Width = 150;
            // 
            // BatDau
            // 
            this.BatDau.DataPropertyName = "BatDau";
            this.BatDau.HeaderText = "Bắt đầu";
            this.BatDau.Name = "BatDau";
            this.BatDau.ReadOnly = true;
            this.BatDau.Width = 140;
            // 
            // KetThuc
            // 
            this.KetThuc.DataPropertyName = "KetThuc";
            this.KetThuc.HeaderText = "Kết thúc";
            this.KetThuc.Name = "KetThuc";
            this.KetThuc.ReadOnly = true;
            this.KetThuc.Width = 140;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(802, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 596);
            this.panel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvRoomTest);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(500, 551);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách phòng thi";
            // 
            // dgvRoomTest
            // 
            this.dgvRoomTest.AllowUserToResizeColumns = false;
            this.dgvRoomTest.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvRoomTest.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvRoomTest.ColumnHeadersHeight = 30;
            this.dgvRoomTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDPhongThi,
            this.STTPhongThi,
            this.TenPhongThi});
            this.dgvRoomTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRoomTest.EnableHeadersVisualStyles = false;
            this.dgvRoomTest.GridColor = System.Drawing.Color.Black;
            this.dgvRoomTest.Location = new System.Drawing.Point(3, 16);
            this.dgvRoomTest.MultiSelect = false;
            this.dgvRoomTest.Name = "dgvRoomTest";
            this.dgvRoomTest.ReadOnly = true;
            this.dgvRoomTest.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvRoomTest.RowHeadersWidth = 25;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRoomTest.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRoomTest.RowTemplate.Height = 30;
            this.dgvRoomTest.RowTemplate.ReadOnly = true;
            this.dgvRoomTest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoomTest.Size = new System.Drawing.Size(494, 532);
            this.dgvRoomTest.TabIndex = 4;
            // 
            // IDPhongThi
            // 
            this.IDPhongThi.DataPropertyName = "ID";
            this.IDPhongThi.HeaderText = "ID Phòng Thi";
            this.IDPhongThi.Name = "IDPhongThi";
            this.IDPhongThi.ReadOnly = true;
            this.IDPhongThi.Visible = false;
            // 
            // STTPhongThi
            // 
            this.STTPhongThi.DataPropertyName = "STT";
            this.STTPhongThi.HeaderText = "STT";
            this.STTPhongThi.Name = "STTPhongThi";
            this.STTPhongThi.ReadOnly = true;
            this.STTPhongThi.Width = 70;
            // 
            // TenPhongThi
            // 
            this.TenPhongThi.DataPropertyName = "TenPhongThi";
            this.TenPhongThi.HeaderText = "Tên phòng thi";
            this.TenPhongThi.Name = "TenPhongThi";
            this.TenPhongThi.ReadOnly = true;
            this.TenPhongThi.Width = 397;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnTrangThaiPhongThi);
            this.panel2.Controls.Add(this.btnThoat);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 551);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(500, 45);
            this.panel2.TabIndex = 0;
            // 
            // btnTrangThaiPhongThi
            // 
            this.btnTrangThaiPhongThi.BackColor = System.Drawing.Color.White;
            this.btnTrangThaiPhongThi.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTrangThaiPhongThi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrangThaiPhongThi.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrangThaiPhongThi.Image = ((System.Drawing.Image)(resources.GetObject("btnTrangThaiPhongThi.Image")));
            this.btnTrangThaiPhongThi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrangThaiPhongThi.Location = new System.Drawing.Point(6, 0);
            this.btnTrangThaiPhongThi.Name = "btnTrangThaiPhongThi";
            this.btnTrangThaiPhongThi.Size = new System.Drawing.Size(248, 45);
            this.btnTrangThaiPhongThi.TabIndex = 34;
            this.btnTrangThaiPhongThi.Text = "Trạng thái phòng thi";
            this.btnTrangThaiPhongThi.UseVisualStyleBackColor = false;
            this.btnTrangThaiPhongThi.Click += new System.EventHandler(this.btnTrangThaiPhongThi_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.White;
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(254, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(246, 45);
            this.btnThoat.TabIndex = 33;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // FrmTrangThaiDiaDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 596);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTrangThaiDiaDiem";
            this.Text = "FrmTrangThaiDiaDiem";
            this.Load += new System.EventHandler(this.FrmTrangThaiDiaDiem_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaThi)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomTest)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvCaThi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvRoomTest;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnTrangThaiPhongThi;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPhongThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn STTPhongThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenPhongThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn STTCaThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenCaThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn KetThuc;
    }
}