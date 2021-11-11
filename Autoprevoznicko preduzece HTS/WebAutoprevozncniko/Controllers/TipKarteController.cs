using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Autoprevoznicko_preduzece_HTS.Model;
using WebAutoprevozncniko.ViewModels;
namespace WebAutoprevozncniko.Controllers
{
    public class TipKarteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListaTipovaKarata()
        {
            MyContext db = new MyContext();
            List<TipKarte> tipKarte = db.tipKarte.ToList();
            ViewData["TipKarte"] = tipKarte;
            return View();
        }
        public IActionResult DodajNoviTip()
        {
            return View();
        }
        public IActionResult SpasiTipKarte(
            string nazivTipa,
            string informacije
            )
        {
            MyContext db = new MyContext();
            TipKarte tk = new TipKarte
            {
                naziv = nazivTipa,
                Informacije = informacije
            };
            db.Add(tk);
            db.SaveChanges();
            TempData["tipKarte"] = nazivTipa;
            return Redirect(url: "/TipKarte/SpasiPoruka");
        }
        public IActionResult SpasiPoruka()
        {
            return View();
        }
        public IActionResult ObrisiTip(int ID)
        {
            MyContext db = new MyContext();
            TipKarte tk = db.tipKarte.Find(ID);
            db.Remove(tk);
            db.SaveChanges();
            TempData["TipKarte"] = tk.naziv;
            return Redirect(url: "/TipKarte/ObrisiPoruka");
        }
        public IActionResult ObrisiPoruka()
        {
            return View();
        }
        public IActionResult UrediTip(int ID)
        {
            MyContext db = new MyContext();
            TipKarte tk = db.tipKarte.Find(ID);
            ViewData["TipKarte"] = tk;
            return View();
        }
        public IActionResult SpasiUredjivanjeTipa(
            int ID,
            string nazivTipa,
            string informacije
            )
        {
            MyContext db = new MyContext();
            TipKarte tk = db.tipKarte.Find(ID);
            if (ID != 0)
            {
                tk.naziv = nazivTipa;
                tk.Informacije = informacije;
            }
            db.SaveChanges();
            db.Dispose();
            return Redirect(url: "/TipKarte/UrediPoruka");
        }
        public IActionResult UrediPoruka()
        {
            return View();
        }
    }
}