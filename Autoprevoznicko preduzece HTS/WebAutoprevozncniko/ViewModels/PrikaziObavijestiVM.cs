using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAutoprevozncniko.ViewModels
{
    public class PrikaziObavijestiVM
    {
        public int ID { get; set; }
        public string naslov { get; set; }
        public string sadrzaj { get; set; }
        public DateTime datumObjave { get; set; }
        public string uprava { get; set; }
    }
}
