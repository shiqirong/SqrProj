using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.Common.Logger
{
    public static  class LoggerManager
    {
        static private ILogger logger = new Log4netLogger();
        public static void Debug(string message, string system = "default", string module = "default", string tag = "")
        {
            logger.Debug(message,system,module,tag);
        }

        public static void Error(string message, string system = "default", string module = "default", string tag = "")
        {
            logger.Error(message, system, module, tag);
        }

        public static void Info(string message, string system = "default", string module = "default", string tag = "")
        {
            logger.Info(message, system, module, tag);
        }

        public static void Warn(string message, string system = "default", string module = "default", string tag = "")
        {
            logger.Warn(message, system, module, tag);
        }
    }
}
