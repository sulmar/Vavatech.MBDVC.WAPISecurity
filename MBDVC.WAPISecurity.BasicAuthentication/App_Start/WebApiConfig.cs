using MBDVC.WAPISecurity.BasicAuthentication.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MBDVC.WAPISecurity.BasicAuthentication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            // Globalna autentyfikacja i autoryzacja
            config.Filters.Add(new AuthorizeAttribute());
            config.Filters.Add(new RequireHttpsAttribute());
            config.Filters.Add(new BasicAuthenticationFilter());
        }
    }
}
