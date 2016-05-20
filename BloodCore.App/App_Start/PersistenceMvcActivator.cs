using BloodCore.Persistence.Context;
using BloodCore.Persistence.Session;
using BloodCore.Persistence.Adapter;
using System.Configuration;
using BloodCore.Persistence.Context.Modes;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BloodCore.App.App_Start.PersistenceMvcActivator), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(BloodCore.App.App_Start.PersistenceMvcActivator), "Shutdown")]

namespace BloodCore.App.App_Start
{
    // TODO: Move to the BloodCore.Persistence library?
    public static class PersistenceMvcActivator
    {
        public static void Start()
        {
            SessionContext.SetContext(new WebSessionContext<ISession>());
            SessionFactoryContext.SetContext(new StaticContext<ISessionFactory>());

            var factory = new SessionFactoryImpl()
                .SetAdapter(new MySqlAdapter())
                .SetConnectionString(ConfigurationManager.AppSettings["ConnectionString"]);

            SessionFactoryContext.Bind(factory);
        }

        public static void Shutdown()
        {
            var factory = SessionFactoryContext.Unbind();
            
            // TODO: Close factory, etc?
        }
    }
}