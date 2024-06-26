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

        [HttpGet("/api/current-weather")]
        public async Task<IActionResult> GetCurrentWeather(string province, string lat, string lon)
        {
            try
            {
                var currentWeather = await _weatherForecastService.GetCurrentWeather(province,lat, lon);
                if (currentWeather == null)
                {
                    return StatusCode(500, "Not found!");
                }

                return Ok(currentWeather);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("/api/weather-forecast")]
        public async Task<IActionResult> GetWeatherForecast(string province, string lat, string lon)
        {
            try
            {
                var weatherForecast = await _weatherForecastService.GetWeatherForecast(province, lat, lon);
                if (weatherForecast == null)
                {
                    return StatusCode(500, "Not found!");
                }

                return Ok(weatherForecast);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
