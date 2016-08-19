using System.Threading.Tasks;

namespace Common.Rolling
{
    public interface IFileTextWriter
    {
        string Path { get; }
        string FileName { get; }
        Task RollLogFile(string content);
    }
}