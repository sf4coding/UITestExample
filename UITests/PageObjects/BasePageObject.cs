using System;
using NUnit.Framework;
using Xamarin.UITest;

namespace UITests.PageObjects
{
    public abstract class BasePageObject
    {
        protected TimeSpan MediumTimeSpan = TimeSpan.FromSeconds(30);
        protected IApp App { get; }

        protected BasePageObject(IApp app)
        {
            App = app;
            AssertOnPage();
        }

        public abstract bool VerifyOnPage();

        private void AssertOnPage()
        {
            var message = "Unable to verify on page: " + GetType().Name;
            Assert.IsTrue(VerifyOnPage(), message);
        }
    }
}