using AutoFixture;
using FluentAssertions;
using Moq;
using WeatherMonitoringAndReportingService.BL.Parsers;
using WeatherMonitoringAndReportingService.BL.Weather;

namespace WeatherMonitoringAndReportingService.Test.Parsers;

public class JsonDataParserShould
{
    [Fact]
    public void ParseJsonWeatherConfigs()
    {
        var fixture = new Fixture();
        const string weatherDataJson = "{ \"Location\": \"City Name\", \"Temperature\": 23.0, \"Humidity\": 85.0 }";
        var parser = new Mock<JsonWeatherDataParser>();
        
        fixture.Customize<WeatherData>(wd => wd
            .With(c => c.Location, "City Name")
            .With(c => c.Temperature, 23.0)
            .With(c => c.Humidity, 85.0)
        );
        var weatherData = fixture.Create<WeatherData>();
        
        var result = parser.Object.Parse(weatherDataJson);
        
        result.Should().BeEquivalentTo(weatherData);
    }
}