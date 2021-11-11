using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoprevoznicko_preduzece_HTS.Model;
using WebAutoprevozncniko.ViewModels;
using Microsoft.AspNetCore.Mvc;
using WebAutoprevozncniko.Helper;
using Microsoft.AspNetCore.SignalR;
using WebAutoprevozncniko.Hubs;

namespace WebAutoprevozncniko.Controllers
{
    [Autorizacija(vozac: true, uprava: true)]
    public class AutobusController : Controller
    {
        private static IHubContext<NotifikacijskiHub> _hubContext;
        public AutobusController(IHubContext<NotifikacijskiHub> hub)
        {
            _hubContext = hub;
        }
        public static void NotificirajSignaIR(string poruka = "")
        {
            _hubContext.Clients.All.SendAsync("ReceiveNotification", poruka);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PrikaziAutobusa()
        {
            MyContext db = new MyContext();
            List<Autobus> autobusi = db.autobus.ToList();
            ViewData["AutobusiPrikaz"] = autobusi;
            return View();
        }
        public IActionResult DodajAutobus()
        {
            return View();

        }
        public IActionResult SpasiAutobus(int RedniBrojAutobusa,
            int BrojSjedista,
            int GodisteAutobusa,
            string Info)
        {
            MyContext db = new MyContext();
            Autobus autobus = new Autobus
            {
                RedniBrojAutobusa = RedniBrojAutobusa,
                BrojSjedila = BrojSjedista,
                GodisteAutobusa = GodisteAutobusa,
                informacije = Info
            };
            db.Add(autobus);
            db.SaveChanges();
            db.Dispose();
            TempData["Autobus"] = autobus.RedniBrojAutobusa;
           // return Redirect(url: "/Autobus/SpasiPoruka");
            NotificirajSignaIR("Dodan je novi autobus! ");
            return RedirectToAction("Index");
        }

        public IActionResult SpasiPoruka()
        {

            return View();
        }
        public IActionResult ObrisiAutobus(int ID)
        {
            MyContext db = new MyContext();
            Autobus a = db.autobus.Find(ID);
            db.Remove(a);
            db.SaveChanges();
            db.Dispose();
            TempData["Autobus"] = a.RedniBrojAutobusa;
            return Redirect(url: "/Autobus/ObrisiPoruka");
        }
        public IActionResult ObrisiPoruka()
        {
            return View();
        }
        public IActionResult UrediAutobus(int ID)
        {
            MyContext db = new MyContext();
            Autobus a = db.autobus.Find(ID);
            ViewData["Autobus"] = a;
            return View();
        }
        public IActionResult SpasiUredjivanje(int ID,
            int RedniBrojAutobusa,
                int BrojSjedista,
                    int GodisteAutobusa,
                       string Info)
        {
            MyContext db = new MyContext();
            Autobus a = db.autobus.Find(ID);
            if (ID!=0)
            {
                a.RedniBrojAutobusa = RedniBrojAutobusa;
                a.BrojSjedila = BrojSjedista;
                a.GodisteAutobusa = GodisteAutobusa;
                a.informacije = Info;
            }
            db.SaveChanges();
            db.Dispose();
            return Redirect(url: "/Autobus/UrediPoruka");
        }
        public IActionResult UrediPoruka()
        {
            return View();
        }
    }
}