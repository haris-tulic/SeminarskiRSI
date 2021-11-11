using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAutoprevozncniko.ViewModels
{
    public class CjenovnikPrikaziVM
    {
        public int ID { get; set; }
        public int zona { get; set; }
        public string VrstaKarte { get; set; }
        public string tipKarte { get; set; }
        public float Cijena { get; set; }
    }
}
