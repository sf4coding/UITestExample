using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace UITests.PageObjects
{
    public class BaseWeatherAppPageObject : BasePageObject
    {
        private readonly Query _locationTab = x => x.Marked("Location");
        private readonly Query _currentWeatherTab = x => x.Marked("Now");
        
        public BaseWeatherAppPageObject(IApp app) : base(app)
        {
        }

        public override bool VerifyOnPage()
        {
            try
            {
                App.WaitForElement(_locationTab);
                App.WaitForElement(_currentWeatherTab);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public LocationPageObject TapLocationTab()
        {
            App.WaitForElement(_locationTab);
            App.Tap(_locationTab);
            return new LocationPageObject(App);
        }
        
        public CurrentWeatherPageObject TapCurrentWeatherTab()
        {
            App.WaitForElement(_currentWeatherTab);
            App.Tap(_currentWeatherTab);
            return new CurrentWeatherPageObject(App);
        }
    }
    
}