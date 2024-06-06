using Data.Consumer;
using Data.Service;
using RabbitMQ.Extensions;
using Worker.Installers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMessageBroker(builder.Configuration);
builder.Services.InstallerServiceInAssembly(builder.Configuration);
builder.Services.AddSingleton<IWeatherConsumerService, WeatherConsumerService>();
builder.Services.AddHostedService<ConsumerHostedService>();

var app = builder.Build();

app.Run();
