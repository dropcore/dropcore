using DropCore.System.Wrappers;
using System.IO;
using System.Linq;

namespace DropCore.System
{
    /// <summary>
    /// Does all the dirty work in order to get pluggable modules to work with Razor. The basic flow of it
    /// all is as follows: We copy all files from the plugin folder into a temporary module location that
    /// is pointed to by the probe directive in the Web.config file. We then load all assemblies present
    /// in the temporary module location into the current AppDomain and add the loaded assemblies to
    /// the Razor build manager.
    ///
    /// This basically loads all the modules as if they were compiled into the application.
    /// </summary>
    public class AssemblyProbingServiceImpl : IAssemblyProbingService
    {
        IAssemblyLoader AssemblyLoader { get; set; }
        IFileSystem FileSystem { get; set; }
        IBuildManager BuildManager { get; set; }

        public AssemblyProbingServiceImpl(IAssemblyLoader assemblyLoader,
            IFileSystem fileSystem,
            IBuildManager buildManager)
        {
            AssemblyLoader = assemblyLoader;
            FileSystem = fileSystem;
            BuildManager = buildManager;
        }

        public void Copy(string sourcePath, string targetPath)
        {
            if (!FileSystem.DirectoryExists(targetPath))
                FileSystem.CreateDirectory(targetPath);

            // Here we copy all files in the plugin directory to the temporary plugin directory.
            foreach (var file in FileSystem.GetFiles(sourcePath))
                FileSystem.CopyFile(file, Path.Combine(targetPath, Path.GetFileName(file)), true);
        }

        public void Load(string targetPath)
        {
            // After we have copied the files from the plugin directory to the temporary plugin directory,
            // we reference all copied dlls and add them to the build manager so they are accessible for
            // razor views.
            foreach (var file in FileSystem.GetFiles(targetPath).Where(p => Path.GetExtension(p) == ".dll"))
            {
                var assembly = AssemblyLoader.Load(Path.GetFileNameWithoutExtension(file));
                BuildManager.AddReferencedAssembly(assembly);
            }
        }
    }
}
