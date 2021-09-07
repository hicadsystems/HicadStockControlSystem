using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI.Models
{
    public class MailClass
    {

        public string FromMailId { get; set; } = "jt@brainobrainnigeria.com";
        public string FromMailIdPassword { get; set; } = "K0f1b@nd@";
        public List<string> ToMailIds { get; set; } = new List<string>();
        public string MailBody { get; set; } = "";
        public string MailSubject { get; set; } = "";
        public bool IsMailHtml { get; set; } = true;

        public List<string> Attachments { get; set; } = new List<string>();
    }
}
