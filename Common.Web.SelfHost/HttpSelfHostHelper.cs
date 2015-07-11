using System;
using System.Web.Http.SelfHost;
using Common.StartUp;
using Common.Web.Contracts;

namespace Common.Web.SelfHost
{
    public class HttpSelfHostHelper
    {
        public static void Host(IWebApiConfiguration webApiConfiguration = null, string hostUri = "http://localhost:8888/", string apiName = "Api")
        {
            var config = new HttpSelfHostConfiguration(hostUri);

            if (webApiConfiguration == null)
            {
                WebApiStartUp.Configure(config);
            }
            else
            {
                webApiConfiguration.Configure(config);    
            }
            
            var host = new HttpSelfHostServer(config);
            host.OpenAsync().Wait();
            Console.WriteLine("{0} hosted at: {1}", apiName, config.BaseAddress);
            Console.ReadLine();
        }
    }
}
