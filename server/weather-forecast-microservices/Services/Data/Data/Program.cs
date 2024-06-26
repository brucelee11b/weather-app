using Data.Consumer;
using Data.Service;
using RabbitMQ.Extensions;
using RabbitMQ.Services;
using StackExchange.Redis;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<ConsumerHostedService>();

builder.Services.AddMessageBroker(builder.Configuration);
builder.Services.AddSingleton<IWeatherConsumerService, WeatherConsumerService>();
builder.Services.AddSingleton<IRabbitMQService, RabbitMQService>();
builder.Services.AddSingleton<ICaching, Caching>();
builder.Services.AddSingleton<IConnectionMultiplexer>(sp => ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis")));

var app = builder.Build();

app.Run();
