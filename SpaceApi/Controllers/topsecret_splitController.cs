using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SpaceApi.Aplicacion.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SpaceApi.Aplicacion.IGestor;

namespace SpaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class topsecret_splitController : ControllerBase
    {
        
        private readonly IGestorSpace _gestorSatelite;
        public topsecret_splitController( IGestorSpace gestorSatelite)
        {
            _gestorSatelite = gestorSatelite;
            

        }

        /// <summary>
        /// Se obtiene la informacion del mensaje y la posicion del emisor siempre y cuando esten cargados los tres satelites
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<ResponseDTO> Obtener()
        {
            string mensajeError = string.Empty;  
            ResponseDTO oresponse = null;
            try { 
            var lstKenobi = _gestorSatelite.GetSatelites("Kenobi");
            var lstSato = _gestorSatelite.GetSatelites("Sato");
            var lstSkyWalker = _gestorSatelite.GetSatelites("SkyWalker");
            if (lstKenobi.Count() == 0 || lstSato.Count() == 0 || lstSkyWalker.Count() == 0)
                throw new Exception("No se establecieron aún todos los satélites para armar la información");




            var msg = _gestorSatelite.GetMessage(lstKenobi.FirstOrDefault().message , lstSkyWalker.FirstOrDefault().message, lstSato.FirstOrDefault().message);
            // determino la posicion 

            var tupla = _gestorSatelite.GetLocation(lstKenobi.FirstOrDefault(), lstSkyWalker.FirstOrDefault(), lstSato.FirstOrDefault());


            oresponse = new ResponseDTO() { message = msg, position = new posicion() { x = tupla.Item1, y = tupla.Item2 } };


        }
            catch (Exception ex)
            {

                return NotFound(ex.Message.ToString());
    }

            return Ok(oresponse);

}

        /// <summary>
        /// Registra la informacion del satelite Kenobi (distancia y mensaje)
        /// </summary>
        /// <param name="satelite"></param>
        /// <returns></returns>
        [HttpPost("Kenobi")]
        
        public ActionResult<SateliteBDDto> PostKenobi(RequestSplitDTO satelite)
        {

            try
            {

            
            SateliteBDDto param = new SateliteBDDto {name = "Kenobi",distance =satelite.distance, message = satelite.message };

            var a= _gestorSatelite.GuardarSatelites(param);
            
            return Ok(a);
            }
            catch (Exception)
            {

                return NotFound("Algo no funciono bien al guardar a Kenobi ");
            }

        }

        /// <summary>
        /// Registra la informacion del satelite SkyWalker (distancia y mensaje)
        /// </summary>
        /// <param name="satelite"></param>
        /// <returns></returns>
        [HttpPost("SkyWalker")]

        public ActionResult<SateliteBDDto> PostSkyWalker(RequestSplitDTO satelite)
        {

            try
            {


                SateliteBDDto param = new SateliteBDDto { name = "SkyWalker", distance = satelite.distance , message = satelite.message };

                var a = _gestorSatelite.GuardarSatelites(param);

                return Ok(a);
            }
            catch (Exception)
            {

                return NotFound("Algo no funciono bien al guardar a SkyWalker ");
            }

        }

        /// <summary>
        /// Registra la informacion del satelite Sato (distancia y mensaje)
        /// </summary>
        /// <param name="satelite"></param>
        /// <returns></returns>
        [HttpPost("Sato")]

        public ActionResult<SateliteBDDto> PostSato(RequestSplitDTO satelite)
        {

            try
            {


                SateliteBDDto param = new SateliteBDDto { name = "Sato", distance = satelite.distance , message = satelite.message };

                var a = _gestorSatelite.GuardarSatelites(param);

                return Ok(a);
            }
            catch (Exception)
            {

                return NotFound("Algo no funciono bien al guardar a Sato ");
            }

        }


    }



}


