using Movies.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.API.Repositories
{
    public interface IMovieDetailRepository
    {
        Task<IEnumerable<MovieDetail>> GetMovies();

        Task<IEnumerable<MovieDetail>> GetMovieByName(string name);

        Task<IEnumerable<MovieDetail>> GetMovieByLanguage(string language);

        Task CreateMovieDetail(MovieDetail moviedetail);
        Task<bool> UpdateMovieDetail(MovieDetail movieDetail);
        
        Task<bool> DeleteMovieDetail(string id);





    }
}
