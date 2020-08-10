using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Runtime.CompilerServices;
using System.IO;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace EXON.MONITOR.Common
{
    public class Log
    {
        private static Log instance;
        public   static Log Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Log();
                }
                return instance;
            }
        }
        private Log() { }
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private log4net.ILog GetLogger([CallerFilePath]string filename = "")
        {
            return log4net.LogManager.GetLogger(filename);
        }
        public void WriteLog(string type, string function, string message)
        {
            log4net.GlobalContext.Properties["function"] = function;
            switch (type)
            {
                case "INFO":
                    log.Info(message);
                    break;
                case "ERROR":
                    log.Error(message);
                    break;
                case "WARN":
                    log.Warn(message);
                    break;
                case "FATAL":
                    log.Fatal(message);
                    break;
            }
        }
        public void WriteErrorLog(string type, string message,
                        [CallerFilePath] string fileName = "",
                        [CallerMemberName] string function = "",
                        [CallerLineNumber] int line = 0)
        {
            log4net.GlobalContext.Properties["function"] = string.Format("{0} {1}", Path.GetFileName(fileName), function);
            switch (type)
            {
                case "INFO":
                    log.Error(string.Format("[{0}]: {1}", line, message));
                    break;
                case "ERROR":
                    log.Info(string.Format("[{0}]: {1}", line, message));
                    break;
                case "WARN":
                    log.Warn(string.Format("[{0}]: {1}", line, message));
                    break;
                case "FATAL":
                    log.Fatal(string.Format("[{0}]: {1}", line, message));
                    break;
            }
        }
    }
}
