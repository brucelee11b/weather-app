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
    public class WheartherDailyServices : IWhearDailyService
	{
		private readonly IGetWheatherDailyRepo _getWheatherDaily;

		public WheartherDailyServices(IGetWheatherDailyRepo getWheatherDaily)
		{
			_getWheatherDaily = getWheatherDaily;
		}
		public async Task<WheatherDaily> GetWheatherDaily(string latitude, string longitude, int count)
		{
			return _getWheatherDaily.GetDaily(latitude, longitude, count).Result;
		}
	}
}
