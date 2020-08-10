using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace UserHelper
{
    public static class Ultis
    {
        public static String FromObjectToJSON(UserTransformation oj)
        {
            return new JavaScriptSerializer().Serialize(oj);
        }
        public static UserTransformation FromJSONToObject(string json)
        {
            return new JavaScriptSerializer().Deserialize<UserTransformation>(json);
        }
        public static String FromObjectToJSON2(RoomTestTranformation oj)
        {
            return new JavaScriptSerializer().Serialize(oj);
        }
        public static RoomTestTranformation FromJSONToObject2(string json)
        {
            return new JavaScriptSerializer().Deserialize<RoomTestTranformation>(json);
        }
        public static void GetCurrentIP(out string myIP)
        {
            myIP = "";
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress address in host.AddressList)
            {
                if (address.AddressFamily.ToString() == "InterNetwork")
                {
                    myIP = address.ToString();
                }
            }
        }

    }
}
