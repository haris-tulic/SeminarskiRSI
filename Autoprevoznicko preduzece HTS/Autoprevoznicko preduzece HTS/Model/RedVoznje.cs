using System;
using System.Collections.Generic;
using System.Text;

namespace Autoprevoznicko_preduzece_HTS.Model
{
    public class RedVoznje
    {
        public int ID { get; set; }

        public GradskeLinije gradskaLinija { get; set; }
        public int gradskaLinijaID { get; set; }
        public DateTime VrijemePolaska { get; set; }
    }
}
