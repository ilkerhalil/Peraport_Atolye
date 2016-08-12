using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using EmailSender.Interfaces;

namespace EmailSender.Impl
{
    public class PeraportSmtpClientEmailSender : IPeraportEmailSender
    {
        private readonly SmtpClient smtpClient;
        public string Host { get; set; }

        public int Port { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int Timeout { get; set; }

        public PeraportSmtpClientEmailSender()
        {
            smtpClient = new SmtpClient();
            
        }

        private void  SetCredational()
        {
        }

        public void SendEmail(PeraportBaseMailMessage peraportMailMessage)
        {
            var mailMessage = MapToMailMessage(peraportMailMessage);
            smtpClient.Send(mailMessage);
            
        }

        private MailMessage MapToMailMessage(PeraportBaseMailMessage peraportMailMessage)
        {
            var mailMessage = new MailMessage();
            var fromMailAddress = new MailAddress(peraportMailMessage.From);
            mailMessage.From = fromMailAddress;

            if (!peraportMailMessage.To.Any())
            {
                throw new Exception("To'da en az bir mail adresi olmalıdır");
            }
            peraportMailMessage.To.ToList().ForEach(f => mailMessage.To.Add(new MailAddress(f.MailAddress, f.DisplayName)));
            if (peraportMailMessage.Cc.Any())
            {

                peraportMailMessage.Cc.ToList().ForEach(f => mailMessage.CC.Add(new MailAddress(f.MailAddress, f.DisplayName)));
            }
            if (peraportMailMessage.Bcc.Any())
            {
                peraportMailMessage.Bcc.ToList().ForEach(f => mailMessage.Bcc.Add(new MailAddress(f.MailAddress, f.DisplayName)));
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
