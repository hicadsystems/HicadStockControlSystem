using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI.Common
{
    public static class Message
    {
        public static string Success = "Success";
        public static string ErrorFound = "Error Fund";
        public static string UserAlreadyCreated = "User Already Created, Please Login";
        public static string VerifyMail = "User already created, please veryfy your given Mail Id";
        public static string InvalidUser = "Invalid user, Please create account";
        public static string MailSent = "Mail Sent";
        public static string UserCreatedVerifyMail = "User created, check mail. Click link and verify";
    }
}
