namespace WeatherMonitoringAndReportingService.BL.WeatherBots;

public interface IBotPublisher
{
    void Attach(IBotSubscriber subscriberBot);
    void Detatch(IBotSubscriber subscriberBot);
    void Notify();
    Dictionary<string, WeatherBotConfig> GetConfigData();
    void SetConfigData(Dictionary<string, WeatherBotConfig> configData); 
    List<IBotSubscriber> GetSubscribers();
}