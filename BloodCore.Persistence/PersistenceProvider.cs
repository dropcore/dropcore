using BloodCore.Persistence.Adapter;
using BloodCore.Persistence.Context;
using BloodCore.Persistence.Context.Modes;
using BloodCore.Persistence.Session;
using Microsoft.Practices.Unity;
using System.Data;

namespace BloodCore.Persistence
{
    public static class PersistenceProvider
    {
        public static void Open<TPersistenceAdapter>(string connectionString)
            where TPersistenceAdapter : IPersistenceAdapter, new()
        {
            SessionContext.SetContext(new WebSessionContext<ISession>());
            SessionFactoryContext.SetContext(new StaticContext<ISessionFactory>());

            var factory = new SessionFactoryImpl()
                .SetAdapter(new TPersistenceAdapter())
                .SetConnectionString(connectionString);

            SessionFactoryContext.Bind(factory);
        }

        public static void Close()
        {
            var factory = SessionFactoryContext.Unbind();
            // TODO: Close factory if applicable?
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ISession>(new InjectionFactory(c => SessionContext.Current));
            container.RegisterType<ISessionFactory>(new InjectionFactory(c => SessionFactoryContext.Current));
            container.RegisterType<IDbConnection>(new InjectionFactory(c => SessionContext.Current.Connection));
        }
    }
}
