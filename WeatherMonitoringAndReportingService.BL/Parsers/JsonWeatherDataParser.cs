using System.Text.Json;
using WeatherMonitoringAndReportingService.BL.Weather;

namespace WeatherMonitoringAndReportingService.BL.Parsers;

public class JsonWeatherDataParser : IParser
{
    private WeatherData _weatherData;

    public JsonWeatherDataParser()
    {
        _weatherData = new WeatherData("", 0, 0);
    }

    public WeatherData Parse(string weatherData)
    {
        var weatherInput = JsonSerializer.Deserialize<WeatherData>(weatherData);

        _weatherData.Location = weatherInput!.Location;
        _weatherData.Temperature = weatherInput.Temperature;
        _weatherData.Humidity = weatherInput.Humidity;

        return _weatherData;
    }
}