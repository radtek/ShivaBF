using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SHF
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "AjaxRoute",
               url: "{method}/{controller}/{action}/{id}",
               defaults: new { method = "Get", controller = "Home", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "UIRoute",
              url: "{area}/{method}/{controller}/{action}/{id}",
              defaults: new {area="Settings", method = "Get", controller = "Home", action = "Index", id = UrlParameter.Optional }
          );
        }
    }
}
