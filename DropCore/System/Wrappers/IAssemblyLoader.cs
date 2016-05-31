using System.Reflection;

namespace DropCore.System.Wrappers
{
    public interface IAssemblyLoader
    {
        Assembly LoadFrom(string path);
        Assembly Load(string path);
    }
}
