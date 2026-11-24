using Microsoft.Maui.Devices.Sensors;

namespace MauiWeather_Application.Services
{
    public interface IGeolocationService
    {
        Task<Location?> GetCurrentLocationAsync();
    }
}
