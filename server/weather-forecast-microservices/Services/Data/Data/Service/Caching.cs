using StackExchange.Redis;

namespace Data.Service
{
    public class Caching : ICaching
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private IDatabase database;
        public Caching(IConnectionMultiplexer connectionMultiplexer)
        {
            this._connectionMultiplexer = connectionMultiplexer;
            this.database = this._connectionMultiplexer.GetDatabase();
        }

        public string GetCacheResponse(string cacheKey)
        {
            return this.database.StringGet(cacheKey).ToString();
        }
    }
}
