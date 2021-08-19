using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceApi.Core.Interface
{
   public interface ISatelitesettings
    {
        string Server { get; set; }
        string Database { get; set; }
        string Collection { get; set; }
    }
}
