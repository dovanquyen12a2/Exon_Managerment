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

namespace EXON.GradedEssay.Control
{
    public partial class frmProgress : MetroFramework.Forms.MetroForm
    {
        public int _MaxValue;
        public frmProgress(int Maxvalue)
        {
            InitializeComponent();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = Maxvalue;
            _MaxValue = Maxvalue;
        }

        public void UpdateValue (int Value)
        {
            progressBar1.Value = Value;
      
            this.Update();
            lblTongSo.Text = string.Format("Đã ghép {0} bài làm trên tổng số {1}", Value, _MaxValue);  
            this.Update();
        }
        public void UpdateValue2(int Value)
        {
            progressBar1.Value = Value;

            this.Update();
            lblTongSo.Text = string.Format("Đang tạo dữ liệu...");
            this.Update();
        }
    }
}
