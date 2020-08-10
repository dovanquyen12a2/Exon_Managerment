using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserHelper
{
    public class RoomTestTranformation
    {
        public int RoomTestID { get; set; }
        public int status { get; set; }
        public RoomTestTranformation() { }
        public RoomTestTranformation(int _RoomTestID, int _status)
        {
            RoomTestID = _RoomTestID;
            status = _status;
        }
    }
}
