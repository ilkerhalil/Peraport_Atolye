namespace EmailSender
{
    public interface IPeraportEmailSender
    {
        void SendEmail(PeraportBaseMailMessage peraportMailMessage);
    }
}