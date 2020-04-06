using DL.Core.Data;
using DL.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DL.Core.Util
{
    public class Mail
    {
        public static void Send(Email _email)
        {
            try
            {
                MailMessage email = new MailMessage();
                email.To.Add(new MailAddress(_email.recipient));
                email.From = new MailAddress("devloops.noreply@gmail.com");
                email.Subject = _email.subject;
                email.Body = _email.body;
                email.IsBodyHtml = true;
                SmtpClient cli = new SmtpClient("relay-hosting.secureserver.net", 25);
                using (cli)
                {
                    cli.Credentials = new System.Net.NetworkCredential("devloops.noreply@gmail.com", "DevLoops#01");
                    cli.EnableSsl = false;
                    cli.Send(email);
                }
                Log log = new Log() { msg = "Email sended to " + _email.recipient, date = DateTime.Now.ToString() };
                LogCommon.GetInstance().Create(log);
            }
            catch (Exception err)
            {
                Log log = new Log() { msg = err.ToString(), date = DateTime.Now.ToString() };
                LogCommon.GetInstance().Create(log);
            }
        }
    }
}
