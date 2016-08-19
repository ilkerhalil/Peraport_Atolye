using System.Threading.Tasks;

namespace Common.Rolling
{
    public interface IRollingFileTextWriter
    {
        string Path { get; }
        string FileName { get; }
        Task RollLogFile(string content);
        long RollingSize { get; set; }
    }
}