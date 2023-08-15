using WeatherMonitoringAndReportingService.BL.Weather;
using WeatherMonitoringAndReportingService.BL.WeatherBots;

namespace WeatherMonitoringAndReportingService.BL.Common.Utilities;

public static class WeatherAnalysisUtility
{
    
    public static Dictionary<string, WeatherBotConfig> AnalyzeWeatherData(
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

        return botConfigs;
    }
}