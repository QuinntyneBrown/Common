﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Common.OAuth;
using Common.StartUp;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using Unity.WebApi;

namespace Common.Web
{
    public class ApiConfiguration
    {
        public static void Install(HttpConfiguration config, IAppBuilder app)
        {
            config.SuppressHostPrincipal();
            
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            app.UseJwtBearerAuthentication(new JwtOptions());
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();

            var jSettings = new JsonSerializerSettings();

            jSettings.Formatting = Formatting.Indented;
            
            jSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            
            config.Formatters.JsonFormatter.SerializerSettings = jSettings;

            

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
        }
    }
}
