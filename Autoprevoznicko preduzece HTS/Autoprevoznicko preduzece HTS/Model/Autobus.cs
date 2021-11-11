using System;
using System.Collections.Generic;
using System.Text;

namespace Autoprevoznicko_preduzece_HTS.Model
{
   public class Autobus
    {
        public int ID { get; set; }
        public int RedniBrojAutobusa { get; set; }
        public int BrojSjedila { get; set; }
        public int GodisteAutobusa { get; set; }
        public string informacije { get; set; }
        
    }
}
