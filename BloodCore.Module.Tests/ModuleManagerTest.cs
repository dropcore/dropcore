using BloodCore.Module;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System.Web.Routing;

namespace BloodCore.Module.Tests
{
    [TestClass]
    public class ModuleManagerTest
    {
        [TestMethod]
        public void ModuleManager_Can_Add_Module_By_Generic_Type()
        {
            var manager = new ModuleManager();

            Assert.IsFalse(manager.Modules.OfType<ModuleStub>().Any());
            manager.Add<ModuleStub>();
            Assert.IsTrue(manager.Modules.OfType<ModuleStub>().Any());
        }

        [TestMethod]
        public void ModuleManager_Does_Not_Add_Duplicate_Modules()
        {
            var manager = new ModuleManager();
            manager.Add<ModuleStub>();
            manager.Add<ModuleStub>();

            Assert.AreEqual(1, manager.Modules.OfType<ModuleStub>().Count());
        }

        [TestMethod]
        public void ModuleManager_Registers_Module_Routes()
        {
            var manager = new ModuleManager();
            var moduleMock = new Mock<IModule>();
            var stubRoutes = new RouteCollection();

            manager.Modules.Add(moduleMock.Object);
            manager.RegisterRoutes(stubRoutes);

            moduleMock.Verify(m => m.RegisterRoutes(stubRoutes));
        }

        [TestMethod]
        public void ModuleManager_Registers_Module_Types()
        {
            var manager = new ModuleManager();
            var moduleMock = new Mock<IModule>();
            var stubContainer = new Mock<IUnityContainer>();

            manager.Modules.Add(moduleMock.Object);
            manager.RegisterTypes(stubContainer.Object);

            moduleMock.Verify(m => m.RegisterTypes(stubContainer.Object));
        }
    }

    public class ModuleStub : IModule
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            //
        }

        public void RegisterTypes(IUnityContainer container)
        {
            //
        }
    }
}
