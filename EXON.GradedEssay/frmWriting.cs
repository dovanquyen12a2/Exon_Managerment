using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXON.GradedEssay
{
    public partial class frmWriting : Form
    {
        private int _contestID;
        public int _TypeShow;
        private int _locationID { get; set; }
        public frmWriting(int Contestid ,int TypeShow,int LocationID)
        {
            InitializeComponent();
            this._contestID = Contestid;
            this._TypeShow = TypeShow;
            this._locationID = LocationID;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }
        public void InitControl()
        {
            pnlMain.Controls.Clear();
            if (_TypeShow == 2)
            {
                Control.ucWritting uc = new Control.ucWritting(_contestID,_locationID);
                uc.Dock = DockStyle.Fill;
                pnlMain.Controls.Add(uc);
            }
            else
            {
                Control.ucWrittingContest uc = new Control.ucWrittingContest(_contestID,_locationID);
                uc.Dock = DockStyle.Fill;
                pnlMain.Controls.Add(uc);
            }
            this.Update();
        }
        private void frmWriting_Load(object sender, EventArgs e)
        {
           
            InitControl();
        }
    }
}
