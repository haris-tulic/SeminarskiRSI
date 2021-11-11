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
    public class GradskeLinijeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListaLinija()
        {
            MyContext db = new MyContext();
            List<GradskaLinijaPrikaziVM> gradskeLinije = db.gradskeLinije.Select(gl => new GradskaLinijaPrikaziVM
            {
                ID = gl.ID,
                brojAutobusa = gl.BrojAutobusa.RedniBrojAutobusa,
                zona = gl.zona.ID,
                stanicaPolaska = gl.StanicaPolaska.nazivLokacijeStanice,
                stanicaDolaska = gl.StanicaDolaska.nazivLokacijeStanice
            }).ToList();
            ViewData["gradskeLinije"] = gradskeLinije;
            return View();
        }
        public IActionResult DodajLiniju()
        {
            MyContext db = new MyContext();
            List<ComboBox> brojAutobusa = db.autobus.Select(a => new ComboBox
            {
                ID = a.ID,
                naziv = a.RedniBrojAutobusa.ToString()
            }).ToList();
            ViewData["autobus"] = brojAutobusa;
            List<ZonaVM> zona = db.zona.Select(z => new ZonaVM
            {
                ID = z.ID,
                BrojZone = z.BrojZone
            }).ToList();
            ViewData["zona"] = zona;
            List<ComboBox> stanicaPolaska = db.stanica.Select(s => new ComboBox
            {
                ID = s.ID,
                naziv = s.nazivLokacijeStanice
            }).ToList();
            ViewData["stanicaPolaska"] = stanicaPolaska;
            List<ComboBox> stanicaDolaska = db.stanica.Select(s => new ComboBox
            {
                ID = s.ID,
                naziv = s.nazivLokacijeStanice
            }).ToList();
            ViewData["stanicaDolaska"] = stanicaDolaska;
            return View();
        }
        public IActionResult SpasiLiniju(
            int brojAutobusa,
            int zonaID,
            int stanicaPolaskaID,
            int stanicaDolaskaID
            )
        {
            MyContext db = new MyContext();
            GradskeLinije gl = new GradskeLinije
            {
                BrojAutobusaID = brojAutobusa,
                zonaID = zonaID,
                StanicaPolaskaID = stanicaPolaskaID,
                StanicaDolaskaID = stanicaDolaskaID
            };
            db.Add(gl);
            db.SaveChanges();
            db.Dispose();
            return Redirect(url: "/GradskeLinije/SpasiPoruka");
        }
        public IActionResult SpasiPoruka()
        {
            return View();
        }
        public IActionResult Obrisi(int ID)
        {
            MyContext db = new MyContext();
            GradskeLinije gl = db.gradskeLinije.Find(ID);
            db.Remove(gl);
            db.SaveChanges();
            return Redirect(url: "/GradskeLinije/ObrisiPoruka");

        }
        public IActionResult ObrisiPoruka()
        {
            return View();
        }
        public IActionResult Uredi(int ID)
        {
            MyContext db = new MyContext();
            GradskeLinije gl = db.gradskeLinije.Find(ID);
            ViewData["gradskaLinija"] = gl;
            List<ComboBox> brojAutobusa = db.autobus.Select(a => new ComboBox
            {
                ID = a.ID,
                naziv = a.RedniBrojAutobusa.ToString()
            }).ToList();
            ViewData["autobus"] = brojAutobusa;
            List<ZonaVM> zona = db.zona.Select(z => new ZonaVM
            {
                ID = z.ID,
                BrojZone = z.BrojZone
            }).ToList();
            ViewData["zona"] = zona;
            List<ComboBox> stanicaPolaska = db.stanica.Select(s => new ComboBox
            {
                ID = s.ID,
                naziv = s.nazivLokacijeStanice
            }).ToList();
            ViewData["stanicaPolaska"] = stanicaPolaska;
            List<ComboBox> stanicaDolaska = db.stanica.Select(s => new ComboBox
            {
                ID = s.ID,
                naziv = s.nazivLokacijeStanice
            }).ToList();
            ViewData["stanicaDolaska"] = stanicaDolaska;
            return View();
        }
        public IActionResult SpasiUredi(
            int ID,
             int brojAutobusa,
            int zonaID,
            int stanicaPolaskaID,
            int stanicaDolaskaID
            )
        {
            MyContext db = new MyContext();
            GradskeLinije gl = db.gradskeLinije.Find(ID);
            if (ID != 0)
            {
                gl.BrojAutobusaID = brojAutobusa;
                gl.zonaID = zonaID;
                gl.StanicaPolaskaID = stanicaPolaskaID;
                gl.StanicaDolaskaID = stanicaDolaskaID;
            }
            db.SaveChanges();
            db.Dispose();
            return Redirect(url: "/GradskeLinije/UrediPoruka");
        }
        public IActionResult UrediPoruka()
        {
            return View();
        }
    }
}

