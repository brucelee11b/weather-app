using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Infrastructure.RepoDto;

namespace WeatherForecast.Application.Services.Interface
{
    public interface ILocationServices
    {
        Task<IEnumerable<LocationDto>> SearchCity(string name, int num);

    }
}
