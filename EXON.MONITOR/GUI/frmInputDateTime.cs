using EXON.MONITOR.Common;
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
    public partial class frmInputDateTime : MetroForm
    {
        public delegate void SendDateTime(int ThoiGianGianDoan,string Note);

        public event SendDateTime Sender;
      
        public frmInputDateTime()
        {
            InitializeComponent();
            dateTimePicker1.Value = DatetimeConvert.GetDateTimeServer();
            
        }

        private void mbtnInput_Click(object sender, EventArgs e)
        {
            if(txtNote.Text!=null)
            {
                int ThoiGianGianDoan = 0;
              
                if (DatetimeConvert.ConvertDateTimeToUnix(dateTimePicker1.Value)<= DatetimeConvert.ConvertDateTimeToUnix(DatetimeConvert.GetDateTimeServer()))
                {
                
                    ThoiGianGianDoan = DatetimeConvert.ConvertDateTimeToUnix(dateTimePicker1.Value);
                    Sender(ThoiGianGianDoan, txtNote.Text);
                    this.Close();
                }
                else{
                    MessageBox.Show("Thời gian gián đoạn không được lớn hơn thời gian hiện tại!");
                }    
            }
          else
            {
                MessageBox.Show("Nguyên nhân không được để trống!");
            }
        }
    }
}
