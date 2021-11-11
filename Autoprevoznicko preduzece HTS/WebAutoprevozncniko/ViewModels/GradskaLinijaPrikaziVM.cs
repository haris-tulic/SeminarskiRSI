using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAutoprevozncniko.ViewModels
{
    public class GradskaLinijaPrikaziVM : Controller
    {
        public int ID { get; set; }
        public int brojAutobusa { get; set; }
        public int zona { get; set; }
        public string stanicaPolaska { get; set; }
        public string stanicaDolaska { get; set; }
    }
}
