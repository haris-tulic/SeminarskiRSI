using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Autoprevoznicko_preduzece_HTS.Model
{
    public class AutorizacijskiToken
    {
        public int ID { get; set; }
        public string Vrijednost { get; set; }

        [ForeignKey("LoginID")]
        public Login Login { get; set; }
        public int LoginID { get; set; }
        
        public DateTime VrijemeEvidentiranja { get; set; }
    }
}
