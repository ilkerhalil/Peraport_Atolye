using System.Collections.Generic;

namespace EmailSender
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