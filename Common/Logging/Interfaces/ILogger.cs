namespace Common.Logging.Interfaces
{
    public interface ILogger
    {
        void Log(LogLevel level, int eventId, string message, string path);
    }
}
