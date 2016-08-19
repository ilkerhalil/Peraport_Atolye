using System.Linq;
using Common.Logging.Interfaces;

namespace Common.Logging
{
    public static class LoggerManager
    {
        private static ILogger[] Logger { get; set; }

        static LoggerManager()
        {

        }

        public static void Log(LogLevel level, int eventId, string message)
        {
            Logger = LoggerFactory.GetLoggers().ToArray();
            foreach (var logger in Logger)
            {
                logger.Log(level, eventId, message);
            }
        }
    }
}
