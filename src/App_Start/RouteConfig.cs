﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Kendo.Mvc.Examples
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            // Imprive SEO by stopping duplicate URL's due to case or trailing slashes.
            routes.AppendTrailingSlash = true;
            routes.LowercaseUrls = true;


            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.Add("Default", new Route(
                "{controller}/{action}",
                new RouteValueDictionary { { "controller", "Home" }, { "action", "Index" } },
                new HyphenatedRouteHandler()
            ));

           

        }
    }
}

