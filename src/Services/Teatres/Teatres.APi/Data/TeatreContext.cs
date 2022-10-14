using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teatres.APi.Entities;

namespace Teatres.APi.Data
{
    public class TeatreContext : ITeatreContext
    {
        public TeatreContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            TeatreDetails = database.GetCollection<TeatreDetail>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            TeatreContextSeed.SeedData(TeatreDetails);
        }
        public IMongoCollection<TeatreDetail> TeatreDetails { get; }
    }
    
}
