using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceApi.Aplicacion.DTO
{

    public class posicion
    {
        public float x
        {
            get; set;
        }
        public float y
        {
            get; set;
        }

    }


    public class ResponseDTO
    {
        public posicion position { get; set; }
        public string message { get; set; }


    }
}
