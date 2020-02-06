using Sqr.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.Common.Logger
{
    public sealed  class LoggerManager
    {
        private static ILogger _logger = null;
        private static object _lockObj = new object();
        public static ILogger CurrentLogger()
        {
            if (_logger == null)
            {
                lock (_lockObj)
                {
                    if (_logger == null)
                    {
                        string _cacheName = ConfigUtil.GetSection("LoggerSetting").Value;
                        if ("Default".Equals(_cacheName, StringComparison.CurrentCultureIgnoreCase))
                            _logger = new DefaultLogger();
                        else
                            _logger = new Log4netLogger();
                    }
                }

            }
            return _logger;

        }
    }
}
