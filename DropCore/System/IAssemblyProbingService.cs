namespace DropCore.System
{
    public interface IAssemblyProbingService
    {
        void Copy(string sourcePath, string targetPath);
        void Load(string targetPath);
    }
}
