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
using EXON.SubModel.Models;
using EXON.MONITOR.Common;
using EXON.SubData.Services;
using EXON.Common;

namespace EXON.MONITOR.GUI
{
    public partial class frmInputKey : MetroForm
    {
        private int divisionShiftID;
      
     
        public delegate void SendIsCrypt(bool IsDecrypt);
        public event SendIsCrypt Sender;
        private IDivisionShiftService _DivisionShiftService;
        public frmInputKey()
        {
            InitializeComponent();
           
        }
        public frmInputKey(int _divisionShiftID)
        {
            InitializeComponent();
            this.divisionShiftID = _divisionShiftID;
            _DivisionShiftService = new DivisionShiftService();
        }
        private void frmInputKey_Load(object sender, EventArgs e)
        {

        }

        private void mtxtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MTAQuizDbContext Db = new MTAQuizDbContext();
            
                En_Decrypt _decrypt;
                string key = Db.DIVISION_SHIFTS.Where(x => x.DivisionShiftID == divisionShiftID).SingleOrDefault().Key;
                if (key == mtxtKey.Text)
                {
                    set();
                    
                    _decrypt = new En_Decrypt(key);
                    List<QUESTIONS_TEMP> lsTempQuestion = new List<QUESTIONS_TEMP>();
                    try { 
                    lsTempQuestion = Db.QUESTIONS_TEMP.Where(x => x.DivisionShiftID == divisionShiftID).ToList();
                    }
                    catch(Exception ex)
                    {
                        string a = ex.Message;
                    }
                    
                    int count = 0;
                    foreach (var item in lsTempQuestion)
                    {
                        QUESTION Question = new QUESTION();
                        Question = Db.QUESTIONS.Where(x => x.QuestionID == item.QuestionID).SingleOrDefault();
                        Question.QuestionContent = _decrypt.Encrypt1000(item.QuestionContent);
                        List<SUBQUESTION> lsSubQuestion = new List<SUBQUESTION>();
                        lsSubQuestion = Question.SUBQUESTIONS.ToList();

                        try
                        {
                            Db.SaveChanges();
                            int countlsSub = 0;
                            foreach (var sub in lsSubQuestion)
                            {
                                string s = Db.SUBQUESTIONS_TEMP.Where(x => x.SubQuestionID == sub.SubQuestionID && x.DivisionShiftID == divisionShiftID).FirstOrDefault().SubQuestionContent;
                                sub.SubQuestionContent = _decrypt.Encrypt1000(s);
                                Db.SaveChanges();
                                countlsSub++;
                            }
                            if (countlsSub == lsSubQuestion.Count && lsSubQuestion.Count>0 )
                            {               
                                count++;
                            }

                        }

                        catch
                        {
                            MessageBox.Show("Thông báo", "Giải mã không thành công!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        //s(true);
                        progressBar1.Value = count * 100 / lsTempQuestion.Count;
                        lbProgress.Text = progressBar1.Value.ToString()+"%";
                        lbProgress.Update();
                    }
                    if (count == lsTempQuestion.Count)
                    {
                        btnOK.Enabled = true;
                        lbstatus.Text = "Hoàn thành giải mã đề thi!";
                        lbstatus.ForeColor = Color.DarkGreen;
                        Sender(true);
                        _DivisionShiftService.UpdateStatus(divisionShiftID, (int)Constant.StatusDivisionShift.STATUS_DECRYPT);
                        MessageBox.Show("Giải mã đề thi thành công!");
                    }
                }
                else
                {
                    MessageBox.Show("Nhập mã sai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        void set()
        {
            this.Height = 253;
            mtxtKey.Enabled = false;
            lbstatus.Text = "Đang giải mã đề..";
            lbstatus.Update();
            this.Update();
            
        }
        //void frmclose(object sender, EventArgs e)
        //{

        //    this.Close();
        //}

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}

