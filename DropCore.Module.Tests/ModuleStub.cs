using Microsoft.Practices.Unity;
using System.Web.Routing;

namespace DropCore.Module.Tests
{
    public class ModuleStub : IModule
    {
        public bool Routed { get; set; }
        public bool Typed { get; set; }

        public void RegisterRoutes(RouteCollection routes)
        {
            Routed = true;
        }

        public void RegisterTypes(IUnityContainer container)
        {
            Typed = true;
        }
    }
}
