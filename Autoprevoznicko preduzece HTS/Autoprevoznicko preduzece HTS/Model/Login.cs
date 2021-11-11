using System;
using System.Collections.Generic;
using System.Text;

namespace Autoprevoznicko_preduzece_HTS.Model
{
   public class Login
    {
        public int ID { get; set; }
        public string KorisnickoIme { get; set; }
        public string Sifra { get; set; }
        public bool ZapamtiSifru { get; set; }

        
    }
}
