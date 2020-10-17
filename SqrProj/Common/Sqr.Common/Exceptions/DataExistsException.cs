using System;
using System.Collections.Generic;
using System.Text;

namespace Sqr.Common.Exceptions
{
    public class DataExistsException : Exception
    {
        public DataExistsException(string message) : base(message)
        {
        }
    }
}
