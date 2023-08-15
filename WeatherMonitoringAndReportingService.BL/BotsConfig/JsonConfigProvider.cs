namespace WeatherMonitoringAndReportingService.BL.BotsConfig;

public sealed class JsonConfigProvider
{
    private static readonly Lazy<IWeatherBotConfigIO> Lazy = new (() =>
    {
        var jsonConfigBuilder = new JsonConfigBuilder();
        jsonConfigBuilder.GetConfigFilePath();
        jsonConfigBuilder.CreateInstance();
        return jsonConfigBuilder.GetInstance();
    });
    public static IWeatherBotConfigIO Instance => Lazy.Value;
    
    private JsonConfigProvider() {  }

}