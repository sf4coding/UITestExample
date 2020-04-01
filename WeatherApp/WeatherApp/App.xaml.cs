using System;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using WeatherApp.Services;
using WeatherApp.ViewModels;
using WeatherApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace WeatherApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer platformInitializer = null) : base(platformInitializer)
        {
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync("MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<LocationPage, LocationViewModel>();
            containerRegistry.RegisterForNavigation<CurrentWeatherPage, CurrentWeatherViewModel>();
            containerRegistry.Register<IWeatherService, WeatherService>();
        }
    }
}