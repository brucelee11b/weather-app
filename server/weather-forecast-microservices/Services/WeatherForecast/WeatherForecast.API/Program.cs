using WeatherForecast.Application.Services;
using WeatherForecast.Application.Services.Interface;
using WeatherForecast.Infrastructure.IRepository;
using WeatherForecast.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<IGetWheatherRepo, GetWheatherRepo>(c =>
c.BaseAddress = new Uri("https://localhost:7186"));
builder.Services.AddHttpClient<IGetCityLocationRepo, GetCityLocationRepo>(c =>
c.BaseAddress = new Uri("https://localhost:7186"));
builder.Services.AddHttpClient<IGetWheatherDailyRepo, GetWheatherDailyRepo>(c =>
c.BaseAddress = new Uri("https://localhost:7186"));
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddScoped<IWhearDailyService, WheartherDailyServices>();
builder.Services.AddScoped<ILocationServices, LocationServices>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
