using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DropCore.Module.Tests
{
    [TestClass]
    public class ModuleTypeManagerImplTest
    {
        [TestMethod]
        public void ModuleTypeManagerImpl_Can_Get_Entry_Point_Type_For_Assembly()
        {
            var manager = new ModuleTypeManagerImpl();
            Assert.AreEqual(typeof(ModuleStub), manager.GetEntryPointType(GetType().Assembly));
        }
    }
}
