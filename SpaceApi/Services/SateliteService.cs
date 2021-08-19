using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using SpaceApi.Model;

namespace SpaceApi.Services
{
    public class SateliteService:ISateliteService1
    {
        private IMongoCollection<SateliteBE1> _satelite;
        public SateliteService(ISatelitesettings1 settings )
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _satelite = database.GetCollection<SateliteBE1>(settings.Collection);


        }

        public SateliteBE1 Create(SateliteBE1 sat)
        {
            _satelite.InsertOne(sat);
            return sat; 
        }

        public List<SateliteBE1> Get()
        {
            return _satelite.Find(d => true).ToList();

        }

    }
}
