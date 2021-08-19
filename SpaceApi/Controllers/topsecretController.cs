using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaceApi.Aplicacion.DTO;
using SpaceApi.Aplicacion.IGestor;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class topsecretController : ControllerBase
    {
        private readonly IGestorSpace _gestorSatelite;

        public topsecretController(IGestorSpace gestorSatelite)
        {
            _gestorSatelite = gestorSatelite;
        }

        
        /// <summary>
        /// Retorna el mensaje que puede interpretar a partir del request. El array de JSon debe tener tres elementos para que responda correctamente
        /// </summary>
        /// <param name="satellites"> array de objetos satelites</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ResponseDTO> Post(RequestDTO satellites)

        {
            ResponseDTO oresponse = null;
            try
            {
                if (satellites.satellites.Length != 3)
                    throw new Exception("Debe haber tres satelites en el array enviado");
                // determino el mensaje entre los distintos satelites
                var msg = _gestorSatelite.GetMessage(satellites.satellites[0].message, satellites.satellites[1].message, satellites.satellites[2].message);
                // determino la posicion 

                var tupla = _gestorSatelite.GetLocation(satellites.satellites[0], satellites.satellites[1], satellites.satellites[2]);


                oresponse = new ResponseDTO() { message = msg, position = new posicion() { x = tupla.Item1, y = tupla.Item2 } };


            }
            catch (Exception ex)
            {

                return NotFound(ex.Message.ToString());
            }

            return Ok(oresponse);

        }


    }
}
