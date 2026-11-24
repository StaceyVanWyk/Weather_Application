
using System.Text.Json.Serialization;

namespace MauiWeather_Application.Models
{
    public class WeatherResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("main")]
        public WeatherMain Main { get; set; } = new();

        [JsonPropertyName("weather")]
        public List<WeatherCondition> Weather { get; set; } = new();

        [JsonPropertyName("wind")]
        public Wind Wind { get; set; } = new();
    }

    public class WeatherMain
    {
        [JsonPropertyName("temp")]
        public double Temperature { get; set; }

        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
    }

    public class WeatherCondition
    {
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("icon")]
        public string Icon { get; set; } = string.Empty;
    }

    public class Wind
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }
    }
}
