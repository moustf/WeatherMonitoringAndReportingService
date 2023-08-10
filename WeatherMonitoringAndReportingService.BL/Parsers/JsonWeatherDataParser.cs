using System.Text.Json;
using WeatherMonitoringAndReportingService.BL.Weather;

namespace WeatherMonitoringAndReportingService.BL.Parsers;

public class JsonWeatherDataParser : IParser
{
    public WeatherData WeatherData { get; set; }

    public JsonWeatherDataParser()
    {
        WeatherData = new WeatherData("", 0, 0);
    }

    public WeatherData Parse(string weatherData)
    {
        var weatherInput = JsonSerializer.Deserialize<WeatherData>(weatherData);

        WeatherData.Location = weatherInput!.Location;
        WeatherData.Temperature = weatherInput.Temperature;
        WeatherData.Humidity = weatherInput.Humidity;

        return WeatherData;
    }
}