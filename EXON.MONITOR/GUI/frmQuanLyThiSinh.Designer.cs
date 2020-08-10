namespace EXON.MONITOR.GUI
{
    partial class frmQuanLyThiSinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyThiSinh));
            this.lbTongSo = new System.Windows.Forms.Label();
            this.btnRefesh = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSum = new System.Windows.Forms.Label();
            this.btnAddnew = new System.Windows.Forms.Button();
            this.contextMenuMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuitemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gvMain = new System.Windows.Forms.DataGridView();
            this.cID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cContestantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBoD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCMND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStudentCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbRoomTest = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbShift = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.contextMenuMain.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTongSo
            // 
            this.lbTongSo.AutoSize = true;
            this.lbTongSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongSo.Location = new System.Drawing.Point(12, 24);
            this.lbTongSo.Name = "lbTongSo";
            this.lbTongSo.Size = new System.Drawing.Size(62, 17);
            this.lbTongSo.TabIndex = 5;
            this.lbTongSo.Text = "Tổng Số";
            // 
            // btnRefesh
            // 
            this.btnRefesh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefesh.ImageIndex = 1;
            this.btnRefesh.ImageList = this.imageList1;
            this.btnRefesh.Location = new System.Drawing.Point(657, 14);
            this.btnRefesh.Name = "btnRefesh";
            this.btnRefesh.Size = new System.Drawing.Size(123, 37);
            this.btnRefesh.TabIndex = 4;
            this.btnRefesh.Text = "Làm Mới";
            this.btnRefesh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefesh.UseVisualStyleBackColor = true;
            this.btnRefesh.Click += new System.EventHandler(this.BtnRefesh_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1459433211_Remove.ico");
            this.imageList1.Images.SetKeyName(1, "1459968210_view-refresh.png");
            this.imageList1.Images.SetKeyName(2, "Actions-list-add-icon (1).png");
            this.imageList1.Images.SetKeyName(3, "Excel-icon.png");
            this.imageList1.Images.SetKeyName(4, "Search-icon.png");
            this.imageList1.Images.SetKeyName(5, "maps-and-flags.png");
            this.imageList1.Images.SetKeyName(6, "funnel.png");
            this.imageList1.Images.SetKeyName(7, "1459968365_edit-paste.png");
            this.imageList1.Images.SetKeyName(8, "Finger-Print-icon.png");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSum);
            this.groupBox1.Controls.Add(this.btnAddnew);
            this.groupBox1.Controls.Add(this.lbTongSo);
            this.groupBox1.Controls.Add(this.btnRefesh);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 401);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1191, 66);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSum.ForeColor = System.Drawing.Color.Red;
            this.lblSum.Location = new System.Drawing.Point(80, 23);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(0, 17);
            this.lblSum.TabIndex = 14;
            // 
            // btnAddnew
            // 
            this.btnAddnew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddnew.Image = global::EXON.MONITOR.Properties.Resources.add16;
            this.btnAddnew.Location = new System.Drawing.Point(510, 13);
            this.btnAddnew.Name = "btnAddnew";
            this.btnAddnew.Size = new System.Drawing.Size(123, 37);
            this.btnAddnew.TabIndex = 13;
            this.btnAddnew.Text = "Thêm mới";
            this.btnAddnew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddnew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddnew.UseVisualStyleBackColor = true;
            this.btnAddnew.Click += new System.EventHandler(this.btnAddnew_Click);
            // 
            // contextMenuMain
            // 
            this.contextMenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuitemEdit});
            this.contextMenuMain.Name = "contextMenuMain";
            this.contextMenuMain.Size = new System.Drawing.Size(175, 26);
            // 
            // menuitemEdit
            // 
            this.menuitemEdit.Name = "menuitemEdit";
            this.menuitemEdit.Size = new System.Drawing.Size(174, 22);
            this.menuitemEdit.Text = "Cập nhật thông tin";
            this.menuitemEdit.Click += new System.EventHandler(this.MenuitemEdit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gvMain);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1191, 467);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách Thí sinh";
            // 
            // gvMain
            // 
            this.gvMain.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.gvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cID,
            this.cSTT,
            this.cContestantCode,
            this.cName,
            this.cUnit,
            this.CBoD,
            this.cCMND,
            this.cSex,
            this.cStudentCode});
            this.gvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvMain.GridColor = System.Drawing.Color.Black;
            this.gvMain.Location = new System.Drawing.Point(3, 70);
            this.gvMain.Name = "gvMain";
            this.gvMain.ReadOnly = true;
            this.gvMain.Size = new System.Drawing.Size(1185, 394);
            this.gvMain.TabIndex = 13;
            // 
            // cID
            // 
            this.cID.DataPropertyName = "ContestantShiftID";
            this.cID.HeaderText = "ID";
            this.cID.Name = "cID";
            this.cID.ReadOnly = true;
            this.cID.Visible = false;
            // 
            // cSTT
            // 
            this.cSTT.DataPropertyName = "STT";
            this.cSTT.HeaderText = "STT";
            this.cSTT.Name = "cSTT";
            this.cSTT.ReadOnly = true;
            this.cSTT.Width = 50;
            // 
            // cContestantCode
            // 
            this.cContestantCode.DataPropertyName = "ContestantCode";
            this.cContestantCode.HeaderText = "Số Báo danh";
            this.cContestantCode.Name = "cContestantCode";
            this.cContestantCode.ReadOnly = true;
            this.cContestantCode.Width = 150;
            // 
            // cName
            // 
            this.cName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cName.DataPropertyName = "FullName";
            this.cName.HeaderText = "Họ và Tên";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            // 
            // cUnit
            // 
            this.cUnit.DataPropertyName = "Unit";
            this.cUnit.HeaderText = "Lớp";
            this.cUnit.Name = "cUnit";
            this.cUnit.ReadOnly = true;
            this.cUnit.Width = 150;
            // 
            // CBoD
            // 
            this.CBoD.DataPropertyName = "DOB";
            this.CBoD.HeaderText = "Ngày Sinh";
            this.CBoD.Name = "CBoD";
            this.CBoD.ReadOnly = true;
            this.CBoD.Width = 150;
            // 
            // cCMND
            // 
            this.cCMND.DataPropertyName = "IdentityCardNumber";
            this.cCMND.HeaderText = "CMND";
            this.cCMND.Name = "cCMND";
            this.cCMND.ReadOnly = true;
            this.cCMND.Width = 150;
            // 
            // cSex
            // 
            this.cSex.DataPropertyName = "Subject";
            this.cSex.HeaderText = "Môn Thi";
            this.cSex.Name = "cSex";
            this.cSex.ReadOnly = true;
            this.cSex.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cSex.Width = 150;
            // 
            // cStudentCode
            // 
            this.cStudentCode.DataPropertyName = "StudentCode";
            this.cStudentCode.HeaderText = "Mã sinh viên";
            this.cStudentCode.Name = "cStudentCode";
            this.cStudentCode.ReadOnly = true;
            this.cStudentCode.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbRoomTest);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbShift);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1185, 54);
            this.panel1.TabIndex = 12;
            // 
            // cbRoomTest
            // 
            this.cbRoomTest.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbRoomTest.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbRoomTest.FormattingEnabled = true;
            this.cbRoomTest.Location = new System.Drawing.Point(496, 17);
            this.cbRoomTest.Name = "cbRoomTest";
            this.cbRoomTest.Size = new System.Drawing.Size(327, 21);
            this.cbRoomTest.TabIndex = 11;
            this.cbRoomTest.SelectedValueChanged += new System.EventHandler(this.cbRoomTest_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ca Thi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(440, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Phòng thi:";
            // 
            // cbShift
            // 
            this.cbShift.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbShift.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbShift.FormattingEnabled = true;
            this.cbShift.Location = new System.Drawing.Point(78, 16);
            this.cbShift.Name = "cbShift";
            this.cbShift.Size = new System.Drawing.Size(327, 21);
            this.cbShift.TabIndex = 9;
            this.cbShift.SelectedValueChanged += new System.EventHandler(this.cbShift_SelectedValueChanged);
            // 
            // frmQuanLyThiSinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 467);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmQuanLyThiSinh";
            this.Text = "Quản lý thí sinh";
            this.Load += new System.EventHandler(this.FrmQuanLyThiSinh_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuMain.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbTongSo;
        private System.Windows.Forms.Button btnRefesh;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuMain;
        private System.Windows.Forms.ToolStripMenuItem menuitemEdit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbShift;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddnew;
        private System.Windows.Forms.ComboBox cbRoomTest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.DataGridView gvMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn cContestantCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn CBoD;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCMND;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStudentCode;
    }
}