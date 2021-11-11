using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAutoprevozncniko.ViewModels
{
    public class VozacPretragaVM
    {
        public List<SelectListItem> vozaci { get; set; }
        public int ID { get; set; }
       
        //public string KorisnickoIme { get; set; }
    }
}
