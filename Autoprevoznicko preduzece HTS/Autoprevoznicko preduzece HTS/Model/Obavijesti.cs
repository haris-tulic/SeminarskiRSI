using System;
using System.Collections.Generic;
using System.Text;

namespace Autoprevoznicko_preduzece_HTS.Model
{
   public class Obavijesti
    {
        public int ID { get; set; }
        public string naslov { get; set; }
        public string sadrzaj { get; set; }
        public DateTime datumObjave { get; set; }

        public Uprava uprava { get; set; }
        public int upravaID { get; set; }
    }
}
