using System;
using BloodCore.Persistence.Context.Modes;
using BloodCore.Persistence.Session;

namespace BloodCore.Persistence.Context
{
    public static class SessionFactoryContext
    {
        public static IContext<ISessionFactory> Context { get; private set; }

        public static ISessionFactory Current => Context.Current;

        public static void SetContext(IContext<ISessionFactory> context)
        {
            Context = context;
        }

        public static void Bind(ISessionFactory factory)
        {
            Context.Bind(factory);
        }

        public static ISessionFactory Unbind()
        {
            return Context.Unbind();
        }
    }
}
