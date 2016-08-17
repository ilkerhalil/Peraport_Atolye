using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using Common.Helper;
using Common.MailSender.Interfaces;

namespace EmailSenderImpl
{
    public class PeraportSmtpClientEmailSender : BasePeraportEmailSender
    {
        private readonly SmtpClient _smtpClient;


        public int Timeout { get; set; }

        public PeraportSmtpClientEmailSender()
        {
            _smtpClient = new SmtpClient();
        }

        protected override void ValidateAndSetHostPort()
        {
            Host.NullGuard();
            _smtpClient.Host = Host;
            _smtpClient.Port = Port;
        }

        protected override void ValidateAndSetCredational()
        {
            UserName.NullGuard();
            Password.NullGuard();
            _smtpClient.Credentials = new NetworkCredential(UserName, Password);
        }

        protected override void SendEmailImpl(BasePeraportMailMessage basePeraportMailMessage)
        {
            var mailMessage = MapToMailMessage(basePeraportMailMessage);
            _smtpClient.Send(mailMessage);
        }


        private static MailMessage MapToMailMessage(BasePeraportMailMessage basePeraportMailMessage)
        {
            var mailMessage = new MailMessage();
            var fromMailAddress = new MailAddress(basePeraportMailMessage.From);
            mailMessage.From = fromMailAddress;

            if (!basePeraportMailMessage.To.Any())
            {
                throw new Exception("To'da en az bir mail adresi olmalıdır");
            }
            basePeraportMailMessage.To.ToList().ForEach(f => mailMessage.To.Add(new MailAddress(f.MailAddress, f.DisplayName)));
            if (basePeraportMailMessage.Cc.Any())
            {

                basePeraportMailMessage.Cc.ToList().ForEach(f => mailMessage.CC.Add(new MailAddress(f.MailAddress, f.DisplayName)));
            }
            if (basePeraportMailMessage.Bcc.Any())
            {
                basePeraportMailMessage.Bcc.ToList().ForEach(f => mailMessage.Bcc.Add(new MailAddress(f.MailAddress, f.DisplayName)));
            }
            if (basePeraportMailMessage.AttachmentCollection.Any())
            {
                basePeraportMailMessage.AttachmentCollection.ForEach(at => mailMessage.Attachments.Add(at.CrateAttachment()));
            }
            mailMessage.Body = basePeraportMailMessage.Body;
            mailMessage.Subject = basePeraportMailMessage.Subject;
            mailMessage.IsBodyHtml = basePeraportMailMessage.IsBodyHtml;
            return mailMessage;
        }
    }
}
