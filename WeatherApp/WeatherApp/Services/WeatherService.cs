using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WeatherApp.ApiModels;
using WeatherApp.Helpers;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherService : IWeatherService
    {
        /* TODO insert your personal appid here
           https://api.openweathermap.org/api */
        private const string Appid = "your_personal_appid";

        private HttpClient _weatherHttpClient;
        public WeatherService()
        {
            InitializeHttpClient();
        }
        
        public async Task<WeatherModel> GetWeatherDataAsync(string city)
        {
            var uriExtension = new Uri($"/data/2.5/weather?q={city}&APPID={Appid}");
            using (HttpResponseMessage response = await _weatherHttpClient.GetAsync(uriExtension))
            {
                if (response.IsSuccessStatusCode)
                {
                    var weatherData = await response.Content.ReadAsAsync<WeatherApiModel>();
                    return Mapping.ToModel(weatherData);
                }

                return null;
            }
        }
        
        private void InitializeHttpClient()
        {
            _weatherHttpClient = new HttpClient();
            _weatherHttpClient.DefaultRequestHeaders.Accept.Clear();
            _weatherHttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _weatherHttpClient.BaseAddress = new Uri("https://api.openweathermap.org/");
        }
    }
}