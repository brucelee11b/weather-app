using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Application.Services.Interface;

namespace WeatherForecast.API.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class LocationController : ControllerBase
	{
		private readonly ILocationServices _service;
		public LocationController(ILocationServices service)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
		}

		[HttpGet("getcity")]
		public async Task<IActionResult> GetLocation(string name, int num)
		{
			var products = await _service.SearchCity(name, num);
			return Ok(products);
		}
	}
}
