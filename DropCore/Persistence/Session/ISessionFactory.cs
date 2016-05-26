using DropCore.Persistence.Adapter;

namespace DropCore.Persistence.Session
{
    public interface ISessionFactory
    {
        ISessionFactory SetAdapter(IPersistenceAdapter adapter);
        ISessionFactory SetConnectionString(string connectionString);
        ISession OpenSession();
    }
}
