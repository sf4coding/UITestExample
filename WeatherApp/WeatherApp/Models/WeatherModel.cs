using System;

namespace WeatherApp.Models
{
    public class WeatherModel
    {
        public string City { get; set; }
        public float CurrentTemperature { get; set; }
        public float MaxTemperature { get; set; }
        public float MinTemperature { get; set; }
        public float Humidity { get; set; }
    }
}