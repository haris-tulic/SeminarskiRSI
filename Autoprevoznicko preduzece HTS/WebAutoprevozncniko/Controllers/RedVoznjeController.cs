using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Autoprevoznicko_preduzece_HTS.Model;
using WebAutoprevozncniko.ViewModels;
using WebAutoprevozncniko.Helper;

namespace WebAutoprevozncniko.Controllers
{
    //[Autorizacija(vozac: true, uprava: true)]
    public class RedVoznjeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult RasporedVoznje()
        {
            MyContext db = new MyContext();
            List<RedVoznjePrikazVM> redVoznje = db.redVoznje.Select(rv => new RedVoznjePrikazVM
            {
                ID = rv.ID,
                LinijaPolaska = rv.gradskaLinija.StanicaPolaska.nazivLokacijeStanice,
                LinijaDolaska = rv.gradskaLinija.StanicaDolaska.nazivLokacijeStanice,
                vrijemePolaska = rv.VrijemePolaska
            }).ToList();
            ViewData["redVoznje"] = redVoznje;
            return View();
        }
        public IActionResult DodajRedVoznje()
        {
            MyContext db = new MyContext();
            List<ComboBox> linija = db.gradskeLinije.Select(gl => new ComboBox
            {
                ID = gl.ID,
                naziv = gl.StanicaPolaska.nazivLokacijeStanice + " - " + gl.StanicaDolaska.nazivLokacijeStanice
            }).ToList();
            ViewData["linija"] = linija;
            return View();
        }
        public IActionResult SpasiRedVoznje(
            int linijaID,
            DateTime vrijemePolaska
            )
        {
            MyContext db = new MyContext();
            RedVoznje rv = new RedVoznje
            {
                gradskaLinijaID = linijaID,
                VrijemePolaska = vrijemePolaska
            };
            db.Add(rv);
            db.SaveChanges();
            db.Dispose();
            return Redirect(url: "/RedVoznje/SpasiPoruka");
        }
        public IActionResult SpasiPoruka()
        {
            return View();
        }
        public IActionResult Obrisi(int ID)
        {
            MyContext db = new MyContext();
            RedVoznje rv = db.redVoznje.Find(ID);
            db.Remove(rv);
            db.SaveChanges();
            return Redirect(url: "/RedVoznje/ObrisiPoruka");
        }
        public IActionResult ObrisiPoruka()
        {
            return View();
        }
        public IActionResult Uredi(int ID)
        {
            MyContext db = new MyContext();
            RedVoznje rv = db.redVoznje.Find(ID);
            ViewData["redvoznje"] = rv;
            List<ComboBox> linija = db.gradskeLinije.Select(gl => new ComboBox
            {
                ID = gl.ID,
                naziv = gl.StanicaPolaska.nazivLokacijeStanice + " - " + gl.StanicaDolaska.nazivLokacijeStanice
            }).ToList();
            ViewData["linija"] = linija;
            return View();
        }
        public IActionResult SpasiUredi(int ID, int linijaID, DateTime vrijemePolaska)
        {
            MyContext db = new MyContext();
            RedVoznje rv = db.redVoznje.Find(ID);
            if (ID != 0)
            {
                rv.gradskaLinijaID = linijaID;
                rv.VrijemePolaska = vrijemePolaska;
            }
            db.SaveChanges();
            db.Dispose();
            return Redirect(url: "/RedVoznje/UrediPoruka");
        }
        public IActionResult UrediPoruka()
        {
            return View();
        }
    }
}


