using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using EXON.MONITOR.Control;
using EXON.SubData.Services;
namespace EXON.MONITOR.GUI
{
    public partial class frmRoomConfig : Form
    {
        private int _roomtestID;
        private IRoomTestService _RoomTestService;
        ucQuanLyMayThi ucQL;
        private int _locationID { get; set; }
        private int _contestID { get; set; }
        public frmRoomConfig(int contestID, int LocationID)
        {
            InitializeComponent();
            this._contestID = contestID;
            this._locationID = LocationID;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }
        public frmRoomConfig(int _RoomtestID)
        {
            InitializeComponent();
            this._RoomTestService = new RoomTestService();
            this._roomtestID = _RoomtestID;
            this.Text = "Quản lý máy thi tại phòng thi " + _RoomTestService.GetById(_RoomtestID).RoomTestName;
        }
        private void frmRoomConfig_Load(object sender, EventArgs e)
        {
            ucQL = new ucQuanLyMayThi(_locationID,_contestID);
            ucQL.Dock = DockStyle.Fill;
          //  ucQL.Location = new Point(0, 0);
            pnlMain.Controls.Add(ucQL);
        }
    }
}
