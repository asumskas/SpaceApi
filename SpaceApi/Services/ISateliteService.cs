using SpaceApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceApi.Services
{
    public interface ISateliteService1
    {
        List<SateliteBE1> Get();
        SateliteBE1 Create(SateliteBE1 sat);
    }
}
