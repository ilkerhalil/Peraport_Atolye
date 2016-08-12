namespace EmailSender.Interfaces
{
    public interface IPeraportEmailSender
    {
        void SendEmail(PeraportBaseMailMessage peraportMailMessage);
    }
}