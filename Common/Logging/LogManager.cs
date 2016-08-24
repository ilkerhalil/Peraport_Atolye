namespace Common.Logging
{
    public static class LogManager
    {

        private static LoggerWriter _loggerWriter;

        public static void SetLogWriter(LoggerWriter loggerWriter)
        {
            _loggerWriter = loggerWriter;
        }

        public static void WriteLog(LogEntry logEntry)
        {
            _loggerWriter.Log(logEntry.LogLevel,logEntry.EventId,logEntry.Message);
        }
    }
}
