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

        const string currentWeatherQueue = "current-weather-queue";
        const string weatherForecastQueue = "weather-forecast-queue";

        public Workers(ILogger<Workers> logger, IHttpClientFactory httpClientFactory, ICaching caching)
        {
            _logger = logger; 
            _httpClientFactory = httpClientFactory;
            _caching = caching;
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
                await CallApiAsync("21.0294498", "105.8544441", "10");

                await Task.Delay(20000, stoppingToken);
            }
        }

        private async Task CallApiAsync(string latitude, string longitude, string count)
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

                    var result = this._caching.SetCacheResponse("GetDailyWeatherData", responseData);
                    if (!result)
                    {
                        Exception exception = new Exception("Set Cache Response Failed");
                        throw exception;
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
