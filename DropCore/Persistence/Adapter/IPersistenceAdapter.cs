using System.Data;

namespace DropCore.Persistence.Adapter
{
    public interface IPersistenceAdapter
    {
        IDbConnection Create(string connectionString);
    }
}
