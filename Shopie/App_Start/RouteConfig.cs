﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shopie
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "Login",
              url: "dang-nhap",
              defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional },
              namespaces: new[] { "Shopie.Controllers" }
          );
            routes.MapRoute(
               name: "Register",
               url: "dang-ky",
               defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
               namespaces: new[] { "Shopie.Controllers" }
           );

                
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "Shopie.Controllers" }
           );
        }
    }
}
