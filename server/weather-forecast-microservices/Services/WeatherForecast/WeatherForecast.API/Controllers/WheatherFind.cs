using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Application.Services;

namespace WeatherForecast.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WheatherFind : Controller
	{
		private readonly IWeatherForecastService _service;
		public WheatherFind(IWeatherForecastService service)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
		}

		[HttpGet("Find")]
		public async Task<IActionResult> WeatherForecastIndex(string lat, string lon)
		{
			var products = await _service.Find(lat, lon);
			return Ok(products);
		}
	}
}
