using MvcCodeRouting;
using System.Web.Mvc;
using System.Web.Routing;

namespace BloodCore.App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ViewEngines.Engines.EnableCodeRouting();
        }
    }
}
