﻿using DropCore.Persistence.Adapter;
using DropCore.Persistence.Context;
using DropCore.Persistence.Context.Modes;
using DropCore.Persistence.Session;
using Microsoft.Practices.Unity;
using System.Data;

namespace DropCore.Persistence
{
    public static class PersistenceProvider
    {
        public static void Open<TPersistenceAdapter>(string connectionString)
            where TPersistenceAdapter : IPersistenceAdapter, new()
        {
            SessionContext.SetContext(new WebSessionContext<ISession>());
            SessionFactoryContext.SetContext(new StaticContext<ISessionFactory>());
            TransactionContext.SetContext(new WebSessionContext<IDbTransaction>());

            var factory = new SessionFactoryImpl()
                .SetAdapter(new TPersistenceAdapter())
                .SetConnectionString(connectionString);

            SessionFactoryContext.Bind(factory);
        }

        public static void Close()
        {
            var factory = SessionFactoryContext.Unbind();
            // TODO: Close factory if applicable?
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            // Currently we only have to expose the IDbConnection to external modules.
            //container.RegisterType<ISession>(new InjectionFactory(c => SessionContext.Current));
            //container.RegisterType<ISessionFactory>(new InjectionFactory(c => SessionFactoryContext.Current));
            container.RegisterType<IDbConnection>(new InjectionFactory(c => SessionContext.Current.Connection));
        }
    }
}
