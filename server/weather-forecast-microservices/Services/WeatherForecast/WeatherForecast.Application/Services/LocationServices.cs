using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Application.Services.Interface;
using WeatherForecast.Infrastructure.IRepository;
using WeatherForecast.Infrastructure.RepoDto;
using WeatherForecast.Infrastructure.WebHelper;

namespace WeatherForecast.Application.Services
{
    public class LocationServices : ILocationServices
	{
		private readonly IGetCityLocationRepo _cityLocationRepo;
		public LocationServices(IGetCityLocationRepo cityLocationRepo)
		{
			_cityLocationRepo = cityLocationRepo;
		}
		public async Task<IEnumerable<LocationDto>> SearchCity(string name, int num)
		{
			return _cityLocationRepo.SearchCity(name, num).Result.ToList();
		}
	}
}
