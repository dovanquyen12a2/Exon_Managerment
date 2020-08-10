
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Net.Sockets;
using System.Data.SqlClient;
using System.Configuration;
using EXON.Common;

namespace EXON.MONITOR.Common
{

    public class Controllers
    {
        private static Controllers instance;
        private static string CONNECTION_STRING = System.Configuration.ConfigurationManager.ConnectionStrings["MTA_QUIZ_1"].ConnectionString;
        public static Controllers Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Controllers();
                }
                return instance;
            }
        }

        private Controllers() { }
        public int GetDBName()
        {
            try
            {
                SqlConnectionStringBuilder SSB = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["MTA_QUIZ_1"].ConnectionString);
                if (SSB.DataSource == "MAYCHUTRUNGTAM\\SQLEXPRESS,1433")
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            catch
            {
                return -1;
            }
        }
        public bool HandleCheckDB()
        {

            try
            {



                SQLHelper sql = new SQLHelper(CONNECTION_STRING);
                if (sql.IsConnection)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void ExitApplicationFromNotificationForm(Form formClose)
        {

            formClose.Close();

        }
        public string HandleCountDown(int timer)
        {
            string stringTime = string.Empty;
            int m = timer / 60;
            int s = timer - m * 60;
            stringTime += m < 10 ? "0" + m.ToString() : m.ToString();
            stringTime += ":";
            stringTime += s < 10 ? "0" + s.ToString() : s.ToString();

            return stringTime;
        }
        public void GenerateConfigFile(ConfigApplication ca, out ErrorController EC)
        {
            try
            {


                // DATABASE
                INIHelper.Instance.WRITE(Constant.SECTION_DATABASE, "IP", ca.Database.IP);
                INIHelper.Instance.WRITE(Constant.SECTION_DATABASE, "PORT", ca.Database.Port.ToString());
                INIHelper.Instance.WRITE(Constant.SECTION_DATABASE, "DBName", ca.DBName);
                INIHelper.Instance.WRITE(Constant.SECTION_DATABASE, "Username", ca.UsernameDB);
                INIHelper.Instance.WRITE(Constant.SECTION_DATABASE, "Password", ca.PasswordDB);

                Encryption.Instance.EncryptConfigFile(Constant.PATH_CONFIG_FILE_TMP, Constant.PATH_CONFIG_FILE, out EC);
                if (EC.ErrorCode == Constant.STATUS_OK)
                {
                    File.Delete(Constant.PATH_CONFIG_FILE_TMP);
                    FileInfo configFile = new FileInfo(Constant.PATH_CONFIG_FILE);
                    configFile.Attributes = FileAttributes.Hidden;
                    EC = new ErrorController(Constant.STATUS_OK, "Config file created at " + Constant.PATH_CONFIG_FILE);
                }
            }
            catch (Exception ex)
            {
                EC = new ErrorController(Constant.STATUS_UNKOWN_EXCEPTION, string.Format(Constant.STR_STATUS_UNKOWN_EXCEPTION, ex.Message));
            }
        }
        public void GetConfigFile(out ConfigApplication rCA, out ErrorController EC)
        {
            try
            {
                if (File.Exists(Constant.PATH_CONFIG_FILE))
                {
                    ConfigApplication ca = new ConfigApplication();

                    // COMMON
                    ca.Password = INIHelper.Instance.READ(Constant.SECTION_COMMON, "Password");
                    if (ca.Password != Constant.ENCRYPT_PASS_HASH)
                    {
                        Constant.ENCRYPT_PASS_HASH = ca.Password;
                    }


                    // DATABASE
                    ca.Database = new IPConfig(INIHelper.Instance.READ(Constant.SECTION_DATABASE, "IP"), Convert.ToInt32(INIHelper.Instance.READ(Constant.SECTION_DATABASE, "PORT")));
                    ca.DBName = INIHelper.Instance.READ(Constant.SECTION_DATABASE, "DBName");
                    ca.UsernameDB = INIHelper.Instance.READ(Constant.SECTION_DATABASE, "Username");
                    ca.PasswordDB = INIHelper.Instance.READ(Constant.SECTION_DATABASE, "Password");
                    rCA = ca;
                    // Delete file tmp
                    File.Delete(Constant.PATH_CONFIG_FILE_TMP);
                    EC = new ErrorController(Constant.STATUS_OK, "GET config file successfully.");
                }
                else
                {
                    rCA = null;
                    EC = new ErrorController(Constant.STATUS_NORMAL, "Config file not found.");
                }
            }
            catch (Exception ex)
            {
                rCA = null;
                EC = new ErrorController(Constant.STATUS_UNKOWN_EXCEPTION, string.Format(Constant.STR_STATUS_UNKOWN_EXCEPTION, ex.Message));
            }
        }
        public string HandleStringErrorController(ErrorController EC)
        {
            return string.Format("{0}: {1}", EC.ErrorCode, EC.Message);
        }
    }
}
