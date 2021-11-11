using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Autoprevoznicko_preduzece_HTS.Model;
using WebAutoprevozncniko.ViewModels;
using WebAutoprevozncniko.Helper;

namespace WebAutoprevozncniko.Controllers
{
    [Autorizacija(vozac: true, uprava: true)]
    public class KartaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListaKarata()
        {
            MyContext db = new MyContext();
            List<KartaPrikaziVM> karta = db.karta.Select(k => new KartaPrikaziVM
            {
                ID = k.ID,
                ime = k.kupac.ime,
                prezime = k.kupac.prezime,
                tipKarte = k.tipKarte.naziv,
                vrstaKarte = k.vrstaKarte.naziv,
                DatumVadjenja = k.DatumVadjenjaKarte,
                datumVazenja = k.DatumVazenjaKarte,
                zona =k.gradskaLinija.zona.BrojZone
            }).ToList();
            ViewData["Karte"] = karta;
            return View();
        }
        public IActionResult PrikazPutnika()
        {
            MyContext db = new MyContext();
            //    List<ZonaVM> zone = db.zona.Select(z => new ZonaVM
            //    {
            //        ID = z.ID,
            //        BrojZone = z.BrojZone
            //    }).ToList();
            //    ViewData["zone"] = zone;
            //    return View();

            ZonaPrikazVM model = new ZonaPrikazVM
            {
                zone = db.zona.Select(x => new SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.BrojZone.ToString()
                }).ToList()
            };

           

            return View(model);
        }
        public IActionResult DodajKartu()
        {
            MyContext db = new MyContext();
            //List<ComboBox> ime = db.kupac.Select(k => new ComboBox
            //{
            //    ID = k.ID,
            //    naziv = k.ime
            //}).ToList();
            //ViewData["ime"] = ime;
            //List<ComboBox> prezime = db.kupac.Select(k => new ComboBox
            //{
            //    ID = k.ID,
            //    naziv = k.prezime
            //}).ToList();
            //ViewData["prezime"] = prezime;
            List<ComboBox> kupac = db.kupac.Select(k => new ComboBox
            {
                ID = k.ID,
                naziv = k.ime + " " + k.prezime
            }).ToList();
            ViewData["Kupac"] = kupac;

            List<ComboBox> tipKarte = db.tipKarte.Select(tk => new ComboBox
            {
                ID = tk.ID,
                naziv = tk.naziv
            }).ToList();
            ViewData["TipKarte"] = tipKarte;
            List<ComboBox> VrstaKarte = db.vrstaKarte.Select(vk => new ComboBox
            {
                ID = vk.ID,
                naziv = vk.naziv
            }).ToList();
            ViewData["VrstaKarte"] = VrstaKarte;

            List<ComboBox> gradskeLinije = db.gradskeLinije.Select(gl => new ComboBox
            {
                ID = gl.ID,
                naziv = gl.zona.BrojZone.ToString()
            }).ToList();
            ViewData["Zona"] = gradskeLinije;
          
            return View();
        }
        public IActionResult SpasiKartu(
            int RbKarte,
            //int imeID,
            //int prezimeID,
            int kupacID,
            int TipKarteID,
            int VrstaKarteID,
            DateTime DatumVadjenja,
            DateTime DatumVazenja,
            int ZonaID
            )
        {
            MyContext db = new MyContext();
            Karta k = new Karta
            {
                kupacID = kupacID,
                tipKarteID = TipKarteID,
                vrstaKarteID = VrstaKarteID,
                DatumVadjenjaKarte = DatumVadjenja,
                DatumVazenjaKarte = DatumVazenja,
                gradskaLinijaID = ZonaID
            };
            db.Add(k);
            db.SaveChanges();
            db.Dispose();
            return Redirect(url: "/Karta/SpasiPoruka");
        }
        public IActionResult SpasiPoruka()
        {
            return View();
        }
        public IActionResult Obrisi(int ID)
        {
            MyContext db = new MyContext();
            Karta k = db.karta.Find(ID);
            db.Remove(k);
            db.SaveChanges();
            return Redirect(url: "/Karta/ObrisiPoruka");
        }
        public IActionResult ObrisiPoruka()
        {
            return View();
        }
        public IActionResult Uredi(int ID)
        {
            MyContext db = new MyContext();
            List<ComboBox> kupac = db.kupac.Select(k => new ComboBox
            {
                ID = k.ID,
                naziv = k.ime + " " + k.prezime
            }).ToList();
            ViewData["Kupac"] = kupac;

            List<ComboBox> tipKarte = db.tipKarte.Select(tk => new ComboBox
            {
                ID = tk.ID,
                naziv = tk.naziv
            }).ToList();
            ViewData["TipKarte"] = tipKarte;
            List<ComboBox> VrstaKarte = db.vrstaKarte.Select(vk => new ComboBox
            {
                ID = vk.ID,
                naziv = vk.naziv
            }).ToList();
            ViewData["VrstaKarte"] = VrstaKarte;

            List<ComboBox> gradskeLinije = db.gradskeLinije.Select(gl => new ComboBox
            {
                ID = gl.ID,
                naziv = gl.zona.BrojZone.ToString()
            }).ToList();
            ViewData["Zona"] = gradskeLinije;
            Karta k = db.karta.Find(ID);
            ViewData["Karta"] = k;
            return View();
        }
        public IActionResult UrediKartu(
            int ID,
            int RbKarte,
            int kupacID,
            int TipKarteID,
            int VrstaKarteID,
            DateTime DatumVadjenja,
            DateTime DatumVazenja,
            int ZonaID
            )
        {
            MyContext db = new MyContext();
            Karta k = db.karta.Find(ID);
            if (ID != 0)
            {
                k.kupacID = kupacID;
                k.tipKarteID = TipKarteID;
                k.vrstaKarteID = VrstaKarteID;
                k.DatumVadjenjaKarte = DatumVadjenja;
                k.DatumVazenjaKarte = DatumVazenja;
                k.gradskaLinijaID = ZonaID;
            }
            db.SaveChanges();
            db.Dispose();
            return Redirect(url: "/Karta/UrediPoruka");
        }
        public IActionResult UrediPoruka()
        {
            return View();
        }
    }
}