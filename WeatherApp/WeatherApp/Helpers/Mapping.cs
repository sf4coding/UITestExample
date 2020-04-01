using System;
using WeatherApp.ApiModels;
using WeatherApp.Models;

namespace WeatherApp.Helpers
{
    public static class Mapping
    {
        public static WeatherModel ToModel(WeatherApiModel apiModel)
        {
            return new WeatherModel
            {
                City = apiModel.City,
                CurrentTemperature = Converter.ConvertKelvinToCelsius(apiModel.TemperatureAndHumidityModel.CurrentTemperatureInKelvin),
                MaxTemperature = Converter.ConvertKelvinToCelsius(apiModel.TemperatureAndHumidityModel.MaxTemperatureInKelvin),
                MinTemperature = Converter.ConvertKelvinToCelsius(apiModel.TemperatureAndHumidityModel.MinTemperatureInKelvin),
                Humidity = Converter.ConvertAbsoluteHumidityToPercent(apiModel.TemperatureAndHumidityModel.Humidity)
            };
        }
    }
}