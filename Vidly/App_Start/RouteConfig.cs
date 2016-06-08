using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //enable to use attributes in the acction to perform custom routes
            //routes.MapMvcAttributeRoutes();

            //the specific routes go first that the general routes
            //routes.MapRoute(
            //    //name of the route
            //    "MoviesByReleaseDate",
            //    //route pattern
            //    "movies/released/{year}/{month}",
            //    new { controller = "Movies", action= "ByReleaseDate"},
            //    //regular expression to validate the parameters
            //    new { year = @"\d{4}", month = @"\d{2}"}
            //    );


            //general route
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
