using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KunderPruebaRest.Models;

namespace KunderPruebaRest.Controllers
{
    public class wordController : ApiController
    {
        /// <summary> POST: api/word
        ///  Ejemplo /api/word Content-type: application/json {"data":"kunder"}</summary>
        [HttpPost]
        public IHttpActionResult Post([FromBody]Entrada entrada)
        {
            try
            {
                if ((entrada == null) || !entrada.data.All(c => char.IsLetter(c)))
                    return BadRequest();
                
                string dataUpper = entrada.data.ToUpper();
                Retorno retorno = new Retorno { code = "00", description = "OK", data = dataUpper };

                return Ok(retorno);

            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }
    }
}
