using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXON.GradedEssay.Control
{
    public partial class ucLoad : MetroFramework.Forms.MetroForm
    {
        public ucLoad()
        {
            InitializeComponent();
        }

        private void ucLoad_Load(object sender, EventArgs e)
        {
            circularProgressBar1.Value = 0;
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = 100;
        }
        public void UpdateValue (int value)
        {
            circularProgressBar1.Value = value;
            circularProgressBar1.Update();
          
        }
        public void UpdateValueForWritting(int value)
        {
            circularProgressBar1.Value = value;
            circularProgressBar1.Update();
            circularProgressBar1.Text = string.Format("Vui lòng chờ. \n Đã tạo thành công {0} trên {1} bài làm..", value);
        }
        public void UpdateValue2(int value)
        {
            circularProgressBar1.Value = value;
            circularProgressBar1.Update();
           
        }
    }
}
