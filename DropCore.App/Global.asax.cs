using DropCore.App.App_Start;
using MvcCodeRouting;
using System.Web;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;

[assembly: PreApplicationStartMethod(typeof(DropCore.App.MvcApplication), "Initialize")]

namespace DropCore.App
{
    public class MvcApplication : global::System.Web.HttpApplication
    {
        public static void Initialize()
        {
            DropCoreProvider.Initialize(UnityConfig.GetConfiguredContainer(),
                HostingEnvironment.MapPath("~/"),
                "DropCore.json");
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DropCoreProvider.Register(RouteTable.Routes);
            ControllerBuilder.Current.EnableCodeRouting();
            ViewEngines.Engines.EnableCodeRouting();
        }
    }
}
