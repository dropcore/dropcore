using BloodCore.Persistence.Adapter;
using System.Configuration;
using BloodCore.Persistence;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BloodCore.App.App_Start.PersistenceMvcActivator), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(BloodCore.App.App_Start.PersistenceMvcActivator), "Shutdown")]

namespace BloodCore.App.App_Start
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