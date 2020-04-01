using System;
using System.Linq;
using WeatherApp.Views.AutomationIds;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITests.PageObjects
{
    public class CurrentWeatherPageObject : BaseWeatherAppPageObject
    {
        private readonly Func<AppQuery, AppQuery> _locationData = x => x.Marked(AutomationIds.CurrentWeatherLocationDataLabel);
        private readonly Func<AppQuery, AppQuery> _currentTemperatureData = x => x.Marked(AutomationIds.CurrentWeatherCurrentTemperatureDataLabel);
        private readonly Func<AppQuery, AppQuery> _maxTemperatureData = x => x.Marked(AutomationIds.CurrentWeatherMaxTemperatureDataLabel);
        private readonly Func<AppQuery, AppQuery> _minTemperatureData = x => x.Marked(AutomationIds.CurrentWeatherMinTemperatureDataLabel);
        private readonly Func<AppQuery, AppQuery> _humidityData = x => x.Marked(AutomationIds.CurrentWeatherHumidityDataLabel);
        
        public CurrentWeatherPageObject(IApp app) : base(app)
        {
        }

        public override bool VerifyOnPage()
        {
            try
            {
                App.WaitForElement(_locationData);
                App.WaitForElement(_currentTemperatureData);
                App.WaitForElement(_maxTemperatureData);
                App.WaitForElement(_minTemperatureData);
                App.WaitForElement(_humidityData);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool IsWeatherDataDisplayed(string enteredLocation)
        {
            if (!VerifyOnPage())
            {
                return false;
            }
            
            string invalidData = float.NaN.ToString();
            var location = App.Query(_locationData).FirstOrDefault()?.Text;
            var currentTemp = App.Query(_currentTemperatureData).FirstOrDefault()?.Text;
            var maxTemp = App.Query(_maxTemperatureData).FirstOrDefault()?.Text;
            var minTemp = App.Query(_minTemperatureData).FirstOrDefault()?.Text;
            var humidity = App.Query(_humidityData).FirstOrDefault()?.Text;

            if (location != enteredLocation || currentTemp == invalidData || maxTemp == invalidData ||
                minTemp == invalidData || humidity == invalidData)
            {
                return false;
            }
            return true;
        }
    }
}