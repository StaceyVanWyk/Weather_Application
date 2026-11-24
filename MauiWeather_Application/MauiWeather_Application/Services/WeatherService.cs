
using System.Net.Http;
using System.Text.Json;
using MauiWeather_Application.Models;
using MauiWeather_Application.Configuration;

namespace MauiWeather_Application.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;

        private const string ApiKey = ApiKeys.OpenWeather;

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherResponse?> GetWeatherAsync(
            double latitude,
            double longitude)
        {
            string url =
                $"https://api.openweathermap.org/data/2.5/weather" +
                $"?lat={latitude}&lon={longitude}" +
                $"&appid={ApiKey}&units=metric";

            HttpResponseMessage response =
                await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string json =
                await response.Content.ReadAsStringAsync();

            WeatherResponse? weather =
                JsonSerializer.Deserialize<WeatherResponse>(json);

            return weather;
        }
    }
}
