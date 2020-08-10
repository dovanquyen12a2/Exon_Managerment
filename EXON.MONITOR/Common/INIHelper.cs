using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using EXON.Common;

namespace EXON.MONITOR.Common
{
    public class INIHelper
    {
        private static INIHelper instance;
        public static INIHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new INIHelper();
                }
                return instance;
            }
        }
        private INIHelper() { }
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);
        [DllImport("kernel32")]
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filepath);

        public string READ(string sSection, string sKey)
        {
            StringBuilder tmp = new StringBuilder(Constant.BUFFER_SIZE_DEFAULT);
            long i = GetPrivateProfileString(sSection, sKey, string.Empty, tmp, Constant.BUFFER_SIZE_DEFAULT, Constant.PATH_CONFIG_FILE_TMP);
            return tmp.ToString();
        }
        public void WRITE(string sSection, string sKey, string sData)
        {
            if (!Directory.Exists(Constant.PATH_EXON))
            {
                Directory.CreateDirectory(Constant.PATH_EXON);
            }
            WritePrivateProfileString(sSection, sKey, sData, Constant.PATH_CONFIG_FILE_TMP);
        }
    }
}
