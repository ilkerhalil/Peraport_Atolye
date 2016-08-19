using System;
using Common.Logging;
using Common.Logging.Interfaces;
using System.IO;
using Common.Rolling;

namespace Logger.FileLogger
{
    public class FileLogger : ILogger
    {
        public async void Log(LogLevel level, int eventId, string message, string path)
        {
            Rolling r = new Rolling();
            string logFileName = r.RollLogFile();
            using (var sw = new StreamWriter(logFileName, true))
            {
                await sw.WriteAsync($"{DateTime.Now} LogLevel => {level} - EventId => {eventId} - Message => {message}");
                await sw.FlushAsync();
            }
        }
    }
}
