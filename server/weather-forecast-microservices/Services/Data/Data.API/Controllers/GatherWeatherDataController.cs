using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace MasstransitRabbitMQConsumer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly HttpClient _httpClient;
        private readonly string apiKey = "a138902a1200a09b2c57e0119815c601";

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.openweathermap.org/"); // Thay đổi thành URL của hệ thống thứ ba
        }

        [HttpPost("getcitylongandlatinfo")]
        public async Task<IActionResult> GetCityInfo(string cityName, int num)
        {
            try
            {
                var version = "geo/1.0/";
                var response = await _httpClient.GetAsync($"{version}direct?q={cityName}&limit={num}&appid={apiKey}");
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadAsStringAsync();
                return Ok(responseData);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error retrieving city data: {ex.Message}");
            }
        }

        [HttpPost("getweatherbycityid")]
        public async Task<IActionResult> GetWeatherByCityId(string cityId, string language)
        {
            try
            {
                var version = "data/2.5/";
                var response = await _httpClient.GetAsync($"{version}weather?id={cityId}&lang={language}&appid={apiKey}&units=metric");
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadAsStringAsync();
                return Ok(responseData);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error retrieving weather data: {ex.Message}");
            }
        }

        [HttpPost("getweatherbylonandlat")]
        public async Task<IActionResult> GetCityInfo(string latitude, string longitude)
        {
            try
            {
                var version = "data/2.5/";
                var response = await _httpClient.GetAsync($"{version}weather?lat={latitude}&lon={longitude}&appid={apiKey}&units=metric");
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadAsStringAsync();
                return Ok(responseData);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error retrieving city data: {ex.Message}");
            }
        }

        [HttpPost("getdailyweatherbylonandlat")]
        public async Task<IActionResult> GetDailyWeatherData(string latitude, string longitude, int count)
        {
            try
            {
                var version = "data/2.5/";
                var response = await _httpClient.GetAsync($"{version}forecast?lat={latitude}&lon={longitude}&cnt={count}&appid={apiKey}&units=metric");
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadAsStringAsync();
                return Ok(responseData);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error retrieving city data: {ex.Message}");
            }
        }
    }
}
