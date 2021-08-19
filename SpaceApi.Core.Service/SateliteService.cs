using MongoDB.Driver;
using SpaceApi.Core.BE;
using SpaceApi.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceApi.Core.Service
{
    public class SateliteService : ISateliteService
    {
        private IMongoCollection<SateliteBE> _satelite;
        public SateliteService(ISatelitesettings settings)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _satelite = database.GetCollection<SateliteBE>(settings.Collection);


        }

        public SateliteBE Create(SateliteBE sat)
        {
            _satelite.InsertOne(sat);
            return sat;
        }

        public List<SateliteBE> Get()
        {
            return _satelite.Find(d => true).ToList();

        }

    }
}
