using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using EXON.SubModel.Models;
using MetroFramework.Forms;
using EXON.SubData.Services;
using Microsoft.Office.Interop.Excel;
using EXON.MONITOR.Common;
using EXON.Common;

namespace EXON.MONITOR.GUI
{
    public partial class frmImportRoom : MetroForm
    {
        int roomtest;
        private List<RoomDiagramInFor> lstRoomdia;
        private IRoomTestService _RoomTestService;
        public frmImportRoom(int _roomtest)
        {
            
            InitializeComponent();
            this.roomtest = _roomtest;
            _RoomTestService = new RoomTestService();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        //private DataTable ReadDataFromExcelFile()
        //{
        //    string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox1.Text.Trim() + ";Extended Properties=\"Excel 8.0\";";
        //    // Tạo đối tượng kết nối
        //    OleDbConnection oledbConn = new OleDbConnection(connectionString);
        //    DataTable data = null;
        //    try
        //    {
        //        // Mở kết nối
        //        oledbConn.Open();

        //        // Tạo đối tượng OleDBCommand và query data từ sheet có tên "Sheet1"
        //        OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", oledbConn);

        //        // Tạo đối tượng OleDbDataAdapter để thực thi việc query lấy dữ liệu từ tập tin excel
        //        OleDbDataAdapter oleda = new OleDbDataAdapter();

        //        oleda.SelectCommand = cmd;

        //        // Tạo đối tượng DataSet để hứng dữ liệu từ tập tin excel
        //        DataSet ds = new DataSet();
        //        // Đổ đữ liệu từ tập excel vào DataSet
        //        oleda.Fill(ds);

        //        data = ds.Tables[0];
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {
        //        // Đóng chuỗi kết nối
        //        oledbConn.Close();
        //    }
        //    return data;
        //}
        private List<RoomDiagramInFor> ReadDataFromExcelFile(string FileName)
        {
            List<RoomDiagramInFor> lstresult = new List<RoomDiagramInFor>();
            int dem = 0;

            try
            {
                var xlApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(FileName, 0, true, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, false, 1, 0);
                Microsoft.Office.Interop.Excel.Worksheet xlWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Sheets[1];
                Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;
                int startindex = 2;
                for (int i = 1; i < rowCount; i++)
                {
                    string item = "";
                    try
                    {
                        item = xlRange.Cells[i, 1].value.ToString().Trim();
                    }
                    catch { }
                    if (item == "TT")
                    {
                        startindex = i + 1;
                        break;
                    }
                }
                for (int i = startindex; i <= rowCount; i++)
                {
                    dem = i;
                    RoomDiagramInFor temp = new RoomDiagramInFor();
              
                    temp.ComputerCode = (string)xlRange.Cells[i, 1].value.ToString().Trim();
                    temp.ComputerName = (string)xlRange.Cells[i, 2].value.ToString().Trim();
                    temp.Status = (string)xlRange.Cells[i, 3].value.ToString().Trim() == "Tốt" ? 4001 : 4002;
        
                    lstresult.Add(temp);
                }

                //xlWorksheet.Columns.AutoFit();
                // xlWorkBook.Save();
                xlWorkBook.Close();
                xlApp.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi lay du lieu: " + ex.Message + "\n\nDong: " + (dem - 1).ToString());
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }
            finally
            {
            }
            return lstresult;
        }
        private void ImportIntoDatabase(List<RoomDiagramInFor> data, int RoomTestID)
        {
            if (data == null || data.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để import");
                return;
            }
            int count = 0;
            try
            {
                using (MTAQuizDbContext db = new MTAQuizDbContext())
                {
                    ROOMDIAGRAM rd = new ROOMDIAGRAM();
                    ROOMTEST rt = new ROOMTEST();

                    rt = _RoomTestService.GetById(RoomTestID);
                    int maxSeat = rt.MaxSeatMount;


                    for (int i = 0; i < data.Count; i++)
                    {
                        string Computername = data[i].ComputerName.ToString();
                        int countseat = db.ROOMDIAGRAMS.Count(x => x.RoomTestID == RoomTestID);
                        if (countseat < maxSeat)
                        {
                            if (db.ROOMDIAGRAMS.Where(x => x.ComputerName == Computername && x.RoomTestID == RoomTestID).SingleOrDefault() == null)
                            {
                                rd.ComputerCode = data[i].ComputerCode.ToString().Trim();
                                rd.ComputerName = data[i].ComputerName.ToString().Trim();
                                rd.Status =data[i].Status;
                                rd.RoomTestID = RoomTestID;
                                db.ROOMDIAGRAMS.Add(rd);
                                db.SaveChanges();
                                count++;
                            }
                            else
                            {
                                MessageBox.Show(data[i].ComputerName.ToString().Trim() + " Đã có trong phòng thi");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Phòng thi đã đủ");
                            break;
                        }
                    }
                    MessageBox.Show("Nhập thành công " + count.ToString() + "/" + data.Count.ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể nhập file");
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, string.Format("Expetion : {0}  ", ex.Message));

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void mbtnChooseFile_Click(object sender, EventArgs e)
        {
            // Browse đến file cần import
            OpenFileDialog ofd = new OpenFileDialog();
            // Lấy đường dẫn file import vừa chọn
            textBox1.Text = ofd.ShowDialog() == DialogResult.OK ? ofd.FileName : "";
            lstRoomdia = new List<RoomDiagramInFor>();
            lstRoomdia= ReadDataFromExcelFile(textBox1.Text);
            dgvCauHinh.DataSource = lstRoomdia;
        }

        private void mbtnInputFile_Click(object sender, EventArgs e)
        {
           // DataTable dt = ReadDataFromExcelFile();
            ImportIntoDatabase(lstRoomdia, roomtest);
        }

    }
    public class RoomDiagramInFor
    {
        public string ComputerCode { get; set; }
        public string ComputerName { get; set; }
        
        public int Status { get; set; }

    }
}
