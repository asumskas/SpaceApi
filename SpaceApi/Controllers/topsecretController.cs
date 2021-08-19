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

        //[HttpGet("{id}")]

        //public string Get(string id)
        //{

        //    return id;
        //}

        [HttpPost]
        public ActionResult<ResponseDTO> Post(RequestDTO satellites)

        {
            ResponseDTO oresponse = null;
            try
            {
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
