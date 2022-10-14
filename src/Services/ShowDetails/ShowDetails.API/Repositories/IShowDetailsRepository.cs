using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShowDetails.API.Entities;

namespace ShowDetails.API.Repositories
{
    public interface IShowDetailsRepository
    {
        Task<Details> GetShowDetailsByID(int TheaterId);
        Task<bool> UpdateDetails(Details coun);
        Task<bool> DeleteDetails(int ShowID);
        Task<bool> CreateDetails(Details coun);

    }
}
