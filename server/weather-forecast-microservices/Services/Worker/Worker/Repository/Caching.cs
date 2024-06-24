﻿using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StackExchange.Redis;

namespace Worker.Repository
{
    public class Caching : ICaching
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        public Caching(IDistributedCache distributedCache, IConnectionMultiplexer connectionMultiplexer) 
        {
            this._distributedCache = distributedCache;
            this._connectionMultiplexer = connectionMultiplexer;
        }

        public string GetCacheResponse(string cacheKey)
        {
            return this._distributedCache.GetString(cacheKey);
        }

        public bool SetCacheResponse(string cacheKey, string response, TimeSpan? timeOut = null)
        {
            if (timeOut == null)
            {
                timeOut = TimeSpan.FromDays(2);
            }

            if (response == null)
            {
                return false;
            }

            this._distributedCache.SetString(cacheKey, response, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = timeOut,
            });

            return !string.IsNullOrEmpty(this.GetCacheResponse(cacheKey));
        }

        public bool RemoveCache(string cacheKey)
        {
            var data = GetCacheResponse(cacheKey);
            if (!string.IsNullOrEmpty(data))
            {
                this._distributedCache.RemoveAsync(cacheKey);
            }

            return string.IsNullOrEmpty(this.GetCacheResponse(cacheKey));
        }
    }
}
