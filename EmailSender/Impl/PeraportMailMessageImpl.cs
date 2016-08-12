namespace EmailSender
{
    public class PeraportMailMessageImpl : PeraportBaseMailMessage
    {
        public PeraportMailMessageImpl(string from, string[] to, string subject, string body) : base(from, to, subject, body)
        {
        }
    }
}