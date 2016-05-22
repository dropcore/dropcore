using BloodCore.Persistence.Context;
using System.Data;

namespace BloodCore.Testing
{
    public abstract class PersistenceTest
    {
        protected IDbConnection Connection => SessionContext.Current.Connection;
    }
}
