using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralManagement.Supervisors
{
    public partial class frmLoading : MetroForm
    {

        public int totalProgress;

        private int CurrentProgress = 0;

        public frmLoading()
        {
            InitializeComponent();
        }
        private void ProcessData(IProgress<int> progress)
        {
         
           
            progress.Report((CurrentProgress * 100) / totalProgress);
        }
        public  void HandelWorlking(bool flag)
        {
            if (flag)
            {
                this.CurrentProgress++;
                var progress = new Progress<int>();
                progress.ProgressChanged += (o, report) =>
                 {
                      lblStatus.Text = "Đang giải mã đề: " + report+ "%";
                     lblStatus.Update();
                     mpLoading.Update();
                     mpLoading.Value = report;
                     mpLoading.Update();
                     this.Update();
                     if (CurrentProgress == totalProgress)
                     {
                   

                         btnOK.Visible = true;
                     }
                 };
               

                ProcessData(progress);
            }
        }
        private void frmLoading_Load(object sender, EventArgs e)
        {
            //Screen scr = Screen.PrimaryScreen; //đi lấy màn hình chính
            //this.Left = (scr.WorkingArea.Width - this.Width)/ 2;
           // this.Top = (scr.WorkingArea.Height - this.Height)/ 2;

        }

        private void btnOK_Click(object sender, EventArgs e)
        { 

            this.Close();
        }
    }
}
