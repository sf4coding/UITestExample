using System;
using Xamarin.UITest;

namespace UITests.PageObjects
{
    public abstract class BasePageObject
    {
        protected IApp App { get; }
        
        protected TimeSpan MediumTimeSpan = new TimeSpan(0, 0, 30);

        protected BasePageObject(IApp app)
        {
            App = app;
        }

        public abstract bool VerifyOnPage();
    }
}