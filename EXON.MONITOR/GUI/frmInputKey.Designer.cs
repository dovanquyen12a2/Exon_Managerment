namespace EXON.MONITOR.GUI
{
    partial class frmInputKey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInputKey));
            this.mtxtKey = new MetroFramework.Controls.MetroTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbstatus = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.lbProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mtxtKey
            // 
            // 
            // 
            // 
            this.mtxtKey.CustomButton.Image = null;
            this.mtxtKey.CustomButton.Location = new System.Drawing.Point(140, 1);
            this.mtxtKey.CustomButton.Name = "";
            this.mtxtKey.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mtxtKey.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxtKey.CustomButton.TabIndex = 1;
            this.mtxtKey.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxtKey.CustomButton.UseSelectable = true;
            this.mtxtKey.CustomButton.Visible = false;
            this.mtxtKey.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.mtxtKey.Lines = new string[0];
            this.mtxtKey.Location = new System.Drawing.Point(95, 77);
            this.mtxtKey.MaxLength = 32767;
            this.mtxtKey.Name = "mtxtKey";
            this.mtxtKey.PasswordChar = '•';
            this.mtxtKey.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxtKey.SelectedText = "";
            this.mtxtKey.SelectionLength = 0;
            this.mtxtKey.SelectionStart = 0;
            this.mtxtKey.ShortcutsEnabled = true;
            this.mtxtKey.Size = new System.Drawing.Size(162, 23);
            this.mtxtKey.TabIndex = 0;
            this.mtxtKey.UseSelectable = true;
            this.mtxtKey.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxtKey.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mtxtKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtxtKey_KeyDown);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(8, 166);
            this.progressBar1.MarqueeAnimationSpeed = 10;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(315, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 1;
            // 
            // lbstatus
            // 
            this.lbstatus.AutoSize = true;
            this.lbstatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbstatus.Location = new System.Drawing.Point(112, 140);
            this.lbstatus.Name = "lbstatus";
            this.lbstatus.Size = new System.Drawing.Size(0, 13);
            this.lbstatus.TabIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(130, 207);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(78, 32);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lbProgress
            // 
            this.lbProgress.AutoSize = true;
            this.lbProgress.Location = new System.Drawing.Point(329, 171);
            this.lbProgress.Name = "lbProgress";
            this.lbProgress.Size = new System.Drawing.Size(0, 13);
            this.lbProgress.TabIndex = 4;
            // 
            // frmInputKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 122);
            this.Controls.Add(this.lbProgress);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbstatus);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.mtxtKey);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInputKey";
            this.ShowIcon = false;
            this.Text = "Nhập khóa ";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Load += new System.EventHandler(this.frmInputKey_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox mtxtKey;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbstatus;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lbProgress;
    }
}