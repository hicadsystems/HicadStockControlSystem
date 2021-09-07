using LoginAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI.IService
{
   public interface IMailService
    {
        Task<string> SendMail(MailClass omailClass);
        string GetMailBody(LoginInfo ologinInfo);
    }
}
