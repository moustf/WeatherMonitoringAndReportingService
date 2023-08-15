namespace WeatherMonitoringAndReportingService.BL.WeatherBots;

public interface IBotPublisherFactory
{
    void AttachSubscribers();
    IBotPublisher GetInstance();
}