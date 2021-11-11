using System;
using System.Collections.Generic;
using System.Text;

namespace Autoprevoznicko_preduzece_HTS.Model
{
   public class Cjenovnik
    {
        public int ID { get; set; }

        public Zona zona { get; set; }
        public int zonaID { get; set; }
        public VrstaKarte vrstaKarte { get; set; }
        public int vrstaKarteID { get; set; }

        public TipKarte tipkarte { get; set; }
        public int tipkarteID { get; set; }

        public float cijena { get; set; }
    }
}
