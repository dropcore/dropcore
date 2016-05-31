using DropCore.Persistence.Context;
using System.Web;

namespace DropCore.Persistence.Http
{
    public class PersistenceModule : IHttpModule
    {
        public void Dispose()
        {
            //
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += Context_BeginRequest;
            context.EndRequest += Context_EndRequest;
        }

        private static void Context_BeginRequest(object sender, global::System.EventArgs e)
        {
            SessionContext.Bind(SessionFactoryContext.Current.OpenSession());
        }

        private static void Context_EndRequest(object sender, global::System.EventArgs e)
        {
            var session = SessionContext.Unbind();
            if (session == null)
                return;

            TransactionContext.Unbind()?.Dispose();

            session.Dispose();
        }
    }
}
