using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebAutoprevozncniko.Helper
{
    public static class MyCookieExtension//Dozvoljava da se u cookie ubaci kompleksniji tip podataka pomoći jsona
    {
        public static T GetCookieJson<T>(this HttpRequest request, string key) {
            string strValue = request.Cookies[key];//preuzima se iz request-a
            return (strValue == null ? default(T) : JsonConvert.DeserializeObject<T>(strValue));
        }

        public static void SetCookieJson(this HttpResponse response, string key, object value, int? expireTime = null)
        {
            if (value == null) {
                response.Cookies.Delete(key);
            }

            CookieOptions options = new CookieOptions();

            if (expireTime.HasValue)
                options.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                options.Expires = DateTime.Now.AddDays(7);

            string strValue = JsonConvert.SerializeObject(value);
         
            response.Cookies.Append(key, strValue, options);//setuje se pomocu response
        }

        public static void RemoveCookie(this HttpResponse response, string key)
        {
            response.Cookies.Delete(key);
        }
    }
}
