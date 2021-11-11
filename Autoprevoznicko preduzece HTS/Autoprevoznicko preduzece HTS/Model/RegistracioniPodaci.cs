using System;
using System.Collections.Generic;
using System.Text;

namespace Autoprevoznicko_preduzece_HTS.Model
{
   public class RegistracioniPodaci
    {
        public int ID { get; set; }
        public Autobus autobus { get; set; }
        public int autobusID { get; set; }
        public int registracijskibroj { get; set; }
        public string PolisaOsiguranja { get; set; }
        public string tehnickipregled { get; set; }
        public Uprava uprava { get; set; }
        public int upravaID { get; set; }
    }
}
