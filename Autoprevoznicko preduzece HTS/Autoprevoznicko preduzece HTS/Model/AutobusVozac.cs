using System;
using System.Collections.Generic;
using System.Text;

namespace Autoprevoznicko_preduzece_HTS.Model
{
   public class AutobusVozac
    {
        public int ID { get; set; }
        public DateTime pocetak { get; set; }
        public DateTime kraj { get; set; }
        public int smjena { get; set; }
        public Autobus autobus { get; set; }
        public int autobusID { get; set; }

        public Vozac vozac { get; set; }
        public int vozacID { get; set; }
       
    }
}
