using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;

namespace DropCore.Module
{
    public class ModuleManager
    {
        public List<IModule> Modules { get; private set; }

        public ModuleManager()
        {
            Modules = new List<IModule>();
        }

        public void Add<TModule>()
            where TModule : IModule, new()
        {
            if (Modules.Any(m => m.GetType() == typeof(TModule)))
                return; // TODO: Throw exception?

            Modules.Add(new TModule());
        }

        public void RegisterRoutes(RouteCollection routes)
        {
            foreach (var module in Modules)
                module.RegisterRoutes(routes);
        }

        public void RegisterTypes(IUnityContainer container)
        {
            foreach (var module in Modules)
                module.RegisterTypes(container);
        }
    }
}
