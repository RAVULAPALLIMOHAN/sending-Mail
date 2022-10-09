using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using sendingmails.Models;
using System.Net.Mail;

namespace sendingmails.Controllers
{
    public class SendMailController : ApiController
    {
        public IHttpActionResult sendMail(mailClass mc)
        {
            MailMessage mm = new MailMessage();
            mm.To.Add(mc.To);
            mm.From = new MailAddress("ravulapallimohan006@gmail.com");
            mm.Subject = mc.Subject;
            mm.Body = mc.Body;
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = true;
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("ravulapallimohan006@gmail.com", "123456789@Aa");
            smtp.Send(mm);

            return Ok();
        }
    }
}
