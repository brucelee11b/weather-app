using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Application.Services.Interface;

namespace WeatherForecast.API.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class WheatherForeController : Controller
	{
		private readonly IWeatherForecastService _service;

		public WheatherForeController(IWeatherForecastService service)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
		}

		[HttpGet("searchbyname")]
		public async Task<IActionResult> WeatherForecastIndex(string name)
		{
			var products = await _service.FindByName(name);
			return Ok(products);
		}

		[HttpGet("search")]
		public async Task<IActionResult> WeatherForecastSeach(string lat, string lon)
		{
			var products = await _service.Find(lat, lon);
			return Ok(products);
		}
	}
}
