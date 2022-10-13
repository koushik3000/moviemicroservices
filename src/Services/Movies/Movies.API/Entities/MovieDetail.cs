using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.API.Entities
{
    public class MovieDetail
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("MovieName")]
        public string MovieName { get; set; }
        public string Language { get; set; }
        public string Genre { get; set; }
        public string Cast { get; set; }
        public string Description { get; set; }
        public int Releaseyear { get; set; }
        public string ImageFile { get; set; }
        public object City { get; set; }


    }
}
