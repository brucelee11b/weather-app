using Data.Consumer;
using Data.Service;
using RabbitMQ.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMessageBroker(builder.Configuration);
builder.Services.AddSingleton<IWeatherConsumerService, WeatherConsumerService>();
builder.Services.AddHostedService<ConsumerHostedService>();

var app = builder.Build();

app.Run();
