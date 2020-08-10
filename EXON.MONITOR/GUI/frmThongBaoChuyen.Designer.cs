namespace EXON.MONITOR.GUI
{
    partial class frmThongBaoChuyen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongBaoChuyen));
            this.rtfReason = new System.Windows.Forms.RichTextBox();
            this.btnChangeShift = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtfReason
            // 
            this.rtfReason.Location = new System.Drawing.Point(41, 61);
            this.rtfReason.Name = "rtfReason";
            this.rtfReason.Size = new System.Drawing.Size(421, 100);
            this.rtfReason.TabIndex = 1;
            this.rtfReason.Text = "";
            // 
            // btnChangeShift
            // 
            this.btnChangeShift.Location = new System.Drawing.Point(141, 167);
            this.btnChangeShift.Name = "btnChangeShift";
            this.btnChangeShift.Size = new System.Drawing.Size(115, 32);
            this.btnChangeShift.TabIndex = 2;
            this.btnChangeShift.Text = "Chuyển thí sinh";
            this.btnChangeShift.UseVisualStyleBackColor = true;
            this.btnChangeShift.Click += new System.EventHandler(this.btnChangeShift_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(290, 167);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 32);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Trở về";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmThongBaoChuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 216);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChangeShift);
            this.Controls.Add(this.rtfReason);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThongBaoChuyen";
            this.Resizable = false;
            this.Text = "Lý Do Chuyển Thí Sinh";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtfReason;
        private System.Windows.Forms.Button btnChangeShift;
        private System.Windows.Forms.Button btnCancel;
    }
}