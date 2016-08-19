using System.Diagnostics;
using Common.Logging;
using Common.Logging.Interfaces;

namespace Logger.DebugImpl
{
    public class DebugLogger : ILogger
    {
        public void Log(LogLevel level, int eventId, string message, string path)
        {
            Debug.WriteLine($"LogLevel => {level} - EventId => {eventId} - Message => {message} - Path => {path}");
        }
    }
}
