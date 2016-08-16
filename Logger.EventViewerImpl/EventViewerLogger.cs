using System.Diagnostics;
using Common.Logging;
using Common.Logging.Interfaces;

namespace Logger.EventViewerImpl
{
    public class EventViewerLogger : ILogger
    {
        public string Source { get; set; }

        public string Event { get; set; }

        public string SLog { get; set; }

        public EventViewerLogger(string source, string @event, string sLog)
        {
            Source = source;
            Event = @event;
            SLog = sLog;
        }


        public void Log(LogLevel level, int eventId, string message)
        {
            if (!EventLog.SourceExists(Source))
            {
                EventLog.CreateEventSource(Source, SLog);
            }

            switch (level)
            {
                case LogLevel.Trace:
                    EventLog.WriteEntry(Source, message, EventLogEntryType.FailureAudit, eventId);
                    break;
                case LogLevel.Error:
                    EventLog.WriteEntry(Source, message, EventLogEntryType.Error, eventId);
                    break;
                case LogLevel.Warn:
                    EventLog.WriteEntry(Source, message, EventLogEntryType.Warning, eventId);
                    break;
                case LogLevel.Debug:
                    EventLog.WriteEntry(Source, message, EventLogEntryType.SuccessAudit, eventId);
                    break;
                case LogLevel.Information:
                    EventLog.WriteEntry(Source, message, EventLogEntryType.Information, eventId);
                    break;
                case LogLevel.Verbose:
                    EventLog.WriteEntry(Source, message, EventLogEntryType.Information, eventId);
                    break;

            }
        }
    }
}
