using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SSA_NMCT2_DeschrijverPieterjan
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
