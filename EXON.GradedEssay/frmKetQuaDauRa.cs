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
    public partial class frmKetQuaDauRa : Form
    {
        private int _contestID;
   
        private int _locationID { get; set; }
        public frmKetQuaDauRa(int Contestid, int LocationID)
        {
            InitializeComponent();
            this._contestID = Contestid;
            
            this._locationID = LocationID;
        }
        public void InitControl()
        {
          
                Control.ucReportKetQuaNN uc = new Control.ucReportKetQuaNN(_contestID,_locationID);
                uc.Dock = DockStyle.Fill;
                pnlMain.Controls.Add(uc);
            
            this.Update();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }
        private void frmReportEL_Load(object sender, EventArgs e)
        {
            InitControl();
        }
    }
}
