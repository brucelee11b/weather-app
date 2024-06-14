using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Worker.Repository;

namespace Worker
{
    public class Workers : BackgroundService
    {
        private readonly ILogger<Workers> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string apiKey = "a138902a1200a09b2c57e0119815c601";
        private readonly ICaching _caching;
        private readonly IServiceProvider _serviceProvider;

        const string currentWeatherQueue = "current-weather-queue";
        const string weatherForecastQueue = "weather-forecast-queue";

        public Workers(ILogger<Workers> logger, IHttpClientFactory httpClientFactory, ICaching caching, IServiceProvider serviceProvider)
        {
            _logger = logger; 
            _httpClientFactory = httpClientFactory;
            _caching = caching;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }

                // Gọi API khi khởi động
                await CallApiAsync("21.0294498", "105.8544441", "10", stoppingToken);

                await Task.Delay(20000, stoppingToken);
            }
        }

        private async Task CallApiAsync(string latitude, string longitude, string count, CancellationToken stoppingToken)
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                try
                {
                    var version = "data/2.5/";
                    StringBuilder url = new StringBuilder();
                    url.Append($"{version}forecast?lat={latitude}&lon={longitude}&cnt={count}&appid={apiKey}&units=metric");

                    client.BaseAddress = new Uri("https://api.openweathermap.org/");
                    HttpResponseMessage response = await client.GetAsync(url.ToString());
                    response.EnsureSuccessStatusCode();
                    var responseData = await response.Content.ReadAsStringAsync();

                    var daillyWeatherData = this._caching.GetCacheResponse("GetDailyWeatherData");
                    if(daillyWeatherData == null )
                    {
                        var result = this._caching.SetCacheResponse("GetDailyWeatherData", responseData);
                        if (!result)
                        {
                            Exception exception = new Exception("Set Cache Response Failed");
                            throw exception;
                        }
                    }

                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var dbContext = scope.ServiceProvider.GetRequiredService<WorkerDbContext>();

                        // Thêm dữ liệu vào cơ sở dữ liệu
                        var newEntity = new WeatherData { Id = 1, DataDaily = responseData };
                        if(dbContext.WeatherDatas.FirstOrDefault(e => e.Id == 1) != null)
                        {
                            var item = dbContext.WeatherDatas.FirstOrDefault(e => e.Id == 1);
                            dbContext.WeatherDatas.Remove(item);
                            dbContext.SaveChanges();

                            await dbContext.WeatherDatas.AddAsync(newEntity, stoppingToken);
                            await dbContext.SaveChangesAsync(stoppingToken);
                        }

                        _logger.LogInformation("Data added to the database.");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error calling API: {e.Message}");
                }
            }
        }
    }
}
