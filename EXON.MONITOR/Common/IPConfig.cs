using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXON.MONITOR.Common
{
    public class IPConfig
    {
        public string IP { get; set; }
        public int Port { get; set; }
        public IPConfig() { }
        public IPConfig(string ip, int port)
        {
            this.IP = ip;
            this.Port = port;
        }
    }
}
