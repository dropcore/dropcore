using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Web.Routing;

namespace DropCore.Module
{
    public class ModuleManager
    {
        public List<ModuleContainer> Modules { get; private set; }

        IUnityContainer Container { get; set; }
        IModuleLoader Loader { get; set; }
        IModuleTypeManager TypeManager { get; set; }

        public ModuleManager(IUnityContainer container, IModuleLoader containerLoader, IModuleTypeManager typeManager)
        {
            Container = container;
            Loader = containerLoader;
            TypeManager = typeManager;

            Modules = new List<ModuleContainer>();
        }

        public void Initialize()
        {
            Modules.AddRange(Loader.Load());

            foreach (var module in Modules)
            {
                var entryPointType = TypeManager.GetEntryPointType(module.Assembly);
                if (entryPointType == null)
                    throw new InvalidOperationException("Module was loaded that does not have an entry point.");

                module.Instance = Container.Resolve(entryPointType) as IModule;
            }
        }

        public void Register(RouteCollection routes)
        {
            foreach (var module in Modules)
            {
                if (module.Instance == null)
                    throw new InvalidOperationException("Attempting to register a module that does not have an instance.");

                module.Instance.RegisterTypes(Container);
                module.Instance.RegisterRoutes(routes);
            }
        }
    }
}
