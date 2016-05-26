using Microsoft.Practices.Unity;
using System.Data;

namespace DropCore.Persistence
{
    public abstract class Repository
    {
        [Dependency]
        public IDbConnection Connection { get; set; }
    }
}
