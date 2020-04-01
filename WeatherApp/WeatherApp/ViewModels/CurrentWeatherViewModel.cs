using Prism.Mvvm;
using Prism.Navigation;
using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public class CurrentWeatherViewModel : BindableBase, INavigatedAware
    {
        private WeatherModel _weatherData;

        private readonly INavigationService _navigationService;
        

        public CurrentWeatherViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _weatherData = new WeatherModel
            {
                City = "Cityname",
                CurrentTemperature = float.NaN,
                MinTemperature = float.NaN,
                MaxTemperature = float.NaN,
                Humidity = float.NaN
            };
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            WeatherData = parameters["weatherData"] as WeatherModel;
        }

        public WeatherModel WeatherData
        {
            get => _weatherData;
            set => SetProperty(ref _weatherData, value);
        }
    }
}