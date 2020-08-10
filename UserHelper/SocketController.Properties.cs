using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UserHelper
{
    public partial class SocketController
    {
        public IPEndPoint IPERemote
        {
            get
            {
                try
                {
                    IPEndPoint remote = (IPEndPoint)Sock.RemoteEndPoint;
                    return remote;
                }
                catch
                {
                    return null;
                }
            }
        }
        public int? Port
        {
            get
            {
                if (IPERemote == null)
                    return null;
                return IPERemote.Port;
            }
        }
        public string IpAddress
        {
            get
            {
                return IPERemote == null ? null : IPERemote.Address.ToString();
            }
        }
    }
}
