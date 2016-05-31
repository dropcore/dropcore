using System.IO;

namespace DropCore.System.Wrappers
{
    internal class FileSystemImpl : IFileSystem
    {
        public void CopyFile(string sourcePath, string targetPath, bool overwrite = false)
        {
            File.Copy(sourcePath, targetPath, overwrite);
        }

        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public string[] GetFiles(string path)
        {
            return Directory.GetFiles(path);
        }
    }
}
