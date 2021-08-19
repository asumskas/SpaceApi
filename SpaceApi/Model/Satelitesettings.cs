using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceApi.Model
{
    public class Satelitesettings1: ISatelitesettings1
    {

        public string Server { get; set; }
        public string Database { get; set; }
        public string Collection { get; set; }


    }


    public interface ISatelitesettings1
    {

        string Server { get; set; }
        string Database { get; set; }
        string Collection { get; set; }


    }

}
