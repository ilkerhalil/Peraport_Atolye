using Common.Logging;
using Common.Logging.Interfaces;
using Common.MailSender.Interfaces;
using EmailSenderImpl;

namespace Logger.EmailImpl
{
    public class EmailLogger : ILogger
    {
        private readonly IPeraportEmailSender _peraportEmailSender;

        public string From { get; set; }

        public string[] To { get; set; }

        public string Subject { get; set; }


        public EmailLogger(IPeraportEmailSender peraportEmailSender)
        {
            _peraportEmailSender = peraportEmailSender;
        }

        public void Log(LogLevel level, int eventId, string message)
        {
            var body = $"LogLevel => {level} - EventId => {eventId} - Message => {message}";
            //_peraportEmailSender.SendEmail(new BasePeraportMailMessageImpl(From, To, Subject, body));
        }
    }
}
