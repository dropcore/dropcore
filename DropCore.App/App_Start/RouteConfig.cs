using MvcCodeRouting;
using System.Web.Mvc;
using System.Web.Routing;

namespace DropCore.App
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.MapCodeRoutes(typeof(Controllers.HomeController));
        }
    }
}
