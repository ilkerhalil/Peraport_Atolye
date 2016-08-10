using System.IO;
using System.Net.Mail;

namespace EmailSender
{
    public class PeraportAttachment
    {
        private readonly string _fileName;
        private readonly byte[] _content;

        public PeraportAttachment(string fileName, byte[] content)
        {
            _fileName = fileName;
            _content = content;
        }

        public Attachment CrateAttachment()
        {
            var memoryStream = new MemoryStream(_content);
            return new Attachment(memoryStream, _fileName);
        }
    }
}