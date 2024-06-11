﻿using Worker.Configuration;
using Worker.Service;
using StackExchange.Redis;
using Worker.IServices;
using Data.Configuration;

namespace Worker.Installers
{
    public class CacheInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            var redisConfiguration = new RedisConfiguration();
            configuration.GetSection("RedisConfiguration").Bind(redisConfiguration);

            services.AddSingleton(redisConfiguration);

            if (!redisConfiguration.Enabled)
                return;
            services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(redisConfiguration.ConnectionString));
            services.AddStackExchangeRedisCache(option => option.Configuration = redisConfiguration.ConnectionString);
            services.AddSingleton<IResponseCacheService, ResponseCacheService>();
        }
    }
}
