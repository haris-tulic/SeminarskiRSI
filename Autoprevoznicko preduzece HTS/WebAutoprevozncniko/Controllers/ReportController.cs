using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Reporting;
using Autoprevoznicko_preduzece_HTS.Model;
using Microsoft.AspNetCore.Mvc;
using WebAutoprevozncniko.Reporti;

namespace WebAutoprevozncniko.Controllers
{
    public class ReportController : Controller
    {
        private MyContext _db;
        public ReportController(MyContext db)
        {
            _db = db;
        }

        public static List<ReportKarta> getKarta(MyContext db, int ID)
        {
            List<ReportKarta> podaci = db.karta.Where(x => x.ID == ID).Select(k => new ReportKarta
            {
                RBkarte = k.ID,
                ime = k.kupac.ime,
                prezime = k.kupac.prezime,
                vrstaKarte = k.vrstaKarte.naziv,
                tipKarte = k.tipKarte.naziv,
                DatumVadjenja = k.DatumVadjenjaKarte,
                datumVazenja = k.DatumVazenjaKarte,
                zona = k.gradskaLinija.zona.BrojZone

            }).ToList();

            return podaci;
        }
        public IActionResult Index(int ID)
        {

            LocalReport _localReport = new LocalReport("Reporti/Report1.rdlc");
            List<ReportKarta> podaci = getKarta(_db, ID);
            DataSet ds = new DataSet();
            _localReport.AddDataSource("DataSet1", podaci);

            Dictionary<string, string> parameters = new Dictionary<string, string>();


            ReportResult result = _localReport.Execute(RenderType.Pdf, parameters: parameters);
            return File(result.MainStream, "application/pdf");

        }
        public static List<reportAutobus> getAutobus(MyContext db, int ID) 
        {
            List<reportAutobus> prikaz = db.autobus.Where(a => a.ID == ID).Select(a => new reportAutobus 
            {
                RedniBrojAutobusa=a.RedniBrojAutobusa,
                GodisteAutobusa=a.GodisteAutobusa,
                BrojSjedila=a.BrojSjedila,
                informacije=a.informacije,
            }).ToList();
            return prikaz;
        }
        public IActionResult IndexA(int ID) 
        {
            LocalReport _localReport = new LocalReport("Reporti/ReportAutobus.rdlc");
            List<reportAutobus> prikaz = getAutobus(_db, ID);
            DataSet ds = new DataSet();
            _localReport.AddDataSource("DataSet1", prikaz);

            Dictionary<string, string> parameters = new Dictionary<string, string>();


            ReportResult result = _localReport.Execute(RenderType.Pdf, parameters: parameters);
            return File(result.MainStream, "application/pdf");
        }
    }
}
//vnd.openxmlformats-officedocument.spreadsheetml.sheet  --ekstenzija za excela