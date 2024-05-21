using WeatherForecast.API.Model;
using WeatherForecast.API.Utility;

namespace WeatherForecast.API.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient _httpClient;

        public WeatherForecastService()
        {
            this._httpClient = new HttpClient();
            this._httpClient.BaseAddress = new Uri("http://localhost:5005/");
        }

        public async Task<CurrentWeather> GetCurrentWeather(string lat, string lon)
        {
            try
            {
                var response = await this._httpClient.GetAsync($"weather?lat={lat}&lon={lon}");
                response.EnsureSuccessStatusCode();

                var responseData = await response.ReadContentAsync<CurrentWeather>();
                return responseData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DailyWeather> GetWeatherForecast(string lat, string lon)
        {
            try
            {
                var response = await this._httpClient.GetAsync($"daily?lat={lat}&lon={lon}");
                response.EnsureSuccessStatusCode();

                var responseData = await response.ReadContentAsync<DailyWeather>();
                return responseData;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
