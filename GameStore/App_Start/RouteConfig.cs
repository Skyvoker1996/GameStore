using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GameStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null, "",
               new
               {
                   controller = "Home",
                   action = "Home"
               }
               );
            routes.MapRoute(null,
                "{platform}",
                new
                {
                    controller = "Home",
                    action = "Index"
                    ,
                    category = (string)null
                }
            );

            routes.MapRoute(null, "Cart/{action}",
                new { controller = "Cart" },
                new { });

            routes.MapRoute(null, "Admin/{action}",
                new { controller = "Admin" },
                new { });

            routes.MapRoute(null, "Account/{action}",
                new { controller = "Account" },
                new { });

            routes.MapRoute(null, "Home/GetImage",
              new { controller = "Home", action = "GetImage" });


            routes.MapRoute(null,
                 "{platform}/{category}",
                 new
                 {
                     controller = "Home",
                     action = "Index"
                 },
                 new { }
             );

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
