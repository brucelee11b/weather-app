using Microsoft.AspNetCore.Mvc;
using WeatherForecast.API.Service;

namespace WeatherForecast.API.Controllers
{
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;
        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            this._weatherForecastService = weatherForecastService;
        }

        [HttpGet("current-weather")]
        public async Task<IActionResult> GetCurrentWeather(string lat, string lon)
        {
            try
            {
                var currentWeather = await _weatherForecastService.GetCurrentWeather(lat, lon);
                return Ok(currentWeather);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("weather-forecast")]
        public async Task<IActionResult> GetWeatherForecast(string lat, string lon)
        {
            try
            {
                var weatherForecast = await _weatherForecastService.GetWeatherForecast(lat, lon);
                return Ok(weatherForecast);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
