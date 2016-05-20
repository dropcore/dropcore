using System.Data;

namespace BloodCore.Persistence.Adapter
{
    public interface IPersistenceAdapter
    {
        IDbConnection Create(string connectionString);
    }
}
