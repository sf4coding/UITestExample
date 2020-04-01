using System;
using System.Linq;
using WeatherApp.Views.AutomationIds;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITests.PageObjects
{
    public class LocationPageObject : BaseWeatherAppPageObject
    {
        private readonly Func<AppQuery, AppQuery> _locationEntry = x => x.Marked(AutomationIds.LocationLocationEntry);
        private readonly Func<AppQuery, AppQuery> _locationSearchButton = x => x.Marked(AutomationIds.LocationSearchButton);
        private readonly Func<AppQuery, AppQuery> _locationLoadingCircle = x => x.Marked(AutomationIds.LocationLoadingCircle);
        
        private readonly Func<AppQuery, AppQuery> _dialogText = x => x.Text("This city does not exist.");
        private readonly Func<AppQuery, AppQuery> _dialogButton = x => x.Text("OK");

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
    }
}