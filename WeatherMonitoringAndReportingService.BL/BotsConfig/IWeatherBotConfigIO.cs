using WeatherMonitoringAndReportingService.BL.WeatherBots;

namespace WeatherMonitoringAndReportingService.BL.BotsConfig;

public interface IWeatherBotConfigIO
{
    Task<Dictionary<string, WeatherBotConfig>> ReadBotsConfigData();

    Task WriteBotsConfigData(Dictionary<string, WeatherBotConfig> botConfigs);
}