using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tung.Log;

namespace EXON.GradedEssay.Report
{
    public partial class frmInput : MetroFramework.Forms.MetroForm
    {
        public delegate void SendSode(int SoDeIn);
        public event SendSode Sender;
        public int SoCau;
        public frmInput()
        {
            InitializeComponent();
        }

        private void mbtnInput_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIndex.Text))
                {
                    MessageBox.Show("Không được để trống", "Thông báo");
                    return;
                }
                else
                {
                    SoCau = int.Parse(txtIndex.Text);
                    Sender(SoCau);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lối định dạng hoặc ô để trống.", "Lối");
                MessageBox.Show(ex.Message);
                Log.Instance.WriteErrorLog(LogType.ERROR, string.Format("Error when convert string to numver: {0}", ex.Message));
                return;
            }
            
        }

        
    }
}
