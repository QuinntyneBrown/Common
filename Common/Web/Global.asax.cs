using System;
using System.Web.Http;
using Common.StartUp;

namespace Common.Web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiStartUp.Configure);
        }
    }
}