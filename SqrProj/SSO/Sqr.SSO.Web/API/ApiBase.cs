using Sqr.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sqr.SSO.Web.API
{
    public class ApiBase
    {

        protected async Task<ResultMo<T>> Get<T>(string url)
        {
            return await SendRequest<T>(url,"GET");
        }

        protected async Task<ResultMo<T>> Post<T>(string url,object body)
        {
            return await SendRequest<T>(url, "POST", body);
        }

        protected async Task<ResultMo<T>> Put<T>(string url, object body)
        {
            return await SendRequest<T>(url, "PUT", body);
        }

        protected async Task<ResultMo<T>> Delete<T>(string url, object body)
        {
            return await SendRequest<T>(url, "DELETE", body);
        }

        private static async Task<ResultMo<T>> SendRequest<T>(string url,string method,object body=null)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = method;
            AddJsonBody(request,body);
            HttpWebResponse response = null;
            try
            {
                response = await request.GetResponseAsync() as HttpWebResponse;
            }
            catch(WebException wExp)
            {
                return new ResultMo<T>(ResultCode.IntenetEror,wExp.Message);
            }
            if(response.StatusCode!= HttpStatusCode.OK)
            {
                return new ResultMo<T>(ResultCode.RequestEror,$"请求失败，StatusCode：{response.StatusCode}");
            }
            var responseText = string.Empty;
            using (var stream = response.GetResponseStream())
            using (var streamReader = new StreamReader(stream))
            {
                responseText=streamReader.ReadToEnd();
            }
            try
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ResultMo<T>>(responseText);
            }
            catch(Exception ex)
            {
                return new ResultMo<T>(ResultCode.JsonTransferError,$"JSON转换失败。{ex.Message}");
            }

        }

        private static void AddJsonBody(HttpWebRequest request,object body)
        {
            if (body == null)
                return;
            request.ContentType = "application/json";
            byte[] data = System.Text.Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(body));
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
        }
    }
}
