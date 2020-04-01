using System;

namespace WeatherApp.Helpers
{
    public static class Converter
    {
        public static int ConvertKelvinToCelsius(float degreeInKelvin)
        {
            var kelvinOffset = 273.15f;
            var degreeInCelsius = degreeInKelvin - kelvinOffset;
            return (int) Math.Round(degreeInCelsius);
        }
        
        public static float ConvertAbsoluteHumidityToPercent(int humidity)
        {
            return (float)humidity / 100;
        }
    }
}