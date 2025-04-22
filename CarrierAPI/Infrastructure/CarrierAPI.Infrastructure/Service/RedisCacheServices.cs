using CarrierAPI.Application.Abstractions.Services;
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
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly IDatabaseAsync _databaseAsync;

        public RedisCacheServices(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
            _databaseAsync = _connectionMultiplexer.GetDatabase();
        }
        public async Task ClearAsync(string key)
        {
            await _databaseAsync.KeyDeleteAsync(key);
        }

        public async Task<string> GetValueAsync(string key)
        {
           return await _databaseAsync.StringGetAsync(key);
        }
        public async Task<bool> SetValueAsync(string key, string value)
        {
           return await _databaseAsync.StringSetAsync(key, value);
        }
    }
}
