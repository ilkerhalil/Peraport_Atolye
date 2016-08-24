using Common.Logging;

namespace EmailSender.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var emailSender = PeraportEmailSenderFactory.CreateEmailSender();
            var mailMessage = new PeraportMailMessageImpl();
            emailSender.SendEmail(mailMessage);*/

            //var emailSenderImap = PeraportEmailSenderFactoryImap.CreateEmailSender();
            //var mailMessageImap = new PeraportMailMessageImplImap();
            //  emailSenderImap.SendMailImap(mailMessageImap);
            //var loggerConfigSection = ConfigurationManager.GetSection("LoggerSection") as LoggerConfigurationSection;
            //LoggerWriter.Log(LogLevel.Debug, 1, "merhaba");

            LogManager.SetLogWriter(new LoggerFactory().CreateLogWriter());


        }
    }
}
