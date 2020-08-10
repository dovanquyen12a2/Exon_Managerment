using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EXON.SubModel;
namespace EXON.MONITOR.Common
{
    public static class DatetimeConvert
    {
        public static string HandleCountDown(int timer)
        {
            int h = timer / 3600;
            int m = timer / 60;
            int s = timer - (h * 3600 + m * 60);
            string stringTime = string.Empty;
            if (h > 0)
            {
                stringTime = h < 10 ? "0" + h.ToString() : h.ToString();
                stringTime += ":";
            }
            stringTime += m < 10 ? "0" + m.ToString() : m.ToString();
            stringTime += ":";
            stringTime += s < 10 ? "0" + s.ToString() : s.ToString();

            return stringTime;

        }
        public static int ConvertDateTimeToUnix(DateTime dt)
        {
            return Convert.ToInt32((dt.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0))).TotalSeconds);
        }
        public static DateTime ConvertUnixToDateTime(int unix)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return dt.AddSeconds(unix);
        }
        public static DateTime GetDateTimeServer()
        {
            EXON.SubModel.Models.MTAQuizDbContext db = new EXON.SubModel.Models.MTAQuizDbContext();
            return db.Database.SqlQuery<DateTime>(@"SELECT GetDate()").First();
        }
    }
}
