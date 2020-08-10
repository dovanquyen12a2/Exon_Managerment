using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXON.SubModel.Models;

namespace QuanLyHoiDongThiVer2.GUI
{
    public partial class FrmTrangThaiDiaDiem : Form
    {
        private MTAQuizDbContext db = new MTAQuizDbContext();
        private LOCATION diadiem = new LOCATION();

        #region Constructor

        public FrmTrangThaiDiaDiem()
        {
            InitializeComponent();
            DAO.DBService.Reload();
        }

        public FrmTrangThaiDiaDiem(LOCATION lc)
        {
            InitializeComponent();
            DAO.DBService.Reload();
            diadiem = lc;
        }

        #endregion Constructor

        #region LoadForm

        private void FrmTrangThaiDiaDiem_Load(object sender, EventArgs e)
        {
            // cbx Shift
            int i = 1;
            dgvCaThi.DataSource = db.SHIFTS.Where(p => p.ContestID == diadiem.ContestID && p.Status > 0)
                                  .OrderBy(p => p.StartTime)
                                  .ToList()
                                  .Select(p => new
                                  {
                                      ID = p.ShiftID,
                                      STT = i++,
                                      TenCaThi = p.ShiftName,
                                      NgayThi = DAO.Helper.ConvertUnixToDateTime((int)p.ShiftDate).ToString("dd/MM/yyyy"),
                                      BatDau = DAO.Helper.ConvertUnixToDateTime((int)p.StartTime).ToString("HH : mm "),
                                      KetThuc = DAO.Helper.ConvertUnixToDateTime((int)p.EndTime).ToString("HH : mm ")
                                  })
                                  .ToList();

            // cbx Roomtest
            i = 1;
            dgvRoomTest.DataSource = db.ROOMTESTS.Where(p => p.Status > 0 && p.LocationID == diadiem.LocationID)
                                     .ToList()
                                     .Select(p => new
                                     {
                                         ID = p.RoomTestID,
                                         STT = i++,
                                         TenPhongThi = p.RoomTestName
                                     })
                                     .ToList();
        }

        #endregion LoadForm

        #region Hàm chức năng

        private DIVISION_SHIFTS GetDivisionShiftWithiD()
        {
            try
            {
                int shiftID, RoomtestID;
                shiftID = (int)dgvCaThi.SelectedRows[0].Cells["ID"].Value;
                RoomtestID = (int)dgvRoomTest.SelectedRows[0].Cells["IDPhongThi"].Value;
                return db.DIVISION_SHIFTS.Where(p => p.Status > 0 && p.ShiftID == shiftID && p.RoomTestID == RoomtestID).First();
            }
            catch
            {
                return new DIVISION_SHIFTS();
            }
        }

        #endregion Hàm chức năng

        #region sự kiện

        private void btnTrangThaiPhongThi_Click(object sender, EventArgs e)
        {
            DIVISION_SHIFTS dv = GetDivisionShiftWithiD();
            if (dv.DivisionShiftID == 0)
            {
                MessageBox.Show("Chưa có ca thi nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmTrangThaiPhongThi tg = new FrmTrangThaiPhongThi(dv);
            tg.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion sự kiện
    }
}