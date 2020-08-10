using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserHelper
{
    public class UserTransformation
    {
        public int UserID { get; set; }
        public int ContestShiftID { get; set; }
        public string UserCode { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
        public string ComputerName { get; set; }

        public UserTransformation() { }
        public UserTransformation(int userID, string userCode, string content, string computerName, int status)
        {
            this.UserID = userID;
            this.UserCode = userCode;
            this.Content = content;
            this.Status = status;
            this.ComputerName = computerName;
        }
    }
}
