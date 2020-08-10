using EXON.SubModel.Models;
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
    public partial class frmTrangThaiDiaDiemThi : Form
    {
        private MTAQuizDbContext db = DAO.DBService.db;
        private int _LocationID;
        public frmTrangThaiDiaDiemThi(int LocationID)
        {
            InitializeComponent();
            this._LocationID = LocationID;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }
        private void frmTrangThaiDiaDiemThi_Load(object sender, EventArgs e)
        {
            ucTrangThaiDiaDiem tgz = new ucTrangThaiDiaDiem(db.LOCATIONS.Where(p => p.LocationID == _LocationID).FirstOrDefault());
            tgz.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(tgz);
            tgz.Show();
        }
    }
}
