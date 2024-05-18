using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Domain.Entity;
using WeatherForecast.Infrastructure.RepoDto;

namespace WeatherForecast.Application.Services.Interface
{
    public interface IWeatherForecastService
    {
        Task<WheatherSearchDto> FindByName(string name);
        Task<WheatherSearchDto> Find(string lat, string lon);
    }
}
