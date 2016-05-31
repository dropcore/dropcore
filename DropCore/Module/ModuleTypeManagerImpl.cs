using System;
using System.Linq;
using System.Reflection;

namespace DropCore.Module
{
    public class ModuleTypeManagerImpl : IModuleTypeManager
    {
        public Type GetEntryPointType(Assembly assembly)
        {
            return assembly.ExportedTypes.FirstOrDefault(t => t.GetInterface(nameof(IModule)) != null);
        }
    }
}
