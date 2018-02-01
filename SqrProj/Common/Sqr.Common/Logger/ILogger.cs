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
        void Info(string message,string system= "default", string module="default",string tag="");

        void Error(string message, string system = "default", string module = "default", string tag = "");

        void Debug(string message, string system = "default", string module = "default", string tag = "");

        void Warn(string message, string system = "default", string module = "default", string tag = "");

    }
}
