using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Navigation.TabbedPages;
using Prism.Services;
using WeatherApp.Models;
using WeatherApp.Services;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    public class LocationViewModel : BindableBase
    {
        private string _location = string.Empty;
        private bool _isLoadingWeatherData;
        private bool _isLocationEntered;
        private WeatherModel _weatherData;

        private readonly IWeatherService _weatherService;
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;

        public LocationViewModel(IWeatherService weatherService, INavigationService navigationService,
                                 IPageDialogService dialogService)
        {
            _weatherService = weatherService;
            _navigationService = navigationService;
            _dialogService = dialogService;

            LoadWeatherDataCommand = new Command(async () => await LoadAndShowWeatherDataAsync());
        }

        public string Location
        {
            get => _location;
            set
            {
                SetProperty(ref _location, value);
                IsLocationEntered = !string.IsNullOrEmpty(_location);
            }
        }

        public Command LoadWeatherDataCommand { get; }

        public bool IsLoadingWeatherData
        {
            get => _isLoadingWeatherData;
            set => SetProperty(ref _isLoadingWeatherData, value);
        }

        public bool IsLocationEntered
        {
            get => _isLocationEntered;
            set => SetProperty(ref _isLocationEntered, value);
        }

        private async Task GoToWeatherDataPage()
        {
            var parameter = new NavigationParameters {{"weatherData", _weatherData}};
            await _navigationService.SelectTabAsync("CurrentWeatherPage", parameter);
        }

        private async Task LoadAndShowWeatherDataAsync()
        {
            await LoadWeatherDataAsync();
            await ShowWeatherDataAsync();
        }

        private async Task LoadWeatherDataAsync()
        {
            IsLoadingWeatherData = true;
            _weatherData = await _weatherService.GetWeatherDataAsync(Location);
            IsLoadingWeatherData = false;
        }

        private async Task ShowWeatherDataAsync()
        {
            if (_weatherData != null)
            {
                await GoToWeatherDataPage();
            }
            else
            {
                await ShowCityDoesNotExistAlert();
            }
        }

        private async Task ShowCityDoesNotExistAlert()
        {
            await _dialogService.DisplayAlertAsync("Weather App", "This city does not exist.", "OK");
        }
    }
}