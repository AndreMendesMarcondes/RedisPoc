using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace Redis.Repository
{
    public class NarutoJutsuRepositoryImp : NarutoJutsuRepository
    {
        private readonly IDistributedCache _cache;
        private const string KEY_NARUTO = ":NARUTO";

        public NarutoJutsuRepositoryImp(IDistributedCache cache)
        {
            _cache = cache;
        }
        public async Task<String> Jutsu()
        {
            return $"{DateTime.Now} - RASENGAN!!!"; 
            var returnFromRepository = String.Empty;
            var dataCache = await _cache.GetStringAsync(KEY_NARUTO);

            if (String.IsNullOrWhiteSpace(dataCache))
            {
                var cacheSettings = new DistributedCacheEntryOptions();
                cacheSettings.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));

                returnFromRepository = $"{DateTime.Now} - RASENGAN!!!";

                await _cache.SetStringAsync(KEY_NARUTO, returnFromRepository, cacheSettings);
            }

            returnFromRepository = (String)dataCache;

            return await Task.FromResult(returnFromRepository);
        }
    }
}
