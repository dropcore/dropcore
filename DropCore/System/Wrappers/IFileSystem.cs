namespace DropCore.System.Wrappers
{
    public interface IFileSystem
    {
        bool DirectoryExists(string path);
        void CreateDirectory(string path);
        void CopyFile(string sourcePath, string targetPath, bool overwrite = false);
        string[] GetFiles(string path);
    }
}
