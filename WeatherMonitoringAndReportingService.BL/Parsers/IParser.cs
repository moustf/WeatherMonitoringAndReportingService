using WeatherMonitoringAndReportingService.BL.Weather;

namespace WeatherMonitoringAndReportingService.BL.Parsers;

public interface IParser
{
    WeatherData Parse(string weatherData);
}
