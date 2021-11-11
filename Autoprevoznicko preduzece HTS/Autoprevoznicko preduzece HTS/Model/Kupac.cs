using System;
using System.Collections.Generic;
using System.Text;

namespace Autoprevoznicko_preduzece_HTS.Model
{
    public class Kupac
    {
        public int ID { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string telefon { get; set; }
        public string email { get; set; }
        public Grad grad { get; set; }
        public int gradID { get; set; }
    }
}
