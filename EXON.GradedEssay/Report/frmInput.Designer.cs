namespace EXON.GradedEssay.Report
{
    partial class frmInput
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
            this.mbtnInput = new MetroFramework.Controls.MetroButton();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mbtnInput
            // 
            this.mbtnInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(182)))), ((int)(((byte)(246)))));
            this.mbtnInput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mbtnInput.ForeColor = System.Drawing.Color.White;
            this.mbtnInput.Highlight = true;
            this.mbtnInput.Location = new System.Drawing.Point(23, 80);
            this.mbtnInput.Name = "mbtnInput";
            this.mbtnInput.Size = new System.Drawing.Size(198, 48);
            this.mbtnInput.TabIndex = 13;
            this.mbtnInput.Text = "Nhập";
            this.mbtnInput.UseCustomBackColor = true;
            this.mbtnInput.UseCustomForeColor = true;
            this.mbtnInput.UseSelectable = true;
            this.mbtnInput.Click += new System.EventHandler(this.mbtnInput_Click);
            // 
            // txtIndex
            // 
            this.txtIndex.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIndex.Location = new System.Drawing.Point(134, 45);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(87, 29);
            this.txtIndex.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 21);
            this.label1.TabIndex = 15;
            this.label1.Text = "Nhập số đề: ";
            // 
            // frmInput
            // 
            this.AcceptButton = this.mbtnInput;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 143);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIndex);
            this.Controls.Add(this.mbtnInput);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInput";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton mbtnInput;
        private System.Windows.Forms.TextBox txtIndex;
        private System.Windows.Forms.Label label1;
    }
}