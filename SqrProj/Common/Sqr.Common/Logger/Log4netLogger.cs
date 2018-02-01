using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.Common.Logger
{
    public class Log4netLogger : ILogger
    {
        log4net.ILog log = log4net.LogManager.GetLogger("RollingLogFileAppender");

        public void Debug(string message, string system = "default", string module = "default", string tag = "")
        {
            log.Debug($"system:{system},module:{module},tag:{tag},category:debug,mssage:{message}");
        }

        public void Error(string message, string system = "default", string module = "default", string tag = "")
        {
            log.Error($"system:{system},module:{module},tag:{tag},category:error,mssage:{message}");
        }

        public void Info(string message, string system = "default", string module = "default", string tag = "")
        {
            log.Info($"system:{system},module:{module},tag:{tag},category:info,mssage:{message}");
        }

        public void Warn(string message, string system = "default", string module = "default", string tag = "")
        {
            log.Warn($"system:{system},module:{module},tag:{tag},category:warn,mssage:{message}");
        }
    }
}
