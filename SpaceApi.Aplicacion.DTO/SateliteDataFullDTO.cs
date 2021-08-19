using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceApi.Aplicacion.DTO
{
    public class SateliteDataFullDTO
    {
        public string name { get; set; }
        public float distance { get; set; }
        public string[] message { get; set; }
        public float CoordenadaX { get; set; }
        public float CoordenadaY { get; set; }


    }
}
