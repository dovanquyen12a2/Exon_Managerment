namespace EXON.MONITOR.Control
{
    partial class ucQuanLyMayThi
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
            this.gbTop = new System.Windows.Forms.GroupBox();
            this.cbRoomTest = new System.Windows.Forms.ComboBox();
            this.rdOK = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbKeyName = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnFilt = new System.Windows.Forms.Button();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbError = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCheckStatusCom = new System.Windows.Forms.Button();
            this.btnImportExcel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.lbCount = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddnew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gvMain = new System.Windows.Forms.DataGridView();
            this.cID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cContestantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbTop.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // gbTop
            // 
            this.gbTop.Controls.Add(this.cbRoomTest);
            this.gbTop.Controls.Add(this.rdOK);
            this.gbTop.Controls.Add(this.label4);
            this.gbTop.Controls.Add(this.label1);
            this.gbTop.Controls.Add(this.btnSearch);
            this.gbTop.Controls.Add(this.cmbKeyName);
            this.gbTop.Controls.Add(this.btnClear);
            this.gbTop.Controls.Add(this.btnFilt);
            this.gbTop.Controls.Add(this.rbAll);
            this.gbTop.Controls.Add(this.rbError);
            this.gbTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTop.Location = new System.Drawing.Point(0, 0);
            this.gbTop.Name = "gbTop";
            this.gbTop.Size = new System.Drawing.Size(1149, 87);
            this.gbTop.TabIndex = 4;
            this.gbTop.TabStop = false;
            this.gbTop.Text = "Thông thi phòng thi";
            // 
            // cbRoomTest
            // 
            this.cbRoomTest.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbRoomTest.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbRoomTest.FormattingEnabled = true;
            this.cbRoomTest.Location = new System.Drawing.Point(115, 15);
            this.cbRoomTest.Name = "cbRoomTest";
            this.cbRoomTest.Size = new System.Drawing.Size(438, 21);
            this.cbRoomTest.TabIndex = 12;
            this.cbRoomTest.SelectedValueChanged += new System.EventHandler(this.cbRoomTest_SelectedValueChanged);
            // 
            // rdOK
            // 
            this.rdOK.AutoSize = true;
            this.rdOK.Location = new System.Drawing.Point(922, 45);
            this.rdOK.Name = "rdOK";
            this.rdOK.Size = new System.Drawing.Size(60, 17);
            this.rdOK.TabIndex = 7;
            this.rdOK.TabStop = true;
            this.rdOK.Text = "Máy tốt";
            this.rdOK.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Phòng thi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tìm Kiếm";
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::EXON.MONITOR.Properties.Resources.search16;
            this.btnSearch.Location = new System.Drawing.Point(559, 45);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm Kiếm";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbKeyName
            // 
            this.cmbKeyName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbKeyName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbKeyName.FormattingEnabled = true;
            this.cmbKeyName.Location = new System.Drawing.Point(115, 46);
            this.cmbKeyName.Name = "cmbKeyName";
            this.cmbKeyName.Size = new System.Drawing.Size(438, 21);
            this.cmbKeyName.TabIndex = 9;
            // 
            // btnClear
            // 
            this.btnClear.ImageIndex = 0;
            this.btnClear.Location = new System.Drawing.Point(640, 45);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnFilt
            // 
            this.btnFilt.Image = global::EXON.MONITOR.Properties.Resources.filter;
            this.btnFilt.Location = new System.Drawing.Point(1021, 42);
            this.btnFilt.Name = "btnFilt";
            this.btnFilt.Size = new System.Drawing.Size(75, 23);
            this.btnFilt.TabIndex = 8;
            this.btnFilt.Text = "Lọc";
            this.btnFilt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFilt.UseVisualStyleBackColor = true;
            this.btnFilt.Click += new System.EventHandler(this.btnFilt_Click);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(745, 46);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(57, 17);
            this.rbAll.TabIndex = 5;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "Tất Cả";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // rbError
            // 
            this.rbError.AutoSize = true;
            this.rbError.Location = new System.Drawing.Point(808, 46);
            this.rbError.Name = "rbError";
            this.rbError.Size = new System.Drawing.Size(72, 17);
            this.rbError.TabIndex = 6;
            this.rbError.Text = "Máy hỏng";
            this.rbError.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCheckStatusCom);
            this.groupBox1.Controls.Add(this.btnImportExcel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.lbCount);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnAddnew);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 391);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1149, 69);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // btnCheckStatusCom
            // 
            this.btnCheckStatusCom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckStatusCom.Location = new System.Drawing.Point(321, 11);
            this.btnCheckStatusCom.Name = "btnCheckStatusCom";
            this.btnCheckStatusCom.Size = new System.Drawing.Size(123, 30);
            this.btnCheckStatusCom.TabIndex = 10;
            this.btnCheckStatusCom.Text = "Kiểm tra tình trạng máy";
            this.btnCheckStatusCom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCheckStatusCom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCheckStatusCom.UseVisualStyleBackColor = true;
            this.btnCheckStatusCom.Click += new System.EventHandler(this.btnCheckStatusCom_Click);
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportExcel.Image = global::EXON.MONITOR.Properties.Resources.Excel_icon;
            this.btnImportExcel.Location = new System.Drawing.Point(877, 11);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(123, 30);
            this.btnImportExcel.TabIndex = 9;
            this.btnImportExcel.Text = "Nhập từ file Excel";
            this.btnImportExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImportExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportExcel.UseVisualStyleBackColor = true;
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Máy thi tốt";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DarkGreen;
            this.button4.Location = new System.Drawing.Point(153, 44);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(19, 19);
            this.button4.TabIndex = 7;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Máy không phản hồi";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(8, 44);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(19, 19);
            this.button3.TabIndex = 7;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Location = new System.Drawing.Point(6, 16);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(48, 13);
            this.lbCount.TabIndex = 5;
            this.lbCount.Text = "Tổng Số";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Image = global::EXON.MONITOR.Properties.Resources.refresh162;
            this.btnRefresh.Location = new System.Drawing.Point(1016, 11);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(123, 30);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Làm Mới";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = global::EXON.MONITOR.Properties.Resources.delete16;
            this.btnDelete.Location = new System.Drawing.Point(738, 11);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(123, 30);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddnew
            // 
            this.btnAddnew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddnew.Image = global::EXON.MONITOR.Properties.Resources.add16;
            this.btnAddnew.Location = new System.Drawing.Point(460, 11);
            this.btnAddnew.Name = "btnAddnew";
            this.btnAddnew.Size = new System.Drawing.Size(123, 30);
            this.btnAddnew.TabIndex = 1;
            this.btnAddnew.Text = "Thêm mới";
            this.btnAddnew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddnew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddnew.UseVisualStyleBackColor = true;
            this.btnAddnew.Click += new System.EventHandler(this.btnAddnew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Image = global::EXON.MONITOR.Properties.Resources.Excel_icon;
            this.btnEdit.Location = new System.Drawing.Point(599, 11);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(123, 30);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gvMain);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1149, 304);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách máy thi";
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
            this.cStatus});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvMain.DefaultCellStyle = dataGridViewCellStyle1;
            this.gvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvMain.GridColor = System.Drawing.Color.Black;
            this.gvMain.Location = new System.Drawing.Point(3, 16);
            this.gvMain.Name = "gvMain";
            this.gvMain.ReadOnly = true;
            this.gvMain.Size = new System.Drawing.Size(1143, 285);
            this.gvMain.TabIndex = 0;
            this.gvMain.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvMain_CellFormatting);
            this.gvMain.SelectionChanged += new System.EventHandler(this.gvMain_SelectionChanged);
            // 
            // cID
            // 
            this.cID.DataPropertyName = "RoomDiagramID";
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
            this.cContestantCode.DataPropertyName = "ComputerCode";
            this.cContestantCode.HeaderText = "Mã máy";
            this.cContestantCode.Name = "cContestantCode";
            this.cContestantCode.ReadOnly = true;
            this.cContestantCode.Width = 300;
            // 
            // cName
            // 
            this.cName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cName.DataPropertyName = "ComputerName";
            this.cName.HeaderText = "Tên máy thi";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            // 
            // cStatus
            // 
            this.cStatus.DataPropertyName = "Status";
            this.cStatus.HeaderText = "Trạng Thái";
            this.cStatus.Name = "cStatus";
            this.cStatus.ReadOnly = true;
            this.cStatus.Width = 300;
            // 
            // ucQuanLyMayThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbTop);
            this.Name = "ucQuanLyMayThi";
            this.Size = new System.Drawing.Size(1149, 460);
            this.Load += new System.EventHandler(this.ucQuanLyMayThi_Load);
            this.gbTop.ResumeLayout(false);
            this.gbTop.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTop;
        private System.Windows.Forms.ComboBox cbRoomTest;
        private System.Windows.Forms.RadioButton rdOK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbKeyName;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnFilt;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.RadioButton rbError;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCheckStatusCom;
        private System.Windows.Forms.Button btnImportExcel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddnew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gvMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn cID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn cContestantCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStatus;
    }
}
