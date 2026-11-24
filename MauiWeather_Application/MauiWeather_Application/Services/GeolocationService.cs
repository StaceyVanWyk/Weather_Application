using Microsoft.Maui.Devices.Sensors;

namespace MauiWeather_Application.Services
{
    public class GeolocationService : IGeolocationService
    {
        public async Task<Location?> GetCurrentLocationAsync()
        {
            var request = new GeolocationRequest(
                GeolocationAccuracy.Medium,
                TimeSpan.FromSeconds(10));

            Location? location =
                await Geolocation.Default.GetLocationAsync(request);

            return location;
        }
    }
}
