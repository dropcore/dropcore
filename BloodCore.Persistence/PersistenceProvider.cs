using BloodCore.Persistence.Adapter;
using BloodCore.Persistence.Context;
using BloodCore.Persistence.Context.Modes;
using BloodCore.Persistence.Session;

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
    }
}
