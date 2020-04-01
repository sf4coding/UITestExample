using Newtonsoft.Json;

namespace WeatherApp.ApiModels
{
    public class WeatherApiModel
    {
        [JsonProperty("name")] 
        public string City { get; set; }

        [JsonProperty("main")] 
        public TemperatureAndHumidityModel TemperatureAndHumidityModel { get; set; }
    }

    public class TemperatureAndHumidityModel
    {
        [JsonProperty("temp")] 
        public float CurrentTemperatureInKelvin { get; set; }

        [JsonProperty("temp_max")]
        public float MaxTemperatureInKelvin { get; set; }

        [JsonProperty("temp_min")]
        public float MinTemperatureInKelvin { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }
    }
}