using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Application.Services.Interface;

namespace WeatherForecast.API.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class WheatherDailyController : ControllerBase
	{
		private readonly IWhearDailyService _service;
		public WheatherDailyController(IWhearDailyService service)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
		}

		[HttpGet("ShowDaily")]
		public async Task<IActionResult> WeatherDailyShow(string lat, string lon , int count)
		{

			var products = await _service.GetWheatherDaily(lat, lon, count);
			return Ok(products);
		}
	}
}
