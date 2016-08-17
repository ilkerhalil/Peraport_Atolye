using System;
 
using System.Text.RegularExpressions;
using Common.Properties;
 

namespace EmailSender.Common
{
    public class PeraportMailAddress
    {
        public string MailAddress { get; }
        public string DisplayName { get; }

        public PeraportMailAddress(string mailAddress)
            : this(mailAddress, mailAddress)
        {
        }

        public PeraportMailAddress(string mailAddress, string displayName)
        {
            if (!Regex.IsMatch(mailAddress, Resources.ValidEMailValidationRegEx))
            {
                throw new ArgumentOutOfRangeException(nameof(mailAddress), "Geçerli e-posta adresi giriniz.");
            }
            if (string.IsNullOrWhiteSpace(displayName)) throw new ArgumentNullException();
            MailAddress = mailAddress;
            DisplayName = displayName;
        }
    }
}
