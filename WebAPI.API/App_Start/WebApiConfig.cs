using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebAPI.API.Attributes;
using WebAPI.API.Security;

namespace WebAPI.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Filters.Add(new ApiExceptionAttribute()); // All Control Method.. Error Managment..
            config.MessageHandlers.Add(new APIKeyHandler()); // All Control Method..Auth Managment..

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "servis/{controller}{id}", // api => servis...
            //    routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional } // Gönderip göndermemek önemli değil
            );

            // Return Json formatting..
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
