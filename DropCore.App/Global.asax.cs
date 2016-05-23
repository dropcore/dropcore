using DropCore.App.App_Start;
using DropCore.Module;
using DropCore.Module.User;
using MvcCodeRouting;
using System.Web.Mvc;
using System.Web.Routing;

namespace DropCore.App
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
