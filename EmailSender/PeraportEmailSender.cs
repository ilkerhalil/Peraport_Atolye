using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection.Emit;

namespace EmailSender
{
    public class PeraportEmailSender : IPeraportEmailSender
    {
        public void SendEmail(PeraportBaseMailMessage peraportMailMessage)
        {
            var smtpClient = new SmtpClient();
            var mailMessage = peraportMailMessage.CreateMailMessage();
            smtpClient.Send(mailMessage);
        }
    }
}
