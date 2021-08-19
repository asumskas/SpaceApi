using System;
using System.Collections.Generic;
using System.Text;
using SpaceApi.Core.Interface;




namespace SpaceApi.Core.Service
{
    public class Satelitesettings : ISatelitesettings
    {

        public string Server { get; set; }
        public string Database { get; set; }
        public string Collection { get; set; }


    }
}
