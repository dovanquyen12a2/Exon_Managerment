using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXON.GradedEssay
{
   public partial class Common
    {
        public static int ConvertDateTimeToUnix(DateTime dt)
        {
            return Convert.ToInt32((dt.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0))).TotalSeconds);
        }
        public static DateTime ConvertUnixToDateTime(int unix)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return dt.AddSeconds(unix);
        }

        public enum StatusDivisionShift { Status_Zero, STATUS_INIT, STATUS_GENTEST, STATUS_ATTENDANCE, STATUS_VERITY, STATUS_DECRYPT, STATUS_DIVISIONTEST, STATUS_STARTTEST, STATUS_COMPLETE }
    }
}
