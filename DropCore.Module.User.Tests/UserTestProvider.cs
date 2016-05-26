using DropCore.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DropCore.Module.User.Tests
{
    [TestClass]
    public class UserTestProvider
    {
        [AssemblyInitialize]
#pragma warning disable CC0057 // Unused parameters
        public static void Initialize(TestContext context)
#pragma warning restore CC0057 // Unused parameters
        {
            PersistenceTestProvider.Open();
        }

        [AssemblyCleanup]
        public static void Cleanup()
        {
            PersistenceTestProvider.Close();
        }
    }
}
