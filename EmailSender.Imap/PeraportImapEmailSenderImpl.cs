using System;
using System.Threading;
using AE.Net.Mail;
using EmailSender.Helper;
using EmailSender.Interfaces;

namespace EmailSender.Imap
{
    public class PeraportImapEmailSenderImpl : BasePeraportEmailSender
    {
        private ImapClient _imapClient;
        public PeraportImapEmailSenderImpl()
        {

        }

        protected override void ValidateAndSetHostPort()
        {
            Host.NullGuard();
        }

        protected override void ValidateAndSetCredational()
        {
            UserName.NullGuard();
            Password.NullGuard();

        }

        protected override void SendEmailImpl(BasePeraportMailMessage basePeraportMailMessage)
        {
            _imapClient = new ImapClient(Host, UserName, Password, port: Port);
            _imapClient.Ma

        }
    }
}
