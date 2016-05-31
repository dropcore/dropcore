using System.Reflection;

namespace DropCore.System.Wrappers
{
    internal class AssemblyLoaderImpl : IAssemblyLoader
    {
        public Assembly LoadFrom(string path)
        {
            return Assembly.LoadFrom(path);
        }

        public Assembly Load(string assembly)
        {
            return Assembly.Load(assembly);
        }
    }
}
