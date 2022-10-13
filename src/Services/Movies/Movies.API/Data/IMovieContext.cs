using MongoDB.Driver;
using Movies.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.API.Data
{
    public interface IMovieContext
    {
        IMongoCollection<MovieDetail> MovieDetails { get; }
    }

}
