using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Infrastructure.IRepository;
using WeatherForecast.Infrastructure.RepoDto;
using WeatherForecast.Infrastructure.WebHelper;

namespace WeatherForecast.Infrastructure.Repository
{
	public class GetCityLocationRepo : IGetCityLocationRepo
	{
		private readonly HttpClient _client;
		private const string BasePath = $"https://localhost:7186/WeatherForecast/getcitylongandlatinfo";

		public GetCityLocationRepo(HttpClient client)
		{
			_client = client ?? throw new ArgumentNullException(nameof(client));
		}
		public async Task<IEnumerable<LocationDto>> SearchCity(string name, int num)
		{
			var response = await _client.GetAsync(BasePath + $"?cityName={name}&num={num}");
			response.EnsureSuccessStatusCode();

			return await response.ReadContentAsync<List<LocationDto>>();
		}
	}
}
