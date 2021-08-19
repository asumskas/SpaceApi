using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceApi.Core.BE
{
   public class SateliteBE
    {

        [BsonId]

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string id { get; set; }
        public string name { get; set; }
        public string distance { get; set; }
        public string[] message { get; set; }

       // public static implicit operator SateliteBE(SateliteBE v) => throw new NotImplementedException();
    }
}
