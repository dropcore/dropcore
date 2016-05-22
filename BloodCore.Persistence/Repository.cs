using BloodCore.Persistence.Session;
using Microsoft.Practices.Unity;
using System.Data;

namespace BloodCore.Persistence
{
    public abstract class Repository
    {
        [Dependency]
        public ISession Session { get; set; }

        protected IDbConnection Connection => Session.Connection;
    }
}
