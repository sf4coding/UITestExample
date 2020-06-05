using NUnit.Framework;
using UITests.PageObjects;
using Xamarin.UITest;

namespace UITests.Tests
{
    public class LocationTest : BaseTestFixture
    {
        public LocationTest(Platform platform) : base(platform)
        {
        }

        [Test]
        public void EnterValidLocationTest()
        {
            const string location = "Hürth";
            var locationPageObject = EnterLocation(location);
            var currentWeatherPage = (CurrentWeatherPageObject)locationPageObject.TapSearchButton();
            Assert.True(currentWeatherPage.IsWeatherDataDisplayed(location));
        }
        
        [Test]
        public void EnterInvalidLocationTest()
        {
            const string location = "abc";
            var locationPageObject = EnterLocation(location);
            locationPageObject.TapSearchButton();
            Assert.True(locationPageObject.IsInvalidLocationDialogDisplayed());
            locationPageObject.CloseInvalidLocationDialog();
            Assert.False(locationPageObject.IsInvalidLocationDialogDisplayed());
            Assert.True(locationPageObject.VerifyOnPage());
        }

        [Test]
        public void GoToCurrentWeatherTabTest()
        {
            var locationPageObject = new LocationPageObject(App);
            var currentWeatherPage = locationPageObject.TapCurrentWeatherTab();
            Assert.False(currentWeatherPage.IsWeatherDataDisplayed(""));
        }

        private LocationPageObject EnterLocation(string location)
        {
            var locationPageObject = new LocationPageObject(App);
            Assert.False(locationPageObject.IsSearchButtonEnabled());
            locationPageObject.EnterLocation(location);
            Assert.True(locationPageObject.IsSearchButtonEnabled());
            return locationPageObject;
        }

        
        [Test]
        public void StartRepl()
        {
            App.Repl();
        }
    }
}