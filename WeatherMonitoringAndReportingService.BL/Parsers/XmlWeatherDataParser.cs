using System.Xml.Serialization;
using WeatherMonitoringAndReportingService.BL.Utilities;
using WeatherMonitoringAndReportingService.BL.Weather;

namespace WeatherMonitoringAndReportingService.BL.Parsers;

public class XmlWeatherDataParser : IParser
{
    private WeatherData WeatherData { get; set; }
    
    public XmlWeatherDataParser()
    {
        WeatherData = new WeatherData("", 0, 0);
    }

    public WeatherData Parse(string weatherData)
    {
        var xmlStream = StringStreamUtility.GenerateStreamFromString(weatherData);
        var xmlSerializer = new XmlSerializer(typeof(WeatherData));
        var weatherObject = (WeatherData)xmlSerializer.Deserialize(xmlStream)!;
        

        WeatherData.Location = weatherObject.Location;
        WeatherData.Temperature = weatherObject.Temperature;
        WeatherData.Humidity = weatherObject.Humidity;

        return WeatherData;
    }
}
