using BloodCore.Persistence;
using BloodCore.Persistence.Adapter;
using BloodCore.Persistence.Context;
using BloodCore.Persistence.Context.Modes;
using BloodCore.Persistence.Session;
using System.Configuration;
using System.Data;

namespace BloodCore.Testing
{
    public static class PersistenceTestProvider
    {
        public static void Open()
        {
            PersistenceProvider.Open<MySqlAdapter>(ConfigurationManager.AppSettings["ConnectionString"]);

            // We override the contexts that use WebSessionContext as that is not available when running unit tests.
            SessionContext.SetContext(new StaticContext<ISession>());
            TransactionContext.SetContext(new StaticContext<IDbTransaction>());

            var session = SessionFactoryContext.Current.OpenSession();
            SessionContext.Bind(session);

            var transaction = session.Connection.BeginTransaction();
            TransactionContext.Bind(transaction);
        }

        public static void Close()
        {
            var session = SessionContext.Unbind();
            if (session == null)
                return;

            TransactionContext.Unbind()?.Dispose();
            session.Dispose();

            PersistenceProvider.Close();
        }
    }
}
