using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAutoprevozncniko.ViewModels
{
    public class ZonaPrikazVM
    {

        //public List<Row> ListaZona { get; set; }
        //public class Row
        //{
        //    public int ID { get; set; }
        //    public int BrojZone { get; set; }
        //}


        public List<SelectListItem> zone { get; set; }
        public int ID { get; set; }

    }
}
