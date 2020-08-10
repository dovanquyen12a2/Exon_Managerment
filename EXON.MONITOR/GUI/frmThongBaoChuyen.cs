using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXON.MONITOR.GUI
{
    public partial class frmThongBaoChuyen : MetroForm
    {

    
        public delegate void SendNotifi(string Reason);
        public event SendNotifi sendWorking; 
        public frmThongBaoChuyen()
        {
            InitializeComponent();
        }
       
        private void btnChangeShift_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn chuyển thí sinh xuống ca thi dự phòng", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                if (rtfReason.Text != null)
                    sendWorking(rtfReason.Text);
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
