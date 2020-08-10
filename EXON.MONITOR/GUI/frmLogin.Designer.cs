namespace EXON.MONITOR.GUI
{
    partial class frmLogin
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
               System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
               this.linkLabel1 = new System.Windows.Forms.LinkLabel();
               this.btnThoat = new System.Windows.Forms.Button();
               this.btnDangNhap = new System.Windows.Forms.Button();
               this.ceHienMatKhau = new System.Windows.Forms.CheckBox();
               this.ceLuuMatKhau = new System.Windows.Forms.CheckBox();
               this.txtPassword = new System.Windows.Forms.TextBox();
               this.txtUserName = new System.Windows.Forms.TextBox();
               this.pictureBox2 = new System.Windows.Forms.PictureBox();
               this.linkLabel2 = new System.Windows.Forms.LinkLabel();
               ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
               this.SuspendLayout();
               // 
               // linkLabel1
               // 
               this.linkLabel1.AutoSize = true;
               this.linkLabel1.Location = new System.Drawing.Point(20, 427);
               this.linkLabel1.Name = "linkLabel1";
               this.linkLabel1.Size = new System.Drawing.Size(138, 13);
               this.linkLabel1.TabIndex = 16;
               this.linkLabel1.TabStop = true;
               this.linkLabel1.Text = "Bạn không thể đăng nhập?";
               // 
               // btnThoat
               // 
               this.btnThoat.BackColor = System.Drawing.Color.CornflowerBlue;
               this.btnThoat.ForeColor = System.Drawing.Color.White;
               this.btnThoat.Location = new System.Drawing.Point(53, 375);
               this.btnThoat.Name = "btnThoat";
               this.btnThoat.Size = new System.Drawing.Size(292, 36);
               this.btnThoat.TabIndex = 15;
               this.btnThoat.Text = "Thoát";
               this.btnThoat.UseVisualStyleBackColor = false;
               this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
               // 
               // btnDangNhap
               // 
               this.btnDangNhap.BackColor = System.Drawing.Color.CornflowerBlue;
               this.btnDangNhap.ForeColor = System.Drawing.Color.White;
               this.btnDangNhap.Location = new System.Drawing.Point(53, 333);
               this.btnDangNhap.Name = "btnDangNhap";
               this.btnDangNhap.Size = new System.Drawing.Size(292, 36);
               this.btnDangNhap.TabIndex = 14;
               this.btnDangNhap.Text = "Đăng Nhập";
               this.btnDangNhap.UseVisualStyleBackColor = false;
               this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
               // 
               // ceHienMatKhau
               // 
               this.ceHienMatKhau.AutoSize = true;
               this.ceHienMatKhau.Location = new System.Drawing.Point(180, 300);
               this.ceHienMatKhau.Name = "ceHienMatKhau";
               this.ceHienMatKhau.Size = new System.Drawing.Size(97, 17);
               this.ceHienMatKhau.TabIndex = 13;
               this.ceHienMatKhau.Text = "Hiện Mật Khẩu";
               this.ceHienMatKhau.UseVisualStyleBackColor = true;
               this.ceHienMatKhau.CheckedChanged += new System.EventHandler(this.ceHienMatKhau_CheckedChanged);
               // 
               // ceLuuMatKhau
               // 
               this.ceLuuMatKhau.AutoSize = true;
               this.ceLuuMatKhau.Location = new System.Drawing.Point(65, 300);
               this.ceLuuMatKhau.Name = "ceLuuMatKhau";
               this.ceLuuMatKhau.Size = new System.Drawing.Size(93, 17);
               this.ceLuuMatKhau.TabIndex = 12;
               this.ceLuuMatKhau.Text = "Lưu Mật Khẩu";
               this.ceLuuMatKhau.UseVisualStyleBackColor = true;
               // 
               // txtPassword
               // 
               this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.txtPassword.Location = new System.Drawing.Point(53, 256);
               this.txtPassword.Multiline = true;
               this.txtPassword.Name = "txtPassword";
               this.txtPassword.PasswordChar = '*';
               this.txtPassword.Size = new System.Drawing.Size(292, 38);
               this.txtPassword.TabIndex = 2;
               this.txtPassword.Text = "123123";
               // 
               // txtUserName
               // 
               this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.txtUserName.Location = new System.Drawing.Point(53, 212);
               this.txtUserName.Multiline = true;
               this.txtUserName.Name = "txtUserName";
               this.txtUserName.Size = new System.Drawing.Size(292, 38);
               this.txtUserName.TabIndex = 1;
               this.txtUserName.Text = "khanhnn";
               // 
               // pictureBox2
               // 
               this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
               this.pictureBox2.Location = new System.Drawing.Point(38, 18);
               this.pictureBox2.Name = "pictureBox2";
               this.pictureBox2.Size = new System.Drawing.Size(339, 188);
               this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
               this.pictureBox2.TabIndex = 17;
               this.pictureBox2.TabStop = false;
               // 
               // linkLabel2
               // 
               this.linkLabel2.AutoSize = true;
               this.linkLabel2.Location = new System.Drawing.Point(282, 427);
               this.linkLabel2.Name = "linkLabel2";
               this.linkLabel2.Size = new System.Drawing.Size(95, 13);
               this.linkLabel2.TabIndex = 18;
               this.linkLabel2.TabStop = true;
               this.linkLabel2.Text = "Khôi phục dữ liệu?";
               // 
               // frmLogin
               // 
               this.AcceptButton = this.btnDangNhap;
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(406, 450);
               this.ControlBox = false;
               this.Controls.Add(this.linkLabel2);
               this.Controls.Add(this.pictureBox2);
               this.Controls.Add(this.linkLabel1);
               this.Controls.Add(this.btnThoat);
               this.Controls.Add(this.btnDangNhap);
               this.Controls.Add(this.ceHienMatKhau);
               this.Controls.Add(this.ceLuuMatKhau);
               this.Controls.Add(this.txtPassword);
               this.Controls.Add(this.txtUserName);
               this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
               this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
               this.Margin = new System.Windows.Forms.Padding(2);
               this.Name = "frmLogin";
               this.Padding = new System.Windows.Forms.Padding(14, 60, 14, 15);
               this.Text = "      ĐĂNG NHẬP HỆ THỐNG";
               this.Load += new System.EventHandler(this.frmLogin_Load);
               ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
               this.ResumeLayout(false);
               this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.CheckBox ceHienMatKhau;
        private System.Windows.Forms.CheckBox ceLuuMatKhau;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}