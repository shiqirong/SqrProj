using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sqr.SSO.Common
{
    public class ResponseResult<T>
    {
        public ResponseResult(int code=1,T data=default(T),string msg="")
        {
            this.Code = code;
            this.Data = data;
            this.Msg = msg;
        }
        public int Code { get; set; }

        public string Msg { get; set; }

        public T Data { get; set; }

        public object Tag { get; set; }
    }
}
