
using MauiWeather_Application.Models;

namespace MauiWeather_Application.Services
{
    public interface IWeatherService
    {
        Task<WeatherResponse?> GetWeatherAsync(
            double latitude,
            double longitude);
    }
}
