using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHoiDongThiVer2.GUI
{
    public partial class frmTrangThaiDDThi : Form
    {
        private int _ContestID { get; set; }
        private int _LocaionID { get; set; }
        private int _StaffID { get; set; }
        public frmTrangThaiDDThi(int ContestID,int LocaionID,int StaffID)
        {
            InitializeComponent();
            _ContestID = ContestID;
            _LocaionID = LocaionID;
            _StaffID = StaffID;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void FrmTrangThaiDDThi_Load(object sender, EventArgs e)
        {
            ucTrangThaiDiaDiemThiHK tgz = new ucTrangThaiDiaDiemThiHK(_ContestID, _LocaionID,_StaffID) ;
            tgz.Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(tgz);
            tgz.Show();
        }
    }
}
