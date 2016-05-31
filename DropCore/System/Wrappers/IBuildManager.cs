using System.Reflection;

namespace DropCore.System.Wrappers
{
    public interface IBuildManager
    {
        void AddReferencedAssembly(Assembly assembly);
    }
}
