using WeatherForecast.API.Model;

namespace WeatherForecast.API.Services
{
    public interface IWeatherForecastService
    {
        public Task<CurrentWeather> GetCurrentWeather(string lat, string lon);

        public Task<DailyWeather> GetWeatherForecast(string lat, string lon);
    }
}
