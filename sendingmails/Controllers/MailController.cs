using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using sendingmails.Models;

namespace sendingmails.Controllers
{
    public class MailController : Controller
    {
        // GET: Mail
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(mailClass mc)
        {
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri("http://localhost:58688/api/SendMail");

            var useApi = http.PostAsJsonAsync<mailClass>("SendMail", mc);
            useApi.Wait();
            //http://localhost:58688/api/Email
            var sendMail =useApi.Result;
            if(sendMail.StatusCode != null)
            {
                ViewBag.result = "The mail status is" + sendMail.StatusCode+","+ mc.To.ToString();
            }

            return View();
        }
    }
}