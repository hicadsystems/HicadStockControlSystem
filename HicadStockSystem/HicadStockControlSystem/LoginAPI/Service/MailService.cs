using LoginAPI.Common;
using LoginAPI.IService;
using LoginAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LoginAPI.Service
{
    public class MailService : IMailService
    {
        public string GetMailBody(LoginInfo ologinInfo)
        {
            string url = Global.DomainName + "https://localhost:44333/api/LoginInfo/confirmMail?username=" + ologinInfo.UserName;
            return string.Format(@"<div style='text-align:center;'>
                                     <h1>Welcome to our web Site</h1>
                                     <h3>Click Below button to verify your Email Id</h3>
                                     <form method='post' action='{0}' style='display:inline;'>
                                        <button type='submit' style='display:block; text-align:center;
                                            font-weight:bold;
                                            bacground-color:#008CBA;
                                            font-size:16px;
                                            border-radious:10px;
                                            cursor:pointer;
                                            width:100%;
                                            padding:10px'> confirm Mail
                                        </button>
                                    </form>
                                 </div>", url, ologinInfo.UserName);
        }

        public async Task<string> SendMail(MailClass omailClass)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(omailClass.FromMailId);
                    omailClass.ToMailIds.ForEach(x =>
                    {
                        mail.To.Add(x);
                    });
                    mail.Subject = omailClass.MailSubject;
                    mail.Body = omailClass.MailBody;
                    mail.IsBodyHtml = omailClass.IsMailHtml;
                    omailClass.Attachments.ForEach(x =>
                    {
                        mail.Attachments.Add(new Attachment(x));
                    });
                    using (SmtpClient smtp=new SmtpClient("mail.brainobrainnigeria.com", 587))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential(omailClass.FromMailId, omailClass.FromMailIdPassword);
                        smtp.EnableSsl = true;
                        await smtp.SendMailAsync(mail);
                        return Message.MailSent;
                    }
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
