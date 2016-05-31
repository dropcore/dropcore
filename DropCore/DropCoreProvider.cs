using DropCore.Configuration;
using DropCore.IO;
using DropCore.Module;
using DropCore.System;
using DropCore.System.Wrappers;
using Microsoft.Practices.Unity;
using System.IO;
using System.Web.Routing;

#pragma warning disable CC0022 // Should dispose object

namespace DropCore
{
    public static class DropCoreProvider
    {
        static IUnityContainer Container { get; set; }
        static AppConfiguration Configuration { get; set; }
        static ModuleManager ModuleManager { get; set; }

        public static void Initialize(IUnityContainer container,
            string applicationPath,
            string configurationFilePath)
        {
            Container = container;

            RegisterTypes();
            LoadConfiguration(applicationPath, configurationFilePath);
            InitializeModules();
        }

        public static void Register(RouteCollection routes)
        {
            ModuleManager.Register(routes);
        }

        static void RegisterTypes()
        {
            // Configuration
            Container.RegisterType<AppConfiguration>(new InjectionFactory(c => Configuration));

            // Module
            Container.RegisterType<IModuleLoader, ModuleLoaderImpl>();
            Container.RegisterType<IModuleTypeManager, ModuleTypeManagerImpl>();
            Container.RegisterType<ModuleManager>(new ContainerControlledLifetimeManager());

            // System
            Container.RegisterType<IAssemblyLoader, AssemblyLoaderImpl>();
            Container.RegisterType<IFileSystem, FileSystemImpl>();
            Container.RegisterType<IBuildManager, BuildManagerImpl>();
            Container.RegisterType<IAssemblyProbingService, AssemblyProbingServiceImpl>();
        }

        static void LoadConfiguration(string applicationPath, string configurationFilePath)
        {
            Configuration = new AppConfiguration
            {
                ApplicationPath = applicationPath
            };

            using (var reader = new JsonFileReader(Path.Combine(applicationPath, configurationFilePath)))
                Configuration.FromJson(reader.Read());
        }

        static void InitializeModules()
        {
            ModuleManager = Container.Resolve<ModuleManager>();
            ModuleManager.Initialize();
        }
    }
}

#pragma warning restore CC0022 // Should dispose object
