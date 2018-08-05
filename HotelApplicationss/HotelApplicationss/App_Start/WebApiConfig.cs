using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace HotelApplicationss
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
                routeTemplate: "api/{controller}/{id}/{add}/{latitude}/{longitude}/{radius}",
                defaults: new {add = RouteParameter.Optional, id = RouteParameter.Optional, latitude = RouteParameter.Optional, longitude = RouteParameter.Optional, radius = RouteParameter.Optional }
            );

        }
    }
}
//,rad = RouteParameter.Optional