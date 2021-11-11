using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoprevoznicko_preduzece_HTS.Model;
using Microsoft.AspNetCore.Mvc;
using Nexmo.Api;
using WebAutoprevozncniko.ViewModels;

namespace WebAutoprevozncniko.Controllers
{
    public class SMSController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Send(int KupacId)
        {
            MyContext db = new MyContext();
            Kupac k = db.kupac.Where(x => x.ID == KupacId).FirstOrDefault();
            ViewData["kupac"] = k;
            return View();
        }

        [HttpPost]
        public ActionResult Send(string to, string text, string telefon)
        {
            var client = new Client(creds: new Nexmo.Api.Request.Credentials
            {
                ApiKey = "62526b17",
                ApiSecret = "rYKHuG0B5GiinSZd"
            });
            //var results = client.SMS.Send(request: new SMS.SMSRequest
            //{
            //    from = "Vonage APIs",
            //    to = "38761981256",
            //    text = "Hello from Vonage SMS API"
            //});

            var results = client.SMS.Send(new SMS.SMSRequest
            {

                //from = Configuration.Instance.Settings["appsettings:NEXMO_FROM_NUMBER"],
                from = "Vonage APIs",
                to = to,
                text = text
            });

            MyContext db = new MyContext();
            Kupac k = db.kupac.FirstOrDefault(x => x.telefon == to);
            ViewData["kupac"] = k;
            return View();
        }
        public ActionResult PosaljiSMS(string to, string text)
        {
            //var results = SMS.Send(new SMS.SMSRequest
            //{
            //    from = Configuration.Instance.Settings["appsettings:NEXMO_FROM_NUMBER"],
            //    to = to,
            //    text = text
            //});
            var client = new Client(creds: new Nexmo.Api.Request.Credentials
            {
                ApiKey = "62526b17",
                ApiSecret = "rYKHuG0B5GiinSZd"
            });
            var results = client.SMS.Send(request: new SMS.SMSRequest
            {
                from = "Vonage APIs",
                to = "38761981256",
                text = "Hello from Vonage SMS API"
            });
            return RedirectToAction("PrikaziKupce", "Kupac");
        }
    }
}