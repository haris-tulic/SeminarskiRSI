using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Autoprevoznicko_preduzece_HTS.Model;
using WebAutoprevozncniko.ViewModels;
using Microsoft.AspNetCore.Http;
using WebAutoprevozncniko.Helper;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAutoprevozncniko.Controllers
{
    [Autorizacija(vozac: false, uprava: true)]
    public class VozacController : Controller
    {
        public IActionResult Index()
        {
            Login korisnik = HttpContext.GetLogiraniKorisnik();
            if (korisnik == null) {
                TempData["error_poruka"] = " Nemate pravo pristupa ";
                return RedirectToAction("Index","Autentifikacija");
            }
            return View();
        }
        public IActionResult PrikazVozaca()
        {
            MyContext db = new MyContext();
            List<VozacPrikaziVM> vozaci = db.vozac.Select(v => new VozacPrikaziVM
            {
                ID = v.ID,
                Ime = v.Ime,
                Prezime = v.Prezime,
                DatumRodjenja = v.DatumRodjenja,
                email = v.email,
                VozackaKategorija = v.VozackaKategorija,
                login = v.login.KorisnickoIme
            }).ToList();

            ViewData["vozaci"] = vozaci;
            return View();
        }
        public IActionResult PretragaVozaca()
        {
            MyContext db = new MyContext();


            VozacPretragaVM model = new VozacPretragaVM
            {
               
                vozaci = db.vozac.Select(x => new SelectListItem 
                {
                    Value = x.ID.ToString(),
                    Text = x.login.KorisnickoIme,
                    
                }).ToList(),
                
            };


            return View(model);
        }
         public IActionResult DodajVozaca()
        {
            MyContext db = new MyContext();
            List<ComboBox> login = db.login.Select(v => new ComboBox
            {
                ID = v.ID,
                naziv=v.KorisnickoIme
             
            }).ToList();
            ViewData["Login"] = login;
            return View();
        }
        public IActionResult SpasiVozaca(string Ime,string Prezime,DateTime DatumRodjenja,string email,string VozackaKategorija,int loginID)
        {
            MyContext db = new MyContext();
            Vozac v = new Vozac
            {
                Ime = Ime,
                Prezime = Prezime,
                DatumRodjenja = DatumRodjenja,
                email = email,
                VozackaKategorija = VozackaKategorija,
                loginID=loginID

            };
            db.Add(v);
            db.SaveChanges();
            TempData["ImeIPrezime"] = v.Ime + " " + v.Prezime;
            EmailController.SendEmail(v.email, "Dodavanje vozaca", "Uspjesno ste dodali vozaca " + v.Ime + " " + v.Prezime);
            return Redirect(url: "/Vozac/SpasiPoruka");
        }
        public IActionResult SpasiPoruka()
        {
            return View();
        }
        public IActionResult ObrisiVozaca(int VozacID)
        {
            MyContext db = new MyContext();
            Vozac v = db.vozac.Find(VozacID);
            db.Remove(v);
            db.SaveChanges();
            TempData["ImeIPrezime"] = v.Ime + " " + v.Prezime;
            return Redirect(url: "/Vozac/ObrisiPoruka");
        }
        public IActionResult ObrisiPoruka()
        {
            return View();
        }
        public IActionResult UrediVozaca(int VozacID)
        {
            MyContext db = new MyContext();
            Vozac v = db.vozac.Find(VozacID);
            ViewData["vozac"] = v;
            List<ComboBox> login = db.login.Select(v => new ComboBox
            {
                ID = v.ID,
                naziv = v.KorisnickoIme

            }).ToList();
            ViewData["Login"] = login;
            return View();
        }
        public IActionResult SpasiUredi(int VozacID,string Ime,string Prezime,DateTime DatumRodjenja,string email,string VozackaKategorija,int loginID)
        {
            MyContext db = new MyContext();
            Vozac v = db.vozac.Find(VozacID);
            if (VozacID != 0)
            {
                v.Ime = Ime;
                v.Prezime = Prezime;
                v.DatumRodjenja = DatumRodjenja;
                v.email = email;
                v.VozackaKategorija = VozackaKategorija;
                v.loginID = loginID;
            }
            db.SaveChanges();
            db.Dispose();
            return Redirect(url: "/Vozac/UrediPoruka");
        }
        public IActionResult UrediPoruka()
        {
            return View();
        }
    }
}
