using System;
using System.Collections.Generic;
using System.Text;

namespace Sqr.Common.Exceptions
{
    public class DataNullException : Exception
    {
        public DataNullException(string message) : base(message)
        {
        }
    }
}
