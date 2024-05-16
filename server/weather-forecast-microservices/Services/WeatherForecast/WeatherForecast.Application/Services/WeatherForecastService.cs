using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherForecast.Domain.Entity;
using WeatherForecast.Infrastructure.WebHelper;

namespace WeatherForecast.Application.Services
{
	public class WeatherForecastService : IWeatherForecastService
	{
		private readonly HttpClient _client;
		private const string BasePath = $"https://localhost:7186/WeatherForecast/getweatherbylonandlat";

		public WeatherForecastService(HttpClient client)
		{
			_client = client ?? throw new ArgumentNullException(nameof(client));
			_client.BaseAddress = new Uri("https://api.openweathermap.org/");
		}

		public async Task<WheatherForest> Find(string latitude, string longitude)
		{
			var response = await _client.GetAsync(BasePath + $"?latitude={latitude}&longitude={longitude}");
			response.EnsureSuccessStatusCode();
			
			return await response.ReadContentAsync<WheatherForest>();
		}
	}
}
