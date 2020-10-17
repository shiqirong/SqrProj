using Sqr.Admin.App.Base;
using Sqr.Common.Logger;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Sqr.Common.Helper;
using Sqr.Common.Utils;
using Sqr.Common;

namespace Sqr.Admin.App.Api
{
    public class ResponseModel<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }

    public abstract class ApiBase<T> where T : class ,new()
    {
        static T _instance = null;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new T();
                return _instance;
            }
        }
        protected static string ApiUrl { get; set; } = "http://localhost:8001/";

        static void Init()
        {
            ApiUrl = ConfigUtil.GetSection("DCConfig").GetSection("BaseUrl").Value;
        }

        public async virtual Task<ResultMo<T>> Post<T>(string url, object data)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var response = await client.PostAsync(url, new StringContent(data.ToJson(),Encoding.UTF8,"application/json"));
                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync();
                    return (str).ToObject<ResultMo<T>>();
                }
                LoggerManager.CurrentLogger().Warn($"远程接口调用返回异常(post)。{(new { url, input = data, output = response }).ToJson()}");
                return ResultMo<T>.Error("远程接口调用返回异常");
            }
            catch (Exception ex)
            {
                LoggerManager.CurrentLogger().Error($"接口调用异常(post)。{(new { url, input = data, exception = ex }).ToJson()}");
                return ResultMo<T>.Error("接口调用异常");
            }
        }

        public async virtual Task<ResultMo<T>> Get<T>(string url, object data)
        {
            if (data != null)
            {
                var strParams = FormatUrlParams(data);
                if (url.Contains("?"))
                    url += "&" + strParams;
                else
                    url += "?" + strParams;
            }
            HttpClient client = new HttpClient();
            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return result.ToObject<ResultMo<T>>();
                }
                LoggerManager.CurrentLogger().Warn($"远程接口调用返回异常(get)。{(new { url, input = data, output = response }).ToJson()}");
                return ResultMo<T>.Error("远程接口调用返回异常");
            }
            catch (Exception ex)
            {
                LoggerManager.CurrentLogger().Error($"接口调用异常(get)。{(new { url, input = data, exception = ex }).ToJson()}");
                return ResultMo<T>.Error("接口调用异常");
            }
        }

        string FormatUrlParams(object data)
        {
            var strParams = string.Empty;
            if (data != null)
            {
                var t = data.GetType();
                var properties = t.GetProperties();
                strParams = "1=1";
                foreach (var p in properties)
                {
                    strParams += "&"+p.Name;
                    strParams += "=" + p.GetValue(data)?.ToString();
                }
            }
            return strParams;
        }
    }


}
