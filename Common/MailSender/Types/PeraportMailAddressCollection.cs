using System.Collections.Generic;
using EmailSender.Common;

namespace Common.MailSender.Types
{
    public class PeraportMailAddressCollection : List<PeraportMailAddress>
    {
        public void Add(string mailAddress)
        {
            this.Add(mailAddress, mailAddress);
        }
        public void Add(string mailAddress, string displayName)
        {
            this.Add(new PeraportMailAddress(mailAddress, displayName));
        }

    }
}