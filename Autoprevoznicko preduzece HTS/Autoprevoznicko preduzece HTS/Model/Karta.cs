using System;
using System.Collections.Generic;
using System.Text;

namespace Autoprevoznicko_preduzece_HTS.Model
{
  public class Karta
    {
        public int ID { get; set; }

        public Kupac kupac { get; set; }
        public int kupacID { get; set; }

        public TipKarte tipKarte { get; set; }
        public int tipKarteID { get; set; }

        public VrstaKarte vrstaKarte { get; set; }
        public int vrstaKarteID { get; set; }
        public DateTime DatumVadjenjaKarte { get; set; }
        public DateTime DatumVazenjaKarte { get; set; }

        public GradskeLinije gradskaLinija { get; set; }
        public int gradskaLinijaID { get; set; }
    }
}
