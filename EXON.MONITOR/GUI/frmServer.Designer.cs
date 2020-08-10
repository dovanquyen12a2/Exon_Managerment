namespace EXON.MONITOR.GUI
{
    partial class frmServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServer));
            this.mpnlTop = new MetroFramework.Controls.MetroPanel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.mbtnPrint = new MetroFramework.Controls.MetroButton();
            this.lblEndTime = new MetroFramework.Controls.MetroLabel();
            this.lblShiftName = new MetroFramework.Controls.MetroLabel();
            this.lblStartTime = new MetroFramework.Controls.MetroLabel();
            this.tabMain = new MetroFramework.Controls.MetroTabControl();
            this.mncPrintArr = new System.Windows.Forms.ToolStripMenuItem();
            this.mncPrintResult = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mncPrintQuestionSpeaking = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDivisionShift = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemStartTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemChangeShift = new System.Windows.Forms.ToolStripMenuItem();
            this.metroContextMenu2 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.mItemPrintContestant = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemPrintResultContestant = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mItemStartForAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTesting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCompleteTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmReadytest = new System.Windows.Forms.ToolStripMenuItem();
            this.mpnlTop.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.metroContextMenu2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mpnlTop
            // 
            this.mpnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(182)))), ((int)(((byte)(246)))));
            this.mpnlTop.Controls.Add(this.metroPanel1);
            this.mpnlTop.Controls.Add(this.lblEndTime);
            this.mpnlTop.Controls.Add(this.lblShiftName);
            this.mpnlTop.Controls.Add(this.lblStartTime);
            this.mpnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.mpnlTop.HorizontalScrollbarBarColor = true;
            this.mpnlTop.HorizontalScrollbarHighlightOnWheel = false;
            this.mpnlTop.HorizontalScrollbarSize = 10;
            this.mpnlTop.Location = new System.Drawing.Point(20, 30);
            this.mpnlTop.Name = "mpnlTop";
            this.mpnlTop.Size = new System.Drawing.Size(1075, 38);
            this.mpnlTop.TabIndex = 6;
            this.mpnlTop.UseCustomBackColor = true;
            this.mpnlTop.UseCustomForeColor = true;
            this.mpnlTop.VerticalScrollbarBarColor = true;
            this.mpnlTop.VerticalScrollbarHighlightOnWheel = false;
            this.mpnlTop.VerticalScrollbarSize = 10;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.White;
            this.metroPanel1.Controls.Add(this.mbtnPrint);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 0);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(126, 38);
            this.metroPanel1.TabIndex = 5;
            this.metroPanel1.UseCustomBackColor = true;
            this.metroPanel1.UseCustomForeColor = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // mbtnPrint
            // 
            this.mbtnPrint.AutoSize = true;
            this.mbtnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.mbtnPrint.DisplayFocus = true;
            this.mbtnPrint.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.mbtnPrint.ForeColor = System.Drawing.Color.DarkRed;
            this.mbtnPrint.Highlight = true;
            this.mbtnPrint.Location = new System.Drawing.Point(0, 0);
            this.mbtnPrint.Name = "mbtnPrint";
            this.mbtnPrint.Size = new System.Drawing.Size(123, 38);
            this.mbtnPrint.TabIndex = 10;
            this.mbtnPrint.Text = "Menu";
            this.mbtnPrint.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mbtnPrint.UseCustomBackColor = true;
            this.mbtnPrint.UseCustomForeColor = true;
            this.mbtnPrint.UseSelectable = true;
            this.mbtnPrint.Click += new System.EventHandler(this.mbtnPrint_Click);
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(182)))), ((int)(((byte)(246)))));
            this.lblEndTime.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblEndTime.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblEndTime.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblEndTime.ForeColor = System.Drawing.Color.Black;
            this.lblEndTime.Location = new System.Drawing.Point(815, 7);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(108, 25);
            this.lblEndTime.TabIndex = 8;
            this.lblEndTime.Text = "ThoiKetThuc";
            this.lblEndTime.UseCustomBackColor = true;
            this.lblEndTime.UseCustomForeColor = true;
            // 
            // lblShiftName
            // 
            this.lblShiftName.AutoSize = true;
            this.lblShiftName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(182)))), ((int)(((byte)(246)))));
            this.lblShiftName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblShiftName.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblShiftName.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblShiftName.ForeColor = System.Drawing.Color.Black;
            this.lblShiftName.Location = new System.Drawing.Point(160, 7);
            this.lblShiftName.Name = "lblShiftName";
            this.lblShiftName.Size = new System.Drawing.Size(55, 25);
            this.lblShiftName.TabIndex = 6;
            this.lblShiftName.Text = "CaThi";
            this.lblShiftName.UseCustomBackColor = true;
            this.lblShiftName.UseCustomForeColor = true;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(182)))), ((int)(((byte)(246)))));
            this.lblStartTime.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblStartTime.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblStartTime.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblStartTime.ForeColor = System.Drawing.Color.Black;
            this.lblStartTime.Location = new System.Drawing.Point(560, 7);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(107, 25);
            this.lblStartTime.TabIndex = 7;
            this.lblStartTime.Text = "TimeBatDau";
            this.lblStartTime.UseCustomBackColor = true;
            this.lblStartTime.UseCustomForeColor = true;
            // 
            // tabMain
            // 
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(20, 68);
            this.tabMain.Name = "tabMain";
            this.tabMain.Size = new System.Drawing.Size(1075, 477);
            this.tabMain.TabIndex = 1;
            this.tabMain.UseSelectable = true;
            this.tabMain.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            this.tabMain.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.tabControl1_ControlAdded);
            // 
            // mncPrintArr
            // 
            this.mncPrintArr.Name = "mncPrintArr";
            this.mncPrintArr.Size = new System.Drawing.Size(248, 22);
            this.mncPrintArr.Text = "In danh sách thí sinh đã xếp chỗ";
            // 
            // mncPrintResult
            // 
            this.mncPrintResult.Name = "mncPrintResult";
            this.mncPrintResult.Size = new System.Drawing.Size(248, 22);
            this.mncPrintResult.Text = "In kết quả thí sinh đã hoàn thành";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(245, 6);
            // 
            // mncPrintQuestionSpeaking
            // 
            this.mncPrintQuestionSpeaking.Name = "mncPrintQuestionSpeaking";
            this.mncPrintQuestionSpeaking.Size = new System.Drawing.Size(248, 22);
            this.mncPrintQuestionSpeaking.Text = "In câu hỏi cho phần thi nói";
            // 
            // MenuItemDivisionShift
            // 
            this.MenuItemDivisionShift.Enabled = false;
            this.MenuItemDivisionShift.Name = "MenuItemDivisionShift";
            this.MenuItemDivisionShift.Size = new System.Drawing.Size(156, 22);
            this.MenuItemDivisionShift.Text = "&Phát đề";
            // 
            // MenuItemStartTest
            // 
            this.MenuItemStartTest.Enabled = false;
            this.MenuItemStartTest.Name = "MenuItemStartTest";
            this.MenuItemStartTest.Size = new System.Drawing.Size(156, 22);
            this.MenuItemStartTest.Text = "&Bắt đầu làm bài";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(153, 6);
            // 
            // MenuItemChangeShift
            // 
            this.MenuItemChangeShift.Name = "MenuItemChangeShift";
            this.MenuItemChangeShift.Size = new System.Drawing.Size(156, 22);
            this.MenuItemChangeShift.Text = "&Chuyển ca thi ";
            // 
            // metroContextMenu2
            // 
            this.metroContextMenu2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemPrintContestant,
            this.mItemPrintResultContestant,
            this.toolStripSeparator2,
            this.mItemStartForAll});
            this.metroContextMenu2.Name = "metroContextMenu2";
            this.metroContextMenu2.Size = new System.Drawing.Size(259, 98);
            // 
            // mItemPrintContestant
            // 
            this.mItemPrintContestant.Name = "mItemPrintContestant";
            this.mItemPrintContestant.Size = new System.Drawing.Size(258, 22);
            this.mItemPrintContestant.Text = "Danh sách thí sinh trong phòng thi";
            this.mItemPrintContestant.Click += new System.EventHandler(this.mItemPrintContestant_Click);
            // 
            // mItemPrintResultContestant
            // 
            this.mItemPrintResultContestant.Name = "mItemPrintResultContestant";
            this.mItemPrintResultContestant.Size = new System.Drawing.Size(258, 22);
            this.mItemPrintResultContestant.Text = "In kết quả thí sinh đã hoàn thành";
            this.mItemPrintResultContestant.Click += new System.EventHandler(this.mItemPrintResultContestant_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(255, 6);
            // 
            // mItemStartForAll
            // 
            this.mItemStartForAll.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmReadytest,
            this.tsmTesting,
            this.tsmCompleteTest});
            this.mItemStartForAll.Name = "mItemStartForAll";
            this.mItemStartForAll.Size = new System.Drawing.Size(258, 22);
            this.mItemStartForAll.Text = "Cập nhập trạng thái đang thi";
            this.mItemStartForAll.Click += new System.EventHandler(this.mItemStartForAll_Click);
            // 
            // tsmTesting
            // 
            this.tsmTesting.Name = "tsmTesting";
            this.tsmTesting.Size = new System.Drawing.Size(180, 22);
            this.tsmTesting.Text = "Đang thi";
            this.tsmTesting.Click += new System.EventHandler(this.TsmTesting_Click);
            // 
            // tsmCompleteTest
            // 
            this.tsmCompleteTest.Name = "tsmCompleteTest";
            this.tsmCompleteTest.Size = new System.Drawing.Size(180, 22);
            this.tsmCompleteTest.Text = "Hoàn thành thi";
            this.tsmCompleteTest.Click += new System.EventHandler(this.TsmCompleteTest_Click);
            // 
            // tsmReadytest
            // 
            this.tsmReadytest.Name = "tsmReadytest";
            this.tsmReadytest.Size = new System.Drawing.Size(180, 22);
            this.tsmReadytest.Text = "Sẵn sàng thi";
            this.tsmReadytest.Click += new System.EventHandler(this.TsmReadytest_Click);
            // 
            // frmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 565);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.mpnlTop);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmServer";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Text = "Giám Sát Ca Thi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmServer_FormClosing);
            this.Load += new System.EventHandler(this.frmServer_Load);
            this.mpnlTop.ResumeLayout(false);
            this.mpnlTop.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroContextMenu2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel mpnlTop;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroButton mbtnPrint;
        private MetroFramework.Controls.MetroLabel lblEndTime;
        private MetroFramework.Controls.MetroLabel lblShiftName;
        private MetroFramework.Controls.MetroLabel lblStartTime;
        private MetroFramework.Controls.MetroTabControl tabMain;

        private System.Windows.Forms.ToolStripMenuItem mncPrintArr;
        private System.Windows.Forms.ToolStripMenuItem mncPrintResult;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mncPrintQuestionSpeaking;
       
        private System.Windows.Forms.ToolStripMenuItem MenuItemDivisionShift;
        private System.Windows.Forms.ToolStripMenuItem MenuItemStartTest;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemChangeShift;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu2;
        private System.Windows.Forms.ToolStripMenuItem mItemPrintContestant;
        private System.Windows.Forms.ToolStripMenuItem mItemPrintResultContestant;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mItemStartForAll;
        private System.Windows.Forms.ToolStripMenuItem tsmReadytest;
        private System.Windows.Forms.ToolStripMenuItem tsmTesting;
        private System.Windows.Forms.ToolStripMenuItem tsmCompleteTest;
    }
}