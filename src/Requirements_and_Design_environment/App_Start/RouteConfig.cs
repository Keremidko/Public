using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Requirements_and_Design_environment
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Template",
                url: "Template/Get/{name}",
                defaults: new { action = "Get", controller = "Template", name = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Modal",
                url: "Template/Modal/{name}",
                defaults: new { action = "Modal", controller = "Template", name = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { action = "Index", controller = "Home", id = UrlParameter.Optional }
            );
        }
    }
}

