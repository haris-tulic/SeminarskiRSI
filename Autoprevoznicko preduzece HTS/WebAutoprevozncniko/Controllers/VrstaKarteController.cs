using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoprevoznicko_preduzece_HTS.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebAutoprevozncniko.Controllers
{
    public class VrstaKarteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListaVrstaKarata()
        {
            MyContext db = new MyContext();
            List<VrstaKarte> vrstaKarte = db.vrstaKarte.ToList();
            ViewData["VrstaKarte"] = vrstaKarte;
            return View();
        }
        public IActionResult DodajNovuVrstu()
        {
            return View();
        }
        public IActionResult SpasiVrstuKarte(string nazivVrste,string informacije)
        {
            MyContext db = new MyContext();
            VrstaKarte tk = new VrstaKarte
            {
                naziv = nazivVrste,
                Informacije = informacije
            };
            db.Add(tk);
            db.SaveChanges();
            TempData["vrstaKarte"] = nazivVrste;
            return Redirect(url: "/VrstaKarte/SpasiPoruka");
        }
        public IActionResult SpasiPoruka()
        {
            return View();
        }
        public IActionResult ObrisiVrstu(int ID)
        {
            MyContext db = new MyContext();
            VrstaKarte vk = db.vrstaKarte.Find(ID);
            db.Remove(vk);
            db.SaveChanges();
            TempData["VrstaKarte"] = vk.naziv;
            return Redirect(url: "/VrstaKarte/ObrisiPoruka");
        }
        public IActionResult ObrisiPoruka()
        {
            return View();
        }
        public IActionResult UrediVrstu(int ID)
        {
            MyContext db = new MyContext();
            VrstaKarte vk = db.vrstaKarte.Find(ID);
            ViewData["VrstaKarte"] = vk;
            return View();
        }
        public IActionResult SpasiUredjivanjeVrste(int ID,string nazivVrste,string informacije)
        {
            MyContext db = new MyContext();
            VrstaKarte vk = db.vrstaKarte.Find(ID);
            if(ID != 0)
            {
                vk.naziv = nazivVrste;
                vk.Informacije = informacije;
            }
            db.SaveChanges();
            db.Dispose();
            return Redirect(url: "/VrstaKarte/UrediPoruka");
        }
        public IActionResult UrediPoruka()
        {
            return View();
        }
    }
}
