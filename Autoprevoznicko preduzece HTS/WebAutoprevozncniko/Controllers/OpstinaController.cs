using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Autoprevoznicko_preduzece_HTS.Model;
using WebAutoprevozncniko.ViewModels;

namespace WebAutoprevozncniko.Controllers
{
    public class OpstinaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PrikaziOpstine()
        {
            MyContext db = new MyContext();
            List<OpstinaPrikaziWM> opstine = db.opstina.Select(o=>new OpstinaPrikaziWM
            {
                ID=o.ID,
                nazivOpstine=o.NazivOpstine,
                grad=o.grad.nazivGrada
            }).ToList();
            ViewData["opstine"] = opstine;
            return View();
        }
        public IActionResult DodajOpstinu()
        {
            MyContext db = new MyContext();
            List<GradoviWM> gradovi = db.grad.Select(g => new GradoviWM
            {
                ID = g.ID,
                naziv=g.nazivGrada
            }).ToList();
            ViewData["gradovi"] = gradovi;
            return View();
        }
        public IActionResult SpasiOpstinu(
            string nazivOpstine,
            int gradID
            )
        {
            MyContext db = new MyContext();
            Opstina o = new Opstina
            {
                NazivOpstine = nazivOpstine,
                gradID = gradID
            };
            db.Add(o);
            db.SaveChanges();
            TempData["opstina"] = o.NazivOpstine;
            return Redirect(url:"/Opstina/OpstinaPoruka");
        }
        public IActionResult OpstinaPoruka()
        {
            return View();
        }
        public IActionResult IzbrisiOpstinu(int ID)
        {
            MyContext db = new MyContext();
            Opstina o = db.opstina.Find(ID);
            db.Remove(o);
            db.SaveChanges();
            TempData["opstina"] = o.NazivOpstine;
            return Redirect(url:"/Opstina/IzbrisiPoruka");
        }
        public IActionResult IzbrisiPoruka()
        {
            return View();
        }
        public IActionResult UrediOpstinu(int ID)
        {
            MyContext db = new MyContext();
            List<GradoviWM> gradovi = db.grad.Select(g => new GradoviWM
            {
                ID = g.ID,
                naziv = g.nazivGrada
            }).ToList();
            ViewData["gradovi"] = gradovi;
            Opstina o = db.opstina.Find(ID);
            ViewData["opstina"] = o;
            return View();        
        }
        public IActionResult SpasiUredjivanje(
            int ID,
            string nazivOpstine,
            int gradID
            )
        {
            MyContext db = new MyContext();
            Opstina o = db.opstina.Find(ID);
            if (ID != 0)
            {
                o.NazivOpstine = nazivOpstine;
                o.gradID = gradID;
            }
            db.SaveChanges();
            db.Dispose();
            return Redirect(url: "/Opstina/UrediPoruka");
        }
        public IActionResult UrediPoruka()
        {
            return View();
        }
    }
}