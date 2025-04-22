using CarrierAPI.Domain.Entities.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Application.Abstractions.Services
{
    public interface IRedisCacheServices
    {
        Task<T> GetCacheAsync<T>(string cacheKey);
        Task SetCacheAsync<T>(string cacheKey, T data, TimeSpan absoluteExpiration, TimeSpan slidingExpiration);
    }
}
