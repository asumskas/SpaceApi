using SpaceApi.Core.BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceApi.Core.Interface
{
    
        public interface ISateliteService
        {
            List<SateliteBE> Get();
            SateliteBE Create(SateliteBE sat);
        }
    
}
