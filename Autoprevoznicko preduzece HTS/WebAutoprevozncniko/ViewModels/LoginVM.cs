using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAutoprevozncniko.ViewModels
{
    public class LoginVM//Adil
    {
        [StringLength(100, ErrorMessage="Korisničko ime mora sadrržavati minimalno 3 karaktera.", MinimumLength = 3)]
        public string Username { get; set; }
        [StringLength(100, ErrorMessage = "Password mora sadrržavati minimalno 3 karaktera.", MinimumLength = 4)]
        [DataType(DataType.Password)]       
        public string Password { get; set; }
        public bool ZapamtiPassword { get; set; }
    }
}
