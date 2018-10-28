using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.Common
{
    public class ResultMo
    {
        public ResultMo(string code=null, string message=null)
        {
            this.Code = code;
            this.Message = message;
        }

        public string Code { get; set; }

        public string Message { get; set; }
    }

    public class ResultMo<T> : ResultMo
    {
        public ResultMo(string code = null, string message = null,T data = default(T)):base(code,message)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
