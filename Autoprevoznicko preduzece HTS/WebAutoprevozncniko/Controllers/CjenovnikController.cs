using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoprevoznicko_preduzece_HTS.Model;
using Microsoft.AspNetCore.Mvc;
using WebAutoprevozncniko.Helper;
using WebAutoprevozncniko.ViewModels;

namespace WebAutoprevozncniko.Controllers
{
    //[Autorizacija(vozac: false, uprava: true)]
    public class CjenovnikController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListaCijena()
        {
            MyContext db = new MyContext();
            List<CjenovnikPrikaziVM> cjenovnik = db.cjenovnik.Select(c => new CjenovnikPrikaziVM
            {
                ID = c.ID,
                zona = c.zona.ID,
                VrstaKarte = c.vrstaKarte.naziv,
                tipKarte = c.tipkarte.naziv,
                Cijena = c.cijena
            }).ToList();
            ViewData["Cjenovnik"] = cjenovnik;
            return View();
        }
        public IActionResult Dodaj()
        {
            MyContext db = new MyContext();
            List<ZonaVM> zona = db.zona.Select(z => new ZonaVM
            {
                ID = z.ID,
                BrojZone = z.BrojZone
            }).ToList();
            ViewData["Zona"] = zona;
            List<ComboBox> vrstaKarte = db.vrstaKarte.Select(vk => new ComboBox
            {
                ID = vk.ID,
                naziv = vk.naziv
            }).ToList();
            ViewData["VrstaKarte"] = vrstaKarte;
            List<ComboBox> tipKarte = db.tipKarte.Select(tk => new ComboBox
            {
                ID = tk.ID,
                naziv = tk.naziv
            }).ToList();
            ViewData["TipKarte"] = tipKarte;
            return View();
        }
        public IActionResult SpasiDodavanje(
              int ZonaID,
            int VrstaKarteID,
            int tipKarteID,
            float Cijena
            )
        {
            MyContext db = new MyContext();
            Cjenovnik c = new Cjenovnik
            {
                zonaID = ZonaID,
                vrstaKarteID = VrstaKarteID,
                tipkarteID = tipKarteID,
                cijena = Cijena
            };
            db.Add(c);
            db.SaveChanges();
            return Redirect(url: "/Cjenovnik/SpasiPoruka");
        }
        public IActionResult SpasiPoruka()
        {
            return View();
        }
        public IActionResult Obrisi(int ID)
        {
            MyContext db = new MyContext();
            Cjenovnik c = db.cjenovnik.Find(ID);
            db.Remove(c);
            db.SaveChanges();
            return Redirect(url: "/Cjenovnik/ObrisiPoruka");
        }
        public IActionResult ObrisiPoruka()
        {
            return View();
        }
        public IActionResult Uredi(int ID)
        {
            MyContext db = new MyContext();
            List<ZonaVM> zona = db.zona.Select(z => new ZonaVM
            {
                ID = z.ID,
                BrojZone = z.BrojZone
            }).ToList();
            ViewData["Zona"] = zona;
            List<ComboBox> vrstaKarte = db.vrstaKarte.Select(vk => new ComboBox
            {
                ID = vk.ID,
                naziv = vk.naziv
            }).ToList();
            ViewData["VrstaKarte"] = vrstaKarte;
            List<ComboBox> tipKarte = db.tipKarte.Select(tk => new ComboBox
            {
                ID = tk.ID,
                naziv = tk.naziv
            }).ToList();
            ViewData["TipKarte"] = tipKarte;
            Cjenovnik c = db.cjenovnik.Find(ID);
            ViewData["Cjena"] = c;
            return View();
        }
        public IActionResult UrediDodavanje(
            int ID,
            int zonaID,
            int vrstaKarteID,
            int tipKarteID,
            float cijena
            )
        {
            MyContext db = new MyContext();
            Cjenovnik c = db.cjenovnik.Find(ID);
            if (ID != 0)
            {
                c.zonaID = zonaID;
                c.vrstaKarteID = vrstaKarteID;
                c.tipkarteID = tipKarteID;
                c.cijena = cijena;
            }
            db.SaveChanges();
            db.Dispose();
            return Redirect(url: "/Cjenovnik/urediPoruka");
        }
        public IActionResult urediPoruka()
        {
            return View();
        }
    }
}