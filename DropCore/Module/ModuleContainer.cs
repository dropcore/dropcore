using DropCore.Configuration;
using System.Reflection;

namespace DropCore.Module
{
    public class ModuleContainer
    {
        public ModuleConfiguration Configuration { get; set; }
        public Assembly Assembly { get; set; }
        public IModule Instance { get; set; }
    }
}
