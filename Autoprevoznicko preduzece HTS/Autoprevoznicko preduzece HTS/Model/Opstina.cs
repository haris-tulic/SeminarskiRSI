using System;
using System.Collections.Generic;
using System.Text;

namespace Autoprevoznicko_preduzece_HTS.Model
{
   public class Opstina
    {
        public int ID { get; set; }
        public string NazivOpstine { get; set; }
        public Grad grad { get; set; }
        public int gradID { get; set; }
    }
}
