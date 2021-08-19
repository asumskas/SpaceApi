using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceApi.Model
{
    public class SateliteBE1
    {
        [BsonId]

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId) ]
        public string id { get; set; }
        public string name { get; set; }

        

        public string distance { get; set; }
        public string[] message { get; set; }
        public string CoordenadaX { get; set; }
        public string CoordenadaY { get; set; }
    }
}
