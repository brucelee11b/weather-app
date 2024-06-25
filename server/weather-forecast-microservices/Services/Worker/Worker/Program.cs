using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using Worker;
using Worker.Repository;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Workers>();
builder.Services.AddHttpClient(); // Đăng ký IHttpClientFactory

builder.Services.AddSingleton<ICaching, Caching>();
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IDistributedCache, MemoryDistributedCache>();

builder.Services.AddDbContext<WorkerDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase")));

builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
    ConnectionMultiplexer.Connect("host.docker.internal:6379,abortConnect=false"));
builder.Services.AddStackExchangeRedisCache(options =>
{
	options.Configuration = "host.docker.internal:6379,abortConnect=false";
	options.InstanceName = "SampleInstance"; // Optional instance name
});

var host = builder.Build();
host.Run();
