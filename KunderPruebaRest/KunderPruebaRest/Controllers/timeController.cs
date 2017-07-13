using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KunderPruebaRest.Models;
using System.Globalization;

namespace KunderPruebaRest.Controllers
{
    public class timeController : ApiController
    {
        /// <summary> GET: api/time/
        ///  Ejemplo /api/time?value=2009/03/01T23:57:00-4:00</summary>
        public IHttpActionResult Get([FromUri]string value)
        {
            try
            {
                DateTime dateTime;
                CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");

                if ((value == null) || !(DateTime.TryParse(value, culture, DateTimeStyles.AdjustToUniversal, out dateTime)))
                    return BadRequest();
                
                Retorno retorno = new Retorno { code = "00", description = "OK", data = dateTime.ToString("HH:mm:ss") };

                return Ok(retorno);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }
    }
}
