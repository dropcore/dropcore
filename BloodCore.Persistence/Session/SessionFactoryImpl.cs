using BloodCore.Persistence.Adapter;

namespace BloodCore.Persistence.Session
{
    public class SessionFactoryImpl : ISessionFactory
    {
        IPersistenceAdapter Adapter { get; set; }

        public string ConnectionString { get; private set; }

        public ISession OpenSession()
        {
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
