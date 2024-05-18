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
	public class GetWheatherDailyRepo : IGetWheatherDailyRepo
	{
		private readonly HttpClient _client;
		private const string BasePath = $"https://localhost:7186/WeatherForecast/getdailyweatherbylonandlat";

		public GetWheatherDailyRepo(HttpClient client)
		{
			_client = client ?? throw new ArgumentNullException(nameof(client));
		}
		public async Task<WheatherDaily> GetDaily(string latitude, string longitude, int count)
		{
			var response = await _client.GetAsync(BasePath + $"?latitude={latitude}&longitude={longitude}&count={count}");
			response.EnsureSuccessStatusCode();

			return await response.ReadContentAsync<WheatherDaily>();
		}
	}
}
