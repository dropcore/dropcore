using Microsoft.Practices.Unity;
using System.Web.Routing;

namespace DropCore.Module
{
    public interface IModule
    {
        void RegisterRoutes(RouteCollection routes);
        void RegisterTypes(IUnityContainer container);
    }
}
