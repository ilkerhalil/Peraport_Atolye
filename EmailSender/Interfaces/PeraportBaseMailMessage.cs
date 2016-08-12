using System;
using System.Linq;
using EmailSender.Common;

namespace EmailSender.Interfaces
{
    public abstract class PeraportBaseMailMessage
    {

        public virtual string From { get; set; }
        public virtual PeraportMailAddressCollection To { get; }
        public virtual PeraportMailAddressCollection Cc { get; }
        public virtual PeraportMailAddressCollection Bcc { get; }
        public virtual string Subject { get; set; }
        public virtual string Body { get; set; }
        public virtual bool IsBodyHtml { get; set; }
        public virtual PeraportAttachmentCollection AttachmentCollection { get; }

        protected PeraportBaseMailMessage()
        {
            AttachmentCollection = new PeraportAttachmentCollection();
            To = new PeraportMailAddressCollection();
            Cc = new PeraportMailAddressCollection();
            Bcc = new PeraportMailAddressCollection();
        }




    }
}
