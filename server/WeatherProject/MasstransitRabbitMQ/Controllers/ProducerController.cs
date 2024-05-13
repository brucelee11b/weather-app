using MassTransit;
using MasstransitContract.Enumerations;
using Microsoft.AspNetCore.Mvc;
using static MasstransitContract.IntergrationEvents.DomainEvent;

namespace MasstransitRabbitMQ.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProducerController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly HttpClient _httpClient;
        private string apiKey = "a138902a1200a09b2c57e0119815c601";
        public ProducerController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.openweathermap.org/"); // Thay đổi thành URL của hệ thống thứ ba
        }

        [HttpGet(Name = "publish-sms-notification")]
        public async Task<IActionResult> PublishSmsNotificationEvent()
        {

            await _publishEndpoint.Publish(new SmsNotificationEvent()
            {
                Id = Guid.NewGuid(),
                Description = "hello guy",
                Name = "sms note",
                TimeStamp = DateTime.UtcNow,
                TransactionId = Guid.NewGuid(),
                Type = NotificationType.sms
            });
            return Accepted();
        }

        //[HttpPost("getweatherbycityid")]
        //public async Task<IActionResult> GetWeatherByCityId(string cityId, string language)
        //{
        //    try
        //    {
        //        var version = "data/2.5/";
        //        var response = await _httpClient.GetAsync($"{version}weather?id={cityId}&lang={language}&appid={apiKey}&units=metric");
        //        response.EnsureSuccessStatusCode();
        //        var responseData = await response.Content.ReadAsStringAsync();
        //        return Ok(responseData);
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        return StatusCode(500, $"Error retrieving weather data: {ex.Message}");
        //    }
        //}

        //[HttpGet("getcityinfo")]
        //public async Task<IActionResult> GetCityInfo(string cityName)
        //{
        //    try
        //    {
        //        var version = "geo/1.0/";
        //        var response = await _httpClient.GetAsync($"direct?q={cityName}&limit=5&appid={apiKey}");
        //        response.EnsureSuccessStatusCode();
        //        var responseData = await response.Content.ReadAsStringAsync();
        //        return Ok(responseData);
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        return StatusCode(500, $"Error retrieving city data: {ex.Message}");
        //    }
        //}
    }
}
