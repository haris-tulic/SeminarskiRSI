using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WebAutoprevozncniko.Helper;
using Microsoft.AspNetCore.Mvc;

namespace WebAutoprevozncniko.Controllers
{
    //[Autorizacija(roditelj: false, profesor: false, administrator: true)]
    public class EmailController : Controller
    {
        //public ActionResult SendEmail()
        //{
                //ne unosimo putem forme
        //    return View();
        //}

        public static bool SendEmail(string receiver, string subject, string message)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    var senderEmail = new MailAddress("web.autoprevoznicko@gmail.com", "webAutoprevoznicko");
                    var receiverEmail = new MailAddress(receiver, "Receiver");
                    var password = "WebAutoprevoznicko21";
                    var sub = subject;
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                //      return RedirectToAction("Index", "Home");
                return true;
                //}   

            }
            catch (Exception)
            {
                return false;
                //ViewBag.Error = "Some Error";

            }
            //return RedirectToAction("Index", "Home");
        }
    }
}