using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Autoprevoznicko_preduzece_HTS.Model;
using WebAutoprevozncniko.Helper;
using WebAutoprevozncniko.ViewModels;

namespace WebAutoprevozncniko.Controllers
{
    //[Autorizacija(vozac: false, uprava: true)]
    public class GradController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListaGradova()
        {
            MyContext db = new MyContext();
            try
            {
                GradPrikazVM ulazniPodaci = new GradPrikazVM();
                ulazniPodaci.ListaGradova = db.grad.Select(
                    o => new Grad
                    {
                        ID = o.ID,
                        nazivGrada=o.nazivGrada,
                        PostanskiBroj=o.PostanskiBroj
                    }
                    ).ToList();
                return View(ulazniPodaci);
            }
            catch (Exception e)
            {

                List<Vozac> l = db.vozac.ToList();
                foreach (Vozac v in l)
                    if (v.email != null)
                    {
                        string naslov = "Prikaz gradova";
                        string sadrzaj = "Problem s prikazom gradova" + e.Message;
                        string primalac = v.email;
                        EmailController.SendEmail(primalac, naslov, sadrzaj);
                    }

                //ili

                EmailController.SendEmail("adin.smajkic@gmail.com", "Prikaz gradova", "Problem s prikazom gradova");
                return RedirectToAction("Index", "Home");
            }

        }
        public IActionResult DodajUredi(int GradID)
        {
            MyContext db = new MyContext();
            try
            {
                GradDodajUredi ulazniPodaci = new GradDodajUredi();
                if (GradID != 0)
                {
                    Grad g = db.grad.Find(GradID);
                    ulazniPodaci.GradID = g.ID;
                    ulazniPodaci.naziv = g.nazivGrada;
                    ulazniPodaci.PostanskiBroj = g.PostanskiBroj;
                }
                return View(ulazniPodaci);
            }
            catch (Exception)
            {
                return RedirectToAction("ListaGradova");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Snimi(GradDodajUredi input)
        {
            MyContext db = new MyContext();
            if (!ModelState.IsValid)
            {
                return View("DodajUredi", input);
            }

            try
            {
                Grad g = db.grad.Where(o => o.nazivGrada == input.naziv).FirstOrDefault();
                if (g != null)
                {
                    TempData["greskaPoruka"] = "Nemoguće dulpliciranje gradova!";
                    return View("DodajUredi", input);
                }

                Grad grad;
                if (input.GradID == 0)
                {
                    grad = new Grad();
                    db.Add(grad);
                }
                else
                {
                    grad = db.grad.Find(input.GradID);
                }
                grad.ID = input.GradID;
                grad.nazivGrada = input.naziv;
                grad.PostanskiBroj = input.PostanskiBroj;
                db.SaveChanges();
                return RedirectToAction("ListaGradova");
            }
            catch (Exception)
            {
                return RedirectToAction("Prikaz");
            }
        }
        //public IActionResult DodajGrad()
        //{

        //    return View();

        //}
        //public IActionResult SpasiGrad(
        //        string NazivGrada,
        //        int PostanskiBroj
        //    )
        //{
        //    MyContext db = new MyContext();
        //    Grad g = new Grad
        //    {
        //        nazivGrada = NazivGrada,
        //        PostanskiBroj = PostanskiBroj
        //    };
        //    db.Add(g);
        //    db.SaveChanges();
        //    db.Dispose();
        //    TempData["Grad"] = NazivGrada;
        //    return Redirect(url: "/Grad/GradPoruka");
        //}
        //public IActionResult GradPoruka()
        //{
        //    return View();
        //}
        public IActionResult ObrisiGrad(int ID)
        {
            MyContext db = new MyContext();
            Grad g = db.grad.Find(ID);
            db.Remove(g);
            db.SaveChanges();
            db.Dispose();
            TempData["Grad"] = g.nazivGrada;
            
            return Redirect(url: "/Grad/ObrisiPoruka");
        }
        public IActionResult ObrisiPoruka()
        {
            return View();
        }
        //public IActionResult UrediGrad(int ID)
        //{
        //    MyContext db = new MyContext();
        //    Grad g = db.grad.Find(ID);
        //    ViewData["Grad"] = g;
        //    return View();
        //}
        //public IActionResult SpasiUredjivanje(
        //    int ID,
        //    string NazivGrada,
        //    int PostanskiBroj
        //    )
        //{
        //    MyContext db = new MyContext();
        //    Grad g = db.grad.Find(ID);
        //    if (ID != 0)
        //    {
        //        g.nazivGrada = NazivGrada;
        //        g.PostanskiBroj = PostanskiBroj;
        //    }
        //    db.SaveChanges();
        //    db.Dispose();
        //    return Redirect(url: "/Grad/UrediPoruka");
        //}
        //public IActionResult UrediPoruka()
        //{
        //    return View();
        //}
    }
}