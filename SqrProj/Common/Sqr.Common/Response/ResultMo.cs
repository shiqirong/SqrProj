using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.Common
{
    public class ResultMo
    {
        public ResultMo() { }

        public ResultMo(int code =ResultCode.Success, string message=null)
        {
            this.Code = code;
            this.Message = message;
        }

        public int Code { get; set; }

        public string Message { get; set; }

        [JsonIgnore]
        public bool IsSuccess
        {
            get { return Code == ResultCode.Success; }
        }
    }

    public class ResultMo<T> : ResultMo
    {
        public ResultMo(){}
        public ResultMo(int code = ResultCode.Success, string message = null,T data = default(T)):base(code,message)
        {
            Data = data;
        }
        public ResultMo(T data = default(T)) : base(ResultCode.Success,string.Empty)
        {
            Data = data;
        }


        public T Data { get; set; }

        public T NotNullData()
        {
            if(!IsSuccess)
            {
                if (!string.IsNullOrWhiteSpace(Message))
                    throw new Exception(Message);
                throw new Exception("数据为空，但没有具体错误信息。");
            }
            if (Data == null)
                throw new Exception("数据不存在。");
            return Data;
        }

        public static ResultMo<T> Error (string message,int code=ResultCode.Error)
        {
            return new ResultMo<T>(code, message);
        }
    }

    public sealed class ResultCode
    {
        public const int Success = 10000;
        public const int Error = 11000;
        public const int IntenetEror = 11001;
        public const int RequestEror = 11002;

        //参数检查
        public const int ParamsIncrect = 12000;
        public const int DataNotExists=13000;
        public const int PasswordIncrect=130001;

        public const int JsonTransferError = 140000;

        public const int NotLogin = 10110;
    }
}
