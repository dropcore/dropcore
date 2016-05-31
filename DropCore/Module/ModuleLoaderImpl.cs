using DropCore.Configuration;
using DropCore.System;
using DropCore.System.Wrappers;
using System.IO;
using System.Linq;

namespace DropCore.Module
{
    public class ModuleLoaderImpl : IModuleLoader
    {
        AppConfiguration Configuration { get; set; }
        IAssemblyLoader AssemblyLoader { get; set; }
        IAssemblyProbingService AssemblyProbingService { get; set; }

        string ApplicationPath => Configuration.ApplicationPath;
        string TempDir => Path.Combine(ApplicationPath, "bin", ".ModuleTemp");

        public ModuleLoaderImpl(AppConfiguration configuration,
            IAssemblyLoader assemblyLoader,
            IAssemblyProbingService assemblyProbingService)
        {
            Configuration = configuration;
            AssemblyLoader = assemblyLoader;
            AssemblyProbingService = assemblyProbingService;
        }

        public ModuleContainer[] Load()
        {
            foreach (var configuration in Configuration.Modules)
                AssemblyProbingService.Copy(GetAssemblyDir(configuration), TempDir);

            AssemblyProbingService.Load(TempDir);

            return Configuration.Modules.Select(mc => Load(mc)).ToArray();
        }

        ModuleContainer Load(ModuleConfiguration configuration)
        {
            var container = new ModuleContainer
            {
                Configuration = configuration,
                Assembly = AssemblyLoader.Load(configuration.Assembly)
            };

            return container;
        }

        string GetAssemblyDir(ModuleConfiguration configuration)
        {
            return Path.Combine(ApplicationPath, configuration.Path);
        }
    }
}
