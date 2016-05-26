using DropCore.Persistence.Context;
using System.Data;

namespace DropCore.Testing
{
    public abstract class PersistenceTest : UnitTest
    {
        protected static IDbConnection Connection => SessionContext.Current.Connection;
    }
}
