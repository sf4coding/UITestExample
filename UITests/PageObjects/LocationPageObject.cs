using System.Linq;
using Xamarin.UITest;
using static TestIds.TestIds;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace UITests.PageObjects
{
    public class LocationPageObject : BaseWeatherAppPageObject
    {
        private readonly Query _locationEntry = x => x.Marked(WeatherLocationLocationEntry);
        private readonly Query _locationSearchButton = x => x.Marked(WeatherLocationSearchButton);
        private readonly Query _locationLoadingCircle = x => x.Marked(WeatherLocationLoadingCircle);
        private readonly Query _dialogText = x => x.Text("This city does not exist.");
        private readonly Query _dialogButton = x => x.Text("OK");

        public LocationPageObject(IApp app) : base(app)
        {
        }

        public override bool VerifyOnPage()
        {
            try
            {
                App.WaitForElement(_locationEntry);
                App.WaitForElement(_locationSearchButton);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void EnterLocation(string location)
        {
            App.WaitForElement(_locationEntry);
            App.EnterText(_locationEntry, location);
        }

        public BasePageObject TapSearchButton()
        {
            App.WaitForElement(_locationSearchButton);
            App.Tap(_locationSearchButton);
            App.WaitForNoElement(_locationLoadingCircle, "Timed out waiting for the loading circle to vanish.", MediumTimeSpan);
            if (IsInvalidLocationDialogDisplayed())
            {
                return this;
            }
            return new CurrentWeatherPageObject(App);
        }

        public bool IsSearchButtonEnabled()
        {
            App.WaitForElement(_locationSearchButton);
            var searchButton = App.Query(_locationSearchButton).FirstOrDefault();
            return searchButton?.Enabled ?? false;
        }

        public bool IsInvalidLocationDialogDisplayed()
        {
            try
            {
                App.WaitForElement(_dialogText);
                App.WaitForElement(_dialogButton);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public void CloseInvalidLocationDialog()
        {
            App.WaitForElement(_dialogButton);
            App.Tap(_dialogButton);
            App.WaitForNoElement(_dialogButton);
        }

        public CurrentWeatherPageObject SwipeToCurrentWeatherTab()
        {
            App.SwipeRightToLeft();
            return new CurrentWeatherPageObject(App);
        }
    }
}