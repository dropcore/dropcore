using BloodCore.Persistence.Context;
using System.Data;
using System.Web.Mvc;

namespace BloodCore.Persistence.Mvc
{
    public class PersistenceController : Controller
    {
        public IDbTransaction Transaction => TransactionContext.Current;
    }
}
