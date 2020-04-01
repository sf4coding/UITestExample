using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITests.PageObjects
{
    public class BaseWeatherAppPageObject : BasePageObject
    {
        private readonly Func<AppQuery, AppQuery> _locationTab = x => x.Marked("Location");
        private readonly Func<AppQuery, AppQuery> _currentWeatherTab = x => x.Marked("Now");
        
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