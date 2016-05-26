using DropCore.Persistence.Context;
using System.Data;
using System.Web.Mvc;

namespace DropCore.Persistence.Mvc
{
    public class PersistenceController : Controller
    {
        public IDbTransaction Transaction => TransactionContext.Current;
    }
}
