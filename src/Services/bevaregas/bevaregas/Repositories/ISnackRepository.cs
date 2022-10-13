using bevaregas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bevaregas.Repositories
{
    public interface ISnackRepository
    {
        Task<Snack> GetSnackList(string userName);
        Task<Snack> UpdateSnack(Snack basket);

        Task DeleteSnacklist(string userName);
    }
}
