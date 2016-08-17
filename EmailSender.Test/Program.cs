using AE.Net.Mail;
 
using System;
using System.Configuration;
using Common.Logging;
using Common.Logging.ConfigurationSections;

namespace EmailSender.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var emailSender = PeraportEmailSenderFactory.CreateEmailSender();
            var mailMessage = new PeraportMailMessageImpl();
            emailSender.SendEmail(mailMessage);*/

            //var q = new ImapClient("host", "ekremalpayy@gmail.com", "Pss!14181850.9298", AuthMethods.Login, 143, false, false);

            //var emailSenderImap = PeraportEmailSenderFactoryImap.CreateEmailSender();
            //var mailMessageImap = new PeraportMailMessageImplImap();
          //  emailSenderImap.SendMailImap(mailMessageImap);
            //var loggerConfigSection = ConfigurationManager.GetSection("LoggerSection") as LoggerConfigurationSection;
            LoggerManager.Log(LogLevel.Debug, 1,"merhaba");
            
        }
    }
}
