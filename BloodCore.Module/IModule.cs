using Microsoft.Practices.Unity;
using System.Web.Routing;

namespace BloodCore.Module
{
    public interface IModule
    {
        void RegisterRoutes(RouteCollection routes);
        void RegisterTypes(IUnityContainer container);
    }
}
