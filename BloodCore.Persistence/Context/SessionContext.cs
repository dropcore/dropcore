using BloodCore.Persistence.Context.Modes;
using BloodCore.Persistence.Session;

namespace BloodCore.Persistence.Context
{
    public static class SessionContext
    {
        public static IContext<ISession> Context { get; private set; }

        public static ISession Current => Context.Current;

        public static void SetContext(IContext<ISession> context)
        {
            Context = context;
        }

        public static void Bind(ISession session)
        {
            Context.Bind(session);
        }

        public static ISession Unbind()
        {
            return Context.Unbind();
        }
    }
}
