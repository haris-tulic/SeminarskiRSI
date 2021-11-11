using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAutoprevozncniko.Reporti
{
    public class ReportKarta
    {
        public int RBkarte { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string tipKarte { get; set; }
        public string vrstaKarte { get; set; }
        public DateTime DatumVadjenja { get; set; }
        public DateTime datumVazenja { get; set; }
        public int zona { get; set; }

        public static List<ReportKarta> get()
        {
            return new List<ReportKarta> { };
        }
    }
}
