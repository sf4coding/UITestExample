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

        public override bool VerifyOnPage()
        {
            throw new System.NotImplementedException();
        }
    }
    
}