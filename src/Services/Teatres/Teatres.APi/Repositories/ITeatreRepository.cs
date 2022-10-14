using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teatres.APi.Entities;

namespace Teatres.APi.Repositories
{
    public interface ITeatreRepository
    {
        Task<IEnumerable<TeatreDetail>> GetAllTeatres();

        Task<IEnumerable<TeatreDetail>> GetTeatreByMovieName(string movieName);

        Task<IEnumerable<TeatreDetail>> GetTeatreByCity(string city);

        Task<IEnumerable<TeatreDetail>> GetTeatreBYName(string teatreName);

        Task CreateTeatreDetail(TeatreDetail teatreDetail);
        Task<bool> UpdateTeatreDetail(TeatreDetail teatreDetail);

        Task<bool> DeleteTeatreDetail(string id);


    }
}
