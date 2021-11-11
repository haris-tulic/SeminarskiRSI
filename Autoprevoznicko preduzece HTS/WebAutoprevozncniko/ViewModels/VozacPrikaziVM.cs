using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAutoprevozncniko.ViewModels
{
    public class VozacPrikaziVM
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }

        public string email { get; set; }
        public string VozackaKategorija { get; set; }
        
        public string login { get; set; }
    }
}
