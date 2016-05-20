using BloodCore.Persistence.Adapter;
using System;

namespace BloodCore.Persistence.Session
{
    public class SessionFactoryImpl : ISessionFactory
    {
        public IPersistenceAdapter Adapter { get; private set; }
        public string ConnectionString { get; private set; }

        public ISession OpenSession()
        {
            if (Adapter == null)
                throw new InvalidOperationException("No adapter has been assigned to the session factory.");

            var session = new SessionImpl(Adapter.Create(ConnectionString));
            session.Open();

            return session;
        }

        public ISessionFactory SetAdapter(IPersistenceAdapter adapter)
        {
            Adapter = adapter;

            return this;
        }

        public ISessionFactory SetConnectionString(string connectionString)
        {
            ConnectionString = connectionString;

            return this;
        }
    }
}
