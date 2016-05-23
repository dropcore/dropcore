using DropCore.Persistence.Context;
using System.Data;

namespace DropCore.Testing
{
    public abstract class PersistenceTest
    {
        protected IDbConnection Connection => SessionContext.Current.Connection;
    }
}
