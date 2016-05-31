using DropCore.Testing;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Web.Routing;

namespace DropCore.Module.Tests
{
    [TestClass]
    public class ModuleManagerTest : UnitTest
    {
        IUnityContainer Container { get; set; }
        Mock<IModuleLoader> LoaderMock { get; set; }
        Mock<IModuleTypeManager> TypeManagerMock { get; set; }
        ModuleManager ModuleManager { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            Container = new UnityContainer();

            LoaderMock = new Mock<IModuleLoader>();
            TypeManagerMock = new Mock<IModuleTypeManager>();
            ModuleManager = new ModuleManager(Container, LoaderMock.Object, TypeManagerMock.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            Container.Dispose();
        }

        [TestMethod]
        public void ModuleManager_Can_Be_Initialized()
        {
            var assembly = GetType().Assembly;
            TypeManagerMock.Setup(tm => tm.GetEntryPointType(assembly)).Returns(typeof(ModuleStub));

            LoaderMock.Setup(l => l.Load()).Returns(new[]
            {
                new ModuleContainer { Assembly = assembly }
            });

            ModuleManager.Initialize();
            var module = ModuleManager.Modules.FirstOrDefault()?.Instance as ModuleStub;
            Assert.IsNotNull(module);
        }

        [TestMethod]
        public void ModuleManager_Can_Register_Modules()
        {
            var module = new ModuleStub();
            ModuleManager.Modules.Add(new ModuleContainer { Instance = module });
            Assert.IsFalse(module.Routed);
            Assert.IsFalse(module.Typed);

            ModuleManager.Register(null);
            Assert.IsTrue(module.Routed);
            Assert.IsTrue(module.Typed);
        }

        [TestMethod]
        public void ModuleManager_Raises_InvalidOperationException_If_Module_Does_Not_Have_An_Entry_Point_On_Initialize()
        {
            var assembly = typeof(Mock).Assembly;
            LoaderMock.Setup(l => l.Load()).Returns(new[]
            {
                new ModuleContainer { Assembly = assembly },
            });

            AssertRaise<InvalidOperationException>(() => ModuleManager.Initialize());
        }

        [TestMethod]
        public void ModuleManager_Raises_InvalidOperationException_If_Module_Does_Not_Have_An_Instance_On_Register()
        {
            ModuleManager.Modules.Add(new ModuleContainer());

            AssertRaise<InvalidOperationException>(() => ModuleManager.Register(null));
        }
    }
}
