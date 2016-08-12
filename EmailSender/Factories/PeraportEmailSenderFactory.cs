namespace EmailSender
{
    public static class PeraportEmailSenderFactory
    {

        public static IPeraportEmailSender CreateEmailSender()
        {
            return new PeraportSmtpClientEmailSender();
        }
    }
}
