using Sqr.Admin.App.Base;
using Sqr.Common.Logger;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Sqr.Common.Helper;

namespace Sqr.Admin.App.Api
{
    public class ResponseModel<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }

    public abstract class ApiBase
    {
        public string ApiUrl { get; set; } = "http://localhost:9000/";

        public async virtual Task<T> Post<T>(string url, object data)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var response = await client.PostAsync(url, new StringContent(data.ToJson(),Encoding.UTF8,"application/json"));
                if (response.IsSuccessStatusCode)
                {
                    return (await response.Content.ReadAsStringAsync()).ToObject<ResponseModel<T>>().Data;
                }
                LoggerManager.Warn($"调用接口返回失败(post)。{(new { url, input = data, output = response }).ToJson()}", SystemInfo.SystemId, "Api");
                return default(T);
            }
            catch (Exception ex)
            {
                LoggerManager.Error($"调用接口返回失败(post)。{(new { url, input = data, exception = ex }).ToJson()}", SystemInfo.SystemId, "Api");
                return default(T);
            }
        }

        public async virtual Task<T> Get<T>(string url, object data)
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
                    return result.ToObject<ResponseModel<T>>().Data;
                }
                LoggerManager.Warn($"调用接口返回失败(get)。{(new { url, input = data, output = response }).ToJson()}", SystemInfo.SystemId, "Api");
                return default(T);
            }
            catch (Exception ex)
            {
                LoggerManager.Error($"调用接口返回失败(get)。{(new { url, input = data, exception = ex }).ToJson()}", SystemInfo.SystemId, "Api");
                return default(T);
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
