using MauiWeather_Application.Services;
using System.Windows.Input;
using MauiWeather_Application.Commands;
using MauiWeather_Application.Models;

namespace MauiWeather_Application.ViewModels;

public class MainPageViewModel : BaseViewModel
{
    private bool _isLoading;
    private readonly IGeolocationService _geolocationService;
    private readonly IWeatherService _weatherService;
    private WeatherResponse? _weather;

    private double _latitude;
    private double _longitude;
    public ICommand GetLocationCommand { get; }
    public MainPageViewModel(
    IGeolocationService geolocationService,
    IWeatherService weatherService)
{
    _geolocationService = geolocationService;
    _weatherService = weatherService;

    GetLocationCommand = new AsyncRelayCommand(
        GetCurrentLocationAsync,
        () => !IsLoading);
}
    public double Latitude
    {
        get => _latitude;
        set
        {
            if (_latitude != value)
            {
                _latitude = value;
                OnPropertyChanged();
            }
        }
    }

    public double Longitude
    {
        get => _longitude;
        set
        {
            if (_longitude != value)
            {
                _longitude = value;
                OnPropertyChanged();
            }
        }
    }
   public WeatherResponse? Weather
{
    get => _weather;
    set
    {
        if (_weather != value)
        {
            _weather = value;
            OnPropertyChanged();
        }
    }
}
  public async Task GetCurrentLocationAsync()
{
    try
    {
        IsLoading = true;

        var location = await _geolocationService.GetCurrentLocationAsync();

        if (location != null)
        {
            Latitude = location.Latitude;
            Longitude = location.Longitude;
        }
        Weather = await _weatherService.GetWeatherAsync(
                    Latitude,
                    Longitude);
    }
    finally
    {
        IsLoading = false;
    }
}
public bool IsLoading
{
    get => _isLoading;
    set
    {
        if (_isLoading != value)
        {
            _isLoading = value;
            OnPropertyChanged();
            (GetLocationCommand as AsyncRelayCommand)?.NotifyCanExecuteChanged();
        }
    }
}
}