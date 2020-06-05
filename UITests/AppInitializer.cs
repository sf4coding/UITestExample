using System;
using System.IO;
using Xamarin.UITest;

namespace UITests
{
    public enum IDE
    {
        Rider,
        VisualStudio
    }
    
    public static class AppInitializer
    {
        private static readonly char DirSep = Path.DirectorySeparatorChar;

        public static IDE IDE { get; private set; }

        public static IApp StartApp(Platform platform)
        {
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
                        $"WeatherApp{DirSep}WeatherApp.iOS{DirSep}bin{DirSep}UITest{DirSep}WeatherApp.iOS.app";
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
            IDE = IDE.Rider;

            // apk is a file -- app is a directory
            if (!File.Exists(file) && !Directory.Exists(file))
            {
                file = Path.Combine(basePathVisualStudio, $"..{DirSep}..{DirSep}..", fileEnd);
                IDE = IDE.VisualStudio;
            }

            return file;
        }
    }
}