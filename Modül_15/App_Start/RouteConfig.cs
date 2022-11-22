using Modül_15.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Modül_15
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //Kendi tanımlamış olduğumuz httphandler için route tanımlamasını gerçekleştirdik.
            //Buradan sonra HomeController içerisinde controller oluşturmamız gerekiyor.
            routes.Add(new Route("Home/CustomHttp",new CustomRouteHandler()));
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
