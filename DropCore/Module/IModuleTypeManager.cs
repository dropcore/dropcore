using System;
using System.Reflection;

namespace DropCore.Module
{
    public interface IModuleTypeManager
    {
        Type GetEntryPointType(Assembly assembly);
    }
}
