using AutoFixture;
using FluentAssertions;
using Moq;
using WeatherMonitoringAndReportingService.BL.BotsConfig;
using WeatherMonitoringAndReportingService.BL.WeatherBots;

namespace WeatherMonitoringAndReportingService.Test.BotsConfig;

public class JsonConfigShould
{
    [Fact]
    public async Task ReadWeatherDataFromConfigFile()
    {
        var jsonConfigBuilder = new Mock<JsonConfigBuilder>();
        jsonConfigBuilder.Object.GetConfigFilePath();
        jsonConfigBuilder.Object.CreateInstance();
        var jsonConfigInstance = jsonConfigBuilder.Object.GetInstance();
        
        var result = await jsonConfigInstance.ReadBotsConfigData();
        
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        Assert.Contains("RainBot", result.Keys);
        Assert.Contains("SnowBot", result.Keys);
        Assert.Contains("SunBot", result.Keys);
    }
    
    [Fact]
    public async Task WriteBotsConfigDataSerializesAndWritesDataToFile()
    {
        // Arrange
        var fixture = new Fixture();
        var botConfigs = fixture.Create<Dictionary<string, WeatherBotConfig>>();
        
        var jsonConfigBuilder = new Mock<JsonConfigBuilder>();
        jsonConfigBuilder.Object.GetConfigFilePath();
        jsonConfigBuilder.Object.CreateInstance();
        var jsonConfigIo = jsonConfigBuilder.Object.GetInstance();

        // Act
        await jsonConfigIo.WriteBotsConfigData(botConfigs);
        var configs = await jsonConfigIo.ReadBotsConfigData();
        
        // Assert.
        configs.Should().BeEquivalentTo(botConfigs);
    }
}
