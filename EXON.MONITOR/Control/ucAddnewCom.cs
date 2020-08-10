using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXON.SubData.Services;
using EXON.SubModel.Models;
using EXON.MONITOR.Common;
using EXON.Common;

namespace EXON.MONITOR.Control
{
    public partial class ucAddnewCom : UserControl
    {
        private int status;
        private int _roomTestID;
        private IRoomDiagramService _RoomDiagramService;
        public ucAddnewCom()
        {
            InitializeComponent();
        }

        public ucAddnewCom(int _roomTestID)
        {
            InitializeComponent();
            this._roomTestID = _roomTestID;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtComputerName.Text.Trim() != "" && txtComputerCode.Text != "")
                {

                    if (cmbStatus.Text.Trim() != null)
                    {
                        if (cmbStatus.Text == "Tốt")
                        {
                            status = 4001;
                        }
                        else if (cmbStatus.Text == "Hỏng")
                        {
                            status = 4002;
                        }

                    }
                    ROOMDIAGRAM rd = new ROOMDIAGRAM();
                    _RoomDiagramService = new RoomDiagramService();
                    rd.ComputerCode = txtComputerCode.Text;
                    rd.ComputerName = txtComputerName.Text;
                    rd.Status = status;
                    rd.RoomTestID = _roomTestID;
                    _RoomDiagramService.Add(rd);
                    _RoomDiagramService.Save();
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);

                }
                else
                {
                    lblNotifi.Text = "Bạn cần nhập đầy đủ thông tin";
                    lblNotifi.ForeColor = Color.Red;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Sửa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }

        }
    }
}
