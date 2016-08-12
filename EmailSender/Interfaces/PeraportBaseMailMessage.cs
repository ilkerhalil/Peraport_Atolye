using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace EmailSender
{
    public abstract class PeraportBaseMailMessage
    {

        private string[] _to;

        public virtual string From { get; set; }
        public virtual string []To
        {
            get
            {
                return _to;
            }
            set
            {
                if (value == null) throw new ArgumentNullException();
                if (value.Any(w => string.IsNullOrWhiteSpace(w)))
                {
                    var source = value.ToList();
                    source.RemoveAll(s => string.IsNullOrWhiteSpace(s));
                    value = source.ToArray();
                }
                if (value == _to) return;
                
                _to = value;
            }
        }
        public virtual string[] Cc { get; set; }
        public virtual string[] Bcc { get; set; }
        public virtual string Subject { get; set; }
        public virtual string Body { get; set; }
        public virtual bool IsBodyHtml { get; set; }
        public virtual PeraportAttachmentCollection AttachmentCollection { get; }

       
        protected PeraportBaseMailMessage(string from, string[] to, string subject, string body)
        {
            AttachmentCollection = new PeraportAttachmentCollection();
            From = @from;
            To = to;
            Subject = subject;
            Body = body;
        }

        //public virtual MailMessage CreateMailMessage()
        //{
        //    ValidateMailMessage();
        //    var mailMessage = new MailMessage();
        //    var fromMailAddress = new MailAddress(From);
        //    mailMessage.From = fromMailAddress;
        //    var tsToMailAddress = ParseMailAdresses(To);
        //    tsToMailAddress.ToList().ForEach(f => mailMessage.To.Add(f));
        //    if (string.IsNullOrWhiteSpace(Cc))
        //    {
        //        var tsCcMailAddress = ParseMailAdresses(Cc);
        //        tsCcMailAddress.ToList().ForEach(f => mailMessage.CC.Add(f));
        //    }
        //    if (string.IsNullOrWhiteSpace(Bcc))
        //    {
        //        var tsBccMailAddress = ParseMailAdresses(Bcc);
        //        tsBccMailAddress.ToList().ForEach(f => mailMessage.Bcc.Add(f));
        //    }
        //    if (AttachmentCollection.Any())
        //    {
        //        AttachmentCollection.ForEach(at => mailMessage.Attachments.Add(at.CrateAttachment()));
        //    }
        //    mailMessage.Body = Body;
        //    mailMessage.Subject = Subject;
        //    mailMessage.IsBodyHtml = IsBodyHtml;
        //    return mailMessage;
        //}

        //protected virtual IEnumerable<string> ParseMailAdresses(string parameter)
        //{
        //    if (!parameter.Contains(Seperator)) return new[] { parameter };
        //    var result = parameter.Split(Seperator);
        //    return result;
        //}

       
    }
}
