using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginAPI.Common;
using LoginAPI.IService;
using LoginAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginInfoController : ControllerBase
    {
        private ILoginInfoService _loginInfoService;
        private IMailService _mailService;
        public LoginInfoController(ILoginInfoService loginInfoService, IMailService mailService)
        {
            _loginInfoService = loginInfoService;
            _mailService = mailService;
        }


        // POST api/LoginInfo
        [AllowAnonymous]
        [HttpPost("Signup")]
        public async Task<IActionResult> Signup([FromBody] LoginInfo ologinInfo)
        {
            string sMessage = "";
            var user = await _loginInfoService.SignUp(ologinInfo);
            if (user == null) return BadRequest(new { message = Message.ErrorFound });
            if (user.Message == Message.VerifyMail)
            {
                MailClass omailClass = this.GetMailObject(user);
                await _mailService.SendMail(omailClass);
                return BadRequest(new { message = Message.VerifyMail });
            }
            #region Send Confirmation Mail
            if (user.Message == Message.Success)
            {
                user.EmailId = ologinInfo.EmailId;
                user.UserName = ologinInfo.UserName;
                MailClass omailClass = this.GetMailObject(user);
                sMessage = await _mailService.SendMail(omailClass);
            }
            #endregion
            if (sMessage != Message.MailSent) return BadRequest(new { message = sMessage });
            else return Ok(new { message = Message.UserCreatedVerifyMail });
        }
       
        [AllowAnonymous]
        [HttpPost("ConfirmMail")]
        public async Task<IActionResult> ConfirmMail(string username)
        {
            string sMessage = await _loginInfoService.confirmMail(username);
            return Ok(new { message = sMessage });

        }

        public MailClass GetMailObject(LoginInfo user)
        {
            MailClass omailClass = new MailClass();
            omailClass.MailSubject = "Mail Confirmation";
            omailClass.MailBody = _mailService.GetMailBody(user);
            omailClass.ToMailIds = new List<string>()
            {
                user.EmailId
            };
            return omailClass;
        }
    }
}
