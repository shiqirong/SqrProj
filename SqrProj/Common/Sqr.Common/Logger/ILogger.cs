using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.Common.Logger
{
    public enum SystemCode
    {
        DataCenter=1,
    }

    public interface  ILogger
    {
        void Info(string message,string logKey="");

        void Error(string message, string logKey = "");

        void Debug(string message, string logKey = "");

        void Warn(string message, string logKey = "");

    }
}
