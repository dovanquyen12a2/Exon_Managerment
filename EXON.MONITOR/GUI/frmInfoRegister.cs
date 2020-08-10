
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXON.MONITOR.Common;
using EXON.SubModel.Models;
using EXON.Common;
using EXON.SubData.Services;
namespace EXON.MONITOR.GUI
{
    public partial class frmRegister : Form
    {
        int _contestantid=0;
     
        List<SUBJECT> lstsub =  new List<SUBJECT>();
     
        CONTESTANT _contestant;
        private ContestantService _ContestantService;
        byte[] img = new byte[] { };

        public frmRegister()
        {
            InitializeComponent();
           
        }
        public frmRegister(int register)
        {
            InitializeComponent();
            _contestantid = register;
            _ContestantService = new ContestantService();

        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            Disable_Enable(false);
            LoadData();
            

        }

        private void LoadData()
        {
            
            _contestant =_ContestantService.GetById(_contestantid);
            if(_contestant!=null)
            {
                txtFullName.Text = _contestant.FullName;
                txtIdentityCardNumber.Text = _contestant.IdentityCardNumber;           
                txtStudentCode.Text = _contestant.StudentCode;
                dtpDOB.Value = DatetimeConvert.ConvertUnixToDateTime((Int32)_contestant.DOB);
                ImageConverter imger = new ImageConverter();
                img = _contestant.Image;
                try
                {
                    ptbImage.Image = (Image)imger.ConvertFrom(_contestant.Image);
                }
                catch
                {
                }
                if (_contestant.Sex == 0)
                    rbtnFemale.Checked = true;
                else rbtnMale.Checked = true;
            }
            
        }
        
        private void LoadImageToPicturebox()
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Title = "Tải ảnh cá nhân";
            //For any other formats
            of.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (of.ShowDialog() == DialogResult.OK)
            {
               
                if (of.FileName != "" && of.FileName != null)
                {
                    FileInfo fInfo = new FileInfo(of.FileName);
                    long numBytes = fInfo.Length;
                    FileStream fStream = new FileStream(of.FileName, FileMode.Open, FileAccess.Read);
                    if (fStream.Length > 500000)
                    {
                        MessageBox.Show("Dung lượng ảnh quá lớn (>500KB)!");
                        return;
                    }
                    ptbImage.ImageLocation = of.FileName;
                    ptbImage.Image = new Bitmap(of.FileName);
                    BinaryReader br = new BinaryReader(fStream);

                    // convert the file to a byte array
                    img = br.ReadBytes((int)numBytes);
                    br.Close();
                }
                //ptbImage.Image = Image.FromFile(of.FileName);
            }
            of.Dispose();
        }
        private void EditRegister()
        {
            try
            {
 
                //_contestant = new REGISTER(); 
                string name = MathHelper.FormatProperCase(txtFullName.Text);
                _contestant.FullName = name;
                _contestant.Sex = rbtnFemale.Checked ? 0 : 1;
                _contestant.StudentCode = txtStudentCode.Text;
                _contestant.DOB = DateTimeHelpers.ConvertDateTimeToUnix(dtpDOB.Value);
                _contestant.IdentityCardNumber = txtIdentityCardNumber.Text;
                _contestant.Image = img;
                
                if (img.Length != 0)
                {

                    if (_contestant.Status == 1000)
                    {
                        _contestant.Status = 1002;
                    }
                    else if (_contestant.Status == 1001)
                    {
                        _contestant.Status = 1003;
                    }
                    else _contestant.Status = 1002;
                    

                } 
                if(_ContestantService.UpdateContestant(_contestant))
                    MessageBox.Show("Lưu thông tin thành công!");
                else
                {
                    MessageBox.Show("Lưu thông tin không thành công!\n" );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (CheckInfo() == false)
            {
                MessageBox.Show(@"Bạn phải điền đầy đủ các thông tin cần thiết.");
            }
            else
            {
                    EditRegister();
            }
        }
        private bool CheckInfo()
        {
            if (txtFullName.Text == "")
            {
                MessageBox.Show(@"Bạn phải điền đầy đủ tên.");
                return false;
            }
            else
            {
                
                if (dtpDOB.Value.Year >= DatetimeConvert.GetDateTimeServer().Year - 16)
                {
                    MessageBox.Show("Bạn chưa đủ độ tuổi đăng ký!");
                    return false;
                }
                if (!CheckName(txtFullName.Text))
                {
                    MessageBox.Show("Họ tên không hợp lệ, (chứa ký tự đặc biệt)!");
                    return false;
                }
                return true;
            }
        }
        bool CheckName(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsLetter(c))
                {
                    if (c != ' ') return false;

                }

            }
            return true;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Disable_Enable(true);
        }
        private void Disable_Enable(bool xx)
        {
           btnPhoto.Enabled= btnSave.Enabled= dtpDOB.Enabled = txtFullName.Enabled   = btnTakePhoto.Enabled= xx;
        }

        private void btnTakePhoto_Click(object sender, EventArgs e)
        {
            LoadImageToPicturebox();
        }
        protected void AddImg(object sender, EventArgs e)
        {
            img = new byte[] { };

            //EXON.Register.frmTakePhoto frm = (EXON.Register.frmTakePhoto)sender;
            //img = frm.img;
        }
        private void btnPhoto_Click(object sender, EventArgs e)
        {
            //EXON.Register.frmTakePhoto frm = new EXON.Register.frmTakePhoto();
            //frm.btnDoneClick += new EventHandler(AddImg);
            //frm.ShowDialog();

            ImageConverter Iconver = new ImageConverter();
            try
            { ptbImage.Image = (Image)Iconver.ConvertFrom(img); }
            catch { }
        }
    }
}
