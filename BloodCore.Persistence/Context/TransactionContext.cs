using BloodCore.Persistence.Context.Modes;
using System.Data;

namespace BloodCore.Persistence.Context
{
    public static class TransactionContext
    {
        public static IContext<IDbTransaction> Context { get; private set; }

        public static IDbTransaction Current => Context.Current;

        public static void SetContext(IContext<IDbTransaction> context)
        {
            Context = context;
        }

        public static void Bind(IDbTransaction transaction)
        {
            Context.Bind(transaction);
        }

        public static IDbTransaction Unbind()
        {
            return Context.Unbind();
        }
    }
}
