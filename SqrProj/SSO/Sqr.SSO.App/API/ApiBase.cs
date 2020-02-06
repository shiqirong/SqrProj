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

        protected async Task<T> Get<T>(string url)
        {
            return await SendRequest<T>(url,"GET");
        }

        protected async Task<T> Post<T>(string url,object body)
        {
            return await SendRequest<T>(url, "POST", body);
        }

        protected async Task<T> Put<T>(string url, object body)
        {
            return await SendRequest<T>(url, "PUT", body);
        }

        protected async Task<T> Delete<T>(string url, object body)
        {
            return await SendRequest<T>(url, "DELETE", body);
        }

        private static async Task<T> SendRequest<T>(string url,string method,object body=null)
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
                return default(T);
            }
            if(response.StatusCode!= HttpStatusCode.OK)
            {
                return default(T);
            }
            var responseText = string.Empty;
            using (var stream = response.GetResponseStream())
            using (var streamReader = new StreamReader(stream))
            {
                responseText=streamReader.ReadToEnd();
            }
            try
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseText);
            }
            catch(Exception ex)
            {
                return default(T);
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
