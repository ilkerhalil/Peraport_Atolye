using Common.MailSender.Types;
using EmailSender.Common;

namespace Common.MailSender.Interfaces
{
    public abstract class BasePeraportMailMessage
    {

        public virtual string From { get; set; }
        public virtual PeraportMailAddressCollection To { get; }
        public virtual PeraportMailAddressCollection Cc { get; }
        public virtual PeraportMailAddressCollection Bcc { get; }
        public virtual string Subject { get; set; }
        public virtual string Body { get; set; }
        public virtual bool IsBodyHtml { get; set; }
        public virtual PeraportAttachmentCollection AttachmentCollection { get; }

        protected BasePeraportMailMessage()
        {
            AttachmentCollection = new PeraportAttachmentCollection();
            To = new PeraportMailAddressCollection();
            Cc = new PeraportMailAddressCollection();
            Bcc = new PeraportMailAddressCollection();
        }




    }
}
