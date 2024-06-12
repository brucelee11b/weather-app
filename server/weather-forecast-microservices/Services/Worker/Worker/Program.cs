using Worker;
using Worker.Repository;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Workers>();
builder.Services.AddHttpClient(); // Đăng ký IHttpClientFactory

builder.Services.AddSingleton<ICaching, Caching>();
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IDistributedCache, MemoryDistributedCache>(); 
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
    ConnectionMultiplexer.Connect("localhost:6379"));

var host = builder.Build();
host.Run();
