
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAutoprevozncniko.ViewModels
{
    public class KartaPrikaziVM
    {
        public int ID { get; set; }
        public int RBkarte { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string tipKarte { get; set; }
        public string vrstaKarte { get; set; }
        public DateTime DatumVadjenja { get; set; }
        public DateTime datumVazenja { get; set; }
        public int zona { get; set; }
    }
}
