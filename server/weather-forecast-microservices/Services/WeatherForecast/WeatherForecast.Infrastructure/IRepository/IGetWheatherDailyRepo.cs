using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Infrastructure.RepoDto;

namespace WeatherForecast.Infrastructure.IRepository
{
	public interface IGetWheatherDailyRepo
	{
		Task<WheatherDaily> GetDaily(string latitude, string longitude, int count);

	}
}
