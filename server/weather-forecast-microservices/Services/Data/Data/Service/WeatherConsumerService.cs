using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Services;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using Worker.Repository;

namespace Data.Service
{
    public class WeatherConsumerService : IWeatherConsumerService, IDisposable
    {
        private readonly IModel _model;
        private readonly IConnection _connection;
        private readonly ICaching _caching;

        const string currentWeatherQueue = "current-weather-queue";
        const string weatherForecastQueue = "weather-forecast-queue";

        public WeatherConsumerService(IRabbitMQService rabbitMqService, ICaching caching)
        {
            _connection = rabbitMqService.CreateChannel();
            _model = _connection.CreateModel();
            this._caching = caching;
        }

        public async Task GetCurrentWeatherData(string lat, string lon)
        {
            _model.QueueDeclare(currentWeatherQueue, exclusive: false);

            var consumer = new AsyncEventingBasicConsumer(_model);

            var currentWeatherData = this._caching.GetCacheResponse("GetCurrentWeatherData");
            if (string.IsNullOrEmpty(currentWeatherData))
            {
                Exception exception = new Exception("Get Cache Response Failed");
                throw exception;
            }

            var responseBody = Encoding.UTF8.GetBytes(currentWeatherData);
            consumer.Received += async (model, ea) =>
            {
                try
                {
                    Console.WriteLine($"Received Request: {ea.BasicProperties.CorrelationId} - message: {Encoding.UTF8.GetString(ea.Body.ToArray())}");

                    var input = Encoding.UTF8.GetString(ea.Body.ToArray()).Split(';');

                    _model.BasicPublish("", ea.BasicProperties.ReplyTo, null, responseBody);
                    await Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    _model.BasicPublish("", ea.BasicProperties.ReplyTo, null, Encoding.UTF8.GetBytes(ex.Message));
                }

            };

            _model.BasicConsume(queue: currentWeatherQueue, autoAck: true, consumer: consumer);
            await Task.CompletedTask;
        }

        public async Task GetDailyWeatherData()
        {
            _model.QueueDeclare(weatherForecastQueue, exclusive: false);

            var consumer = new AsyncEventingBasicConsumer(_model);

            consumer.Received += async (model, ea) =>
            {
                try
                {
                    Console.WriteLine($"Received Request: {ea.BasicProperties.CorrelationId} - message: {Encoding.UTF8.GetString(ea.Body.ToArray())}");

                    var input = Encoding.UTF8.GetString(ea.Body.ToArray()).Split(';');

                    //var version = "data/2.5/";
                    //var response = await _httpClient.GetAsync($"{version}forecast?lat={input[0]}&lon={input[1]}&cnt=7&appid={apiKey}");
                    //response.EnsureSuccessStatusCode();
                    //var responseData = await response.Content.ReadAsStringAsync();

                    //var responseBody = Encoding.UTF8.GetBytes(responseData);
                    var daillyWeatherData = this._caching.GetCacheResponse("GetDailyWeatherData");
                    if (string.IsNullOrEmpty(daillyWeatherData))
                    {
                        Exception exception = new Exception("Get Cache Response Failed");
                        throw exception;
                    }
                    var responseBody = Encoding.UTF8.GetBytes(daillyWeatherData);
                    //if (!string.IsNullOrEmpty(responseData))
                    //{
                    //    var result = this._caching.SetCacheResponse("GetDailyWeatherData", responseBody);
                    //    if (!result)
                    //    {
                    //        Exception exception = new Exception("Set Cache Response Failed");
                    //        throw exception;
                    //    }
                    //}
                    //else
                    //{
                    //    var result = this._caching.RemoveCache("GetDailyWeatherData");
                    //    if (!result)
                    //    {
                    //        Exception exception = new Exception("Remove Cache Response Failed");
                    //        throw exception;
                    //    }
                    //}

                    _model.BasicPublish("", ea.BasicProperties.ReplyTo, null, responseBody);
                    await Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    _model.BasicPublish("", ea.BasicProperties.ReplyTo, null, Encoding.UTF8.GetBytes(ex.Message));
                }

            };

            _model.BasicConsume(queue: weatherForecastQueue, autoAck: true, consumer: consumer);
            await Task.CompletedTask;
        }

        public void Dispose()
        {
            if (_model.IsOpen)
                _model.Close();

            if (_connection.IsOpen)
                _connection.Close();
        }
    }
}
