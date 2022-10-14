using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teatres.APi.Data;
using Teatres.APi.Entities;

namespace Teatres.APi.Repositories
{
    public class TeatreRepository : ITeatreRepository
    {
        private readonly ITeatreContext _Context;

        public TeatreRepository(ITeatreContext context)
        {
            _Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<TeatreDetail>> GetAllTeatres()
        {
            return await _Context.TeatreDetails
                                 .Find(p => true).ToListAsync();

        }

        public async Task<IEnumerable<TeatreDetail>> GetTeatreByMovieName(string movieName)
        {
            FilterDefinition<TeatreDetail> filter = Builders<TeatreDetail>.Filter.Eq(p => p.MovieName, movieName);

            return await _Context
                            .TeatreDetails
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<IEnumerable<TeatreDetail>> GetTeatreByCity(string city)
        {
            FilterDefinition<TeatreDetail> filter = Builders<TeatreDetail>.Filter.Eq(p => p.CityName, city);

            return await _Context
                            .TeatreDetails
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<IEnumerable<TeatreDetail>> GetTeatreBYName(string teatreName)
        {
            FilterDefinition<TeatreDetail> filter = Builders<TeatreDetail>.Filter.Eq(p => p.TeatreName, teatreName);

            return await _Context
                            .TeatreDetails
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task CreateTeatreDetail(TeatreDetail teatreDetail)
        {
            await _Context.TeatreDetails.InsertOneAsync(teatreDetail);
        }


        public async Task<bool> UpdateTeatreDetail(TeatreDetail movieDetail)
        {
            var updateResult = await _Context
                                        .TeatreDetails
                                        .ReplaceOneAsync(filter: g => g.Id == movieDetail.Id, replacement: movieDetail);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
        public async Task<bool> DeleteTeatreDetail(string id)
        {
            FilterDefinition<TeatreDetail> filter = Builders<TeatreDetail>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _Context
                                                .TeatreDetails
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}
