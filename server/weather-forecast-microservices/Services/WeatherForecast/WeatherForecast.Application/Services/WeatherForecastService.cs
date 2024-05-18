using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherForecast.Application.Services.Interface;
using WeatherForecast.Domain.Entity;
using WeatherForecast.Infrastructure.IRepository;
using WeatherForecast.Infrastructure.RepoDto;
using WeatherForecast.Infrastructure.WebHelper;

namespace WeatherForecast.Application.Services
{
	public class WeatherForecastService : IWeatherForecastService
	{
		private readonly IGetCityLocationRepo _getCity;
		private readonly IGetWheatherRepo _getWheather;

		public WeatherForecastService(IGetCityLocationRepo getCity , IGetWheatherRepo getWheather)
		{
			_getCity = getCity;
			_getWheather = getWheather;
		}

		public Task<WheatherSearchDto> Find(string lat, string lon)
		{
			return _getWheather.Find(lat, lon);
		}

		public Task<WheatherSearchDto> FindByName(string name)
		{
			var city = _getCity.SearchCity(name, 1);
			var input = city.Result.FirstOrDefault();
			var result = _getWheather.Find(input.lat.ToString(), input.lon.ToString());
			return result;
		}
	}
}
