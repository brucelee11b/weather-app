using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Services;
using System.Text;

namespace Data.Service
{
    public class WeatherConsumerService : IWeatherConsumerService, IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly string apiKey = "a138902a1200a09b2c57e0119815c601";
        private readonly IModel _model;
        private readonly IConnection _connection;

        public WeatherConsumerService(IRabbitMQService rabbitMqService)
        {
            _connection = rabbitMqService.CreateChannel();
            _model = _connection.CreateModel();
            _model.QueueDeclare("request-queue", exclusive: false);

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.openweathermap.org/");
        }

        public async Task GetCurrentWeatherData()
        {
            var consumer = new AsyncEventingBasicConsumer(_model);

            consumer.Received += async (model, ea) =>
            {
                try
                {
                    Console.WriteLine($"Received Request: {ea.BasicProperties.CorrelationId} - message: {Encoding.UTF8.GetString(ea.Body.ToArray())}");

                    var input = Encoding.UTF8.GetString(ea.Body.ToArray()).Split(';');

                    var version = "data/2.5/";
                    var response = await _httpClient.GetAsync($"{version}weather?lat={input[0]}&lon={input[1]}&appid={apiKey}");
                    response.EnsureSuccessStatusCode();
                    var responseData = await response.Content.ReadAsStringAsync();

                    var responseBody = Encoding.UTF8.GetBytes(responseData);

                    _model.BasicPublish("", ea.BasicProperties.ReplyTo, null, responseBody);
                    await Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    _model.BasicPublish("", ea.BasicProperties.ReplyTo, null, Encoding.UTF8.GetBytes(ex.Message));
                }

            };

            _model.BasicConsume(queue: "request-queue", autoAck: true, consumer: consumer);
            await Task.CompletedTask;
        }

        public async Task GetDailyWeatherData()
        {
            try
            {
                var version = "data/2.5/";
                var response = await _httpClient.GetAsync($"{version}forecast?lat={123}&lon={123}&cnt=7&appid={apiKey}");
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadAsStringAsync();
                await Task.CompletedTask;
            }
            catch (HttpRequestException ex)
            {

            }
        }

        public void Dispose()
        {
            if (_model.IsOpen)
                _model.Close();

            if (_connection.IsOpen)
                _connection.Close();

            _httpClient?.Dispose();
        }
    }
}
