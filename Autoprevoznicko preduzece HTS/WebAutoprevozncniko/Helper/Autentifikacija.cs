using Autoprevoznicko_preduzece_HTS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAutoprevozncniko.Helper
{
    public static class Autentifikacija//za logiranog korisnika, olaksava rad sa sesijom
    {
        private const string LogiraniKorisnik = "logirani_korisnik";

        //this HttpContext context <- extended metoda za kontekst
        public static void SetLogiraniKorisnik(this HttpContext context, Login korisnik, bool snimiUCookie = false)
        {
            context.Session.Set(LogiraniKorisnik, korisnik);

            //Moze biti sigurnosni problem radi kuija koji se sprema i moze se ispraviti vrijednost pa cemo prepraviti kod
            //Moramo prosiriti nas kod za novu entity klasu  AutorizacijskiToken

            //ukoliko korisnik zeli snimiti vrijednost odnosto ostati logovan preuzima kuki
            /*if (snimiUCookie) 
                context.Response.SetCookieJson(LogiraniKorisnik,korisnik);//Response, key, vale
            else
               context.Response.SetCookieJson(LogiraniKorisnik, null);*/
            //sigurnosi problem***

            if (snimiUCookie)
            {
                MyContext db = context.RequestServices.GetService<MyContext>();
                string token = Guid.NewGuid().ToString();
                db.AutorizacijskiToken.Add(new AutorizacijskiToken
                {
                    Vrijednost = token,
                    LoginID = korisnik.ID,
                    VrijemeEvidentiranja = DateTime.Now
                });

                db.SaveChanges();
                context.Response.SetCookieJson(LogiraniKorisnik, token);
            }
            else
            {
                context.Response.SetCookieJson(LogiraniKorisnik, null);
            }
        }

        public static Login GetLogiraniKorisnik(this HttpContext context)
        {
            Login korisnik = context.Session.Get<Login>(LogiraniKorisnik);

            if (korisnik == null)
            { //ako je korisnik null onda cemo u kukiju pokusat pronac vrijednost za tog korisnika
                /*korisnik = context.Request.GetCookieJson<Login>(LogiraniKorisnik);//ako smo ga pronasli
                context.Session.Set(LogiraniKorisnik, korisnik);//onda i sesiju postavljamo za njega*/
                //sigurnosni problem***

                MyContext db = context.RequestServices.GetService<MyContext>();

                string token = context.Request.GetCookieJson<string>(LogiraniKorisnik);
                if (token == null)
                {
                    return null;
                }


                /*AutorizacijskiToken autorizacijskiToken = db.AutorizacijskiToken
                    .Include(x => x.Login)
                    .SingleOrDefault(x => x.Vrijednost == token);

                if (autorizacijskiToken != null)
                {
                    context.Session.Set(LogiraniKorisnik, autorizacijskiToken.Login);
                }*///ili verzija ispod

                korisnik = db.AutorizacijskiToken
                    .Where(x => x.Vrijednost == token)
                    .Select(s => s.Login)
                    .SingleOrDefault();

                if (korisnik != null)
                {
                    context.Session.Set(LogiraniKorisnik, korisnik);
                }
            }
            return korisnik;
        }
    }
}
