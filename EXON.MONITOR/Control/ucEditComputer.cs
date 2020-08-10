using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXON.SubModel.Models;
using EXON.SubData.Services;
using EXON.MONITOR.Common;
using EXON.Common;

namespace EXON.MONITOR.Control
{
    public partial class ucEditComputer : UserControl
    {
        private int _roomDiagramID;
        private IRoomDiagramService _RoomDiagramService;
        private ROOMDIAGRAM rd;
        private int status;

        public ucEditComputer()
        {
            InitializeComponent();
        }

        public ucEditComputer(int _roomDiagramID)
        {
            InitializeComponent();
            this._roomDiagramID = _roomDiagramID;
            _RoomDiagramService = new RoomDiagramService();
        }

        private void ucEditComputer_Load(object sender, EventArgs e)
        {
            rd = new ROOMDIAGRAM();
            rd = _RoomDiagramService.GetById(_roomDiagramID);
            if(rd !=null)
            {
                txtComputerCode.Text = rd.ComputerCode;
                txtComputerName.Text = rd.ComputerName;
                cmbStatus.Text = rd.Status == 4001 ? "Tốt" : "Không phản hồi";

            } 
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtComputerName.Text.Trim() != "")
                {
                    if (cmbStatus.Text == "Tốt")
                    {
                        status = 4001;
                    }
                    else if (cmbStatus.Text == "Không phản hồi")
                    {
                        status = 4002;
                    }
                    _RoomDiagramService = new RoomDiagramService();
                    ROOMDIAGRAM rd = _RoomDiagramService.GetById(_roomDiagramID);
                    rd.ComputerCode = txtComputerCode.Text;
                    rd.ComputerName = txtComputerName.Text;
                    rd.Status = status;

                    _RoomDiagramService.Update(rd);
                    _RoomDiagramService.Save();
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Sửa không thành công", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Error);
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }

        }
    }
}
