using log4net.Config;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.Common.Logger
{
    public class Log4netLogger : ILogger
    {
        static log4net.ILog log = null;
        static Log4netLogger()
        {
            ILoggerRepository repository = log4net.LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
            log = log4net.LogManager.GetLogger(repository.Name, "NETCorelog4net");
        }

        public void Debug(string message,  string logKey = "")
        {
            log.Debug($"time:{DateTime.Now.ToLongTimeString()},longKey:{logKey},message:{message}");
        }

        public void Error(string message, string logKey = "")
        {
            log.Error($"time:{DateTime.Now.ToLongTimeString()},longKey:{logKey},message:{message}");
        }

        public void Info(string message, string logKey = "")
        {
            log.Info($"time:{DateTime.Now.ToLongTimeString()},longKey:{logKey},message:{message}");
        }

        public void Warn(string message, string logKey = "")
        {
            log.Warn($"time:{DateTime.Now.ToLongTimeString()},longKey:{logKey},message:{message}");
        }
    }
}
