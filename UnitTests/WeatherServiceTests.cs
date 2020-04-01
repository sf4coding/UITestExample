using System;
using System.Threading.Tasks;
using NUnit.Framework;
using WeatherApp.Models;
using WeatherApp.Services;

namespace UnitTests
{
    [TestFixture]
    public class WeatherServiceTests
    {

        [TestCase("London")]
        [TestCase("Hürth")]
        public async Task WeatherApiRequest_ValidData(string city)
        {
            var receivedWeatherData = await GetWeatherData(city);

            Assert.AreEqual(city, receivedWeatherData.City);
            Assert.NotNull(receivedWeatherData.CurrentTemperature);
            Assert.NotNull(receivedWeatherData.MaxTemperature);
            Assert.NotNull(receivedWeatherData.MinTemperature);
            Assert.NotNull(receivedWeatherData.Humidity);
        }

        [TestCase("abc", "xyz")]
        public async Task WeatherApiRequest_InvalidData(string city, string countryCode)
        {
            var receivedWeatherData = await GetWeatherData(city);

            Assert.IsNull(receivedWeatherData);
        }

        private async Task<WeatherModel> GetWeatherData(string city)
        {
            var weatherService = new WeatherService();
            var weatherData = await weatherService.GetWeatherDataAsync(city);
            return weatherData;
        }
    }
}