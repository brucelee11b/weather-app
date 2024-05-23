namespace Data.Service
{
    public interface IWeatherConsumerService
    {
        public Task GetCurrentWeatherData();
        public Task GetDailyWeatherData();
    }
}
