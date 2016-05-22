using Microsoft.Practices.Unity;
using System.Data;

namespace BloodCore.Persistence
{
    public abstract class Repository
    {
        [Dependency]
        public IDbConnection Connection { get; set; }
    }
}
