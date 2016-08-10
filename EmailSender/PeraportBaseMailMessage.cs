using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender
{
    public abstract class PeraportBaseMailMessage
    {
        public virtual string From { get; set; }
        public virtual string To { get; set; }
        public virtual string Cc { get; set; }
        public virtual string Bcc { get; set; }
        public virtual string Subject { get; set; }
        public virtual string Body { get; set; }

        public virtual bool IsBodyHtml { get; set; }

        public virtual PeraportAttachmentCollection AttachmentCollection { get; }
        protected PeraportBaseMailMessage()
        {
            AttachmentCollection = new PeraportAttachmentCollection();
        }
        protected PeraportBaseMailMessage(string from, string to, string subject, string body)
        {
            From = @from;
            To = to;
            Subject = subject;
            Body = body;
        }

        public virtual MailMessage CreateMailMessage()
        {
            ValidateMailMessage();
            var mailMessage = new MailMessage();
            var fromMailAddress = new MailAddress(From);
            mailMessage.From = fromMailAddress;
            var tsToMailAddress = ParseMailAdresses(To);
            tsToMailAddress.ToList().ForEach(f => mailMessage.To.Add(f));
            if (string.IsNullOrWhiteSpace(Cc))
            {
                var tsCcMailAddress = ParseMailAdresses(Cc);
                tsCcMailAddress.ToList().ForEach(f => mailMessage.CC.Add(f));
            }
            if (string.IsNullOrWhiteSpace(Bcc))
            {
                var tsBccMailAddress = ParseMailAdresses(Bcc);
                tsBccMailAddress.ToList().ForEach(f => mailMessage.Bcc.Add(f));
            }
            if (AttachmentCollection.Any())
            {
                AttachmentCollection.ForEach(at => mailMessage.Attachments.Add(at.CrateAttachment()));
            }
            mailMessage.Body = Body;
            mailMessage.Subject = Subject;
            mailMessage.IsBodyHtml = IsBodyHtml;
            return mailMessage;
        }
        protected virtual IEnumerable<string> ParseMailAdresses(string parameter)
        {
            if (!parameter.Contains(";")) return new[] { parameter };
            var result = parameter.Split(';');
            return result;
        }
        protected virtual void ValidateMailMessage()
        {
            if (string.IsNullOrWhiteSpace(From))
            {
                throw new ArgumentNullException(nameof(From), "From boş bırakılamaz.");
            }
            if (string.IsNullOrWhiteSpace(To))
            {
                throw new ArgumentNullException(nameof(To), "To boş bırakılamaz.");
            }
            if (string.IsNullOrWhiteSpace(Subject))
            {
                throw new ArgumentNullException(nameof(Subject), "Subject boş bırakılamaz.");
            }
            if (string.IsNullOrWhiteSpace(Body))
            {
                throw new ArgumentNullException(nameof(Body), "Body boş bırakılamaz.");
            }
        }
    }
}
