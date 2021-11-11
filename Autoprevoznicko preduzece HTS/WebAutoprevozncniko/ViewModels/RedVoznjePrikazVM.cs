using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAutoprevozncniko.ViewModels
{
    public class RedVoznjePrikazVM
    {
        public int ID { get; set; }
        public string LinijaPolaska { get; set; }
        public string LinijaDolaska { get; set; }
        public DateTime vrijemePolaska { get; set; }
    }
}
