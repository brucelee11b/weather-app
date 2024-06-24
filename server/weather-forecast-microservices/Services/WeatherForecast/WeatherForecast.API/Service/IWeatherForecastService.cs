using WeatherForecast.API.Model;

namespace WeatherForecast.API.Service
{
    public interface IWeatherForecastService
    {
        public Task<CurrentWeather> GetCurrentWeather(string province, string lat, string lon);

        public Task<DailyWeather> GetWeatherForecast(string province, string lat, string lon);
    }
}
