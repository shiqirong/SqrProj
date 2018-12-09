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
