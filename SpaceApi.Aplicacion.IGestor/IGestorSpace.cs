using SpaceApi.Aplicacion.DTO;
using SpaceApi.Core.BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceApi.Aplicacion.IGestor
{
    public interface IGestorSpace
    {

        Tuple<float, float> GetLocation(SatelitesDTO sat1, SatelitesDTO sat2, SatelitesDTO sat3);
        

        string GetMessage(string[] Message1, string[] Message2, string[] Message3);

        SateliteBDDto GuardarSatelites(SateliteBDDto sat);

        List<SateliteBDDto> GetSatelites(string nombre);

        //SateliteBDDto UpdateSatelite(string id, SateliteBDDto sat);


    }
}
