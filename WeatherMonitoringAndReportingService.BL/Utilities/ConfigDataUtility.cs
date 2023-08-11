using System.Text.Json;
using WeatherMonitoringAndReportingService.BL.WeatherBots;

namespace WeatherMonitoringAndReportingService.BL.Utilities;

public static class ConfigDataUtility
{
    private static readonly string PathToConfigFile;

    static ConfigDataUtility()
    {
        var generalBusinessLayerDirectory = Directory
            .GetCurrentDirectory()
            .Split('/')
            .TakeWhile(directory => directory != "bin");

        PathToConfigFile = $"{string.Join('/', generalBusinessLayerDirectory)}/Configurations/Bots.config.json";
    }
    
    public static async Task<Dictionary<string, WeatherBotConfig>> ReadBotsConfigData()
    {
        var jsonText = await File.ReadAllTextAsync(PathToConfigFile);

        var jsonSerializationSettings = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
        };
        var configBotRecords = JsonSerializer.Deserialize<Dictionary<string, WeatherBotConfig>>(jsonText, jsonSerializationSettings);

        return configBotRecords!;
    }

    public static async Task WriteBotsConfigData(Dictionary<string, WeatherBotConfig> botConfigs)
    {
        var serializedBotConfigs = JsonSerializer.Serialize(botConfigs);
        
        await File.WriteAllTextAsync(PathToConfigFile, serializedBotConfigs);
    }
}
