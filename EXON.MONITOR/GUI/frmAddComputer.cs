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
namespace EXON.MONITOR.GUI
{
    public partial class frmAddComputer : MetroForm
    {
        private int _roomTestID;
        private int _roomDiagramID;
        private bool _EditOrAdd;
        private ucAddnewCom ucAdd;
        private ucEditComputer ucEdit;
        public frmAddComputer()
        {
            InitializeComponent();
        }
        public frmAddComputer(int ID ,bool EditOrAdd)
        {
            InitializeComponent();
            if(EditOrAdd)
            {
                this._roomDiagramID = ID;
            }
            else
            {
                this._roomTestID = ID;
            }
            this._EditOrAdd = EditOrAdd;
        }

        private void frmAddComputer_Load(object sender, EventArgs e)
        {
            if (_EditOrAdd)
            {
               ucEdit = new ucEditComputer(_roomDiagramID);
                ucEdit.Dock = DockStyle.Fill;
                panel1.Controls.Add(ucEdit);
            }
            else
            {
                ucAdd = new ucAddnewCom(_roomTestID);
                ucAdd.Dock = DockStyle.Fill;
                panel1.Controls.Add(ucAdd);
            }
        }
    }
}
