using Common.Helper;

namespace Common.MailSender.Interfaces
{
    public abstract class BasePeraportEmailSender : IPeraportEmailSender
    {
        public virtual string Host { get; set; }

        public virtual int Port { get; set; }

        public virtual string UserName { get; set; }

        public virtual string Password { get; set; }
        public virtual void SendEmail(BasePeraportMailMessage basePeraportMailMessage)
        {
            ValidateMailMessage(basePeraportMailMessage);
            ValidateAndSetCredational();
            ValidateAndSetHostPort();
            SendEmailImpl(basePeraportMailMessage);
        }

        protected virtual void ValidateMailMessage(BasePeraportMailMessage mailMessage)
        {
            mailMessage.NullGuard();
        }


        protected abstract void ValidateAndSetHostPort();


        protected abstract void ValidateAndSetCredational();

        protected abstract void SendEmailImpl(BasePeraportMailMessage basePeraportMailMessage);
    }
}