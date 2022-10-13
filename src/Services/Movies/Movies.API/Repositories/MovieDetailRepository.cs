using MongoDB.Driver;
using Movies.API.Data;
using Movies.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.API.Repositories
{
    public class MovieDetailRepository : IMovieDetailRepository
    {
        private readonly IMovieContext _Context;

        public MovieDetailRepository(IMovieContext context)
        {
            _Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<MovieDetail>> GetMovies()
        {
            return await _Context.MovieDetails.
                Find(p => true).ToListAsync();
        }

        public async Task<IEnumerable<MovieDetail>> GetMovieByName(string name)
        {
            FilterDefinition<MovieDetail> filter = Builders<MovieDetail>.Filter.Eq(p => p.MovieName, name);

            return await _Context
                            .MovieDetails
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<IEnumerable<MovieDetail>> GetMovieByLanguage(string language)
        {
            FilterDefinition<MovieDetail> filter = Builders<MovieDetail>.Filter.Eq(p => p.Language, language);

            return await _Context
                            .MovieDetails
                            .Find(filter)
                            .ToListAsync();
        }


        public async Task CreateMovieDetail(MovieDetail movieDetail)
        {
            await _Context.MovieDetails.InsertOneAsync(movieDetail);
        }

        public async Task<bool> UpdateMovieDetail(MovieDetail movieDetail)
        {
            var updateResult = await _Context
                                        .MovieDetails
                                        .ReplaceOneAsync(filter: g => g.Id == movieDetail.Id, replacement: movieDetail);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
        public async Task<bool> DeleteMovieDetail(string id)
        {
            FilterDefinition<MovieDetail> filter = Builders<MovieDetail>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _Context
                                                .MovieDetails
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

    }
}
