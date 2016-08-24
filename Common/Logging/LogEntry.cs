namespace Common.Logging
{
    public class LogEntry
    {
        public string Message { get; set; }
        //LogLevel level, int eventId, string message
        public int Level { get; set; }

        public int EventId { get; set; }


        public LogLevel LogLevel { get; set; }

    }
}