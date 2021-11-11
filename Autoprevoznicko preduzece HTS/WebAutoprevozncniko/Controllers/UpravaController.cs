using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Autoprevoznicko_preduzece_HTS.Model;
using Microsoft.AspNetCore.Mvc;
using WebAutoprevozncniko.ViewModels;
using WebAutoprevozncniko.Helper;


namespace WebApplicationAutoprevoznicko.Controllers
{
    public class UpravaController : Controller
    {
        public IActionResult Index()
        {
            Login korisnik = HttpContext.GetLogiraniKorisnik();
            if (korisnik == null)
            {
                TempData["error_poruka"] = " Nemate pravo pristupa ";
                return RedirectToAction("Index", "Autentifikacija");
            }
            return View();

        }
        public IActionResult PrikazUprave()
        {
            MyContext db = new MyContext();
            List<UpravaPrikaziVM> uprava = db.uprava.Select(u => new UpravaPrikaziVM
            {
                ID = u.ID,
                Ime = u.Ime,
                Prezime = u.Prezime,
                DatumRodjenja = u.DatumRodjenja,
                login = u.login.KorisnickoIme
            }).ToList();
            ViewData["uprava"] = uprava;
            return View();
        }
        public IActionResult DodajUprava()
        {
            MyContext db = new MyContext();
            List<ComboBox> login = db.login.Select(v => new ComboBox
            {
                ID = v.ID,
                naziv = v.KorisnickoIme

            }).ToList();
            ViewData["Login"] = login;
            return View();
        }
        public IActionResult SpasiUprava(string Ime,string Prezime,DateTime Datum,int loginID)
        {

            MyContext db = new MyContext();
            Uprava u = new Uprava
            {
               Ime=Ime,
               Prezime=Prezime,
               DatumRodjenja=Datum,
               loginID=loginID
            };
            db.Add(u);
            db.SaveChanges();
            TempData["ImeIprezime"] = u.Ime + " " + u.Prezime;
            return Redirect(url: "/Uprava/SpasiPoruka");
        }
        public IActionResult SpasiPoruka()
        {
            return View();
        }
        public IActionResult ObrisiUprava(int UpravaID)
        {
            MyContext db = new MyContext();
            Uprava u = db.uprava.Find(UpravaID);
            db.Remove(u);
            db.SaveChanges();
            TempData["ImeIprezime"] = u.Ime  + " "+ u.Prezime;
            return Redirect(url: "/Uprava/ObrisiPoruka");
        }
        public IActionResult ObrisiPoruka()
        {
            return View();
        }
        public IActionResult UrediUprava(int UpravaID)
        {
            MyContext db = new MyContext();
            Uprava u = db.uprava.Find(UpravaID);
            ViewData["uprava"] = u;
            List<ComboBox> login = db.login.Select(u => new ComboBox
            {
                ID = u.ID,
                naziv = u.KorisnickoIme

            }).ToList();
            ViewData["Login"] = login;
            return View();
        }
        public IActionResult SpasiUredi(int UpravaID,string Ime, string Prezime, DateTime Datum,int loginID)
        {
            MyContext db = new MyContext();
            Uprava u = db.uprava.Find(UpravaID);
            if (UpravaID != 0)
            {
                u.Ime = Ime;
                u.Prezime = Prezime;
                u.DatumRodjenja = Datum;
                u.loginID = loginID;
            }
            db.SaveChanges();
            db.Dispose();
            return Redirect(url: "/Uprava/UrediPoruka");
        }
        public IActionResult UrediPoruka()
        {
            return View();
        }
    }
}
