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

        public ResultMo(int code =ResultCode.Success, string message="",bool isError=false)
        {
            this.Code = code;
            this.Message = message;
            this.IsError = isError;
        }

        public bool IsError { get; set; }

        public int Code { get; set; }

        public string Message { get; set; }

        [JsonIgnore]
        public bool IsSuccess
        {
            get { return Code == ResultCode.Success; }
        }

        

        public static ResultMo Success()
        {
            return new ResultMo();
        }

        public static ResultMo Fail(string message="操作失败",int code=ResultCode.Fail)
        {
            return new ResultMo(code,message);
        }

        public static ResultMo Error(string message="操作异常",int code = ResultCode.Error)
        {
            return new ResultMo(code, message);
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

        public static new ResultMo<T> Success(T data)
        {
            return new ResultMo<T>(data);
        }

        public static new ResultMo<T> Fail(string message = "操作失败", int code = ResultCode.Fail)
        {
            return new ResultMo<T>(code, message);
        }

        public static new ResultMo<T> Error(string message = "操作异常", int code = ResultCode.Error)
        {
            return new ResultMo<T>(code, message);
        }

        [JsonIgnore]
        public bool IsHasData
        {
            get { return Code == ResultCode.Success && Data!=null; }
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

        
    }

    public sealed class ResultCode
    {
        public const int Success = 0;
        public const int Fail = 10000;
        public const int Error = 11000;
        public const int IntenetEror = 11001;
        public const int RequestEror = 11002;

        //参数检查
        public const int ParamsIncrect = 12000;
        public const int DataNotExists=13000;
        public const int DataExists = 13001;
        public const int PasswordIncrect=130002;

        public const int JsonTransferError = 140000;

        public const int NotLogin = 10110;
    }
}
