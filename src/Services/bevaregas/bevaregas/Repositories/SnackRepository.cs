using bevaregas.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bevaregas.Repositories
{
    public class SnackRepository : ISnackRepository
    {
        private readonly IDistributedCache _redisCache;

        public SnackRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }

        public async Task<Snack> GetSnackList(string userName)
        {
            var basket = await _redisCache.GetStringAsync(userName);
            if (string.IsNullOrEmpty(basket))
                return null;
            return JsonConvert.DeserializeObject<Snack>(basket);
        }

        public async Task<Snack> UpdateSnack(Snack basket)
        {
            await _redisCache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));
            return await GetSnackList(basket.UserName);
        }

        public async Task DeleteSnacklist(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }

      
    }
}
