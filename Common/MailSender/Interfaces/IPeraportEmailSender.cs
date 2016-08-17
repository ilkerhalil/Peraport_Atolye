namespace Common.MailSender.Interfaces
{
    public interface IPeraportEmailSender
    {
        void SendEmail(BasePeraportMailMessage basePeraportMailMessage);
    }
}