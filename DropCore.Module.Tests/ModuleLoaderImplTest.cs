using DropCore.Configuration;
using DropCore.System;
using DropCore.System.Wrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.IO;
using System.Reflection;

namespace DropCore.Module.Tests
{
    [TestClass]
    public class ModuleLoaderImplTest
    {
        AppConfiguration Configuration { get; set; }
        Mock<IAssemblyLoader> AssemblyLoaderMock { get; set; }
        Mock<IAssemblyProbingService> AssemblyProbingServiceMock { get; set; }
        ModuleLoaderImpl ModuleLoader { get; set; }

        string ModuleAssembly => "test.assembly";
        string ModulePath => @"module\path";
        string TempDir => Path.Combine(Configuration.ApplicationPath, "bin", ".ModuleTemp");

        [TestInitialize]
        public void Initialize()
        {
            Configuration = new AppConfiguration
            {
                ApplicationPath = @"C:\test",
                Modules = new[]
                {
                    new ModuleConfiguration
                    {
                        Assembly = ModuleAssembly,
                        Path = ModulePath,
                    },
                },
            };

            AssemblyLoaderMock = new Mock<IAssemblyLoader>();
            AssemblyProbingServiceMock = new Mock<IAssemblyProbingService>();
            ModuleLoader = new ModuleLoaderImpl(Configuration, AssemblyLoaderMock.Object, AssemblyProbingServiceMock.Object);
        }

        [TestMethod]
        public void ModuleLoaderImpl_Can_Load_Modules_From_Configuration()
        {
            var result = ModuleLoader.Load();

            Assert.AreEqual(1, result.Length);
            AssemblyProbingServiceMock.Verify(aps => aps.Copy(Path.Combine(Configuration.ApplicationPath, ModulePath), TempDir));
            AssemblyProbingServiceMock.Verify(aps => aps.Load(TempDir));
            AssemblyLoaderMock.Verify(al => al.Load(ModuleAssembly));
        }
    }
}
