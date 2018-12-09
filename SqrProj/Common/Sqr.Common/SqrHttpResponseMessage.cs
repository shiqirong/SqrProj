using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.Common
{

    public class SqrResponse
    {
        public SqrStatusCode StatusCode { get; set; }

        public string Message { get; set; }

        public SqrResponse(SqrStatusCode statusCode = SqrStatusCode.Ok, string msg = "")
        {
            StatusCode = statusCode;
            Message = msg;
        }

        public static SqrResponse Ok()
        {
            return new SqrResponse(SqrStatusCode.Ok, string.Empty);
        }

        public static SqrResponse  Fail(string msg = "")
        {
            return new SqrResponse (SqrStatusCode.Fail );
        }
    }

    public class SqrResponse<T> 
    {
        public SqrStatusCode StatusCode { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }

        public SqrResponse(SqrStatusCode statusCode= SqrStatusCode.Ok, string msg="",T data=default(T))
        {
            StatusCode = statusCode;
            Message = msg;
            Data= data;
        }

        public static SqrResponse<T> Ok(T data = default(T))
        {
            return new SqrResponse<T>(SqrStatusCode.Ok,string.Empty,data);
        }

        public static SqrResponse<T> Fail(string msg="",T data = default(T))
        {
            return new SqrResponse<T>(SqrStatusCode.Fail, string.Empty, data);
        }
    }

    public enum SqrStatusCode
    {
        Ok=200,
        Fail=300

    }
}
