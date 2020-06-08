using System;
using System.IO;
using NUnit.Framework;
using Xamarin.UITest;

namespace UITests.Tests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class BaseTestFixture
    {
        protected IApp App;
        protected bool OnAndroid => _platform == Platform.Android;
        protected bool OniOS => _platform == Platform.iOS;
        private readonly Platform _platform;

        public BaseTestFixture(Platform platform)
        {
            _platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            App = AppInitializer.StartApp(_platform);
        }

        [TearDown]
        public void AfterEachTest()
        {
            var testResult = TestContext.CurrentContext.Result.Status;
            if (testResult != TestStatus.Failed)
            {
                return;
            }

            SaveScreenshot();
        }

        private string CreateDestPath()
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            if (AppInitializer.IDE == IDE.VisualStudio)
            {
                basePath = Environment.CurrentDirectory;
            }
            var screenshotPath = Path.Combine(basePath, "../../UITestScreenshots");
            var platform = _platform.ToString();
            var testName = TestContext.CurrentContext.Test.Name;
            var screenshotName = $"{platform}_{testName}.png";
            var destPath = Path.Combine(screenshotPath, screenshotName);
            return destPath;
        }

        private void SaveScreenshot()
        {
            var destPath = CreateDestPath();
            
            var fileInfo = App.Screenshot("");
            if (File.Exists(destPath))
            {
                File.Delete(destPath);
            }
            fileInfo.MoveTo(destPath);
        }
    }
}