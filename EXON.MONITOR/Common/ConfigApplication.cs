
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXON.MONITOR.Common
{
   public class ConfigApplication
    {
        public string Password { get; set; }

        public IPConfig Database { get; set; }
        public string DBName { get; set; }
        public string UsernameDB { get; set; }
        public string PasswordDB { get; set; }
        public ConfigApplication() { }
    }
}
