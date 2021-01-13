using Consul;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsulCommon
{
    public sealed class  ConsulRegistry
    {

        public static IConfiguration Configuration { get; private set; }

        static ConsulRegistry()
        {
            var fileDir=new PhysicalFileProvider(Directory.GetCurrentDirectory());

            Configuration = new ConfigurationBuilder().SetBasePath(fileDir.Root).AddJsonFile("appsettings.json", false, true).Build();
        }


        /// <summary>
        /// 需要注册的服务地址
        /// </summary>
        public static string ConsulServiceIP
        {
            get
            {
                return Configuration["Consul:ServiceIP"];
            }
        }

        /// <summary>
        /// 需要注册的服务端口
        /// </summary>
        public static int ConsulServicePort
        {
            get
            {
                string str = Configuration["Consul:ServicePort"];
                return int.Parse(str);
            }
        }

        public static string ConsulAddress
        {
            get
            {
                return Configuration["Consul:Address"];
            }
        }

        /// <summary>
        /// 服务注册
        /// </summary>
        public static void ConsulRegister()
        {
            ConsulClient client = new ConsulClient(
                (ConsulClientConfiguration c) =>
                {
                    c.Address = new Uri(Configuration["Consul:Address"]); //Consul服务中心地址
                    c.Datacenter = Configuration["Consul:DataCenter"]; //指定数据中心，如果未提供，则默认为代理的数据中心。
                }
            );
            string checkUrl = Configuration["Consul:CheckUrl"];
            client.Agent.ServiceRegister(new AgentServiceRegistration()
            {
                ID = Guid.NewGuid().ToString(), //服务编号，不可重复
                Name = Configuration["Consul:ServiceName"], //服务名称
                Port = ConsulServicePort, //本程序的端口号
                Address = ConsulServiceIP, //本程序的IP地址
                Check = new AgentServiceCheck()
                {
                    DeregisterCriticalServiceAfter = TimeSpan.FromMilliseconds(1), //服务停止后多久注销
                    Interval = TimeSpan.FromSeconds(5), //服务健康检查间隔
                    Timeout = TimeSpan.FromSeconds(5), //检查超时的时间
                    HTTP = $"http://{ConsulServiceIP}:{ConsulServicePort}{checkUrl}" //检查的地址
                }
            });
        }

        /// <summary>
        /// 获取服务
        /// </summary>
        public static string GetService(string serviceName)
        {
            ConsulClient client = new ConsulClient(c => c.Address = new Uri(ConsulAddress));

            var response = client.Agent.Services().Result.Response;

            //服务名称区分大小写，若要不区分：Equals(serviceName, StringComparison.OrdinalIgnoreCase)
            var services = response.Where(s => s.Value.Service.Equals(serviceName)).Select(s => s.Value);

            //进行取模，随机取得一个服务器，或者使用其它负载均衡策略
            var service = services.ElementAt(Environment.TickCount % services.Count());

            return service.Address + ":" + service.Port;
        }

        /// <summary>
        /// 获取服务（异步方法）
        /// </summary>
        public async Task<string> GetServiceAsync(string serviceName)
        {
            ConsulClient client = new ConsulClient(c => c.Address = new Uri(ConsulAddress));

            var response = (await client.Agent.Services()).Response;

            //服务名称区分大小写，若要不区分：Equals(serviceName, StringComparison.OrdinalIgnoreCase)
            var services = response.Where(s => s.Value.Service.Equals(serviceName)).Select(s => s.Value);

            //进行取模，随机取得一个服务器，或者使用其它负载均衡策略
            var service = services.ElementAt(Environment.TickCount % services.Count());

            return service.Address + ":" + service.Port;
        }

        public static string HttpGetString(string url)
        {
            HttpClient httpClient = new HttpClient();
            string result = httpClient.GetAsync(url)
            .Result.Content.ReadAsStringAsync().Result;
            httpClient.Dispose();
            return result;
        }

        public static T HttpGetObject<T>(string url)
        {
            string result = HttpGetString(url);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(result);
        }
    }
}
