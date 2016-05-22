using BloodCore.Persistence.Context;
using Microsoft.Practices.Unity;
using System.Data;
using System.Web.Mvc;

namespace BloodCore.Persistence.Mvc
{
    public sealed class TransactionAttribute : ActionFilterAttribute
    {
        [Dependency]
        public IDbConnection Connection { get; set; }

        public IsolationLevel? IsolationLevel { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var transaction = IsolationLevel.HasValue
                ? Connection.BeginTransaction(IsolationLevel.Value)
                : Connection.BeginTransaction();

            TransactionContext.Bind(transaction);

            base.OnActionExecuting(filterContext);
        }
    }
}
