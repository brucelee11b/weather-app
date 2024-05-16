using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Domain.Entity;

namespace WeatherForecast.Application.Services
{
	public interface IWeatherForecastService
	{
		Task<WheatherForest> Find(string latitude, string longitude);
	}
}
