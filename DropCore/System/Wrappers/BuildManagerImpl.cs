using System.Reflection;
using System.Web.Compilation;

namespace DropCore.System.Wrappers
{
    internal class BuildManagerImpl : IBuildManager
    {
        public void AddReferencedAssembly(Assembly assembly)
        {
            BuildManager.AddReferencedAssembly(assembly);
        }
    }
}
