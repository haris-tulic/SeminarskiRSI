
using Autoprevoznicko_preduzece_HTS.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAutoprevozncniko.Helper
{//atribut se koristi tako sto se navede naziv "Autorizacija" bez nastavka Attribut(moze i sa njim) 
 //iznad akcija koje zelimo zastitit ili cijelog kontrolera i onda se odnosi na sve akcije unutar kontrolera
    public class AutorizacijaAttribute : TypeFilterAttribute//filter https://www.c-sharpcorner.com/article/working-with-filters-in-asp-net-core-mvc/
    {
        public AutorizacijaAttribute(bool vozac, bool uprava) : base(typeof(MyAuthorizeImpl))
        {
            Arguments = new object[] { vozac, uprava };
        }
    }

    public class MyAuthorizeImpl : IAsyncActionFilter
    {
        public MyAuthorizeImpl(bool vozac, bool uprava)
        {
            _vozac = vozac;
            _uprava = uprava;
        }

        private readonly bool _vozac;
        private readonly bool _uprava;

        public async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {

            //Login k = Autetntifikacija.GetLogiraniKorisnik(filterContext.HttpContext);
            Login k = filterContext.HttpContext.GetLogiraniKorisnik();

            if (k == null)
            {
                if (filterContext.Controller is Controller controller)
                {
                    controller.TempData["error_poruka"] = "Niste logirani";
                }
                filterContext.Result = new RedirectToActionResult("Index", "Autentifikacija", new { area = "" });
                return;
            }

            //DbContext preuzimamo preko app servisa
            MyContext db = filterContext.HttpContext.RequestServices.GetService<MyContext>();//GetRequiredService

            //prava pristupa
            if (_vozac && db.vozac.Any(s => s.loginID == k.ID))
            {
                await next();
                return;
            }

            if (_uprava && db.uprava.Any(s => s.loginID == k.ID))
            {
                await next();
                return;
            }



            if (filterContext.Controller is Controller c1)
            {
                c1.TempData["error_poruka"] = "Nemate pravo pristupa";
            }
            filterContext.Result = new RedirectToActionResult("Index", "Home", new { area = "" });
            return;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementException();
        }

    }


}
