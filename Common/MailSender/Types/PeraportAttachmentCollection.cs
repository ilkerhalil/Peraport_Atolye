using System.Collections.Generic;

namespace Common.MailSender.Types
{
    public class PeraportAttachmentCollection : List<PeraportAttachment>
    {
        public PeraportAttachmentCollection() : base()
        {

        }

        public PeraportAttachmentCollection(IEnumerable<PeraportAttachment> collection)
            : base(collection)
        {

        }
    }
}