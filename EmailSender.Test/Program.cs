namespace EmailSender.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var emailSender = PeraportEmailSenderFactory.CreateEmailSender();
            var mailMessage = new PeraportMailMessageImpl();
            emailSender.SendEmail(mailMessage);

        }
    }
}
