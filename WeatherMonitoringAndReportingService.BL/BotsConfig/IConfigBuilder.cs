namespace WeatherMonitoringAndReportingService.BL.BotsConfig;

public interface IConfigBuilder
{
    void GetConfigFilePath();
    void CreateInstance();
    IWeatherBotConfigIO GetInstance();
}