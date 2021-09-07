using LoginAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI.IService
{
    public interface ILoginInfoService
    {
        Task<LoginInfo> SignUp(LoginInfo ologinInfo);
        Task<string> confirmMail(string userName);
    }
}
