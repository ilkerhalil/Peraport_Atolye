using System.Linq;
using Common.Logging.Interfaces;

namespace Common.Logging
{
    public class LoggerWriter
    {
        private ILogger[] Logger { get; }

        public LoggerWriter(ILogger[] logger)
        {
            Logger = logger;
        }

        public void Log(LogLevel level, int eventId, string message)
        {
            foreach (var logger in Logger)
            {
                logger.Log(level, eventId, message);
            }
        }
    }
}
