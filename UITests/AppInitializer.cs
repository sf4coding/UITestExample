using System;
using System.IO;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITests
{
    public enum Ide
    {
        Rider,
        VisualStudio
    }
    
    public static class AppInitializer
    {
        private static readonly char DirSep = Path.DirectorySeparatorChar;

        public static Platform Platform { get; private set; }
        
        public static Ide Ide { get; private set; }

        public static IApp StartApp(Platform platform)
        {
            Platform = platform;

            switch (platform)
            {
                case Platform.Android:
                {
                    var apkFileEnd =
                        $"WeatherApp{DirSep}WeatherApp.Android{DirSep}bin{DirSep}UITest{DirSep}my.WeatherApp-Signed.apk";
                    var apkFile = GetApplicationFile(apkFileEnd);

                    return ConfigureApp.Android.EnableLocalScreenshots().ApkFile(apkFile).StartApp();
                }
                case Platform.iOS:
                {
                    var appFileEnd =
                        $"WeatherApp{DirSep}WeatherApp.iOS{DirSep}bin{DirSep}UITest{DirSep}device-builds{DirSep}iphone10.5-13.3{DirSep}WeatherApp.iOS.app";
                    var appFile = GetApplicationFile(appFileEnd);

                    return ConfigureApp.iOS.EnableLocalScreenshots().AppBundle(appFile).StartApp();
                }
                default:
                    throw new Exception("Unknown platform");
            }
        }

        private static string GetApplicationFile(string fileEnd)
        {
            var basePathRider = AppDomain.CurrentDomain.BaseDirectory;
            var basePathVisualStudio = Environment.CurrentDirectory;

            var file = Path.Combine(basePathRider, $"..{DirSep}..{DirSep}..", fileEnd);
            Ide = Ide.Rider;

            // apk is a file, app is a directory
            if (!File.Exists(file) && !Directory.Exists(file))
            {
                file = Path.Combine(basePathVisualStudio, $"..{DirSep}..{DirSep}..", fileEnd);
                Ide = Ide.VisualStudio;
            }

            return file;
        }
    }
}