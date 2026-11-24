using MauiWeather_Application.Services;
using System.Windows.Input;

namespace MauiWeather_Application.ViewModels;

public class MainPageViewModel : BaseViewModel
{
    private bool _isLoading;
    private readonly IGeolocationService _geolocationService;

    private double _latitude;
    private double _longitude;

    public MainPageViewModel(IGeolocationService geolocationService)
    {
        _geolocationService = geolocationService;
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
        }
    }
}
}