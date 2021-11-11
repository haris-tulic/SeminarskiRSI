using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Autoprevoznicko_preduzece_HTS.Model;
using Microsoft.AspNetCore.Mvc;
using WebAutoprevozncniko.ViewModels;

namespace WebAutoprevozncniko.Controllers
{
    public class AutobusVozacController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PrikazAutobusVozac()
        {
            MyContext db = new MyContext();
            List<AutobusVozacVM> autobusvozac = db.autobusVozac.Select(av => new AutobusVozacVM
            {
                ID = av.ID,
                autobus = av.autobus.RedniBrojAutobusa,
                vozac = av.vozac.Ime+" "+av.vozac.Prezime,
                pocetak=av.pocetak,
                kraj=av.kraj,
                smjena=av.smjena
            }).ToList();
            ViewData["vozacautobus"] = autobusvozac;
            return View();
        }
        public IActionResult DodajAutobusVozac()
        {
            MyContext db = new MyContext();
            List<ComboBox> vozac = db.vozac.Select(v => new ComboBox
            {
                ID = v.ID,
                naziv = v.Ime+" "+v.Prezime
            }).ToList();
            ViewData["vozac"] = vozac;
            List<ComboBox> autobus = db.autobus.Select(a => new ComboBox
            {
                ID = a.ID,
                naziv = a.RedniBrojAutobusa.ToString()
            }).ToList();
            ViewData["autobus"] = autobus;

            return View();
        }
        public IActionResult SpasiAutobusVozac(int AutobusID,int VozacID,DateTime DatumPocetka,DateTime DatumZavrsetka,int Smjena)
        {
            MyContext db = new MyContext();
            AutobusVozac av = new AutobusVozac
            {
                autobusID = AutobusID,
                vozacID = VozacID,
                pocetak = DatumPocetka,
                kraj = DatumZavrsetka,
                smjena = Smjena
            };
            db.Add(av);
            db.SaveChanges();
            return Redirect(url: "/AutobusVozac/SpasiPoruka");
        }
        public IActionResult SpasiPoruka()
        {
            return View();
        }
        public IActionResult ObrisiAutobusVozac(int AutobusVozacID)
        {
            MyContext db = new MyContext();
            AutobusVozac av = db.autobusVozac.Find(AutobusVozacID);
            db.Remove(av);
            db.SaveChanges();
            return Redirect(url: "/AutobusVozac/ObrisiPoruka");
        }
        public IActionResult ObrisiPoruka()
        {
            return View();
        }
        public IActionResult UrediAutobusVozac(int AutobusVozacID)
        {
            MyContext db = new MyContext();
            AutobusVozac av = db.autobusVozac.Find(AutobusVozacID);
            ViewData["av"] = av;
            List<ComboBox> vozac = db.vozac.Select(v => new ComboBox
            {
                ID = v.ID,
                naziv = v.Ime + " " + v.Prezime
            }).ToList();
            ViewData["vozac"] = vozac;
            List<ComboBox> autobus = db.autobus.Select(a => new ComboBox
            {
                ID = a.ID,
                naziv = a.RedniBrojAutobusa.ToString()
            }).ToList();
            ViewData["autobus"] = autobus;

            return View();
        }
        public IActionResult SpasiUredi(int AutobusVozacID,int AutobusID, int VozacID, DateTime DatumPocetka, DateTime DatumZavrsetka, int Smjena)
        {
            MyContext db = new MyContext();
            AutobusVozac av = db.autobusVozac.Find(AutobusVozacID);
            if (AutobusVozacID != 0)
            {
                av.autobusID = AutobusID;
                av.vozacID = VozacID;
                av.pocetak = DatumPocetka;
                av.kraj = DatumZavrsetka;
                av.smjena = Smjena;
            }
            db.SaveChanges();
            db.Dispose();
            return Redirect(url: "/AutobusVozac/UrediPoruka");
        }
        public IActionResult UrediPoruka()
        {
            return View();
        }
    }
}

