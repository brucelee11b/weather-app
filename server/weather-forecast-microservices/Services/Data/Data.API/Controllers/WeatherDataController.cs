using Microsoft.AspNetCore.Mvc;

namespace Data.API.Controllers
{
    [ApiController]
    public class WeatherDataController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly string apiKey = "a138902a1200a09b2c57e0119815c601";

        public WeatherDataController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.openweathermap.org/");
        }

        [HttpGet("weather")]
        public async Task<IActionResult> GetCurrentWeatherData(string lat, string lon)
        {
            try
            {
                var version = "data/2.5/";
                var response = await _httpClient.GetAsync($"{version}weather?lat={lat}&lon={lon}&appid={apiKey}");
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadAsStringAsync();
                return Ok(responseData);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error retrieving city data: {ex.Message}");
            }
        }

        [HttpGet("daily")]
        public async Task<IActionResult> GetDailyWeatherData(string lat, string lon)
        {
            try
            {
                var version = "data/2.5/";
                var response = await _httpClient.GetAsync($"{version}forecast?lat={lat}&lon={lon}&cnt=7&appid={apiKey}");
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
