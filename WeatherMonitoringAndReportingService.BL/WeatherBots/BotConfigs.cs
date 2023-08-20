namespace WeatherMonitoringAndReportingService.BL.WeatherBots;
public class WeatherBotConfig
{
    public bool Enabled { get; set; }
    public double? HumidityThreshold { get; set; }
    public double? TemperatureThreshold { get; set; }
    public string Message { get; set; }

    public WeatherBotConfig()
    {
        Enabled = false;
        HumidityThreshold = null;
        TemperatureThreshold = null;
        Message = string.Empty;
    }
}