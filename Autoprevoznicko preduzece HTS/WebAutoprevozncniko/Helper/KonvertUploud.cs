using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAutoprevozncniko.Helper
{
    public class KonvertUploud
    {
        public static string JedinstvenNaziv(string imeFajla)
        {
            imeFajla = Path.GetFileName(imeFajla);
            return Path.GetFileNameWithoutExtension(imeFajla)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(imeFajla);
        }
    }
}
