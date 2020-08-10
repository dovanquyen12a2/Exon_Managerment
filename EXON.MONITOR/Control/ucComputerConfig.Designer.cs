namespace GeneralManagement.Supervisors
{
    partial class ucComputerConfig
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
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbComputername = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ptbImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Times New Roman", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.Location = new System.Drawing.Point(8, 136);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(80, 17);
            this.lbStatus.TabIndex = 10;
            this.lbStatus.Text = "Trạng thái: ";
            this.lbStatus.Click += new System.EventHandler(this.lbStatus_Click);
            // 
            // lbComputername
            // 
            this.lbComputername.AutoSize = true;
            this.lbComputername.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbComputername.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbComputername.Location = new System.Drawing.Point(13, 12);
            this.lbComputername.Name = "lbComputername";
            this.lbComputername.Size = new System.Drawing.Size(54, 15);
            this.lbComputername.TabIndex = 9;
            this.lbComputername.Text = "Tên Máy";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::EXON.MONITOR.Properties.Resources.keybooo;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(10, 99);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(85, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // ptbImage
            // 
            this.ptbImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ptbImage.Image = global::EXON.MONITOR.Properties.Resources.monitor;
            this.ptbImage.Location = new System.Drawing.Point(10, 30);
            this.ptbImage.Name = "ptbImage";
            this.ptbImage.Size = new System.Drawing.Size(85, 63);
            this.ptbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbImage.TabIndex = 7;
            this.ptbImage.TabStop = false;
            this.ptbImage.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ucComputerConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.lbComputername);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.ptbImage);
            this.Name = "ucComputerConfig";
            this.Size = new System.Drawing.Size(106, 160);
            this.Load += new System.EventHandler(this.ucComputerConfig_Load);
            this.Click += new System.EventHandler(this.ucComputerConfig_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label lbComputername;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox ptbImage;
    }
}
