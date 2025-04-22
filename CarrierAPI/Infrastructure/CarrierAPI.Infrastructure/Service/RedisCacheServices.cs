using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Domain.Entities.Item;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Infrastructure.Service
{
    public class RedisCacheServices: IRedisCacheServices
    {
        private readonly IDistributedCache _cache;

        public RedisCacheServices(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T> GetCacheAsync<T>(string cacheKey)
        {
            var cachedData = await _cache.GetStringAsync(cacheKey);
            if (!string.IsNullOrEmpty(cachedData))
            {
                return JsonConvert.DeserializeObject<T>(cachedData);
            }

            return default(T);
        }

        public async Task SetCacheAsync<T>(string cacheKey, T data, TimeSpan absoluteExpiration, TimeSpan slidingExpiration)
        {
            var jsonData = JsonConvert.SerializeObject(data);
            await _cache.SetStringAsync(cacheKey, jsonData, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpiration,
                SlidingExpiration = slidingExpiration
            });
        }
    }
}
