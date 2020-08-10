using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UserHelper
{
    public class ClientSide : IDisposable
    {
        public bool Status { get; set; }
        string IpAddress { get; set; }
        int Port { get; set; }
        object sync = new object();
        public IPEndPoint IPEP
        {
            get
            {
                return new IPEndPoint(IPAddress.Parse(IpAddress), Port);
            }
        }
        public SocketController Remote;
        public ClientSide(int Port = 9050, string IpAddress = "127.0.0.1")
        {
            this.Port = Port;
            this.IpAddress = IpAddress;
            Remote = new SocketController();
        }
        public bool Connect(int TryNum = 1)
        {
            TryNum = TryNum == 0 ? 1 : TryNum;
            while (TryNum != 0)
            {
                var result = Remote.Connect(IPEP);
                if (result == true)
                    return true;
                if (TryNum > 0)
                {
                    TryNum--;
                }
            }
            return false;
        }
        public void Dispose()
        {
            Remote.Dispose();
        }
    }
}
