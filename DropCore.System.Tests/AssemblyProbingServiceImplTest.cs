using DropCore.System.Wrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DropCore.System.Tests
{
    [TestClass]
    public class AssemblyProbingServiceImplTest
    {
        Mock<IAssemblyLoader> AssemblyLoaderMock { get; set; }
        Mock<IFileSystem> FileSystemMock { get; set; }
        Mock<IBuildManager> BuildManagerMock { get; set; }

        AssemblyProbingServiceImpl Service { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            AssemblyLoaderMock = new Mock<IAssemblyLoader>();
            FileSystemMock = new Mock<IFileSystem>();
            BuildManagerMock = new Mock<IBuildManager>();
            Service = new AssemblyProbingServiceImpl(AssemblyLoaderMock.Object,
                FileSystemMock.Object,
                BuildManagerMock.Object);
        }

        [TestMethod]
        public void AssemblyProbingServiceImpl_Can_Copy()
        {
            var sourcePath = @"C:\test\hello";
            var targetPath = @"C:\foo\bar";

            FileSystemMock.Setup(fs => fs.GetFiles(sourcePath)).Returns(new[] { @"C:\test\hello\world.txt", @"C:\test\hello\bar.txt" });
            Service.Copy(sourcePath, targetPath);
            FileSystemMock.Verify(fs => fs.CopyFile(sourcePath + @"\world.txt", targetPath + @"\world.txt", true));
            FileSystemMock.Verify(fs => fs.CopyFile(sourcePath + @"\bar.txt", targetPath + @"\bar.txt", true));
        }
        
        [TestMethod]
        public void AssemblyProbingServiceImpl_Can_Load()
        {
            var assembly = this.GetType().Assembly;
            var targetPath = @"C:\test\hello";
            FileSystemMock.Setup(fs => fs.GetFiles(targetPath)).Returns(new[] { @"C:\test\hello\world.dll", @"C:\test\hello\bar.dll" });
            AssemblyLoaderMock.Setup(al => al.Load("world")).Returns(assembly);
            AssemblyLoaderMock.Setup(al => al.Load("bar")).Returns(assembly);
            Service.Load(targetPath);
            AssemblyLoaderMock.Verify(al => al.Load("world"));
            AssemblyLoaderMock.Verify(al => al.Load("bar"));
            BuildManagerMock.Verify(bm => bm.AddReferencedAssembly(assembly), Times.Exactly(2));
        }
    }
}
