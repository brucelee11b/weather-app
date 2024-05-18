using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Infrastructure.RepoDto;

namespace WeatherForecast.Infrastructure.IRepository
{
	public interface IGetCityLocationRepo
	{
		Task<IEnumerable<LocationDto>> SearchCity(string name, int num);

	}
}
