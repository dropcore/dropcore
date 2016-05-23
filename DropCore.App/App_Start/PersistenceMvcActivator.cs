using DropCore.Persistence.Adapter;
using System.Configuration;
using DropCore.Persistence;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DropCore.App.App_Start.PersistenceMvcActivator), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(DropCore.App.App_Start.PersistenceMvcActivator), "Shutdown")]

namespace DropCore.App.App_Start
{
    public static class PersistenceMvcActivator
    {
        public static void Start()
        {
            PersistenceProvider.Open<MySqlAdapter>(ConfigurationManager.AppSettings["ConnectionString"]);
            PersistenceProvider.RegisterTypes(UnityConfig.GetConfiguredContainer());
        }

        public static void Shutdown()
        {
            PersistenceProvider.Close();
        }
    }
}