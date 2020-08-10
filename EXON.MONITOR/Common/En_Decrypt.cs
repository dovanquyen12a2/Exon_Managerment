using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXON.MONITOR.Common
{
    class En_Decrypt
    {
        static string key = "";
        public En_Decrypt(string k)
        {
            key = k;
        }

        public string Encrypt(string toEncrypt)
        {
            if (toEncrypt == null) return null;
            StringBuilder inSb = new StringBuilder(toEncrypt);
            StringBuilder outSb = new StringBuilder(toEncrypt.Length);
            char c;
            for (int i = 0; i < toEncrypt.Length; i++)
            {
                c = inSb[i];
                c = (char)(c ^ key[i % key.Length]);
                outSb.Append(c);
            }
            return outSb.ToString();
        }
        public string Encrypt1000(string toEncrypt)
        {
            if (toEncrypt == null) return null;
            StringBuilder inSb = new StringBuilder(toEncrypt);

            char c;
            if (toEncrypt.Length > 1000)
            {
                StringBuilder outSb = new StringBuilder(1000);
                for (int i = 0; i < 1000; i++)
                {
                    c = inSb[i];
                    c = (char)(c ^ key[i % key.Length]);
                    outSb.Append(c);
                }
                string kq = outSb.ToString() + toEncrypt.Substring(1000, toEncrypt.Length - 1000);
                return kq;
            }
            else
            {
                StringBuilder outSb = new StringBuilder(toEncrypt.Length);
                for (int i = 0; i < toEncrypt.Length; i++)
                {
                    c = inSb[i];
                    c = (char)(c ^ key[i % key.Length]);
                    outSb.Append(c);
                }
                return outSb.ToString();
            }
        }
    }
}
