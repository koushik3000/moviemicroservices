using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teatres.APi.Entities
{
    public class TeatreDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("TeatreName")]
        public string TeatreName { get; set; }
        public string CityName { get; set; }
        public int Rating { get; set; }
        public string MovieName { get; set; }
        public string ScreenName { get; set; }
        public int NoOfScreens { get; set; }


    }
}
