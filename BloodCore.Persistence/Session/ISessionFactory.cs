using BloodCore.Persistence.Adapter;

namespace BloodCore.Persistence.Session
{
    public interface ISessionFactory
    {
        ISessionFactory SetAdapter(IPersistenceAdapter adapter);
        ISessionFactory SetConnectionString(string connectionString);
        ISession OpenSession();
    }
}
