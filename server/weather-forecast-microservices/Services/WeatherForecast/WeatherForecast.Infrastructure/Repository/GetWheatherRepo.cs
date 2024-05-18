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
	public class GetWheatherRepo : IGetWheatherRepo
	{
		private readonly HttpClient _client;
		private const string BasePath = $"https://localhost:7186/WeatherForecast/getweatherbylonandlat";

		public GetWheatherRepo(HttpClient client)
		{
			_client = client ?? throw new ArgumentNullException(nameof(client));
		}

		public async Task<WheatherSearchDto> Find(string latitude, string longitude)
		{
			var response = await _client.GetAsync(BasePath + $"?latitude={latitude}&longitude={longitude}");
			response.EnsureSuccessStatusCode();

			return await response.ReadContentAsync<WheatherSearchDto>();
		}
	}
}
