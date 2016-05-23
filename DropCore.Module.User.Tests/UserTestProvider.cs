using DropCore.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DropCore.Module.User.Tests
{
    [TestClass]
    public class UserTestProvider
    {
        [AssemblyInitialize]
        public static void Initialize(TestContext context)
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
