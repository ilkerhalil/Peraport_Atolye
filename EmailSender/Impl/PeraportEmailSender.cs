using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection.Emit;

namespace EmailSender
{
    public class PeraportSmtpClientEmailSender : IPeraportEmailSender
    {
        public void SendEmail(PeraportBaseMailMessage peraportMailMessage)
        {
            var smtpClient = new SmtpClient();
            var mailMessage = MapToMailMessage(peraportMailMessage);
            smtpClient.Send(mailMessage);
        }

        private MailMessage MapToMailMessage(PeraportBaseMailMessage peraportMailMessage)
        {
            var mailMessage = new MailMessage();
            var fromMailAddress = new MailAddress(peraportMailMessage.From);
            mailMessage.From = fromMailAddress;
           
            peraportMailMessage.To.ToList().ForEach(f => mailMessage.To.Add(f));
            if (peraportMailMessage.Cc.Any())
            {
               
                peraportMailMessage.Cc.ToList().ForEach(f => mailMessage.CC.Add(f));
            }
            if (peraportMailMessage.Bcc.Any())
            {
                peraportMailMessage.Bcc.ToList().ForEach(f => mailMessage.Bcc.Add(f));
            }
            if (peraportMailMessage.AttachmentCollection.Any())
            {
                peraportMailMessage.AttachmentCollection.ForEach(at => mailMessage.Attachments.Add(at.CrateAttachment()));
            }
            mailMessage.Body = peraportMailMessage.Body;
            mailMessage.Subject = peraportMailMessage.Subject;
            mailMessage.IsBodyHtml = peraportMailMessage.IsBodyHtml;
            return mailMessage;
        }
    }
}
