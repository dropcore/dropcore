using BloodCore.App.App_Start;
using BloodCore.Module;
using BloodCore.Module.User;
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

            var moduleManager = new ModuleManager();
            moduleManager.Add<UserModule>();
            moduleManager.RegisterRoutes(RouteTable.Routes);
            moduleManager.RegisterTypes(UnityConfig.GetConfiguredContainer());

            ViewEngines.Engines.EnableCodeRouting();
        }
    }
}
