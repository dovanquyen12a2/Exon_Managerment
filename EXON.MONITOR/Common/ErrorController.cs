using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXON.MONITOR.Common
{
   public class ErrorController
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public ErrorController()
        {
            this.ErrorCode = -1;
            this.Message = string.Empty;
        }
        public ErrorController(int errorCode, string message)
        {
            this.ErrorCode = errorCode;
            this.Message = message;
        }
        
    }
}
