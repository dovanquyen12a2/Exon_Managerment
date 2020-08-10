using EXON.SubModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoiDongThiVer2.DTO
{
    public class KhoiThi
    {
        public KhoiThi()
        {
            Cnt_MonThi = 0;
            listMonThi = new List<SUBJECT>();
        }

        public int ID
        {
            get;
            set;
        }
        public int Cnt_MonThi { get; set; }
        public List<SUBJECT> listMonThi { get; set; }
        public string str
        {
            get;
            set;
        }
        public string toString()
        {
            string ans = "";
            for (int i = 0; i< listMonThi.Count; i++)
            {
                ans = ans + listMonThi[i].SubjectName;
                if (i < listMonThi.Count - 1) ans = ans + " + ";
            }

            return ans;
        }
    }
}