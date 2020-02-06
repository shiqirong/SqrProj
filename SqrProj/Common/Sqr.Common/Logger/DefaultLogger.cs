using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.Common.Logger
{
    /// <summary>
    /// 系统默认写日志模块
    /// </summary>
    public class DefaultLogger : ILogger
    {
        private readonly string _logBaseDirPath = null;
        private const string _logFormat = "{0:T}  LogKey:{1}   Detail:{2}\r\n";

        /// <summary>
        /// 构造函数
        /// </summary>
        public DefaultLogger()
        {
            // todo  测试地址是否ok

            _logBaseDirPath = Path.Combine(AppContext.BaseDirectory, "log");
            if (!Directory.Exists(_logBaseDirPath))
                Directory.CreateDirectory(_logBaseDirPath);
        }

        private string GetLogFilePath(string module, string level)
        {
            var dirPath = Path.Combine(_logBaseDirPath, string.Concat(module, "_", level), DateTime.Now.ToString("yyMM"));//string.Format(@"{0}\{1}\{2}\",_logBaseDirPath, module, level);

            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);

            return Path.Combine(dirPath, DateTime.Now.ToString("yyyyMMddHH") + ".txt");
        }

        private static readonly object obj = new object();

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="info"></param>
        public void WriteLog(string message, string logKey, string level)
        {
            Task.Run((Action)(() =>
            {
                lock (obj)
                {
                    var filePath = GetLogFilePath("default", level);

                    using (StreamWriter sw = new StreamWriter(new FileStream((string)filePath, FileMode.Append, FileAccess.Write), Encoding.UTF8))
                    {
                        sw.WriteLine(_logFormat,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                            logKey,
                            message);
                    }
                }
            }));
        }

        public void Debug(string message, string logKey = "")
        {
            WriteLog(message, logKey, "Debug");
        }

        public void Error(string message, string logKey = "")
        {
            WriteLog(message, logKey, "Error");
        }

        public void Info(string message, string logKey = "")
        {
            WriteLog(message, logKey, "Info");
        }

        public void Warn(string message, string logKey = "")
        {
            WriteLog(message, logKey, "Warn");
        }

    }
}
