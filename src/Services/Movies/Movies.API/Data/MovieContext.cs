using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Movies.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.API.Data
{
    public class MovieContext : IMovieContext
    {
        public MovieContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            MovieDetails = database.GetCollection<MovieDetail>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            MovieContextSeed.SeedData(MovieDetails);
        }
        public IMongoCollection<MovieDetail> MovieDetails { get; }
    }
}
