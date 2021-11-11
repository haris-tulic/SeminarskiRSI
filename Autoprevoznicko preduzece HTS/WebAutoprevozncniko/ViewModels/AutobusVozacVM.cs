using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAutoprevozncniko.ViewModels
{
    public class AutobusVozacVM : Controller
    {
       public int ID { get; set; }
       public int autobus { get; set; }
       public string vozac { get; set; }
        public DateTime pocetak { get; set; }
        public DateTime kraj { get; set; }
        public int smjena { get; set; }

    }
}
