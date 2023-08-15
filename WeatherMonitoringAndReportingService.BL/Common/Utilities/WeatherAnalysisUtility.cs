using WeatherMonitoringAndReportingService.BL.BotsConfig;
using WeatherMonitoringAndReportingService.BL.Weather;
using WeatherMonitoringAndReportingService.BL.WeatherBots;

namespace WeatherMonitoringAndReportingService.BL.Utilities;

public static class WeatherAnalysisUtility
{
    private static IWeatherBotConfigIO _jsonWeatherConfig;
    static WeatherAnalysisUtility()
    {
        _jsonWeatherConfig = JsonConfigProvider.Instance;
    }
    
    public static async Task<Dictionary<string, WeatherBotConfig>> AnalyzeWeatherData(
        WeatherData weatherData, Dictionary<string, WeatherBotConfig> botConfigs
        )
    {
        if (weatherData.Humidity > botConfigs["RainBot"].HumidityThreshold)
        {
            botConfigs["SunBot"].Enabled = true;
        }
        
        if (weatherData.Temperature > botConfigs["SunBot"].TemperatureThreshold)
        {
            botConfigs["SunBot"].Enabled = true;
        }
        
        if (weatherData.Temperature < botConfigs["SnowBot"].TemperatureThreshold)
        {
            botConfigs["SunBot"].Enabled = true;
        }

        await _jsonWeatherConfig.WriteBotsConfigData(botConfigs);
        return botConfigs;
    }
}