using EXON.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EXON.MONITOR.Common
{
    public class Encryption

    {
        private static Encryption instance;
        public static Encryption Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Encryption();
                }
                return instance;
            }
        }
        private Encryption() { }
        public string MD5Encryption(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }
        public void EncryptConnectionString(out ErrorController EC, bool encrypt = true, string pass = null)
        {
            Configuration configuration = null;
            try
            {
                // Open the configuration file and retrieve the connectionStrings section.
                configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                ConnectionStringsSection configSection = configuration.GetSection("connectionStrings") as ConnectionStringsSection;
                if ((!(configSection.ElementInformation.IsLocked)) && (!(configSection.SectionInformation.IsLocked)))
                {
                    if (encrypt && !configSection.SectionInformation.IsProtected)
                    {
                        //this line will encrypt the file
                        configSection.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                    }

                    if (!encrypt && Encryption.Instance.MD5Encryption(pass) == Constant.ENCRYPT_PASS_HASH && configSection.SectionInformation.IsProtected)//encrypt is true so encrypt
                    {
                        //this line will decrypt the file. 
                        configSection.SectionInformation.UnprotectSection();
                    }
                    //re-save the configuration file section
                    configSection.SectionInformation.ForceSave = true;
                    // Save the current configuration

                    configuration.Save(ConfigurationSaveMode.Full);
                    ConfigurationManager.RefreshSection("connectionStringsSection");
                    //configFile.FilePath 

                }
                EC = new ErrorController(Constant.STATUS_OK, "Encrypt ConnectString successfully");
            }
            catch
            {
                ///Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_FATAL, ex.Message);
                EC = new ErrorController(Constant.STATUS_NORMAL, "Can not encrypt ConnectString");
            }
        }
        public void EncryptConfigFile(string inputFile, string outputFile, out ErrorController EC)
        {
            try
            {
                using (RijndaelManaged aes = new RijndaelManaged())
                {
                    byte[] key = ASCIIEncoding.UTF8.GetBytes(Constant.ENCRYPT_PASS_HASH.Substring(0, 16));

                    /* This is for demostrating purposes only. 
                     * Ideally you will want the IV key to be different from your key and you should always generate a new one for each encryption in other to achieve maximum security*/
                    byte[] IV = ASCIIEncoding.UTF8.GetBytes(Constant.ENCRYPT_PASS_HASH.Substring(16));

                    using (FileStream fsCrypt = new FileStream(outputFile, FileMode.Create, FileAccess.ReadWrite))
                    {
                        using (ICryptoTransform encryptor = aes.CreateEncryptor(key, IV))
                        {
                            using (CryptoStream cs = new CryptoStream(fsCrypt, encryptor, CryptoStreamMode.Write))
                            {
                                using (FileStream fsIn = new FileStream(inputFile, FileMode.Open, FileAccess.ReadWrite))
                                {
                                    int data;
                                    while ((data = fsIn.ReadByte()) != -1)
                                    {
                                        cs.WriteByte((byte)data);
                                    }
                                    EC = new ErrorController(Constant.STATUS_OK, "Encrypt config file successfully.");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EC = new ErrorController(Constant.STATUS_UNKOWN_EXCEPTION, string.Format(Constant.STR_STATUS_UNKOWN_EXCEPTION, ex.Message));
            }

        }
        public void DecryptConfigFile(string inputFile, string outputFile, out ErrorController EC)
        {
            try
            {
                using (RijndaelManaged aes = new RijndaelManaged())
                {
                    byte[] key = ASCIIEncoding.UTF8.GetBytes(Constant.ENCRYPT_PASS_HASH.Substring(0, 16));

                    /* This is for demostrating purposes only. 
                     * Ideally you will want the IV key to be different from your key and you should always generate a new one for each encryption in other to achieve maximum security*/
                    byte[] IV = ASCIIEncoding.UTF8.GetBytes(Constant.ENCRYPT_PASS_HASH.Substring(16));

                    using (FileStream fsCrypt = new FileStream(inputFile, FileMode.Open, FileAccess.ReadWrite))
                    {
                        using (FileStream fsOut = new FileStream(outputFile, FileMode.Create, FileAccess.ReadWrite))
                        {
                            using (ICryptoTransform decryptor = aes.CreateDecryptor(key, IV))
                            {
                                using (CryptoStream cs = new CryptoStream(fsCrypt, decryptor, CryptoStreamMode.Read))
                                {
                                    int data;
                                    while ((data = cs.ReadByte()) != -1)
                                    {
                                        fsOut.WriteByte((byte)data);
                                    }
                                    EC = new ErrorController(Constant.STATUS_OK, "Dencrypt config file successfully.");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EC = new ErrorController(Constant.STATUS_UNKOWN_EXCEPTION, string.Format(Constant.STR_STATUS_UNKOWN_EXCEPTION, ex.Message));
            }
        }
    }
}