
namespace Logger.Models.Interfaces
{
    public interface IIOManager
    {
        string CurrentDirectoryPath { get; }
        string CurrentFilePath { get; }
        
        void EnsurePathAndFileExistance();

        string GetCurrentPath();
    }
}
