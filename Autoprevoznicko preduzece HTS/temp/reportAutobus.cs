using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace temp
{
    public class reportAutobus
    {

        public int ID { get; set; }
        public int RedniBrojAutobusa { get; set; }
        public int BrojSjedila { get; set; }
        public int GodisteAutobusa { get; set; }
        public string informacije { get; set; }

        public static List<reportAutobus> get()
        {
            return new List<reportAutobus> { };
        }
    }
}