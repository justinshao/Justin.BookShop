using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Justin.BookShop.Admin
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "admin/{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                namespaces: new string[] { "Justin.BookShop.Controllers.Admin" }
            );
        }
    }
}