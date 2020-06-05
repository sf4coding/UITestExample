using System.Linq;
using Xamarin.UITest;
using static TestIds.TestIds;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace UITests.PageObjects
{
    public class CurrentWeatherPageObject : BaseWeatherAppPageObject
    {
        private readonly Query _locationData = x => x.Marked(CurrentWeatherLocationDataLabel);
        private readonly Query _currentTemperatureData = x => x.Marked(CurrentWeatherCurrentTemperatureDataLabel);
        private readonly Query _maxTemperatureData = x => x.Marked(CurrentWeatherMaxTemperatureDataLabel);
        private readonly Query _minTemperatureData = x => x.Marked(CurrentWeatherMinTemperatureDataLabel);
        private readonly Query _humidityData = x => x.Marked(CurrentWeatherHumidityDataLabel);
        
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