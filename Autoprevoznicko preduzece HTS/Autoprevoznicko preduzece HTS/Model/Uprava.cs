using System;
using System.Collections.Generic;
using System.Text;

namespace Autoprevoznicko_preduzece_HTS.Model
{
   public class Uprava
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string email { get; set; }
        public Login login { get; set; }
        public int loginID { get; set; }


    }
}
