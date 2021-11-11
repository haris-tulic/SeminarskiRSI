using System;
using System.Collections.Generic;
using System.Text;

namespace Autoprevoznicko_preduzece_HTS.Model
{
   public class GradskeLinije
    {
        public int ID { get; set; }

        public Autobus BrojAutobusa { get; set; }
        public int BrojAutobusaID { get; set; }
        public Zona zona { get; set; }
        public int zonaID { get; set; }
        public Stanica StanicaPolaska { get; set; }
        public int StanicaPolaskaID { get; set; }
        public Stanica StanicaDolaska { get; set; }
        public int StanicaDolaskaID { get; set; }
    }
}
