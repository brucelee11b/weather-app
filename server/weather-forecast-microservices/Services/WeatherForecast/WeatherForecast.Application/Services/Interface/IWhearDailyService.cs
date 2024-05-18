using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Infrastructure.RepoDto;

namespace WeatherForecast.Application.Services.Interface
{
    public interface IWhearDailyService
    {
        Task<WheatherDaily> GetWheatherDaily(string latitude, string longitude, int count);

    }
}
