using EmailSender.Impl;
using EmailSender.Interfaces;

namespace EmailSender.Factories
{
    public static class PeraportEmailSenderFactory
    {

        public static IPeraportEmailSender CreateEmailSender()
        {
            return new PeraportSmtpClientEmailSender();
        }
    }
}
