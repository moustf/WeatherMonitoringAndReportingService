using AutoFixture;
using FluentAssertions;
using Moq;
using WeatherMonitoringAndReportingService.BL.Parsers;
using WeatherMonitoringAndReportingService.BL.Weather;

namespace WeatherMonitoringAndReportingService.Test.Parsers;

public class XmlDataParserShould
{
    [Fact]
    public void ParseXmlWeatherConfig()
    {
        var fixture = new Fixture();
        const string weatherDataXml = @"<WeatherData><Location>City Name</Location><Temperature>23.0</Temperature><Humidity>85.0</Humidity></WeatherData>";
        var parser = new Mock<XmlWeatherDataParser>();
        
        fixture.Customize<WeatherData>(wd => wd
            .With(c => c.Location, "City Name")
            .With(c => c.Temperature, 23.0)
            .With(c => c.Humidity, 85.0)
        );
        var weatherData = fixture.Create<WeatherData>();
        
        var result = parser.Object.Parse(weatherDataXml);
        
        result.Should().BeEquivalentTo(weatherData);
    }
}