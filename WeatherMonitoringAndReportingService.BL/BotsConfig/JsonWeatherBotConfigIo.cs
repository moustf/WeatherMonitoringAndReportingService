using System.Text.Json;
using WeatherMonitoringAndReportingService.BL.WeatherBots;

namespace WeatherMonitoringAndReportingService.BL.BotsConfig;

public class JsonWeatherBotConfigIo : IWeatherBotConfigIO
{
    private readonly string _pathToConfigFile;

    public JsonWeatherBotConfigIo(string pathToConfigFile)
    {
        _pathToConfigFile = pathToConfigFile;
    }
    
    public async Task<Dictionary<string, WeatherBotConfig>> ReadBotsConfigData()
    {
        var jsonText = await File.ReadAllTextAsync(_pathToConfigFile);

        var jsonSerializationSettings = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
        };
        var configBotRecords = JsonSerializer.Deserialize<Dictionary<string, WeatherBotConfig>>(jsonText, jsonSerializationSettings);

        return configBotRecords!;
    }
    
    public async Task WriteBotsConfigData(Dictionary<string, WeatherBotConfig> botConfigs)
    {
        var serializedBotConfigs = JsonSerializer.Serialize(botConfigs);
        
        await File.WriteAllTextAsync(_pathToConfigFile, serializedBotConfigs);
    }
}